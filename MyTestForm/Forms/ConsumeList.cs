using MyTestForm.dao;
using MyTestForm.domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTestForm.Forms
{
    public partial class ConsumeList : Form
    {

        ConsumeDao consumeDao = new ConsumeDao();

        MeterialDao meterialDao = new MeterialDao();

        /// <summary>
        /// 存储当前菜品耗材
        /// </summary>
        ArrayList meterialList;

        string dishes_id;

        public ConsumeList(string dishes_id)
        {
            InitializeComponent();
            meterialList = new ArrayList();
            this.dishes_id = dishes_id;
            DataRefresh();
        }

        private void DataRefresh()
        {
            meterialList = new ArrayList();
            var consumes = consumeDao.GetConsumeMeterials(dishes_id);
            foreach(Consume consume in consumes)
            {
                Meterial meterial = meterialDao.Select(new { meterial_id = consume.meterial_id })[0];
                meterialList.Add(new {
                    meterial_id = meterial.meterial_id,
                    meterial_name = meterial.meterial_name,
                    consume_num = consume.consume_num
                });
            }
            this.dataGridView.DataSource = meterialList;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.DataRefresh();
        }

        /// <summary>
        /// 按下删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                int index = dataGridView.CurrentRow.Index;
                //获取选中行的id(被隐藏)
                string meterial_id = dataGridView.Rows[index].Cells["meterial_id"].Value.ToString();
                string consume_num = dataGridView.Rows[index].Cells["consume_num"].Value.ToString();
                if (MessageBox.Show("是否删除", "删除提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK
                    && consumeDao.Delete(new {
                        dishes_id = dishes_id,
                        meterial_id = meterial_id
                    }))
                {
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            DataRefresh();
        }

        /// <summary>
        /// 按下添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertButton_Click(object sender, EventArgs e)
        {
            ConsumeEdit consumeEdit = new ConsumeEdit(dishes_id);
            consumeEdit.ShowDialog();
            this.DataRefresh();
        }
    }
}
