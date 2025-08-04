using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NKC_Resource_Allocation.DbModels;
using NKC_Resource_Allocation.Repositories;
using System.Data;

namespace NKC_Resource_Allocation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuditorsController : ControllerBase
    {
        AuditorRepository _repo;

        public AuditorsController(AuditorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            DataTable dt = await _repo.GetAllAsync();
            return Ok(dt);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            Auditors? o = await _repo.GetByIdAsync(id);
            return Ok(o);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Auditors o)
        {
            return Ok(await _repo.CreateAsync(o));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Auditors o)
        {
            return Ok(await _repo.UpdateAsync(o));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _repo.DeleteAsync(id));
        }
    }
}
