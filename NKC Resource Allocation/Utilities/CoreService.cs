using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKC_Resource_Allocation.Database.CoreService
{
    public class CoreService
    {
        public int GetOffsetRow(int pageNo, int rowLimit)
        {
            int OffsetRow = (pageNo - 1) * rowLimit; // for page no. 1, OffsetRow is 0. Page no. 2, OffsetRow is 10
            return OffsetRow;
        }
    }
}
