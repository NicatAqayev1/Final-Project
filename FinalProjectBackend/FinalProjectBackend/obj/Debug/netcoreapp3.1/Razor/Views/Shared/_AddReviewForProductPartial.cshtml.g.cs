#pragma checksum "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc6c715de4643e5df9ad2fa526532f204d5152f6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__AddReviewForProductPartial), @"mvc.1.0.view", @"/Views/Shared/_AddReviewForProductPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc6c715de4643e5df9ad2fa526532f204d5152f6", @"/Views/Shared/_AddReviewForProductPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a583e8d0a426e2168d557d35c9aad053e3f4f376", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__AddReviewForProductPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("editForma"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display: none;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
 foreach (Review review in Model.Reviews)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"comment\" style=\"position: relative;\">\n    <div class=\"icons\">\n");
#nullable restore
#line 6 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
         for (int i = 0; i < review.Star; i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <i class=\"fa-solid fa-star\"></i>\n");
#nullable restore
#line 9 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n    <h4 class=\"title\">");
#nullable restore
#line 11 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
                 Write(review.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n    <p class=\"date\"><i>");
#nullable restore
#line 12 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
                  Write(review.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span>on</span> ");
#nullable restore
#line 12 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
                                               Write(review.CreatedAt?.ToString("MMMM dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" , ");
#nullable restore
#line 12 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
                                                                                        Write(review.CreatedAt?.ToString("yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</i></p>\n    <p class=\"comment\">");
#nullable restore
#line 13 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
                  Write(review.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n    <div class=\"buttonss\">\n");
#nullable restore
#line 15 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
         if (User.Identity.Name == review.Name)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"comment-body\" style=\" position: absolute; top: 0%; right: 0;\">\n                <span class=\"reply-btn\">\n                    <a href=\"#\" data-id=\"");
#nullable restore
#line 19 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
                                    Write(review.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" class=""changeCommentp"" style="" color: black; border-radius: 15px; border: 1px solid #bfbfbf; padding: 5px 10px; background-color: #ececec;"">Change</a>
                </span>
            </div>
            <div class=""comment-body"" style="" position: absolute; top: 50px; right: 0;"">
                <span class=""reply-btn"">
                    <a href=""#"" data-id=""");
#nullable restore
#line 24 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
                                    Write(review.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-bid=\"");
#nullable restore
#line 24 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
                                                          Write(review.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"deleteCommentp\" style=\" color: black; border-radius: 15px; border: 1px solid #bfbfbf; padding: 5px 13px; background-color: #ececec;\">Delete</a>\n                </span>\n            </div>\n");
#nullable restore
#line 27 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc6c715de4643e5df9ad2fa526532f204d5152f612017", async() => {
                WriteLiteral(@"
        <div class=""comment-post-box"">
            <div class=""row"" style=""position: relative;"">
                <div class=""col-12"" style=""padding: 0px;"">
                    <textarea id=""MessageEditp"" name=""Message"" placeholder=""Write a comment"" style=""height: 100px; width: 100%;margin: 0px; padding: 10px; box-shadow: 0px -1px 6px 0px #80808040;"">");
#nullable restore
#line 33 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
                                                                                                                                                                                               Write(Model.Reviews.FirstOrDefault(p=>p.ProductId == Model.Product.Id && p.Id == review.Id && !p.IsDeleted).Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("</textarea>\n                </div>\n                <div class=\"col-2\" style=\"position: absolute; right: 0; top: 0; width: auto; background-color: #f7f7f7; padding: 0;\">\n                    <div class=\"coment-btn\">\n");
#nullable restore
#line 37 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
                         if (User.Identity.Name == review.Name)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <a class=\"btn editCommentp\" data-rid=\"");
#nullable restore
#line 39 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
                                                             Write(Model.Reviews.FirstOrDefault(p=>p.ProductId == Model.Product.Id && !p.IsDeleted).Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" style=\"border: 0;\">Edit</a>\n");
#nullable restore
#line 40 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <a href=\"#\" class=\"btn default-link\" style=\"border: 0;\">Edit</a>\n");
#nullable restore
#line 44 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </div>\n                </div>\n            </div>\n        </div>\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
                                                                     WriteLiteral(Model.Reviews.FirstOrDefault(p=>p.ProductId == Model.Product.Id && !p.IsDeleted).Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</div>\n    <hr style=\"margin:0;\"/>\n");
#nullable restore
#line 52 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_AddReviewForProductPartial.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
