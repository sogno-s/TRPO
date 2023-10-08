using kursach.Model;
using kursach.Modules;
using kursach.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace kursach.ViewModel
{
    public class VMProduct : INotifyPropertyChanged
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

        private readonly KurkurContext _productService;
        private ObservableCollection<Product> _productLst;
        public ObservableCollection<Product> LstProducts
        {
            get { return _productLst; }
            set { _productLst = value; OnPropertyChanged(nameof(LstProducts)); }
        }

        public ObservableCollection<SortOption> SortOptions { get; set; }
        public ObservableCollection<Categoryproduct> Categories { get; set; }

        public VMProduct()
        {
            _productService = new KurkurContext();
            LstProducts = new ObservableCollection<Product>(_productService.Products.ToList());
            SelectedProducts = ShoppingCart.Instance.SelectedProducts;

            _productsView = CollectionViewSource.GetDefaultView(LstProducts);
            _productsView.Filter = FilterProducts;

            SearchCommand = new RelayCommand(obj => ApplyFilters());

            SortOptions = new ObservableCollection<SortOption>
            {
                new SortOption { PropertyName = "Не выбрано", SortDirection = SortDirection.Ascending, DisplayName = "Не выбрано" },
                new SortOption { PropertyName = "По названию А-Я", SortDirection = SortDirection.Ascending, DisplayName = "По названию А-Я" },
                new SortOption { PropertyName = "По названию Я-А", SortDirection = SortDirection.Descending, DisplayName = "По названию Я-А" },
                new SortOption { PropertyName = "По цене(MAX)", SortDirection = SortDirection.Ascending, DisplayName = "По цене(MAX)" },
                new SortOption { PropertyName = "По цене(MIN)", SortDirection = SortDirection.Descending, DisplayName = "По цене(MIN)" },
            };
            SelectedSortOption = SortOptions[0];
            SortProducts();

            Categories = new ObservableCollection<Categoryproduct>(_productService.Categoryproducts.ToList());
            Categories.Insert(0, new Categoryproduct { Idcategory = 0, Namingcategory = "Не выбрано" });

            SelectedCategory = Categories[0];
        }

        private static ObservableCollection<CartLogic> _selectedProducts;
        public static ObservableCollection<CartLogic> SelectedProducts
        {
            get { return _selectedProducts; }
            set { _selectedProducts = value; }
        }

        private int _tbCount;
        public int TbCount
        {
            get { return _tbCount; }
            set { _tbCount = value; OnPropertyChanged(); }
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                MaxStockQuantity = value?.Stockquantity ?? 0;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private RelayCommand _btnAddToCart;
        public RelayCommand BtnAddToCart
        {
            get
            {
                return _btnAddToCart ?? new RelayCommand(obj =>
                {
                    if (_selectedProduct != null)
                    {
                        int selectedQuantity = TbCount;
                        if (selectedQuantity > MaxStockQuantity)
                        {
                            MessageBox.Show("Количество выбранного товара превышает количество на складе.");
                        }
                        else
                        {
                            CartLogic cartLogic = new CartLogic();
                            if (_tbCount > 0)
                            {
                                cartLogic.Id = _selectedProduct.Idproduct;
                                cartLogic.Name = _selectedProduct.Naming;
                                cartLogic.Count = _tbCount;
                                cartLogic.Price = _selectedProduct.Price * cartLogic.Count;
                                cartLogic.StockQuantity = _selectedProduct.Stockquantity;
                            }
                            else
                            {
                                cartLogic.Id = _selectedProduct.Idproduct;
                                cartLogic.Name = _selectedProduct.Naming;
                                cartLogic.Count = 1;
                                cartLogic.Price = _selectedProduct.Price;
                                cartLogic.StockQuantity = _selectedProduct.Stockquantity;
                            }
                            SelectedProducts.Add(cartLogic);
                            TbCount = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Товар не выбран.");
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
                    Main main = new Main();
                    main.Show();
                    Window window = (Window)obj;
                    window.Close();
                });
            }
        }

        private RelayCommand _goToCartBtn;
        public RelayCommand GoToCartBtn
        {
            get
            {
                return _goToCartBtn ?? new RelayCommand(obj =>
                {
                    CartWindow cw = new CartWindow();
                    cw.Show();
                    Window window = (Window)obj;
                    window.Close();
                });
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged();
                ApplyFilters();
            }
        }

        private SortOption _selectedSortOption;
        public SortOption SelectedSortOption
        {
            get { return _selectedSortOption; }
            set
            {
                if (_selectedSortOption != value)
                {
                    _selectedSortOption = value;
                    OnPropertyChanged();

                    if (_selectedSortOption != _previousSortOption)
                    {
                        _previousSortOption = _selectedSortOption;

                        // Проверка на выбор значения "не выбрано"
                        if (_selectedSortOption != null && _selectedSortOption.PropertyName == "Не выбрано")
                        {
                            _productsView.SortDescriptions.Clear();
                        }
                        else
                        {
                            ApplyFilters();
                        }
                    }
                }
            }
        }

        private SortOption _previousSortOption;

        public Categoryproduct _selectedCategory;
        public Categoryproduct SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                ApplyFilters();
            }
        }

        private int _maxStockQuantity;
        public int MaxStockQuantity
        {
            get { return _maxStockQuantity; }
            set
            {
                _maxStockQuantity = value;
                OnPropertyChanged(nameof(MaxStockQuantity));
            }
        }

        public ICommand SearchCommand { get; }


        private bool FilterProducts(object obj)
        {
            var product = (Product)obj;

            // Применение фильтрации по категории
            if (SelectedCategory != null && SelectedCategory.Idcategory != 0 && product.Idcategory != SelectedCategory.Idcategory)
                return false;

            // Применение фильтрации по тексту поиска
            if (!string.IsNullOrWhiteSpace(SearchText) && !product.Naming.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                return false;

            return true;
        }

        private ICollectionView _productsView;
        private void ApplyFilters()
        {
            _productsView.Refresh();
            SortProducts();
        }

        public class SortOption
        {
            public string PropertyName { get; set; }
            public SortDirection SortDirection { get; set; }
            public string DisplayName { get; set; } // Новое свойство для отображения названия сортировки
        }

        private void SortProducts()
        {
            if (SelectedSortOption == null || SelectedSortOption.PropertyName == "Не выбрано")
            {
                _productsView.SortDescriptions.Clear();
                return;
            }

            var propertyName = SelectedSortOption.PropertyName;
            var direction = SelectedSortOption.SortDirection;

            Debug.WriteLine($"Sorting by: {propertyName}, Direction: {direction}");

            if (!string.IsNullOrWhiteSpace(propertyName))
            {
                switch (propertyName)
                {
                    case "По названию А-Я":
                        _productsView.SortDescriptions.Clear();
                        _productsView.SortDescriptions.Add(new SortDescription("Naming", direction == SortDirection.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending));
                        break;
                    case "По названию Я-А":
                        _productsView.SortDescriptions.Clear();
                        _productsView.SortDescriptions.Add(new SortDescription("Naming", direction == SortDirection.Descending ? ListSortDirection.Descending : ListSortDirection.Ascending));
                        break;
                    case "По цене(MAX)":
                        _productsView.SortDescriptions.Clear();
                        _productsView.SortDescriptions.Add(new SortDescription("Price", direction == SortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending));
                        break;
                    case "По цене(MIN)":
                        _productsView.SortDescriptions.Clear();
                        _productsView.SortDescriptions.Add(new SortDescription("Price", direction == SortDirection.Descending ? ListSortDirection.Ascending : ListSortDirection.Descending));
                        break;
                }
            }
            _productsView.Refresh();
        }
    }
}
