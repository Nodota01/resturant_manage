using MyTestForm.dao;
using MyTestForm.domain;
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
    public partial class EmployeeEdit : Form
    {

        private EmployeeDao employeeDao = new EmployeeDao();
        private Employee employee;
        string employee_id;

        public EmployeeEdit(string employee_id)
        {
            InitializeComponent();
            this.employee_id = employee_id;
            this.employee = employeeDao.Select(new { employee_id = employee_id })[0];
            this.Text = "正在编辑 - " + employee.employee_name;
            Util.Binding.BindObjectToForm(this, employee, typeof(Employee));
        }

        public EmployeeEdit()
        {
            InitializeComponent();
            this.employee = null;
            this.Text = "新增";
            //设置性别默认值
            gender.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //判空
            foreach (Control control in this.panelMain.Controls)
            {
                TextBox textBox = control as TextBox;
                if (textBox != null && textBox.Text.Trim().Length == 0)
                {
                    MessageBox.Show("所有字段不能为空");
                    return;
                }
            }
            //根据是否存有对象判别新增还是修改
            if (employee == null)
            {
                employee = new Employee();
                if (Util.Binding.BindFormToObject(this, employee, typeof(Employee)) && employeeDao.Insert(employee))
                {
                    MessageBox.Show("添加成功");
                    this.Text = "正在编辑 - " + employee.employee_name;
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            //更新
            else
            {
                if ((Util.Binding.BindFormToObject(this, employee, typeof(Employee)) && employeeDao.Update(employee)))
                {
                    MessageBox.Show("更新成功");
                    this.Text = "正在编辑 - " + employee.employee_name;
                }
                else
                {
                    MessageBox.Show("更新失败");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (Control control in panelMain.Controls)
            {
                TextBox textBox = control as TextBox;
                if (textBox != null)
                {
                    textBox.Text = "";
                }
            }
        }
    }
}
