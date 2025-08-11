using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NKC_Resource_Allocation.DbModels;
using NKC_Resource_Allocation.Repositories;
using System.Data;

namespace NKC_Resource_Allocation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        FormRepository _repo;
        public FormController(FormRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _repo.GetAllAsync().Result;
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetFormInitData()
        {
            var data = _repo.GetDataForFormInit().Result;
            return Ok(data);
        }
    }
}
