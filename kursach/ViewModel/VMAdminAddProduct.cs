using kursach.Model;
using kursach.View;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kursach.ViewModel
{
    public class VMAdminAddProduct : INotifyPropertyChanged
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

        private string? _productName;
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; OnPropertyChanged(); }
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
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private string? _newCategoryName;
        public string? NewCategoryName
        {
            get { return _newCategoryName; }
            set { _newCategoryName = value; OnPropertyChanged(); }
        }
        
        private string? _newNumberInventory;
        public string? NewNumberInventory
        {
            get { return _newNumberInventory; }
            set { _newNumberInventory = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Categoryproduct> CategoryName { get; set; }
        public ObservableCollection<Warehouse> InventoryNumbers { get; set; }
        private readonly KurkurContext _productService;

        private Warehouse _selectedInventoryNumber;
        public Warehouse SelectedInventoryNumber
        {
            get { return _selectedInventoryNumber; }
            set { _selectedInventoryNumber = value; OnPropertyChanged(); }
        }

        private Categoryproduct _selectedCategory;
        public Categoryproduct SelectedCategory
        {
            get { return _selectedCategory; }
            set { _selectedCategory = value; OnPropertyChanged(); }
        }

        public VMAdminAddProduct()
        {
            _productService = new KurkurContext();
            CategoryName = new ObservableCollection<Categoryproduct>(_productService.Categoryproducts.ToList());
            CategoryName.Insert(0, new Categoryproduct { Idcategory = 0, Namingcategory = "Не выбрано" });

            SelectedCategory = new Categoryproduct();
            SelectedCategory = CategoryName[0];

            InventoryNumbers = new ObservableCollection<Warehouse>(_productService.Warehouses.ToList());
        }

        private RelayCommand _exitBtn;
        public RelayCommand ExitBtn
        {
            get
            {
                return _exitBtn ?? new RelayCommand(obj =>
                {
                    AdminMain authorization = new AdminMain();
                    authorization.Show();
                    Window window = (Window)obj;
                    window.Close();
                });
            }
        }

        private RelayCommand _addNewCategory;
        public RelayCommand AddNewCategory
        {
            get
            {
                return _addNewCategory ?? new RelayCommand(obj =>
                {
                    if (NewCategoryName != null)
                    {
                        var category = new Categoryproduct()
                        {
                            Namingcategory = _newCategoryName
                        };
                        var dbContext = ModelPublic.GetContext();
                        dbContext.Categoryproducts.Add(category);
                        dbContext.SaveChanges();
                        MessageBox.Show("Категория добавлена");
                        // Обновление списка категорий
                        CategoryName.Add(category);
                        OnPropertyChanged(nameof(CategoryName));
                    }
                });
            }
        }
   
        private RelayCommand _addNewNumber;
        public RelayCommand AddNewNumber
        {
            get
            {
                return _addNewNumber ?? new RelayCommand(obj =>
                {
                    if (NewNumberInventory != null)
                    {
                        var warehouse = new Warehouse()
                        {
                            Inventorynumber = NewNumberInventory
                        };
                        var dbContext = ModelPublic.GetContext();
                        dbContext.Warehouses.Add(warehouse);
                        dbContext.SaveChanges();
                        MessageBox.Show("Номер добавлен");
                        InventoryNumbers.Add(warehouse);
                        OnPropertyChanged(nameof(InventoryNumbers));
                    }
                });
            }
        }

        private RelayCommand _addProductCommand;
        public RelayCommand AddProductCommand
        {
            get
            {
                return _addProductCommand ?? new RelayCommand(obj =>
                {
                    if (SelectedInventoryNumber != null&&SelectedCategory!=null)
                    {
                        var dbContext = ModelPublic.GetContext();
                        var searchCat = dbContext.Categoryproducts.FirstOrDefault(f => f.Namingcategory == SelectedCategory.ToString());
                        var search = dbContext.Warehouses.FirstOrDefault(f => f.Inventorynumber == SelectedInventoryNumber.ToString());
                        var product = new Product()
                        {
                            Naming = _productName,
                            Manufacturer = _manufacturer,
                            Price = _price,
                            Idcategory = SelectedCategory.Idcategory,
                            Description = _description,
                            Idwarehouse = SelectedInventoryNumber.Idwarehouse,
                            Stockquantity = 0
                        };
                        dbContext.Products.Add(product);
                        dbContext.SaveChanges();
                        MessageBox.Show("Товар добавлен");
                    }
                    else
                    {
                        MessageBox.Show("Аргументы пусты");
                    }

                });
            }
        }
    }
}
