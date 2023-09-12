using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pixabay
{
    public partial class Image_UserControl : UserControl
    {
        private int _indexImage = 0;
        private string _nameImg;

        public Image_UserControl() => InitializeComponent();
        public Image_UserControl(string url, string nameImage) : this()
        {
            this.pictureBox1.ImageLocation = url;
            _nameImg = nameImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.DownloadFile(this.pictureBox1.ImageLocation, @"C:\Users\elons\Downloads\" + $"{_nameImg}.jpg");
        }
    }
}
