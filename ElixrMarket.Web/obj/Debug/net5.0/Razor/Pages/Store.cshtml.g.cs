#pragma checksum "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be8914cdbae7f43d1f4d553c34ccde4a03934678"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ElixrMarket.Web.Pages.Pages_Store), @"mvc.1.0.razor-page", @"/Pages/Store.cshtml")]
namespace ElixrMarket.Web.Pages
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
#line 1 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/_ViewImports.cshtml"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/_ViewImports.cshtml"
using ElixrMarket.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/_ViewImports.cshtml"
using ElixrMarket.Web.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be8914cdbae7f43d1f4d553c34ccde4a03934678", @"/Pages/Store.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0b60b177337bd522245b655ec01a099480a2747", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Store : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "education", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "medical", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "enterprise", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "VR", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "AR", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Thumbnail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/add-cart.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div id=\"store\">\n    <div id=\"filter-container\">\n        <div>\n            <span>Genres:</span>\n            <select id=\"categories\" multiple=\"multiple\">\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be8914cdbae7f43d1f4d553c34ccde4a039346785861", async() => {
                WriteLiteral("Education");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be8914cdbae7f43d1f4d553c34ccde4a039346787021", async() => {
                WriteLiteral("Medical");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be8914cdbae7f43d1f4d553c34ccde4a039346788179", async() => {
                WriteLiteral("Enterprise");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            </select>\n        </div>\n        <div>\n            <span>Application Types:</span>\n            <select id=\"app-types\" multiple=\"multiple\">\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be8914cdbae7f43d1f4d553c34ccde4a039346789500", async() => {
                WriteLiteral("VR");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be8914cdbae7f43d1f4d553c34ccde4a0393467810653", async() => {
                WriteLiteral("AR");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            </select>\n        </div>\n    </div>\n    <hr />\n    <div id=\"list-container\">\n");
#nullable restore
#line 26 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml"
         foreach (var product in Model.Products)
        {
            string href = $"/Details/{product.Id}";


#line default
#line hidden
#nullable disable
            WriteLiteral("            <input type=\"hidden\"");
            BeginWriteAttribute("id", " id=\"", 864, "\"", 883, 2);
#nullable restore
#line 30 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml"
WriteAttributeValue("", 869, product.Id, 869, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 880, "-id", 880, 3, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 884, "\"", 903, 1);
#nullable restore
#line 30 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml"
WriteAttributeValue("", 892, product.Id, 892, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n            <input type=\"hidden\"");
            BeginWriteAttribute("id", " id=\"", 940, "\"", 962, 2);
#nullable restore
#line 31 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml"
WriteAttributeValue("", 945, product.Id, 945, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 956, "-price", 956, 6, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 963, "\"", 985, 1);
#nullable restore
#line 31 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml"
WriteAttributeValue("", 971, product.Price, 971, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n            <input type=\"hidden\"");
            BeginWriteAttribute("id", " id=\"", 1022, "\"", 1043, 2);
#nullable restore
#line 32 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml"
WriteAttributeValue("", 1027, product.Id, 1027, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1038, "-name", 1038, 5, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 1044, "\"", 1065, 1);
#nullable restore
#line 32 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml"
WriteAttributeValue("", 1052, product.Name, 1052, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n            <div class=\"product-container\" >\n                <a class=\"img-container\"");
            BeginWriteAttribute("href", " href=\"", 1155, "\"", 1167, 1);
#nullable restore
#line 34 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml"
WriteAttributeValue("", 1162, href, 1162, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "be8914cdbae7f43d1f4d553c34ccde4a0393467814840", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1200, "~/", 1200, 2, true);
#nullable restore
#line 35 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml"
AddHtmlAttributeValue("", 1202, product.ThumbnailPath, 1202, 22, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("   \n                </a>\n                <div class=\"text-container\">\n                    <a class=\"detail-link\"");
            BeginWriteAttribute("href", " href=\"", 1356, "\"", 1368, 1);
#nullable restore
#line 38 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml"
WriteAttributeValue("", 1363, href, 1363, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 38 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml"
                                                   Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - $");
#nullable restore
#line 38 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml"
                                                                    Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n                    <button class=\"cart-btn\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1450, "\"", 1482, 3);
            WriteAttributeValue("", 1460, "addToCart(", 1460, 10, true);
#nullable restore
#line 39 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml"
WriteAttributeValue("", 1470, product.Id, 1470, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1481, ")", 1481, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-cart-plus\"></i> </button>\n                </div>\n            </div>\n");
#nullable restore
#line 42 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml"
            
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be8914cdbae7f43d1f4d553c34ccde4a0393467818153", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    <script>\n        initializeCart()\n\n");
#nullable restore
#line 50 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml"
         if (Model.RedirectFromCheckout)
        {
            

#line default
#line hidden
#nullable disable
            WriteLiteral("Snackbar.show({ pos: \'bottom-center\', text: \'Congratulations on your purchase.\' })");
#nullable restore
#line 52 "/home/chase/elixr/ElixrMarket/ElixrMarket.Web/Pages/Store.cshtml"
                                                                                                           
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </script>
    <script>
        // initalize cart on page load
        initializeCart();
        $(document).ready(function () {
            $('#categories, #app-types').multiselect({
                includeSelectAllOption: true,
            });
        });
    </script>

    <style>
        #store #list-container {
            display: flex;
            flex-wrap: wrap;
            justify-content: space-evenly;
            gap: 1rem;
        }

        #store #filter-container {
            display: flex;
            gap: 2rem;
            background-color: white;
            border: 1px solid #B8B8B8;
            border-radius: .5rem;
            padding: .5rem 3rem;
        }

            #store #filter-container > div {
                border-right: 1px solid grey;
                padding-right: 1rem;
                margin-top: .5rem;
                margin-bottom: .5rem;
            }

        #store #categories #app-types {
            background-color: white;
        }

        #store .product-con");
            WriteLiteral(@"tainer {
            border-radius: .5rem;
            flex: 21%;
            background-color: white;
            display: flex;
            flex-direction: column;
            align-items: center;
            border: 1px solid #B8B8B8;
        }

        #store .img-container {

            display: flex;
            justify-content: center;
            height: 7rem;
            width: 100%;
        }

        #store .img-container:hover {
            background-color: #e9e9e9;
            cursor: pointer;
        }

            #store .img-container > img {
                height: 100%;
            }

        #store .text-container {
            padding: 1rem;
            width: 100%;
            display: flex;
            justify-content: space-between;
            align-items: center;
            gap: 1rem;
        }

        #store a {
            text-decoration: none;
            color: black;
        }

        #store .detail-link:hover {
            color: darkslategray;
            text-decoration:");
            WriteLiteral(" underline;\n        }\n\n        #store .cart-btn {\n            flex-grow: 0;\n            border-radius: .3rem;\n            border: 1px solid grey;\n            padding: .3rem;\n        }\n    </style>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ElixrMarket.Web.Pages.StoreModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ElixrMarket.Web.Pages.StoreModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ElixrMarket.Web.Pages.StoreModel>)PageContext?.ViewData;
        public ElixrMarket.Web.Pages.StoreModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591