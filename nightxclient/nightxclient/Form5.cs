using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace nightxclient
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        string dy;
        string dy2 = "";
        string folderInfo;
        private void Form5_Load(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Bir dosya seçiniz";
            openFileDialog1.FileName = "Dosya Seç";
            openFileDialog1.InitialDirectory = @"C:";
            openFileDialog1.Filter = "dff Dosyası |*.dff";
            openFileDialog2.Title = "Bir dosya seçiniz";
            openFileDialog2.FileName = "Dosya Seç";
            openFileDialog2.InitialDirectory = @"C:";
            openFileDialog2.Filter = "txd Dosyası |*.txd";
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(" https://wiki.multitheftauto.com/wiki/Vehicle_IDs");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                guna2TextBox2.Text = openFileDialog1.SafeFileName;

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                guna2TextBox3.Text = openFileDialog2.SafeFileName;

            }
        }
        void KlasorOlusturmaIslemi()
        {
            folderBrowserDialog1.ShowDialog();
            folderInfo = folderBrowserDialog1.SelectedPath + "\\" + guna2TextBox1.Text;
            Directory.CreateDirectory(folderInfo);
            guna2TextBox6.Text = folderBrowserDialog1.SelectedPath;
        }
        void ClientOlusturma()
        {
            string txd = guna2TextBox3.Text;
            string dff = guna2TextBox2.Text;
            string id = guna2TextBox5.Text;
            string client = "function Arac()\nlocal txd = engineLoadTXD ('" + txd + "')\nengineImportTXD(txd," + id + ")\n local dff = engineLoadDFF('" + dff + "'," + id + ")\nengineReplaceModel(dff," + id + ")\nend\naddEventHandler('onClientResourceStart',getResourceRootElement(getThisResource()),Arac)";
            richTextBox2.Text = client;
        }
        void MetaOlusturma()
        {
            string txd = guna2TextBox3.Text;
            string dff = guna2TextBox2.Text;
            string meta = "<meta>\n    <info author='NightX' name='Arac' />\n	   <script src='client.lua' type='client' />\n	   <file src='" + txd + "' />\n	   <file src='" + dff + "' />\n</meta>";
            richTextBox1.Text = meta;
        }
        void butonkaydet()
        {
            dy2 = guna2TextBox1.Text;
            dy = folderInfo + @"\meta.xml";
            FileStream fs = File.Create(dy);
            fs.Close();
            StreamWriter sw = new StreamWriter(dy);
            sw.WriteLine(richTextBox1.Text);
            sw.Close();
        }
        void butonkaydet2()
        {
            dy2 = guna2TextBox1.Text;
            dy = folderInfo + @"\client.lua";
            FileStream fs = File.Create(dy);
            fs.Close();
            StreamWriter sw = new StreamWriter(dy);
            sw.WriteLine(richTextBox2.Text);
            sw.Close();
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox5.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "")
            {
                MessageBox.Show("Boş alanları doldurun!", "NightX", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                KlasorOlusturmaIslemi();
                ClientOlusturma();
                MetaOlusturma();
                butonkaydet();
                butonkaydet2();
            }
        }

        private void guna2TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
