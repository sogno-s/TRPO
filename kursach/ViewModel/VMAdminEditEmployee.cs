using DocumentFormat.OpenXml.Wordprocessing;
using kursach.Model;
using kursach.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace kursach.ViewModel
{
    public class VMAdminEditEmployee : INotifyPropertyChanged
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

        private ObservableCollection<Employee> _employees;
        private Employee _selectedEmployee;

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                if (_selectedEmployee != null)
                {
                    var pas = ModelPublic.GetContext().Pasports.FirstOrDefault(f => f.Idpasport == SelectedEmployee.Idpasport);
                    //Seria = pas.Seria;
                    //Numberp = pas.Numberp;
                    Firstname = _selectedEmployee.Firstname;
                    Lastname = _selectedEmployee.Lastname;
                    Phonenumber = _selectedEmployee.Phonenumber;
                    Idspecialization = _selectedEmployee.Idspecialization;
                    Login = _selectedEmployee.Login;
                    Email = _selectedEmployee.Email;
                    Passworde = _selectedEmployee.Passworde;
                }
                else
                {
                    ClearFields();
                }
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }
        private void ClearFields()
        {
            Seria = null;
            Numberp = null;
            Firstname = null;
            Lastname = null;
            Phonenumber = null;
            Idspecialization = null;
            Login = null;
            Email = null;
            Passworde = null;
        }

        public ICommand SearchCommand { get; }

        private readonly KurkurContext _employeService;
        public VMAdminEditEmployee()
        {
            var employee = ModelPublic.GetContext().Employees.ToList();

            Employees = new ObservableCollection<Employee>(employee);
            SearchCommand = new RelayCommand(obj => FilterEmployees());
        }

        private string? _passportSeries;
        public string? Seria
        {
            get { return _passportSeries; }
            set
            {
                _passportSeries = value; OnPropertyChanged();
            }
        }

        private string? _passportNumber;
        public string? Numberp
        {
            get { return _passportNumber; }
            set
            {
                _passportNumber = value; OnPropertyChanged();
            }
        }

        private string? _surname;
        public string? Surname
        {
            get { return _surname; }
            set
            {
                _surname = value; OnPropertyChanged();
            }
        }

        private string? _firstName;
        public string? Firstname
        {
            get { return _firstName; }
            set
            {
                _firstName = value; OnPropertyChanged();
            }
        }

        private string? _lastname;
        public string? Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value; OnPropertyChanged();
            }
        }

        private string? _phoneNumber;
        public string? Phonenumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value; OnPropertyChanged();
            }
        }

        private string? _specialization;
        public string? Idspecialization
        {
            get { return _specialization; }
            set
            {
                _specialization = value; OnPropertyChanged();
            }
        }

        private string? _login;
        public string? Login
        {
            get { return _login; }
            set
            {
                _login = value; OnPropertyChanged();
            }
        }

        private string? _email;
        public string? Email
        {
            get { return _email; }
            set
            {
                _email = value; OnPropertyChanged();
            }
        }

        private string? _password;
        public string? Passworde
        {
            get { return _password; }
            set
            {
                _password = value; OnPropertyChanged();
            }
        }

        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? new RelayCommand(obj =>
                {
                    if (SelectedEmployee != null)
                    {
                        var pas = ModelPublic.GetContext().Pasports.FirstOrDefault(f => f.Idpasport == SelectedEmployee.Idpasport);
                        ModelPublic.GetContext().Remove(pas);
                        ModelPublic.GetContext().SaveChanges();
                        var selemp = ModelPublic.GetContext().Employees.FirstOrDefault(f => f.Idemployee == SelectedEmployee.Idemployee);
                        ModelPublic.GetContext().Remove(selemp);
                        ModelPublic.GetContext().SaveChanges();
                        var updatedEmployees = ModelPublic.GetContext().Employees.ToList();
                        Employees = new ObservableCollection<Employee>(updatedEmployees);

                        OnPropertyChanged();
                        ClearFields();
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
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                FilterEmployees();
                OnPropertyChanged(nameof(SearchText));
            }
        }

        private void FilterEmployees()
        {
            var searchText = SearchText?.ToLower();
            var filteredEmployees = model.Employees
                .Where(e => (e.Surname != null && e.Surname.ToLower().Contains(searchText)) ||
                            (e.Lastname != null && e.Lastname.ToLower().Contains(searchText)))
                .ToList();
            Employees = new ObservableCollection<Employee>(filteredEmployees);
        }

        private RelayCommand _saveEmployeeCommand;
        public RelayCommand SaveEmployeeCommand
        {
            get
            {
                return _saveEmployeeCommand ?? new RelayCommand(obj =>
                {
                    if (SelectedEmployee != null)
                    {
                        var pas = ModelPublic.GetContext().Pasports.FirstOrDefault(f => f.Idpasport == SelectedEmployee.Idpasport);
                        if (pas != null)
                        {
                            var up = new Pasport()
                            {
                                Seria = pas.Seria,
                                Numberp = pas.Numberp,
                            };
                            ModelPublic.GetContext().SaveChanges();
                        }

                        var emp = ModelPublic.GetContext().Employees.FirstOrDefault(f => f.Idemployee == SelectedEmployee.Idemployee);
                        var upd = new Employee()
                        {
                            Surname = emp.Surname,
                            Firstname = emp.Firstname,
                            Lastname = emp.Lastname,
                            Email = emp.Email,
                            Phonenumber = emp.Phonenumber,
                            Idspecialization = emp.Idspecialization,
                            Login = emp.Login,
                            Passworde = emp.Passworde,
                        };


                        ModelPublic.GetContext().SaveChanges();
                        MessageBox.Show("Информация изменена");

                        var updatedEmployees = ModelPublic.GetContext().Employees.ToList();
                        Employees = new ObservableCollection<Employee>(updatedEmployees);
                    }
                    else
                    {
                        MessageBox.Show("Аргуметы пусты");
                    }
                });
            }
        }
    }
}
