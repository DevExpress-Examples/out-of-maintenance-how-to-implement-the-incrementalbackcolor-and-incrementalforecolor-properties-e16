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
                typeof(RepositoryItemMyTextEdit), typeof(MyTextEditViewInfo), new TextEditPainter(), true));
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

    public class MyTextEditViewInfo : TextEditViewInfo {
        public MyTextEditViewInfo(RepositoryItem item) : base(item) { }

        public override Color GetSystemColor(Color color) {
            if (color == SystemColors.HighlightText) return ((RepositoryItemMyTextEdit)Owner).IncrementalForeColor;
            else if (color == SystemColors.Highlight) return ((RepositoryItemMyTextEdit)Owner).IncrementalBackColor;
            else return base.GetSystemColor(color);
        }
    }
}