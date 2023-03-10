#pragma checksum "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80da1c5b0960fcce7156287812b7e3d70f4c4d5c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__AddReviewPartial), @"mvc.1.0.view", @"/Views/Shared/_AddReviewPartial.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Basket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Order;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Contact;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Blog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Product;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Wishlist;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80da1c5b0960fcce7156287812b7e3d70f4c4d5c", @"/Views/Shared/_AddReviewPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a583e8d0a426e2168d557d35c9aad053e3f4f376", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__AddReviewPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<ol>\n");
#nullable restore
#line 3 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewPartial.cshtml"
     foreach (Review review in Model.Reviews)
    {

        if (!review.IsDeleted)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li>\n                <div class=\"comment\">\n                    <ul style=\"position: relative;\">\n                        <li>\n                            <i class=\"fa-solid fa-calendar-days\"></i>\n                            <span>");
#nullable restore
#line 13 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewPartial.cshtml"
                             Write(review.CreatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                        </li>\n                        <li>\n                            <i class=\"fa-solid fa-circle-user\"></i>\n                            <span>");
#nullable restore
#line 17 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewPartial.cshtml"
                             Write(review.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                        </li>\n");
#nullable restore
#line 19 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewPartial.cshtml"
                         if (User.Identity.Name == review.Name)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"comment-body\" style=\" position: absolute; top: 0%; right: 0;\">\n                                <span class=\"reply-btn\">\n                                    <a href=\"#\" data-id=\"");
#nullable restore
#line 23 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewPartial.cshtml"
                                                    Write(review.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" class=""changeComment"" style="" color: black; border-radius: 15px; border: 1px solid #bfbfbf; padding: 5px 10px; background-color: #ececec;"">Change</a>
                                </span>
                            </div>
                            <div class=""comment-body"" style="" position: absolute; top: 50%; right: 0;"">
                                <span class=""reply-btn"">
                                    <a data-id=""");
#nullable restore
#line 28 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewPartial.cshtml"
                                           Write(review.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-bid=\"");
#nullable restore
#line 28 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewPartial.cshtml"
                                                                 Write(review.BlogId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"deleteComment\" style=\" color: black; border-radius: 15px; border: 1px solid #bfbfbf; padding: 5px 10px; background-color: #ececec;\">Delete</a>\n                                </span>\n                            </div>\n");
#nullable restore
#line 31 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewPartial.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\n                    <hr>\n                    <p>");
#nullable restore
#line 34 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewPartial.cshtml"
                  Write(review.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                </div>\n            </li>\n            <div style=\"opacity:1;visibility: visible;\" class=\"EditComment\">\n\n            </div>\n");
#nullable restore
#line 40 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewPartial.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</ol>

<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>
<script>

    $(document).on(""click"", "".deleteComment"", function (e) {
        e.preventDefault();
        var id = $(this).attr(""data-id"");
        var bid = $(this).attr(""data-bid"");
        fetch(""Delete"" + ""?id="" + id).then(res => {
            return res.text();
        }).then(data => {
            $("".comments"").html(data);
            $(""#MessageMain"").val("""");

            fetch(""CommentCount"" + ""?id="" + bid).then(response => {
                return response.text()
            }).then(data => {
                $("".CommentCount"").html(data);
            })
        })
    })

    $(document).on(""click"", "".changeComment"", function (e) {
        e.preventDefault();
        var id = $(this).attr(""data-id"");
        fetch(""EditComment"" + ""?id="" + id).then(res => {
            return res.text()
        }).then(data => {
            $(this).parents(""li"").next().html(data)
        })
    })
</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
