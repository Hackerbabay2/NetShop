using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace NetShop_Mahonin_
{
    public partial class Shop : Form
    {
        private Goods _goods;
        private Basket _basket;
        private string path;

        public Shop()
        {
            InitializeComponent();
            _goods = new Goods();
            _basket = new Basket();

            if (File.Exists("settings.txt"))
            {
                path = File.ReadAllText("settings.txt");
                _goods = DeseriacliezeXml(path);
            }

            _goods.ShowProduct(listView1);
        }

        private Goods DeseriacliezeXml(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Goods));

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (Goods)xmlSerializer.Deserialize(fileStream);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_goods.GetProduct((int)numericUpDown1.Value) != null)
            {
                _basket.AddProduct(_goods.GetProduct((int)numericUpDown1.Value));
            }
            else
            {
                MessageBox.Show("Товар не найден");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                _goods.ShowProductDataByAttribute(listView1,textBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            _goods.ShowProduct(listView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BasketForm basketForm = new BasketForm(_basket);
            basketForm.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lsw = (ListView)sender;

            if (e.Column == ListViewItemComparer.SortColumn)
            {
                if (ListViewItemComparer.Order == SortOrder.Ascending)
                {
                    ListViewItemComparer.Order = SortOrder.Descending;
                }
                else
                {
                    ListViewItemComparer.Order = SortOrder.Ascending;
                }
            }
            else
            {
                ListViewItemComparer.SortColumn = e.Column;
                ListViewItemComparer.Order = SortOrder.Ascending;
            }
            this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }
    }

    public class Basket
    {
        private List<Product> _products;
        private List<Accessory> _accessories;

        public List<Product> Products => _products;

        public int CountAccessories => _accessories.Count;
        public int CountProducts => _products.Count;

        public Basket()
        {
            _products = new List<Product>();
            _accessories = new List<Accessory>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void ShowProduct(ListView listView)
        {
            ListViewItem items = null;

            foreach (Product product in _products)
            {
                items = new ListViewItem(new string[]
                {
                    product.Id.ToString(),
                    product.Name,
                    product.Category,
                    product.Model,
                    product.Manufacturer,
                    product.Price.ToString(),
                    product.Description,
                    product.Characteristic,
                    product.Appearance,
                    product.Shops,
                    product.PlacePurchase,
                    product.PhoneNumber,
                    product.Address
                });

                listView.Items.Add(items);
            }
        }

        public Product GetProductById(int id)
        {
            foreach (Product product in _products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }

            return null;
        }

        public void AddAccessory(Accessory accessory)
        {
            _accessories.Add(accessory);
        }
    }
}
