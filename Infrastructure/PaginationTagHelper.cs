using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TheWaterProject.Models.ViewModels;

namespace TheWaterProject.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            this.urlHelperFactory = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        public string? PageAction { get; set; }
        public PaginationInfo PageModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

                TagBuilder result = new TagBuilder("div");

                int totalPages = (int)Math.Ceiling((double)PageModel.TotalItems / PageModel.ItemsPerPage);

                for (int i = 1; i <= totalPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });
                    tag.InnerHtml.Append(i.ToString());

                    result.InnerHtml.AppendHtml(tag);
                }

                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}



//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.AspNetCore.Mvc.Routing;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using Microsoft.AspNetCore.Razor.TagHelpers;
//using TheWaterProject.Models.ViewModels;

//namespace TheWaterProject.Infrastructure
//{
//    [HtmlTargetElement("div", Attributes = "page-model")]
//    public class PaginationTagHelper : TagHelper
//    {
//        private IUrlHelperFactory urlHelperFactory; //Private instance

//        public PaginationTagHelper(IUrlHelperFactory temp)
//        {
//            this.urlHelperFactory = temp;
//        }
//        [ViewContext]
//        [HtmlAttributeNotBound] //We don't want users to get this information in the URL
//        public ViewContext? ViewContext { get; set; }
//        public string? PageAction { get; set; } //ASP.Net does this translation into HTML by making it 'page-action'
//        public PaginationInfo PageModel { get; set; }

//        public override void Process(TagHelperContext context, TagHelperOutput output) //Preexisted in the tag helper
//        {
//            if (ViewContext != null && PageModel != null)
//            {
//                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

//                TagBuilder result = new TagBuilder("div");

//                for (int i = 1; i <= PageModel.TotalNumPages; i++)
//                {
//                    TagBuilder tag = new TagBuilder("a");

//                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = 1 });
//                    tag.InnerHtml.Append(i.ToString());

//                    result.InnerHtml.AppendHtml(tag);
//                }

//                output.Content.Append(result.InnerHtml); //Shows the bad boy on the screen
//            }
//        }
//    }
//}

