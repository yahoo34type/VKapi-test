using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class CreateUpdate : Form
    {
        public CreateUpdate()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void confirmationBtn_Click(object sender, EventArgs e)
        {
            if (confirmationBtn.Text == "Добавить")
            {
                CRUD.Create(this);
                this.Visible = false;
            }
            else
            {
                CRUD.Update(this);
                this.Visible = false;
            }
        }
    }
}
