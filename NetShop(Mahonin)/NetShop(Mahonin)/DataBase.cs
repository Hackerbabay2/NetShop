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
    public class DataBase
    {
        public List<User> UserList { get; set; } = new List<User>();
        public List<Admin> AdminList { get; set; } = new List<Admin>();

        public DataBase() { }

        public DataBase(string adminLogin, string adminPassword)
        {
            AdminList.Add(new Admin(adminLogin,adminPassword));
        }

        public bool CheckUser(string login, string password)
        {
            foreach (User user in UserList)
            {
                if (user.Login == login)
                {
                    if (user.Password == password)
                        return true;
                }
            }
            return false;
        }

        public bool CheckRepeatLogin(string login)
        {
            foreach (User user in UserList)
            {
                if (user.Login == login)
                    return true;
            }
            return false;
        }

        public bool CheckAdmin(string login, string password)
        {
            foreach (Admin admin in AdminList)
            {
                if (admin.Login == login)
                {
                    if (admin.Password == password)
                        return true;
                }
            }
            return false;
        }

        public bool TryAddUser(string login, string password)
        {
            if (!CheckRepeatLogin(login))
            {
                if (login != "" && password != "")
                {
                    if (password.Length > 8)
                    {
                        UserList.Add(new User(login,password));
                        MessageBox.Show("Вы зарегестрировались, входите!");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Пароль слишком короткий");
                        return false;
                    }
                }
                MessageBox.Show("Заполните все поля");
                return false;
            }
            else
            {
                MessageBox.Show("Этот логин уже занят");
                return false;
            }
        }
    }

    [Serializable]
    public class User
    {
        [XmlElement("User")]

        public string Login { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }

    [Serializable]
    public class Admin
    {
        [XmlElement("Admin")]
        public string Login { get; set; }
        public string Password { get; set; }

        public Admin() { }

        public Admin(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
