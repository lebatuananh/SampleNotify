namespace SampleNotify.Application.Queries
{
    public abstract class ListQuery
    {
        protected ListQuery(int skip, int take, string query = null)
        {
            Skip = skip;
            Take = take;
            Query = query;
        }

        public int Skip { get; }
        public int Take { get; }
        public string Query { get; }
    }
}