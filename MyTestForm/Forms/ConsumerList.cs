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
                if (ConsumerDao.Delete(new { consumer_id = consumer_id }) &&
                    MessageBox.Show("是否删除", "删除提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
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
    }
}
