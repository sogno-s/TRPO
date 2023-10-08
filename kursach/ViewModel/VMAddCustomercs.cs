using kursach.Model;
using kursach.Modules;
using kursach.View;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Wpf.Toolkit;

namespace kursach.ViewModel
{
    public class VMAddCustomercs : INotifyPropertyChanged
    {
        KurkurContext model = new KurkurContext();
        BaseViewModel a = new BaseViewModel();
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        private string _tbSurname;
        public string TbSurname
        {
            get { return _tbSurname; }
            set { _tbSurname = value; OnPropertyChanged(); }
        }

        private string _tbName;
        public string TbName
        {
            get { return _tbName; }
            set { _tbName = value; OnPropertyChanged(); }
        }

        private string _tbLastName;
        public string TbLastName
        {
            get { return _tbLastName; }
            set { _tbLastName = value; OnPropertyChanged(); }
        }

        private string _tbNumber;
        public string TbNumber
        {
            get { return _tbNumber; }
            set { _tbNumber = value; OnPropertyChanged(); }
        }

        private string _tbSeriaPass;
        public string TbSeriaPass
        {
            get { return _tbSeriaPass; }
            set { _tbSeriaPass = value; OnPropertyChanged(); }
        }

        private string _tbNumberPass;
        public string TbNumberPass
        {
            get { return _tbNumberPass; }
            set { _tbNumberPass = value; OnPropertyChanged(); }
        }

        private string _tbRegion;
        public string TbRegion
        {
            get { return _tbRegion; }
            set { _tbRegion = value; OnPropertyChanged(); }
        }

        private string _tbCity;
        public string TbCity
        {
            get { return _tbCity; }
            set { _tbCity = value; OnPropertyChanged(); }
        }

        private string _tbStreet;
        public string TbStreet
        {
            get { return _tbStreet; }
            set { _tbStreet = value; OnPropertyChanged(); }
        }

        private string _tbNumberHouse;
        public string TbNumberHouse
        {
            get { return _tbNumberHouse; }
            set { _tbNumberHouse = value; OnPropertyChanged(); }
        }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? new RelayCommand(obj =>
                {
                    if (_tbNumberPass != null && _tbSeriaPass != null)
                    {
                        var passport = new Pasport()
                        {
                            Seria = _tbSeriaPass,
                            Numberp = _tbNumberPass
                        };
                        var dbContext = ModelPublic.GetContext();
                        dbContext.Pasports.Add(passport);
                        dbContext.SaveChanges();
                        int idPas = passport.Idpasport;
                        if (_tbRegion != null && _tbCity != null && _tbStreet != null && _tbNumberHouse != null)
                        {
                            var addres = new Address()
                            {
                                Region = _tbRegion,
                                City = _tbCity,
                                Street = _tbStreet,
                                Numberhouse = _tbNumberHouse
                            };
                            dbContext.Addresses.Add(addres);
                            dbContext.SaveChanges();
                            int idAddres = addres.Idaddress;
                            if (_tbSurname != null && _tbName != null && _tbLastName != null && _tbNumber != null)
                            {
                                var person = new Customer()
                                {
                                    Surname = _tbSurname,
                                    Firstname = _tbName,
                                    Lastname = _tbLastName,
                                    Phonenumber = _tbNumber,
                                    Idaddress = idAddres,
                                    Idpasport = idPas
                                };
                                dbContext.Customers.Add(person);
                                dbContext.SaveChanges();
                                DetailsPay detailsPay = new DetailsPay();
                                detailsPay.Show();
                                Window window = (Window)obj;
                                window.Close();
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("не заполнены личные данные");
                            }
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("не заполнены данные об адресе");
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("не заполнены данные о паспорте");
                    }
                });
            }
        }


        private RelayCommand _exitBtn;
        public RelayCommand ExitBtn
        {
            get
            {
                return _exitBtn ?? new RelayCommand(obj =>
                {
                    Products products = new Products();
                    products.Show();
                    Window window = (Window)obj;
                    window.Close();
                });
            }
        }
    }
}
