using Microsoft.Data.SqlClient;
using NKC_Resource_Allocation.Database.Helper;
using System.Data;

namespace NKC_Resource_Allocation.Repositories
{
    public class FormRepository
    {
        private readonly NKC_DbContext _context;
        private readonly QueryHelper _queryHelper;
        public FormRepository(NKC_DbContext context, QueryHelper queryHelper)
        {
            _context = context;
            _queryHelper = queryHelper;
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
    }
}
