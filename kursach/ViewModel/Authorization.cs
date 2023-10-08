using kursach.Model;
using kursach.Modules;
using kursach.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace kursach.ViewModel
{
    public class Authorization : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public static string? PersonLogin { get; set; }

        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ?? new RelayCommand(obj =>
                {
                    var values = (object[])obj;
                    var passwordBox = (PasswordBox)values[0];
                    var loginBtn = (Window)values[1];
                    var User = ModelPublic.GetContext().Employees.FirstOrDefault(f => f.Login == PersonLogin && f.Passworde == passwordBox.Password);

                    if (User != null)
                    {
                        Reserv.IdSpec = User.Idspecialization;
                        Reserv.IdPerson = User.Idemployee;
                        if (Reserv.IdSpec == "Продавец")
                        {
                            Main main = new Main();
                            main.Show();
                            loginBtn.Close();

                        }
                        else if (Reserv.IdSpec == "Админ")
                        {
                            AdminMain admin = new AdminMain();
                            admin.Show();
                            loginBtn.Close();
                        }
                        else if (Reserv.IdSpec == "Склад")
                        {
                            WarehouseMain warehouse = new WarehouseMain();
                            warehouse.Show();
                            loginBtn.Close();
                        }
                        else
                        {
                            MessageBox.Show("У пользователя не определена роль. Обратитесь к администратору.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден. Некорректный ввод данных");
                    }
                });
            }
        }
    }
}
