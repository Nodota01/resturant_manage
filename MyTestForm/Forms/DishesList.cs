using MyTestForm.dao;
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
    public partial class DishesList : Form
    {
        private DishesDao dishesDao;

        public DishesList()
        {
            InitializeComponent();
            dishesDao = new DishesDao();
            DataRefresh();

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void DataRefresh()
        {
            var dishess = dishesDao.SelectAll();
            this.dataGridView.DataSource = dishess;
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertButton_Click(object sender, EventArgs e)
        {
            DishesEdit dishesEdit = new DishesEdit();
            dishesEdit.ShowDialog();
            this.DataRefresh();
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
                string dishes_id = dataGridView.Rows[index].Cells["dishes_id"].Value.ToString();
                if (MessageBox.Show("是否删除", "删除提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK
                    && dishesDao.Delete(new { dishes_id = dishes_id }))
                {
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            DataRefresh();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            //获取id后进入edit
            if (dataGridView.CurrentRow != null)
            {
                int index = dataGridView.CurrentRow.Index;
                string dishes_id = dataGridView.Rows[index].Cells["dishes_id"].Value.ToString();
                DishesEdit dishesEdit = new DishesEdit(dishes_id);
                //退出编辑后刷新数据
                dishesEdit.ShowDialog();
                this.DataRefresh();
            }
            else
            {
                MessageBox.Show("尚未选择数据");
            }

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.DataRefresh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //获取选中行
            if (dataGridView.CurrentRow != null)
            {
                int index = index = dataGridView.CurrentRow.Index;
                //获取选中行的id(被隐藏)
                string dishes_id = dataGridView.Rows[index].Cells["dishes_id"].Value.ToString();
                ConsumeList consumeList = new ConsumeList(dishes_id);
                consumeList.ShowDialog();
            }
            DataRefresh();
        }
    }
}
