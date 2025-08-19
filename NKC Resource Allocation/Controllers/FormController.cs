using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NKC_Resource_Allocation.Database.Helper;
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
        public async Task<IActionResult> GetAll()
        {
            var data = await _repo.GetAllAsync();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetFormInitData()
        {
            var data = await _repo.GetDataForFormInit();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetForm(string outletId, string auditorId, string doucumentId)
        {
            var data = await _repo.GetFormDetailAsync(outletId, auditorId, doucumentId);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetFormList(DateTime? startDate, DateTime? endDate, string? searchText)
        {
            DataTable dt = await _repo.GetByFilterAsync(startDate, endDate, searchText);
            return Ok(dt);
        }

        [HttpGet]
        public async Task<IActionResult> GetFormListPaging(int pageNo, int rowLimit, DateTime? startDate, DateTime? endDate, string? searchText)
        {
            DataTable dt = await _repo.GetByFilterPagingAsync(pageNo, rowLimit, startDate, endDate, searchText);
            return Ok(dt);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string documentId, string auditorId, string outletId)
        {
            ResponseModel res = await _repo.DeleteFormRecordAsync(documentId, auditorId, outletId);
            return Ok(res);
        }
    }
}
