namespace MilishitaMacro {
    abstract class GameControlItemContainer<ItemType, ComboItemType> {
        protected abstract ref ItemType[]? data();
        protected abstract ItemType makeTap(JsonAppendage.Tap tap);
        protected abstract ItemType makeZoom(JsonAppendage.Zoom zoom);
        protected abstract ItemType makeRepeat(JsonAppendage.Repeat repeat);
        protected abstract ItemType makeCombo(JsonAppendage.Combo combo);

        protected void AddAppendage(JsonAppendage app, int n_noapp) {
            ItemType[] output = data()!;
            int index = n_noapp;
            foreach (JsonAppendage.Tap tap in app.tap)
                output[index++] = makeTap(tap);
            foreach (JsonAppendage.Zoom zoom in app.zoom)
                output[index++] = makeZoom(zoom);
            foreach (JsonAppendage.Repeat repeat in app.repeat)
                output[index++] = makeRepeat(repeat);
            foreach (JsonAppendage.Combo combo in app.combo)
                output[index++] = makeCombo(combo);
        }

        public ItemType[]? ChangeAppendage(JsonAppendage app) {
            ItemType[]? input = data();
            if (input == null) return null;

            int n_noapp = Array.FindIndex(input, p => !(p is ComboItemType));
            if (n_noapp == -1) n_noapp = input.Length;

            int output_size = n_noapp + app.tap.Length + app.zoom.Length + app.repeat.Length + app.combo.Length;
            ItemType[] output = new ItemType[output_size];

            Array.Copy(input, output, n_noapp);
            AddAppendage(app, n_noapp);

            return data() = output;
        }
    }
}
