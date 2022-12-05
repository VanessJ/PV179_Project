using Optional;

namespace Bazaar.BL.Dtos.Base
{
    public class BaseFilterDto
    {
        public Option<int> RequestedPageNumber { get; set; }
        public Option<int> PageSize { get; set; }
        public Option<string> OderCriteria { get; set; } 
        public Option<bool> OrderAscending { get; set; }
    }
}
