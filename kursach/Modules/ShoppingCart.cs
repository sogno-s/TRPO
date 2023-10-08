using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach.Modules
{
    public class ShoppingCart
    {
        private static ShoppingCart instance;
        public static ShoppingCart Instance
        {
            get
            {
                if (instance == null)
                    instance = new ShoppingCart();
                return instance;
            }
        }

        private ObservableCollection<CartLogic> selectedProducts;
        public ObservableCollection<CartLogic> SelectedProducts
        {
            get
            {
                if (selectedProducts == null)
                    selectedProducts = new ObservableCollection<CartLogic>();
                return selectedProducts;
            }
        }
    }
}
