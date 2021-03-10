using Caliburn.Micro;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Webinar2App.Caliburn.ViewModels
{
    class DriverWindowViewModel : Screen, IDataErrorInfo
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


        public void OK()
        {
            if (Error == null)
            {
                TryClose(true);
            }
        }


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
