using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;

namespace DXSample {
    public class MyTextEdit : TextEdit {
        static MyTextEdit() { RepositoryItemMyTextEdit.RegisterMyTextEdit(); }

        public MyTextEdit() : base() { }

        public override string EditorTypeName { get { return RepositoryItemMyTextEdit.MyTextEditName; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemMyTextEdit Properties { get { return (RepositoryItemMyTextEdit)base.Properties; } }
    }

    [UserRepositoryItem("RegisterMyTextEdit")]
    public class RepositoryItemMyTextEdit : RepositoryItemTextEdit {
        static RepositoryItemMyTextEdit() { RegisterMyTextEdit(); }

        public RepositoryItemMyTextEdit() : base() { }

        internal static string MyTextEditName = "MyTextEdit";

        public override string EditorTypeName { get { return MyTextEditName; } }

        private Color incrementalBackColor;
        public Color IncrementalBackColor {
            get { return incrementalBackColor; }
            set { incrementalBackColor = value; }
        }

        private Color incrementalForeColor;
        public Color IncrementalForeColor {
            get { return incrementalForeColor; }
            set { incrementalForeColor = value; }
        }

        public static void RegisterMyTextEdit() {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(MyTextEditName, typeof(MyTextEdit),
                typeof(RepositoryItemMyTextEdit), typeof(TextEditViewInfo), new MyTextEditPainter(), true));
        }

        public override void Assign(RepositoryItem item) {
            BeginUpdate();
            try {
                base.Assign(item);
                RepositoryItemMyTextEdit source = item as RepositoryItemMyTextEdit;
                if (source == null) return;
                IncrementalBackColor = source.IncrementalBackColor;
                IncrementalForeColor = source.IncrementalForeColor;
            } finally { EndUpdate(); }
        }
    }

    public class MyTextEditPainter :TextEditPainter {
        public MyTextEditPainter() : base() { }

        protected override void DrawMatchedString(ControlGraphicsInfoArgs info, Rectangle bounds, string text, 
            string matchedText, AppearanceObject appearance, bool invert, int containsIndex) {
            TextEditViewInfo vi = info.ViewInfo as TextEditViewInfo;
            if (matchedText.Length > text.Length) matchedText = text;
            RepositoryItemMyTextEdit properties = (RepositoryItemMyTextEdit)vi.Item;
            AppearanceDefault highlight = new AppearanceDefault(properties.IncrementalForeColor, properties.IncrementalBackColor);
            info.Cache.Paint.DrawMultiColorString(info.Cache, bounds, text, matchedText, appearance, appearance.GetTextOptions().GetStringFormat(info.ViewInfo.DefaultTextOptions),
                highlight.ForeColor, highlight.BackColor, invert, containsIndex);
        }
    }
}