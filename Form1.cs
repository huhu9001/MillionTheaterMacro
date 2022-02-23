using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.IO;
using System.Text.RegularExpressions;

using Newtonsoft.Json;


namespace MilishitaMacro {
    public partial class form_main : Form {

        SongName[] songs;
        DiffName[] diffs = {
                new DiffName(0),
                new DiffName(1),
                new DiffName(2),
                new DiffName(3),
                new DiffName(4),
                new DiffName(5),
        };
        int index_song_selected;
        int index_diff_selected;
        string name_save;
        Js_notes_OBJ js_notes;
        Js_macro_OBJ js_macro = new Js_macro_OBJ();

        string dir_TXT, dir_ASS;
        string[] dir_CFG = new string[6];

        public form_main() {
            InitializeComponent();
            combo_difficulty.DataSource = diffs;
            combo_difficulty.SelectedIndex = 5;

            try {
                StreamReader saved_songs = new StreamReader(new FileStream("songs.txt", FileMode.Open));
                int songs_size = int.Parse(saved_songs.ReadLine());
                songs = new SongName[songs_size];
                {
                    int i0;
                    string s1, s2;
                    for (i0 = 0; i0 < songs_size; ++i0) {
                        s1 = saved_songs.ReadLine();
                        s2 = saved_songs.ReadLine();
                        songs[i0] = new SongName(s1, s2);
                    }
                }
                saved_songs.Close();
                combo_SongName.DataSource = songs;
                button_Download.Enabled = true;
            }
            catch (Exception) { }

            try
            {
                StreamReader saved_dirs = new StreamReader(new FileStream("dirs.txt", FileMode.Open));
                dir_TXT = saved_dirs.ReadLine();
                dir_ASS = saved_dirs.ReadLine();
                dir_CFG[0] = saved_dirs.ReadLine();
                dir_CFG[1] = saved_dirs.ReadLine();
                dir_CFG[2] = saved_dirs.ReadLine();
                dir_CFG[3] = saved_dirs.ReadLine();
                dir_CFG[4] = saved_dirs.ReadLine();
                dir_CFG[5] = saved_dirs.ReadLine();
                saved_dirs.Close();
            }
            catch(Exception) {
                dir_TXT = "";
                dir_ASS = "";
                dir_CFG[0] = "";
                dir_CFG[1] = "";
                dir_CFG[2] = "";
                dir_CFG[3] = "";
                dir_CFG[4] = "";
                dir_CFG[5] = "";
            }
        }
        
        private void form_main_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                StreamWriter saved_songs = new StreamWriter(new FileStream("songs.txt", FileMode.Create));
                int songs_size = songs.Length;
                saved_songs.WriteLine(songs_size.ToString());
                for(int i0 = 0; i0 < songs_size; ++i0) {
                    saved_songs.WriteLine(songs[i0].fullName);
                    saved_songs.WriteLine(songs[i0].urlName);
                }
                saved_songs.Close();
            }
            catch (Exception) { }

            try
            {
                StreamWriter saved_dirs = new StreamWriter(new FileStream("dirs.txt", FileMode.Create));
                saved_dirs.WriteLine(dir_TXT);
                saved_dirs.WriteLine(dir_ASS);
                saved_dirs.WriteLine(dir_CFG[0]);
                saved_dirs.WriteLine(dir_CFG[1]);
                saved_dirs.WriteLine(dir_CFG[2]);
                saved_dirs.WriteLine(dir_CFG[3]);
                saved_dirs.WriteLine(dir_CFG[4]);
                saved_dirs.WriteLine(dir_CFG[5]);
                saved_dirs.Close();
            }
            catch (Exception) { }
        }

        private void button_Save_Click(object sender, EventArgs e) {
            SaveFileDialog d_save = new SaveFileDialog {
                FileName = name_save,
                Filter = "CFG files (*.cfg)|*.cfg|All files (*.*)|*.*",
                InitialDirectory = dir_CFG[index_diff_selected],
            };
            if (d_save.ShowDialog() == DialogResult.OK) {
                dir_CFG[index_diff_selected] = Path.GetDirectoryName(d_save.FileName);
                try {
                    StreamWriter sw_save = new StreamWriter(new FileStream(d_save.FileName, FileMode.Create));
                    sw_save.Write(JsonConvert.SerializeObject(js_macro));
                    sw_save.Close();

                    button_Save.Text = "Save";
                }
                catch (Exception err) {
                    output_000.Text += "\r\n" + err.Message;
                }
            }
        }

        private void button_Download_Click(object sender, EventArgs e) {
            if ((index_song_selected = combo_SongName.SelectedIndex) == -1) return;
            if ((index_diff_selected = combo_difficulty.SelectedIndex) == -1) return;
            button_Download.Enabled = false;
            button_Save.Enabled = false;
            button_FromMacros.Enabled = false;
            name_save = songs[index_song_selected].fullName + "_" + diffs[index_diff_selected].shortName + ".cfg";
            
            output_000.Text = "";
            Task t = new Task(() => {
                try {
                    HttpWebRequest xhr = (HttpWebRequest)WebRequest.Create("https://million.hyrorre.com/musics/" +
                        songs[index_song_selected].urlName +
                        "/" +
                        diffs[index_diff_selected].urlName);
                    xhr.Method = "GET";

                    Invoke(new Action(() => { output_000.Text += "Connecting... "; }));

                    HttpWebResponse xhrr = xhr.GetResponse() as HttpWebResponse;

                    Invoke(new Action(() => { output_000.Text += "Success.\r\nProcessingText..."; }));

                    StreamReader sr = new StreamReader(xhrr.GetResponseStream());
                    string string_sr = sr.ReadToEnd();
                    sr.Close();

                    Match m_u = Regex.Match(string_sr, "(?<=<div id=\"score_str\">)[^<]*");
                    if (!m_u.Success) throw new Exception("Notes information is not found.");

                    string_sr = Regex.Replace(m_u.Value, "&quot;", "\"");

                    Invoke(new Action(() => { output_000.Text += "Success.\r\nParsingJSON..."; }));

                    js_notes = JsonConvert.DeserializeObject<Js_notes_OBJ>(string_sr);

                    Converter_NotesMacro.ConvertMacro(
                        ref js_macro,
                        ref js_notes,
                        ref songs[index_song_selected],
                        ref diffs[index_diff_selected]);

                    Invoke(new Action(() => {
                        output_000.Text += "Success.";
                        button_Save.Enabled = true;
                        button_Download.Enabled = true;
                        button_FromMacros.Enabled = true;

                        button_Save.Text = "Save*";
                        b_SaveTXT.Text = "Save TXT";
                        button_ToMacros.Text = "To Macros";
                    }));
                }
                catch (Exception err) {
                    Invoke(new Action(() => { output_000.Text += "\r\n" + err.Message; }));
                    button_Download.Enabled = true;
                }
            });
            t.Start();
        }

        private void button_ToMacros_Click(object sender, EventArgs e) {
            if ((index_song_selected = combo_SongName.SelectedIndex) == -1) return;
            if ((index_diff_selected = combo_difficulty.SelectedIndex) == -1) return;
            name_save = textb_SongName.Text + "_" + diffs[index_diff_selected].shortName + ".cfg";

            if (MessageBox.Show(
                "The current difficulty is \"" + diffs[index_diff_selected].displayName + "\". Sure?",
                "Confirm",
                MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            button_ToMacros.Enabled = false;
            button_Save.Enabled = false;
            button_FromMacros.Enabled = false;

            output_000.Text = "Processing...";

            try {
                Converter_NotesMacro.ConvertMacro(
                ref js_macro,
                text_Score.Lines,
                textb_SongName.Text,
                ref diffs[index_diff_selected]);

                MessageBox.Show("Done.");
                output_000.Text += "Done.";
                button_ToMacros.Enabled = true;
                button_Save.Enabled = true;

                button_ToMacros.Text = "To Macros";
                button_Save.Text = "Save*";
            }
            catch (Exception err) {
                output_000.Text += "\r\n" + err.Message;
                button_ToMacros.Enabled = true;
            }
        }

        private void button_updateSong_Click(object sender, EventArgs e) {
            button_updateSong.Enabled = false;

            new Task(() => {
                try {
                    HttpWebRequest xhr = (HttpWebRequest)WebRequest.Create("https://million.hyrorre.com/");
                    xhr.Method = "GET";
                    
                    Invoke(new Action(() => { output_000.Text += "Connecting... "; }));
                    
                    string string_sr = new StreamReader(((HttpWebResponse)xhr.GetResponse()).GetResponseStream()).ReadToEnd();

                    Invoke(new Action(() => { output_000.Text += "Success.\r\nProcessingText..."; }));

                    Match m_u = Regex.Match(string_sr, "(?<=<ul id=\"musiclist\" class=\"list\">)[\\s\\S]*?(?=</ul>)");
                    if (!m_u.Success) throw new Exception("Songs information is not found.");
                    MatchCollection m_uc = Regex.Matches(m_u.Value, "(?<=<li>)[\\s\\S]*?(?=</li>)");
                    songs = new SongName[m_uc.Count];
                    Match m_u_1, m_u_2;
                    for (int i0 = 0; i0 < m_uc.Count; ++i0) {
                        m_u_1 = Regex.Match(m_uc[i0].Value, "(?<=<h3 class=\"title\">).*?(?=</h3>)");
                        if (!m_u_1.Success) throw new Exception("Song" + i0.ToString() + "do not have a name.");
                        m_u_2 = Regex.Match(m_uc[i0].Value, "(?<=<a href=\"/musics/).*?(?=/\\d+\">\\d+</a>)");
                        if (!m_u_1.Success) throw new Exception("Song \"" + m_u_1.Value + "\" do not have a URL.");
                        songs[i0] = new SongName(m_u_1.Value, m_u_2.Value);
                    }

                    Invoke(new Action(() => {
                        combo_SongName.DataSource = songs;
                        output_000.Text += "Success.";
                        button_updateSong.Enabled = true;
                    }));
                }
                catch(Exception err) {
                    Invoke(new Action(() => {
                        output_000.Text += "\r\n" + err.Message;
                        button_updateSong.Enabled = true;
                    }));
                }
            }).Start();
        }

        private void b_ass_Click(object sender, EventArgs e) {
            OpenFileDialog d_load = new OpenFileDialog {
                Filter = "ASS files (*.ass)|*.ass|All files (*.*)|*.*",
                InitialDirectory = dir_ASS,
            };
            if (d_load.ShowDialog() == DialogResult.OK) {
                dir_ASS = Path.GetDirectoryName(d_load.FileName);
                try {
                    Match m_u;
                    List<string> s_ass = new List<string>();
                    StreamReader sr_ass = new StreamReader(new FileStream(d_load.FileName, FileMode.Open));
                    for(; !sr_ass.EndOfStream; ) {
                        m_u = Regex.Match(sr_ass.ReadLine(), "(?:Dialogue|Comment):[^,]*,([^,]*),[^,]*,[^,]*,[^,]*,[^,]*,[^,]*,[^,]*,[^,]*,([^,]*)");
                        if (m_u.Success) {
                            s_ass.Add(m_u.Groups[1] + "," + m_u.Groups[2]);
                        }
                    }
                    sr_ass.Close();
                    text_Score.Text = string.Join("\r\n", s_ass);

                    m_u = Regex.Match(d_load.FileName, "\\\\([^\\\\_]+)_([^\\\\_]+)\\.txt$");
                    if (m_u.Success)
                    {
                        textb_SongName.Text = m_u.Groups[1].Value;
                        switch (m_u.Groups[2].Value)
                        {
                            default:
                                combo_difficulty.SelectedIndex = -1; break;
                            case "2s":
                                combo_difficulty.SelectedIndex = 0; break;
                            case "2p":
                                combo_difficulty.SelectedIndex = 1; break;
                            case "2m":
                                combo_difficulty.SelectedIndex = 2; break;
                            case "4m":
                                combo_difficulty.SelectedIndex = 3; break;
                            case "6m":
                                combo_difficulty.SelectedIndex = 4; break;
                            case "mm":
                                combo_difficulty.SelectedIndex = 5; break;
                        }
                    }

                    button_Save.Text = "Save";
                    b_SaveTXT.Text = "Save TXT*";
                    button_ToMacros.Text = "To Macros*";
                }
                catch (Exception err) {
                    output_000.Text += "\r\n" + err.Message;
                }
            }
        }

        private void button_FromMacros_Click(object sender, EventArgs e) {
            if (js_notes == null) {
                MessageBox.Show("Notes data is not loaded.");
                return;
            }

            try {
                List<string> ss = new List<string>(0x400);
                Converter_NotesMacro.MacroToString(ref ss, ref js_notes);
                text_Score.Text = string.Join("\r\n", ss);
                textb_SongName.Text = songs[index_song_selected].urlName;
                combo_difficulty.SelectedIndex = index_diff_selected;

                tabC_main.SelectedIndex = 1;
            }
            catch (Exception err) {
                output_000.Text += "\r\n" + err.Message;
            }
        }

        private void b_LoadText_Click(object sender, EventArgs e)
        {
            OpenFileDialog d_load = new OpenFileDialog
            {
                Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = dir_TXT,
            };
            if (d_load.ShowDialog() == DialogResult.OK)
            {
                dir_TXT = Path.GetDirectoryName(d_load.FileName);
                try
                {
                    Match m_u;
                    List<string> s_ass = new List<string>();
                    StreamReader sr_ass = new StreamReader(new FileStream(d_load.FileName, FileMode.Open));
                    text_Score.Text = sr_ass.ReadToEnd();
                    sr_ass.Close();

                    m_u = Regex.Match(d_load.FileName, "\\\\([^\\\\_]+)_([^\\\\_]+)\\.txt$");
                    if (m_u.Success)
                    {
                        textb_SongName.Text = m_u.Groups[1].Value;
                        switch(m_u.Groups[2].Value)
                        {
                            default:
                                combo_difficulty.SelectedIndex = -1; break;
                            case "2s":
                                combo_difficulty.SelectedIndex = 0; break;
                            case "2p":
                                combo_difficulty.SelectedIndex = 1; break;
                            case "2m":
                                combo_difficulty.SelectedIndex = 2; break;
                            case "4m":
                                combo_difficulty.SelectedIndex = 3; break;
                            case "6m":
                                combo_difficulty.SelectedIndex = 4; break;
                            case "mm":
                                combo_difficulty.SelectedIndex = 5; break;
                        }
                    }

                    button_Save.Text = "Save";
                    b_SaveTXT.Text = "Save TXT";
                    button_ToMacros.Text = "To Macros*";
                }
                catch (Exception err)
                {
                    output_000.Text += "\r\n" + err.Message;
                }
            }
        }

        private void b_SaveTXT_Click(object sender, EventArgs e)
        {
            SaveFileDialog d_save = new SaveFileDialog
            {
                FileName = textb_SongName.Text + (
                    combo_difficulty.SelectedIndex == 0 ? "_2s" :
                    combo_difficulty.SelectedIndex == 1 ? "_2p" :
                    combo_difficulty.SelectedIndex == 2 ? "_2m" :
                    combo_difficulty.SelectedIndex == 3 ? "_4m" :
                    combo_difficulty.SelectedIndex == 4 ? "_6m" :
                    combo_difficulty.SelectedIndex == 5 ? "_mm" : ""),
                Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = dir_TXT,
            };
            if (d_save.ShowDialog() == DialogResult.OK)
            {
                dir_TXT = Path.GetDirectoryName(d_save.FileName);
                try
                {
                    StreamWriter sw_save = new StreamWriter(new FileStream(d_save.FileName, FileMode.Create));
                    sw_save.Write(text_Score.Text);
                    sw_save.Close();

                    b_SaveTXT.Text = "Save TXT";
                }
                catch (Exception err)
                {
                    output_000.Text += "\r\n" + err.Message;
                }
            }
        }
    }
}
