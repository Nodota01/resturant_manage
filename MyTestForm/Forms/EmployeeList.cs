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
    public partial class EmployeeList : Form
    {

        private EmployeeDao employeeDao;

        public EmployeeList()
        {
            InitializeComponent();
            employeeDao = new EmployeeDao();
            DataRefresh();
        }

        private void DataRefresh()
        {
            var employees = employeeDao.SelectAll();
            var dataSource = changeGender(employees);
            this.dataGridView.DataSource = dataSource;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            DataRefresh();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

        }

        private IList<Object> changeGender(IList<Employee> employees)
        {
            var dataSource = new List<Object>();
            foreach (Employee employee in employees)
            {
                string gender = employee.gender == 0 ? "女" : "男";
                dataSource.Add(new
                {
                    employee_id = employee.employee_id,
                    employee_name = employee.employee_name,
                    gender = gender,
                    titel_name = employee.titel_name,
                    join_date = employee.join_date,
                    wage = employee.wage,
                    password = employee.password
                });
            }
            return dataSource;
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            EmployeeEdit employeeEdit = new EmployeeEdit();
            employeeEdit.ShowDialog();
            this.DataRefresh();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            //获取id后进入edit
            if (dataGridView.CurrentRow != null)
            {
                int index = dataGridView.CurrentRow.Index;
                string employee_id = dataGridView.Rows[index].Cells["employee_id"].Value.ToString();
                EmployeeEdit employeeEdit = new EmployeeEdit(employee_id);
                //退出编辑后刷新数据
                employeeEdit.ShowDialog();
                this.DataRefresh();
            }
            else
            {
                MessageBox.Show("尚未选择数据");
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                int index = index = dataGridView.CurrentRow.Index;
                //获取选中行的id(被隐藏)
                string employee_id = dataGridView.Rows[index].Cells["employee_id"].Value.ToString();
                if (MessageBox.Show("是否删除", "删除提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK
                    && employeeDao.Delete(new { employee_id = employee_id }))
                {
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            DataRefresh();
        }
    }
}
