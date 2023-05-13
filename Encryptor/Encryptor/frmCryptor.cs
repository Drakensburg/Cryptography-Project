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
        

        //===Cryptography
        static void Crypt_Transposition()
        {
            //Will encrypt data using Keyed-Transposition Cypher
        }

        static void Crypt_Viganere()
        {
            //Will encrypt data using Viganere Cypher
        }




        public void Encrypt_Vernom()
        {
            //Will encrypt data using Vernom Cypher
            if (rtbDataView.Text == "")
            {
                //file
                if (tbFPath.Text == "")
                {
                    MessageBox.Show("Please select a file to encrypt!");
                    return;
                }
                string path = tbFPath.Text;
                string KeyFilePath = "";
                byte[] inputBytes = File.ReadAllBytes(path);
                //make keyfile
                if (cbMkKey.Checked==true)
                {
                    //making key
                    KeyFilePath = tbKeyPath.Text;
                    byte[] keyBytes = new byte[inputBytes.Length];
                    using (var rng = new RNGCryptoServiceProvider())
                    {
                        rng.GetBytes(keyBytes);
                    }

                    File.WriteAllBytes(KeyFilePath, keyBytes);
                    //making key


                    keyBytes = File.ReadAllBytes(KeyFilePath);

                    byte[] encryptedBytes = new byte[inputBytes.Length];

                    for (int i = 0; i < inputBytes.Length; i++)
                    {
                        encryptedBytes[i] = (byte)(inputBytes[i] ^ keyBytes[i % keyBytes.Length]);
                    }
                    File.WriteAllBytes(path, encryptedBytes);
                    MessageBox.Show("File is encrypted!");
                }
                else if (!cbMkKey.Checked)
                {
                    if (tbKeyPath.Text == "")
                    {
                        MessageBox.Show("Please select a key file for encryption!");
                        return;
                    }
                    KeyFilePath = sKeyFilePath;
                    byte[] keyBytes = new byte[inputBytes.Length];

                    keyBytes = File.ReadAllBytes(KeyFilePath);

                    byte[] encryptedBytes = new byte[inputBytes.Length];

                    for (int i = 0; i < inputBytes.Length; i++)
                    {
                        encryptedBytes[i] = (byte)(inputBytes[i] ^ keyBytes[i % keyBytes.Length]);
                    }
                    File.WriteAllBytes(path, encryptedBytes);
                    MessageBox.Show("File is encrypted!");
                }
                
            
                
            }
            else if (rtbDataView.Text != "")
            {
                //text
                sEncKey = tbKey.Text;
                string pText = rtbDataView.Text;
                // Convert the plaintext and key to byte arrays
                byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(pText);
                byte[] tkeyBytes = System.Text.Encoding.UTF8.GetBytes(sEncKey);

                // Make sure the key length matches the plaintext length
                if (tkeyBytes.Length != plaintextBytes.Length)
                {
                    MessageBox.Show("Key length must match plaintext length");
                    return;
                }


                // Perform the encryption using the Vernam cipher
                byte[] ciphertextBytes = new byte[plaintextBytes.Length];
                for (int i = 0; i < plaintextBytes.Length; i++)
                {
                    ciphertextBytes[i] = (byte)(plaintextBytes[i] ^ tkeyBytes[i]);
                }

                // Convert the ciphertext to a printable string
                string ciphertext = "";
                foreach (byte b in ciphertextBytes)
                {
                    ciphertext += (char)(b + 32); // Add 32 to make the character printable
                }
                rtbDataView.Text = ciphertext;
                MessageBox.Show("Message encrypted");
            }
            //test mess

            //text
        }
        public void Decrypt_Vernom()
        {
            //file
            if(rtbDataView.Text == "")
            {

                string path = tbFPath.Text;
                string KeyFilePath = tbKeyPath.Text;
                byte[] inputBytes = File.ReadAllBytes(path);
                byte[] keyBytes = File.ReadAllBytes(KeyFilePath);

                byte[] decryptedBytes = new byte[inputBytes.Length];

                for (int i = 0; i < inputBytes.Length; i++)
                {
                    decryptedBytes[i] = (byte)(inputBytes[i] ^ keyBytes[i % keyBytes.Length]);
                }

                File.WriteAllBytes(path, decryptedBytes);
                MessageBox.Show("Message decrypted");
            }
            //text
            else if(rtbDataView.Text != "") 
            {
                // Convert the ciphertext and key to byte arrays
                string ciphertext = rtbDataView.Text;
                byte[] ciphertextBytes = new byte[ciphertext.Length];
                for (int i = 0; i < ciphertext.Length; i++)
                {
                    ciphertextBytes[i] = (byte)(ciphertext[i] - 32); // Subtract 32 to undo the addition in the encryption method
                }
                byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(sEncKey);

                // Make sure the key length matches the ciphertext length
                if (keyBytes.Length != ciphertextBytes.Length)
                    throw new ArgumentException("Key length must match ciphertext length");

                // Perform the decryption using the Vernam cipher
                byte[] plaintextBytes = new byte[ciphertextBytes.Length];
                for (int i = 0; i < ciphertextBytes.Length; i++)
                {
                    plaintextBytes[i] = (byte)(ciphertextBytes[i] ^ keyBytes[i]);
                }

                // Convert the plaintext byte array to a string
                string plaintext = System.Text.Encoding.UTF8.GetString(plaintextBytes);
                rtbDataView.Text = plaintext;
                MessageBox.Show("Message decrypted");
            }
        }

        public void Encrypt_Unique()
        {
            //Will encrypt data using Homebrew Cypher




      

        // encrypts a byte array using modular addition and subtraction
       
            
        

        //text
            sEncKey = tbKey.Text;
            string[] key =sEncKey.Split('-');
            byte iAdd = (byte) int.Parse(key[0]);
            int iCeas = (byte)int.Parse(key[1]);
            string pText = rtbDataView.Text;
            // Convert the plaintext and key to byte arrays
            byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(pText);
            

            // Perform the encryption using modular 
            byte[] ciphertextBytes = new byte[plaintextBytes.Length];
            for (int i = 0; i < plaintextBytes.Length; i++)
            {
                ciphertextBytes[i] = (byte)((plaintextBytes[i] + iAdd) % 256);
                
            }

            for (int i = 0; i < ciphertextBytes.Length; i++)
            {

                ciphertextBytes[i] = (byte)((ciphertextBytes[i] + iCeas));
            }

            // Convert the ciphertext to a printable string
            /*string ciphertext = "";
           foreach (byte b in ciphertextBytes)
           {
               ciphertext += (char)(b + 32); // Add 32 to make the character printable
           }*/
            rtbDataView.Text = Convert.ToBase64String(ciphertextBytes);

            MessageBox.Show("Message encrypted");
        }


        public void Decrypt_Unique()
        {

            sEncKey = tbKey.Text;
            string[] key = sEncKey.Split('-');
            byte iAdd = (byte)int.Parse(key[0]);
            int iCeas = (byte)int.Parse(key[1]);
            string cText = rtbDataView.Text;
            byte[] ciphertextBytes = Convert.FromBase64String(cText);
            byte[] plaintextBytes = new byte[ciphertextBytes.Length];
            byte[] ceasarBytes = new byte[ciphertextBytes.Length];
           
            //text

            for (int i = 0; i < ciphertextBytes.Length; i++)
            {
                byte b = ciphertextBytes[i];
                int temp = b - iCeas;
                if (temp < 0)
                {
                    temp += 256;
                }
                ciphertextBytes[i] = (byte)temp;
                
            }

            for (int i = 0; i < ciphertextBytes.Length; i++)
            {
                plaintextBytes[i] = (byte)((ciphertextBytes[i] + 256 - iAdd )  % 256);
                
            }
            rtbDataView.Text = Encoding.UTF8.GetString(plaintextBytes);
            MessageBox.Show("Message decrypted");
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
            if (cbVernom.Checked)
            {
                Encrypt_Vernom();
            }
            else if (cbUnique.Checked)
            {
                Encrypt_Unique();
            }
            else
            {
                MessageBox.Show("Please select an encryption method!");
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            //Will decrypt data using selected methods
            if (cbVernom.Checked)
            {
                Decrypt_Vernom();
            }
            else if (cbUnique.Checked)
            {
                Decrypt_Unique();
            }
            else
            {
                MessageBox.Show("Please select an encryption method!");
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

        private void rtbDataView_TextChanged(object sender, EventArgs e)
        {

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
            }
        }




        //===System
    }
}
