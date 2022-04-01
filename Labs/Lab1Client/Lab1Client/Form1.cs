using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var x = this.x.Text;
            var y = this.y.Text;

            var formData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("x", x),
                new KeyValuePair<string, string>("y", y)
            });

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61611/");
            var response = await client.PostAsync("task4", formData);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                this.result.Text = result;
            }
        }
    }
}
