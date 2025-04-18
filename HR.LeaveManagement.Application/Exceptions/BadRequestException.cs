using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Exceptions
{
    public class BadRequestException : Exception 
    {
        public BadRequestException(string message) : base(message)
        {
            
        }
        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            ValidationErros = validationResult.ToDictionary();

            //foreach (var error in validationResult.Errors)
            //{
            //    ValidationErros.Add(error.ErrorMessage);
            //}
        }

        public IDictionary<string, string[]> ValidationErros { get; set; }
    }
}
