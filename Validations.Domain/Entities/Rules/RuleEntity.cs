using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validations.Domain.Entities.Rules
{
    public class RuleEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Variable { get; set; } = string.Empty;
        public string? VariableB { get; set; }
        public string Operator {  get; set; } = string.Empty;
        public bool Negative { get; set; } = false;
    }
}
