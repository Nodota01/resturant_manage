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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTestForm.Forms
{
    public partial class ConsumeEdit : Form
    {

        ConsumeDao consumeDao = new ConsumeDao();

        MeterialDao meterialDao = new MeterialDao();

        /// <summary>
        /// 装载食材列表
        /// </summary>
        IList<Meterial> meterialList;

        string dishes_id;

        public ConsumeEdit(string dishes_id)
        {
            InitializeComponent();
            this.dishes_id = dishes_id;
            meterialList = meterialDao.SelectAll();
            comboBox1.DataSource = meterialList;
            //绑定键值对
            comboBox1.DisplayMember = "meterial_name";
            comboBox1.ValueMember = "meterial_id";
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(consume_num.Text.Trim(), @"^\d+\.\d+\z|^\d+\z"))
            {
                Consume consume = new Consume
                {
                    dishes_id = dishes_id,
                    meterial_id = comboBox1.SelectedValue.ToString(),
                    consume_num = Convert.ToDecimal(consume_num.Text)
                };
                //查看是否已存在一对相同的耗材
                if (consumeDao.Select(new { dishes_id = dishes_id, meterial_id = consume.meterial_id }).Count > 0)
                {
                    MessageBox.Show("已存在相同耗材");
                    return;
                }
                consumeDao.Insert(consume);
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入数字");
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
