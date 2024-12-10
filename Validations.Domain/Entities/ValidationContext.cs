using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validations.Domain.Entities.Rules;

namespace Validations.Domain.Entities
{
    public class ValidationContext
    {
        public RuleEntity Rule {  get; set; } = new RuleEntity();
        public object? Data { get; set; }
    }
}
