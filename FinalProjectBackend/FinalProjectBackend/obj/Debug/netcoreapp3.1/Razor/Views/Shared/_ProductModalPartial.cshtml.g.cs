#pragma checksum "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_ProductModalPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1194e9bdfc0dcf33dc64c629d5517156bf594a07"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ProductModalPartial), @"mvc.1.0.view", @"/Views/Shared/_ProductModalPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1194e9bdfc0dcf33dc64c629d5517156bf594a07", @"/Views/Shared/_ProductModalPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a583e8d0a426e2168d557d35c9aad053e3f4f376", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ProductModalPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/main.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"modal-prod row\">\n    <div class=\"left-modal col-lg-6\">\n        <div class=\"swiper mySwiperModal\">\n            <div class=\"swiper-wrapper\">\n");
#nullable restore
#line 6 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_ProductModalPartial.cshtml"
                 foreach (ProductColorSize productImage in Model.Product.ProductColorSizes)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"swiper-slide\">\n                        <div class=\"image\">\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1194e9bdfc0dcf33dc64c629d5517156bf594a076566", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 407, "~/images/products/", 407, 18, true);
#nullable restore
#line 10 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_ProductModalPartial.cshtml"
AddHtmlAttributeValue("", 425, productImage.Image, 425, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                        </div>\n                    </div>\n");
#nullable restore
#line 13 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_ProductModalPartial.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\n");
            WriteLiteral("        </div>\n    </div>\n    <div class=\"right-modal col-lg-6\">\n        ");
#nullable restore
#line 20 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Views\Shared\_ProductModalPartial.cshtml"
   Write(await Html.PartialAsync("_ProductRightModalPartial", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n</div>\n");
            DefineSection("Script", async() => {
                WriteLiteral("\n    <link rel=\"stylesheet\"\n          href=\"https://unpkg.com/swiper/swiper-bundle.min.css\" />\n    <script src=\"https://unpkg.com/swiper/swiper-bundle.min.js\"></script>\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1194e9bdfc0dcf33dc64c629d5517156bf594a079251", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
            }
            );
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
