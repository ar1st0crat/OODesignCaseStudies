using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Webinar2AppPrism.ViewModels
{
    class DriverWindowViewModel : BindableBase, IDialogAware, IDataErrorInfo
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
            set { SetProperty(ref _firstName, value); OkCommand.RaiseCanExecuteChanged(); }
        }

        [Required]
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); OkCommand.RaiseCanExecuteChanged(); }
        }

        [Required]
        [Range(1, 100)]
        public int ExperienceYears
        {
            get { return _experienceYears; }
            set { SetProperty(ref _experienceYears, value); OkCommand.RaiseCanExecuteChanged(); }
        }

        [Required]
        public string CarMake
        {
            get { return _carMake; }
            set { SetProperty(ref _carMake, value); OkCommand.RaiseCanExecuteChanged(); }
        }

        [Required]
        public string CarModel
        {
            get { return _carModel; }
            set { SetProperty(ref _carModel, value); OkCommand.RaiseCanExecuteChanged(); }
        }
        
        [Required]
        [RegularExpression(@"[a-zA-Z]\d{3}[a-zA-Z]{2}", ErrorMessage = "Examples: A123BC, X705QA, etc.")]
        public string CarNo
        {
            get { return _carNo; }
            set { SetProperty(ref _carNo, value); OkCommand.RaiseCanExecuteChanged(); }
        }

        public string CarColor { get; set; }


        #region IDialogAware implementation

        public event Action<IDialogResult> RequestClose;

        public string Title => "Edit Driver";

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        #endregion


        private DelegateCommand _okCommand;
        public DelegateCommand OkCommand => _okCommand ??= new DelegateCommand(Ok, CanOk);

        private void Ok()
        {
            var parameters = new DialogParameters { { "driver", this } };

            RaiseRequestClose(new DialogResult(ButtonResult.OK, parameters));
        }

        private bool CanOk() => Error == null;


        #region validation

        public string this[string columnName]
        {
            get
            {
                var validationResults = new List<ValidationResult>();

                var property = GetType().GetProperty(columnName);

                var validationContext = new ValidationContext(this)
                {
                    MemberName = columnName
                };

                var isValid = Validator.TryValidateProperty(property.GetValue(this), validationContext, validationResults);
                if (isValid)
                {
                    return null;
                }

                return validationResults.First().ErrorMessage;
            }
        }

        /// <summary>
        /// Строка с общим текстом ошибки валидации модели
        /// </summary>
        public string Error
        {
            get
            {
                // получаем список всех свойств автоматически через рефлексию:

                var properties = GetType().GetProperties().Where(p => p.CustomAttributes.Count() > 0);

                // пробегаемся по всем свойствам
                // и если какое-то невалидно, то текст общей ошибки валидации = текст ошибки по этому свойству

                foreach (var property in properties)
                {
                    var error = this[property.Name];

                    if (error != null)
                    {
                        return error;
                    }
                }

                return null;
            }
        }

        #endregion
    }
}
