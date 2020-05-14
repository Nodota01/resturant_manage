using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTestForm.Forms
{
    public partial class MenuForm : Form
    {
        public MenuForm(string title)
        {
            InitializeComponent();
            if(title == "雇员")
            {
                EmplyeeButton.Enabled = false;
            }
        }

        private void ConsumerButton_Click(object sender, EventArgs e)
        {
            ConsumerList consumerList = new ConsumerList();
            consumerList.ShowDialog();
        }

        private void DeskButton_Click(object sender, EventArgs e)
        {
            DeskList deskList = new DeskList();
            deskList.ShowDialog();
        }

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
