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
    public partial class Redactor : Form
    {
        private Product _product;

        public Redactor(Product product)
        {
            InitializeComponent();
            _product = product;
            productNameTextBox.Text = _product.Name;
            CategoryTextBox.Text = _product.Category;
            ModelTextBox.Text = _product.Model;
            manufacturerTextBox.Text = _product.Manufacturer;
            priceNumeric.Value = _product.Price;
            discriptionTextBox.Text = _product.Description;
            characteristicTextBox.Text = _product.Characteristic;
            appearanceTextBox.Text = _product.Appearance;
            shopsTextBox.Text = _product.Shops;
            placeProductPurchaseTextBox.Text = _product.PlacePurchase;
            numberPhoneMaskedBox.Text = _product.PhoneNumber;
            _product.ShowAccessory(listView2);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            LoadDataAccessory();
        }

        private void LoadDataAccessory()
        {
            if (_product.GetAccessory((int)idAccessoryNumeric.Value) != null)
            {
                Accessory accessory = _product.GetAccessory((int)idAccessoryNumeric.Value);
                accessoryNameTextBox.Text = accessory.Name;
                accessoryPriceNumeric.Value = accessory.Price;
                placeAccessuryPurachseTextBox.Text = accessory.PlacePurchase;
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

        private void idAccessoryNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            LoadDataAccessory();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_product.GetAccessory((int)idAccessoryNumeric.Value) != null)
            {
                Accessory accessory = _product.GetAccessory((int)idAccessoryNumeric.Value);
                accessory.SetData(accessoryNameTextBox.Text, (int)accessoryPriceNumeric.Value, placeAccessuryPurachseTextBox.Text);
            }
            else
            {
                MessageBox.Show("Id не найден");
            }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            _product.SetData(productNameTextBox.Text,
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Завершить редактирование?",
                "Внимание!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
                );

            if (result == DialogResult.Yes)
            {
                Hide();
            }
        }
    }
}
