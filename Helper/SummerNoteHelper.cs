

namespace NET105.Helper 
{

    public class SummerNoteHelper 
    {
        public string Id {get;set;}

        public int Height {get;set;} = 120 ;

        public string ToolBar = @"
        [
          ['style', ['style']],
          ['font', ['bold', 'underline', 'clear']],
          ['color', ['color']],
          ['para', ['ul', 'ol', 'paragraph']],
          ['table', ['table']],
          ['insert', ['link', 'picture', 'video']],
          ['view', ['fullscreen', 'codeview', 'help']]
        ]";
        

        public bool loadScript {get;set;}

        public SummerNoteHelper(string _id , bool load = true)
        {
            this.Id = _id;
            loadScript = load;
        }
    }
}