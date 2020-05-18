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
    public partial class DishesEdit : Form
    {

        private DishesDao dishesDao = new DishesDao();
        private Dishes dishes;
        private string dishes_id;

        //编辑
        public DishesEdit(string id)
        {
            InitializeComponent();
            //如果传入ID则查出来并放入控件
            dishes_id = id;
            dishes = dishesDao.Select(new { dishes_id = dishes_id })[0];
            this.Text = "正在编辑 - " + dishes.dishes_name;
            Util.Binding.BindObjectToForm(this, dishes, typeof(Dishes));
        }

        //新增
        public DishesEdit()
        {
            InitializeComponent();
            dishes = null;
            this.Text = "新增";
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
            if (dishes == null)
            {
                dishes = new Dishes();
                if (Util.Binding.BindFormToObject(this, dishes, typeof(Dishes)) && dishesDao.Insert(dishes))
                {
                    MessageBox.Show("添加成功");
                    this.Text = "正在编辑 - " + dishes.dishes_name;
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            //更新
            else
            {
                if ((Util.Binding.BindFormToObject(this, dishes, typeof(Dishes)) && dishesDao.Update(dishes)))
                {
                    MessageBox.Show("更新成功");
                    this.Text = "正在编辑 - " + dishes.dishes_name;
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
    }
}
