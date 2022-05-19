using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace NetShop_Mahonin_
{
    public partial class AdminTool : Form
    {
        private Goods _goods;

        public AdminTool()
        {
            InitializeComponent();
            _goods = new Goods();
        }

        private void AdminTool_Load(object sender, EventArgs e)
        {

        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            _goods.AddProduct(productNameTextBox.Text,
                CategoryTextBox.Text,
                ModelTextBox.Text,
                manufacturerTextBox.Text,
                (int)priceNumeric.Value,
                discriptionTextBox.Text,
                characteristicTextBox.Text,
                appearanceTextBox.Text,
                shopsTextBox.Text,
                placeProductPurchaseTextBox.Text,
                numberPhoneMaskedBox.Text,
                addressTextBox.Text);
            listView1.Items.Clear();
            _goods.ShowProduct(listView1);
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

        private void AddAccessoryButton_Click(object sender, EventArgs e)
        {
            if (_goods.GetProduct((int)accessoryProductIdNumeric.Value) != null)
            {
                _goods.AddAccessory((int)accessoryProductIdNumeric.Value, accessoryNameTextBox.Text, (int)accessoryPriceNumeric.Value, placeAccessuryPurachseTextBox.Text);
                ShowAccesory();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowAccesory();
        }

        private void ShowAccesory()
        {
            if (_goods.GetProduct((int)accessoryProductIdNumeric.Value) != null)
            {
                listView2.Items.Clear();
                _goods.GetProduct((int)accessoryProductIdNumeric.Value).ShowAccessory(listView2);
            }
        }

        private void redactorButton_Click(object sender, EventArgs e)
        {
            if (_goods.GetProduct((int)productIdNumeric.Value) != null)
            {
                Redactor redactor = new Redactor(_goods.GetProduct((int)productIdNumeric.Value));
                redactor.Show();
            }
        }

        private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.listView2.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _goods.RemoveProductId((int)productIdNumeric.Value);
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            _goods.ShowProduct(listView1);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ".xml (*.xml*)|*.xml*";
            saveFileDialog.ShowDialog();

            if (!saveFileDialog.FileName.EndsWith(".xml"))
                saveFileDialog.FileName += ".xml";

            File.Delete(saveFileDialog.FileName);
            SerializeXML(_goods, saveFileDialog.FileName);
            File.WriteAllText("settings.txt",saveFileDialog.FileName);
        }

        private void SerializeXML(Goods goods, string pathFile)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Goods));

            using (FileStream fileStream = new FileStream(pathFile, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, goods);
            }
        }

        private Goods DeseriacliezeXml(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Goods));

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (Goods)xmlSerializer.Deserialize(fileStream);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = ".xml (*.xml*)|*.xml*";
            openFileDialog.ShowDialog();

            try
            {
                if (openFileDialog.FileName.EndsWith(".xml"))
                {
                    _goods = DeseriacliezeXml(openFileDialog.FileName);
                    listView1.Items.Clear();
                    _goods.ShowProduct(listView1);
                }
            }
            catch (Exception exeption)
            {
                MessageBox.Show("Программа не смогла обработать эти данные, побробуйте перезаписать☺");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                _goods.ShowProductDataByAttribute(listView1,textBox1.Text);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (_goods.GetProduct((int)accessoryProductIdNumeric.Value) != null)
                {
                    _goods.ShowAccessoriesDataByAttribute(listView2,_goods.GetProduct((int)accessoryProductIdNumeric.Value),textBox2.Text);
                }
                else
                {
                    MessageBox.Show("Нет такого id продукта");
                }
            }
        }
    }
}
