using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using IS413_Assignment_10.Models.ViewModels;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace IS413_Assignment_10.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-info")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlInfo;

        public PaginationTagHelper(IUrlHelperFactory urlInfo)
        {
            this.urlInfo = urlInfo;
        }

        public PageNumberInfo PageInfo { get; set; }

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        //Our own dictionary (key value pairs) that we are creating
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelp = urlInfo.GetUrlHelper(ViewContext);

            TagBuilder finishedTag = new TagBuilder("div");

            // builds a tag for every page
            for (int i = 1; i <= PageInfo.NumPages; i++)
            {
                TagBuilder individualTag = new TagBuilder("a");

                KeyValuePairs["pageNum"] = i;
                individualTag.Attributes["href"] = urlHelp.Action("Index", KeyValuePairs);

                if (PageClassesEnabled)
                {
                    individualTag.AddCssClass(PageClass);
                    individualTag.AddCssClass(i == PageInfo.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                if (PageClassesEnabled && PageInfo.CurrentPage == 0 && i == 1) // adds styling to first a tag when page isn't selected
                {
                    individualTag.AddCssClass(PageClass);
                    individualTag.AddCssClass(PageClassSelected);
                    
                }

                individualTag.InnerHtml.AppendHtml(i.ToString());

                finishedTag.InnerHtml.AppendHtml(individualTag);
            }

            output.Content.AppendHtml(finishedTag.InnerHtml);
        }
    }
}
