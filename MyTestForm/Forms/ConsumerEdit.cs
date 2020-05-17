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
    public partial class ConsumerEdit : Form
    {
        private ConsumerDao consumerDao = new ConsumerDao();
        private Consumer consumer;
        private string consumer_id;

        //编辑
        public ConsumerEdit(string id)
        {
            InitializeComponent();
            //如果传入ID则查出来并放入控件
            consumer_id = id;
            consumer = consumerDao.Select(new { consumer_id = consumer_id })[0];
            this.Text = "正在编辑 - " + consumer.consumer_name;
            Util.Binding.BindObjectToForm(this, consumer, typeof(Consumer));
        }

        //新增
        public ConsumerEdit()
        {
            InitializeComponent();
            consumer = null;
            this.Text = "新增";
            //设置性别默认值
            gender.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //判空
            foreach(Control control in this.panelMain.Controls)
            {
                TextBox textBox = control as TextBox;
                if (textBox != null && textBox.Text.Trim().Length == 0)
                {
                    MessageBox.Show("所有字段不能为空");
                    return;
                }
            }
            //根据是否存有对象判别新增还是修改
            if (consumer == null)
            {
                consumer = new Consumer();
                if (Util.Binding.BindFormToObject(this, consumer, typeof(Consumer)) && consumerDao.Insert(consumer))
                {
                    MessageBox.Show("添加成功");
                    this.Text = "正在编辑 - " + consumer.consumer_name;
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            //更新
            else
            {
                if ((Util.Binding.BindFormToObject(this, consumer, typeof(Consumer)) && consumerDao.Update(consumer)))
                {
                    MessageBox.Show("更新成功");
                    this.Text = "正在编辑 - " + consumer.consumer_name;
                }
                else
                {
                    MessageBox.Show("更新失败");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 清空textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach(Control control in panelMain.Controls)
            {
                TextBox textBox = control as TextBox;
                if(textBox != null)
                {
                    textBox.Text = "";
                }
            }
        }

        
    }
}
