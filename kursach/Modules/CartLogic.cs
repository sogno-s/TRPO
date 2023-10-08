using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace kursach.Modules
{
    public class CartLogic : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private int id { get; set; }
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        private string name { get; set; }
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private int count { get; set; }
        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged(); }
        }

        private decimal? price;
        public decimal? Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }

        private int? _stockQuantity;
        public int? StockQuantity
        {
            get { return _stockQuantity; }
            set
            {
                _stockQuantity = value;
                OnPropertyChanged(nameof(StockQuantity));
            }
        }

    }
}
