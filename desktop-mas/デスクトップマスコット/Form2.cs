using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace デスクトップマスコット
{
    public partial class Form2 : Form
    {
        string path;
        private int mouseX;
        private int mouseY;
        
        

        public Form2()
        {

            InitializeComponent();
            //背景透過
            this.TransparencyKey = BackColor;
            //手前表示
            this.TopMost = !this.TopMost;
        }


        public void Form2_Load(object sender, EventArgs e)
        {
            string stCurrentDir = System.IO.Directory.GetCurrentDirectory();
            path = stCurrentDir+@"\mi\mi.png";
            show(path);
        }

        private void show(string path)
        {
            //フォームの境界線をなくす
            this.FormBorderStyle = FormBorderStyle.None;
            //フォームのサイズ変更
            size_change(@path);
            //背景画像を指定する
            this.BackgroundImage = Image.FromFile(@path);
        }

        //ウィンドウの大きさを画像の大きさに変更
        private void size_change(string path)
        {
            //元画像の縦横サイズを調べる
            System.Drawing.Bitmap bmpSrc = new System.Drawing.Bitmap(@path);
            int width = bmpSrc.Width;
            int height = bmpSrc.Height;
            //ウィンドウのサイズを変更
            this.Size = new Size(width, height);
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - mouseX;
                this.Top += e.Y - mouseY;
            }
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mouseX = e.X;
                this.mouseY = e.Y;
            }
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
