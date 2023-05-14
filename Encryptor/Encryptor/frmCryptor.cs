using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryptor
{
    public partial class frmCryptor : Form
    {
        public string sEncKey;
        public string sFilePath;
        public string sKeyFilePath;
        public bool bPass = false;
        public bool bLoca = false;
        public bool bKey = false;


        //======Cryptography
        //====Transposition
        private static int[] GetShiftIndexes(string sKey)
        {
            int keyLength = sKey.Length;
            int[] indexes = new int[keyLength];
            List<KeyValuePair<int, char>> sortedKey = new List<KeyValuePair<int, char>>();
            int i;

            for (i = 0; i < keyLength; ++i)
                sortedKey.Add(new KeyValuePair<int, char>(i, sKey[i]));

            sortedKey.Sort(
                delegate (KeyValuePair<int, char> pair1, KeyValuePair<int, char> pair2) {
                    return pair1.Value.CompareTo(pair2.Value);
                }
            );

            for (i = 0; i < keyLength; ++i)
                indexes[sortedKey[i].Key] = i;

            return indexes;
        }

        public static Byte[] Tran_Encipher(Byte[] bInput, string sKey)
        {
            string sInput = Encoding.Default.GetString(bInput);
            char padChar = ';';

            sInput = (sInput.Length % sKey.Length == 0) ? sInput : sInput.PadRight(sInput.Length - (sInput.Length % sKey.Length) + sKey.Length, padChar);
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

            MessageBox.Show("TRANSPOSITION SUCCESSFUL");
            return Encoding.Default.GetBytes(output.ToString());           
        }

        public static Byte[] Tran_Decipher(Byte[] bInput, string sKey)
        {
            string sInput = Encoding.Default.GetString(bInput);

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

            MessageBox.Show("TRANSPOSITION SUCCESSFUL");
            return Encoding.Default.GetBytes(output.ToString());
        }
        //====Transposition


        //====Viganere
        public static Byte[] Vig_Encipher(Byte[] bPlainText, string sKey)
        {

            Byte[] result = new Byte[bPlainText.Length];

            sKey = sKey.Trim().ToUpper();

            int keyIndex = 0;
            int keylength = sKey.Length;

            for (int i = 0; i < bPlainText.Length; i++)
            {
                keyIndex = keyIndex % keylength;
                int shift = (int)sKey[keyIndex] - 65;
                result[i] = (Byte)(((int)bPlainText[i] + shift) % 256);
                keyIndex++;
            }

            MessageBox.Show("VIGENERE SUCCESSFUL");
            return result;
        }

        public static Byte[] Vig_Decipher(Byte[] bCipherText, string sKey)
        {
            Byte[] result = new Byte[bCipherText.Length];

            sKey = sKey.Trim().ToUpper();

            int keyIndex = 0;
            int keylength = sKey.Length;

            for (int i = 0; i < bCipherText.Length; i++)
            {
                keyIndex = keyIndex % keylength;
                int shift = (int)sKey[keyIndex] - 65;
                result[i] = (Byte)(((int)bCipherText[i] + 256 - shift) % 256);
                keyIndex++;
            }

            MessageBox.Show("VIGENERE SUCCESSFUL");
            return result;
        }
        //====Viganere


        //====Vernom
        public Byte[] Encrypt_Vernom(Byte[] bPlainText)
        {
            //Will encrypt data using Vernom Cypher
                //file
                string KeyFilePath = "";
                Byte[] inputBytes = bPlainText;
                //make keyfile
                if (cbMkKey.Checked==true)
                {
                    //making key
                    KeyFilePath = tbKeyPath.Text;
                    Byte[] keyBytes = new Byte[inputBytes.Length];
                    using (var rng = new RNGCryptoServiceProvider())
                    {
                        rng.GetBytes(keyBytes);
                    }

                    File.WriteAllBytes(KeyFilePath, keyBytes);
                    //making key


                    keyBytes = File.ReadAllBytes(KeyFilePath);

                    Byte[] encryptedBytes = new Byte[inputBytes.Length];

                    for (int i = 0; i < inputBytes.Length; i++)
                    {
                        encryptedBytes[i] = (Byte)(inputBytes[i] ^ keyBytes[i % keyBytes.Length]);
                    }

                    MessageBox.Show("VERNOM SUCCESSFUL");
                    return encryptedBytes;
                }
                else if (!cbMkKey.Checked)
                {
                    KeyFilePath = sKeyFilePath;
                    Byte[] keyBytes = new Byte[inputBytes.Length];

                    keyBytes = File.ReadAllBytes(KeyFilePath);

                    Byte[] encryptedBytes = new Byte[inputBytes.Length];

                    for (int i = 0; i < inputBytes.Length; i++)
                    {
                        encryptedBytes[i] = (Byte)(inputBytes[i] ^ keyBytes[i % keyBytes.Length]);
                    }

                    MessageBox.Show("VERNOM SUCCESSFUL");
                    return encryptedBytes;
                }
                MessageBox.Show("VERNOM UNSUCCESSFUL");
                return bPlainText;
        }

        public Byte[] Decrypt_Vernom(Byte[] bCipherText)
        {
                string KeyFilePath = tbKeyPath.Text;
                Byte[] inputBytes = bCipherText;
                Byte[] keyBytes = File.ReadAllBytes(KeyFilePath);

                Byte[] decryptedBytes = new Byte[inputBytes.Length];

                for (int i = 0; i < inputBytes.Length; i++)
                {
                    decryptedBytes[i] = (Byte)(inputBytes[i] ^ keyBytes[i % keyBytes.Length]);
                }

                MessageBox.Show("VERNOM SUCCESSFUL");
                return decryptedBytes;
        }
        //====Vernom


        //====Unique
        public Byte[] Encrypt_Unique(Byte[] bPlainText, string sKey)
        {
            //Will encrypt data using Homebrew Cypher
                Byte[] inputBytes = bPlainText;
                string sUniqueKey = sKey;

            if (sUniqueKey.Contains('-') && sKey.Length == 5)
            {
                string[] key = sUniqueKey.Split('-');
                Byte iAdd = (Byte)int.Parse(key[0]);
                int iCeas = (Byte)int.Parse(key[1]);

                Byte[] ciphertextBytes = new Byte[inputBytes.Length];
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    ciphertextBytes[i] = (Byte)((inputBytes[i] + iAdd) % 256);
                }

                for (int i = 0; i < ciphertextBytes.Length; i++)
                {
                    ciphertextBytes[i] = (Byte)((ciphertextBytes[i] + iCeas));
                }
                MessageBox.Show("UNIQUE SUCCESSFUL");
                return ciphertextBytes;
            }
            else 
            {
                MessageBox.Show("UNIQUE UNSUCCESSFUL");
                return bPlainText;
            }
        }

        public Byte[] Decrypt_Unique(Byte[] bCipherText, string sKey)
        {

            Byte[] inputBytes = bCipherText;
            string sUniqueKey = sKey;
            string[] key = sUniqueKey.Split('-');
            Byte iAdd = (Byte)int.Parse(key[0]);
            int iCeas = (Byte)int.Parse(key[1]);
            Byte[] plaintextBytes = new Byte[inputBytes.Length];

            for (int i = 0; i < inputBytes.Length; i++)
            {
                Byte b = inputBytes[i];
                int temp = b - iCeas;
                if (temp < 0)
                {
                    temp += 256;
                }
                inputBytes[i] = (Byte)temp;
            }

            for (int i = 0; i < inputBytes.Length; i++)
            {
                plaintextBytes[i] = (Byte)((inputBytes[i] + 256 - iAdd) % 256);
            }

            MessageBox.Show("UNIQUE SUCCESSFUL");
            return plaintextBytes;
        }
        //====Unique
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

                rtbDataView.AppendText("File: " + sFilePath + " selected for cryption.\r\n\n");
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
            if (bLoca == true && bPass == true && (cbTransposition.Checked || cbUnique.Checked || (cbVernom.Checked && bKey == true) || cbViganere.Checked))
            {
                byte[] bytesEncrypted = Encoding.ASCII.GetBytes("empty");
                byte[] bFile = File.ReadAllBytes(sFilePath);
                string sFile = Convert.ToBase64String(bFile);

                if (cbTransposition.Checked)
                {
                    bytesEncrypted = Tran_Encipher(bFile, sEncKey);
                    bFile = bytesEncrypted;
                }

                if (cbViganere.Checked)
                {
                    bytesEncrypted = Vig_Encipher(bFile, sEncKey);
                    bFile = bytesEncrypted;
                }

                if (cbVernom.Checked)
                {
                    bytesEncrypted = Encrypt_Vernom(bFile);
                    bFile = bytesEncrypted;
                }

                if (cbUnique.Checked)
                {
                    bytesEncrypted = Encrypt_Unique(bFile, sEncKey);
                    bFile = bytesEncrypted;
                }

                File.WriteAllBytes(sFilePath + ".crypt", bytesEncrypted);

                bPass = false;
                bLoca = false;
                bKey = false;

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
            else if (!bKey)
            {
                MessageBox.Show("SELECT A KEY FILE");
                bKey = false;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            rtbDataView.Clear();
            string sUpdatedFilePath = sFilePath.Remove(sFilePath.Length - 6, 6);
            string sCheckCrypt = sFilePath.Remove(0, sFilePath.Length - 6);

            if (bLoca == true && bPass == true && sCheckCrypt == ".crypt" && (cbTransposition.Checked || cbUnique.Checked || (cbVernom.Checked && bKey == true) || cbViganere.Checked))
            {
                byte[] bytesDecrypted = Encoding.ASCII.GetBytes("empty");
                byte[] bFile = File.ReadAllBytes(sFilePath);
                string sFile = Convert.ToBase64String(bFile);

                if (cbUnique.Checked)
                {
                    bytesDecrypted = Decrypt_Unique(bFile, sEncKey);
                    bFile = bytesDecrypted;
                }

                if (cbVernom.Checked)
                {
                    bytesDecrypted = Decrypt_Vernom(bFile);
                    bFile = bytesDecrypted;
                }

                if (cbViganere.Checked)
                {
                    bytesDecrypted = Vig_Decipher(bFile, sEncKey);
                    bFile = bytesDecrypted;
                }

                if (cbTransposition.Checked)
                {
                    bytesDecrypted = Tran_Decipher(bFile, sEncKey);
                }

                File.WriteAllBytes(sUpdatedFilePath, bytesDecrypted);

                bPass = false;
                bLoca = false;
                bKey = false;

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
            else if (!bKey)
            {
                MessageBox.Show("SELECT A KEY FILE");
                bKey = false;
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

        private void cbMkKey_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMkKey.Checked)
            {
                btnKeySelect.Enabled = false;

                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        // Code to write the stream goes here.
                        myStream.Close();
                        bKey = true;
                    }
                }

                sKeyFilePath = saveFileDialog1.FileName;
                tbKeyPath.Text = sKeyFilePath;

            }
            else
            {
                btnKeySelect.Enabled = true;;
            }
        }

        private void btnKeySelect_Click(object sender, EventArgs e)
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

                sKeyFilePath = openFileDialogSelector.FileName;
                tbKeyPath.Text = openFileDialogSelector.FileName;
                bKey = true;
            }
        }
        //===System
    }
}
