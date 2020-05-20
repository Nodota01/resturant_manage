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
    public partial class OrderEdit : Form
    {

        private string visit_record_id;

        private DishesDao dishesDao = new DishesDao();

        private OrderDao orderDao = new OrderDao();

        private ConsumeDao consumeDao = new ConsumeDao();

        private MeterialDao meterialDao = new MeterialDao();

        public OrderEdit(string visit_record_id)
        {
            InitializeComponent();
            this.visit_record_id = visit_record_id;
            //设置值和显示值
            var dishesList = dishesDao.SelectAll();
            comboBox1.DataSource = dishesList;
            comboBox1.DisplayMember = "dishes_name";
            comboBox1.ValueMember = "dishes_id";
            comboBox1.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 检查食材是否足够并更新食材和写入订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string dishes_id = comboBox1.SelectedValue.ToString();
            //检查食材
            var consumes = consumeDao.GetConsumeMeterials(dishes_id);
            var meterials = new List<Meterial>();
            foreach(Consume consume in consumes)
            {
                Meterial meterial = meterialDao.Select(new { meterial_id = consume.meterial_id })[0];
                //如果不够
                if(consume.consume_num > meterial.storage)
                {
                    MessageBox.Show(meterial.meterial_name + " 食材不足");
                    return;
                }
                meterial.storage = meterial.storage - consume.consume_num;
                meterials.Add(meterial);
            }
            //更新食材数量
            foreach(Meterial meterial1 in meterials)
            {
                meterialDao.Update(meterial1);
            }
            //写入订单
            Order order = new Order();
            order.visit_record_id = visit_record_id;
            order.dishes_id = dishes_id;
            orderDao.Insert(order);
            this.Close();
        }
    }
}
