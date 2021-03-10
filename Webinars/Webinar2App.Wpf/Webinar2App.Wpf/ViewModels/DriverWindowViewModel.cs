﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Webinar2App.Wpf.Services.Dialogs;
using Webinar2App.Wpf.Util;

namespace Webinar2App.Wpf.ViewModels
{
    // Будет работать Fody.PropertyChanged:

    class DriverWindowViewModel : IDialogViewModel, IDataErrorInfo, INotifyPropertyChanged
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Range(1, 100)]
        public int ExperienceYears { get; set; }
        [Required]
        public string CarMake { get; set; }
        [Required]
        public string CarModel { get; set; }
        [Required]
        [RegularExpression(@"[z-zA-Z]\d{3}[a-zA-Z]{2}", ErrorMessage = "Examples: A123BC, X705QA, etc.")]
        public string CarNo { get; set; }
        public string CarColor { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool? DialogResult { get; set; }

        public ICommand OkCommand { get; }


        public DriverWindowViewModel()
        {
            OkCommand = new RelayCommand(() =>
            {
                if (Error == null)
                {
                    DialogResult = true;
                }
            });
        }


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
    }

    // без DataAnnotations писали бы так:

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
