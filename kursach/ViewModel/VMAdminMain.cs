using kursach.Model;
using kursach.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kursach.ViewModel
{
    public class VMAdminMain : INotifyPropertyChanged
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


        private RelayCommand _exitBtn;
        public RelayCommand ExitBtn
        {
            get
            {
                return _exitBtn ?? new RelayCommand(obj =>
                {
                    MainWindow authorization = new MainWindow();
                    authorization.Show();
                    Window window = (Window)obj;
                    window.Close();
                });
            }
        }

        private RelayCommand _addEmployeeBtn;
        public RelayCommand AddEmployeeBtn
        {
            get
            {
                return _addEmployeeBtn ?? new RelayCommand(obj =>
                {
                    AdminAddEmployee adminAddEmployee = new AdminAddEmployee();
                    adminAddEmployee.Show();
                    Window window = (Window)obj; window.Close();
                });
            }
        }

        private RelayCommand _addProductBtn;
        public RelayCommand AddProductBtn
        {
            get
            {
                return _addProductBtn ?? new RelayCommand(obj =>
                {
                    AdminAddProduct adminAddProduct = new AdminAddProduct();
                    adminAddProduct.Show();
                    Window window = (Window)obj; window.Close();
                });
            }
        }

        private RelayCommand _editProductBtn;
        public RelayCommand EditProductBtn
        {
            get
            {
                return _editProductBtn ?? new RelayCommand(obj =>
                {
                    AdminEditProduct ae = new AdminEditProduct();
                    ae.Show();
                    Window window = (Window)obj; window.Close();
                });
            }
        }

        private RelayCommand _editEmployee;
        public RelayCommand EditEmployee
        {
            get
            {
                return _editEmployee ?? new RelayCommand(obj =>
                {
                    AdminEditEmployee adminedProduct = new AdminEditEmployee();
                    adminedProduct.Show();
                    Window window = (Window)obj; window.Close();
                });
            }
        }
    }
}
