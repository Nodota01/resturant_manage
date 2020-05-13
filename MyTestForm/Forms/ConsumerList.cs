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

        private ConsumerDao ConsumerDao;

        public ConsumerList()
        {
            InitializeComponent();
            ConsumerDao = new ConsumerDao();
            RefreshData();
            
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshData()
        {
            this.dataGridView.DataSource = ConsumerDao.SelectAll();
            
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
                    && ConsumerDao.Delete(new { consumer_id = consumer_id }) )
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
            this.Dispose();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            ConsumerEdit consumerEdit = new ConsumerEdit();
            consumerEdit.ShowDialog();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            //获取id后进入edit
            if (dataGridView.CurrentRow != null)
            {
                int index = index = dataGridView.CurrentRow.Index;
                string consumer_id = dataGridView.Rows[index].Cells["consumer_id"].Value.ToString();
                ConsumerEdit consumerEdit = new ConsumerEdit(consumer_id);
                //退出编辑后刷新数据
                if(consumerEdit.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData();
                }
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
            this.dataGridView.DataSource = ConsumerDao.SelectLike(new {consumer_name = this.SearchTextBox.Text });
        }
    }
}
