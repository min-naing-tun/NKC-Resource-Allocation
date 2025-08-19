using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NKC_Resource_Allocation.Database.CoreService;
using NKC_Resource_Allocation.Database.Helper;
using NKC_Resource_Allocation.DbModels;
using NKC_Resource_Allocation.ViewModels;
using System.Collections.Generic;
using System.Data;

namespace NKC_Resource_Allocation.Repositories
{
    public class FormRepository
    {
        private readonly NKC_DbContext _context;
        private readonly QueryHelper _queryHelper;
        private readonly CoreService _coreService;
        public FormRepository(NKC_DbContext context, QueryHelper queryHelper, CoreService coreService)
        {
            _context = context;
            _queryHelper = queryHelper;
            _coreService = coreService;
        }

        public async Task<DataTable> GetAllAsync()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = await _queryHelper.GetDataTableAsync("select * from Forms", new List<SqlParameter>().ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving forms", ex);
            }
            return dataTable;
        }

        public async Task<DataTable> GetDataForFormInit()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = await _queryHelper.GetDataTableAsync(@"SELECT
                                                                    ISNULL((
                                                                        SELECT TOP 1 OutletSerialNo
                                                                        FROM Outlets
                                                                        ORDER BY OutletSerialNo DESC
                                                                    ), 0) + 1 AS NewSerialNo", new List<SqlParameter>().ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving.", ex);
            }
            return dataTable;
        }

        public async Task<FormDetailViewModel> GetFormDetailAsync(string outletId, string auditorId, string documentId)
        {
            FormDetailViewModel model = new FormDetailViewModel();

            try
            {
                Outlets? o = await _context.Outlets.FromSqlRaw("select * from Outlets where OutletId = @oId", new SqlParameter("@oId", outletId)).SingleOrDefaultAsync();

                Auditors? a = await _context.Auditors.FromSqlRaw("select * from Auditors where AuditorId = @aId", new SqlParameter("@aId", auditorId)).SingleOrDefaultAsync();

                Documents? d = await _context.Documents.FromSqlRaw("select * from Documents where DocumentId = @dId", new SqlParameter("@dId", documentId)).SingleOrDefaultAsync();

                if(o != null && a != null && d != null)
                {
                    model.outlet = o;
                    model.auditor = a;
                    model.document = d;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving.", ex);
            }

            return model;
        }

        public async Task<DataTable> GetByFilterAsync(DateTime? startDate, DateTime? endDate, string? searchString)
        {
            DataTable dt = new DataTable();

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string filterQuery = " 1=1";

                #region Filter query build
                if(startDate != null && endDate != null)
                {
                    filterQuery += " AND a.NKCAuditDate BETWEEN @startDate AND @endDate";
                    parameters.Add(new SqlParameter("@startDate", startDate));
                    parameters.Add(new SqlParameter("@endDate", endDate));
                }
                if (!string.IsNullOrEmpty(searchString))
                {
                    filterQuery += @" AND (
                                        o.OutletSerialNo LIKE @searchString OR
                                        o.OutletName LIKE @searchString OR
                                        o.OutletCode LIKE @searchString OR
                                        o.Brand LIKE @searchString OR
                                        a.AuditorName LIKE @searchString OR
                                        a.AuditorNRC LIKE @searchString OR
                                        a.PhoneNumber LIKE @searchString OR
                                        a.NKCAuditDate LIKE @searchString OR
                                        a.Remark LIKE @searchString
                                      )";
                    parameters.Add(new SqlParameter("@searchString", searchString));
                }
                #endregion

                string sql = @"select 
								o.OutletId, a.AuditorId, d.DocumentId,
                                o.OutletSerialNo, o.OutletName, o.OutletCode, o.Brand,
                                a.AuditorName, a.AuditorNRC, a.PhoneNumber,
                                a.NKCAuditDate, a.Remark, 
                                d.BarrelAndCO2_Res_1_Name,
                                d.BarrelAndCO2_Res_1_Value,
                                d.BarrelAndCO2_Res_2_Name,
                                d.BarrelAndCO2_Res_2_Value,
                                d.BarrelAndCO2_Res_3_Name,
                                d.BarrelAndCO2_Res_3_Value,
                                d.BarrelAndCO2_Res_4_Name,
                                d.BarrelAndCO2_Res_4_Value,
                                d.BarrelAndCO2_Res_5_Name,
                                d.BarrelAndCO2_Res_5_Value,
                                d.BarrelAndCO2_Res_6_Name,
                                d.BarrelAndCO2_Res_6_Value,
                                d.BarrelAndCO2_Res_7_Name,
                                d.BarrelAndCO2_Res_7_Value,
                                d.BarrelAndCO2_Res_8_Name,
                                d.BarrelAndCO2_Res_8_Value,
                                d.Machine_Res_1_Name,
                                d.Machine_Res_1_Value,
                                d.Machine_Res_2_Name,
                                d.Machine_Res_2_Value,
                                d.Machine_Res_3_Name,
                                d.Machine_Res_3_Value,
                                d.Machine_Res_4_Name,
                                d.Machine_Res_4_Value,
                                d.Machine_Res_5_Name,
                                d.Machine_Res_5_Value,
                                d.AuditorNRCFront_Name,
                                d.AuditorNRCFront_Value,
                                d.AuditorNRCBack_Name,
                                d.AuditorNRCBack_Value
                               from Documents d
                               inner join Auditors a on a.AuditorId = d.AuditorId
                               inner join Outlets o on o.OutletId = d.OutletId
                               WHERE " + filterQuery + " ORDER BY d.CreatedDate";

                dt = await _queryHelper.GetDataTableAsync(sql, parameters.ToArray());

            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving", ex);
            }

            return dt;
        }

        public async Task<DataTable> GetByFilterPagingAsync(int pageNo, int rowLimit, DateTime? startDate, DateTime? endDate, string? searchString)
        {
            DataTable dt = new DataTable();

            try
            {
                int offsetRowNo = _coreService.GetOffsetRow(pageNo, rowLimit);
                List<SqlParameter> parameters = new List<SqlParameter>();
                string filterQuery = " 1=1";

                #region Filter query build
                if (startDate != null && endDate != null)
                {
                    filterQuery += " AND a.NKCAuditDate BETWEEN @startDate AND @endDate";
                    parameters.Add(new SqlParameter("@startDate", startDate));
                    parameters.Add(new SqlParameter("@endDate", endDate));
                }
                if (!string.IsNullOrEmpty(searchString))
                {
                    filterQuery += @" AND (
                                        o.OutletSerialNo LIKE @searchString OR
                                        o.OutletName LIKE @searchString OR
                                        o.OutletCode LIKE @searchString OR
                                        o.Brand LIKE @searchString OR
                                        a.AuditorName LIKE @searchString OR
                                        a.AuditorNRC LIKE @searchString OR
                                        a.PhoneNumber LIKE @searchString OR
                                        a.NKCAuditDate LIKE @searchString OR
                                        a.Remark LIKE @searchString
                                      )";
                    parameters.Add(new SqlParameter("@searchString", searchString));
                }
                #endregion

                string sql = @"select 
                                count(*) over () as TotalCount,
								o.OutletId, a.AuditorId, d.DocumentId,
                                o.OutletSerialNo, o.OutletName, o.OutletCode, o.Brand,
                                a.AuditorName, a.AuditorNRC, a.PhoneNumber,
                                a.NKCAuditDate, a.Remark, 
                                d.BarrelAndCO2_Res_1_Name,
                                d.BarrelAndCO2_Res_1_Value,
                                d.BarrelAndCO2_Res_2_Name,
                                d.BarrelAndCO2_Res_2_Value,
                                d.BarrelAndCO2_Res_3_Name,
                                d.BarrelAndCO2_Res_3_Value,
                                d.BarrelAndCO2_Res_4_Name,
                                d.BarrelAndCO2_Res_4_Value,
                                d.BarrelAndCO2_Res_5_Name,
                                d.BarrelAndCO2_Res_5_Value,
                                d.BarrelAndCO2_Res_6_Name,
                                d.BarrelAndCO2_Res_6_Value,
                                d.BarrelAndCO2_Res_7_Name,
                                d.BarrelAndCO2_Res_7_Value,
                                d.BarrelAndCO2_Res_8_Name,
                                d.BarrelAndCO2_Res_8_Value,
                                d.Machine_Res_1_Name,
                                d.Machine_Res_1_Value,
                                d.Machine_Res_2_Name,
                                d.Machine_Res_2_Value,
                                d.Machine_Res_3_Name,
                                d.Machine_Res_3_Value,
                                d.Machine_Res_4_Name,
                                d.Machine_Res_4_Value,
                                d.Machine_Res_5_Name,
                                d.Machine_Res_5_Value,
                                d.AuditorNRCFront_Name,
                                d.AuditorNRCFront_Value,
                                d.AuditorNRCBack_Name,
                                d.AuditorNRCBack_Value
                               from Documents d
                               inner join Auditors a on a.AuditorId = d.AuditorId
                               inner join Outlets o on o.OutletId = d.OutletId
                               WHERE " + filterQuery + " ORDER BY d.CreatedDate OFFSET @offset ROWS FETCH NEXT @fetchRow ROWS ONLY";

                parameters.Add(new SqlParameter("@offset", offsetRowNo)); //starting row no.
                parameters.Add(new SqlParameter("@fetchRow", rowLimit)); //rows count in each page

                dt = await _queryHelper.GetDataTableAsync(sql, parameters.ToArray());

            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving", ex);
            }

            return dt;
        }

        public async Task<ResponseModel> DeleteFormRecordAsync(string documentId, string auditorId, string outletId)
        {
            ResponseModel response = new ResponseModel();


            try
            {
                Documents? d = await _context.Documents.FromSqlRaw("select * from Documents where DocumentId = @dId"
                    , new SqlParameter("@dId", documentId)).FirstOrDefaultAsync();

                Auditors? a = await _context.Auditors.FromSqlRaw("select * from Auditors where AuditorId = @aId"
                    , new SqlParameter("@aId", auditorId)).FirstOrDefaultAsync();

                Outlets? o = await _context.Outlets.FromSqlRaw("select * from Outlets where OutletId = @oId"
                    , new SqlParameter("@oId", outletId)).FirstOrDefaultAsync();

                if (d != null && a != null && o != null)
                {
                    _context.Documents.Remove(d);
                    await _context.SaveChangesAsync();

                    _context.Auditors.Remove(a);
                    await _context.SaveChangesAsync();

                    _context.Outlets.Remove(o);
                    await _context.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Message = "Form record deleted successfully";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Form record not found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error deleting: {ex.Message}";
            }


            return response;
        }
    }
}
