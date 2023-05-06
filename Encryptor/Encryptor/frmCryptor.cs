using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Encryptor
{
    public partial class frmCryptor : Form
    {
        public string sEncKey;
        public string sFilePath;
        public bool bPass = false;
        public bool bLoca = false;

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
            bLoca = true;

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

                rtbDataView.AppendText("File: "+ sFilePath + " selected for cryption.\r\n\n");
            }    
            else
            {
                    bLoca = false;
            }
        }

        private void btnConstraints_Click(object sender, EventArgs e)
        {
            sEncKey = tbKey.Text;
            bPass = true;

            rtbDataView.AppendText("Key has been set.\r\n\n");
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (bLoca == true && bPass == true)
            {
                byte[] bytesEncrypted;
                byte[] bFile = File.ReadAllBytes(sFilePath);
                string sFile = System.Text.Encoding.UTF8.GetString(bFile);

                if (cbViganere.Checked)
                {
                    bytesEncrypted = Encoding.ASCII.GetBytes(Vig_Encipher(sFile, sEncKey));
                    File.WriteAllBytes(sFilePath + ".crypt", bytesEncrypted);
                }

                bPass = false;
                bLoca = false;

                rtbDataView.Clear();
                rtbDataView.AppendText("File: " + sFilePath + " encrypted.\r\n\n");
            }
            else if (bLoca == false)
            {
                MessageBox.Show("PLEASE ENSURE FILE IS SELECTED");
                bLoca = false;
            }
            else if (bPass == false)
            {
                MessageBox.Show("PLEASE ENSURE KEY IS SET");
                bPass = false;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string sUpdatedFilePath = sFilePath.Remove(sFilePath.Length - 6, 6);
            string sCheckCrypt = sFilePath.Remove(0,sFilePath.Length - 6);

            if (bLoca == true && bPass == true && sCheckCrypt == ".crypt")
            {
                byte[] bytesDecrypted;
                byte[] bFile = File.ReadAllBytes(sFilePath);
                string sFile = System.Text.Encoding.UTF8.GetString(bFile);

                if (cbViganere.Checked)
                {
                    bytesDecrypted = Encoding.ASCII.GetBytes(Vig_Decipher(sFile, sEncKey));
                    
                    File.WriteAllBytes(sUpdatedFilePath, bytesDecrypted);
                }

                bPass = false;
                bLoca = false;

                rtbDataView.Clear();
                rtbDataView.AppendText("File: " + sFilePath + " decrypted.\r\n\n");
            }
            else if (bLoca == false)
            {
                MessageBox.Show("PLEASE ENSURE FILE IS SELECTED");
                bLoca = false;
            }
            else if (bPass == false)
            {
                MessageBox.Show("PLEASE ENSURE KEY IS SET");
                bPass = false;
            }
            else if (!(sCheckCrypt == ".crypt"))
            {
                MessageBox.Show("ONLY .CRYPT FILES CAN BE DECRYPTED");
            }
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

        private void cbTransposition_CheckedChanged(object sender, EventArgs e)
        {
            rtbDataView.AppendText("Transposition Cryption Selected.\r\n\n");
        }

        private void cbViganere_CheckedChanged(object sender, EventArgs e)
        {
            rtbDataView.AppendText("Vigenere Cryption Selected.\r\n\n");
        }

        private void cbVernom_CheckedChanged(object sender, EventArgs e)
        {
            rtbDataView.AppendText("Vernom Cryption Selected.\r\n\n");
        }

        private void cbUnique_CheckedChanged(object sender, EventArgs e)
        {
            rtbDataView.AppendText("Unique Cryption Selected.\r\n\n");
        }
        //===System
    }
}
