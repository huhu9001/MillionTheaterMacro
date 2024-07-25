using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

namespace MilishitaMacro {
    public partial class FormMain : Form {
        SongName[] songs;
        JsonAppendage appendage;

        string dir_TXT, dir_ASS;
        string[] dir_CFG = new string[6];

        bool b_changed_songname;
        bool settings_changed;

        public FormMain() {
            InitializeComponent();

            combo_ver.DataSource = CodecSettings.versions;
            combo_ver.DisplayMember = "name";
            combo_ver.SelectedIndex = 0;

            combo_difficulty.DataSource = CodecSettings.diffs;
            combo_difficulty.DisplayMember = "displayName";
            combo_difficulty.SelectedIndex = 5;

            try {
                StreamReader saved_songs = new StreamReader(new FileStream("songs.txt", FileMode.Open, FileAccess.Read));
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
            catch (Exception) { songs = new SongName[0]; }
            b_changed_songname = false;

            try {
                StreamReader saved_dirs = new StreamReader(new FileStream("settings.ini", FileMode.Open, FileAccess.Read));
                string txt_ini = saved_dirs.ReadToEnd();
                saved_dirs.Close();
                Match m;
                dir_TXT = (m = Regex.Match(txt_ini, @"^\s*dirTXT\s*=\s*(.+?)\s*$", RegexOptions.Multiline)).Success ? m.Groups[1].Value : "";
                dir_ASS = (m = Regex.Match(txt_ini, @"^\s*dirASS\s*=\s*(.+?)\s*$", RegexOptions.Multiline)).Success ? m.Groups[1].Value : "";
                dir_CFG[0] = (m = Regex.Match(txt_ini, @"^\s*dirCFG2S\s*=\s*(.+?)\s*$", RegexOptions.Multiline)).Success ? m.Groups[1].Value : "";
                dir_CFG[1] = (m = Regex.Match(txt_ini, @"^\s*dirCFG2P\s*=\s*(.+?)\s*$", RegexOptions.Multiline)).Success ? m.Groups[1].Value : "";
                dir_CFG[2] = (m = Regex.Match(txt_ini, @"^\s*dirCFG2M\s*=\s*(.+?)\s*$", RegexOptions.Multiline)).Success ? m.Groups[1].Value : "";
                dir_CFG[3] = (m = Regex.Match(txt_ini, @"^\s*dirCFG4M\s*=\s*(.+?)\s*$", RegexOptions.Multiline)).Success ? m.Groups[1].Value : "";
                dir_CFG[4] = (m = Regex.Match(txt_ini, @"^\s*dirCFG6M\s*=\s*(.+?)\s*$", RegexOptions.Multiline)).Success ? m.Groups[1].Value : "";
                dir_CFG[5] = (m = Regex.Match(txt_ini, @"^\s*dirCFGMM\s*=\s*(.+?)\s*$", RegexOptions.Multiline)).Success ? m.Groups[1].Value : "";
                int ParseIntOr(string s, int def) { try { return int.Parse(s); } catch (Exception) { return def; } }
                combo_ver.SelectedIndex = (m = Regex.Match(txt_ini, @"^\s*verMacro\s*=\s*(.+?)\s*$", RegexOptions.Multiline)).Success ? ParseIntOr(m.Groups[1].Value, 0) : 0;
                num_downNum.Value = (m = Regex.Match(txt_ini, @"^\s*delayClick\s*=\s*(.+?)\s*$", RegexOptions.Multiline)).Success ? ParseIntOr(m.Groups[1].Value, 0) : 0;
                num_moveNum.Value = (m = Regex.Match(txt_ini, @"^\s*delayMove\s*=\s*(.+?)\s*$", RegexOptions.Multiline)).Success ? ParseIntOr(m.Groups[1].Value, 0) : 0;
                num_Den.Value = (m = Regex.Match(txt_ini, @"^\s*delayDen\s*=\s*(.+?)\s*$", RegexOptions.Multiline)).Success ? ParseIntOr(m.Groups[1].Value, 1) : 1;
                num_nCmdScpt.Value = (m = Regex.Match(txt_ini, @"^\s*nCmdScpt\s*=\s*(.+?)\s*$", RegexOptions.Multiline)).Success ? ParseIntOr(m.Groups[1].Value, 0) : 0;
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
            settings_changed = false;

            try {
                StreamReader file_ap = new StreamReader(new FileStream("ap.json", FileMode.Open, FileAccess.Read));
                appendage = JsonConvert.DeserializeObject<JsonAppendage>(file_ap.ReadToEnd());
                file_ap.Close();
            }
            catch (FileNotFoundException) {
                appendage = new JsonAppendage();
                try {
                    StreamWriter file_ap = new StreamWriter(new FileStream("ap.json", FileMode.Create));
                    file_ap.WriteLine("{");
                    file_ap.WriteLine("    \"tap\":[],");
                    file_ap.WriteLine("    \"zoom\":[],");
                    file_ap.WriteLine("    \"repeat\":[],");
                    file_ap.WriteLine("    \"combo\":[],");
                    file_ap.WriteLine("}");
                    file_ap.Close();
                }
                catch (Exception) { }
            }
            catch (Exception err) {
                appendage = new JsonAppendage();
                MessageBox.Show("Loading appendage JSON error, please check ap.json in the program directory: " + err.Message);
            }
            if (appendage.tap.Length == 0 && appendage.zoom.Length == 0 && appendage.repeat.Length == 0 && appendage.combo.Length != 0)
                appendage.tap = new JsonAppendage.Tap[] { new JsonAppendage.Tap(25, 25, "") };
        }
        
        private void form_main_FormClosing(object sender, FormClosingEventArgs e) {
            if (b_changed_songname) try {
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

            if (settings_changed) try {
                    StreamWriter saved_dirs = new StreamWriter(new FileStream("settings.ini", FileMode.Create));
                    string s;
                    if ((s = dir_TXT.Trim()) != "") saved_dirs.WriteLine("dirTXT=" + s);
                    if ((s = dir_ASS.Trim()) != "") saved_dirs.WriteLine("dirASS=" + s);
                    if ((s = dir_CFG[0].Trim()) != "") saved_dirs.WriteLine("dirCFG2S=" + s);
                    if ((s = dir_CFG[1].Trim()) != "") saved_dirs.WriteLine("dirCFG2P=" + s);
                    if ((s = dir_CFG[2].Trim()) != "") saved_dirs.WriteLine("dirCFG2M=" + s);
                    if ((s = dir_CFG[3].Trim()) != "") saved_dirs.WriteLine("dirCFG4M=" + s);
                    if ((s = dir_CFG[4].Trim()) != "") saved_dirs.WriteLine("dirCFG6M=" + s);
                    if ((s = dir_CFG[5].Trim()) != "") saved_dirs.WriteLine("dirCFGMM=" + s);
                    if (combo_ver.SelectedIndex > 0) saved_dirs.WriteLine("verMacro=" + combo_ver.SelectedIndex);
                    if (num_downNum.Value > 0) saved_dirs.WriteLine("delayClick=" + num_downNum.Value);
                    if (num_moveNum.Value > 0) saved_dirs.WriteLine("delayMove=" + num_moveNum.Value);
                    if (num_Den.Value > 1) saved_dirs.WriteLine("delayDen=" + num_Den.Value);
                    if (num_nCmdScpt.Value > 0) saved_dirs.WriteLine("nCmdScpt=" + num_nCmdScpt.Value);
                    saved_dirs.Close();
            }
            catch (Exception) { }
        }

        private string ReadWithProgress(StreamReader reader, long total) {
            if (total > 0) {
                if (total > int.MaxValue) throw new ArgumentOutOfRangeException();
                StringBuilder builder = new StringBuilder((int)total);
                char[] buffer = new char[0x1000];
                int current = 0;
                Invoke(new Action(() => { pgbar_main.Value = 0; }));
                while (!reader.EndOfStream) {
                    int n = reader.Read(buffer, 0, 0x1000);
                    builder.Append(buffer, 0, n);
                    current += n;
                    Invoke(new Action(() => {
                        pgbar_main.Value = (int)(current * 100 / total);
                    }));
                }
                Invoke(new Action(() => { pgbar_main.Value = 0; }));
                return builder.ToString();
            }
            else return reader.ReadToEnd();
        }

        private void button_Save_Click(object sender, EventArgs e) {
            int index_diff_selected;
            if ((index_diff_selected = combo_difficulty.SelectedIndex) == -1) return;
            string name_save = textb_SongName.Text + '_' + CodecSettings.diffs[index_diff_selected].shortName + ".cfg";
            SaveFileDialog d_save = new SaveFileDialog {
                FileName = name_save,
                Filter = "CFG files (*.cfg)|*.cfg|All files (*.*)|*.*",
                InitialDirectory = dir_CFG[index_diff_selected],
            };
            if (d_save.ShowDialog() == DialogResult.OK) {
                string dir_new = Path.GetDirectoryName(d_save.FileName);
                if (dir_CFG[index_diff_selected] != dir_new) {
                    settings_changed = true; dir_CFG[index_diff_selected] = dir_new;
                }
                
                int n_con = appendage.tap.Length + appendage.zoom.Length + appendage.repeat.Length + appendage.combo.Length + 2;
                CodecSettings settings = new CodecSettings(
                    ((MacroVersion)combo_ver.SelectedItem).value,
                    index_diff_selected,
                    Convert.ToInt32(num_nCmdScpt.Value),
                    Convert.ToInt32(num_downNum.Value),
                    Convert.ToInt32(num_moveNum.Value),
                    Convert.ToInt32(num_Den.Value));
                
                try {
                    string output;
                    switch (settings.version) {
                        default: output_000.Text += "Macro version error."; return;
                        case (int)MacroVersion.Value.BluestacksParser13:
                            output = JsonConvert.SerializeObject(MacroCodec.ConvertMacroV13(
                                text_Score.Lines,
                                appendage,
                                textb_SongName.Text,
                                ref settings));
                            break;
                        case (int)MacroVersion.Value.BluestacksParser17:
                            output = JsonConvert.SerializeObject(MacroCodec.ConvertMacroV17(
                                text_Score.Lines,
                                appendage,
                                textb_SongName.Text,
                                ref settings));
                            break;
                    }

                    StreamWriter sw_save = new StreamWriter(new FileStream(d_save.FileName, FileMode.Create));
                    sw_save.Write(output);
                    sw_save.Close();
                }
                catch (Exception err) { output_000.Text += err.Message; }
                
                button_Save.Text = "Save";
            }
        }

        private void button_Download_Click(object sender, EventArgs e) {
            int index_song_selected, index_diff_selected;
            if ((index_song_selected = combo_SongName.SelectedIndex) == -1) return;
            if ((index_diff_selected = combo_difficulty.SelectedIndex) == -1) return;
            button_Download.Enabled = false;
            button_Save.Enabled = false;
            textb_SongName.Text = songs[index_song_selected].fullName;
            
            Task t = new Task(() => {
                try {
                    HttpWebRequest xhr = (HttpWebRequest)WebRequest.Create("https://million.hyrorre.com/musics/" +
                        songs[index_song_selected].urlName +
                        "/" +
                        CodecSettings.diffs[index_diff_selected].urlName);
                    xhr.Method = "GET";

                    Invoke(new Action(() => { output_000.Text = "Connecting... " + Environment.NewLine; }));
                    
                    HttpWebResponse xhrr = xhr.GetResponse() as HttpWebResponse;

                    Invoke(new Action(() => { output_000.Text += "Downloading..." + Environment.NewLine; }));

                    StreamReader reader = new StreamReader(xhrr.GetResponseStream());
                    string string_sr = ReadWithProgress(reader, xhrr.ContentLength);
                    reader.Close();

                    Match m_u = Regex.Match(string_sr, "(?<=<div id=\"score_str\">)[^<]*");
                    if (!m_u.Success) throw new Exception("Notes information is not found.");

                    string_sr = Regex.Replace(m_u.Value, "&quot;", "\"");

                    Invoke(new Action(() => { output_000.Text += "ParsingJSON..." + Environment.NewLine; }));

                    JsonScoreMltd js_notes = JsonConvert.DeserializeObject<JsonScoreMltd>(string_sr);
                    StringBuilder strb = new StringBuilder();
                    foreach (string line in MacroCodec.FromScoreMltd(js_notes, index_diff_selected)) {
                        strb.Append(line);
                        strb.Append(Environment.NewLine);
                    }
                    text_Score.Text = strb.ToString();

                    Invoke(new Action(() => {
                        output_000.Text += "Success.";
                        button_Save.Enabled = true;
                        button_Download.Enabled = true;

                        button_Save.Text = "Save*";
                        b_SaveTXT.Text = "Save TXT*";
                        tabC_main.SelectedIndex = 0;
                    }));
                }
                catch (Exception err) {
                    Invoke(new Action(() => {
                        output_000.Text += err.Message;
                        button_Download.Enabled = true;
                    }));
                }
            });
            t.Start();
        }

        private void button_updateSong_Click(object sender, EventArgs e) {
            button_updateSong.Enabled = false;

            new Task(() => {
                try {
                    HttpWebRequest xhr = (HttpWebRequest)WebRequest.Create("https://million.hyrorre.com/");
                    xhr.Method = "GET";
                    
                    Invoke(new Action(() => { output_000.Text = "Connecting... " + Environment.NewLine; }));

                    HttpWebResponse xhrr = (HttpWebResponse)xhr.GetResponse();
                    StreamReader reader = new StreamReader(xhrr.GetResponseStream());
                    string string_sr = ReadWithProgress(reader, xhrr.ContentLength);
                    reader.Close();

                    Invoke(new Action(() => { output_000.Text += "ProcessingText..." + Environment.NewLine; }));

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

                    b_changed_songname = true;
                    Invoke(new Action(() => {
                        combo_SongName.DataSource = songs;
                        output_000.Text += "Success.";
                        button_updateSong.Enabled = true;
                    }));
                }
                catch(Exception err) {
                    Invoke(new Action(() => {
                        output_000.Text += err.Message;
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
                string dir_new = Path.GetDirectoryName(d_load.FileName);
                if (dir_ASS != dir_new) { settings_changed = true; dir_ASS = dir_new; }
                try {
                    Match m_u;
                    List<string> s_ass = new List<string>();
                    StreamReader sr_ass = new StreamReader(new FileStream(d_load.FileName, FileMode.Open, FileAccess.Read));
                    for(; !sr_ass.EndOfStream; ) {
                        m_u = Regex.Match(sr_ass.ReadLine(), "(?:Dialogue|Comment):[^,]*,([^,]*),[^,]*,[^,]*,[^,]*,[^,]*,[^,]*,[^,]*,[^,]*,([^,]*)");
                        if (m_u.Success) {
                            s_ass.Add(m_u.Groups[1] + "," + m_u.Groups[2]);
                        }
                    }
                    sr_ass.Close();
                    text_Score.Text = string.Join(Environment.NewLine, s_ass);

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

                    button_Save.Text = "Save*";
                    b_SaveTXT.Text = "Save TXT*";
                }
                catch (Exception err) { output_000.Text = err.Message; }
            }
        }

        private void textScore_Change(object sender, EventArgs e) {
            if (text_Score.Text == "") {
                b_SaveTXT.Text = "Save TXT";
                button_Save.Text = "Save";
            }
            else {
                b_SaveTXT.Text = "Save TXT*";
                button_Save.Text = "Save*";
            }
        }

        private void b_LoadText_Click(object sender, EventArgs e)
        {
            OpenFileDialog d_load = new OpenFileDialog {
                Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = dir_TXT,
            };
            if (d_load.ShowDialog() == DialogResult.OK) {
                string dir_new = Path.GetDirectoryName(d_load.FileName);
                if (dir_TXT != dir_new) { settings_changed = true; dir_TXT = dir_new; }
                try
                {
                    Match m_u;
                    List<string> s_ass = new List<string>();
                    StreamReader sr_ass = new StreamReader(new FileStream(d_load.FileName, FileMode.Open, FileAccess.Read));
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

                    button_Save.Text = "Save*";
                    b_SaveTXT.Text = "Save TXT";
                }
                catch (Exception err) { output_000.Text = err.Message; }
            }
        }

        private void b_SaveTXT_Click(object sender, EventArgs e)
        {
            SaveFileDialog d_save = new SaveFileDialog {
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
            if (d_save.ShowDialog() == DialogResult.OK) {
                string dir_new = Path.GetDirectoryName(d_save.FileName);
                if (dir_TXT != dir_new) { settings_changed = true; dir_TXT = dir_new; }
                try {
                    StreamWriter sw_save = new StreamWriter(new FileStream(d_save.FileName, FileMode.Create));
                    sw_save.Write(text_Score.Text);
                    sw_save.Close();

                    b_SaveTXT.Text = "Save TXT";
                }
                catch (Exception err) { output_000.Text = err.Message; }
            }
        }

        private void b_reworkAp_Click(object sender, EventArgs e) {
            uint count = 0, count_success = 0, count_failure = 0;
            bool isOlder = cb_old.Checked;
            bool isApOnly = sender == b_reworkAp;
            CodecSettings settings = new CodecSettings(
                ((MacroVersion)combo_ver.SelectedItem).value,
                combo_difficulty.SelectedIndex,
                Convert.ToInt32(num_nCmdScpt.Value),
                Convert.ToInt32(num_downNum.Value),
                Convert.ToInt32(num_moveNum.Value),
                Convert.ToInt32(num_Den.Value));

            Task t = new Task(() => {
                string[] files_cfg = Directory.GetFiles(tb_reworkF.Text, "*.cfg", SearchOption.AllDirectories);
                int n_cfg = files_cfg.Length;
                foreach (string f_cfg in files_cfg) {
                    count += 1;
                    try {
                        string so;

                        if (isOlder && new FileInfo(f_cfg).LastWriteTime >= mc_old.SelectionStart) continue;
                        if (isApOnly) {
                            StreamReader fr = new StreamReader(new FileStream(f_cfg, FileMode.Open, FileAccess.Read));
                            string si = fr.ReadToEnd();
                            fr.Close();

                            switch (settings.version) {
                                default: throw new Exception("Invalid macro version.");
                                case (int)MacroVersion.Value.BluestacksParser13: {
                                        JsonMacroBs13 macro = JsonConvert.DeserializeObject<JsonMacroBs13>(si, new JsonSerializerSettings {
                                            TypeNameHandling = TypeNameHandling.All,
                                            SerializationBinder = new JsonMacroBs13.PrimitiveTypesBinder(),
                                        });
                                        macro.Primitives = MacroCodec.ChangeAppendage(macro.Primitives, appendage);
                                        so = JsonConvert.SerializeObject(macro);
                                    }
                                    break;
                                case (int)MacroVersion.Value.BluestacksParser17: {
                                        JsonMacroBs17 macro = JsonConvert.DeserializeObject<JsonMacroBs17>(si, new JsonSerializerSettings {
                                            TypeNameHandling = TypeNameHandling.All,
                                            SerializationBinder = new JsonMacroBs17.class_ControlSchemes.GameControlsTypesBinder(),
                                        });
                                        macro.ControlSchemes[0].GameControls = MacroCodec.ChangeAppendage(macro.ControlSchemes[0].GameControls, appendage);
                                        so = JsonConvert.SerializeObject(macro);
                                    }
                                    break;
                            }
                        }
                        else {
                            string filename = Path.GetFileNameWithoutExtension(f_cfg);
                            string songname = filename.Substring(0, filename.Length - 3);
                            DiffName diff;
                            switch (filename.Substring(filename.Length - 2)) {
                                default:
                                    diff = CodecSettings.diffs[5];
                                    songname = filename;
                                    break;
                                case "2s":
                                    diff = CodecSettings.diffs[0]; break;
                                case "2p":
                                    diff = CodecSettings.diffs[1]; break;
                                case "2m":
                                    diff = CodecSettings.diffs[2]; break;
                                case "4m":
                                    diff = CodecSettings.diffs[3]; break;
                                case "6m":
                                    diff = CodecSettings.diffs[4]; break;
                                case "mm":
                                    diff = CodecSettings.diffs[5]; break;
                            }

                            StreamReader fr = new StreamReader(new FileStream(dir_TXT + "\\" + filename + ".txt", FileMode.Open, FileAccess.Read));
                            IEnumerable<string> RL(TextReader tr) {
                                while (tr.Peek() != -1) yield return tr.ReadLine();
                            }
                            switch (settings.version) {
                                default: fr.Close(); throw new Exception("Invalid macro version.");
                                case (int)MacroVersion.Value.BluestacksParser13: {
                                        JsonMacroBs13 macro = MacroCodec.ConvertMacroV13(RL(fr), appendage, songname, ref settings);
                                        fr.Close();
                                        so = JsonConvert.SerializeObject(macro);
                                    }
                                    break;
                                case (int)MacroVersion.Value.BluestacksParser17: {
                                        JsonMacroBs17 macro = MacroCodec.ConvertMacroV17(RL(fr), appendage, songname, ref settings);
                                        fr.Close();
                                        so = JsonConvert.SerializeObject(macro);
                                    }
                                    break;
                            }
                        }

                        StreamWriter fw = new StreamWriter(new FileStream(f_cfg, FileMode.Create));
                        fw.Write(so);
                        fw.Close();

                        ++count_success;
                    }
                    catch (FileNotFoundException) {}
                    catch (Exception err) {
                        Invoke(new Action(() => { output_000.Text += err.Message + Environment.NewLine; }));
                        ++count_failure;
                        if (count_failure > 4) {
                            Invoke(new Action(() => {
                                output_000.Text += "Too many errors. Reworking aborted." + Environment.NewLine;
                            }));
                            break;
                        }
                    }
                    Invoke(new Action(() => {
                        pgbar_main.Value = (int)count * 100 / n_cfg;
                    }));
                }
                Invoke(new Action(() => {
                    pgbar_main.Value = 0;
                    output_000.Text += count_success + " out of " + n_cfg + " files updated.";
                }));
            });

            output_000.Text = "Start reworking..." + Environment.NewLine;
            b_rework.Enabled = false;
            b_reworkAp.Enabled = false;
            cb_old.Enabled = false;
            mc_old.Enabled = false;
            pgbar_main.Value = 0;
            t.Start();
            b_rework.Enabled = true;
            b_reworkAp.Enabled = true;
            cb_old.Enabled = true;
            mc_old.Enabled = true;
        }

        private void b_reworkBrowse_Click(object sender, EventArgs e) {
            FolderBrowserDialog d_load = new FolderBrowserDialog {};
            if (d_load.ShowDialog() == DialogResult.OK) {
                tb_reworkF.Text = d_load.SelectedPath;
            }
        }

        private void SettingControlsChanged(object sender, EventArgs e) { settings_changed = true; }
    }
}
