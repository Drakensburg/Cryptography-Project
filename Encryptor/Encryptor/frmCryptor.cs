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

        //======Cryptography
        //====Transposition
        private static int[] GetShiftIndexes(string sKey)
        {
            int iKeyLength = sKey.Length;
            int[] iIndexes = new int[iKeyLength];
            List<KeyValuePair<int, char>> sortedKey = new List<KeyValuePair<int, char>>();
            int i;

            for (i = 0; i < iKeyLength; ++i)
                sortedKey.Add(new KeyValuePair<int, char>(i, sKey[i]));

            sortedKey.Sort(
                delegate (KeyValuePair<int, char> pair1, KeyValuePair<int, char> pair2) {
                    return pair1.Value.CompareTo(pair2.Value);
                }
            );

            for (i = 0; i < iKeyLength; ++i)
                iIndexes[sortedKey[i].Key] = i;

            return iIndexes;
        }

        public static string Tran_Encipher(string sInput, string sKey, char cPadChar)
        {
            sInput = (sInput.Length % sKey.Length == 0) ? sInput : sInput.PadRight(sInput.Length - (sInput.Length % sKey.Length) + sKey.Length, cPadChar);
            StringBuilder output = new StringBuilder();
            int totalChars = sInput.Length;
            int totalColumns = sKey.Length;
            int totalRows = (int)Math.Ceiling((double)totalChars / totalColumns);
            char[,] rowChars = new char[totalRows, totalColumns];
            char[,] colChars = new char[totalColumns, totalRows];
            char[,] sortedColChars = new char[totalColumns, totalRows];
            int currentRow, currentColumn, i, j;
            int[] shiftIndexes = GetShiftIndexes(sKey);

            for (i = 0; i < totalChars; ++i)
            {
                currentRow = i / totalColumns;
                currentColumn = i % totalColumns;
                rowChars[currentRow, currentColumn] = sInput[i];
            }

            for (i = 0; i < totalRows; ++i)
                for (j = 0; j < totalColumns; ++j)
                    colChars[j, i] = rowChars[i, j];

            for (i = 0; i < totalColumns; ++i)
                for (j = 0; j < totalRows; ++j)
                    sortedColChars[shiftIndexes[i], j] = colChars[i, j];

            for (i = 0; i < totalChars; ++i)
            {
                currentRow = i / totalRows;
                currentColumn = i % totalRows;
                output.Append(sortedColChars[currentRow, currentColumn]);
            }

            return output.ToString();
        }

        public static string Tran_Decipher(string sInput, string sKey)
        {
            StringBuilder output = new StringBuilder();
            int totalChars = sInput.Length;
            int totalColumns = (int)Math.Ceiling((double)totalChars / sKey.Length);
            int totalRows = sKey.Length;
            char[,] rowChars = new char[totalRows, totalColumns];
            char[,] colChars = new char[totalColumns, totalRows];
            char[,] unsortedColChars = new char[totalColumns, totalRows];
            int currentRow, currentColumn, i, j;
            int[] shiftIndexes = GetShiftIndexes(sKey);

            for (i = 0; i < totalChars; ++i)
            {
                currentRow = i / totalColumns;
                currentColumn = i % totalColumns;
                rowChars[currentRow, currentColumn] = sInput[i];
            }

            for (i = 0; i < totalRows; ++i)
                for (j = 0; j < totalColumns; ++j)
                    colChars[j, i] = rowChars[i, j];

            for (i = 0; i < totalColumns; ++i)
                for (j = 0; j < totalRows; ++j)
                    unsortedColChars[i, j] = colChars[i, shiftIndexes[j]];

            for (i = 0; i < totalChars; ++i)
            {
                currentRow = i / totalRows;
                currentColumn = i % totalRows;
                output.Append(unsortedColChars[currentRow, currentColumn]);
            }

            return output.ToString();
        }
        //====Transposition


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


        //====Vernom
        static void Crypt_Vernom()
        {
            //Will encrypt data using Vernom Cypher
        }
        //====Vernom


        //====Unique
        static void Crypt_Unique()
        {
            //Will encrypt data using Homebrew Cypher
        }
        //====Unique
        //======Cryptography



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
            rtbDataView.Clear();
            if (bLoca == true && bPass == true && (cbTransposition.Checked || cbUnique.Checked || cbVernom.Checked || cbViganere.Checked))
            {
                byte[] bytesEncrypted = Encoding.ASCII.GetBytes("empty");
                byte[] bFile = File.ReadAllBytes(sFilePath);
                string sFile = System.Text.Encoding.UTF8.GetString(bFile);

                if (cbTransposition.Checked)
                {
                    bytesEncrypted = Encoding.ASCII.GetBytes(Tran_Encipher(sFile, sEncKey, '-'));
                    sFile = System.Text.Encoding.UTF8.GetString(bytesEncrypted);
                }

                if (cbViganere.Checked)
                {
                    bytesEncrypted = Encoding.ASCII.GetBytes(Vig_Encipher(sFile, sEncKey));
                    sFile = System.Text.Encoding.UTF8.GetString(bytesEncrypted);
                }

                if (cbVernom.Checked)
                {
                    //bytesEncrypted = Encoding.ASCII.GetBytes( );
                    sFile = System.Text.Encoding.UTF8.GetString(bytesEncrypted);
                }

                if (cbUnique.Checked)
                {
                    //bytesEncrypted = Encoding.ASCII.GetBytes( );
                    sFile = System.Text.Encoding.UTF8.GetString(bytesEncrypted);
                }

                File.WriteAllBytes(sFilePath + ".crypt", bytesEncrypted);

                bPass = false;
                bLoca = false;

                rtbDataView.Clear();
                rtbDataView.AppendText("File: " + sFilePath + " encrypted.\r\n\n");
                tbFPath.Clear();
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
            else if (!(cbTransposition.Checked || cbUnique.Checked || cbVernom.Checked || cbViganere.Checked))
            {
                MessageBox.Show("PLEASE CHOOSE AN ENCRYPTION METHOD");
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            rtbDataView.Clear();
            string sUpdatedFilePath = sFilePath.Remove(sFilePath.Length - 6, 6);
            string sCheckCrypt = sFilePath.Remove(0,sFilePath.Length - 6);

            if (bLoca == true && bPass == true && sCheckCrypt == ".crypt" && (cbTransposition.Checked || cbUnique.Checked || cbVernom.Checked || cbViganere.Checked))
            {
                byte[] bytesDecrypted = Encoding.ASCII.GetBytes("empty");
                byte[] bFile = File.ReadAllBytes(sFilePath);
                string sFile = System.Text.Encoding.UTF8.GetString(bFile);

                if (cbUnique.Checked)
                {
                    //bytesDecrypted = Encoding.ASCII.GetBytes( );
                    sFile = System.Text.Encoding.UTF8.GetString(bytesDecrypted);
                }

                if (cbVernom.Checked)
                {
                    //bytesDecrypted = Encoding.ASCII.GetBytes( );
                    sFile = System.Text.Encoding.UTF8.GetString(bytesDecrypted);
                }

                if (cbViganere.Checked)
                {
                    bytesDecrypted = Encoding.ASCII.GetBytes(Vig_Decipher(sFile, sEncKey));
                    sFile = System.Text.Encoding.UTF8.GetString(bytesDecrypted);
                }

                if (cbTransposition.Checked)
                {
                    bytesDecrypted = Encoding.ASCII.GetBytes(Tran_Decipher(sFile, sEncKey));
                    sFile = System.Text.Encoding.UTF8.GetString(bytesDecrypted);
                }

                File.WriteAllBytes(sUpdatedFilePath, bytesDecrypted);

                bPass = false;
                bLoca = false;

                rtbDataView.Clear();
                rtbDataView.AppendText("File: " + sFilePath + " decrypted.\r\n\n");
                tbFPath.Clear();
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
            else if (!(cbTransposition.Checked || cbUnique.Checked || cbVernom.Checked || cbViganere.Checked))
            {
                MessageBox.Show("PLEASE CHOOSE AN DECRYPTION METHOD");
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
            if (cbTransposition.Checked)
            {
                rtbDataView.AppendText("TRANSPOSITION CRYPTION SELECTED.\r\n\n");
            }
            else
            {
                rtbDataView.AppendText("TRANSPOSITION CRYPTION DELECTED.\r\n\n");
            }
            
        }

        private void cbViganere_CheckedChanged(object sender, EventArgs e)
        {
            if (cbViganere.Checked)
            {
                rtbDataView.AppendText("VIGENERE CRYPTION SELECTED.\r\n\n");
             }
            else
            {
                rtbDataView.AppendText("VIGENERE CRYPTION DELECTED.\r\n\n");
            }
        }

        private void cbVernom_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVernom.Checked)
            {
                rtbDataView.AppendText("VERNOM CRYPTION SELECTED.\r\n\n");
            }
            else
            {
                rtbDataView.AppendText("VERNOM CRYPTION DELECTED.\r\n\n");
            }
        }

        private void cbUnique_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUnique.Checked)
            {
                rtbDataView.AppendText("UNIQUE CRYPTION SELECTED.\r\n\n");
            }
            else
            {
                rtbDataView.AppendText("UNIQUE CRYPTION DELECTED.\r\n\n");
            }
        }
        //===System
    }
}
