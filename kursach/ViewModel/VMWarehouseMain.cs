using kursach.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Globalization;
using kursach.View;
using System.Collections.ObjectModel;

namespace kursach.ViewModel
{
    public class VMWarehouseMain : INotifyPropertyChanged
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

        public ObservableCollection<Supplier> Suppliers { get; set; }

        public ObservableCollection<Warehouse> InventoryNumber { get; set; }

        private Warehouse _selectedNumber;
        public Warehouse SelectedNumber
        {
            get { return _selectedNumber; }
            set
            {
                _selectedNumber = value; NotifyPropertyChanged();
                if (_selectedNumber != null)
                {
                    var product = ModelPublic.GetContext().Products.FirstOrDefault(f => f.Idwarehouse == SelectedNumber.Idwarehouse);
                    if (product != null)
                    {
                        NewProductName = product.Naming;
                    }
                    else
                    {
                        NewProductName = "Нет товара с таким номером.";
                    }
                }
            }
        }

        private Supplier _selectedSupplier;
        public Supplier SelectedSupplier
        {
            get { return _selectedSupplier; }
            set
            {
                _selectedSupplier = value;
                NotifyPropertyChanged();
                if (_selectedSupplier != null)
                {
                    ResponsibleSurname = _selectedSupplier.Surnameresponsible;
                }
            }
        }

        private string responsibleSurname;
        public string ResponsibleSurname
        {
            get { return responsibleSurname; }
            set
            {
                responsibleSurname = value;
                NotifyPropertyChanged();
            }
        }

        private string newProductName;
        public string NewProductName
        {
            get { return newProductName; }
            set
            {
                newProductName = value;
                NotifyPropertyChanged();
            }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                NotifyPropertyChanged();
            }
        }

        private RelayCommand _acceptProductCommand;
        public RelayCommand AcceptProductCommand
        {
            get
            {
                return _acceptProductCommand ?? new RelayCommand(obj =>
                {
                    AcceptProduct();
                });
            }
        }

        private readonly KurkurContext _suppContext;
        private readonly KurkurContext _warContext;

        public VMWarehouseMain()
        {
            _suppContext = new KurkurContext();

            Suppliers = new ObservableCollection<Supplier>(_suppContext.Suppliers.ToList());

            _warContext = new KurkurContext();
            InventoryNumber = new ObservableCollection<Warehouse>(_warContext.Warehouses.ToList());
        }

        public string DateReceipt { get; set; }

        private void AcceptProduct()
        {
            if (SelectedSupplier == null)
            {
                MessageBox.Show("Выберите поставщика.");
                return;
            }

            if (SelectedNumber == null)
            {
                MessageBox.Show("Введите инвентаризационный номер товара.");
                return;
            }

            if (SelectedSupplier != null && SelectedNumber != null && Quantity != 0)
            {
                var product = ModelPublic.GetContext().Products.FirstOrDefault(f => f.Idwarehouse == SelectedNumber.Idwarehouse);
                var supprod = new Supplierproduct()
                {
                    Idsupplier = SelectedSupplier.Idsupplier,
                    Idproduct = product.Idproduct,
                    Quantity = Quantity
                };
                if(product.Stockquantity == null)
                {
                    product.Stockquantity = 0;
                    product.Stockquantity = product.Stockquantity + supprod.Quantity;
                }
                else
                {
                    product.Stockquantity = product.Stockquantity + supprod.Quantity;
                }

                ModelPublic.GetContext().Supplierproducts.Add(supprod);
                ModelPublic.GetContext().SaveChanges();
                MessageBox.Show("Товар успешно принят.");
            }
            else
            {
                MessageBox.Show("Аргументы пусты");
            }
        }

        private RelayCommand _exitBtn;
        public RelayCommand ExitBtn
        {
            get
            {
                return _exitBtn ?? new RelayCommand(obj =>
                {
                    MainWindow ad = new MainWindow();
                    ad.Show();
                    Window window = (Window)obj;
                    window.Close();
                });
            }
        }

    }
}
