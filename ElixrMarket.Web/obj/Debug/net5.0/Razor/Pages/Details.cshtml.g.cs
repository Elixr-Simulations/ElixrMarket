#pragma checksum "C:\Users\Chase\Desktop\Work\Elixr\ElixrMarket\ElixrMarket.Web\Pages\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1eb00fadd11ebcdd7d6eee61c616d8ccbcf5575c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ElixrMarket.Web.Pages.Pages_Details), @"mvc.1.0.razor-page", @"/Pages/Details.cshtml")]
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
#line 1 "C:\Users\Chase\Desktop\Work\Elixr\ElixrMarket\ElixrMarket.Web\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Chase\Desktop\Work\Elixr\ElixrMarket\ElixrMarket.Web\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Chase\Desktop\Work\Elixr\ElixrMarket\ElixrMarket.Web\Pages\_ViewImports.cshtml"
using ElixrMarket.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Chase\Desktop\Work\Elixr\ElixrMarket\ElixrMarket.Web\Pages\_ViewImports.cshtml"
using ElixrMarket.Web.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/Details/{id:int}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1eb00fadd11ebcdd7d6eee61c616d8ccbcf5575c", @"/Pages/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c84e7a0c4aa8d2a51fedf6d143ee034de6e8d08", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("main-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Main image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div id=\"details\">\r\n    <div id=\"page-container\">\r\n        <div id=\"summary-container\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1eb00fadd11ebcdd7d6eee61c616d8ccbcf5575c4466", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 197, "~/product-media/", 197, 16, true);
#nullable restore
#line 7 "C:\Users\Chase\Desktop\Work\Elixr\ElixrMarket\ElixrMarket.Web\Pages\Details.cshtml"
AddHtmlAttributeValue("", 213, Model.Product.Id, 213, 17, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 230, "/img/main.jpg", 230, 13, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <div id=summary-text>\r\n                <div id=\"title\">\r\n                    <h3>");
#nullable restore
#line 10 "C:\Users\Chase\Desktop\Work\Elixr\ElixrMarket\ElixrMarket.Web\Pages\Details.cshtml"
                   Write(Model.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                </div>\r\n                <div>");
#nullable restore
#line 12 "C:\Users\Chase\Desktop\Work\Elixr\ElixrMarket\ElixrMarket.Web\Pages\Details.cshtml"
                Write(Model.Product.Summary);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div id=\"btn-container\">\r\n                    <button class=\"btn btn-primary\"><i class=\"fas fa-cart-plus\"></i> - <span>$");
#nullable restore
#line 14 "C:\Users\Chase\Desktop\Work\Elixr\ElixrMarket\ElixrMarket.Web\Pages\Details.cshtml"
                                                                                         Write(Model.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div>\r\n            ");
#nullable restore
#line 19 "C:\Users\Chase\Desktop\Work\Elixr\ElixrMarket\ElixrMarket.Web\Pages\Details.cshtml"
       Write(Model.Product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
    </div>

    <style >
        #details #page-container {
            display: flex;
            flex-direction: column;
            gap: 1rem;
        }

        #details #title {
            display: flex;
            justify-content: space-between;
        }

        #details #summary-container {
            display: flex;
            width: 100%;
            padding-bottom: 1rem;
            gap: 1rem;
            border-bottom: 1px solid #D3D3D3;
        }

        #details #summary-text {
            display: flex;
            flex-direction: column;
            flex-basis: 60%;
            justify-content: space-between;
            gap: 1rem;
        }

        #details img {
            display: flex;
            flex-basis: 40%;
        }

        #details #btn-container {
            display: flex;
            justify-content: flex-end;
            align-items: center;
            gap: 1rem;
        }
    </style>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ElixrMarket.Web.Pages.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ElixrMarket.Web.Pages.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ElixrMarket.Web.Pages.DetailsModel>)PageContext?.ViewData;
        public ElixrMarket.Web.Pages.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
