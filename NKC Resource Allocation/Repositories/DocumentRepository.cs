using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
                    BarrelAndCO2_Res_1_Name = (model.BarrelAndCO2_Res_1_Name.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_1_Name),
                    BarrelAndCO2_Res_1_Value = (model.BarrelAndCO2_Res_1_Value.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_1_Value),
                    BarrelAndCO2_Res_2_Name = (model.BarrelAndCO2_Res_2_Name.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_2_Name),
                    BarrelAndCO2_Res_2_Value = (model.BarrelAndCO2_Res_2_Value.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_2_Value),
                    BarrelAndCO2_Res_3_Name = (model.BarrelAndCO2_Res_3_Name.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_3_Name),
                    BarrelAndCO2_Res_3_Value = (model.BarrelAndCO2_Res_3_Value.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_3_Value),
                    BarrelAndCO2_Res_4_Name = (model.BarrelAndCO2_Res_4_Name.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_4_Name),
                    BarrelAndCO2_Res_4_Value = (model.BarrelAndCO2_Res_4_Value.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_4_Value),
                    BarrelAndCO2_Res_5_Name = (model.BarrelAndCO2_Res_5_Name.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_5_Name),
                    BarrelAndCO2_Res_5_Value = (model.BarrelAndCO2_Res_5_Value.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_5_Value),
                    BarrelAndCO2_Res_6_Name = (model.BarrelAndCO2_Res_6_Name.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_6_Name),
                    BarrelAndCO2_Res_6_Value = (model.BarrelAndCO2_Res_6_Value.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_6_Value),
                    BarrelAndCO2_Res_7_Name = (model.BarrelAndCO2_Res_7_Name.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_7_Name),
                    BarrelAndCO2_Res_7_Value = (model.BarrelAndCO2_Res_7_Value.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_7_Value),
                    BarrelAndCO2_Res_8_Name = (model.BarrelAndCO2_Res_8_Name.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_8_Name),
                    BarrelAndCO2_Res_8_Value = (model.BarrelAndCO2_Res_8_Value.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_8_Value),
                    Machine_Res_1_Name = (model.Machine_Res_1_Name.IsNullOrEmpty() ? null : model.Machine_Res_1_Name),
                    Machine_Res_1_Value = (model.Machine_Res_1_Value.IsNullOrEmpty() ? null : model.Machine_Res_1_Value),
                    Machine_Res_2_Name = (model.Machine_Res_2_Name.IsNullOrEmpty() ? null : model.Machine_Res_2_Name),
                    Machine_Res_2_Value = (model.Machine_Res_2_Value.IsNullOrEmpty() ? null : model.Machine_Res_2_Value),
                    Machine_Res_3_Name = (model.Machine_Res_3_Name.IsNullOrEmpty() ? null : model.Machine_Res_3_Name),
                    Machine_Res_3_Value = (model.Machine_Res_3_Value.IsNullOrEmpty() ? null : model.Machine_Res_3_Value),
                    Machine_Res_4_Name = (model.Machine_Res_4_Name.IsNullOrEmpty() ? null : model.Machine_Res_4_Name),
                    Machine_Res_4_Value = (model.Machine_Res_4_Value.IsNullOrEmpty() ? null : model.Machine_Res_4_Value),
                    Machine_Res_5_Name = (model.Machine_Res_5_Name.IsNullOrEmpty() ? null : model.Machine_Res_5_Name),
                    Machine_Res_5_Value = (model.Machine_Res_5_Value.IsNullOrEmpty() ? null : model.Machine_Res_5_Value),
                    AuditorNRCFront_Name = (model.AuditorNRCFront_Name.IsNullOrEmpty() ? null : model.AuditorNRCFront_Name),
                    AuditorNRCFront_Value = (model.AuditorNRCFront_Value.IsNullOrEmpty() ? null : model.AuditorNRCFront_Value),
                    AuditorNRCBack_Name = (model.AuditorNRCBack_Name.IsNullOrEmpty() ? null : model.AuditorNRCBack_Name),
                    AuditorNRCBack_Value = (model.AuditorNRCBack_Value.IsNullOrEmpty() ? null : model.AuditorNRCBack_Value),
                    CreatedDate = DateTime.Now,
                    CreatedUser = model.CreatedUser
                };

                await _context.Documents.AddAsync(d);
                await _context.SaveChangesAsync();
                response.IsSuccess = true;
                response.Message = $"Documents {d.DocumentId} created successfully";
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
                    document.BarrelAndCO2_Res_1_Name = (model.BarrelAndCO2_Res_1_Name.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_1_Name);
                    document.BarrelAndCO2_Res_1_Value = (model.BarrelAndCO2_Res_1_Value.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_1_Value);
                    document.BarrelAndCO2_Res_2_Name = (model.BarrelAndCO2_Res_2_Name.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_2_Name);
                    document.BarrelAndCO2_Res_2_Value = (model.BarrelAndCO2_Res_2_Value.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_2_Value);
                    document.BarrelAndCO2_Res_3_Name = (model.BarrelAndCO2_Res_3_Name.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_3_Name);
                    document.BarrelAndCO2_Res_3_Value = (model.BarrelAndCO2_Res_3_Value.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_3_Value);
                    document.BarrelAndCO2_Res_4_Name = (model.BarrelAndCO2_Res_4_Name.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_4_Name);
                    document.BarrelAndCO2_Res_4_Value = (model.BarrelAndCO2_Res_4_Value.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_4_Value);
                    document.BarrelAndCO2_Res_5_Name = (model.BarrelAndCO2_Res_5_Name.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_5_Name);
                    document.BarrelAndCO2_Res_5_Value = (model.BarrelAndCO2_Res_5_Value.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_5_Value);
                    document.BarrelAndCO2_Res_6_Name = (model.BarrelAndCO2_Res_6_Name.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_6_Name);
                    document.BarrelAndCO2_Res_6_Value = (model.BarrelAndCO2_Res_6_Value.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_6_Value);
                    document.BarrelAndCO2_Res_7_Name = (model.BarrelAndCO2_Res_7_Name.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_7_Name);
                    document.BarrelAndCO2_Res_7_Value = (model.BarrelAndCO2_Res_7_Value.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_7_Value);
                    document.BarrelAndCO2_Res_8_Name = (model.BarrelAndCO2_Res_8_Name.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_8_Name);
                    document.BarrelAndCO2_Res_8_Value = (model.BarrelAndCO2_Res_8_Value.IsNullOrEmpty() ? null : model.BarrelAndCO2_Res_8_Value);
                    document.Machine_Res_1_Name = (model.Machine_Res_1_Name.IsNullOrEmpty() ? null : model.Machine_Res_1_Name);
                    document.Machine_Res_1_Value = (model.Machine_Res_1_Value.IsNullOrEmpty() ? null : model.Machine_Res_1_Value);
                    document.Machine_Res_2_Name = (model.Machine_Res_2_Name.IsNullOrEmpty() ? null : model.Machine_Res_2_Name);
                    document.Machine_Res_2_Value = (model.Machine_Res_2_Value.IsNullOrEmpty() ? null : model.Machine_Res_2_Value);
                    document.Machine_Res_3_Name = (model.Machine_Res_3_Name.IsNullOrEmpty() ? null : model.Machine_Res_3_Name);
                    document.Machine_Res_3_Value = (model.Machine_Res_3_Value.IsNullOrEmpty() ? null : model.Machine_Res_3_Value);
                    document.Machine_Res_4_Name = (model.Machine_Res_4_Name.IsNullOrEmpty() ? null : model.Machine_Res_4_Name);
                    document.Machine_Res_4_Value = (model.Machine_Res_4_Value.IsNullOrEmpty() ? null : model.Machine_Res_4_Value);
                    document.Machine_Res_5_Name = (model.Machine_Res_5_Name.IsNullOrEmpty() ? null : model.Machine_Res_5_Name);
                    document.Machine_Res_5_Value = (model.Machine_Res_5_Value.IsNullOrEmpty() ? null : model.Machine_Res_5_Value);
                    document.AuditorNRCFront_Name = (model.AuditorNRCFront_Name.IsNullOrEmpty() ? null : model.AuditorNRCFront_Name);
                    document.AuditorNRCFront_Value = (model.AuditorNRCFront_Value.IsNullOrEmpty() ? null : model.AuditorNRCFront_Value);
                    document.AuditorNRCBack_Name = (model.AuditorNRCBack_Name.IsNullOrEmpty() ? null : model.AuditorNRCBack_Name);
                    document.AuditorNRCBack_Value = (model.AuditorNRCBack_Value.IsNullOrEmpty() ? null : model.AuditorNRCBack_Value);
                    document.UpdatedDate = DateTime.Now;
                    document.UpdatedUser = model.UpdatedUser;

                    await _context.SaveChangesAsync();
                    response.IsSuccess = true;
                    response.Message = $"Documents {document.DocumentId} updated successfully";
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
