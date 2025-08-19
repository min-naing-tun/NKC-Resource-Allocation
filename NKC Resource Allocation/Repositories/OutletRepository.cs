using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NKC_Resource_Allocation.Database.Helper;
using NKC_Resource_Allocation.DbModels;
using System.Data;

namespace NKC_Resource_Allocation.Repositories
{
    public class OutletRepository
    {
        private readonly NKC_DbContext _context;
        private readonly QueryHelper _queryHelper;

        public OutletRepository(NKC_DbContext context, QueryHelper queryHelper)
        {
            _context = context;
            _queryHelper = queryHelper;
        }

        public async Task<DataTable> GetAllAsync()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = await _queryHelper.GetDataTableAsync("select * from Outlets", new List<SqlParameter>().ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving", ex);
            }
            return dataTable;
        }

        public async Task<Outlets?> GetByIdAsync(string id)
        {
            try
            {
                Outlets? model = await _context.Outlets.FromSqlRaw($"select * from Outlets where OutletId = @oId", new SqlParameter("@oId", id)).FirstOrDefaultAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving with ID {id}", ex);
            }
        }

        public async Task<ResponseModel> CreateAsync(Outlets outlet)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (outlet == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Outlet cannot be null";
                    return response;
                }

                Outlets o = new Outlets()
                {
                    OutletSerialNo = outlet.OutletSerialNo,
                    OutletId = "o_" + Guid.NewGuid().ToString().Substring(0, 20),
                    OutletName = outlet.OutletName,
                    OutletCode = outlet.OutletCode,
                    Brand = outlet.Brand,
                    CreatedDate = DateTime.Now,
                    CreatedUser = outlet.CreatedUser
                };

                await _context.Outlets.AddAsync(o);
                await _context.SaveChangesAsync();
                response.IsSuccess = true;
                response.Message = $"Outlet {o.OutletId} created successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error creating outlet: {ex.Message}";
            }
            return response;
        }

        public async Task<ResponseModel> UpdateAsync(Outlets outlets)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Outlets? outlet = await _context.Outlets.FromSqlRaw($"select * from Outlets where OutletId = @oId", new SqlParameter("@oId", outlets.OutletId)).FirstOrDefaultAsync();
                if(outlet == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Outlet not found";
                    return response;
                }
                else
                {
                    //outlet.OutletCode = "o_" + Guid.NewGuid().ToString().Substring(0, 10);
                    outlet.OutletSerialNo = outlets.OutletSerialNo;
                    outlet.OutletName = outlets.OutletName;
                    outlet.OutletCode = outlets.OutletCode;
                    outlet.Brand = outlets.Brand;
                    outlet.UpdatedDate = DateTime.Now;
                    outlet.UpdatedUser = outlets.UpdatedUser;
                    
                    await _context.SaveChangesAsync();
                    response.IsSuccess = true;
                    response.Message = $"Outlet {outlet.OutletId} updated successfully";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error updating outlet: {ex.Message}";
            }

            return response;
        }

        public async Task<ResponseModel> DeleteAsync(string id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var outlet = await _context.Outlets.FindAsync(id);
                if (outlet != null)
                {
                    _context.Outlets.Remove(outlet);
                    await _context.SaveChangesAsync();
                }
                response.IsSuccess = true;
                response.Message = "Outlet deleted successfully";
            }
            catch (DbUpdateException ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error deleting outlet: {ex.Message}";
            }
            return response;
        }
    }
}
