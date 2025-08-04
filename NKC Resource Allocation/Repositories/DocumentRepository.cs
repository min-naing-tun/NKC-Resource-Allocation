using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NKC_Resource_Allocation.Database.Helper;
using NKC_Resource_Allocation.DbModels;
using System.Data;

namespace NKC_Resource_Allocation.Repositories
{
    public class DocumentRepository
    {
        private readonly NKC_DbContext _context;
        private readonly QueryHelper _queryHelper;

        public DocumentRepository(NKC_DbContext context, QueryHelper queryHelper)
        {
            _context = context;
            _queryHelper = queryHelper;
        }

        public async Task<DataTable> GetAllAsync()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = await _queryHelper.GetDataTableAsync("select * from Documents", new List<SqlParameter>().ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving", ex);
            }
            return dataTable;
        }

        public async Task<Documents?> GetByIdAsync(string id)
        {
            try
            {
                Documents? model = await _context.Documents.FromSqlRaw($"select * from Documents where DocumentId = @id", new SqlParameter("@id", id)).FirstOrDefaultAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving with ID {id}", ex);
            }
        }

        public async Task<ResponseModel> CreateAsync(Documents model)
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

                Documents d = new Documents()
                {
                    DocumentId = "d_" + Guid.NewGuid().ToString().Substring(0, 20),
                    AuditorId = model.AuditorId,
                    OutletId = model.OutletId,
                    BarrelAndCO2_Res_1 = model.BarrelAndCO2_Res_1,
                    BarrelAndCO2_Res_2 = model.BarrelAndCO2_Res_2,
                    BarrelAndCO2_Res_3 = model.BarrelAndCO2_Res_3,
                    BarrelAndCO2_Res_4 = model.BarrelAndCO2_Res_4,
                    BarrelAndCO2_Res_5 = model.BarrelAndCO2_Res_5,
                    BarrelAndCO2_Res_6 = model.BarrelAndCO2_Res_6,
                    BarrelAndCO2_Res_7 = model.BarrelAndCO2_Res_7,
                    BarrelAndCO2_Res_8 = model.BarrelAndCO2_Res_8,
                    Machine_Res_1 = model.Machine_Res_1,
                    Machine_Res_2 = model.Machine_Res_2,
                    Machine_Res_3 = model.Machine_Res_3,
                    Machine_Res_4 = model.Machine_Res_4,
                    Machine_Res_5 = model.Machine_Res_5,
                    AuditorNRCFront = model.AuditorNRCFront,
                    AuditorNRCBack = model.AuditorNRCBack,
                    CreatedDate = DateTime.Now,
                    CreatedUser = model.CreatedUser
                };

                await _context.Documents.AddAsync(d);
                await _context.SaveChangesAsync();
                response.IsSuccess = true;
                response.Message = "Documents created successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error creating : {ex.Message}";
            }
            return response;
        }

        public async Task<ResponseModel> UpdateAsync(Documents model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Documents? document = await _context.Documents.FromSqlRaw($"select * from Documents where DocumentId = @dId", new SqlParameter("@dId", model.DocumentId)).FirstOrDefaultAsync();
                if (document == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }
                else
                {
                    document.AuditorId = model.AuditorId;
                    document.OutletId = model.OutletId;
                    document.BarrelAndCO2_Res_1 = model.BarrelAndCO2_Res_1;
                    document.BarrelAndCO2_Res_2 = model.BarrelAndCO2_Res_2;
                    document.BarrelAndCO2_Res_3 = model.BarrelAndCO2_Res_3;
                    document.BarrelAndCO2_Res_4 = model.BarrelAndCO2_Res_4;
                    document.BarrelAndCO2_Res_5 = model.BarrelAndCO2_Res_5;
                    document.BarrelAndCO2_Res_6 = model.BarrelAndCO2_Res_6;
                    document.BarrelAndCO2_Res_7 = model.BarrelAndCO2_Res_7;
                    document.BarrelAndCO2_Res_8 = model.BarrelAndCO2_Res_8;
                    document.Machine_Res_1 = model.Machine_Res_1;
                    document.Machine_Res_2 = model.Machine_Res_2;
                    document.Machine_Res_3 = model.Machine_Res_3;
                    document.Machine_Res_4 = model.Machine_Res_4;
                    document.Machine_Res_5 = model.Machine_Res_5;
                    document.AuditorNRCFront = model.AuditorNRCFront;
                    document.AuditorNRCBack = model.AuditorNRCBack;
                    document.UpdatedDate = DateTime.Now;
                    document.UpdatedUser = model.UpdatedUser;

                    await _context.SaveChangesAsync();
                    response.IsSuccess = true;
                    response.Message = "Document updated successfully";
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
                Documents? document = await _context.Documents.FromSqlRaw($"select * from Documents where DocumentId = @dId", new SqlParameter("@dId", id)).FirstOrDefaultAsync();
                if (document != null)
                {
                    _context.Documents.Remove(document);
                    await _context.SaveChangesAsync();
                }
                response.IsSuccess = true;
                response.Message = "Document deleted successfully";
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
