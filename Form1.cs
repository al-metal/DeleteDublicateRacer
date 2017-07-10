using Bike18;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeleteDublicateRacer
{
    public partial class Form1 : Form
    {
        Thread forms;

        nethouse nethouse = new nethouse();
        httpRequest webRequest = new httpRequest();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.login = tbLogin.Text;
            Properties.Settings.Default.password = tbPassword.Text;
            Properties.Settings.Default.Save();

            Thread tabl = new Thread(() => DeleteTovar());
            forms = tabl;
            forms.IsBackground = true;
            forms.Start();
        }

        private void DeleteTovar()
        {
            CookieContainer cookie = nethouse.CookieNethouse(tbLogin.Text, tbPassword.Text);
            if (cookie.Count == 1)
            {
                MessageBox.Show("Логин или пароль для сайта введены не верно", "Ошибка логина/пароля");
                return;
            }

            string otv = webRequest.getRequest("https://bike18.ru/products/category/katalog-zapchastey-racer");
            MatchCollection razdel = new Regex("(?<=</div></a><div class=\"category-capt-txt -text-center\"><a href=\").*?(?=\" class=\"blue\">)").Matches(otv);

            for(int i = 0; razdel.Count > i; i++)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbLogin.Text = Properties.Settings.Default.login;
            tbPassword.Text = Properties.Settings.Default.password;
        }
    }
}
