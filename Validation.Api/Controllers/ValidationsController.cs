using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Validation.Core.Handlers;
using Validations.Domain.Entities.Rules;
using Validations.Domain.Interfaces;
using Validations.Repository.MongoDB;
using Validations.Domain.Entities;

namespace Validation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationsController : ControllerBase
    {
        private readonly RuleValidationHandler _ruleValidationHandler;
        private readonly IRepository<RuleEntity> _ruleRepository;
        public ValidationsController(IRepository<RuleEntity> ruleRepository)
        {
            _ruleValidationHandler = new RuleValidationHandler();
            _ruleRepository = ruleRepository;
        }
        [HttpPost]
        public async Task<IActionResult> ValidateAsync()
        {
            TestEntity? entity = null;
            var rules = await _ruleRepository.ListAsync();

            var result = _ruleValidationHandler.Validate(new ValidationContext()
            {
                Data = entity,
                Rule = rules.First()
            });
            return Ok(result);
        }
    }
}
