#pragma checksum "C:\Users\dgonzalezdelaoliva\source\repos\WebAPi\NetCore\MySQL\WebAPiMySQL\WebAPiMySQL\Views\Usuarios\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a010d4f6cc66fdf384b4800f088eb1247ddef6c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuarios_Details), @"mvc.1.0.view", @"/Views/Usuarios/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a010d4f6cc66fdf384b4800f088eb1247ddef6c8", @"/Views/Usuarios/Details.cshtml")]
    public class Views_Usuarios_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebAPiMySQL.Models.cca_user>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\dgonzalezdelaoliva\source\repos\WebAPi\NetCore\MySQL\WebAPiMySQL\WebAPiMySQL\Views\Usuarios\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>cca_user</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\dgonzalezdelaoliva\source\repos\WebAPi\NetCore\MySQL\WebAPiMySQL\WebAPiMySQL\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdRol));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\dgonzalezdelaoliva\source\repos\WebAPi\NetCore\MySQL\WebAPiMySQL\WebAPiMySQL\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdRol));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\dgonzalezdelaoliva\source\repos\WebAPi\NetCore\MySQL\WebAPiMySQL\WebAPiMySQL\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdSite));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\dgonzalezdelaoliva\source\repos\WebAPi\NetCore\MySQL\WebAPiMySQL\WebAPiMySQL\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdSite));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\dgonzalezdelaoliva\source\repos\WebAPi\NetCore\MySQL\WebAPiMySQL\WebAPiMySQL\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Login));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\dgonzalezdelaoliva\source\repos\WebAPi\NetCore\MySQL\WebAPiMySQL\WebAPiMySQL\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayFor(model => model.Login));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Users\dgonzalezdelaoliva\source\repos\WebAPi\NetCore\MySQL\WebAPiMySQL\WebAPiMySQL\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.VersionShow));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Users\dgonzalezdelaoliva\source\repos\WebAPi\NetCore\MySQL\WebAPiMySQL\WebAPiMySQL\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayFor(model => model.VersionShow));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "C:\Users\dgonzalezdelaoliva\source\repos\WebAPi\NetCore\MySQL\WebAPiMySQL\WebAPiMySQL\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "C:\Users\dgonzalezdelaoliva\source\repos\WebAPi\NetCore\MySQL\WebAPiMySQL\WebAPiMySQL\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "C:\Users\dgonzalezdelaoliva\source\repos\WebAPi\NetCore\MySQL\WebAPiMySQL\WebAPiMySQL\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdCalculationCycleType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "C:\Users\dgonzalezdelaoliva\source\repos\WebAPi\NetCore\MySQL\WebAPiMySQL\WebAPiMySQL\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdCalculationCycleType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1495, "\"", 1523, 1);
#nullable restore
#line 52 "C:\Users\dgonzalezdelaoliva\source\repos\WebAPi\NetCore\MySQL\WebAPiMySQL\WebAPiMySQL\Views\Usuarios\Details.cshtml"
WriteAttributeValue("", 1510, Model.IdUser, 1510, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n    <a asp-action=\"Index\">Back to List</a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebAPiMySQL.Models.cca_user> Html { get; private set; }
    }
}
#pragma warning restore 1591
