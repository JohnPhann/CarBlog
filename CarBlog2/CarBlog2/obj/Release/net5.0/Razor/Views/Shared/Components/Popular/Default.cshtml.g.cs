#pragma checksum "E:\Repos\CarBlog2\CarBlog2\Views\Shared\Components\Popular\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a571c58baf35043e7b598d3dd3f19073e166db32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Popular_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Popular/Default.cshtml")]
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
#line 1 "E:\Repos\CarBlog2\CarBlog2\Views\_ViewImports.cshtml"
using CarBlog2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Repos\CarBlog2\CarBlog2\Views\_ViewImports.cshtml"
using CarBlog2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a571c58baf35043e7b598d3dd3f19073e166db32", @"/Views/Shared/Components/Popular/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"287b054c4c84dec825b335ae87eb3639572daee8", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_Popular_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Category>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Repos\CarBlog2\CarBlog2\Views\Shared\Components\Popular\Default.cshtml"
 if(Model != null){

#line default
#line hidden
#nullable disable
            WriteLiteral("        <ul class=\"submenu\">\r\n");
#nullable restore
#line 5 "E:\Repos\CarBlog2\CarBlog2\Views\Shared\Components\Popular\Default.cshtml"
             foreach(var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li><a");
            BeginWriteAttribute("href", " href=\"", 154, "\"", 173, 2);
            WriteAttributeValue("", 161, "/", 161, 1, true);
#nullable restore
#line 7 "E:\Repos\CarBlog2\CarBlog2\Views\Shared\Components\Popular\Default.cshtml"
WriteAttributeValue("", 162, item.Alias, 162, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 7 "E:\Repos\CarBlog2\CarBlog2\Views\Shared\Components\Popular\Default.cshtml"
                                      Write(item.CastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 8 "E:\Repos\CarBlog2\CarBlog2\Views\Shared\Components\Popular\Default.cshtml"
            
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </ul>\r\n");
#nullable restore
#line 13 "E:\Repos\CarBlog2\CarBlog2\Views\Shared\Components\Popular\Default.cshtml"
    
    
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Category>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591