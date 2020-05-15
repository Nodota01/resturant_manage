using MyTestForm.dao;
using MyTestForm.domain;
using System;
using System.Collections;
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
    public partial class ConsumerList : Form
    {

        private ConsumerDao consumerDao;

        public ConsumerList()
        {
            InitializeComponent();
            consumerDao = new ConsumerDao();
            RefreshData();
            
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshData()
        {
            var consumers = consumerDao.SelectAll();
            var dataSource = changeGender(consumers);
            this.dataGridView.DataSource = dataSource;
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            //获取选中行
            if (dataGridView.CurrentRow != null)
            {
                int index = index = dataGridView.CurrentRow.Index;
                //获取选中行的id(被隐藏)
                string consumer_id = dataGridView.Rows[index].Cells["consumer_id"].Value.ToString();
                if (MessageBox.Show("是否删除", "删除提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK
                    && consumerDao.Delete(new { consumer_id = consumer_id }) )
                {
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            RefreshData();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            ConsumerEdit consumerEdit = new ConsumerEdit();
            consumerEdit.ShowDialog();
            this.RefreshData();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            //获取id后进入edit
            if (dataGridView.CurrentRow != null)
            {
                int index  = dataGridView.CurrentRow.Index;
                string consumer_id = dataGridView.Rows[index].Cells["consumer_id"].Value.ToString();
                ConsumerEdit consumerEdit = new ConsumerEdit(consumer_id);
                //退出编辑后刷新数据
                consumerEdit.ShowDialog();
                this.RefreshData();
            }
            else
            {
                MessageBox.Show("尚未选择数据");
            }
            
        }

        /// <summary>
        /// 根据用户名的模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            var consumers = consumerDao.SelectLike(new {consumer_name = this.SearchTextBox.Text });
            var dataSource = changeGender(consumers);
            this.dataGridView.DataSource = dataSource;
        }

        /// <summary>
        /// 把性别变成字符串
        /// </summary>
        /// <param name="consumers"></param>
        /// <returns></returns>
        private IList changeGender(IList<Consumer> consumers)
        {
            var dataSource = new List<Object>();
            foreach (Consumer consumer in consumers)
            {
                string gender = consumer.gender == 0 ? "女" : "男";
                dataSource.Add(new
                {
                    consumer_id = consumer.consumer_id,
                    consumer_name = consumer.consumer_name,
                    phone_number = consumer.phone_number,
                    gender = gender
                });
            }
            return dataSource;
        }
    }
}
