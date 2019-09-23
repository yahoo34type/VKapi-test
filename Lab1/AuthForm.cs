using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using xNet;
using Newtonsoft.Json;
using EO.Base;
using EO.WebBrowser;
using EO.WinForm;


namespace Lab1
{
    public partial class AuthForm : Form 
    {
        private string token; 
        private string user;
        public string Token { get { return token; } set { token = value; } }
        public string User { get { return user; } set { user = value; ((MainForm)this.Parent).button2.Text = value; } }
        public AuthForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            
        }
        public void AuthForm_DeleteAuthData()
        {
            webView1.Engine.Stop(deleteCache: true);
            webView1.Engine.Start();
        }
        private void AuthForm_Load(object sender, EventArgs e)
        {
            
            webControl1.WebView = webView1;
            webControl1.WebView.Url = "https://oauth.vk.com/authorize?client_id=7144699&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=wall&response_type=token&v=5.52";
        }
        
        private void webView1_UrlChanged(object sender, EventArgs e)
        {
            if (webControl1.WebView.Url.ToString().Contains("access_token"))
            {
                char[] Symbols = { '=', '&' };
                string[] URL = webControl1.WebView.Url.ToString().Split(Symbols);
                token = URL[1];
                user = URL[5];
                this.Visible = false;
                this.AuthForm_DeleteAuthData();
            }
        }
    }
}
