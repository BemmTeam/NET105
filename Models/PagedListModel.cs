

namespace NET105.Models
{

    public class PagedListModel 
    {
        public int? Page {get;set;}

        public string SearchString {get;set;}

        public int? PageSize {get;set;}

        public int? OrderBy {get;set;}

        public int? IdCategory {get;set;}
    }

}