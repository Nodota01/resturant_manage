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
            //雇员无法查看的内容
            if(title == "雇员")
            {
                EmplyeeButton.Enabled = false;
                BillButton.Enabled = false;
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

        private void EmplyeeButton_Click(object sender, EventArgs e)
        {
            EmployeeList employeeList = new EmployeeList();
            employeeList.ShowDialog();
        }

        private void BillButton_Click(object sender, EventArgs e)
        {
            BillList billList = new BillList();
            billList.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MeterialList meterialList = new MeterialList();
            meterialList.ShowDialog();
        }

        private void DishesManageButton_Click(object sender, EventArgs e)
        {
            DishesList dishesList = new DishesList();
            dishesList.ShowDialog();
        }
    }
}
