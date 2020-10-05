namespace SampleNotify.Application.Queries
{
    public abstract class ListQuery
    {
        protected ListQuery(int pageIndex, int pageSize, string query, string sorts)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Query = query;
            Sorts = sorts;
        }

        public string Sorts { get; }
        public int PageIndex { get; }
        public int PageSize { get; }
        public string Query { get; }
    }
}