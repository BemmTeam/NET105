

using Microsoft.AspNetCore.Razor.TagHelpers;
using NET105.Models;
using System.Text;
using System.Threading.Tasks;

namespace NET105.Helper
{

    [HtmlTargetElement("PagedOrderBy")]
    public class PagedOrderByTagHelper : TagHelper
    {
        public int? Value { get; set; }

        public PagedListModel model {get;set;}
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            Value ??= 1;
            output.TagName = "select";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("onchange", "this.form.submit()");
            output.Attributes.SetAttribute("name", "OrderBy");

            StringBuilder content = new();
           
                for(int i = 1 ; i <= 4 ;i++)
                {
              
                    switch(i)
                    {
                        case 1 : content.Append(contextAppend(1 , "Giá giảm dần")); break;
                        case 2 : content.Append(contextAppend(2 , "Giá tăng gần")); break;
                        case 3 : content.Append(contextAppend(3 , "Tên giảm dần")); break;
                        case 4 : content.Append(contextAppend(4 , "Tên tăng dần")); break;
                    }
                }

            content.Append($@"<input name=""SearchString"" value=""{model.SearchString}"" hidden/> ");
               content.Append($@"<input name=""OrderBy"" value=""{model.OrderBy}"" hidden/> ");
               content.Append($@"<input name=""IdCategory"" value=""{model.IdCategory}"" hidden/> ");



    
            output.Content.SetHtmlContent(content.ToString());

        }

        private string contextAppend(int i, string text)
        {
            string result;
            if(Value == i ) 
            {
                result = $@"<option selected  value=""{i}"">{text}</option>";
            }
            else
                result = $@"<option  value=""{i}"">{text}</option>";

            return result;
        }


    }

}