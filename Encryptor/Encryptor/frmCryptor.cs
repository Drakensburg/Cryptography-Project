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
        //===Transposition
        static void Crypt_Transposition()
        {
            //Will encrypt data using Keyed-Transposition Cypher
        }
        //===Transposition


        //====Viganere
        private static int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }

        private static string Crypt_Viganere(string sInput, string sKey, bool bEncipher)
        {
            for (int i = 0; i < sKey.Length; ++i)
                if (!char.IsLetter(sKey[i]))
                    return null; 

            string sOutput = string.Empty;
            int iNonAlphaCharCount = 0;

            for (int i = 0; i < sInput.Length; ++i)
            {
                if (char.IsLetter(sInput[i]))
                {
                    bool bCIsUpper = char.IsUpper(sInput[i]);
                    char offset = bCIsUpper ? 'A' : 'a';
                    int iKeyIndex = (i - iNonAlphaCharCount) % sKey.Length;
                    int k = (bCIsUpper ? char.ToUpper(sKey[iKeyIndex]) : char.ToLower(sKey[iKeyIndex])) - offset;
                    k = bEncipher ? k : -k;
                    char cCh = (char)((Mod(((sInput[i] + k) - offset), 26)) + offset);
                    sOutput += cCh;
                }
                else
                {
                    sOutput += sInput[i];
                    ++iNonAlphaCharCount;
                }
            }

            return sOutput;
        }

        public static string Vig_Encipher(string sInput, string sKey)
        {
            return Crypt_Viganere(sInput, sKey, true);
        }

        public static string Vig_Decipher(string sInput, string sKey)
        {
            return Crypt_Viganere(sInput, sKey, false);
        }
        //====Viganere

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
            //Vig_Encipher(Input, sEncKey);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            //Vig_Decipher(Input, sEncKey);
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
