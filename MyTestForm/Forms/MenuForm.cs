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
            //服务员无法查看的内容
            if(title == "服务员")
            {
                EmplyeeButton.Enabled = false;
                BillButton.Enabled = false;
                MeterialButton.Enabled = false;
                DishesManageButton.Enabled = false;
            }else if(title == "后厨")
            {
                EmplyeeButton.Enabled = false;
                BillButton.Enabled = false;
                ConsumerButton.Enabled = false;
                DeskButton.Enabled = false;
            }else if(title == "店长")
            {
                return;
            }
            else
            {
                EmplyeeButton.Enabled = false;
                BillButton.Enabled = false;
                MeterialButton.Enabled = false;
                DishesManageButton.Enabled = false;
                ConsumerButton.Enabled = false;
                DeskButton.Enabled = false;
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



        /// <summary>
        /// 摁下退出按钮结束程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 被禁用后背景变灰
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DishesManageButton_EnabledChanged(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Gray;
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
