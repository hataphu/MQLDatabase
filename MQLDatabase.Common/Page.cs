using System.Collections.Generic;

namespace MQLDatabase.Common
{
    public class Page<T>
    {
        public List<T> data { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int total { get; set; }
        public int totalPage
        {
            get
            {
                var tp = total / pageSize;
                var du = total % pageSize;
                return du > 0 ? tp + 1 : tp;
            }
        }
        public int Next() { return pageIndex + 1; }
    }
}
