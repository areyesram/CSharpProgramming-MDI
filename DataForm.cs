using System.Windows.Forms;

namespace areyesram
{
    public partial class DataForm : Form
    {
        #region Singleton pattern

        private DataForm()
        {
            InitializeComponent();
        }

        private static DataForm _instance;

        internal static DataForm Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                _instance = new DataForm();
                return _instance;
            }
        }

        private void DataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

        #endregion

        internal void Reload()
        {
            if (Instance.MdiParent == null) return;
            var total = new Stats();
            foreach (var form in Instance.MdiParent.MdiChildren)
            {
                var editor = form as EditorForm;
                if (editor == null) continue;
                var stats = editor.GetStats();
                total.Chars += stats.Chars;
                total.Alpha += stats.Alpha;
                total.Words += stats.Words;
            }
            lblChars.Text = total.Chars.ToString("N0");
            lblAlpha.Text = total.Alpha.ToString("N0");
            lblWords.Text = total.Words.ToString("N0");
        }
    }
}
