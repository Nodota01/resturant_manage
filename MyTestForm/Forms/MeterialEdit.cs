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
    public partial class MeterialEdit : Form
    {
        private MeterialDao meterialDao = new MeterialDao();
        private Meterial meterial;
        private string meterial_id;

        //编辑
        public MeterialEdit(string id)
        {
            InitializeComponent();
            //如果传入ID则查出来并放入控件
            meterial_id = id;
            meterial = meterialDao.Select(new { meterial_id = meterial_id })[0];
            this.Text = "正在编辑 - " + meterial.meterial_name;
            Util.Binding.BindObjectToForm(this, meterial, typeof(Meterial));
        }

        //新增
        public MeterialEdit()
        {
            InitializeComponent();
            meterial = null;
            this.Text = "新增";
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            foreach (Control control in panelMain.Controls)
            {
                TextBox textBox = control as TextBox;
                if (textBox != null)
                {
                    textBox.Text = "";
                }
            }
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
            if (meterial == null)
            {
                meterial = new Meterial();
                if (Util.Binding.BindFormToObject(this, meterial, typeof(Meterial)) && meterialDao.Insert(meterial))
                {
                    MessageBox.Show("添加成功");
                    this.Text = "正在编辑 - " + meterial.meterial_name;
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            //更新
            else
            {
                if ((Util.Binding.BindFormToObject(this, meterial, typeof(Meterial)) && meterialDao.Update(meterial)))
                {
                    MessageBox.Show("更新成功");
                    this.Text = "正在编辑 - " + meterial.meterial_name;
                }
                else
                {
                    MessageBox.Show("更新失败");
                }
            }
        }
    }
}
