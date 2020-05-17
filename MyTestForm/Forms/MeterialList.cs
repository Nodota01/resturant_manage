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
    public partial class MeterialList : Form
    {

        MeterialDao meterialDao = new MeterialDao();

        public MeterialList()
        {
            InitializeComponent();
            DataRefresh();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            DataRefresh();
        }

        private void DataRefresh()
        {
            this.dataGridView.DataSource = meterialDao.SelectAll();
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
                string meterial_id = dataGridView.Rows[index].Cells["meterial_id"].Value.ToString();
                if (MessageBox.Show("是否删除", "删除提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK
                    && meterialDao.Delete(new { meterial_id = meterial_id }))
                {
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            DataRefresh();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            MeterialEdit meterialEdit = new MeterialEdit();
            meterialEdit.ShowDialog();
            this.DataRefresh();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            //获取id后进入edit
            if (dataGridView.CurrentRow != null)
            {
                int index = dataGridView.CurrentRow.Index;
                string meterial_id = dataGridView.Rows[index].Cells["meterial_id"].Value.ToString();
                MeterialEdit meterialEdit = new MeterialEdit(meterial_id);
                //退出编辑后刷新数据
                meterialEdit.ShowDialog();
                this.DataRefresh();
            }
            else
            {
                MessageBox.Show("尚未选择数据");
            }
        }

        /// <summary>
        /// 进货，打开进货窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddStorageButton_Click(object sender, EventArgs e)
        {
            //获取选中行
            if (dataGridView.CurrentRow != null)
            {
                int index = index = dataGridView.CurrentRow.Index;
                //获取选中行的id(被隐藏)
                string meterial_id = dataGridView.Rows[index].Cells["meterial_id"].Value.ToString();
                MeterialAddStorage meterialAdd = new MeterialAddStorage(meterial_id);
                meterialAdd.ShowDialog();
            }
            DataRefresh();
        }
    }
}
