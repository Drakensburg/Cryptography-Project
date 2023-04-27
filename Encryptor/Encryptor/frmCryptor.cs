using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryptor
{
    public partial class frmCryptor : Form
    {
        public string sEncKey;
        public string sFilePath;

        //===Cryptography
        static void Crypt_Transposition()
        {
            //Will encrypt data using Keyed-Transposition Cypher
        }

        static void Crypt_Viganere()
        {
            //Will encrypt data using Viganere Cypher
        }

        static void Crypt_Vernom()
        {
            //Will encrypt data using Vernom Cypher
        }

        static void Crypt_Unique()
        {
            //Will encrypt data using Homebrew Cypher
        }
        //===Cryptography



        //======Actions
        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogSelector = new OpenFileDialog
            {
                InitialDirectory = @System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Title = "Select File",

                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialogSelector.ShowDialog() == DialogResult.OK)
            {
                tbFPath.Text = openFileDialogSelector.FileName;
                sFilePath = openFileDialogSelector.FileName;
            }
        }

        private void btnConstraints_Click(object sender, EventArgs e)
        {
            sEncKey = tbKey.Text;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            //Will encrypt data using selected methods
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            //Will decrypt data using selected methods
        }
        //======Actions



        //===System
        public frmCryptor()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //===System
    }
}
