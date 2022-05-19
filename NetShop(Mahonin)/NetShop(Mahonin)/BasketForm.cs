using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetShop_Mahonin_
{
    public partial class BasketForm : Form
    {
        private Basket _basket;
        private int _price = 0;

        public BasketForm(Basket basket)
        {
            InitializeComponent();
            _basket = basket;
            _basket.ShowProduct(listView1);
            productsLabel.Text += _basket.CountProducts;

            foreach (Product product in basket.Products)
            {
                _price += product.Price;
            }
            priceLabel.Text = $"Цена: {_price}";
        }

        public void ReloadDataOrder()
        {
            priceLabel.Text = $"Цена: {_price}";
            countAccessoryLabel.Text = $"Акссесуаров: {_basket.CountAccessories}";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            LoadDataAccessory();
        }

        private void LoadDataAccessory()
        {
            if (_basket.GetProductById((int)numericUpDown1.Value) != null)
            {
                listView2.Items.Clear();
                _basket.GetProductById((int)numericUpDown1.Value).ShowAccessory(listView2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_basket.GetProductById((int)numericUpDown1.Value) != null)
            {
                Accessory accessory = _basket.GetProductById((int)numericUpDown1.Value).GetAccessory((int)numericUpDown2.Value);
                _basket.AddAccessory(accessory);
                _price += accessory.Price;
                ReloadDataOrder();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "")
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    MessageBox.Show("Заказ оплачен");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
