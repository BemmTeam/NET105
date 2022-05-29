

using Microsoft.AspNetCore.Razor.TagHelpers;
using NET105.Models;
using System.Text;
using System.Threading.Tasks;

namespace NET105.Helper
{

    [HtmlTargetElement("PagedSize")]
    public class PagedSizeTagHelper : TagHelper
    {
        public int? Value { get; set; }

        public PagedListModel model {get;set;}

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            Value ??= 6;

            output.TagName = "select";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("onchange", "this.form.submit()");
            output.Attributes.SetAttribute("name", "PageSize");

            StringBuilder content = new();
        
                for (int i = 6; i <= 12; i = i + 3)
                {
                    content.Append(contextAppend(i , "Show " + i));
                    
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