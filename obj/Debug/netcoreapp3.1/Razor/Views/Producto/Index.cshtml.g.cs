#pragma checksum "C:\Users\Bryan J. Campos\Desktop\git\SitemaDePublicacionProductos\Views\Producto\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9678cc04bf0c616803610ef283d4e2e3bc0a9764"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Producto_Index), @"mvc.1.0.view", @"/Views/Producto/Index.cshtml")]
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
#line 1 "C:\Users\Bryan J. Campos\Desktop\git\SitemaDePublicacionProductos\Views\_ViewImports.cshtml"
using CompratodoUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Bryan J. Campos\Desktop\git\SitemaDePublicacionProductos\Views\_ViewImports.cshtml"
using CompratodoUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9678cc04bf0c616803610ef283d4e2e3bc0a9764", @"/Views/Producto/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"600ef8310b43f5aeb54d3ecc6ccf670f7d3df3c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Producto_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/PeticionesAJAX/catalogo.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Bryan J. Campos\Desktop\git\SitemaDePublicacionProductos\Views\Producto\Index.cshtml"
  
    ViewData["Title"] = "Catalogo";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    #txtBuscarProducto {
        border-top-left-radius: 30px !important;
    }

    #btnBuscar {
        border-top-right-radius: 30px !important;
    }

    .ir-arriba {
        display: none;
        border-radius: 30px;
        color: white;
        position: fixed;
        bottom: 70px; /*baje*/
        right: 0; /*/derecha*/
        z-index: 100;
    }

    #btnReportar {
        right: 0px !important;
    }
</style>
<input type=""hidden"" id=""idSesion""");
            BeginWriteAttribute("value", " value=\"", 538, "\"", 557, 1);
#nullable restore
#line 28 "C:\Users\Bryan J. Campos\Desktop\git\SitemaDePublicacionProductos\Views\Producto\Index.cshtml"
WriteAttributeValue("", 546, ViewBag.id, 546, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
<div class=""row"">
    <div class=""col-12 mb-3"">
        <div class=""input-group"">
            <input type=""text"" id=""txtBuscarProducto"" placeholder=""Buscar por nombre o categoria"" class=""form-control"" />
            <input type=""button"" id=""btnBuscar"" onclick=""limpiarBusqueda()"" value=""Limpiar"" class=""btn btn-primary"" />
        </div>
        <button class=""ir-arriba btn btn-primary"" type=""button"" id=""btnSubir"">subir</button>
    </div>
</div>
<div class=""row"" id=""cartas"">
    <div class=""col-12""><span>Cargando...</span></div>
</div>
<!-- Modal denuncia-->
<div class=""modal fade"" id=""modalReporte"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-body"">
                <div id=""contenidoDenuncia"">
                </div>
            </div>
            <!--footer-->
            <div class=""modal-footer"">
             ");
            WriteLiteral(@"   <input type=""button"" class=""btn btn-danger"" data-dismiss=""modal"" id=""btnCerrarModal"" value=""Cancelar"" />
                <input type=""button"" class=""btn btn-primary"" id=""btnEnviarReporte"" onclick=""denunciarPublicacion()"" value=""Denunciar"" />
            </div>
        </div>
    </div>
</div>
<!-- Modal -->
<div class=""modal fade"" id=""verImagen"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <div class=""text-center"">
                    <h3 id=""nombreproducto""></h3>
                </div>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div id=""verImagenModal""><span >Cargando...</span></div>
        </div>
    </div>
</div>");
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9678cc04bf0c616803610ef283d4e2e3bc0a97646863", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
