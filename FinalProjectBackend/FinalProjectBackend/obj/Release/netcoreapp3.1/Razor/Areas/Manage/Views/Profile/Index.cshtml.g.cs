#pragma checksum "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\Profile\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "666d71461f3a3af1a9d4cb985d1501c0cd2393b6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Profile_Index), @"mvc.1.0.view", @"/Areas/Manage/Views/Profile/Index.cshtml")]
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
#line 2 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\_ViewImports.cshtml"
using FinalProjectBackend.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Product;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"666d71461f3a3af1a9d4cb985d1501c0cd2393b6", @"/Areas/Manage/Views/Profile/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a6e324a6277f189a29d578e1c996ff8d10f862b", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Profile_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AppUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-lg-12 btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
                        <table class=""table table-striped"">
                            <thead>
                                <tr>
                                    <th scope=""col"">FullName</th>
                                    <th scope=""col"">UserName</th>
                                    <th scope=""col"">Email</th>
                                    <th scope=""col"">PhoneNumber</th>
                                    <th scope=""col"">Address</th>
                                    <th scope=""col"">Country</th>
                                    <th scope=""col"">City</th>
                                    <th scope=""col"">State</th>
                                    <th scope=""col"">Settings</th>
                                </tr>
                            </thead>
     ");
            WriteLiteral("                       <tbody>\n                                <tr>\n                                    <td>");
#nullable restore
#line 46 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\Profile\Index.cshtml"
                                   Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 47 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\Profile\Index.cshtml"
                                   Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 48 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\Profile\Index.cshtml"
                                   Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 49 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\Profile\Index.cshtml"
                                   Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 50 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\Profile\Index.cshtml"
                                   Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 51 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\Profile\Index.cshtml"
                                   Write(Model.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 52 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\Profile\Index.cshtml"
                                   Write(Model.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 53 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Areas\Manage\Views\Profile\Index.cshtml"
                                   Write(Model.State);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "666d71461f3a3af1a9d4cb985d1501c0cd2393b69842", async() => {
                WriteLiteral("Change your password");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                    </td>
                                </tr>
                            </tbody>
                        </table>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AppUser> Html { get; private set; }
    }
}
#pragma warning restore 1591