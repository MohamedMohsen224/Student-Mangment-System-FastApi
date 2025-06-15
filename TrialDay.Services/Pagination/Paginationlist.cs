namespace TrialDay.Pagination
{
    public class PaginationList<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public List<T> Items { get; set; }
        public string? SearchTerm { get; set; } // Optional, for UI feedback

        public PaginationList(
            int pageIndex,
            int pageSize,
            List<T> items,
            string? searchTerm = null)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Items = items;
            SearchTerm = searchTerm;
        }
    }
}
