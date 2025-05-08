using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilishitaMacro {
    class JsonAppendage {
        public class Tap {
            public readonly double X, Y;
            public readonly string Key;
            public Tap(double x, double y, string key) { X = x; Y = y; Key = key; }
        }
        public class Zoom {
            public readonly double X1, Y1, X2, Y2;
            public readonly string KeyIn, KeyOut;
            public Zoom(double x1, double y1, double x2, double y2, string keyin, string keyout) {
                X1 = x1; Y1 = y1; X2 = x2; Y2 = y2; KeyIn = keyin; KeyOut = keyout;
            }
        }
        public class Repeat {
            public readonly double X, Y;
            public readonly int Count, Delay;
            public readonly string Key;
            public Repeat(double x, double y, int count, int delay, string key) {
                X = x; Y = y; Count = count; Delay = delay; Key = key;
            }
        }
        public class Combo {
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
}
