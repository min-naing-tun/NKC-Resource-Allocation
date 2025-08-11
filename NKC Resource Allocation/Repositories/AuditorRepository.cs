using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NKC_Resource_Allocation.Database.Helper;
using NKC_Resource_Allocation.DbModels;
using System.Data;

namespace NKC_Resource_Allocation.Repositories
{
    public class AuditorRepository
    {
        private readonly NKC_DbContext _context;
        private readonly QueryHelper _queryHelper;

        public AuditorRepository(NKC_DbContext context, QueryHelper queryHelper)
        {
            _context = context;
            _queryHelper = queryHelper;
        }

        public async Task<DataTable> GetAllAsync()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = await _queryHelper.GetDataTableAsync("select * from Auditors", new List<SqlParameter>().ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving", ex);
            }
            return dataTable;
        }

        public async Task<Auditors?> GetByIdAsync(string id)
        {
            try
            {
                Auditors? model = await _context.Auditors.FromSqlRaw($"select * from Auditors where AuditorId = @id", new SqlParameter("@id", id)).FirstOrDefaultAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving with ID {id}", ex);
            }
        }

        public async Task<ResponseModel> CreateAsync(Auditors model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (model == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Model cannot be null";
                    return response;
                }

                Auditors a = new Auditors()
                {
                    AuditorId = "a_" + Guid.NewGuid().ToString().Substring(0, 20),
                    AuditorName = model.AuditorName,
                    AuditorNRC = model.AuditorNRC,
                    PhoneNumber = model.PhoneNumber,
                    NKCAuditDate = model.NKCAuditDate,
                    Remark = model.Remark,
                    CreatedDate = DateTime.Now,
                    CreatedUser = model.CreatedUser
                };

                await _context.Auditors.AddAsync(a);
                await _context.SaveChangesAsync();
                response.IsSuccess = true;
                response.Message = $"Auditor {a.AuditorId} created successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error creating : {ex.Message}";
            }
            return response;
        }

        public async Task<ResponseModel> UpdateAsync(Auditors model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Auditors? auditor = await _context.Auditors.FromSqlRaw($"select * from Auditors where AuditorId = @aId", new SqlParameter("@aId", model.AuditorId)).FirstOrDefaultAsync();
                if (auditor == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }
                else
                {
                    auditor.AuditorName = model.AuditorName;
                    auditor.AuditorNRC = model.AuditorNRC;
                    auditor.PhoneNumber = model.PhoneNumber;
                    auditor.NKCAuditDate = model.NKCAuditDate;
                    auditor.Remark = model.Remark;
                    auditor.UpdatedDate = DateTime.Now;
                    auditor.UpdatedUser = model.UpdatedUser;

                    await _context.SaveChangesAsync();
                    response.IsSuccess = true;
                    response.Message = "Auditor updated successfully";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error updating: {ex.Message}";
            }

            return response;
        }

        public async Task<ResponseModel> DeleteAsync(string id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Auditors? auditors = await _context.Auditors.FromSqlRaw($"select * from Auditors where AuditorId = @aId", new SqlParameter("@aId", id)).FirstOrDefaultAsync();
                if (auditors != null)
                {
                    _context.Auditors.Remove(auditors);
                    await _context.SaveChangesAsync();
                }
                response.IsSuccess = true;
                response.Message = "Auditor deleted successfully";
            }
            catch (DbUpdateException ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error deleting: {ex.Message}";
            }
            return response;
        }
    }
}
