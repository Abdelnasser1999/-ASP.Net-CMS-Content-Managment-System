using System;

namespace MYCMS.Core.Dtos.Helpers
{
   public static class PagingHelper
    {
        public static int GetSkipValue(this Pagination pagination)
        {
           return (pagination.Page - 1) * pagination.PerPage;
        }

        public static int GetPages(this Pagination pagination , int dataCount)
        {
            double pageCount = Math.Ceiling(dataCount / (double)pagination.PerPage);
            return Convert.ToInt32(pageCount);
        }
    }
}
