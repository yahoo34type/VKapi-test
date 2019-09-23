using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using xNet;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.IO;

namespace Lab1
{
    public class CRUD
    {
        static private string token;
        static private string fname;
        static private string lname;
        static public string Token { get { return token; } set { token = value; } }
        static public string Fname { get { return fname; } set { fname = value; } }
        static public string Lname { get { return lname; } set { lname = value; } }
        static private string uid;
        static public string Uid { get { return uid; } set { uid = value; Mform.button2.Text = value; } }
        static private AuthForm authForm;
        static private VkApi api;
        static public MainForm Mform;
        public static string Crypt(string text)
        {
            return Convert.ToBase64String(
                ProtectedData.Protect(
                    Encoding.Unicode.GetBytes(text), null, DataProtectionScope.CurrentUser));
        }

        public static string Decrypt(string text)
        {
            return Encoding.Unicode.GetString(
                ProtectedData.Unprotect(
                     Convert.FromBase64String(text), null, DataProtectionScope.CurrentUser));
        }
        static public void Authenticate()
        {
            authForm = new AuthForm();
            authForm.ShowDialog();
            if (authForm.Token != null)
            {
                token = authForm.Token;
                Uid = authForm.User;
                api = new VkApi();
                api.Authorize(new ApiAuthParams() { AccessToken = token });
                VkNet.Model.RequestParams.AccountSaveProfileInfoParams s = api.Account.GetProfileInfo();
                Fname = s.FirstName;
                Lname = s.LastName;
            }
        }
        static public void FormClose()
        {
            if (token != null)
            {
                string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                if (!Directory.Exists(roaming + "/VKTest"))
                    Directory.CreateDirectory(roaming + "/VKTest");
                string specificFolder = roaming + "/VKTest/token";
                StreamWriter writer = new StreamWriter(specificFolder);
                writer.WriteLine(Crypt(token));
                writer.Close();
            }
            else
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/VKTest/token";
                if (File.Exists(path))
                    File.Delete(path);
            }
        }
        static public void FormLoad()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/VKTest/token";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                try
                {
                    token = Decrypt(sr.ReadLine());
                    api = new VkApi();
                    api.Authorize(new ApiAuthParams() { AccessToken = token });
                    if (!api.IsAuthorized)
                    {
                        MessageBox.Show("Закончилось время авторизации, авторизуйтесь снова");
                        Token = null;
                    }
                    else
                    {
                        VkNet.Model.RequestParams.AccountSaveProfileInfoParams s = api.Account.GetProfileInfo();
                        Fname = s.FirstName;
                        Lname = s.LastName;
                        Uid = api.Users.Get(new List<long> { }).FirstOrDefault().Id.ToString();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка авторизации, авторизуйтесь снова");
                    Token = null;
                }
                sr.Close();
            }
        }
        static public void PostShit()
        {
            api.Wall.Post(new VkNet.Model.RequestParams.WallPostParams { Message = "Текст сообщения!", OwnerId = -186834007 });
        }
        static async public void WallDisplay()
        {
            Mform.listView1.Items.Clear();
            WallGetObject WGO = await api.Wall.GetAsync(new VkNet.Model.RequestParams.WallGetParams { OwnerId = -186834007, Extended = true });
            /*foreach (User user in WGO.Profiles)
            {
                MessageBox.Show(user.Id.ToString());
            }*/
            foreach (VkNet.Model.Attachments.Post post in WGO.WallPosts)
            {
                User u = (WGO.Profiles.ToList()).Find(x => x.Id == post.FromId);
                // № автор текст дата
                ListViewItem item = new ListViewItem(new[]
                        {
                        u.FirstName + " " + u.LastName,
                        post.Text,
                        post.Date.ToString()
                    })
                { Name = u.Id.ToString(), Tag = post.Id};
                Mform.listView1.Items.Add(item);
                //Mform.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        static async public void Create(CreateUpdate sender)
        {
            long x = await api.Wall.PostAsync(new VkNet.Model.RequestParams.WallPostParams { Message = sender.richTextBox1.Text, OwnerId = -186834007 });
            WallDisplay();
            sender.Dispose();
        }
        static async public void Update(CreateUpdate sender)
        {
            try
            {
                bool x = await api.Wall.EditAsync(new VkNet.Model.RequestParams.WallEditParams { PostId = Int64.Parse(Mform.listView1.SelectedItems[0].Tag.ToString()), Message = sender.richTextBox1.Text, OwnerId = -186834007 });
            }
            catch { }
            WallDisplay();
            sender.Dispose();
        }
        static async public void Delete()
        {
            bool x = await api.Wall.DeleteAsync(ownerId: -186834007, postId: Int64.Parse(Mform.listView1.SelectedItems[0].Tag.ToString()));
            WallDisplay();
        }
    }
}
