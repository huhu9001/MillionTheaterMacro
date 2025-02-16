using Newtonsoft.Json;

using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace MilishitaMacro {
    public partial class FormMain : Form {
        private const string BT_SAVE = "Save";
        private const string BT_MAKE = "Make";

        SongName[] songs;
        JsonAppendage appendage;

        string dir_TXT, dir_ASS;
        string[] dir_CFG = new string[6];

        bool b_changed_songname;
        bool settings_changed;

        Task?task_current;

        public FormMain() {
            InitializeComponent();

            combo_ver.DataSource = CodecSettings.versions;
            combo_ver.DisplayMember = "name";
            combo_ver.SelectedIndex = 0;

            combo_difficulty.DataSource = CodecSettings.diffs;
            combo_difficulty.DisplayMember = "displayName";
            combo_difficulty.SelectedIndex = 5;

            task_current = null;

            try {
                StreamReader saved_songs = new StreamReader(new FileStream("songs.txt", FileMode.Open, FileAccess.Read));
                int songs_size = int.Parse(saved_songs.ReadLine() ?? "");
                songs = new SongName[songs_size];
                {
                    int i0;
                    string?s1, s2;
                    for (i0 = 0; i0 < songs_size; ++i0) {
                        if ((s1 = saved_songs.ReadLine()) == null) break;
                        if ((s2 = saved_songs.ReadLine()) == null) break;
                        songs[i0] = new SongName(s1, s2);
                    }
                }
                saved_songs.Close();
                combo_SongName.DataSource = songs;
                button_Download.Enabled = songs_size > 0;
            }
            catch (Exception) {
                songs = new SongName[0];
                button_Download.Enabled = false;
            }
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
                tb_vidparserDir.Text = (m = Regex.Match(txt_ini, @"^\s*dirMilishitaVideoParser\s*=\s*(.+?)\s*$", RegexOptions.Multiline)).Success ? m.Groups[1].Value : "";
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
                JsonAppendage?appendage = JsonConvert.DeserializeObject<JsonAppendage>(file_ap.ReadToEnd());
                if (appendage == null) throw new JsonException();
                this.appendage = appendage;
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
                MessageBox.Show($"Loading appendage JSON error, please check ap.json in the program directory: {err.Message}");
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
                    if ((s = dir_TXT.Trim()) != "") saved_dirs.WriteLine($"dirTXT={s}");
                    if ((s = dir_ASS.Trim()) != "") saved_dirs.WriteLine($"dirASS={s}");
                    if ((s = dir_CFG[0].Trim()) != "") saved_dirs.WriteLine($"dirCFG2S={s}");
                    if ((s = dir_CFG[1].Trim()) != "") saved_dirs.WriteLine($"dirCFG2P={s}");
                    if ((s = dir_CFG[2].Trim()) != "") saved_dirs.WriteLine($"dirCFG2M={s}");
                    if ((s = dir_CFG[3].Trim()) != "") saved_dirs.WriteLine($"dirCFG4M={s}");
                    if ((s = dir_CFG[4].Trim()) != "") saved_dirs.WriteLine($"dirCFG6M={s}");
                    if ((s = dir_CFG[5].Trim()) != "") saved_dirs.WriteLine($"dirCFGMM={s}");
                    if ((s = tb_vidparserDir.Text.Trim()) != "") saved_dirs.WriteLine($"dirMilishitaVideoParser={s}");
                    if (combo_ver.SelectedIndex > 0) saved_dirs.WriteLine($"verMacro={combo_ver.SelectedIndex}");
                    if (num_downNum.Value > 0) saved_dirs.WriteLine($"delayClick={num_downNum.Value}");
                    if (num_moveNum.Value > 0) saved_dirs.WriteLine($"delayMove={num_moveNum.Value}");
                    if (num_Den.Value > 1) saved_dirs.WriteLine($"delayDen={num_Den.Value}");
                    if (num_nCmdScpt.Value > 0) saved_dirs.WriteLine($"nCmdScpt={num_nCmdScpt.Value}");
                    saved_dirs.Close();
            }
            catch (Exception) { }
        }

        private string ReadWithProgress(StreamReader reader, long total) {
            if (total > 0 && total <= int.MaxValue) {
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

        private void DisableInput() {
            combo_difficulty.Enabled = false;
            button_Make.Enabled = false;
            tabC_main.Enabled = false;
        }

        private void EnableInput() {
            combo_difficulty.Enabled = true;
            button_Make.Enabled = true;
            tabC_main.Enabled = true;
        }

        private void button_Make_Click(object sender, EventArgs e) {
            int index_diff_selected;
            if ((index_diff_selected = combo_difficulty.SelectedIndex) == -1) return;
            string name_save = $"{textb_SongName.Text}_{CodecSettings.diffs[index_diff_selected].shortName}.cfg";
            SaveFileDialog d_save = new SaveFileDialog {
                FileName = name_save,
                Filter = "CFG files (*.cfg)|*.cfg|All files (*.*)|*.*",
                InitialDirectory = dir_CFG[index_diff_selected],
            };
            if (d_save.ShowDialog() == DialogResult.OK) {
                string?dir_new = Path.GetDirectoryName(d_save.FileName);
                if (dir_new != null && dir_CFG[index_diff_selected] != dir_new) {
                    settings_changed = true; dir_CFG[index_diff_selected] = dir_new;
                }
                
                CodecSettings settings = new CodecSettings {
                    version = ((MacroVersion)combo_ver.SelectedItem!).value,
                    nDiff = index_diff_selected,
                    numCommandPerScript = Convert.ToInt32(num_nCmdScpt.Value),
                    numDown = Convert.ToInt32(num_downNum.Value),
                    numMove = Convert.ToInt32(num_moveNum.Value),
                    den = Convert.ToInt32(num_Den.Value),
                };

                tb_output.Clear();
                try {
                    string output;
                    switch (settings.version) {
                        default: tb_output.AppendText("Macro version error."); return;
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
                catch (Exception err) { tb_output.AppendText(err.Message); }
                
                button_Make.Text = BT_MAKE;
            }
        }

        private void button_Download_Click(object sender, EventArgs e) {
            if (task_current != null) return;
            int index_song_selected, index_diff_selected;
            if ((index_song_selected = combo_SongName.SelectedIndex) == -1) return;
            if ((index_diff_selected = combo_difficulty.SelectedIndex) == -1) return;
            DisableInput();
            textb_SongName.Text = songs[index_song_selected].fullName;

            task_current = new Task(() => {
                try {
                    Invoke(new Action(() => { tb_output.Text = $"Connecting... {Environment.NewLine}"; }));

                    HttpResponseMessage reply = new HttpClient().Send(new(
                        HttpMethod.Get,
                        $"https://million.hyrorre.com/musics/{
                            songs[index_song_selected].urlName
                        }/{
                            CodecSettings.diffs[index_diff_selected].urlName
                        }"), HttpCompletionOption.ResponseHeadersRead);
                    
                    Invoke(new Action(() => {
                        tb_output.AppendText($"Downloading...{Environment.NewLine}");
                    }));

                    long length = reply.Content.Headers.ContentLength ?? 0;
                    StreamReader reader = new StreamReader(reply.Content.ReadAsStream());
                    string string_sr = ReadWithProgress(reader, length);
                    reader.Close();

                    Match m_u = Regex.Match(string_sr, "(?<=<div id=\"score_str\">)[^<]*");
                    if (!m_u.Success) throw new Exception("Notes information is not found.");

                    string_sr = Regex.Replace(m_u.Value, "&quot;", "\"");

                    Invoke(new Action(() => {
                        tb_output.AppendText($"ParsingJSON...{Environment.NewLine}");
                    }));

                    JsonScoreMltd?js_notes = JsonConvert.DeserializeObject<JsonScoreMltd>(string_sr);
                    if (js_notes == null) throw new JsonException();
                    text_Score.Lines = MacroCodec.FromScoreMltd(js_notes, index_diff_selected).ToArray();

                    Invoke(new Action(() => {
                        tb_output.AppendText("Success.");
                        EnableInput();

                        button_Make.Text = $"{BT_MAKE}*";
                        b_SaveTXT.Text = $"{BT_SAVE}*";
                        tabC_main.SelectedIndex = 0;
                    }));
                }
                catch (Exception err) {
                    Invoke(new Action(() => {
                        tb_output.AppendText(err.Message);
                        EnableInput();
                    }));
                }
                task_current = null;
            });
            task_current.Start();
        }

        private void button_updateSong_Click(object sender, EventArgs e) {
            if (task_current != null) return;
            DisableInput();
            
            task_current = new Task(() => {
                try {
                    Invoke(new Action(() => {
                        tb_output.Text = $"Connecting... {Environment.NewLine}";
                    }));

                    HttpResponseMessage reply = new HttpClient().Send(
                        new(HttpMethod.Get, "https://million.hyrorre.com/"),
                        HttpCompletionOption.ResponseHeadersRead);

                    Invoke(new Action(() => {
                        tb_output.AppendText($"Downloading...{Environment.NewLine}");
                    }));

                    long length = reply.Content.Headers.ContentLength ?? 0;
                    StreamReader reader = new StreamReader(reply.Content.ReadAsStream());
                    string string_sr = ReadWithProgress(reader, length);
                    reader.Close();

                    Invoke(new Action(() => {
                        tb_output.AppendText($"ProcessingText...{Environment.NewLine}");
                    }));

                    Match m_u = Regex.Match(
                        string_sr,
                        "(?<=<ul id=\"musiclist\" class=\"list\">)[\\s\\S]*?(?=</ul>)");
                    if (!m_u.Success) throw new Exception("Songs information is not found.");
                    MatchCollection m_uc = Regex.Matches(m_u.Value, "(?<=<li>)[\\s\\S]*?(?=</li>)");
                    songs = new SongName[m_uc.Count];
                    Match m_u_1, m_u_2;
                    for (int i0 = 0; i0 < m_uc.Count; ++i0) {
                        m_u_1 = Regex.Match(m_uc[i0].Value, "(?<=<h3 class=\"title\">).*?(?=</h3>)");
                        if (!m_u_1.Success) throw new Exception($"Song {i0} do not have a name.");
                        m_u_2 = Regex.Match(
                            m_uc[i0].Value,
                            "(?<=<a href=\"/musics/).*?(?=/\\d+\">\\d+</a>)");
                        if (!m_u_1.Success) throw new Exception($"Song \"{m_u_1.Value}\" do not have a URL.");
                        songs[i0] = new SongName(m_u_1.Value, m_u_2.Value);
                    }

                    b_changed_songname = true;
                    Invoke(new Action(() => {
                        combo_SongName.DataSource = songs;
                        tb_output.AppendText("Success.");
                        EnableInput();
                    }));
                }
                catch (Exception err) {
                    Invoke(new Action(() => {
                        tb_output.AppendText(err.Message);
                        EnableInput();
                    }));
                }
                task_current = null;
            });
            task_current.Start();
        }

        private void openAss(string fass) {
            try {
                Match m_u;
                List<string> s_ass = new List<string>();
                StreamReader sr_ass = new StreamReader(new FileStream(fass, FileMode.Open, FileAccess.Read));
                for (string?line; (line = sr_ass.ReadLine()) != null; ) {
                    m_u = Regex.Match(
                        line,
                        "(?:Dialogue|Comment):[^,]*,([^,]*),[^,]*,[^,]*,[^,]*,[^,]*,[^,]*,[^,]*,[^,]*,([^,]*)");
                    if (m_u.Success) {
                        s_ass.Add($"{m_u.Groups[1]},{m_u.Groups[2]}");
                    }
                }
                sr_ass.Close();
                text_Score.Lines = s_ass.ToArray();

                m_u = Regex.Match(fass, "\\\\([^\\\\_]+)_([^\\\\_]+)\\.txt$");
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

                button_Make.Text = $"{BT_MAKE}*";
                b_SaveTXT.Text = $"{BT_SAVE}*";
            }
            catch (Exception err) { tb_output.Text = err.Message; }
        }

        private void b_ass_Click(object sender, EventArgs e) {
            OpenFileDialog d_load = new OpenFileDialog {
                Filter = "ASS files (*.ass)|*.ass|All files (*.*)|*.*",
                InitialDirectory = dir_ASS,
            };
            if (d_load.ShowDialog() != DialogResult.OK) return;

            string?dir_new = Path.GetDirectoryName(d_load.FileName);
            if (dir_new != null && dir_ASS != dir_new) {
                settings_changed = true;
                dir_ASS = dir_new;
            }
            
            tb_output.Clear();
            openAss(d_load.FileName);
        }

        private void b_video_Click(object sender, EventArgs e) {
            const string FNAME_VIDEOPARSER = "MilishitaVideoParser";
            string dir_parser = tb_vidparserDir.Text;
            string fexe;
            switch (combo_difficulty.SelectedIndex) {
                default:
                    fexe = Path.Combine(dir_parser, $"{FNAME_VIDEOPARSER}.exe"); break;
                case 0: case 1:
                    fexe = Path.Combine(dir_parser, $"{FNAME_VIDEOPARSER}_2p.exe"); break;
                case 2:
                    fexe = Path.Combine(dir_parser, $"{FNAME_VIDEOPARSER}_2m.exe"); break;
                case 3:
                    fexe = Path.Combine(dir_parser, $"{FNAME_VIDEOPARSER}_4m.exe"); break;
            }
            if (!File.Exists(fexe)) {
                const string NO_PARSER1 = " is needed to use this function. The following DLLs may also be needed:";
                const string NO_PARSER2 = "avcodec-*.dll, avformat-*.dll, swscale-*.dll, imgutils-*.dll";
                MessageBox.Show($"{fexe}{NO_PARSER1}{Environment.NewLine}{NO_PARSER2}");
                return;
            }

            OpenFileDialog d_load = new OpenFileDialog {
                Filter = "MP4 files (*.mp4)|*.mp4|All files (*.*)|*.*",
                InitialDirectory = dir_ASS,
            };
            if (d_load.ShowDialog() != DialogResult.OK) return;

            if (task_current != null) return;
            DisableInput();

            Process p = new Process();
            p.StartInfo.FileName = fexe;
            p.StartInfo.Arguments = $"\"{d_load.FileName}\"";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            try { p.Start(); } catch (Exception err) {
                tb_output.Text = err.Message;
                EnableInput();
                return;
            }

            task_current = new Task(() => {
                string fass = $"{Regex.Replace(d_load.FileName, "\\.[^\\.\\\\/:]*$", "")}.ass";
                while (!p.StandardOutput.EndOfStream) {
                    Invoke(new Action(() => {
                        tb_output.AppendText($"{p.StandardOutput.ReadLine()}{Environment.NewLine}");
                    }));
                }
                p.WaitForExit();
                Invoke(new Action(() => {
                    tb_output.AppendText(p.StandardError.ReadToEnd());
                    if (p.ExitCode == 0) {
                        openAss(fass);
                        tabC_main.SelectedIndex = 0;
                    }
                    else MessageBox.Show($"Parser exited with a code of 0x{p.ExitCode:X}. This was probably due to missing DLLs.");
                    EnableInput();
                }));
                task_current = null;
            });
            
            tb_output.Clear();
            task_current.Start();
        }

        private void textScore_Change(object sender, EventArgs e) {
            if (text_Score.Text == "") {
                b_SaveTXT.Text = BT_SAVE;
                button_Make.Text = BT_MAKE;
            }
            else {
                b_SaveTXT.Text = $"{BT_SAVE}*";
                button_Make.Text = $"{BT_MAKE}*";
            }
        }

        private void b_LoadText_Click(object sender, EventArgs e) {
            OpenFileDialog d_load = new OpenFileDialog {
                Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = dir_TXT,
            };
            if (d_load.ShowDialog() == DialogResult.OK) {
                string?dir_new = Path.GetDirectoryName(d_load.FileName);
                if (dir_new != null && dir_TXT != dir_new) {
                    settings_changed = true;
                    dir_TXT = dir_new;
                }
                tb_output.Clear();
                try {
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

                    button_Make.Text = $"{BT_MAKE}*";
                    b_SaveTXT.Text = BT_SAVE;
                }
                catch (Exception err) { tb_output.Text = err.Message; }
            }
        }

        private void b_SaveTXT_Click(object sender, EventArgs e) {
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
                string?dir_new = Path.GetDirectoryName(d_save.FileName);
                if (dir_new != null && dir_TXT != dir_new) {
                    settings_changed = true;
                    dir_TXT = dir_new;
                }
                tb_output.Clear();
                try {
                    StreamWriter sw_save = new StreamWriter(new FileStream(d_save.FileName, FileMode.Create));
                    sw_save.Write(text_Score.Text);
                    sw_save.Close();

                    b_SaveTXT.Text = BT_SAVE;
                }
                catch (Exception err) { tb_output.Text = err.Message; }
            }
        }

        private void b_reworkAp_Click(object sender, EventArgs e) {
            if (task_current != null) return;
            DisableInput();
            uint count = 0, count_success = 0, count_failure = 0;
            bool isOlder = cb_old.Checked;
            bool isApOnly = sender == b_reworkAp;
            CodecSettings settings = new CodecSettings {
                version = ((MacroVersion)combo_ver.SelectedItem!).value,
                nDiff = 5,
                numCommandPerScript = Convert.ToInt32(num_nCmdScpt.Value),
                numDown = Convert.ToInt32(num_downNum.Value),
                numMove = Convert.ToInt32(num_moveNum.Value),
                den = Convert.ToInt32(num_Den.Value),
            };
            
            task_current = new Task(() => {
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
                                        JsonMacroBs13?macro = JsonConvert.DeserializeObject<JsonMacroBs13>(si, new JsonSerializerSettings {
                                            TypeNameHandling = TypeNameHandling.All,
                                            SerializationBinder = new JsonMacroBs13.PrimitiveTypesBinder(),
                                        });
                                        if (macro == null) throw new JsonException();
                                        JsonMacroBs13.class_Primitive[]?ctrls = macro.Primitives;
                                        if (ctrls == null) throw new Exception($"{f_cfg} has invalid format.");
                                        macro.Primitives = MacroCodec.ChangeAppendage(ctrls, appendage);
                                        so = JsonConvert.SerializeObject(macro);
                                    }
                                    break;
                                case (int)MacroVersion.Value.BluestacksParser17: {
                                        JsonMacroBs17?macro = JsonConvert.DeserializeObject<JsonMacroBs17>(si, new JsonSerializerSettings {
                                            TypeNameHandling = TypeNameHandling.All,
                                            SerializationBinder = new JsonMacroBs17.class_ControlSchemes.GameControlsTypesBinder(),
                                        });
                                        if (macro == null) throw new JsonException();
                                        JsonMacroBs17.class_ControlSchemes.class_GameControls[]?ctrls = macro.ControlSchemes[0].GameControls;
                                        if (ctrls == null) throw new Exception($"{f_cfg} has invalid format.");
                                        macro.ControlSchemes[0].GameControls = MacroCodec.ChangeAppendage(ctrls, appendage);
                                        so = JsonConvert.SerializeObject(macro);
                                    }
                                    break;
                            }
                        }
                        else {
                            string filename = Path.GetFileNameWithoutExtension(f_cfg);
                            string songname = filename.Substring(0, filename.Length - 3);
                            switch (filename.Substring(filename.Length - 2)) {
                                default:
                                    settings.nDiff = 5;
                                    songname = filename;
                                    break;
                                case "2s": settings.nDiff = 0; break;
                                case "2p": settings.nDiff = 1; break;
                                case "2m": settings.nDiff = 2; break;
                                case "4m": settings.nDiff = 3; break;
                                case "6m": settings.nDiff = 4; break;
                                case "mm": settings.nDiff = 5; break;
                            }

                            StreamReader fr =
                                new StreamReader(new FileStream($"{dir_TXT}\\{filename}.txt", FileMode.Open, FileAccess.Read));
                            IEnumerable<string> RL(TextReader tr) {
                                for (string?line; (line = tr.ReadLine()) != null;) yield return line;
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
                        Invoke(new Action(() => { tb_output.AppendText(err.Message + Environment.NewLine); }));
                        ++count_failure;
                        if (count_failure > 4) {
                            Invoke(new Action(() => {
                                tb_output.AppendText($"Too many errors. Reworking aborted.{Environment.NewLine}");
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
                    tb_output.AppendText($"{count_success} out of {n_cfg} files updated.");
                    EnableInput();
                }));
                task_current = null;
            });

            tb_output.Text = $"Start reworking...{Environment.NewLine}";
            pgbar_main.Value = 0;
            task_current.Start();
        }

        private void b_reworkBrowse_Click(object sender, EventArgs e) {
            FolderBrowserDialog d_load = new FolderBrowserDialog {};
            if (d_load.ShowDialog() == DialogResult.OK) {
                tb_reworkF.Text = d_load.SelectedPath;
            }
        }
        private void b_locateParser_Click(object sender, EventArgs e) {
            FolderBrowserDialog d_load = new FolderBrowserDialog {};
            if (d_load.ShowDialog() == DialogResult.OK) {
                tb_vidparserDir.Text = d_load.SelectedPath;
            }
        }

        private void SettingControlsChanged(object sender, EventArgs e) { settings_changed = true; }
    }
}
