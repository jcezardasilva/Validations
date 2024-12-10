using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Validations.Domain.Entities;
using Validations.Domain.Interfaces;

namespace Validation.Core.Handlers
{
    public class RuleValidationHandler : IValidationHandler
    {
        public bool Validate(ValidationContext context)
        {
            var result = context.Rule.Operator switch
            {
                "IS NULL" => context.Data == null,
                "IS EMPTY" => context.Data == string.Empty,
                "IS NUMBER" => int.TryParse(context.Data.ToString(), out _),
                _ => throw new Exception("Conditional operator not recognized."),
            };
            return result && !context.Rule.Negative;
        }
    }
}
