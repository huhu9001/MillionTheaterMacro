using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace MilishitaMacro {
    class Js_notes_OBJ : object {
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
    class Js_macro_OBJ : object {
        /// Structure
        public class class_MetaData {
            public string ParserVersion = "13";
            public string KeyboardLayout = "Chinese (simplified) -us keyboard";
        }
        public class_MetaData MetaData = new class_MetaData();
        
        public class class_Primitive {
            [JsonProperty("$type", Order = 1)]
            public string type;

            [JsonProperty(Order = 100)]
            public string Type;
            public class class_Guidance { }
            [JsonProperty(Order = 101)]
            public class_Guidance Guidance;
            [JsonProperty(Order = 102)]
            public string GuidanceCategory;
            [JsonProperty(Order = 103)]
            public string[] Tags;
            [JsonProperty(Order = 104)]
            public string EnableCondition;
            [JsonProperty(Order = 105)]
            public bool IsVisibleInOverlay;
        }
        public class class_Primitive_Tap : class_Primitive {
            [JsonProperty(Order = 2)]
            public double X;
            [JsonProperty(Order = 3)]
            public double Y;
            [JsonProperty(Order = 4)]
            public string Key;
            [JsonProperty(Order = 5)]
            public string Key_alt1;
            [JsonProperty(Order = 6)]
            public bool ShowOnOverlay;

            [JsonConstructor]
            public class_Primitive_Tap() { type = "Tap, Bluestacks"; }
        }
        public class class_Primitive_Combo : class_Primitive {
            [JsonProperty(Order = 4)]
            public string Key;
            [JsonProperty(Order = 5)]
            public string Description;
            public class class_Event {
                public int Timestamp;
                public double X;
                public double Y;
                public int Delta;
                public string EventType;
            }
            public class class_Event_comparer : IComparer<class_Event> {
                public int Compare(class_Event a, class_Event b) {
                    return a.Timestamp - b.Timestamp;
                }
            }
            [JsonProperty(Order = 6)]
            public class_Event[] Events;

            [JsonConstructor]
            public class_Primitive_Combo() { type = "Combo, Bluestacks"; }
        }
        public class class_Primitive_Zoom : class_Primitive {
            [JsonProperty(Order = 2)]
            public double X1;
            [JsonProperty(Order = 3)]
            public double Y1;
            [JsonProperty(Order = 4)]
            public double X2;
            [JsonProperty(Order = 5)]
            public double Y2;
            [JsonProperty(Order = 6)]
            public string KeyIn;
            [JsonProperty(Order = 7)]
            public string KeyIn_alt1;
            [JsonProperty(Order = 8)]
            public string KeyOut;
            [JsonProperty(Order = 9)]
            public string KeyOut_alt1;
            [JsonProperty(Order = 10)]
            public double Speed;
            [JsonProperty(Order = 11)]
            public int Mode;
            [JsonProperty(Order = 12)]
            public bool Override;

            [JsonConstructor]
            public class_Primitive_Zoom() { type = "Zoom, Bluestacks"; }
        }
        public class class_Primitive_Repeat : class_Primitive {
            [JsonProperty(Order = 2)]
            public double X;
            [JsonProperty(Order = 3)]
            public double Y;
            [JsonProperty(Order = 4)]
            public string Key;
            [JsonProperty(Order = 5)]
            public int Count;
            [JsonProperty(Order = 6)]
            public int Delay;
            [JsonProperty(Order = 7)]
            public bool ShowOnOverlay;
            [JsonProperty(Order = 8)]
            public bool RepeatUntilKeyUp;

            [JsonConstructor]
            public class_Primitive_Repeat() { type = "TapRepeat, Bluestacks"; }
        }
        public class PrimitiveTypesBinder : Newtonsoft.Json.Serialization.ISerializationBinder {
            public Type BindToType(string assemblyName, string typeName) {
                if (typeName == "Tap") return typeof(class_Primitive_Tap);
                if (typeName == "Combo") return typeof(class_Primitive_Combo);
                if (typeName == "Zoom") return typeof(class_Primitive_Zoom);
                if (typeName == "TapRepeat") return typeof(class_Primitive_Repeat);
                return typeof(class_Primitive);
            }
            public void BindToName(Type serializedType, out string assemblyName, out string typeName) {
                assemblyName = null;
                typeName = null;
            }
        }
        public class_Primitive[] Primitives = null;
        /*{
            new class_Primitive_Tap {
                type = "Tap, Bluestacks",
                X = 50.01,
                Y = 50.01,
                Key = "Space",
                Key_alt1 = "",
                ShowOnOverlay = true,
                Type = "Tap",
                Guidance = new class_Primitive.class_Guidance(),
                GuidanceCategory = "MISC",
                Tags = new string[0],
                EnableCondition = "",
                IsVisibleInOverlay = true,
            },
            new class_Primitive_Combo {
                type = "Combo, Bluestacks",
                Key ="Z",

                Type="Combo",
                Guidance = {},
                GuidanceCategory = "MISC",
                Tags = {},
                EnableCondition = "",
                IsVisibleInOverlay = false,

                Description = null,
                Events = null,
            },
            new class_Primitive_Combo {
                type = "Combo, Bluestacks",
                Key ="Z",

                Type="Combo",
                Guidance = {},
                GuidanceCategory = "MISC",
                Tags = {},
                EnableCondition = "",
                IsVisibleInOverlay = false,

                Description = null,
                Events = null,
            },
            new class_Primitive_Zoom {
                type = "Zoom, Bluestacks",
                X1 = 46.92,
                Y1 = 30.43,
                X2 = 46.92,
                Y2 = 70.43,
                KeyIn = "OemPlus",
                KeyIn_alt1 = "",
                KeyOut = "OemMinus",
                KeyOut_alt1 = "",
                Speed = 1.0,
                Mode = 0,
                Override = true,
                Type = "Zoom",
                Guidance = {},
                GuidanceCategory = "MISC",
                Tags = {},
                EnableCondition = "",
                IsVisibleInOverlay = true,
            },
            new class_Primitive_Repeat {
                type = "TapRepeat, Bluestacks",
                X = 75.34,
                Y = 88.81,
                Key = "M",
                Count = 5,
                Delay = 100,
                ShowOnOverlay = true,
                RepeatUntilKeyUp = true,
                Type = "TapRepeat",
                Guidance = {},
                GuidanceCategory = "MISC",
                Tags = {},
                EnableCondition = "",
                IsVisibleInOverlay = true
            },
            new class_Primitive_Repeat {
                type = "TapRepeat, Bluestacks",
                X = 69.78,
                Y = 77.24,
                Key = "N",
                Count = 5,
                Delay = 100,
                ShowOnOverlay = true,
                RepeatUntilKeyUp = true,
                Type = "TapRepeat",
                Guidance = {},
                GuidanceCategory = "MISC",
                Tags = {},
                EnableCondition = "",
                IsVisibleInOverlay = true
            }
        };//*/
        public class class_Strings {
            public class class_UserDefined { }
            [JsonProperty("User-Defined")]
            public class_UserDefined UserDefined = new class_UserDefined();
        }
        public class_Strings Strings = new class_Strings();
    }
    class Js_ap_OBJ : object {
        public Js_macro_OBJ.class_Primitive_Tap[] tap = new Js_macro_OBJ.class_Primitive_Tap[0];
        public Js_macro_OBJ.class_Primitive_Zoom[] zoom = new Js_macro_OBJ.class_Primitive_Zoom[0];
        public Js_macro_OBJ.class_Primitive_Repeat[] repeat = new Js_macro_OBJ.class_Primitive_Repeat[0];
        public Js_macro_OBJ.class_Primitive_Combo[] combo = new Js_macro_OBJ.class_Primitive_Combo[0];
    }

    public class SongName : object {
        public string fullName { get; }
        public string urlName { get; }

        public SongName(string _s1, string _s2) {
            fullName = _s1;
            urlName = _s2;
        }
    }
    public class DiffName : object {

        public string displayName { get; }

        public readonly string urlName;
        public readonly string shortName;

        public readonly bool isSolo;
        public readonly int nChannels;

        public readonly Func<double, double> GetX, GetY;
        public double GetXYReverse(double x) {
            for(int i1 = nChannels; --i1 > 0;) for (int i2 = 0; i2 < 3; ++i2) {
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

        private static double _Get_f(double x) {
            return 82.82;
        }
        private static double _Get_f_solo(double x) {
            return 71.36;
        }
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
    class StateTimeline {
        class int_2 {
            public int start, end;
            public int_2(int _int_start, int _int_end) {
                start = _int_start;
                end = _int_end;
            }
        }
        LinkedList<int_2> timestamp = new LinkedList<int_2>();

        public void Insert(int _t_s, int _t_e) {
            LinkedListNode<int_2> i0 = timestamp.Last;
            for (; ; ) {
                if (i0 == null) {
                    timestamp.AddFirst(new int_2(_t_s, _t_e));
                    break;
                }
                if (i0.Value.end <= _t_e) {
                    timestamp.AddAfter(i0, new int_2(_t_s, _t_e));
                    break;
                }
                i0 = i0.Previous;
            }
        }

        public bool IsIn(int _t) {
            for (
                LinkedListNode<int_2> i0 = timestamp.Last;
                i0 != null && i0.Value.end >= _t;
                i0 = i0.Previous) {
                if (i0.Value.start <= _t) return true;
            }
            return false;
        }
    }

    class Converter_NotesMacro {
        static int ParseTime(string _t) {
            //return (int)Math.Round(TimeSpan.Parse(_t).TotalMilliseconds);
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
            throw new Exception("Invalid timestamp: \"" + _t + "\".");
        }

        static int FromTicksToMilisecond(int _t, Js_notes_OBJ.class_Conductor[] _tempo) {
            const double tempo_const = 96;
            int time = 0;
            if (_tempo.Length == 0) throw new Exception("BPM information is missing.");
            _tempo.OrderBy(u => u.Ticks);
            for (int i0 = 1; ;) {
                if (i0 < _tempo.Length && _tempo[i0].Ticks < _t) {
                    time += (int)
                        ((ulong)(_tempo[i0].Ticks - _tempo[i0 - 1].Ticks) * 1000 / (ulong)(_tempo[i0 - 1].Tempo * tempo_const));
                    ++i0;
                }
                else {
                    time += (int)
                        ((ulong)(_t - _tempo[i0 - 1].Ticks) * 1000 / (ulong)(_tempo[i0 - 1].Tempo * tempo_const));
                    break;
                }
            }
            return time;
        }

        static void InsertNoteMacro(
            ref List<Js_macro_OBJ.class_Primitive_Combo.class_Event> _e,
            int _time,
            double _x,
            int _type,
            ref DiffName _d) {
            double _X = _d.GetX(_x);
            double _Y = _d.GetY(_x);

            switch (_type) {
                default: break;
                case 0: //normal note
                    _e.Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                        Timestamp = _time,
                        X = _X,
                        Y = _Y,
                        Delta = 0,
                        EventType = "MouseDown",
                    });
                    _e.Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                        Timestamp = _time + 5,
                        X = _X,
                        Y = _Y,
                        Delta = 0,
                        EventType = "MouseUp",
                    });
                    break;
                case 1: // left flip
                case 2: // up flip
                case 3: // right flip
                    _e.Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                        Timestamp = _time - 20,
                        X = _X,
                        Y = _Y,
                        Delta = 0,
                        EventType = "MouseMove",
                    });
                    _e.Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                        Timestamp = _time,
                        X = _X,
                        Y = _Y,
                        Delta = 0,
                        EventType = "MouseMove",
                    });
                    _e.Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                        Timestamp = _time + 5,
                        X = Math.Round(_X + _d.x_flick[_type] * 1, 2),
                        Y = Math.Round(_Y + _d.y_flick[_type] * 1, 2),
                        Delta = 0,
                        EventType = "MouseMove",
                    });
                    _e.Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                        Timestamp = _time + 10,
                        X = Math.Round(_X + _d.x_flick[_type] * 2, 2),
                        Y = Math.Round(_Y + _d.y_flick[_type] * 2, 2),
                        Delta = 0,
                        EventType = "MouseMove",
                    });
                    _e.Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                        Timestamp = _time + 15,
                        X = Math.Round(_X + _d.x_flick[_type] * 3, 2),
                        Y = Math.Round(_Y + _d.y_flick[_type] * 3, 2),
                        Delta = 0,
                        EventType = "MouseMove",
                    });
                    _e.Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                        Timestamp = _time + 20,
                        X = Math.Round(_X + _d.x_flick[_type] * 4, 2),
                        Y = Math.Round(_Y + _d.y_flick[_type] * 4, 2),
                        Delta = 0,
                        EventType = "MouseMove",
                    });
                    _e.Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                        Timestamp = _time + 22,
                        X = Math.Round(_X + _d.x_flick[_type] * 4, 2),
                        Y = Math.Round(_Y + _d.y_flick[_type] * 4, 2),
                        Delta = 0,
                        EventType = "MouseUp",
                    });
                    break;
                case 4: //strip start
                    _e.Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                        Timestamp = _time,
                        X = _X,
                        Y = _Y,
                        Delta = 0,
                        EventType = "MouseDown",
                    });
                    break;
                case 5: //strip move
                    _e.Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                        Timestamp = _time,
                        X = _X,
                        Y = _Y,
                        Delta = 0,
                        EventType = "MouseMove",
                    });
                    break;
                case 6: //strip end
                    _e.Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                        Timestamp = _time,
                        X = _X,
                        Y = _Y,
                        Delta = 0,
                        EventType = "MouseMove",
                    });
                    _e.Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                        Timestamp = _time + 5,
                        X = _X,
                        Y = _Y,
                        Delta = 0,
                        EventType = "MouseUp",
                    });
                    break;
                case 7: // big note
                    _e.Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                        Timestamp = _time,
                        X = _d.x_center,
                        Y = _d.y_center,
                        Delta = 0,
                        EventType = "MouseDown",
                    });
                    _e.Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                        Timestamp = _time + 5,
                        X = _d.x_center,
                        Y = _d.y_center,
                        Delta = 0,
                        EventType = "MouseUp",
                    });
                    break;
            }
        }

        static void InsertNoteMacroFromString(
            List<Js_macro_OBJ.class_Primitive_Combo.class_Event>[] _e,
            string _score_line,
            ref DiffName _d) {
            int time, type, lr;
            double x;
            Match m_u;

            if ((m_u = Regex.Match(_score_line, "^[0-9:.]+(?=,)")).Success) {
                time = ParseTime(m_u.Value);
                for (int i0 = m_u.Index + m_u.Length + 1; i0 < _score_line.Length;) {
                    if ((m_u = Regex.Match(_score_line.Substring(i0), "(\\d|\\(\\d+\\.\\d+\\))([sdSD]?)([+\\-=uUlLrR!]?)")).Success) {
                        i0 += m_u.Index + m_u.Length;

                        if (m_u.Groups[1].Value[0] == '(') x = Convert.ToDouble(m_u.Groups[1].Value.Substring(1, m_u.Groups[1].Value.Length - 2));
                        else x = Convert.ToDouble(m_u.Groups[1].Value);
                        --x;

                        if (m_u.Groups[2].Value.Length == 0) lr = _d.IsLeft(x) ? 0 : 1;
                        else if (m_u.Groups[2].Value[0] == 's' || m_u.Groups[2].Value[0] == 'S') lr = 0;
                        else lr = 1;

                        if (m_u.Groups[3].Value.Length == 0) type = 0;
                        else switch (m_u.Groups[3].Value[0]) {
                                default: type = 0; break;
                                case 'l': case 'L': type = 1; break;
                                case 'u': case 'U': type = 2; break;
                                case 'r': case 'R': type = 3; break;
                                case '+': type = 4; break;
                                case '=': type = 5; break;
                                case '-': type = 6; break;
                                case '!': type = 7; break;
                            }

                        InsertNoteMacro(ref _e[lr], time, x, type, ref _d);
                    }
                    else break;
                }
            }
            else if (Regex.Match(_score_line, "\\S").Success) {
                throw new Exception("Invalid Input Line: \"" + _score_line + "\".");
            }
        }

        static void PostProcessNotes(
            ref List<Js_macro_OBJ.class_Primitive_Combo.class_Event> _e,
            ref DiffName _d) {
            bool isDown;
            int previous_time, this_time;
            double x_now = 0, y_now = 0;

            _e.Sort(new Js_macro_OBJ.class_Primitive_Combo.class_Event_comparer());
            isDown = false;
            previous_time = 0;

            for (int i0 = 0; i0 < _e.Count; ++i0) {
                this_time = _e[i0].Timestamp;
                switch (_e[i0].EventType) {
                    default: break;
                    case "MouseDown": //MouseDown when mouse is already down
                        if (isDown) {
                            if (previous_time + 1 < this_time) {
                                _e.Insert(i0, new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                                    Timestamp = this_time - 1,
                                    X = x_now,
                                    Y = y_now,
                                    Delta = 0,
                                    EventType = "MouseUp",
                                });
                                ++i0;
                            }
                            else _e[i0].EventType = "MouseMove";
                        }
                        else isDown = true;
                        x_now = _e[i0].X;
                        y_now = _e[i0].Y;
                        break;
                    case "MouseUp": //MouseUp when mouse is not down
                        if (isDown) isDown = false;
                        else {
                            if (previous_time + 1 < this_time) {
                                _e.Insert(i0, new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                                    Timestamp = this_time - 1,
                                    X = x_now,
                                    Y = y_now,
                                    Delta = 0,
                                    EventType = "MouseDown",
                                });
                                ++i0;
                            }
                            else {
                                _e.RemoveAt(i0);
                                --i0;
                            }
                        }
                        break;
                    case "MouseMove": //Oblique strip
                        double xy_now, xy_new;
                        if (_d.isSolo) {
                            xy_now = y_now;
                            y_now = xy_new = _e[i0].Y;
                        }
                        else {
                            xy_now = x_now;
                            x_now = xy_new = _e[i0].X;
                        }
                        if (isDown) {
                            if (xy_new != xy_now) {
                                double nxy_now = _d.GetXYReverse(xy_now);
                                
                                for (int i1 = previous_time; (i1 = i1 + 10) < this_time;) {
                                    double xy_med = Math.Round(xy_now + (i1 - previous_time) * (xy_new - xy_now) / (this_time - previous_time), 2);

                                    double nxy_new = _d.GetXYReverse(xy_med);

                                    if (nxy_now != nxy_new) {
                                        _e.Insert(i0, new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                                            Timestamp = i1,
                                            X = _d.GetX(nxy_new),
                                            Y = _d.GetY(nxy_new),
                                            Delta = 0,
                                            EventType = "MouseMove",
                                        });
                                        nxy_now = nxy_new;
                                        ++i0;
                                    }
                                }
                            }
                            
                            if (i0 > 0 && _e[i0 - 1].X == _e[i0].X && _e[i0 - 1].Y == _e[i0].Y) {
                                _e.RemoveAt(i0);
                                --i0;
                            }
                        }
                        else {
                            isDown = true;
                            _e[i0].EventType = "MouseDown";
                        }
                        break;
                }
                previous_time = this_time;
            }

            //Every key event makes a strange delay depending on the PC performance
            for (int i0 = 1, n_delay = 0; i0 < _e.Count; ++i0) {
                switch(_e[i0].EventType)
                {
                    default:break;
                    case "MouseMove":
                            n_delay += 183;
                        break;
                    case "MouseDown":
                    case "MouseUp":
                        n_delay += 193;
                        break;
                }
                if (_e[i0 - 1].Timestamp + n_delay / 256 >= _e[i0].Timestamp)
                    _e[i0].Timestamp = _e[i0 - 1].Timestamp;
                else _e[i0].Timestamp -= n_delay / 256;
            }
        }

        static void PostProcessMacro(
            ref Js_macro_OBJ _m,
            List<Js_macro_OBJ.class_Primitive_Combo.class_Event>[] _es,
            ref DiffName _d) {
            int time_init, time_exit;

            PostProcessNotes(ref _es[0], ref _d);
            PostProcessNotes(ref _es[1], ref _d);

            {
                int i0, i1, i2, i3;
                if (_es[0].Count != 0) {
                    i0 = _es[0][0].Timestamp;
                    i2 = _es[0].Last().Timestamp;
                }
                else {
                    i0 = 0;
                    i2 = 0;
                } 
                if (_es[1].Count != 0) {
                    i1 = _es[1][0].Timestamp;
                    i3 = _es[1].Last().Timestamp;
                }
                else {
                    i1 = 0;
                    i3 = 0;
                }
                time_init = i0 <= i1 ? i0 : i1;
                time_exit = i2 <= i3 ? i3 : i2;
            }

            //Add signal of macro end
            _es[0].Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                Timestamp = time_exit + 500,
                X = 36.0,
                Y = 50.0,
                Delta = 0,
                EventType = "MouseDown",
            });
            _es[1].Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                Timestamp = time_exit + 500,
                X = 64.0,
                Y = 50.0,
                Delta = 0,
                EventType = "MouseDown",
            });
            _es[0].Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                Timestamp = time_exit + 510,
                X = 36.0,
                Y = 50.0,
                Delta = 0,
                EventType = "MouseUp",
            });
            _es[1].Add(new Js_macro_OBJ.class_Primitive_Combo.class_Event {
                Timestamp = time_exit + 510,
                X = 64.0,
                Y = 50.0,
                Delta = 0,
                EventType = "MouseUp",
            });

            //Align start timepoint to the first note
            for (int i1 = _es[0].Count; --i1 >= 0;) {
                _es[0][i1].Timestamp -= time_init;
            }
            for (int i1 = _es[1].Count; --i1 >= 0;) {
                _es[1][i1].Timestamp -= time_init;
            }

            ((Js_macro_OBJ.class_Primitive_Combo)_m.Primitives[0]).Events =
                new Js_macro_OBJ.class_Primitive_Combo.class_Event[_es[0].Count];
            _es[0].CopyTo(((Js_macro_OBJ.class_Primitive_Combo)_m.Primitives[0]).Events);
            ((Js_macro_OBJ.class_Primitive_Combo)_m.Primitives[1]).Events =
                new Js_macro_OBJ.class_Primitive_Combo.class_Event[_es[1].Count];
            _es[1].CopyTo(((Js_macro_OBJ.class_Primitive_Combo)_m.Primitives[1]).Events);
        }

        static public void ConvertMacro(
            ref Js_macro_OBJ _macros,
            ref Js_notes_OBJ _notes,
            ref SongName _song,
            ref DiffName _diff) {
            ((Js_macro_OBJ.class_Primitive_Combo)_macros.Primitives[0]).Description = _song.urlName + "_" + _diff.shortName + " (left)";
            ((Js_macro_OBJ.class_Primitive_Combo)_macros.Primitives[1]).Description = _song.urlName + "_" + _diff.shortName + " (right)";

            List<Js_macro_OBJ.class_Primitive_Combo.class_Event>[] events = {
                        new List<Js_macro_OBJ.class_Primitive_Combo.class_Event>(0x400),
                        new List<Js_macro_OBJ.class_Primitive_Combo.class_Event>(0x400),
                    };
            StateTimeline[] Handbusy = {
                new StateTimeline(),
                new StateTimeline(),
            };

            for (int i0 = 0, _lr, _fl, _time; i0 < _notes.Notes.Length; ++i0) {
                _lr =
                    _diff.IsLeft(_notes.Notes[i0].EndX) &&
                    !Handbusy[0].IsIn(_notes.Notes[i0].Ticks) ||
                    Handbusy[1].IsIn(_notes.Notes[i0].Ticks) ?
                    0 : 1;
                _fl = _notes.Notes[i0].FollowingNotes == null ? 0 : _notes.Notes[i0].FollowingNotes.Length;
                _time = FromTicksToMilisecond(_notes.Notes[i0].Ticks, _notes.Conductors);
                if (_fl == 0) {
                    InsertNoteMacro(
                        ref events[_lr],
                        _time,
                        _notes.Notes[i0].EndX,
                        _notes.Notes[i0].Type == 100 ? 7 : _notes.Notes[i0].FlickDirection,
                        ref _diff);
                    if (_notes.Notes[i0].FlickDirection == 0)
                        Handbusy[_lr].Insert(_notes.Notes[i0].Ticks, _notes.Notes[i0].Ticks + 5);
                    else Handbusy[_lr].Insert(_notes.Notes[i0].Ticks - 20, _notes.Notes[i0].Ticks + 20);
                }
                else {
                    InsertNoteMacro(
                        ref events[_lr],
                        _time,
                        _notes.Notes[i0].EndX,
                        4,
                        ref _diff);
                    for (int i1 = 0; i1 < _fl; ++i1) {
                        _time = FromTicksToMilisecond(_notes.Notes[i0].FollowingNotes[i1].Ticks, _notes.Conductors);
                        InsertNoteMacro(
                            ref events[_lr],
                            _time,
                            _notes.Notes[i0].FollowingNotes[i1].EndX,
                            _notes.Notes[i0].FollowingNotes[i1].FlickDirection != 0 ? _notes.Notes[i0].FollowingNotes[i1].FlickDirection : i1 + 1 == _fl ? 6 : 5,
                            ref _diff);
                    }
                    Handbusy[_lr].Insert(_notes.Notes[i0].Ticks, _notes.Notes[i0].FollowingNotes.Last().Ticks);
                }
            }

            PostProcessMacro(ref _macros, events, ref _diff);
        }

        static public void ConvertMacro(
            ref Js_macro_OBJ _macros,
            string[] _score,
            string _song_name,
            ref DiffName _diff) {
            ((Js_macro_OBJ.class_Primitive_Combo)_macros.Primitives[0]).Description = _song_name + "_" + _diff.shortName + " (left)";
            ((Js_macro_OBJ.class_Primitive_Combo)_macros.Primitives[1]).Description = _song_name + "_" + _diff.shortName + " (right)";

            List<Js_macro_OBJ.class_Primitive_Combo.class_Event>[] events = {
                        new List<Js_macro_OBJ.class_Primitive_Combo.class_Event>(0x400),
                        new List<Js_macro_OBJ.class_Primitive_Combo.class_Event>(0x400),
                    };

            for (int i0 = 0; i0 < _score.Length; ++ i0) {
                InsertNoteMacroFromString(events, _score[i0], ref _diff);
            }
            
            PostProcessMacro(ref _macros, events, ref _diff);
        }

        static public void ConvertMacro(
            ref Js_macro_OBJ _macros,
            ref System.IO.StreamReader _score,
            string _song_name,
            ref DiffName _diff) {
            ((Js_macro_OBJ.class_Primitive_Combo)_macros.Primitives[0]).Description = _song_name + "_" + _diff.shortName + " (left)";
            ((Js_macro_OBJ.class_Primitive_Combo)_macros.Primitives[1]).Description = _song_name + "_" + _diff.shortName + " (right)";

            List<Js_macro_OBJ.class_Primitive_Combo.class_Event>[] events = {
                        new List<Js_macro_OBJ.class_Primitive_Combo.class_Event>(0x400),
                        new List<Js_macro_OBJ.class_Primitive_Combo.class_Event>(0x400),
                    };

            string scoreLine;
            while ((scoreLine = _score.ReadLine()) != null) {
                InsertNoteMacroFromString(events, scoreLine, ref _diff);
            }
            
            PostProcessMacro(ref _macros, events, ref _diff);
        }

        static public void MacroToString(
            ref List<string> _ss,
            ref Js_notes_OBJ _notes) {
            StateTimeline[] Handbusy = {
                new StateTimeline(),
                new StateTimeline(),
            };

            string _noteType, _LeftRightForced;
            double _x_int;
            for (int i0 = 0, _lr, _fl, _time; i0 < _notes.Notes.Length; ++i0) {
                _lr = _notes.Notes[i0].EndX * 2 + 1 <= _notes.TrackCount ? 0 : 1;
                _LeftRightForced = "";
                if (Handbusy[_lr].IsIn(_notes.Notes[i0].Ticks)) {
                    _lr = 1 - _lr;
                    _LeftRightForced = _lr == 0 ? "s" : "d";
                }
                _fl = _notes.Notes[i0].FollowingNotes == null ? 0 : _notes.Notes[i0].FollowingNotes.Length;
                _time = FromTicksToMilisecond(_notes.Notes[i0].Ticks, _notes.Conductors);
                _x_int = Math.Floor(_notes.Notes[i0].EndX);
                if (_fl == 0) {
                    _noteType =
                        _notes.Notes[i0].Type == 100 ? "!" :
                        _notes.Notes[i0].FlickDirection == 1 ? "L" :
                        _notes.Notes[i0].FlickDirection == 2 ? "U" :
                        _notes.Notes[i0].FlickDirection == 3 ? "R" : "";
                    _ss.Add(
                        _time + "," +
                        (_notes.Notes[i0].EndX == _x_int ? ((int)_x_int + 1).ToString() : "(" + (_notes.Notes[i0].EndX + 1).ToString() + ")") +
                        _LeftRightForced + _noteType
                    );
                    if (_notes.Notes[i0].FlickDirection == 0)
                        Handbusy[_lr].Insert(_notes.Notes[i0].Ticks, _notes.Notes[i0].Ticks + 5);
                    else Handbusy[_lr].Insert(_notes.Notes[i0].Ticks - 20, _notes.Notes[i0].Ticks + 20);
                } 
                else {
                    _ss.Add(
                        _time + "," +
                        (_notes.Notes[i0].EndX == _x_int ? ((int)_x_int + 1).ToString() : "(" + (_notes.Notes[i0].EndX + 1).ToString() + ")") +
                        _LeftRightForced + "+"
                    );
                    for (int i1 = 0; i1 < _fl; ++i1) {
                        _time = FromTicksToMilisecond(_notes.Notes[i0].FollowingNotes[i1].Ticks, _notes.Conductors);
                        _x_int = Math.Floor(_notes.Notes[i0].FollowingNotes[i1].EndX);
                        _noteType =
                            _notes.Notes[i0].FollowingNotes[i1].FlickDirection == 1 ? "L" :
                            _notes.Notes[i0].FollowingNotes[i1].FlickDirection == 2 ? "U" :
                            _notes.Notes[i0].FollowingNotes[i1].FlickDirection == 3 ? "R" :
                            i1 + 1 == _fl ? "-" : "=";
                        _ss.Add(
                            _time + "," +
                            (_notes.Notes[i0].FollowingNotes[i1].EndX == _x_int ? ((int)_x_int + 1).ToString() : "(" + (_notes.Notes[i0].FollowingNotes[i1].EndX + 1).ToString() + ")") +
                            _LeftRightForced + _noteType
                        );
                    }
                    Handbusy[_lr].Insert(_notes.Notes[i0].Ticks, _notes.Notes[i0].FollowingNotes.Last().Ticks);
                }
            }

            _ss.Sort( (s1, s2) => {
                return Convert.ToInt32(s1.Split(',')[0]) - Convert.ToInt32(s2.Split(',')[0]);
            });
        }
    }
}
