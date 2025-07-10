namespace task_list_api.Utils
{
    public class PagedResult<TaskDto>
    {
        public List<TaskDto> Items { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
