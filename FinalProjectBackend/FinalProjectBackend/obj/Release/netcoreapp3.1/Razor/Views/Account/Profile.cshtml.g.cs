#pragma checksum "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a367fd714a11d925db20701dedcd1bedb1ab9b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Profile), @"mvc.1.0.view", @"/Views/Account/Profile.cshtml")]
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
#line 2 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Basket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Order;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Contact;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Blog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Product;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.ViewModels.Wishlist;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\_ViewImports.cshtml"
using FinalProjectBackend.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a367fd714a11d925db20701dedcd1bedb1ab9b9", @"/Views/Account/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a583e8d0a426e2168d557d35c9aad053e3f4f376", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MemberProfileVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color: black"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color: #c1001c;text-decoration: underline;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("logout"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
  
    ViewData["Title"] = "Profile";
    int orderCount = 0;
    int orderItemCount = 0;
    double totalOrderItem = 0;
    foreach (var item in Model.Orders)
    {
        foreach (var item1 in item.OrderItems)
        {
            totalOrderItem = item1.TotalPrice;
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main>
    <!-- breadcrumb area start -->
    <div class=""breadcrumb-area bg-img"" data-bg=""assets/img/banner/breadcrumb-banner.jpg"" style=""background-image: url(&quot;assets/img/banner/breadcrumb-banner.jpg&quot;);"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""breadcrumb-wrap text-center"">
                        <nav aria-label=""breadcrumb"">
                            <h1 class=""breadcrumb-title"" style=""font-family: 'Text Me One'; font-weight: 700; letter-spacing: 2px; font-size: 45px;"">My Account</h1>
                            <ul class=""breadcrumb"" style=""font-family: 'Philosopher';"">
                                <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a367fd714a11d925db20701dedcd1bedb1ab9b98901", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                                <li class=""breadcrumb-item active"" aria-current=""page"" style=""color: #c1001c;"">My Account</li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- breadcrumb area end -->
    <!-- my account wrapper start -->
    <div class=""my-account-wrapper section-padding"">
        <div class=""container custom-container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <!-- My Account Page Start -->
                    <div class=""myaccount-page-wrapper"">
                        <!-- My Account Tab Menu Start -->
                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""myaccount-tab-menu nav""role=""tablist"">
                                    <a href=""#dashboad"" class=""active navs"" data-toggle=""dashboad"">
                                        <i c");
            WriteLiteral(@"lass=""fa fa-dashboard""></i>
                                        Dashboard
                                    </a>
                                    <a href=""#orders"" class=""navs"" data-toggle=""orders""><i class=""fa fa-cart-arrow-down""></i> Orders</a>
                                    <a href=""#address-edit"" class=""navs"" data-toggle=""address-edit""><i class=""fa fa-map-marker""></i> address</a>
                                    <a href=""#account-info"" class=""navs"" data-toggle=""account-info""><i class=""fa fa-user""></i> Account Details</a>
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a367fd714a11d925db20701dedcd1bedb1ab9b912036", async() => {
                WriteLiteral("<i class=\"fa fa-sign-out\"></i> Logout");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
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
                            <!-- My Account Tab Menu End -->
                            <!-- My Account Tab Content Start -->
                            <div class=""col-lg-12"">
                                <div class=""tab-content"" id=""myaccountContent"">
                                    <!-- Single Tab Content Start -->
                                    <div class=""tab-pane fade show active"" id=""dashboad"" data-toggle=""dashboad"" role=""tabpanel"">
                                        <div class=""myaccount-content"">
                                            <h3>Dashboard</h3>
                                            <div class=""welcome"" style=""display: block !important;opacity : 1 !important;"">
                                                <p style=""color: black; font-family: 'Text me one'; font-size: 18px;"">Hello, <strong>");
#nullable restore
#line 66 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                                                                                                Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> (If Not <strong>");
#nullable restore
#line 66 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                                                                                                                                             Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" !</strong>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a367fd714a11d925db20701dedcd1bedb1ab9b915213", async() => {
                WriteLiteral(" Logout");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@")</p>
                                            </div>
                                            <p class=""mb-0"">From your account dashboard. you can easily check &amp; view your recent orders, manage your shipping and billing addresses and edit your password and account details.</p>
                                        </div>
                                    </div>
                                    <!-- Single Tab Content End -->
                                    <!-- Single Tab Content Start -->
                                    <div class=""tab-pane fade"" id=""orders"" data-toggle=""orders"" role=""tabpanel"">
                                        <div class=""myaccount-content"">
                                            <h3>Orders</h3>
                                            <div class=""myaccount-table table-responsive text-center"">

");
#nullable restore
#line 78 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                 if (Model.Orders.Count() > 0)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <table class=""table table-bordered"">
                                                <thead class=""thead-light"">
                                                    <tr>
                                                        <th>Order</th>
                                                        <th>User</th>
                                                        <th>Product Count</th>
                                                        <th>Total</th>
                                                        <th>Date</th>
                                                        <th>Status</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
");
#nullable restore
#line 92 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                     foreach (var item in Model.Orders)
                                                    {
                                                        orderCount++;
                                                        orderItemCount = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr data-toggle=\"collapse\" data-target=\"#demo");
#nullable restore
#line 96 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                                                     Write(orderCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"accordion-toggle openCloseOrderItem\">\n                                                <td>");
#nullable restore
#line 97 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                               Write(orderCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                                <td>");
#nullable restore
#line 98 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                               Write(item.AppUser.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                                <td>");
#nullable restore
#line 99 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                               Write(item.OrderItems.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                                <td>");
#nullable restore
#line 100 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                               Write(item.OrderItems.Sum(o => o.TotalPrice + o.Product.ExTax));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                                <td>");
#nullable restore
#line 101 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                               Write(item.CreatedAt?.ToString("MMMM dd, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                                <td>");
#nullable restore
#line 102 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                               Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                            </tr>
                                                                <tr>
                                                                    <td colspan=""12"" class=""hiddenRow"">
                                                                        <div class=""accordian-body collapse""");
            BeginWriteAttribute("id", " id=\"", 7050, "\"", 7072, 2);
            WriteAttributeValue("", 7055, "demo", 7055, 4, true);
#nullable restore
#line 106 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
WriteAttributeValue("", 7059, orderCount, 7059, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" style=""opacity: 1;"">
                                                                            <table class=""table table-striped"">
                                                                                <thead>
                                                                                    <tr class=""info"">
                                                                                        <th>#</th>
                                                                                        <th>Product Name</th>
                                                                                        <th>Product Color</th>
                                                                                        <th>Product Size</th>
                                                                                        <th>Count</th>
                                                                                        <th>Price</th>
                                                                ");
            WriteLiteral(@"                        <th>Extax</th>
                                                                                        <th>Total Price</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody>
");
#nullable restore
#line 121 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                                                     foreach (var orderItem in item.OrderItems)
                                                                                    {
                                                                                        orderItemCount++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <tr data-toggle=\"collapse\" class=\"accordion-toggle\">\n                                                                    <td>");
#nullable restore
#line 125 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                                   Write(orderItemCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                                                    <td>");
#nullable restore
#line 126 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                                   Write(orderItem?.Product?.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\n                                                                    <td>");
#nullable restore
#line 127 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                                   Write(orderItem?.Size);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\n                                                                    <td>");
#nullable restore
#line 128 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                                   Write(orderItem?.Color);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\n                                                                    <td>");
#nullable restore
#line 129 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                                   Write(orderItem?.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                                                    <td>");
#nullable restore
#line 130 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                                   Write(orderItem?.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                                                    <td>");
#nullable restore
#line 131 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                                   Write(orderItem?.Product.ExTax);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                                                    <td>");
#nullable restore
#line 132 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                                    Write(orderItem?.TotalPrice+orderItem?.Product.ExTax);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                                                </tr>\n");
#nullable restore
#line 134 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>
");
#nullable restore
#line 140 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </tbody>\n                                            </table> ");
#nullable restore
#line 142 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                     }
                                                else
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <p style=\"color: black; font-family: \'Text me one\'; font-size: 18px; font-weight: 700;\">You have no any order yet. ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a367fd714a11d925db20701dedcd1bedb1ab9b929691", async() => {
                WriteLiteral("Go shopping");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</p>\n");
#nullable restore
#line 146 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </div>
                                        </div>
                                    </div>
                                    <!-- Single Tab Content End -->
                                    <!-- Single Tab Content Start -->
                                    <div class=""tab-pane fade"" id=""address-edit"" data-toggle=""address-edit"" role=""tabpanel"">
                                        <div class=""myaccount-content"">
                                            <h3>Billing Address</h3>
                                            <address>
                                                <p><strong>");
#nullable restore
#line 157 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                      Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></p>\n                                                <ol>\n");
#nullable restore
#line 159 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                     if (ViewBag.AppUser.Addresses != null)
                                                    {
                                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 161 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                         foreach (Address Address in ViewBag.AppUser.Addresses)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <li style=\"width: 100%;\">");
#nullable restore
#line 163 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                                            Write(Address.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n");
#nullable restore
#line 164 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 164 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                         
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <p style=\"color: black; font-family: \'Text me one\'; font-size: 18px; font-weight: 700;\">You have no any address yet. ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a367fd714a11d925db20701dedcd1bedb1ab9b934534", async() => {
                WriteLiteral("Go shopping");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</p>\n");
#nullable restore
#line 169 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </ol>\n                                                <p>Mobile: ");
#nullable restore
#line 171 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                                       Write(ViewBag.AppUser.PhoneNumber != null ? ViewBag.AppUser.PhoneNumber : "You didn't save your phone number");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                            </address>
                                        </div>
                                    </div>
                                    <!-- Single Tab Content End -->
                                    <!-- Single Tab Content Start -->
                                    <div class=""tab-pane fade"" id=""account-info"" data-toggle=""account-info"" role=""tabpanel"">
                                        <div class=""myaccount-content"" id=""login"" style=""padding: 0;"">
                                            <h3>Account Details</h3>
                                            <div class=""account-details-form login"" style=""display: block;opacity : 1;"">
                                                ");
#nullable restore
#line 181 "C:\Users\user\Desktop\salameesalaam-main\FinalProjectBackend\FinalProjectBackend\Views\Account\Profile.cshtml"
                                           Write(await Html.PartialAsync("_ProfileFormPartial", Model.Member));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </div>
                                        </div>
                                    </div> <!-- Single Tab Content End -->
                                </div>
                            </div> <!-- My Account Tab Content End -->
                        </div>
                    </div> <!-- My Account Page End -->
                </div>
            </div>
        </div>
    </div>
    <!-- my account wrapper end -->
</main>

<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>

<script>
    $(document).ready(function () {
        $(document).on(""click"", "".openCloseOrderItem"", function () {
            $(this).next().find("".accordian-body"").slideToggle();
            $(this).next().find("".accordian-body"").css({
                ""opacity"": ""1"",
                ""display"":""block""
            });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MemberProfileVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
