using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProject
{
    public class PaginatedList<T>: List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; set; }

        public PaginatedList(List<T> values, int cout, int pageIndex, int totalSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(cout / (double)totalSize);
            this.AddRange(values);
        }

        public bool PreviousPage { get { return PageIndex > 1; } }
        public bool NextPage { get { return PageIndex < TotalPages; } }
        

        public static async Task<PaginatedList<T>> CreateAsunc(IQueryable<T> values, int pageIndex, int pageSize)
        {
            var count = await values.CountAsync();
            var items = await values.Skip((pageIndex - 1)*pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count,pageIndex, pageSize);

        }
    }
}
