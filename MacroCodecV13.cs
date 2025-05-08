using Newtonsoft.Json;

namespace MilishitaMacro {
    using Container = GameControlItemContainer<JsonMacroBs13.class_Primitive, JsonMacroBs13.class_Primitive_Combo>;
    class JsonMacroBs13:Container {
        /// Structure
        public class class_MetaData {
            public string ParserVersion = "13";
            public string KeyboardLayout = "Chinese (simplified) -us keyboard";
        }
        public class_MetaData MetaData = new class_MetaData();
        
        public class class_Primitive {
            [JsonProperty("$type", Order = 1)]
            public string?type;

            [JsonProperty(Order = 100)]
            public string?Type;
            public class class_Guidance { }
            [JsonProperty(Order = 101)]
            public class_Guidance?Guidance;
            [JsonProperty(Order = 102)]
            public string?GuidanceCategory;
            [JsonProperty(Order = 103)]
            public string[]?Tags;
            [JsonProperty(Order = 104)]
            public string?EnableCondition;
            [JsonProperty(Order = 105)]
            public bool IsVisibleInOverlay;
        }
        public class class_Primitive_Tap : class_Primitive {
            [JsonProperty(Order = 2)]
            public double X;
            [JsonProperty(Order = 3)]
            public double Y;
            [JsonProperty(Order = 4)]
            public string?Key;
            [JsonProperty(Order = 5)]
            public string?Key_alt1;
            [JsonProperty(Order = 6)]
            public bool ShowOnOverlay;

            [JsonConstructor]
            public class_Primitive_Tap() { type = "Tap, Bluestacks"; }
        }
        public class class_Primitive_Combo : class_Primitive {
            [JsonProperty(Order = 4)]
            public string?Key;
            [JsonProperty(Order = 5)]
            public string?Description;
            public class class_Event {
                public int Timestamp;
                public double X;
                public double Y;
                public int Delta;
                public string?EventType;
            }
            [JsonProperty(Order = 6)]
            public class_Event[]?Events;

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
            public string?KeyIn;
            [JsonProperty(Order = 7)]
            public string?KeyIn_alt1;
            [JsonProperty(Order = 8)]
            public string?KeyOut;
            [JsonProperty(Order = 9)]
            public string?KeyOut_alt1;
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
            public string?Key;
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
            public Type BindToType(string?assemblyName, string typeName) {
                if (typeName == "Tap") return typeof(class_Primitive_Tap);
                if (typeName == "Combo") return typeof(class_Primitive_Combo);
                if (typeName == "Zoom") return typeof(class_Primitive_Zoom);
                if (typeName == "TapRepeat") return typeof(class_Primitive_Repeat);
                return typeof(class_Primitive);
            }
            public void BindToName(Type serializedType, out string?assemblyName, out string?typeName) {
                assemblyName = null;
                typeName = null;
            }
        }
        public class_Primitive[]?Primitives = null;
        public class class_Strings {
            public class class_UserDefined { }
            [JsonProperty("User-Defined")]
            public class_UserDefined UserDefined = new class_UserDefined();
        }
        public class_Strings Strings = new class_Strings();

        class_Primitive[] Container.getData() => Primitives!;
        class_Primitive Container.makeTap(JsonAppendage.Tap tap) =>
            new class_Primitive_Tap {
                type = "Tap, Bluestacks",

                X = tap.X,
                Y = tap.Y,
                Key = tap.Key,
                Key_alt1 = "",
                ShowOnOverlay = true,

                Type = "Tap",
                Guidance = new class_Primitive.class_Guidance(),
                GuidanceCategory = "MISC",
                Tags = new string[0],
                EnableCondition = "",
                IsVisibleInOverlay = true,
            };
        class_Primitive Container.makeZoom(JsonAppendage.Zoom zoom) =>
            new class_Primitive_Zoom {
                type = "Tap, Bluestacks",

                X1 = zoom.X1,
                Y1 = zoom.Y1,
                X2 = zoom.X2,
                Y2 = zoom.Y2,
                KeyIn = zoom.KeyIn,
                KeyIn_alt1 = "",
                KeyOut = zoom.KeyOut,
                KeyOut_alt1 = "",
                Speed = 1,
                Mode = 0,
                Override = true,

                Type = "Tap",
                Guidance = new class_Primitive.class_Guidance(),
                GuidanceCategory = "MISC",
                Tags = new string[0],
                EnableCondition = "",
                IsVisibleInOverlay = true,
            };
        class_Primitive Container.makeRepeat(JsonAppendage.Repeat repeat) =>
            new class_Primitive_Repeat {
                type = "Tap, Bluestacks",

                X = repeat.X,
                Y = repeat.Y,
                Key = repeat.Key,
                Count = repeat.Count,
                Delay = repeat.Delay,
                ShowOnOverlay = true,
                RepeatUntilKeyUp = true,

                Type = "Tap",
                Guidance = new class_Primitive.class_Guidance(),
                GuidanceCategory = "MISC",
                Tags = new string[0],
                EnableCondition = "",
                IsVisibleInOverlay = true,
            };
        class_Primitive Container.makeCombo(JsonAppendage.Combo combo) {
            var e = new class_Primitive_Combo.class_Event[combo.Events.Length];
            for (int i = 0; i < combo.Events.Length; ++i) {
                MacroCommand c = combo.Events[i];
                string typename;
                switch (c.type) {
                    default: continue;
                    case (int)MacroCommand.Type.DOWN: typename = "MouseDown"; break;
                    case (int)MacroCommand.Type.UP: typename = "MouseUp"; break;
                    case (int)MacroCommand.Type.MOVE: typename = "MouseMove"; break;
                }
                e[i] = new class_Primitive_Combo.class_Event {
                    Timestamp = c.time,
                    X = c.x,
                    Y = c.y,
                    Delta = 0,
                    EventType = typename,
                };
            }
            return new class_Primitive_Combo {
                type = "Combo, Bluestacks",

                Key = combo.Key,
                Description = "",
                Events = e,

                Type = "Combo",
                Guidance = new class_Primitive.class_Guidance(),
                GuidanceCategory = "MISC",
                Tags = new string[0],
                EnableCondition = "",
                IsVisibleInOverlay = true,
            };
        }

        public JsonMacroBs13(
            IEnumerable<string> scores,
            JsonAppendage appendage,
            string song_name,
            ref CodecSettings settings) {
            MacroCommand[][] commands = MacroCodec.ParseLines(scores, ref settings);

            int n_con = commands.Length + appendage.tap.Length + appendage.zoom.Length + appendage.repeat.Length + appendage.combo.Length;
            Primitives = new JsonMacroBs13.class_Primitive[n_con];

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

                Primitives[i] = new JsonMacroBs13.class_Primitive_Combo {
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

            MacroCodec.AddAppendage(this, appendage, commands.Length);
        }
    }
}