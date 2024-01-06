using Microsoft.AspNetCore.Razor.TagHelpers;

namespace VetKlinik.Extensions
{
    //TODO custom tag helper oluşturma
    [HtmlTargetElement("custom-submit-button")]
    public class MyCustomTagHelper : TagHelper
    {
        public string Text { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Attributes.SetAttribute("type", "submit");
            output.Attributes.SetAttribute("class", "btn btn-success my-3");
            output.Content.SetContent(Text);
        }
    }
}
