#pragma checksum "C:\Users\artem\Studing\Courses\TMS\Project\Headphones\HeadphonesShop\HeadphonesShop.PresentationWebMVC\Views\CommonUser\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b27264a6f05354b7ac6aed5b856589586f4cca41"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CommonUser_Index), @"mvc.1.0.view", @"/Views/CommonUser/Index.cshtml")]
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
#line 1 "C:\Users\artem\Studing\Courses\TMS\Project\Headphones\HeadphonesShop\HeadphonesShop.PresentationWebMVC\Views\_ViewImports.cshtml"
using HeadphonesShop.PresentationWebMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\artem\Studing\Courses\TMS\Project\Headphones\HeadphonesShop\HeadphonesShop.PresentationWebMVC\Views\_ViewImports.cshtml"
using HeadphonesShop.PresentationWebMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b27264a6f05354b7ac6aed5b856589586f4cca41", @"/Views/CommonUser/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"999b5250435e2fc136c8cde20bb320c4ad76c344", @"/Views/_ViewImports.cshtml")]
    public class Views_CommonUser_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HeadphonesShop.PresentationWebMVC.Models.DTO.CommonUserIndexDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div>
    <table class=""table table-bordered table-striped"">
        <thead class=""table-info"">
            <tr>
                <td class=""admin-heaphones-table-column-0"">
                    <a>Name</a>
                </td>
                <td class=""admin-heaphones-table-column-1"">
                    <a>Company</a>
                </td>
                <td class=""admin-heaphones-table-column-2"">
                    <a>Design</a>
                </td>
                <td class=""admin-heaphones-table-column-3"">
                    <a>Min Frequancy</a>
                </td>
                <td class=""admin-heaphones-table-column-4"">
                    <a>Max Frequency</a>
                </td>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 24 "C:\Users\artem\Studing\Courses\TMS\Project\Headphones\HeadphonesShop\HeadphonesShop.PresentationWebMVC\Views\CommonUser\Index.cshtml"
             foreach (var h in Model.Headphones)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 990, "\"", 1063, 1);
#nullable restore
#line 28 "C:\Users\artem\Studing\Courses\TMS\Project\Headphones\HeadphonesShop\HeadphonesShop.PresentationWebMVC\Views\CommonUser\Index.cshtml"
WriteAttributeValue("", 997, Url.Action("InfoHeadphones", "CommonUser", new { name = h.Name }), 997, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" >");
#nullable restore
#line 28 "C:\Users\artem\Studing\Courses\TMS\Project\Headphones\HeadphonesShop\HeadphonesShop.PresentationWebMVC\Views\CommonUser\Index.cshtml"
                                                                                                 Write(h.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </td>\r\n                    <td>\r\n                        <a>");
#nullable restore
#line 31 "C:\Users\artem\Studing\Courses\TMS\Project\Headphones\HeadphonesShop\HeadphonesShop.PresentationWebMVC\Views\CommonUser\Index.cshtml"
                      Write(h.Company.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </td>\r\n                    <td>\r\n                        <a>");
#nullable restore
#line 34 "C:\Users\artem\Studing\Courses\TMS\Project\Headphones\HeadphonesShop\HeadphonesShop.PresentationWebMVC\Views\CommonUser\Index.cshtml"
                      Write(h.Design.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </td>\r\n                    <td>\r\n                        <a>");
#nullable restore
#line 37 "C:\Users\artem\Studing\Courses\TMS\Project\Headphones\HeadphonesShop\HeadphonesShop.PresentationWebMVC\Views\CommonUser\Index.cshtml"
                      Write(h.MinFrequency);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </td>\r\n                    <td>\r\n                        <a>");
#nullable restore
#line 40 "C:\Users\artem\Studing\Courses\TMS\Project\Headphones\HeadphonesShop\HeadphonesShop.PresentationWebMVC\Views\CommonUser\Index.cshtml"
                      Write(h.MaxFrequency);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 43 "C:\Users\artem\Studing\Courses\TMS\Project\Headphones\HeadphonesShop\HeadphonesShop.PresentationWebMVC\Views\CommonUser\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HeadphonesShop.PresentationWebMVC.Models.DTO.CommonUserIndexDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
