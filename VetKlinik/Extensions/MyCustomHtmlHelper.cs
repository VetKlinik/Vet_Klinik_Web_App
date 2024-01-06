using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq.Expressions;
using VetKlinik.Dto;

namespace VetKlinik.Extensions
{
    public static class MyCustomHtmlHelper
    {
        //TODO custom html helper oluşturma
        public static IHtmlContent CustomSaveButton(this IHtmlHelper htmlHelper, string buttonText, string onclickScript, object htmlAttributes)
        {
            var tagBuilder = new TagBuilder("button");
            tagBuilder.MergeAttribute("type", "submit");
            tagBuilder.InnerHtml.AppendHtml(buttonText);
            tagBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            tagBuilder.MergeAttribute("onclick", onclickScript);

            return tagBuilder;
        }
    }
}
