#pragma checksum "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2cb40e92df3fcb6fd57828137e73bd4bb4ecb338"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Cart), @"mvc.1.0.view", @"/Views/Product/Cart.cshtml")]
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
#line 1 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\_ViewImports.cshtml"
using NestBack;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\_ViewImports.cshtml"
using NestBack.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\_ViewImports.cshtml"
using NestBack.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\_ViewImports.cshtml"
using NestBack.Utilies;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\_ViewImports.cshtml"
using NestBack.ViewModels.Auth;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2cb40e92df3fcb6fd57828137e73bd4bb4ecb338", @"/Views/Product/Cart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e20e310c3e0642cff1947d0b806fe44c8db76dcb", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Product_Cart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CartProductVM>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml"
  
    ViewData["Title"] = "Cart";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main class=""main"">
    <div class=""page-header breadcrumb-wrap"">
        <div class=""container"">
            <div class=""breadcrumb"">
                <a href=""index.html"" rel=""nofollow""><i class=""fi-rs-home mr-5""></i>Home</a>
                <span></span> Shop
                <span></span> Cart
            </div>
        </div>
    </div>
    <div class=""container mb-80 mt-50"">
        <div class=""row"">
            <div class=""col-lg-8 mb-40"">
                <h1 class=""heading-2 mb-10"">Your Cart</h1>
                <div class=""d-flex justify-content-between"">
                    <h6 class=""text-body"">There are <span class=""text-brand"">3</span> products in your cart</h6>
                    <h6 class=""text-body""><a href=""#"" class=""text-muted""><i class=""fi-rs-trash mr-5""></i>Clear Cart</a></h6>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-lg-8"">
");
#nullable restore
#line 28 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml"
                 if (Model.Count > 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""table-responsive shopping-summery"">
                        <table class=""table table-wishlist"">
                            <thead>
                                <tr class=""main-heading"">
                                    <th class=""custome-checkbox start pl-30"">
                                        <input class=""form-check-input"" type=""checkbox"" name=""checkbox"" id=""exampleCheckbox11""");
            BeginWriteAttribute("value", " value=\"", 1507, "\"", 1515, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                        <label class=""form-check-label"" for=""exampleCheckbox11""></label>
                                    </th>
                                    <th scope=""col"" colspan=""2"">Product</th>
                                    <th scope=""col"">Unit Price</th>
                                    <th scope=""col"">Quantity</th>
                                    <th scope=""col"">Subtotal</th>
                                    <th scope=""col"" class=""end"">Remove</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 46 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml"
                                 foreach (CartProductVM item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr");
            BeginWriteAttribute("class", " class=\"", 2286, "\"", 2338, 2);
            WriteAttributeValue("", 2294, "pt-30", 2294, 5, true);
#nullable restore
#line 48 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml"
WriteAttributeValue(" ", 2299, item.IsAbailable ? "" : "bg-danger", 2300, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <td class=\"custome-checkbox pl-30\">\r\n                                            <input class=\"form-check-input\" type=\"checkbox\" name=\"checkbox\" id=\"exampleCheckbox1\"");
            BeginWriteAttribute("value", " value=\"", 2548, "\"", 2556, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            <label class=\"form-check-label\" for=\"exampleCheckbox1\"></label>\r\n                                        </td>\r\n                                        <td class=\"image product-thumbnail pt-40\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2cb40e92df3fcb6fd57828137e73bd4bb4ecb33810111", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2808, "~/imgs/products/", 2808, 16, true);
#nullable restore
#line 53 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml"
AddHtmlAttributeValue("", 2824, item.Img, 2824, 9, false);

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
            WriteLiteral("</td>\r\n                                        <td class=\"product-des product-name\">\r\n                                            <h6 class=\"mb-5\"><a class=\"product-name mb-10 text-heading\" href=\"shop-product-right.html\">");
#nullable restore
#line 55 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml"
                                                                                                                                  Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a></h6>
                                            <div class=""product-rate-cover"">
                                                <div class=""product-rate d-inline-block"">
                                                    <div class=""product-rating""");
            BeginWriteAttribute("style", " style=\"", 3333, "\"", 3368, 3);
            WriteAttributeValue("", 3341, "width:", 3341, 6, true);
#nullable restore
#line 58 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml"
WriteAttributeValue("", 3347, item.Raiting * 20, 3347, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3367, "%", 3367, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                    </div>\r\n                                                </div>\r\n                                                <span class=\"font-small ml-5 text-muted\"> (");
#nullable restore
#line 61 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml"
                                                                                      Write(item.Raiting);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</span>\r\n                                            </div>\r\n                                        </td>\r\n                                        <td class=\"price\" data-title=\"Price\">\r\n                                            <h4 class=\"text-body\">");
#nullable restore
#line 65 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml"
                                                             Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </h4>
                                        </td>
                                        <td class=""text-center detail-info"" data-title=""Stock"">
                                            <div class=""detail-extralink mr-15"">
                                                <div class=""detail-qty border radius"">
                                                    <a href=""#"" class=""qty-down""><i class=""fi-rs-angle-small-down""></i></a>
                                                    <span class=""qty-val"">");
#nullable restore
#line 71 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml"
                                                                     Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                                    <a href=""#"" class=""qty-up""><i class=""fi-rs-angle-small-up""></i></a>
                                                </div>
                                            </div>
                                        </td>
                                        <td class=""price"" data-title=""Price"">
                                            <h4 class=""text-brand"">");
#nullable restore
#line 77 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml"
                                                               Write(item.Price * item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n                                        </td>\r\n\r\n\r\n                                        <td class=\"action text-center\" data-title=\"Remove\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2cb40e92df3fcb6fd57828137e73bd4bb4ecb33815847", async() => {
                WriteLiteral("\r\n                                                <button type=\"submit\" class=\"text-body\"><i class=\"fi-rs-trash\"></i></button>\r\n                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 82 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml"
                                                                                                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 87 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </tbody>
                        </table>
                    </div>
                    <div class=""divider-2 mb-30""></div>
                    <div class=""cart-action d-flex justify-content-between"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2cb40e92df3fcb6fd57828137e73bd4bb4ecb33819512", async() => {
                WriteLiteral("<i class=\"fi-rs-arrow-left mr-10\"></i>Continue Shopping");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <a class=\"btn  mr-10 mb-sm-15\"><i class=\"fi-rs-refresh mr-10\"></i>Update Cart</a>\r\n                    </div>\r\n");
#nullable restore
#line 97 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml"
                }
                else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h2>Cart is empty ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2cb40e92df3fcb6fd57828137e73bd4bb4ecb33821430", async() => {
                WriteLiteral("Here");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" you can continue</h2>\r\n");
#nullable restore
#line 101 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            <div class=""col-lg-4"">
                <div class=""border p-md-4 cart-totals ml-30"">
                    <div class=""table-responsive"">
                        <table class=""table no-border"">
                            <tbody>
                                <tr>
                                    <td class=""cart_total_label"">
                                        <h6 class=""text-muted"">Total</h6>
                                    </td>
                                    <td class=""cart_total_amount"">
                                        <h4 class=""text-brand text-end"">");
#nullable restore
#line 113 "C:\Users\admin\Desktop\git\all\Nest\nesttask8\NestBack\Views\Product\Cart.cshtml"
                                                                   Write(Model.Sum(m=>m.Price*m.Count));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <a href=""#"" class=""btn mb-20 w-100"">Proceed To CheckOut<i class=""fi-rs-sign-out ml-15""></i></a>
                </div>
            </div>
        </div>
    </div>
</main>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CartProductVM>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
