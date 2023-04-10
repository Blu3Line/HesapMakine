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
        double sayi1, sayi2;
        string Operator;
        bool ilkrakam;
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
            textBox1.BackColor = tableLayoutPanel1.BackColor;//textboxun arka planı panel layout ile aynı olsun
            textBox1.Text = "0";
            ilkrakam = true;
        }


        private void Form1_Resize(object sender, EventArgs e)//form resizeable olayını yapmaya çalıştım ama bozuk
        {
            this.ClientSize = new Size(430, 750);//TODO: burası hardcoded sonra dinamik olsun 
        }

        private void NumberButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string rakamText = btn.Text;
            if(btn.Text == "0"  && ilkrakam) {//0 ile sayılar başlanmasın TODO: potansiyel bug olabilir
                
            }
            else if (ilkrakam)
            {
                textBox1.Text = rakamText;
                ilkrakam = false;
            }
            else
            {
                textBox1.Text += rakamText;
            }

        }

        private void OperatorButtonClick(object sender, EventArgs e)
        {
            //TODO: operatore direkt basılmasın fixle potansiyel bug olabilir.
            
            Button btn = (Button)(sender);
            sayi1 = Convert.ToDouble(textBox1.Text);
            Operator = btn.Text;
            ilkrakam = true;
        }

        private void EsittirButtonClick(object sender, EventArgs e)//bürsürü bug var
        {
            sayi2 = Convert.ToDouble(textBox1.Text);
            double sonuc = 0;
            switch (Operator)
            {
                case "+":
                    sonuc = sayi1 + sayi2;
                    break;
                case "-":
                    sonuc = sayi1 - sayi2;
                    break;
                case "x":
                    sonuc = sayi1 * sayi2;
                    break;
                case "/":
                    sonuc = sayi1 / sayi2;
                    break;
                default:
                    break;
            }
            textBox1.Text = sonuc.ToString();
            ilkrakam = true;
        }

        private void ClearButtonClick(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            Operator = "";
            ilkrakam = true;
        }

        private void DelButtonClick(object sender, EventArgs e)//bunu test etmedin.
        {
            if(textBox1.Text != "0" && textBox1.Text.Length > 1)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
            else
            {
                textBox1.Text = "0";
                ilkrakam = true;
            }

        }

        private void NoktaButtonClick(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("."))//zaten nokta olmasın
            {
                textBox1.Text += ".";
            }

        }



    }
}
