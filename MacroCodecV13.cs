using Newtonsoft.Json;

using System;
using System.Collections.Generic;

namespace MilishitaMacro {
    class JsonMacroBs13 {
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
            public class_Primitive_Tap(JsonAppendage.Tap j) {
                type = "Tap, Bluestacks";

                X = j.X;
                Y = j.Y;
                Key = j.Key;
                Key_alt1 = "";
                ShowOnOverlay = true;

                Type = "Tap";
                Guidance = new class_Guidance();
                GuidanceCategory = "MISC";
                Tags = new string[0];
                EnableCondition = "";
                IsVisibleInOverlay = true;
            }
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
            [JsonProperty(Order = 6)]
            public class_Event[] Events;

            [JsonConstructor]
            public class_Primitive_Combo() { type = "Combo, Bluestacks"; }
            public class_Primitive_Combo(JsonAppendage.Combo j) {
                type = "Combo, Bluestacks";
                
                Key = j.Key;
                Description = "";
                Events = new class_Event[j.Events.Length];
                for (int i = 0; i < j.Events.Length; ++i) {
                    MacroCommand c = j.Events[i];
                    string typename;
                    switch (c.type) {
                        default: continue;
                        case (int)MacroCommand.Type.DOWN: typename = "MouseDown"; break;
                        case (int)MacroCommand.Type.UP: typename = "MouseUp"; break;
                        case (int)MacroCommand.Type.MOVE: typename = "MouseMove"; break;
                    }
                    Events[i] = new class_Event {
                        Timestamp = c.time,
                        X = c.x,
                        Y = c.y,
                        Delta = 0,
                        EventType = typename,
                    };
                }

                Type = "Combo";
                Guidance = new class_Guidance();
                GuidanceCategory = "MISC";
                Tags = new string[0];
                EnableCondition = "";
                IsVisibleInOverlay = true;
            }
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
            public class_Primitive_Zoom(JsonAppendage.Zoom j) {
                type = "Tap, Bluestacks";

                X1 = j.X1;
                Y1 = j.Y1;
                X2 = j.X2;
                Y2 = j.Y2;
                KeyIn = j.KeyIn;
                KeyIn_alt1 = "";
                KeyOut = j.KeyOut;
                KeyOut_alt1 = "";
                Speed = 1;
                Mode = 0;
                Override = true;

                Type = "Tap";
                Guidance = new class_Guidance();
                GuidanceCategory = "MISC";
                Tags = new string[0];
                EnableCondition = "";
                IsVisibleInOverlay = true;
            }
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
            public class_Primitive_Repeat(JsonAppendage.Repeat j) {
                type = "Tap, Bluestacks";

                X = j.X;
                Y = j.Y;
                Key = j.Key;
                Count = j.Count;
                Delay = j.Delay;
                ShowOnOverlay = true;
                RepeatUntilKeyUp = true;

                Type = "Tap";
                Guidance = new class_Guidance();
                GuidanceCategory = "MISC";
                Tags = new string[0];
                EnableCondition = "";
                IsVisibleInOverlay = true;
            }
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
        public class class_Strings {
            public class class_UserDefined { }
            [JsonProperty("User-Defined")]
            public class_UserDefined UserDefined = new class_UserDefined();
        }
        public class_Strings Strings = new class_Strings();
    }

    partial class MacroCodec {
        static void AddAppendage(JsonMacroBs13.class_Primitive[] output, JsonAppendage app, int n_noapp) {
            int index = n_noapp;
            for (int i = 0; i < app.tap.Length; ++i, ++index)
                output[index] = new JsonMacroBs13.class_Primitive_Tap(app.tap[i]);
            for (int i = 0; i < app.zoom.Length; ++i, ++index)
                output[index] = new JsonMacroBs13.class_Primitive_Zoom(app.zoom[i]);
            for (int i = 0; i < app.repeat.Length; ++i, ++index)
                output[index] = new JsonMacroBs13.class_Primitive_Repeat(app.repeat[i]);
            for (int i = 0; i < app.combo.Length; ++i, ++index)
                output[index] = new JsonMacroBs13.class_Primitive_Combo(app.combo[i]);
        }

        static public JsonMacroBs13.class_Primitive[] ChangeAppendage(JsonMacroBs13.class_Primitive[] input, JsonAppendage app) {
            int n_noapp = Array.FindIndex(input, (p) => {
                return !(p is JsonMacroBs13.class_Primitive_Combo);
            });
            if (n_noapp == -1) n_noapp = input.Length;

            int output_size = n_noapp + app.tap.Length + app.zoom.Length + app.repeat.Length + app.combo.Length;
            JsonMacroBs13.class_Primitive[] output = new JsonMacroBs13.class_Primitive[output_size];

            Array.Copy(input, output, n_noapp);
            AddAppendage(output, app, n_noapp);

            return output;
        }

        static public JsonMacroBs13 ConvertMacroV13(
            IEnumerable<string> scores,
            JsonAppendage appendage,
            string song_name,
            ref CodecSettings settings) {
            JsonMacroBs13 macro = new JsonMacroBs13();
            MacroCommand[][] commands = ParseLines(scores, ref settings);

            int n_con = commands.Length + appendage.tap.Length + appendage.zoom.Length + appendage.repeat.Length + appendage.combo.Length;
            macro.Primitives = new JsonMacroBs13.class_Primitive[n_con];
            
            string song_diff_name = song_name + '_' + CodecSettings.diffs[settings.nDiff].shortName;

            for (int i = 0; i < commands.Length; ++i) {
                MacroCommand[] cs = commands[i];
                JsonMacroBs13.class_Primitive_Combo.class_Event[] e =
                    new JsonMacroBs13.class_Primitive_Combo.class_Event[cs.Length];
                for (int i1 = 0; i1 < cs.Length; ++i1) {
                    MacroCommand c = cs[i1];
                    string typename;
                    switch (c.type) {
                        default: continue;
                        case (int)MacroCommand.Type.DOWN: typename = "MouseDown"; break;
                        case (int)MacroCommand.Type.UP: typename = "MouseUp"; break;
                        case (int)MacroCommand.Type.MOVE: typename = "MouseMove"; break;
                    }
                    e[i1] = new JsonMacroBs13.class_Primitive_Combo.class_Event {
                        Timestamp = c.time,
                        X = c.x,
                        Y = c.y,
                        Delta = 0,
                        EventType = typename,
                    };
                }
                
                macro.Primitives[i] = new JsonMacroBs13.class_Primitive_Combo {
                    type = "Combo, Bluestacks",
                    Key = "Z",

                    Type = "Combo",
                    Guidance = new JsonMacroBs13.class_Primitive.class_Guidance(),
                    GuidanceCategory = "MISC",
                    Tags = new string[0],
                    EnableCondition = "",
                    IsVisibleInOverlay = false,

                    Description = song_diff_name,
                    Events = e,
                };
            }

            AddAppendage(macro.Primitives, appendage, commands.Length);

            return macro;
        }
    }
}