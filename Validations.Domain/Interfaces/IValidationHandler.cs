using System.Linq;
using System.Text.RegularExpressions;
using Validations.Domain.Entities;

namespace Validations.Domain.Interfaces
{
    public interface IValidationHandler
    {
        public bool Validate(ValidationContext context);

    }
}
