using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lab1
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            CRUD.Mform = this;
            listView1.FullRowSelect = true;
        }
        private void enableButtons()
        {
            редактированиеToolStripMenuItem.Enabled = true;
            добавитьToolStripMenuItem.Enabled = true;
            редактироватьToolStripMenuItem.Enabled = true;
            удалитьToolStripMenuItem.Enabled = true;
            refreshBtn.Enabled = true;
        }
        private void disableButtons()
        {
            редактированиеToolStripMenuItem.Enabled = false;
            добавитьToolStripMenuItem.Enabled = false;
            редактироватьToolStripMenuItem.Enabled = false;
            удалитьToolStripMenuItem.Enabled = false;
            refreshBtn.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CRUD.Authenticate();
            if (CRUD.Token != null)
            {
                enableButtons();
                this.Text = "VK CRUD - " + CRUD.Fname + " " + CRUD.Lname;
                CRUD.WallDisplay();
            }
            else
            {
                disableButtons();
                this.Text = "VK CRUD -  не авторизовано";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CRUD.FormClose();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            CRUD.PostShit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            listView1.ContextMenuStrip = CRUDcms;
            CRUD.FormLoad();
            if (CRUD.Token != null)
            {
                this.Text = "VK CRUD - " + CRUD.Fname + " " + CRUD.Lname;
                CRUD.WallDisplay();
            }
            else
            {
                disableButtons();
                this.Text = "VK CRUD -  не авторизовано";
            }
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CRUD.Token = null;
            disableButtons();
            listView1.Items.Clear();
            this.Text = "VK CRUD -  не авторизовано";
        }

        public void refreshBtn_Click(object sender, EventArgs e)
        {
            CRUD.WallDisplay();
        }

        private void CRUDcms_Opening(object sender, CancelEventArgs e)
        {
            добавитьToolStripMenuItem.Enabled = true;
            редактироватьToolStripMenuItem.Enabled = true;
            удалитьToolStripMenuItem.Enabled = true;
            if (CRUD.Token == null)
            {
                добавитьToolStripMenuItem.Enabled = false;
                редактироватьToolStripMenuItem.Enabled = false;
                удалитьToolStripMenuItem.Enabled = false;
            }
            else 
            if (listView1.SelectedItems.Count > 0)
            {
                if (listView1.SelectedItems[0].Name != CRUD.Uid)
                {
                    редактироватьToolStripMenuItem.Enabled = false;
                    удалитьToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                редактироватьToolStripMenuItem.Enabled = false;
                удалитьToolStripMenuItem.Enabled = false;
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUpdate createUpdate = new CreateUpdate();
            createUpdate.Text = "Добавление записи на стену";
            createUpdate.confirmationBtn.Text = "Добавить";
            createUpdate.ShowDialog();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUpdate createUpdate = new CreateUpdate();
            createUpdate.Text = "Редактирование записи";
            createUpdate.confirmationBtn.Text = "Подтвердить";
            createUpdate.richTextBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            createUpdate.ShowDialog();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CRUD.Delete();
        }

        private void редактированиеToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            редактироватьЗаписьToolStripMenuItem.Enabled = true;
            удалитьЗаписьToolStripMenuItem.Enabled = true;
            if (listView1.SelectedItems.Count > 0)
            {
                if (listView1.SelectedItems[0].Name != CRUD.Uid)
                {
                    редактироватьЗаписьToolStripMenuItem.Enabled = false;
                    удалитьЗаписьToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                редактироватьЗаписьToolStripMenuItem.Enabled = false;
                удалитьЗаписьToolStripMenuItem.Enabled = false;
            }
        }
    }
}
