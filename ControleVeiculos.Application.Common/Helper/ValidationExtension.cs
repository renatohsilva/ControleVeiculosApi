using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace ControleVeiculos.Application.Common.Helper
{
    public static class ValidationExtension
    {
        public static IEnumerable<string> ToListValidationFailureString(this IEnumerable<ValidationFailure> Errors)
        {
            if (Errors != null && Errors.Any())
            {
                return Errors.Select(item => item.ErrorMessage);
            }
            return new List<string>();
        }
    }
}
