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
    public partial class Authorization : Form
    {
        private DataBase _dataBase;
        private string _path = "dataBase.xml";

        public Authorization()
        {
            InitializeComponent();
            LoadData();
            RegistrationgroupBox.Hide();
            LogIn.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogingroupBox.Hide();
            RegistrationgroupBox.Show();
            LogIn.Show();
            SiginUp.Hide();
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            RegistrationgroupBox.Hide();
            LogingroupBox.Show();
            SiginUp.Show();
            LogIn.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void LoadData()
        {
            if (File.Exists(_path))
            {
                _dataBase = DeseriacliezeXml(_path);

                if (_dataBase == null)
                {
                    _dataBase = new DataBase("root", "toor");
                }
            }
            else
            {
                _dataBase = new DataBase("root","toor");
                SaveData();
            }
        }

        private void SaveData()
        {
            if (File.Exists(_path))
                File.Delete(_path);
            SerializeXML(_dataBase, _path);
        }

        private void SiginUpbutton_Click(object sender, EventArgs e)
        {
            if (_dataBase.TryAddUser(userLoginBox.Text, userPasswordBox.Text))
            {
                userLoginBox.Text = null;
                userPasswordBox.Text = null;
                SaveData();
            }
        }

        private void UserLoginbutton_Click(object sender, EventArgs e)
        {
            if (_dataBase.CheckUser(LoginTextBox.Text,PasswordTextBox.Text))
            {
                Shop shop = new Shop();
                shop.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неправильно введен логин или пароль");
            }
        }

        private void LoginAdminbutton_Click(object sender, EventArgs e)
        {
            if (_dataBase.CheckAdmin(LoginTextBox.Text,PasswordTextBox.Text))
            {
                AdminTool adminTool = new AdminTool();
                adminTool.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неправильно введен логин или пароль");
            }
        }

        private void SerializeXML(DataBase database, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataBase));

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, database);
            }
        }

        private DataBase DeseriacliezeXml(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataBase));

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (DataBase)xmlSerializer.Deserialize(fileStream);
            }
        }
    }
}
