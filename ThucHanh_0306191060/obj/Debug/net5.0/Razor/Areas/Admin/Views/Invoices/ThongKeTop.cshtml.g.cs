#pragma checksum "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Invoices\ThongKeTop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64b4c8e3bc62d1e58a88601a6461a5f1416123c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Invoices_ThongKeTop), @"mvc.1.0.view", @"/Areas/Admin/Views/Invoices/ThongKeTop.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64b4c8e3bc62d1e58a88601a6461a5f1416123c9", @"/Areas/Admin/Views/Invoices/ThongKeTop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a59cf5e5c442e075879082985e4b28e7a327ca9", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Invoices_ThongKeTop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ThucHanh_0306191060.Areas.Admin.Models.InvoiceDetail>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ThongKeTop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Invoices\ThongKeTop.cshtml"
      
        ViewData["Title"] = "Thong ke doanh thu";
        Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <h1></h1>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64b4c8e3bc62d1e58a88601a6461a5f1416123c94231", async() => {
                WriteLiteral("\r\n        <input type=\"number\" name=\"top\"");
                BeginWriteAttribute("value", " value=\"", 426, "\"", 434, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <button type=\"submit\">Thống kê</button>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <!--<th>-->\r\n");
            WriteLiteral(" <!--InvoiceId\r\n                </th>-->\r\n                <th>\r\n");
            WriteLiteral(" Product\r\n                </th>\r\n                <th>\r\n");
            WriteLiteral(" Quantity\r\n                </th>\r\n                <th>\r\n");
            WriteLiteral(" UnitPrice\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 38 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Invoices\ThongKeTop.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n");
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 45 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Invoices\ThongKeTop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Product.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 48 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Invoices\ThongKeTop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 51 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Invoices\ThongKeTop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                   \r\n                </tr>\r\n");
#nullable restore
#line 55 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\ThucHanh_0306191060\ThucHanh_0306191060\Areas\Admin\Views\Invoices\ThongKeTop.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n");
            WriteLiteral("    </table>\r\n");
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