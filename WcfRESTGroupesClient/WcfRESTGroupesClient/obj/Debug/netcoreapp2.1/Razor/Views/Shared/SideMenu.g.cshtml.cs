#pragma checksum "D:\BdeB\session04\A16-PROGRAMMATION D'APPLICATIONS WEB\projetSession\option 02\WcfRESTGroupesClient\WcfRESTGroupesClient\Views\Shared\SideMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed073e0868150120550fa7a99c26f1ffa079f3a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_SideMenu), @"mvc.1.0.view", @"/Views/Shared/SideMenu.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/SideMenu.cshtml", typeof(AspNetCore.Views_Shared_SideMenu))]
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
#line 1 "D:\BdeB\session04\A16-PROGRAMMATION D'APPLICATIONS WEB\projetSession\option 02\WcfRESTGroupesClient\WcfRESTGroupesClient\Views\_ViewImports.cshtml"
using WcfRESTGroupesClient;

#line default
#line hidden
#line 2 "D:\BdeB\session04\A16-PROGRAMMATION D'APPLICATIONS WEB\projetSession\option 02\WcfRESTGroupesClient\WcfRESTGroupesClient\Views\_ViewImports.cshtml"
using WcfRESTGroupesClient.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed073e0868150120550fa7a99c26f1ffa079f3a0", @"/Views/Shared/SideMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bcd111adbeae28f44e8f7e151a09dfe003febe06", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_SideMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Content/Images/director1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-top:-20px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(120, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            BeginContext(179, 175, true);
            WriteLiteral("\r\n<div class=\"panel panel-default\">\r\n    <div class=\"panel-heading\">\r\n        <h4>Menu Item</h4>\r\n    </div>\r\n    <div class=\"panel-body\">\r\n        <ul class=\"list-group\">\r\n\r\n");
            EndContext();
#line 15 "D:\BdeB\session04\A16-PROGRAMMATION D'APPLICATIONS WEB\projetSession\option 02\WcfRESTGroupesClient\WcfRESTGroupesClient\Views\Shared\SideMenu.cshtml"
             if (Model != null)
            {

                foreach (var item in Model)
                {


#line default
#line hidden
            BeginContext(470, 50, true);
            WriteLiteral("                    <li class=\"list-group-item\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 520, "\"", 537, 1);
#line 21 "D:\BdeB\session04\A16-PROGRAMMATION D'APPLICATIONS WEB\projetSession\option 02\WcfRESTGroupesClient\WcfRESTGroupesClient\Views\Shared\SideMenu.cshtml"
WriteAttributeValue("", 527, item.Link, 527, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(538, 35, true);
            WriteLiteral(" class=\"btn btn-primary btn-block\">");
            EndContext();
            BeginContext(574, 13, false);
#line 21 "D:\BdeB\session04\A16-PROGRAMMATION D'APPLICATIONS WEB\projetSession\option 02\WcfRESTGroupesClient\WcfRESTGroupesClient\Views\Shared\SideMenu.cshtml"
                                                                                                  Write(item.LinkName);

#line default
#line hidden
            EndContext();
            BeginContext(587, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 22 "D:\BdeB\session04\A16-PROGRAMMATION D'APPLICATIONS WEB\projetSession\option 02\WcfRESTGroupesClient\WcfRESTGroupesClient\Views\Shared\SideMenu.cshtml"

                }
            }

#line default
#line hidden
            BeginContext(634, 501, true);
            WriteLiteral(@"
            <li class=""list-group-item""><a href=""http://google.com"" class=""btn btn-success btn-block"">Google</a></li>
            <li class=""list-group-item""><a href=""http://technotipstutorial.blogspot.com"" class=""btn btn-warning btn-block"">Official Blog</a></li>

        </ul>
    </div>
</div>


<div class=""thumbnail"">
    <div class=""panel panel-primary"">
        <div class=""panel-heading"">
            <h3 class=""panel-title"">Director Message</h3>
        </div>
    </div>
    ");
            EndContext();
            BeginContext(1135, 77, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "48e2247f39904b1faa1701553f7613ed", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1212, 271, true);
            WriteLiteral(@"
    <div class=""caption"">
        <h3>Ashish Tiwary</h3>
        <p>&para; Have faith in us, We will give you full satisfaction by providing best service. &para;</p>
        <p><a href=""#"" class=""btn btn-primary"" role=""button"">See more</a> </p>
    </div>
</div>
");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591