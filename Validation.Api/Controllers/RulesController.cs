using Microsoft.AspNetCore.Mvc;
using Validations.Domain.Entities.Rules;
using Validations.Repository.MongoDB;

namespace Validation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesController(IRepository<RuleEntity> repository) : ControllerBase
    {
        private readonly IRepository<RuleEntity> _repository = repository;
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _repository.ListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            return Ok(await _repository.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(RuleEntity entity)
        {
            await _repository.AddAsync(entity);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, RuleEntity entity)
        {
            await _repository.UpdateAsync(entity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }
    }
}
