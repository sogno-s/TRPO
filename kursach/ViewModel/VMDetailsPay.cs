using kursach.Model;
using kursach.Modules;
using kursach.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace kursach.ViewModel
{
    public class VMDetailsPay : INotifyPropertyChanged
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



        private string _clientName;
        private string _clientLastName;
        private string _deliveryAddress;
        private string _resultMessage;

        public string ClientName
        {
            get { return _clientName; }
            set
            {
                if (_clientName != value)
                {
                    _clientName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ClientLastName
        {
            get { return _clientLastName; }
            set
            {
                if (_clientLastName != value)
                {
                    _clientLastName = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isDeliveryChecked;

        public bool IsDeliveryChecked
        {
            get { return _isDeliveryChecked; }
            set
            {
                if (_isDeliveryChecked != value)
                {
                    _isDeliveryChecked = value;
                    OnPropertyChanged();
                }
            }
        }

        public string DeliveryAddress
        {
            get { return _deliveryAddress; }
            set
            {
                if (_deliveryAddress != value)
                {
                    _deliveryAddress = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ResultMessage
        {
            get { return _resultMessage; }
            set
            {
                if (_resultMessage != value)
                {
                    _resultMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        private RelayCommand _searchBtn;
        public RelayCommand SearchCommand
        {
            get
            {
                return _searchBtn ?? new RelayCommand(obj =>
                {
                    bool check;
                    var customer = ModelPublic.GetContext().Customers.FirstOrDefault(f => f.Surname == ClientLastName);
                    if (customer != null)
                    {
                        check = true;
                        Reserv.Check = check;
                        ClientName = customer.Firstname;
                        bool isDeliveryChecked = IsDeliveryChecked;

                        if (isDeliveryChecked)
                        {
                            var addres = ModelPublic.GetContext().Addresses.FirstOrDefault(a => a.Idaddress == customer.Idaddress);
                            DeliveryAddress = addres.City.ToString() + " " + addres.Region.ToString() + " " + addres.Street.ToString() + " " + addres.Numberhouse.ToString();
                        }
                        else
                        {
                            DeliveryAddress = " ";
                        }
                        ResultMessage = "Способ оплаты: " + Reserv.Typeofpay;
                    }
                    else
                    {
                        check = false;
                        Reserv.Check = check;
                        ResultMessage = "Клиент не найден."; // Обновите сообщение об ошибке, если клиент не найден
                    }
                });
            }
        }


        private ObservableCollection<CartLogic> _cartItems;
        public ObservableCollection<CartLogic> CartItems
        {
            get { return _cartItems; }
            set { _cartItems = value; OnPropertyChanged(); }
        }

        public VMDetailsPay()
        {
            _cartItems = ShoppingCart.Instance.SelectedProducts;
            CartItems = _cartItems;
            DeliveryDate = DateTime.Now;
        }

        //public DateOnly DeliveryDate { get; set; }

        private CartLogic _selectedCartItem;
        public CartLogic SelectedCartItem
        {
            get { return _selectedCartItem; }
            set { _selectedCartItem = value; OnPropertyChanged(); }
        }

        private DateTime _deliveryDateTime;

        public DateTime DeliveryDate
        {
            get { return _deliveryDateTime; }
            set
            {
                _deliveryDateTime = value.Date; // Извлечение только даты из DateTime
                DeliveryDateOnly = value.Date.ToString("yyyy-MM-dd"); // Преобразование в строку
            }
        }

        public string DeliveryDateOnly { get; set; }

        public DateTime DateOnly { get; set; }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? new RelayCommand(obj =>
                {
                    if (_deliveryAddress != null && _clientLastName != null && _clientName != null && DeliveryDateOnly != null)
                    {
                        if (Reserv.Typeofpay == "Картой")
                        {
                            var dateonly = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                            decimal? totalAmoun = 0;
                            foreach (CartLogic item in _cartItems)
                            {
                                totalAmoun += item.Price;
                            }
                            var payment = new Payment()
                            {
                                Idemployee = Reserv.IdPerson,
                                Totalsumm = totalAmoun,
                                Dateofpay = dateonly,
                                Idstatus = 1,
                                Typeofpay = "Картой"
                            };
                            var dbContext = ModelPublic.GetContext();
                            dbContext.Payments.Add(payment);
                            dbContext.SaveChanges();
                            int idpayment = payment.Idpayment;
                            foreach (CartLogic item in _cartItems)
                            {
                                var saveTable = new Paymentproduct()
                                {
                                    Idpayment = idpayment,
                                    Idproduct = item.Id,
                                    Quantity = item.Count
                                };
                                dbContext.Paymentproducts.Add(saveTable);
                                dbContext.SaveChanges();
                            }
                            var deliveryDate = DateTime.ParseExact(DeliveryDateOnly, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            var assembl = new Assembling()//---------------------------------------------------------
                            {
                                Idpayment = idpayment,
                                Dateofadmission = new DateOnly(deliveryDate.Year, deliveryDate.Month, deliveryDate.Day)
                            };
                            dbContext.Assemblings.Add(assembl);
                            dbContext.SaveChanges();
                            _cartItems.Clear();
                            foreach (CartLogic item in _cartItems)
                            {
                                Product product = dbContext.Products.FirstOrDefault(p => p.Idproduct == item.Id);
                                if (product != null)
                                {
                                    product.Stockquantity = product.Stockquantity - item.Count;
                                    dbContext.SaveChanges();
                                }
                            }
                            MessageBox.Show("Оплачено");//---------------------------------------------------------------
                            Products cart = new Products();
                            cart.Show();
                            Window window = (Window)obj;
                            window.Close();
                        }
                        else
                        {
                            var dateonly = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                            decimal? totalAmoun = 0;
                            foreach (CartLogic item in _cartItems)
                            {
                                totalAmoun += item.Price;
                            }
                            var payment = new Payment()
                            {
                                Idemployee = Reserv.IdPerson,
                                Totalsumm = totalAmoun,
                                Dateofpay = dateonly,
                                Idstatus = 1,
                                Typeofpay = "Наличными"
                            };
                            var dbContext = ModelPublic.GetContext();
                            dbContext.Payments.Add(payment);
                            dbContext.SaveChanges();
                            int idpayment = payment.Idpayment;
                            foreach (CartLogic item in _cartItems)
                            {
                                var saveTable = new Paymentproduct()
                                {
                                    Idpayment = idpayment,
                                    Idproduct = item.Id,
                                    Quantity = item.Count
                                };
                                dbContext.Paymentproducts.Add(saveTable);
                                dbContext.SaveChanges();
                            }
                            var deliveryDate = DateTime.ParseExact(DeliveryDateOnly, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            var assembl = new Assembling()//---------------------------------------------------------
                            {
                                Idpayment = idpayment,
                                Dateofadmission = new DateOnly(deliveryDate.Year, deliveryDate.Month, deliveryDate.Day)
                            };
                            dbContext.Assemblings.Add(assembl);
                            dbContext.SaveChanges();
                            _cartItems.Clear();
                            foreach (CartLogic item in _cartItems)
                            {
                                Product product = dbContext.Products.FirstOrDefault(p => p.Idproduct == item.Id);
                                if (product != null)
                                {
                                    product.Stockquantity = product.Stockquantity - item.Count;
                                    dbContext.SaveChanges();
                                }
                            }
                            MessageBox.Show("Оплачено");
                            Products cart = new Products();
                            cart.Show();
                            Window window = (Window)obj;
                            window.Close();
                        }
                    }
                });
            }
        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? new RelayCommand(obj =>
                {
                    AddCustomer addCustomer = new AddCustomer();
                    addCustomer.Show();
                    Window window = (Window)obj;
                    window.Close();
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
                    CartWindow cart = new CartWindow();
                    cart.Show();
                    Window window = (Window)obj;
                    window.Close();
                });
            }
        }
    }
}
