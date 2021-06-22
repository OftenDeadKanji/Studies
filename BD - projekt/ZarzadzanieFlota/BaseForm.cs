using System;
using System.Windows.Forms;
using System.IO;

namespace ZarzadzanieFlota
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void openMainWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChoosingProffesion formNew = new ChoosingProffesion();
            ChangeForm(this, formNew);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uri uri = new System.Uri(Path.GetFullPath("..\\..\\Help\\BD_Help.chm"));
            string helpUri = uri.AbsoluteUri;

            Help.ShowHelp(this, helpUri);
        }
    }
}
