using HtmlAgilityPack;
using System.Net;
using System.Text.Json;

namespace Pixabay
{
    public partial class Form1 : Form
    {
        private int index = 0;
        private int x = 10;
        private int y = 10;
        private JsonFile json;
        public Form1()
        {
            InitializeComponent();

            WebClient web = new WebClient();
            json = JsonSerializer.Deserialize<JsonFile>(web.DownloadString("https://pixabay.com/api/?key=39338092-c0cdc00edf208712991837a09&q=yellow+flowers&image_type=photo"));
            y += this.menuStrip1.Height;
            ViewImage();
        }
        private void ViewImage()
        {
            foreach (var item in json.hits)
            {
                Image_UserControl img = new Image_UserControl(item.webformatURL, item.tags.Split(", ")[0]);
                if (x + img.Width + 10 > this.Width)
                {
                    y += img.Height + 10;
                    x = 10;
                }
                img.Name = $"image_{++index}";
                img.Location = new System.Drawing.Point(x, y);
                x += img.Width + 10;
                this.Controls.Add(img);
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            x = 10;
            y = 10 + this.menuStrip1.Height;
            while (index != 0)
                this.Controls.RemoveByKey($"image_{index--}");
            if (this.toolStripTextBox1.Text != "")
            {
                foreach (var item in json.hits)
                    foreach (var item2 in item.tags.Split(", "))
                        if (item2 == this.toolStripTextBox1.Text)
                        {
                            Image_UserControl img = new Image_UserControl(item.webformatURL, item.tags.Split(", ")[0]);
                            if (x + img.Width + 10 > this.Width)
                            {
                                y += img.Height + 10;
                                x = 10;
                            }
                            img.Name = $"image_{++index}";
                            img.Location = new System.Drawing.Point(x, y);
                            x += img.Width + 10;
                            this.Controls.Add(img);
                        }
            }
            else
                ViewImage();
        }
    }
}