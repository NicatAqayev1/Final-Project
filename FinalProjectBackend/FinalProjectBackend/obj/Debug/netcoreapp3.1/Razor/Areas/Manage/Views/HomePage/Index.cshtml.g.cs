#pragma checksum "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d84d4595c166819a8381f6c70f1cb59716b33ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_HomePage_Index), @"mvc.1.0.view", @"/Areas/Manage/Views/HomePage/Index.cshtml")]
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
#line 2 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\_ViewImports.cshtml"
using FinalProjectBackend.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Product;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d84d4595c166819a8381f6c70f1cb59716b33ea", @"/Areas/Manage/Views/HomePage/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a6e324a6277f189a29d578e1c996ff8d10f862b", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_HomePage_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Home>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100px;object-fit:cover;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Change", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "homepage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-lg-12 btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""page-wrapper"">
    <!-- ============================================================== -->
    <div class=""page-breadcrumb"">
        <div class=""row align-items-center"">
            <div class=""col-md-6 col-8 align-self-center"">
                <h3 class=""page-title mb-0 p-0"">Blank Page</h3>
                <div class=""d-flex align-items-center"">
                    <nav aria-label=""breadcrumb"">
                        <ol class=""breadcrumb"">
                            <li class=""breadcrumb-item""><a href=""#"">Home</a></li>
                            <li class=""breadcrumb-item active"" aria-current=""page"">Blank Page</li>
                        </ol>
                    </nav>
                </div>
            </div>
            <div class=""col-md-6 col-4 align-self-center"">
                <div class=""text-end upgrade-btn"">
                    <ul class=""dropdown-menu"" aria-labelledby=""navbarDropdown""></ul>
                </div>
            </div>
        </div>
    </div>
    <!-- =============");
            WriteLiteral(@"================================================= -->
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-body"">
                        <h2 class=""text-center"">Arrival section</h2>
                        <table class=""table table-striped"">
                            <thead>
                                <tr>
                                    <th scope=""col"">ArrivalBestBtnText</th>
                                    <th scope=""col"">ArrivalFeatureBtnText</th>
                                    <th scope=""col"">ArrivalNewBtnText</th>
                                    <th scope=""col"">ArrivalHeader</th>
                                    <th scope=""col"">ArrivalText</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>");
#nullable restore
#line 43 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.ArrivalBestBtnText));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 44 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.ArrivalFeatureBtnText));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 45 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.ArrivalNewBtnText));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 46 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.ArrivalHeader));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 47 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.ArrivalFeatureBtnText));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 48 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.ArrivalText));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                </tr>
                            </tbody>
                        </table>
                        <h2 class=""text-center"">Upgrade section</h2>
                        <table class=""table table-striped"">
                            <thead>
                                <tr>
                                    <th scope=""col"">UpgradeLatestImage</th>
                                    <th scope=""col"">UpgradeLatestSignImage</th>
                                    <th scope=""col"">UpgradeLatestHeader</th>
                                    <th scope=""col"">UpgradeLatestText</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3d84d4595c166819a8381f6c70f1cb59716b33ea10503", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3318, "~/images/MainHJome/", 3318, 19, true);
#nullable restore
#line 65 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
AddHtmlAttributeValue("", 3337, Model.UpgradeLatestImage, 3337, 25, false);

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
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3d84d4595c166819a8381f6c70f1cb59716b33ea12265", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3538, "~/images/MainHJome/", 3538, 19, true);
#nullable restore
#line 68 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
AddHtmlAttributeValue("", 3557, Model.UpgradeLatestSignImage, 3557, 29, false);

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
            WriteLiteral("\n                                    </td>\n                                    <td>");
#nullable restore
#line 70 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.UpgradeLatestHeader));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 71 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.UpgradeLatestText));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                </tr>
                            </tbody>
                        </table>
                        <h2 class=""text-center"">Gallery section</h2>
                        <table class=""table table-striped"">
                            <thead>
                                <tr>
                                    <th scope=""col"">GalleryHeader</th>
                                    <th scope=""col"">GalleryText</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>");
#nullable restore
#line 85 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.GalleryHeader));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 86 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.GalleryText));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                </tr>
                            </tbody>
                        </table>
                        <h2 class=""text-center"">Featured section</h2>
                        <table class=""table table-striped"">
                            <thead>
                                <tr>
                                    <th scope=""col"">featuredProdsImage</th>
                                    <th scope=""col"">featuredProdsHeader</th>
                                    <th scope=""col"">featuredProdsText</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3d84d4595c166819a8381f6c70f1cb59716b33ea16797", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5359, "~/images/MainHJome/", 5359, 19, true);
#nullable restore
#line 102 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
AddHtmlAttributeValue("", 5378, Model.featuredProdsImage, 5378, 25, false);

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
            WriteLiteral("\n                                    </td>\n                                    <td>");
#nullable restore
#line 104 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.featuredProdsHeader));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 105 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.featuredProdsText));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                </tr>
                            </tbody>
                        </table>
                        <h2 class=""text-center"">Hurry section</h2>
                        <table class=""table table-striped"">
                            <thead>
                                <tr>
                                    <th scope=""col"">HurryImage</th>
                                    <th scope=""col"">HurryHeader</th>
                                    <th scope=""col"">HurrySaleText</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3d84d4595c166819a8381f6c70f1cb59716b33ea19973", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 6405, "~/images/MainHJome/", 6405, 19, true);
#nullable restore
#line 121 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
AddHtmlAttributeValue("", 6424, Model.HurryImage, 6424, 17, false);

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
            WriteLiteral("\n                                    </td>\n                                    <td>");
#nullable restore
#line 123 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.HurryHeader));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 124 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.HurrySaleText));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                </tr>
                            </tbody>
                        </table>
                        <h2 class=""text-center"">Special section</h2>
                        <table class=""table table-striped"">
                            <thead>
                                <tr>
                                    <th scope=""col"">SpecialImage</th>
                                    <th scope=""col"">SpecialHeader</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3d84d4595c166819a8381f6c70f1cb59716b33ea23062", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 7366, "~/images/MainHJome/", 7366, 19, true);
#nullable restore
#line 139 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
AddHtmlAttributeValue("", 7385, Model.SpecialImage, 7385, 19, false);

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
            WriteLiteral("\n                                    </td>\n                                    <td>");
#nullable restore
#line 141 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.SpecialHeader));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                </tr>
                            </tbody>
                        </table>
                        <h2 class=""text-center"">Client section</h2>
                        <table class=""table table-striped"">
                            <thead>
                                <tr>
                                    <th scope=""col"">OurClientsHeader</th>
                                    <th scope=""col"">OurClientsText</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>");
#nullable restore
#line 155 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.OurClientsHeader));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 156 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                   Write(Html.Raw(Model.OurClientsText));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                </tr>\n                            </tbody>\n                        </table>\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3d84d4595c166819a8381f6c70f1cb59716b33ea26582", async() => {
                WriteLiteral("Change");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 160 "C:\Users\Fintex\Desktop\FinalProject-Backend-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\HomePage\Index.cshtml"
                                                                                             WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ============================================================== -->
    <footer class=""footer text-center"">
        © 2021 Monster Admin by <a href=""https://www.wrappixel.com/"">wrappixel.com</a>
    </footer>
    <!-- ============================================================== -->
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Home> Html { get; private set; }
    }
}
#pragma warning restore 1591
