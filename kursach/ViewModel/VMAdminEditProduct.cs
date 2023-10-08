using kursach.Model;
using kursach.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace kursach.ViewModel
{
    public class VMAdminEditProduct : INotifyPropertyChanged
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

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged(nameof(Products)); }
        }
        public ICommand SearchCommand { get; }

        public VMAdminEditProduct()
        {
            var product = ModelPublic.GetContext().Products.ToList();
            Products = new ObservableCollection<Product>(product);

            SearchCommand = new RelayCommand(obj => FilterProduct());

        }

        private string? _categoryName;
        public string? Namingcategory
        {
            get { return _categoryName; }
            set { _categoryName = value; OnPropertyChanged(); }
        }

        private string? _inventoryNumber;
        public string? Inventorynumber
        {
            get { return _inventoryNumber; }
            set { _inventoryNumber = value; OnPropertyChanged(); }
        }

        private string? _naming;
        public string? Naming
        {
            get { return _naming; }
            set { _naming = value; OnPropertyChanged(); }
        }

        private string? _manufacturer;
        public string? Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; OnPropertyChanged(); }
        }

        private decimal? _price;
        public decimal? Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(); }
        }

        private string? _description;
        public string? Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                if (SelectedProduct != null)
                {
                    var category = ModelPublic.GetContext().Categoryproducts.FirstOrDefault(f => f.Idcategory == SelectedProduct.Idcategory);
                    var warehouse = ModelPublic.GetContext().Warehouses.FirstOrDefault(f => f.Idwarehouse == SelectedProduct.Idwarehouse);
                }
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                FilterProduct();
                OnPropertyChanged(nameof(SearchText));
            }
        }

        private void FilterProduct()
        {
            var searchText = SearchText?.ToLower();
            var filteredProduct = model.Products
                .Where(e => (e.Naming != null && e.Naming.ToLower().Contains(searchText))
                 || (e.Idcategory != null && e.IdcategoryNavigation.Namingcategory.ToLower().Contains(searchText))
                 || (e.Idwarehouse != null && e.IdwarehouseNavigation.Inventorynumber.ToLower().Contains(searchText)))
                .ToList();
            Products = new ObservableCollection<Product>(filteredProduct);
        }

        private RelayCommand _saveProductCommand;
        public RelayCommand SaveProductCommand
        {
            get
            {
                return _saveProductCommand ?? new RelayCommand(obj =>
                {
                    if (SelectedProduct != null)
                    {
                        var category = ModelPublic.GetContext().Categoryproducts.FirstOrDefault(f => f.Idcategory == SelectedProduct.Idcategory);
                        if (category != null)
                        {
                            var update = new Categoryproduct()
                            {
                                Namingcategory = category.Namingcategory
                            };
                            ModelPublic.GetContext().SaveChanges();
                        }

                        var warehouse = ModelPublic.GetContext().Warehouses.FirstOrDefault(f => f.Idwarehouse == SelectedProduct.Idwarehouse);
                        if (warehouse != null)
                        {
                            var update = new Warehouse()
                            {
                                Inventorynumber = warehouse.Inventorynumber
                            };
                            ModelPublic.GetContext().SaveChanges();
                        }

                        var product = ModelPublic.GetContext().Products.FirstOrDefault(f => f.Idproduct == SelectedProduct.Idproduct);
                        var update1 = new Product()
                        {
                            Naming = product.Naming,
                            Manufacturer = product.Manufacturer,
                            Price = product.Price,
                            Description = product.Description
                        };
                        ModelPublic.GetContext().SaveChanges();
                        MessageBox.Show("Информация изменена");

                        var updateProd = ModelPublic.GetContext().Products.ToList();
                        Products = new ObservableCollection<Product>(updateProd);
                    }
                    else
                    {
                        MessageBox.Show("Аргументы пусты");
                    }
                });
            }
        }

        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? new RelayCommand(obj =>
                {
                    if (SelectedProduct != null)
                    {
                        var product = ModelPublic.GetContext().Products.FirstOrDefault(f => f.Idproduct == SelectedProduct.Idproduct);
                        ModelPublic.GetContext().Remove(product);
                        ModelPublic.GetContext().SaveChanges();

                        var updateProduct = ModelPublic.GetContext().Products.ToList();
                        Products = new ObservableCollection<Product>(updateProduct);
                        OnPropertyChanged();
                    }
                    else
                    {
                        MessageBox.Show("Аргументы пусты");
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
                    AdminMain ad = new AdminMain();
                    ad.Show();
                    Window window = (Window)obj;
                    window.Close();
                });
            }
        }
    }
}
