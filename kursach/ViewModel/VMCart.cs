using kursach.Model;
using kursach.Modules;
using kursach.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kursach.ViewModel
{
    public class VMCart : INotifyPropertyChanged
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

        private ObservableCollection<CartLogic> _cartItems;
        public ObservableCollection<CartLogic> CartItems
        {
            get { return _cartItems; }
            set { _cartItems = value; OnPropertyChanged(); }
        }

        private decimal? _totalPrice;
        public decimal? TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                _totalPrice = value;
                OnPropertyChanged();
            }
        }

        private void UpdateTotalPrice()
        {
            TotalPrice = CartItems.Sum(item => item.Price * item.Count);
        }

        public VMCart()
        {
            _cartItems = ShoppingCart.Instance.SelectedProducts;
            CartItems = _cartItems;

            UpdateTotalPrice();
        }

        private CartLogic _selectedCartItem;
        public CartLogic SelectedCartItem
        {
            get { return _selectedCartItem; }
            set { _selectedCartItem = value; OnPropertyChanged(); }
        }

        private RelayCommand _removeCartItemCommand;
        public RelayCommand RemoveCartItemCommand
        {
            get
            {
                return _removeCartItemCommand ?? new RelayCommand(obj =>
                {
                    if (_selectedCartItem != null)
                    {
                        TotalPrice = TotalPrice - _selectedCartItem.Price;
                        _cartItems.Remove(_selectedCartItem);
                    }
                });
            }
        }

        private RelayCommand _payWithoutCardBtn;
        public RelayCommand PayWithoutCardBtn
        {
            get
            {
                return _payWithoutCardBtn ?? new RelayCommand(obj =>
                {
                    if (_cartItems == null || !_cartItems.Any())
                    {
                        MessageBox.Show("Нет товаров в корзине.");
                    }
                    else
                    {
                        ShowPopup = true;
                        Reserv.Typeofpay = "Наличными";
                    }
                });
            }
        }

        private RelayCommand _payWithCardBtn;
        public RelayCommand PayWitCardBtn
        {
            get
            {
                return _payWithCardBtn ?? new RelayCommand(obj =>
                {
                    if (_cartItems == null || !_cartItems.Any())
                    {
                        MessageBox.Show("Нет товаров в корзине.");
                    }
                    else
                    { 
                        ShowPopup = true;
                        Reserv.Typeofpay = "Картой";
                    }
                });
            }
        }

        private bool _deliveryCheckbox;

        public bool DeliveryCheckBox
        {
            get { return _deliveryCheckbox; }
            set
            {
                if (_deliveryCheckbox != value)
                {
                    _deliveryCheckbox = value;
                    OnPropertyChanged();
                }
            }
        }

        private RelayCommand _continueCommand;
        public RelayCommand ContinueCommand
        {
            get
            {
                return _continueCommand ?? (_continueCommand = new RelayCommand(obj =>
                {
                        ShowPopup = false;
                        bool DeliveryChecked = DeliveryCheckBox;
                    if (DeliveryChecked)
                    {
                        // Если выбрана доставка, переходите на окно доставки
                        DetailsPay dp = new DetailsPay();
                        dp.Show();
                        Window window = (Window)obj;
                        window.Close();
                    }
                    else
                    {
                        // Если доставка не выбрана, переходите к оплате СОХРАНЕНИЕ В БД
                        if (Reserv.Typeofpay == "Картой")
                        {
                            var dateonly = DateOnly.FromDateTime(DateTime.Today);
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
                            foreach (CartLogic item in _cartItems)
                            {
                                Product product = dbContext.Products.FirstOrDefault(p => p.Idproduct == item.Id);
                                if (product != null)
                                {
                                    product.Stockquantity = product.Stockquantity - item.Count;
                                    dbContext.SaveChanges();
                                }
                            }
                            _cartItems.Clear();
                            MessageBox.Show("Оплачено");
                        }
                        else
                        {
                            var dateonly = DateOnly.FromDateTime(DateTime.Today);
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
                            foreach (CartLogic item in _cartItems)
                            {
                                Product product = dbContext.Products.FirstOrDefault(p => p.Idproduct == item.Id);
                                if (product != null)
                                {
                                    product.Stockquantity = product.Stockquantity - item.Count;
                                    dbContext.SaveChanges();
                                }
                            }
                            _cartItems.Clear();
                            MessageBox.Show("Оплачено");
                        }
                    } 
                }));
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

        private bool _showPopup;
        public bool ShowPopup
        {
            get { return _showPopup; }
            set
            {
                _showPopup = value;
                OnPropertyChanged(nameof(ShowPopup));
            }
        }
    }
}
