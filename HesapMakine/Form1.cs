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
        bool TextBoxSayıBulunduruyorMu;
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
            TextBoxSayıBulunduruyorMu = false;
        }


        private void NumberButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string rakamText = btn.Text;
            if(btn.Text == "0"  && !TextBoxSayıBulunduruyorMu) {//0 tuşuna basıp başka bir tuşa basınca execute olur ve ignorelar.
                return;
            }
            else if (!TextBoxSayıBulunduruyorMu)
            {
                textBox1.Text = rakamText;
                TextBoxSayıBulunduruyorMu = true;
            }
            else
            {
                textBox1.Text += rakamText;
            }

        }

        private void OperatorButtonClick(object sender, EventArgs e)
        {
            if (TextBoxSayıBulunduruyorMu) {//
                Button btn = (Button)(sender);
                sayi1 = Convert.ToDouble(textBox1.Text);
                Operator = btn.Text;
                TextBoxSayıBulunduruyorMu = false;
            }
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
            TextBoxSayıBulunduruyorMu = true;
        }

        private void ClearButtonClick(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            Operator = "";
            TextBoxSayıBulunduruyorMu = false;
            sayi1 = 0; sayi2 = 0;//sayılar temizlensin.
        }

        private void DelButtonClick(object sender, EventArgs e)
        {
            if(textBox1.Text != "0" && textBox1.Text.Length > 1)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
            else
            {
                textBox1.Text = "0";
                TextBoxSayıBulunduruyorMu = false;
            }

        }

        private void NoktaButtonClick(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("."))//zaten nokta olmasın
            {
                textBox1.Text += ".";
                TextBoxSayıBulunduruyorMu = true;
            }

        }



    }
}
