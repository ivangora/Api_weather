using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
namespace Weather_API
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.PerformClick();
        }
        public void con(string url, out Bitmap loadedBitmap) 
        {
            string T_url = "http://openweathermap.org/img/w/" + url + ".png";
            var request = WebRequest.Create(T_url);
            var respon = request.GetResponse();
            loadedBitmap = null;
            using (var responseStream = respon.GetResponseStream())
            {
                loadedBitmap = new Bitmap(responseStream);
            }
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = Convert.ToString(textBox1.Text);
                string url = "http://api.openweathermap.org/data/2.5/forecast/daily?q=" + name + "&units=metric&appid=70a0820f964d63980e10ea6b420a8d46&lang=ua";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string response;
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
                MainJSON wea = JsonConvert.DeserializeObject<MainJSON>(response);
                DateTime d = DateTime.Now;

                label30.Text = wea.city.name;
                label31.Text = d.ToString("ddd") + ",";
                label2.Text = Convert.ToString((int)wea.list[0].temp.day) + "°";
                label29.Text = wea.list[0].speed.ToString() + " км/г";
                label28.Text = wea.list[0].humidity.ToString() + " %";
                label32.Text = wea.list[0].weather[0].description.ToString();
                label27.Text = wea.list[0].clouds.ToString() + " %";

                Bitmap Bit;
                con(wea.list[0].weather[0].icon.ToString(), out Bit);

                pictureBox8.Image = (Image)Bit;
                ////////////////////////// http://openweathermap.org/img/w/01d.png

                label10.Text = Convert.ToString((int)wea.list[0].temp.max) + "°";
                label11.Text = Convert.ToString((int)wea.list[0].temp.min) + "°";
                pictureBox1.Image = (Image)Bit;

                label12.Text = Convert.ToString((int)wea.list[1].temp.min) + "°";
                label13.Text = Convert.ToString((int)wea.list[1].temp.max) + "°";
                con(wea.list[1].weather[0].icon.ToString(), out Bit);
                pictureBox2.Image = (Image)Bit;

                label14.Text = Convert.ToString((int)wea.list[2].temp.min) + "°";
                label15.Text = Convert.ToString((int)wea.list[2].temp.max) + "°";
                con(wea.list[2].weather[0].icon.ToString(), out Bit);
                pictureBox3.Image = (Image)Bit;

                label16.Text = Convert.ToString((int)wea.list[3].temp.min) + "°";
                label17.Text = Convert.ToString((int)wea.list[3].temp.max) + "°";
                con(wea.list[3].weather[0].icon.ToString(), out Bit);
                pictureBox4.Image = (Image)Bit;

                label18.Text = Convert.ToString((int)wea.list[4].temp.min) + "°";
                label19.Text = Convert.ToString((int)wea.list[4].temp.max) + "°";
                con(wea.list[4].weather[0].icon.ToString(), out Bit);
                pictureBox5.Image = (Image)Bit;

                label20.Text = Convert.ToString((int)wea.list[5].temp.min) + "°";
                label21.Text = Convert.ToString((int)wea.list[5].temp.max) + "°";
                con(wea.list[5].weather[0].icon.ToString(), out Bit);
                pictureBox6.Image = (Image)Bit;

                label22.Text = Convert.ToString((int)wea.list[6].temp.min) + "°";
                label23.Text = Convert.ToString((int)wea.list[6].temp.max) + "°";
                con(wea.list[6].weather[0].icon.ToString(), out Bit);
                pictureBox7.Image = (Image)Bit;


                //////////////////////////
                label3.Text = d.ToString("ddd");
                label4.Text = d.AddDays(1).ToString("ddd");
                label5.Text = d.AddDays(2).ToString("ddd");
                label6.Text = d.AddDays(3).ToString("ddd");
                label7.Text = d.AddDays(4).ToString("ddd");
                label8.Text = d.AddDays(5).ToString("ddd");
                label9.Text = d.AddDays(6).ToString("ddd");
            }
            catch
            { label1.Text = "ERROR"; Close(); }
              
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           button1.PerformClick();
        }

        
    }
}
