using kursach.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kursach.View
{
    /// <summary>
    /// Логика взаимодействия для AdminAddEmployee.xaml
    /// </summary>
    public partial class AdminAddEmployee : Window
    {
        public AdminAddEmployee()
        {
            InitializeComponent();
            DataContext = new VMAdminAddEmployee();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length >= 4)
            {
                e.Handled = true; // Предотвращаем ввод символов, если длина текста достигла 4
            }
        }

        private void TextBox_PreviewTextInput1(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length >= 6)
            {
                e.Handled = true; // Предотвращаем ввод символов, если длина текста достигла 4
            }
        }

        private void TextBox_PreviewTextInput_Surname(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length >= 25)
            {
                e.Handled = true; // Предотвращаем ввод символов, если длина текста достигла 4
            }
        }
        private void TextBox_PreviewTextInput_Email(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length >= 15)
            {
                e.Handled = true; // Предотвращаем ввод символов, если длина текста достигла 4
            }
        }

        private void TextBox_PreviewTextInput_Login(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length >= 10)
            {
                e.Handled = true; // Предотвращаем ввод символов, если длина текста достигла 4
            }
        }


    }
}
