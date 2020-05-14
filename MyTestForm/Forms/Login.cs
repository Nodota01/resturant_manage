using MyTestForm.dao;
using MyTestForm.domain;
using Renci.SshNet.Security;
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
    public partial class Login : Form
    {
        private EmployeeDao employeeDao;

        public Login()
        {
            InitializeComponent();
            employeeDao = new EmployeeDao();
        }

        /// <summary>
        /// 去验证是否通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.employee_name = NameText.Text;
            employee.password = PasswordText.Text;
            if (employeeDao.IsRight(employee))
            {
                MenuForm menu = new MenuForm(employee.titel_name);
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("账户或密码不存在");
            }
        }

        private void PasswordText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                LoginButton_Click(sender, e);
            }
        }
    }
}
