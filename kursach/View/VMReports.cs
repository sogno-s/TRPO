using kursach.Model;
using kursach.Modules;
using kursach.ViewModel;
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

namespace kursach.View
{
    public class VMReports : INotifyPropertyChanged
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

        private ObservableCollection<string> _reportTypes; //ТИП ОТЧЕТА(1 КОМБОБОКС
        public ObservableCollection<string> ReportTypes
        {
            get { return _reportTypes; }
            set { _reportTypes = value; OnPropertyChanged(); }
        }

        private string _selectedReportType;//ТИП ОТЧЕТА(1 КОМБОБОКС выбор
        public string SelectedReportType
        {
            get => _selectedReportType;
            set { _selectedReportType = value; OnPropertyChanged(); }
        }

        private DateTime _selectedPeriodStartDate;

        public DateTime SelectedPeriodStartDate
        {
            get { return _selectedPeriodStartDate; }
            set
            {
                _selectedPeriodStartDate = value.Date;// Извлечение только даты из DateTime    
                OnPropertyChanged();
                // Преобразование в строку
            }
        }
        public string SelectedPeriodStartDateOnly { get; set; }

        public DateTime _selectedPeriodEndDate;
        public DateTime SelectedPeriodEndDate
        {
            get { return _selectedPeriodEndDate; }
            set { _selectedPeriodEndDate = value.Date; OnPropertyChanged(); }
        }

        public string SelectedPeriodEndDateOnly { get; set; }

        private ObservableCollection<string> _exportFormats;
        public ObservableCollection<string> ExportFormats
        {
            get { return _exportFormats; }
            set { _exportFormats = value; OnPropertyChanged(); }
        }

        private string _selectedExportFormat;
        public string SelectedExportFormat
        {
            get { return _selectedExportFormat; }
            set { _selectedExportFormat = value; OnPropertyChanged(); }
        }

        public VMReports()
        {
            ReportTypes = new ObservableCollection<string>
            {
                "Не выбрано", //[0]
                "Количество продаж сделанных сотрудником", //[1]
                "Количество продаж сделанных сотрудником за период",
            };
            ExportFormats = new ObservableCollection<string>
            {
                "Не выбрано", //[0]
                "Документ Word (*.docx)|*.docx", //[1]
                "Документ Excel (*.xlsx)|*.xlsx"
            };

            var dateonly = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            // Установка значений по умолчанию
            SelectedReportType = ReportTypes[0];
            SelectedPeriodStartDate = DateTime.Today;
            SelectedPeriodEndDate = DateTime.Today;
            SelectedExportFormat = ExportFormats[0];

        }

        private RelayCommand _generateReportCommand;
        public RelayCommand GenerateReportCommand
        {
            get
            {
                return _generateReportCommand ?? new RelayCommand(obj =>
                {
                    if (SelectedReportType != null && SelectedExportFormat != null)
                    {
                        switch (SelectedReportType)
                        {
                            case "Количество продаж сделанных сотрудником":
                                if (SelectedExportFormat == "Документ Word (*.docx)|*.docx")
                                {
                                    var Idsave = Reserv.IdPerson;
                                    CreateReportsHelper.GenerateSalesReportByEmployeeDOCX(Idsave);
                                }
                                else
                                {
                                    var Idsave = Reserv.IdPerson;
                                    CreateReportsHelperEX.GenerateSalesReportByEmployeeExcel(Idsave);
                                }
                                break;
                            case "Количество продаж сделанных сотрудником за период":
                                if (SelectedPeriodStartDate != null && SelectedPeriodEndDate != null && SelectedExportFormat != null)
                                {
                                    SelectedPeriodStartDateOnly = SelectedPeriodStartDate.ToString("yyyy-MM-dd");
                                    SelectedPeriodEndDateOnly = SelectedPeriodEndDate.ToString("yyyy-MM-dd");
                                    if (SelectedExportFormat == "Документ Word (*.docx)|*.docx")
                                    {
                                        var Idsave = Reserv.IdPerson;
                                        CreateReportsHelper.GenerateSalesReportByEmployeeWithPeriodDOCX(Idsave, SelectedPeriodStartDate, SelectedPeriodEndDate);
                                    }
                                    else
                                    {
                                        var Idsave = Reserv.IdPerson;
                                        CreateReportsHelperEX.GenerateSalesReportByEmployeeWithPeriodExcel(Idsave, SelectedPeriodStartDate, SelectedPeriodEndDate);
                                    }
                                }
                                break;
                            default:
                                break;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Не выбраны аргументы");
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
                    Main m = new Main();
                    m.Show();
                    Window window = (Window)obj;
                    window.Close();
                });
            }
        }
    }
}
