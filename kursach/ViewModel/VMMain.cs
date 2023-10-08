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
    public class VMMain : INotifyPropertyChanged
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

        private RelayCommand _productBtn;
        public RelayCommand ProductBtn
        {
            get
            {
                return _productBtn ?? new RelayCommand(obj =>
                {
                    Products product = new Products();
                    product.Show();
                    Window window = (Window)obj;
                    window.Close();
                });
            }
        }

        private RelayCommand _reportBtn;
        public RelayCommand ReportBtn
        {
            get
            {
                return _reportBtn ?? new RelayCommand(obj =>
                {
                    ReportGenerationWindow reportGenerationWindow = new ReportGenerationWindow();
                    reportGenerationWindow.Show();
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
                    MainWindow authorization = new MainWindow();
                    authorization.Show();
                    Window window = (Window)obj;
                    window.Close();
                });
            }
        }
    }
}
