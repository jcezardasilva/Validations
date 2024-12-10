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
    public class CompáreRuleValidationHandler : IValidationHandler
    {
        public bool Validate(ValidationContext context)
        {
            var result = context.Rule.Operator switch
            {
                "CONTAINS" => context.Rule.Variable.Contains(context.Rule.VariableB),
                "NOT CONTAINS" => !context.Rule.Variable.Contains(context.Rule.VariableB),
                "EQUAL" => context.Rule.Variable == context.Rule.VariableB,
                "DIFFERENT" => context.Rule.Variable != context.Rule.VariableB,
                "IN" => context.Rule.Variable.Contains(context.Rule.VariableB),
                "NOT IN" => !context.Rule.Variable.Contains(context.Rule.VariableB),
                "STARTS WITH" => context.Rule.Variable.StartsWith(context.Rule.VariableB),
                "NOT STARTS WITH" => !context.Rule.Variable.StartsWith(context.Rule.VariableB),
                "ENDS WITH" => context.Rule.Variable.EndsWith(context.Rule.VariableB),
                "NOT ENDS WITH" => !context.Rule.Variable.EndsWith(context.Rule.VariableB),
                "MATCHES" => new Regex(context.Rule.Variable).IsMatch(context.Rule.VariableB),
                "NOT MATCHES" => !new Regex(context.Rule.Variable).IsMatch(context.Rule.VariableB),
                _ => throw new Exception("Conditional operator not recognized."),
            };
            return result && !context.Rule.Negative;
        }
    }
}
