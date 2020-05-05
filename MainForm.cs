using System;
using System.IO;
using System.Windows.Forms;

namespace areyesram
{
    public partial class MainForm : Form
    {
        private const int MaxFileSize = 1024 * 1024 * 1024;
        public MainForm()
        {
            InitializeComponent();
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            //showing a multiple instance form
            var form = new EditorForm { MdiParent = this };
            form.Show();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog(this) != DialogResult.OK) return;
            var fileName = openFileDialog.FileName;
            var info = new FileInfo(fileName);
            if (info.Length > MaxFileSize)
            {
                Util.Warning("Sorry, file too big. Won't load.");
                return;
            }
            var form = new EditorForm(fileName) { MdiParent = this };
            form.Show();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            Util.Warning("Not implemented");
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {
            Util.Warning("Not implemented");
        }

        private void mnuRedo_Click(object sender, EventArgs e)
        {
            Util.Warning("Not implemented");
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            Util.Warning("Not implemented");
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            Util.Warning("Not implemented");
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            Util.Warning("Not implemented");
        }

        private void mnuSelect_Click(object sender, EventArgs e)
        {
            Util.Warning("Not implemented");
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuVertical_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuHorizontal_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            foreach (var childForm in MdiChildren)
                childForm.Close();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Util.Confirm())
                e.Cancel = true;
        }

        private void mnuStats_Click(object sender, EventArgs e)
        {
            //showing a single instance form
            DataForm.Instance.MdiParent = this;
            DataForm.Instance.Reload();
            DataForm.Instance.Show();
            DataForm.Instance.Activate();
        }
    }
}
