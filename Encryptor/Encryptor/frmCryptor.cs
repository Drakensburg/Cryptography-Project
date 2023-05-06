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

        public static int GetAlpha(char c)
        {
            // Convert the character to uppercase to simplify the calculation
            char upperCaseChar = Char.ToUpper(c);

            // Calculate the alphabetical position based on the ASCII code of the character
            int position = upperCaseChar - 'A';

            // Return the alphabetical position
            return position;
        }

        public char GetAlphaChar(int position)
        {
            // Subtract 1 from the input position to account for the fact that the alphabet is 0-indexed
            // and the input is 1-indexed.
            int alphabetIndex = position;

            // Check if the input position is within the bounds of the alphabet.
            if (alphabetIndex >= 0 && alphabetIndex < 26)
            {
                // Convert the alphabet index to a character using ASCII encoding.
                return (char)('A' + alphabetIndex);
            }
            else
            {
                // Return a null character if the input position is out of bounds.
                return '\0';
            }
        }


        public void Encrypt_Vernom()
        {
            //Will encrypt data using Vernom Cypher

            //text
            sEncKey = tbKey.Text;
            string pText = rtbDataView.Text;
            StringBuilder sbPtext = new StringBuilder(pText);
            StringBuilder sbKey = new StringBuilder(sEncKey);
            int[] iPtext = new int[sEncKey.Length];
            int[] iKey = new int[sEncKey.Length];
            char[] cText = new char[sEncKey.Length];
            int[] cipher = new int[sEncKey.Length];

            //When key is not long enough
            if(sEncKey.Length != pText.Length)
            {
                MessageBox.Show("Key must be the same legnth as plaintext!");
                return;
            }

            //converting to int
            for(int i = 0; i < sEncKey.Length; i++)
            {
                iPtext[i] = GetAlpha(sbPtext[i]);
                iKey[i] = GetAlpha(sbKey[i]);
                cipher[i] = iPtext[i] ^ iKey[i];

                if (cipher[i] > 26)
                {
                    cipher[i] = cipher[i] - 26;
                }

                cText[i] = GetAlphaChar(cipher[i]);
            }
            //test mess
            MessageBox.Show(string.Join(Environment.NewLine, cText));
            //text
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
            if (cbVernom.Checked)
            {
                Encrypt_Vernom();
            }
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
