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
        Cezar Me = new Cezar();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = Me.Codeс(textBox1.Text, key);
        }

        class Clent
        {
            string le;

            public Clent(string m)
            {
                le = m;
            }

            public string Repl(string m, int key)
            {
                int pos = le.IndexOf(m);
                if (pos == -1) return "";
                pos = (pos + key) % le.Length;
                if (pos < 0) pos += le.Length;
                return le.Substring(pos, 1);
            }
        }

        class Cezar : System.Collections.Generic.List<Clent>
        {
            public Cezar()
            {
                this.Add(new Clent("abcdefghijklmnopqrstuvwxyz"));
                this.Add(new Clent("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
                this.Add(new Clent("абвгдеёжзийклмнопрстуфхцчшщъыьэюя"));
                this.Add(new Clent("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"));
                this.Add(new Clent("0123456789"));
                this.Add(new Clent("!\"#$%^&*()+=-_'?.,|/`~№:;@[]{}"));
            }

            public string Codeс(string m, int key)
            {
                string res = "", tmp = "";
                for (int i = 0; i < m.Length; i++)
                {
                    foreach (Clent v in this)
                    {
                        tmp = v.Repl(m.Substring(i, 1), key);
                        if (tmp != "")
                        {
                            res += tmp;
                            break;
                        }
                    }
                    if (tmp == "") res += m.Substring(i, 1);
                }
                return res;
            }
        }
    }
}

