using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MilishitaMacro {
    class MacroCommand {
        public enum Type { DOWN, UP, MOVE }
        public int time, type;
        public double x, y;
        public MacroCommand(int new_time, int new_type, double xreal, double yreal) {
            time = new_time; type = new_type; x = xreal; y = yreal;
        }
    }

    struct MacroVersion {
        public enum Value { BluestacksParser13, BluestacksParser17 }
        public readonly int value;
        public string name { get; }
        public MacroVersion(int new_value, string new_name) {
            value = new_value; name = new_name;
        }
    }
    struct DiffName {
        public string displayName { get; }

        public readonly string urlName;
        public readonly string shortName;

        public readonly bool isSolo;
        public readonly int nChannels;

        public readonly Func<double, double> GetX, GetY;
        public double GetXYReverse(double x) {
            for (int i1 = nChannels; --i1 > 0;) for (int i2 = 0; i2 < 3; ++i2) {
                if (isSolo ? GetY(i1 - (double)i2 / 3) >= x : GetX(i1 - (double)i2 / 3) <= x) {
                    if (i2 == 2) return i1 - 0.5;
                    else return i1;
                }
            }
            return 0;
        }
        
        public bool IsLeft(double x1) {
            return x1 <= (double)(nChannels - 1) / 2;
        }

        public readonly double[] x_flick, y_flick;

        public readonly double x_center, y_center;

        private static double _Get_f(double x) { return 82.82; }
        private static double _Get_f_solo(double x) { return 71.36; }
        private static double _Get_2b(double x) {
            return Math.Round(31.55 + 37.07 * x, 2);
        }
        private static double _Get_2b_solo(double x) {
            return Math.Round(76.18 - 52.21 * x, 2);
        }
        private static double _Get_4b(double x) {
            return Math.Round(19.3 + 20.43 * x, 2);
        }
        private static double _Get_6b(double x) {
            return Math.Round(19.3 + 12.25 * x, 2);
        }

        public DiffName(int __indexDiff) {
            switch (__indexDiff) {
                default:
                case 0:
                    displayName = "2 Mix (solo)";
                    urlName = "0";
                    shortName = "2s";
                    isSolo = true;
                    nChannels = 2;
                    GetX = _Get_f_solo;
                    GetY = _Get_2b_solo;
                    x_flick = new double[] { 0, 0, -5, 0 };
                    y_flick = new double[] { 0, 5, 0, -5 };
                    x_center = 71.36;
                    y_center = 50;
                    break;
                case 1:
                    displayName = "2 Mix+ (solo)";
                    urlName = "1";
                    shortName = "2p";
                    isSolo = true;
                    nChannels = 2;
                    GetX = _Get_f_solo;
                    GetY = _Get_2b_solo;
                    x_flick = new double[] { 0, 0, -5, 0 };
                    y_flick = new double[] { 0, 5, 0, -5 };
                    x_center = 71.36;
                    y_center = 50;
                    break;
                case 2:
                    displayName = "2 Mix";
                    urlName = "0";
                    shortName = "2m";
                    isSolo = false;
                    nChannels = 2;
                    GetX = _Get_2b;
                    GetY = _Get_f;
                    x_flick = new double[] { 0, -1, 0, 1 };
                    y_flick = new double[] { 0, 0, -5, 0 };
                    x_center = 50;
                    y_center = 82.82;
                    break;
                case 3:
                    displayName = "4 Mix";
                    urlName = "2";
                    shortName = "4m";
                    isSolo = false;
                    nChannels = 4;
                    GetX = _Get_4b;
                    GetY = _Get_f;
                    x_flick = new double[] { 0, -1, 0, 1 };
                    y_flick = new double[] { 0, 0, -5, 0 };
                    x_center = 50;
                    y_center = 82.82;
                    break;
                case 4:
                    displayName = "6 Mix";
                    urlName = "3";
                    shortName = "6m";
                    isSolo = false;
                    nChannels = 6;
                    GetX = _Get_6b;
                    GetY = _Get_f;
                    x_flick = new double[] { 0, -1, 0, 1 };
                    y_flick = new double[] { 0, 0, -5, 0 };
                    x_center = 50;
                    y_center = 82.82;
                    break;
                case 5:
                    displayName = "Million Mix";
                    urlName = "4";
                    shortName = "mm";
                    isSolo = false;
                    nChannels = 6;
                    GetX = _Get_6b;
                    GetY = _Get_f;
                    x_flick = new double[] { 0, -1, 0, 1 };
                    y_flick = new double[] { 0, 0, -5, 0 };
                    x_center = 50;
                    y_center = 82.82;
                    break;
            }
        }
    }
    struct SongName {
        public string fullName { get; }
        public string urlName { get; }

        public SongName(string _s1, string _s2) {
            fullName = _s1;
            urlName = _s2;
        }
    }

    struct CodecSettings {
        public static readonly MacroVersion[] versions = {
            new MacroVersion((int)MacroVersion.Value.BluestacksParser17, "Bluestacks v17 (5.21.212.1027)"),
            new MacroVersion((int)MacroVersion.Value.BluestacksParser13, "Bluestacks v13 (4.170.10.1001)"),
        };
        public static readonly DiffName[] diffs = {
                new DiffName(0),
                new DiffName(1),
                new DiffName(2),
                new DiffName(3),
                new DiffName(4),
                new DiffName(5),
        };
        public int version;
        public int nDiff;
        public int numCommandPerScript;
        public int numDown;
        public int numMove;
        public int den;
    }

    class JsonScoreMltd : object {
        public class class_Conductor {
            public int Beat;
            public string ExtraInfo;
            public int Measure;
            public int Ticks;
            public int SignatureDenominator;
            public int SignatureNumerator;
            public int Tempo;
        }
        public class_Conductor[] Conductors;
        public int MusicOffset;
        public class class_Note {
            public int Beat;
            public string ExtraInfo;
            public int Measure;
            public int Ticks;
            public double EndX;
            public int FlickDirection;
            public class_Note[] FollowingNotes;
            public int GroupID;
            public double LeadTime;
            public int Size;
            public double Speed;
            public double StartX;
            public int TrackIndex;
            public int Type;
        }
        public class_Note[] Notes;
        public int ScoreIndex;
        public int TrackCount;
    }
    class JsonAppendage {
        public struct Tap {
            public readonly double X, Y;
            public readonly string Key;
            public Tap(double x, double y, string key) { X = x; Y = y; Key = key; }
        }
        public struct Zoom {
            public readonly double X1, Y1, X2, Y2;
            public readonly string KeyIn, KeyOut;
            public Zoom(double x1, double y1, double x2, double y2, string keyin, string keyout) {
                X1 = x1; Y1 = y1; X2 = x2; Y2 = y2; KeyIn = keyin; KeyOut = keyout;
            }
        }
        public struct Repeat {
            public readonly double X, Y;
            public readonly int Count, Delay;
            public readonly string Key;
            public Repeat(double x, double y, int count, int delay, string key) {
                X = x; Y = y; Count = count; Delay = delay; Key = key;
            }
        }
        public struct Combo {
            public readonly string Key;
            public readonly MacroCommand[] Events;
            public Combo(string key, MacroCommand[] events) { Key = key; Events = events; }
        }
        public Tap[] tap;
        public Zoom[] zoom;
        public Repeat[] repeat;
        public Combo[] combo;
        public JsonAppendage() {
            tap = new Tap[0];
            zoom = new Zoom[0];
            repeat = new Repeat[0];
            combo = new Combo[0];
        }
        public JsonAppendage(Tap[] new_tap, Zoom[] new_zoom, Repeat[] new_repeat, Combo[] new_combo) {
            tap = new_tap;
            zoom = new_zoom;
            repeat = new_repeat;
            combo = new_combo;
        }
    }

    partial class MacroCodec {
        class StateTimeline {
            struct int2 {
                public readonly int start, end;
                public int2(int start, int end) { this.start = start; this.end = end; }
            }
            LinkedList<int2> timestamp = new LinkedList<int2>();

            public void Insert(int _t_s, int _t_e) {
                LinkedListNode<int2> i0 = timestamp.Last;
                for (;;) {
                    if (i0 == null) {
                        timestamp.AddFirst(new int2(_t_s, _t_e));
                        break;
                    }
                    if (i0.Value.end <= _t_e) {
                        timestamp.AddAfter(i0, new int2(_t_s, _t_e));
                        break;
                    }
                    i0 = i0.Previous;
                }
            }

            public bool IsIn(int _t) {
                for (LinkedListNode<int2> i0 = timestamp.Last; i0 != null && i0.Value.end >= _t; i0 = i0.Previous) {
                    if (i0.Value.start <= _t) return true;
                }
                return false;
            }
        }

        static int ParseTime(string _t) {
            Match m_u;
            if ((m_u = Regex.Match(_t, "^\\d+$")).Success) {
                return
                    Convert.ToInt32(_t, 10);
            }
            if ((m_u = Regex.Match(_t, "^\\d+\\.\\d+$")).Success) {
                return
                    Convert.ToInt32(Convert.ToDouble(_t) * 1000);
            }
            if ((m_u = Regex.Match(_t, "^(\\d+):(\\d+\\.\\d+)$")).Success) {
                return
                    Convert.ToInt32(m_u.Groups[1].Value, 10) * 60 * 1000 +
                    Convert.ToInt32(Convert.ToDouble(m_u.Groups[2].Value) * 1000);
            }
            if ((m_u = Regex.Match(_t, "^(\\d+):(\\d+):(\\d+\\.\\d+)$")).Success) {
                return
                    Convert.ToInt32(m_u.Groups[1].Value, 10) * 3600000 +
                    Convert.ToInt32(m_u.Groups[2].Value, 10) * 60000 +
                    Convert.ToInt32(Convert.ToDouble(m_u.Groups[3].Value) * 1000);
            }
            throw new Exception($"Invalid timestamp: \"{_t}\".");
        }

        static int FromTicksToMilisecond(int _t, JsonScoreMltd.class_Conductor[] _tempo) {
            const double tempo_const = 96;
            int time = 0;
            IEnumerator<JsonScoreMltd.class_Conductor> tems = _tempo.OrderBy(u => u.Ticks).GetEnumerator();
            if (!tems.MoveNext()) throw new Exception("BPM information is missing.");
            JsonScoreMltd.class_Conductor tem = tems.Current, tem_next;
            while (tems.MoveNext() && (tem_next = tems.Current).Ticks < _t) {
                time += (int)((ulong)(tem_next.Ticks - tem.Ticks) * 1000 / (tem.Tempo * tempo_const));
                tem = tem_next;
            }
            time += (int)((ulong)(_t - tem.Ticks) * 1000 / (tem.Tempo * tempo_const));
            return time;
        }

        static public IEnumerable<string> FromScoreMltd(JsonScoreMltd score, int n_diff) {
            string FromSingleNote(JsonScoreMltd.class_Note note) {
                string time = FromTicksToMilisecond(note.Ticks, score.Conductors).ToString();
                string x_nobrac = (note.EndX + 1).ToString();
                string x = x_nobrac.Length == 1 ? x_nobrac : $"({x_nobrac})" ;
                return time + ',' + x;
            }

            StateTimeline[] Handbusy = {
                new StateTimeline(),
                new StateTimeline(),
            };
            Func<double, bool> IsLeft = CodecSettings.diffs[n_diff].IsLeft;

            foreach (var note in score.Notes) {
                int dexterity;
                string dexterity_suffix;
                string dex_first;
                if (IsLeft(note.EndX)) {
                    if (Handbusy[0].IsIn(note.Ticks))
                        { dexterity = 1; dexterity_suffix = "D"; dex_first = "D"; }
                    else { dexterity = 0; dexterity_suffix = "S"; dex_first = ""; }
                }
                else {
                    if (Handbusy[1].IsIn(note.Ticks))
                        { dexterity = 0; dexterity_suffix = "S"; dex_first = "S"; }
                    else { dexterity = 1; dexterity_suffix = "D"; dex_first = ""; }
                }
                if (note.FollowingNotes == null) {
                    string note_type = 
                        note.Type == 100 ? "!" :
                        note.FlickDirection == 1 ? "L" :
                        note.FlickDirection == 2 ? "U" :
                        note.FlickDirection == 3 ? "R" : "";
                    yield return FromSingleNote(note) + dex_first + note_type;
                    Handbusy[dexterity].Insert(note.Ticks, note.Ticks + 5);
                }
                else {
                    string note_type = 
                        note.Type == 100 ? "!" :
                        note.FlickDirection == 1 ? "L" :
                        note.FlickDirection == 2 ? "U" :
                        note.FlickDirection == 3 ? "R" : "+";
                    yield return FromSingleNote(note) + dex_first + note_type;
                    for (int i1 = 0; i1 < note.FollowingNotes.Length - 1; ++i1) {
                        JsonScoreMltd.class_Note note_following = note.FollowingNotes[i1];
                        string dex_following = (IsLeft(note_following.EndX) ? 0 : 1) == dexterity ? "" : dexterity_suffix;
                        yield return $"{FromSingleNote(note.FollowingNotes[i1])}{dex_following}=";
                    }
                    JsonScoreMltd.class_Note note_last = note.FollowingNotes.Last();
                    string dex_last = (IsLeft(note_last.EndX) ? 0 : 1) == dexterity ? "" : dexterity_suffix;
                    string note_type_last = note_last.FlickDirection == 1 ? "L" :
                            note_last.FlickDirection == 2 ? "U" :
                            note_last.FlickDirection == 3 ? "R" : "-";
                    yield return FromSingleNote(note_last) + dex_last + note_type_last;
                    Handbusy[dexterity].Insert(note.Ticks, note_last.Ticks + 5);
                }
            }
        }
        
        static MacroCommand[][] ParseLines(IEnumerable<string> lines, ref CodecSettings settings) {
            List<MacroCommand>[] command2 = { new List<MacroCommand>(0x400), new List<MacroCommand>(0x400) };

            ref DiffName diff = ref CodecSettings.diffs[settings.nDiff];

            //notes to commands
            foreach (string line in lines) {
                Match m_u;
                if ((m_u = Regex.Match(line, "^[0-9:.]+(?=,)")).Success) {
                    int time = ParseTime(m_u.Value);
                    for (int i0 = m_u.Index + m_u.Length + 1; i0 < line.Length;) {
                        if ((m_u = Regex.Match(line.Substring(i0), "(\\d|\\(\\d+\\.\\d+\\))([sdSD]?)([+\\-=uUlLrR!]?)")).Success) {
                            i0 += m_u.Index + m_u.Length;

                            double nx = Convert.ToDouble(m_u.Groups[1].Value[0] == '(' ?
                                m_u.Groups[1].Value.Substring(1, m_u.Groups[1].Value.Length - 2)
                            : m_u.Groups[1].Value) - 1;

                            List<MacroCommand> command1 = command2[m_u.Groups[2].Value.Length == 0 ?
                                diff.IsLeft(nx) ? 0 : 1
                            : m_u.Groups[2].Value[0] == 's' || m_u.Groups[2].Value[0] == 'S' ? 0 : 1];

                            double x = diff.GetX(nx);
                            double y = diff.GetY(nx);

                            if (m_u.Groups[3].Value.Length == 0) {
                                command1.Add(new MacroCommand(time, (int)MacroCommand.Type.DOWN, x, y));
                                command1.Add(new MacroCommand(time + 5, (int)MacroCommand.Type.UP, x, y));
                            }
                            else {
                                int type;
                                switch (m_u.Groups[3].Value[0]) {
                                    default:
                                        command1.Add(new MacroCommand(time, (int)MacroCommand.Type.DOWN, x, y));
                                        command1.Add(new MacroCommand(time + 5, (int)MacroCommand.Type.UP, x, y));
                                        break;
                                    case 'l': case 'L': type = 1; goto CASE_FLICK;
                                    case 'u': case 'U': type = 2; goto CASE_FLICK;
                                    case 'r': case 'R': type = 3;
                                    CASE_FLICK:
                                        {
                                            double x_flick = diff.x_flick[type];
                                            double y_flick = diff.y_flick[type];
                                            command1.Add(new MacroCommand(time - 20, (int)MacroCommand.Type.MOVE, x, y));
                                            command1.Add(new MacroCommand(time, (int)MacroCommand.Type.MOVE, x, y));
                                            command1.Add(new MacroCommand(time + 5, (int)MacroCommand.Type.MOVE, x + x_flick, y + y_flick));
                                            command1.Add(new MacroCommand(time + 10, (int)MacroCommand.Type.MOVE, x + x_flick * 2, y + y_flick * 2));
                                            command1.Add(new MacroCommand(time + 15, (int)MacroCommand.Type.MOVE, x + x_flick * 3, y + y_flick * 3));
                                            command1.Add(new MacroCommand(time + 20, (int)MacroCommand.Type.MOVE, x + x_flick * 4, y + y_flick * 4));
                                            command1.Add(new MacroCommand(time + 22, (int)MacroCommand.Type.UP, x + x_flick * 4, y + y_flick * 4));
                                        }
                                        break;
                                    case '+': command1.Add(new MacroCommand(time, (int)MacroCommand.Type.DOWN, x, y)); break;
                                    case '=': command1.Add(new MacroCommand(time, 2, x, y)); break;
                                    case '-':
                                        command1.Add(new MacroCommand(time, (int)MacroCommand.Type.MOVE, x, y));
                                        command1.Add(new MacroCommand(time + 5, (int)MacroCommand.Type.UP, x, y));
                                        break;
                                    case '!': {
                                            double x_center = diff.x_center;
                                            double y_center = diff.y_center;
                                            command1.Add(new MacroCommand(time, (int)MacroCommand.Type.DOWN, x_center, y_center));
                                            command1.Add(new MacroCommand(time + 5, (int)MacroCommand.Type.UP, x_center, y_center));
                                        }
                                        break;
                                }
                            }
                        }
                        else break;
                    }
                }
                else if (Regex.Match(line, "\\S").Success) {
                    throw new Exception($"Invalid Input Line: \"{line}\".");
                }
            }

            List<List<MacroCommand>> commandN = new List<List<MacroCommand>>();

            foreach (List<MacroCommand> command1 in command2) {
                command1.Sort((c1, c2) => c1.time - c2.time);

                bool isDown = false;
                int previous_time = 0, this_time;
                double x_now = 0, y_now = 0;

                //connect commands
                for (int i0 = 0; i0 < command1.Count; ++i0) {
                    this_time = command1[i0].time;
                    switch (command1[i0].type) {
                        case (int)MacroCommand.Type.DOWN: //MouseDown when mouse is already down
                            if (isDown) {
                                if (previous_time + 1 < this_time) {
                                    command1.Insert(i0, new MacroCommand(this_time - 1, (int)MacroCommand.Type.UP, x_now, y_now));
                                    ++i0;
                                }
                                else command1[i0].type = (int)MacroCommand.Type.UP;
                            }
                            else isDown = true;
                            x_now = command1[i0].x;
                            y_now = command1[i0].y;
                            break;
                        case (int)MacroCommand.Type.UP:  //MouseUp when mouse is not down
                            if (isDown) isDown = false;
                            else {
                                if (previous_time + 1 < this_time) {
                                    command1.Insert(i0, new MacroCommand(this_time - 1, (int)MacroCommand.Type.DOWN, x_now, y_now));
                                    ++i0;
                                }
                                else {
                                    command1.RemoveAt(i0);
                                    --i0;
                                }
                            }
                            break;
                        case (int)MacroCommand.Type.MOVE: //Oblique strip
                            if (isDown) {
                                double xy_now, xy_new;
                                if (diff.isSolo) {
                                    xy_now = y_now;
                                    y_now = xy_new = command1[i0].y;
                                }
                                else {
                                    xy_now = x_now;
                                    x_now = xy_new = command1[i0].x;
                                }
                                if (xy_new != xy_now) {
                                    double nxy_now = diff.GetXYReverse(xy_now);
                                    for (int i1 = previous_time; (i1 = i1 + 10) < this_time;) {
                                        double xy_med = Math.Round(xy_now + (i1 - previous_time) * (xy_new - xy_now) / (this_time - previous_time), 2);
                                        double nxy_new = diff.GetXYReverse(xy_med);
                                        if (nxy_now != nxy_new) {
                                            double x = diff.GetX(nxy_new);
                                            double y = diff.GetY(nxy_new);
                                            double xy = diff.isSolo ? y : x;
                                            if (xy < xy_new == xy_new < xy_now) xy = xy_new;
                                            else if (xy < xy_now == xy_now < xy_new) xy = xy_now;
                                            if (diff.isSolo) y = xy;
                                            else x = xy;
                                            command1.Insert(i0, new MacroCommand(i1, (int)MacroCommand.Type.MOVE, x, y));
                                            nxy_now = nxy_new;
                                            ++i0;
                                        }
                                    }
                                }

                                if (i0 > 0 && command1[i0 - 1].x == command1[i0].x && command1[i0 - 1].y == command1[i0].y) {
                                    //Remove redundant "Mousemove"
                                    command1.RemoveAt(i0);
                                    --i0;
                                }
                            }
                            else {
                                isDown = true;
                                command1[i0].type = (int)MacroCommand.Type.DOWN;
                                x_now = command1[i0].x;
                                y_now = command1[i0].y;
                            }
                            break;
                    }
                    previous_time = this_time;
                }

                //desync management 1: divide commands into groups
                if (settings.numCommandPerScript > 0) {
                    int i0 = 0;
                    int i1 = settings.numCommandPerScript - 1;
                    while (i1 < command1.Count) {
                        if (command1[i1].type == (int)MacroCommand.Type.UP) {
                            commandN.Add(command1.GetRange(i0, i1 + 1 - i0));
                            i0 = i1 + 1;
                            i1 = i0 + settings.numCommandPerScript - 1;
                        }
                        else ++i1;
                    }
                    if (i0 < command1.Count) commandN.Add(command1.GetRange(i0, command1.Count - i0));
                }
                else commandN.Add(command1);
            }

            //desync management 2: linear compensation
            foreach (List<MacroCommand> command1 in commandN) {
                int n_delay = 0;
                MacroCommand mc = command1.FirstOrDefault();
                foreach (MacroCommand mc_next in command1.Skip(1)) {
                    switch (mc.type) {
                        case (int)MacroCommand.Type.DOWN:
                        case (int)MacroCommand.Type.UP:
                            n_delay += settings.numDown; // 193
                            break;
                        case (int)MacroCommand.Type.MOVE:
                            n_delay += settings.numMove; // 183
                            break;
                    }
                    // 256
                    int time_this = mc.time;
                    int time_next_adjusted = mc_next.time - n_delay / settings.den;
                    mc_next.time = time_next_adjusted >= time_this ? time_next_adjusted : time_this;
                    mc = mc_next;
                }
            }
            
            int time_init = int.MaxValue, time_exit = 0;
            foreach (List<MacroCommand> command1 in commandN) {
                if (command1.Count > 0) {
                    if (command1.First().time < time_init) time_init = command1.First().time;
                    if (command1.Last().time > time_exit) time_exit = command1.Last().time;
                }
            }

            //end sign
            if (commandN.Count >= 1) {
                commandN[0].Add(new MacroCommand(time_exit + 500, (int)MacroCommand.Type.DOWN, 36, 50));
                commandN[0].Add(new MacroCommand(time_exit + 505, (int)MacroCommand.Type.UP, 36, 50));
            }
            if (commandN.Count >= 2) {
                commandN[1].Add(new MacroCommand(time_exit + 500, (int)MacroCommand.Type.DOWN, 64, 50));
                commandN[1].Add(new MacroCommand(time_exit + 505, (int)MacroCommand.Type.UP, 64, 50));
            }

            //move start time to the 1st command
            foreach (List<MacroCommand> command1 in commandN)
                foreach (MacroCommand c in command1)
                    c.time -= time_init;

            return commandN.ConvertAll(list => list.ToArray()).ToArray();
        }
    }
}
