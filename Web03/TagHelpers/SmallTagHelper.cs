using Microsoft.AspNetCore.Razor.TagHelpers;


namespace Web03.TagHelpers
{
    [HtmlTargetElement(Attributes = "small")]
    public class SmallTagHelper:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll("small");
            output.PreContent.SetContent("<small>");
            output.PostContent.SetHtmlContent("</small>");
        }
    }
}
