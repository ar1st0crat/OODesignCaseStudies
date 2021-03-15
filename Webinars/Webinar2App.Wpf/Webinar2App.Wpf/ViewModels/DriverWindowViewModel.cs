using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Webinar2App.Wpf.Util;
using Webinar2App.Wpf.Util.Dialogs;

namespace Webinar2App.Wpf.ViewModels
{
    // 1) INotifyDataErrorInfo (не как в видео)
    // 2) Будет работать Fody.PropertyChanged:

    class DriverWindowViewModel : IDialogViewModel, INotifyDataErrorInfo, INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private int _experienceYears;
        private string _carMake;
        private string _carModel;
        private string _carNo;

        [Required]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OkCommand.OnCanExecuteChanged();
            }
        }

        [Required]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OkCommand.OnCanExecuteChanged();
            }
        }

        [Required]
        [Range(1, 100)]
        public int ExperienceYears
        {
            get { return _experienceYears; }
            set
            {
                _experienceYears = value;
                OkCommand.OnCanExecuteChanged();
            }
        }

        [Required]
        public string CarMake
        {
            get { return _carMake; }
            set
            {
                _carMake = value;
                OkCommand.OnCanExecuteChanged();
            }
        }

        [Required]
        public string CarModel
        {
            get { return _carModel; }
            set
            {
                _carModel = value;
                OkCommand.OnCanExecuteChanged();
            }
        }

        [Required]
        [RegularExpression(@"[a-zA-Z]\d{3}[a-zA-Z]{2}", ErrorMessage = "Examples: A123BC, X705QA, etc.")]
        public string CarNo
        {
            get { return _carNo; }
            set
            {
                _carNo = value;
                OkCommand.OnCanExecuteChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool? DialogResult { get; set; }

        public RelayCommand OkCommand { get; }


        public DriverWindowViewModel()
        {
            OkCommand = new RelayCommand(Ok, CanOk);
        }

        public void Ok()
        {
            DialogResult = true;
        }

        public bool CanOk()
        {
            return !HasErrors;
        }


        #region INotifyDataErrorInfo implementation

        public IEnumerable GetErrors(string propertyName)
        {
            var validationResults = new List<ValidationResult>();

            var property = GetType().GetProperty(propertyName);

            var validationContext = new ValidationContext(this)
            {
                MemberName = propertyName
            };

            var isValid = Validator.TryValidateProperty(property.GetValue(this), validationContext, validationResults);
            if (isValid)
            {
                return null;
            }

            return validationResults;
        }

        public bool HasErrors
        {
            get
            {
                // получаем список всех свойств автоматически через рефлексию:

                var properties = GetType().GetProperties().Where(p => p.CustomAttributes.Count() > 0);

                // пробегаемся по всем свойствам
                // и если какое-то невалидно, то текст общей ошибки валидации = текст ошибки по этому свойству

                foreach (var property in properties)
                {
                    var error = GetErrors(property.Name);

                    if (error != null)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        #endregion
    }


    // без DataAnnotations (и с интерфейсом IDataErrorInfo) писали бы так:

    //public string this[string columnName]
    //{
    //    get
    //    {
    //        string error = null;

    //        switch (columnName)
    //        {
    //            case "FirstName":
    //                if (string.IsNullOrWhiteSpace(FirstName))
    //                    return "Empty first name!";
    //                break;

    //            case "LastName":
    //                if (string.IsNullOrWhiteSpace(LastName))
    //                    return "Empty last name!";
    //                break;

    //            // и другие поля ...
    //        }

    //        return error;
    //    }
    //}


}
