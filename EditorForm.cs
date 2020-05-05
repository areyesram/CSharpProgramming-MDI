using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace areyesram
{
    public sealed partial class EditorForm : Form
    {
        public EditorForm(string fileName = null)
        {
            InitializeComponent();
            txtEditor.TextChanged += (o, e) => DataForm.Instance.Reload();
            Activated += (o, e) => DataForm.Instance.Reload();
            FormClosed += (o, e) =>
            {
                ((EditorForm) o).txtEditor.Text = "";
                DataForm.Instance.Reload();
            };
            if (fileName == null)
            {
                Text = "[noname]";
            }
            else
            {
                Text = Path.GetFileName(fileName);
                txtEditor.Text = File.ReadAllText(fileName);
            }
        }

        internal Stats GetStats()
        {
            var s = txtEditor.Text;
            var word = new Regex(@"[\w']+");
            return new Stats
            {
                Chars = s.Length,
                Alpha = s.Count(char.IsLetterOrDigit),
                Words = word.Matches(s).Count
            };
        }
    }
}
