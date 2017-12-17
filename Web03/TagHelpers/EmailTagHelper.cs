using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Web03.TagHelpers
{
    [HtmlTargetElement("email", TagStructure = TagStructure.WithoutEndTag)]
    public class EmailTagHelper : TagHelper
    {
        public string MailTo { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            var emailTo = $"{MailTo}@company.com";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("href",$"mailto:{emailTo}");
            output.Attributes.Add("class","btn btn-default btn-xs");
            output.Content.SetContent(emailTo);
        }
    }
}
