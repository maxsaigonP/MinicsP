#pragma checksum "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Carts\Duyetdetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4388e5dfbb5965ecc016587d086d9c0ae7cf5971"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Carts_Duyetdetail), @"mvc.1.0.view", @"/Areas/Admin/Views/Carts/Duyetdetail.cshtml")]
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
#line 1 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\_ViewImports.cshtml"
using ThucHanh_0306191060;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\_ViewImports.cshtml"
using ThucHanh_0306191060.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4388e5dfbb5965ecc016587d086d9c0ae7cf5971", @"/Areas/Admin/Views/Carts/Duyetdetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a59cf5e5c442e075879082985e4b28e7a327ca9", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Carts_Duyetdetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ThucHanh_0306191060.Areas.Admin.Models.InvoiceDetail>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Carts\Duyetdetail.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n");
            WriteLiteral("            <th>\r\n                ");
#nullable restore
#line 18 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Carts\Duyetdetail.cshtml"
           Write(Html.DisplayNameFor(model => model.Product));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Carts\Duyetdetail.cshtml"
           Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Carts\Duyetdetail.cshtml"
           Write(Html.DisplayNameFor(model => model.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 30 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Carts\Duyetdetail.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n");
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 37 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Carts\Duyetdetail.cshtml"
               Write(Html.DisplayFor(modelItem => item.Product.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 40 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Carts\Duyetdetail.cshtml"
               Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 43 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Carts\Duyetdetail.cshtml"
               Write(Html.DisplayFor(modelItem => item.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>             \r\n            </tr>\r\n");
#nullable restore
#line 46 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Carts\Duyetdetail.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ThucHanh_0306191060.Areas.Admin.Models.InvoiceDetail>> Html { get; private set; }
    }
}
#pragma warning restore 1591
