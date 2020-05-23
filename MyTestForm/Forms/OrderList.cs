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
    public partial class OrderList : Form
    {

        private string visit_record_id;

        private OrderDao orderDao = new OrderDao();

        private DishesDao dishesDao = new DishesDao();

        public OrderList(string visit_record_id)
        {
            InitializeComponent();
            this.visit_record_id = visit_record_id;
            this.DataRefresh();
        }

        private void DataRefresh()
        {
            var orderList = orderDao.Select(new { visit_record_id = visit_record_id });
            var dispList = new List<Object>();
            //总价计数
            decimal totalCost = 0;
            //组装显示表
            foreach(Order order in orderList)
            {
                Dishes dishes = dishesDao.Select(new { dishes_id = order.dishes_id })[0];
                dispList.Add(new
                {
                    order_id = order.order_id,
                    dishes_name = dishes.dishes_name,
                    order_date = order.order_date
                });
                totalCost += dishes.price;
            }
            this.dataGridView.DataSource = dispList;
            this.TotalLabel.Text = "总计：" + totalCost + "元";
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
        /// 点餐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertButton_Click(object sender, EventArgs e)
        {
            点餐菜品 orderEdit = new 点餐菜品(visit_record_id);
            orderEdit.ShowDialog();
            this.DataRefresh();
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            //获取是否可用并删除
            if (dataGridView.CurrentRow != null)
            {
                int index = dataGridView.CurrentRow.Index;
                string order_id = (string)dataGridView.Rows[index].Cells["order_id"].Value;
                orderDao.Delete(new { order_id = order_id });
                this.DataRefresh();
            }
            else
            {
                MessageBox.Show("尚未选择数据");
            }
        }
    }
}
