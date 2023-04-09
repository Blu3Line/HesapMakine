using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HesapMakine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach (Control control in tableLayoutPanel1.Controls)//layouttaki kontrolleri geziyor
            {
                if (control is Button) // Eğer kontrol bir buton ise
                {
                    Button button = (Button)control; // Buton nesnesi olarak tanımla
                    button.BackColor = tableLayoutPanel1.BackColor; // Butonun arka plan rengini TableLayoutPanel ile aynı renk yap
                    button.FlatStyle = FlatStyle.Flat;//saçma buton çizgisi vardı onu engelliyor
                    button.ForeColor = Color.White;
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)//form resizeable olayını yapmaya çalıştım ama bozuk
        {
            this.ClientSize = new Size(430, 750);//TODO: burası hardcoded sonra dinamik olsun 
        }

        private void button_Click(object sender, EventArgs e)
        {

        }

    }
}
