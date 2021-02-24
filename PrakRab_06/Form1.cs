using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace PrakRab_06
{
    public partial class Form1 : Form
    {
        CaesarCipher C1;
        public Form1()
        {
            InitializeComponent();
            C1 = new CaesarCipher ();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int secretKey1 = 29;
            int secretKey2 = 7;
            int secretKey3 = 14;

            var encryptedText1 = C1.Encrypt(textBox1.Text, secretKey1);
            var encryptedText2 = C1.Encrypt(textBox1.Text, secretKey2);
            var encryptedText3 = C1.Encrypt(textBox1.Text, secretKey3);

            label3.Text = ("Вариант 1: " + encryptedText1);
            label4.Text = ("Вариант 2: " + encryptedText2);
            label5.Text = ("Вариант 3: " + encryptedText3);
        }
        public class CaesarCipher
        {
            const string ABC = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            private string CodeEncode(string text, int k)
            {
                var fullABC = ABC + ABC.ToLower();
                var letterQty = fullABC.Length;
                var retVal = "";
                for (int i = 0; i < text.Length; i++)
                {
                    var c = text[i];
                    var index = fullABC.IndexOf(c);
                    if (index < 0)
                    {
                        retVal += c.ToString();
                    }
                    else
                    {
                        var codeIndex = (letterQty + index + k) % letterQty;
                        retVal += fullABC[codeIndex];
                    }
                }
                return retVal;
            }
            public string Encrypt(string plainMessage, int key) => CodeEncode(plainMessage, key);
            public string Decrypt(string encryptedMessage, int key) => CodeEncode(encryptedMessage, -key);
        }
    }
}

