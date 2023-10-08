using DocumentFormat.OpenXml.Drawing;
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
using System.Windows.Controls;
using System.Windows.Input;

namespace kursach.ViewModel
{
    public class VMAdminAddEmployee : INotifyPropertyChanged
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

        private string? _passportSeries;
        public string? PassportSeries
        {
            get { return _passportSeries; }
            set
            {
                _passportSeries = value; OnPropertyChanged();
            }
        }

        private string? _passportNumber;
        public string? PassportNumber
        {
            get { return _passportNumber; }
            set
            {
                _passportNumber = value; OnPropertyChanged();
            }
        }
       
        private string? _lastName;
        public string? LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value; OnPropertyChanged();
            }
        }

        private string? _firstName;
        public string? FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value; OnPropertyChanged();
            }
        }

        private string? _middleName;
        public string? MiddleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value; OnPropertyChanged();
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

        private string? _phoneNumber;
        public string? PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value; OnPropertyChanged();
            }
        }

        private string? _specialization;
        public string? Specialization
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

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value.Date;
                DateOfBirthday = value.Date.ToString("yyyy-MM-dd"); OnPropertyChanged();
            }
        }

        private string? _password;
        public string? Password
        {
            get { return _password; }
            set
            {
                _password = value; OnPropertyChanged();
            }
        }

        public string DateOfBirthday { get; set; }

        private RelayCommand _addEmployeeCommand;
        public RelayCommand AddEmployeeCommand
        {
            get
            {
                return _addEmployeeCommand ?? new RelayCommand(obj =>
                {
                    if (_passportSeries != null && _passportNumber != null)
                    {
                        var passport = new Pasport()
                        {
                            Seria = _passportSeries,
                            Numberp = _passportNumber
                        };
                        var dbContext = ModelPublic.GetContext();
                        dbContext.Pasports.Add(passport);
                        dbContext.SaveChanges();
                        int idPass = passport.Idpasport;
                        if (_middleName != null && _firstName != null && _lastName != null && _specialization != null && _dateOfBirth != null && _password != null && _login != null)
                        {
                            var birthDate = DateTime.ParseExact(DateOfBirthday, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            var employee = new Employee()
                            {
                                Surname = _lastName,
                                Firstname = _firstName,
                                Lastname = _middleName,
                                Phonenumber = _phoneNumber,
                                Email = _email,
                                Idspecialization = _specialization,
                                Dateofbirthday = new DateOnly(birthDate.Year, birthDate.Month, birthDate.Day),
                                Idpasport = idPass,
                                Login = _login,
                                Passworde = _password
                            };

                            dbContext.Employees.Add(employee);
                            dbContext.SaveChanges();
                            MessageBox.Show("Сотрудник зарегистрирован");
                        }
                        else
                        {
                            MessageBox.Show("Аргументы пусты");
                        }

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
