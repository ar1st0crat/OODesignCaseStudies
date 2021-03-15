using Caliburn.Micro;
using System.Linq;
using System.ComponentModel;
using Webinar2App.Caliburn.ViewModels.Validators;


namespace Webinar2App.Caliburn.ViewModels
{
    class DriverWindowViewModel : Screen, IDataErrorInfo
    {
        private readonly DriverViewModelValidator _validator = new DriverViewModelValidator();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ExperienceYears { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
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
                var validationErrors = _validator.Validate(this).Errors;

                if (!validationErrors.Any(e => e.PropertyName == columnName))
                {
                    return null;
                }

                return validationErrors
                            .First(e => e.PropertyName == columnName)
                            .ErrorMessage;
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

                var properties = GetType().GetProperties().Where(p => p.CanWrite);

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
