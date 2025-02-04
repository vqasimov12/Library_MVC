using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Library.WebUI.TagHelpers;

[HtmlTargetElement("list-pager")]
public class PagingTagHelper : TagHelper
{
    [HtmlAttributeName("page-Size")]
    public int PageSize { get; set; }
    [HtmlAttributeName("page-count")]
    public int PageCount { get; set; }
    [HtmlAttributeName("current-page")]
    public int CurrentPage { get; set; }
    [HtmlAttributeName("type")]
    public string Type { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = null; 

        if (PageCount <= 0)
        {
            output.Content.SetHtmlContent("<p>No pages available.</p>");
            return;
        }

        var sb = new StringBuilder();
        sb.Append("<ul class='pagination d-flex'>");

        for (int i = 1; i <= PageCount; i++) 
        {
            string activeClass = (i == CurrentPage) ? "page-item active" : "page-item";
            string url = $"/{Type}/index?page={i}";

            sb.AppendFormat("<li class='{0}'>", activeClass);
            sb.AppendFormat("<a class='page-link' href='{0}'>{1}</a>", url, i);
            sb.Append("</li>");
        }


        sb.Append("</ul>");
        Console.WriteLine(sb.ToString());
        output.Content.AppendHtml(sb.ToString());


    }

}