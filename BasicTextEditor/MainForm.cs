using System;
using System.Drawing;
using System.Windows.Forms;

namespace BasicTextEditor
{    public interface IMainForm
    {
        string FilePath { get; }
        string Content { get; set; }
        void SetSymbolCount(int count);
        event EventHandler OpenFileClick;
        event EventHandler SaveFileClick;
        event EventHandler ContentChanged;
    }

    public partial class MainForm : Form, IMainForm
    {

        public MainForm()
        {
            InitializeComponent();
            btnOpenFile.Click += BtnOpenFile_Click;
            btnSaveFile.Click += BtnSaveFile_Click;
            fldContent.TextChanged += FldContent_TextChanged;
            btnSelectFile.Click += BtnSelectFile_Click;
            numFont.ValueChanged += NumFont_ValueChanged;
        }

        #region Events forwarding
        private void FldContent_TextChanged(object sender, EventArgs e)
        {
            if (ContentChanged != null) ContentChanged(this, EventArgs.Empty);
        }

        private void BtnSaveFile_Click(object sender, EventArgs e)
        {
            if (SaveFileClick != null) SaveFileClick(this, EventArgs.Empty);
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            if (OpenFileClick != null) OpenFileClick(this, EventArgs.Empty);
        }
        #endregion

        #region IMainForm
        public string FilePath
        {
            get { return fldFilePath.Text; }
        }

        public string Content
        {
            get { return fldContent.Text; }
            set { fldContent.Text = value; }
        }

        public void SetSymbolCount(int count)
        {
            lblSymbolNumber.Text = count.ToString();
        }

        public event EventHandler OpenFileClick;
        public event EventHandler SaveFileClick;
        public event EventHandler ContentChanged;
        #endregion

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text files|*.txt|All files|*.*";

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                fldFilePath.Text = dlg.FileName;

                if (OpenFileClick != null) OpenFileClick(this, EventArgs.Empty);
            }    
        }

        private void NumFont_ValueChanged(object sender, EventArgs e)
        {
            fldContent.Font = new Font("Calibri", (float)numFont.Value);
        }
    }
}
