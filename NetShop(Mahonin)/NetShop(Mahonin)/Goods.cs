using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace NetShop_Mahonin_
{
    [Serializable]
    public class Goods
    {
        public List<Product> ProductsList { get; set; } = new List<Product>();

        public Goods() { }

        public void RemoveProductId(int id)
        {
            foreach (Product product in ProductsList)
            {
                if (product.Id == id)
                {
                    ProductsList.Remove(product);
                    return;
                }
            }

            MessageBox.Show("Id не найден");
        }

        public ListViewItem GetListItemProduct(Product product)
        {
            ListViewItem item = null;

            item = new ListViewItem(new string[]
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
            return item;
        }

        public ListViewItem GetListItemAccessory(Accessory accessory)
        {
            ListViewItem item = null;

            item = new ListViewItem(new string[]
            {
                accessory.Id.ToString(),
                accessory.Name,
                accessory.Price.ToString(),
                accessory.PlacePurchase,
            });
            return item;
        }

        public List<ListViewItem> GetProductItemsByAttribute(string attribute)
        {
            List<ListViewItem> items = new List<ListViewItem>();

            foreach (Product product in ProductsList)
            {
                List<string> dataProduct = new List<string>();
                dataProduct.AddRange(new string[]{product.Id.ToString(), product.Name, product.Category, product.Model, product.Manufacturer, product.Price.ToString(), product.Description, product.Characteristic, product.Appearance, product.Shops, product.PlacePurchase, product.PhoneNumber, product.Address});

                foreach (string item in dataProduct)
                {
                    if (item.ToLower().Contains(attribute.ToLower()))
                    {
                        items.Add(GetListItemProduct(product));
                        break;
                    }
                }
            }
            return items;
        }

        public List<ListViewItem> GetAccessoryItemsByAttributw(string attribute,Product product)
        {
            List<ListViewItem> items = new List<ListViewItem>();

            foreach (Accessory accessory in product.Accessories)
            {
                List<string> dataAccessories = new List<string>();
                dataAccessories.AddRange(new string[] { accessory.Id.ToString(), accessory.Name, accessory.Price.ToString(), accessory.PlacePurchase});

                foreach (string item in dataAccessories)
                {
                    if (item.ToLower().Contains(attribute.ToLower()))
                    {
                        items.Add(GetListItemAccessory(accessory));
                        break;
                    }
                }
            }
            return items;
        }

        public void ShowAccessoriesDataByAttribute(ListView listView,Product product, string attribute)
        {
            List<ListViewItem> items = GetAccessoryItemsByAttributw(attribute,product);

            if (items.Count > 0)
            {
                listView.Items.Clear();

                foreach (ListViewItem item in items)
                {
                    listView.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Ничего не найдено");
            }
        }

        public void ShowProductDataByAttribute(ListView listView,string attribute)
        {
            List<ListViewItem> items = GetProductItemsByAttribute(attribute);

            if (items.Count > 0)
            {
                listView.Items.Clear();

                foreach (ListViewItem item in items)
                {
                    listView.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Ничего не найдено");
            }
        }

        public Product GetProduct(int id)
        {
            foreach (Product product in ProductsList)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            MessageBox.Show("Продукт не найден");
            return null;
        }

        public void AddProduct(string name,
            string category, string model,
            string manufacturer, int price,
            string description, string characteristic,
            string appearnce, string shops,
            string placePurtchase, string phoneNumber,
            string address)
        {
            ProductsList.Add(new Product(ProductsList.Count + 1, name, category, model, manufacturer, price, description, characteristic, appearnce, shops, placePurtchase, phoneNumber, address));
        }

        public void ShowProduct(ListView listView)
        {
            ListViewItem items = null;

            foreach (Product product in ProductsList)
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

        public void AddAccessory(int id, string name, int price, string placePurtchase)
        {
            foreach (Product product in ProductsList)
            {
                if (product.Id == id)
                {
                    product.Accessories.Add(new Accessory(product.Accessories.Count + 1,name, price, placePurtchase));
                    return;
                }
            }

            MessageBox.Show("Продукт не найден");
        }
    }

    [Serializable]
    public class Product
    {
        [XmlElement("Product")]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Characteristic { get; set; }
        public string Appearance { get; set; }
        public string Shops { get; set; }
        public string PlacePurchase { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<Accessory> Accessories { get; set; } = new List<Accessory>();

        public Product() { }

        public Product(int id, string name, 
            string category, string model,
            string manufacturer, int price,
            string description, string characteristic,
            string appearnce, string shops,
            string placePurtchase, string phoneNumber,
            string address)
        {
            Id = id;
            Name = name;
            Category = category;
            Model = model;
            Manufacturer = manufacturer;
            Price = price;
            Description = description;
            Characteristic = characteristic;
            Appearance = appearnce;
            Shops = shops;
            PlacePurchase = placePurtchase;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public void SetData(string name,
            string category, string model,
            string manufacturer, int price,
            string description, string characteristic,
            string appearnce, string shops,
            string placePurtchase, string phoneNumber,
            string address)
        {
            Name = name;
            Category = category;
            Model = model;
            Manufacturer = manufacturer;
            Price = price;
            Description = description;
            Characteristic = characteristic;
            Appearance = appearnce;
            Shops = shops;
            PlacePurchase = placePurtchase;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public void AddAccessory(string name, int price, string placePurchase)
        {
            Accessories.Add(new Accessory(Accessories.Count + 1,name,price,placePurchase));
        }

        public Accessory GetAccessory(int id)
        {
            foreach (Accessory accessory in Accessories)
            {
                if (accessory.Id == id)
                {
                    return accessory;
                }
            }

            return null;
        }

        public void ShowAccessory(ListView listViewAccessory)
        {
            ListViewItem items = null;

            foreach (Accessory accessory in Accessories)
            {
                items = new ListViewItem(new string[]
                {
                    accessory.Id.ToString(),
                    accessory.Name,
                    accessory.Price.ToString(),
                    accessory.PlacePurchase,
                });

                listViewAccessory.Items.Add(items);
            }
        }
    }

    [Serializable]
    public class Accessory
    {
        [XmlElement("Accessory")]

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string PlacePurchase { get; set; }

        public Accessory() { }

        public Accessory(int id, string name, int price, string placePurchase)
        {
            Id = id;
            Name = name;
            Price = price;
            PlacePurchase = placePurchase;
        }

        public void SetData(string name, int price, string placePurchase)
        {
            Name = name;
            Price = price;
            PlacePurchase = placePurchase;
        }
    }
}
