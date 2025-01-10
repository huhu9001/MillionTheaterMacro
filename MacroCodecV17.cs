using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MilishitaMacro {
    class JsonMacroBs17 {
        public class class_MetaData {
            public string ParserVersion = "17";
            public string UpdateVersion = "";
            public string UpdataArticleKey = "";
            public string CloudUpdateTimeUTC = "";
        }
        public class_MetaData MetaData = new class_MetaData();

        public class class_ControlSchemes {
            public string Name;
            public bool BuiltIn = false;
            public bool Selected = true;
            public bool IsBookMarked = false;
            public bool IsCategoryVisible = true;
            public string KeyboardLayout = "";

            public class class_GameControls {
                [JsonProperty("$type", Order = 1)]
                public string type;
                [JsonProperty(Order = 2)]
                public string Type;
                [JsonProperty(Order = 3)]
                public int Tweaks = 0;
                [JsonProperty(Order = 4)]
                public bool Exclusive = false;
                [JsonProperty(Order = 5)]
                public int ExclusiveDelay = 200;
                [JsonProperty(Order = 6)]
                public string XExpr = "";
                [JsonProperty(Order = 7)]
                public string YExpr = "";
                [JsonProperty(Order = 8)]
                public string XOverlayOffset = "";
                [JsonProperty(Order = 9)]
                public string YOverlayOffset = "";
                [JsonProperty(Order = 10)]
                public string StartCondition = "";
                [JsonProperty(Order = 11)]
                public string EnableCondition = "";
                [JsonProperty(Order = 12)]
                public bool ShowOnOverlay = true;

                public class class_Guidance { }
                [JsonProperty(Order = 201)]
                public string GuidanceCategory;
                [JsonProperty(Order = 202)]
                public class_Guidance Guidance;

            }
            public class class_GameControls_Tap : class_GameControls {
                [JsonProperty(Order = 100)]
                public double X;
                [JsonProperty(Order = 101)]
                public double Y;
                [JsonProperty(Order = 102)]
                public string Key;
                [JsonProperty(Order = 103)]
                public string Key_alt1;

                [JsonConstructor]
                public class_GameControls_Tap() { type = "Tap, Bluestacks"; }
                public class_GameControls_Tap(JsonAppendage.Tap j) {
                    type = "Tap, Bluestacks";
                    Type = "Tap";
                    Tweaks = 0;
                    Exclusive = false;
                    ExclusiveDelay = 200;
                    XExpr = "";
                    YExpr = "";
                    XOverlayOffset = "";
                    YOverlayOffset = "";
                    StartCondition = "";
                    EnableCondition = "";
                    ShowOnOverlay = true;

                    X = j.X;
                    Y = j.Y;
                    Key = j.Key;
                    Key_alt1 = "";

                    GuidanceCategory = "";
                    Guidance = new class_Guidance();
                }
            }
            public class class_GameControls_Script : class_GameControls {
                [JsonProperty(Order = 100)]
                public double X;
                [JsonProperty(Order = 101)]
                public double Y;
                [JsonProperty(Order = 102)]
                public string Key;
                [JsonProperty(Order = 103)]
                public string Key_alt1;
                [JsonProperty(Order = 104)]
                public string[] Commands;

                [JsonConstructor]
                public class_GameControls_Script() { type = "Script, Bluestacks"; }
                public class_GameControls_Script(JsonAppendage.Combo j) {
                    type = "Script, Bluestacks";
                    Type = "Script";
                    Tweaks = 0;
                    Exclusive = false;
                    ExclusiveDelay = 200;
                    XExpr = "";
                    YExpr = "";
                    XOverlayOffset = "";
                    YOverlayOffset = "";
                    StartCondition = "";
                    EnableCondition = "";
                    ShowOnOverlay = true;

                    X = 10;
                    Y = 10;
                    Key = j.Key;
                    Key_alt1 = "";

                    List<string> o = new List<string>(j.Events.Length * 2);
                    int time_prev = 0;
                    foreach (MacroCommand c in j.Events.OrderBy(c => c.time)) {
                        string typename;
                        switch (c.type) {
                            default: continue;
                            case (int)MacroCommand.Type.DOWN: typename = "mouseDown"; break;
                            case (int)MacroCommand.Type.UP: typename = "mouseUp"; break;
                            case (int)MacroCommand.Type.MOVE: typename = "mouseMove"; break;
                        }
                        int time_det = c.time - time_prev;
                        if (time_det > 0) o.Add($"wait {time_det}");
                        o.Add(typename + ' ' + c.x + ' ' + c.y);
                        time_prev = c.time;
                    }
                    Commands = o.ToArray();

                    GuidanceCategory = "";
                    Guidance = new class_Guidance();
                }
            }
            public class class_GameControls_Zoom : class_GameControls {
                [JsonProperty(Order = 100)]
                public double X1;
                [JsonProperty(Order = 101)]
                public double Y1;
                [JsonProperty(Order = 102)]
                public double X2;
                [JsonProperty(Order = 103)]
                public double Y2;
                [JsonProperty(Order = 104)]
                public double Speed;
                [JsonProperty(Order = 105)]
                public double MinDistance;
                [JsonProperty(Order = 106)]
                public int Mode;
                [JsonProperty(Order = 107)]
                public int ResetDelay;
                [JsonProperty(Order = 108)]
                public bool Override;
                [JsonProperty(Order = 109)]
                public string KeyIn;
                [JsonProperty(Order = 110)]
                public string KeyIn_alt1;
                [JsonProperty(Order = 111)]
                public string KeyOut;
                [JsonProperty(Order = 112)]
                public string KeyOut_alt1;
                [JsonProperty(Order = 113)]
                public string KeyModifier;
                [JsonProperty(Order = 114)]
                public string KeyModifier_alt1;
                [JsonProperty(Order = 115)]
                public string KeyWheel;

                [JsonConstructor]
                public class_GameControls_Zoom() { type = "Zoom, Bluestacks"; }
                public class_GameControls_Zoom(JsonAppendage.Zoom j) {
                    type = "Zoom, Bluestacks";
                    Type = "Zoom";
                    Tweaks = 0;
                    Exclusive = false;
                    ExclusiveDelay = 200;
                    XExpr = "";
                    YExpr = "";
                    XOverlayOffset = "";
                    YOverlayOffset = "";
                    StartCondition = "";
                    EnableCondition = "";
                    ShowOnOverlay = true;

                    X1 = j.X1;
                    Y1 = j.Y1;
                    X2 = j.X2;
                    Y2 = j.Y2;
                    Speed = 1;
                    MinDistance = 5;
                    Mode = 0;
                    ResetDelay = 75;
                    Override = true;
                    KeyIn = j.KeyIn;
                    KeyIn_alt1 = "";
                    KeyOut = j.KeyOut;
                    KeyOut_alt1 = "";
                    KeyModifier = "";
                    KeyModifier_alt1 = "";
                    KeyWheel = "";

                    GuidanceCategory = "";
                    Guidance = new class_Guidance();
                }
            }
            public class class_GameControls_Repeat : class_GameControls {
                [JsonProperty(Order = 100)]
                public double X;
                [JsonProperty(Order = 101)]
                public double Y;
                [JsonProperty(Order = 102)]
                public int Count;
                [JsonProperty(Order = 103)]
                public int Delay;
                [JsonProperty(Order = 104)]
                public bool RepeatUntilKeyUp;
                [JsonProperty(Order = 105)]
                public string Key;
                [JsonProperty(Order = 106)]
                public string Key_alt1;

                [JsonConstructor]
                public class_GameControls_Repeat() { type = "TapRepeat, Bluestacks"; }
                public class_GameControls_Repeat(JsonAppendage.Repeat j) {
                    type = "TapRepeat, Bluestacks";
                    Type = "TapRepeat";
                    Tweaks = 0;
                    Exclusive = false;
                    ExclusiveDelay = 200;
                    XExpr = "";
                    YExpr = "";
                    XOverlayOffset = "";
                    YOverlayOffset = "";
                    StartCondition = "";
                    EnableCondition = "";
                    ShowOnOverlay = true;

                    X = j.X;
                    Y = j.Y;
                    Count = j.Count;
                    Delay = j.Delay;
                    RepeatUntilKeyUp = true;
                    Key = j.Key;
                    Key_alt1 = "";

                    GuidanceCategory = "";
                    Guidance = new class_Guidance();
                }
            }
            public class GameControlsTypesBinder : Newtonsoft.Json.Serialization.ISerializationBinder {
                public Type BindToType(string assemblyName, string typeName) {
                    if (typeName == "Tap") return typeof(class_GameControls_Tap);
                    if (typeName == "Script") return typeof(class_GameControls_Script);
                    if (typeName == "Zoom") return typeof(class_GameControls_Zoom);
                    if (typeName == "TapRepeat") return typeof(class_GameControls_Repeat);
                    return typeof(class_GameControls);
                }
                public void BindToName(Type serializedType, out string assemblyName, out string typeName) {
                    assemblyName = null;
                    typeName = null;
                }
            }
            public class_GameControls[] GameControls = null;

            public int[] Images = new int[0];
        }
        public class_ControlSchemes[] ControlSchemes = { new class_ControlSchemes() };
        
        public class class_Strings {}
        public class_Strings Strings = new class_Strings();
    }

    partial class MacroCodec {
        static void AddAppendage(JsonMacroBs17.class_ControlSchemes.class_GameControls[] output, JsonAppendage app, int n_noapp) {
            int index = n_noapp;
            for (int i = 0; i < app.tap.Length; ++i, ++index)
                output[index] = new JsonMacroBs17.class_ControlSchemes.class_GameControls_Tap(app.tap[i]);
            for (int i = 0; i < app.zoom.Length; ++i, ++index)
                output[index] = new JsonMacroBs17.class_ControlSchemes.class_GameControls_Zoom(app.zoom[i]);
            for (int i = 0; i < app.repeat.Length; ++i, ++index)
                output[index] = new JsonMacroBs17.class_ControlSchemes.class_GameControls_Repeat(app.repeat[i]);
            for (int i = 0; i < app.combo.Length; ++i, ++index)
                output[index] = new JsonMacroBs17.class_ControlSchemes.class_GameControls_Script(app.combo[i]);
        }

        static public JsonMacroBs17.class_ControlSchemes.class_GameControls[] ChangeAppendage(JsonMacroBs17.class_ControlSchemes.class_GameControls[] input, JsonAppendage app) {
            int n_noapp = Array.FindIndex(input, p => !(p is JsonMacroBs17.class_ControlSchemes.class_GameControls_Script));
            if (n_noapp == -1) n_noapp = input.Length;

            int output_size = n_noapp + app.tap.Length + app.zoom.Length + app.repeat.Length + app.combo.Length;
            JsonMacroBs17.class_ControlSchemes.class_GameControls[] output = new JsonMacroBs17.class_ControlSchemes.class_GameControls[output_size];

            Array.Copy(input, output, n_noapp);
            AddAppendage(output, app, n_noapp);

            return output;
        }

        static public JsonMacroBs17 ConvertMacroV17(
            IEnumerable<string> scores,
            JsonAppendage appendage,
            string song_name,
            ref CodecSettings settings) {
            JsonMacroBs17 macro = new JsonMacroBs17();
            MacroCommand[][] commands = ParseLines(scores, ref settings);
            
            int n_con = commands.Length + appendage.tap.Length + appendage.zoom.Length + appendage.repeat.Length + appendage.combo.Length;
            macro.ControlSchemes[0].GameControls = new JsonMacroBs17.class_ControlSchemes.class_GameControls[n_con];
            
            macro.ControlSchemes[0].Name = $"{song_name}_{CodecSettings.diffs[settings.nDiff].shortName}";

            for (int i = 0; i < commands.Length; ++i) {
                List<string> o = new List<string>(commands[i].Length);
                int time_last = 0;
                foreach (MacroCommand c in commands[i]) {
                    string typename;
                    switch (c.type) {
                        default: continue;
                        case (int)MacroCommand.Type.DOWN: typename = "mouseDown"; break;
                        case (int)MacroCommand.Type.UP: typename = "mouseUp"; break;
                        case (int)MacroCommand.Type.MOVE: typename = "mouseMove"; break;
                    }
                    int time_det = c.time - time_last;
                    if (time_det > 0) o.Add($"wait {time_det}");
                    o.Add(typename + ' ' + c.x + ' ' + c.y);
                    time_last = c.time;
                }
                macro.ControlSchemes[0].GameControls[i] =
                    new JsonMacroBs17.class_ControlSchemes.class_GameControls_Script {
                        type = "Script, Bluestacks",
                        Type = "Script",
                        Tweaks = 0,
                        Exclusive = false,
                        ExclusiveDelay = 200,
                        XExpr = "",
                        YExpr = "",
                        XOverlayOffset = "",
                        YOverlayOffset = "",
                        StartCondition = "",
                        EnableCondition = "",
                        ShowOnOverlay = true,
                        X = 50 + i * 5,
                        Y = 50,
                        Key = "Z",
                        Key_alt1 = "",
                        Commands = o.ToArray(),
                        GuidanceCategory = "",
                        Guidance = new JsonMacroBs17.class_ControlSchemes.class_GameControls.class_Guidance(),
                    };
            }

            AddAppendage(macro.ControlSchemes[0].GameControls, appendage, commands.Length);

            return macro;
        }
    }
}