using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form1 : Form
    {
        Text_Value txt;
        int dark_light_select = 0;

        public Form1()
        {
            InitializeComponent();

            rtb_Text.BackColor = Color.Black;
            rtb_Text.ForeColor = Color.White;
            dark_light_select = 0;
        }

        private void miDark_Click(object sender, EventArgs e)
        {
            rtb_Text.BackColor = Color.Black;
            rtb_Text.ForeColor = Color.White;
            dark_light_select = 0;
        }

        private void miLight_Click(object sender, EventArgs e)
        {
            rtb_Text.BackColor = Color.White;
            rtb_Text.ForeColor = Color.Black;
            dark_light_select = 1;
        }

        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Новый текст"; // Default file name
            sfd.DefaultExt = ".txt"; // Default file extension
            sfd.Filter = "Text documents (.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txt = new Text_Value(sfd.FileName, new string[1]);
                txt.Save();
                rtb_Text.Text = "";
                this.Text = txt.FileName + " - Блокнот";
            };            
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            if (txt != null)
            {
                txt = new Text_Value(txt.FileName);
                txt.Text[0] = rtb_Text.Text;
                txt.Save();
                rtb_Text.Text = txt.Text[0];
                this.Text = txt.FileName + " - Блокнот";
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = "Новый текст"; // Default file name
                sfd.DefaultExt = ".txt"; // Default file extension
                sfd.Filter = "Text documents (.txt)|*.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    txt = new Text_Value(sfd.FileName);                    
                    txt.Text[0] = rtb_Text.Text;
                    txt.Save();
                    rtb_Text.Text = txt.Text[0];
                    this.Text = txt.FileName + " - Блокнот";
                };
            }
        }

        private void miSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (txt != null)
            {                
                sfd.FileName = txt.FileName; // Default file name                
            }
            else
            {               
                sfd.FileName = "Новый текст"; // Default file name                
            }
            sfd.DefaultExt = ".txt"; // Default file extension
            sfd.Filter = "Text documents (.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txt = new Text_Value(sfd.FileName);
                txt.Text[0] = rtb_Text.Text;
                txt.Save();
                rtb_Text.Text = txt.Text[0];
                this.Text = txt.FileName + " - Блокнот";
            };
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text documents (.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txt = new Text_Value(ofd.FileName);
                txt.Load();
                rtb_Text.Text = "";
                int count = 0;
                foreach (var item in txt.Text)
                {
                    count++;
                    if (count == txt.Text.Length)
                    {
                        rtb_Text.Text += item;
                    }
                    else
                    {
                        rtb_Text.Text += item + "\n";
                    }
                }
                this.Text = txt.FileName + " - Блокнот";
            }            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Вы хотите сохранить изменения?", "Сохранить изменения?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    if (txt != null)
                    {
                        txt = new Text_Value(txt.FileName);
                        txt.Text[0] = rtb_Text.Text;
                        txt.Save();
                        rtb_Text.Text = txt.Text[0];
                        this.Text = txt.FileName + " - Блокнот";
                    }
                    else
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.FileName = "Новый текст"; // Default file name
                        sfd.DefaultExt = ".txt"; // Default file extension
                        sfd.Filter = "Text documents (.txt)|*.txt";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            txt = new Text_Value(sfd.FileName);
                            txt.Text[0] = rtb_Text.Text;
                            txt.Save();
                            rtb_Text.Text = txt.Text[0];
                        };
                    }
                    break;
                default:
                    break;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("mail@sagitov.pro", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Вставка в формате текста внутри RichTextBox
        /// </summary>
        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Text);
            rtb_Text.Paste(myFormat);
        }
    }
}
