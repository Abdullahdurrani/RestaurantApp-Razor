#pragma checksum "D:\abdullah\Development\C#\Asp.net core\Pluralsight\Asp.net Core Fundamentals\RestaurantApp-Razor\RestaurantApp-Razor\Pages\Shared\Components\RestaurantCount\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb278f6e19019fac4cc405e8486415ea4f5a424a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RestaurantApp_Razor.Pages.Shared.Components.RestaurantCount.Pages_Shared_Components_RestaurantCount_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/RestaurantCount/Default.cshtml")]
namespace RestaurantApp_Razor.Pages.Shared.Components.RestaurantCount
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
#line 1 "D:\abdullah\Development\C#\Asp.net core\Pluralsight\Asp.net Core Fundamentals\RestaurantApp-Razor\RestaurantApp-Razor\Pages\_ViewImports.cshtml"
using RestaurantApp_Razor;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb278f6e19019fac4cc405e8486415ea4f5a424a", @"/Pages/Shared/Components/RestaurantCount/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3931a720a9ac25478572646726eb071c8067aaf5", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_RestaurantCount_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"alert alert-info mt-2\">\r\n\r\n    Total <b>");
#nullable restore
#line 5 "D:\abdullah\Development\C#\Asp.net core\Pluralsight\Asp.net Core Fundamentals\RestaurantApp-Razor\RestaurantApp-Razor\Pages\Shared\Components\RestaurantCount\Default.cshtml"
        Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>  restaurants\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591