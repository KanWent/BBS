using System.Reflection;

namespace MockTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set
            {
                filePath = value;
                if (!string.IsNullOrEmpty(filePath))
                {
                    cmbModel.Enabled = true;

                    InitCombox();
                }
                else
                {
                    cmbModel.Enabled = false;
                }
            }
        }


        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "dll files (*.dll)|*.dll";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = openFileDialog.FileName;
            }
        }
        Assembly assembly;
        private void InitCombox()
        {
            assembly = Assembly.LoadFile(filePath);
            var allTypes = assembly.GetTypes().Where(t => t.IsClass && t.IsPublic).ToList();

            cmbModel.DataSource = allTypes;
            cmbModel.DisplayMember = "FullName";
            cmbModel.ValueMember = "FullName";
        }

    }
}