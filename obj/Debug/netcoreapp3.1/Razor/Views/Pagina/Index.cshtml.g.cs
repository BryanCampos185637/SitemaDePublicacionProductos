#pragma checksum "C:\Users\Bryan J. Campos\Desktop\CatalogoProductos2\CompratodoUI\Views\Pagina\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ab2bdf8d62fda7bd50968964af5ac48c6ca13ce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pagina_Index), @"mvc.1.0.view", @"/Views/Pagina/Index.cshtml")]
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
#line 1 "C:\Users\Bryan J. Campos\Desktop\CatalogoProductos2\CompratodoUI\Views\_ViewImports.cshtml"
using CompratodoUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Bryan J. Campos\Desktop\CatalogoProductos2\CompratodoUI\Views\_ViewImports.cshtml"
using CompratodoUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ab2bdf8d62fda7bd50968964af5ac48c6ca13ce", @"/Views/Pagina/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"600ef8310b43f5aeb54d3ecc6ccf670f7d3df3c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Pagina_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/funcionesGenericas.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Bryan J. Campos\Desktop\CatalogoProductos2\CompratodoUI\Views\Pagina\Index.cshtml"
  
    ViewData["Title"] = "Pagina";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <h3>Pagina</h3>
<div class=""row"">
    <div class=""col-12"">
        <div class=""mb-3"">
            <input type=""button"" class=""btn btn-primary"" value=""Nuevo"" data-toggle=""modal"" data-target=""#exampleModal"" onclick=""limpiar()""/>
        </div>
        <div id=""domDinamico""><span>Cargando...</span></div>
    </div>
</div>
<!-- Modal -->
<div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Formulario</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <!--Cuerpo-->
            <div class=""modal-body"">
                <div id=""mensajeVacios""></div>
                <input ty");
            WriteLiteral(@"pe=""hidden"" id=""iidpagina"" class=""form-control data"" name=""Iidpagina"" />
                <div class=""form-group"">

                    <label>Mensaje:</label>
                    <input type=""text"" autocomplete=""off""autofocus id=""mensaje"" class=""form-control data requerido"" name=""Mensaje"" placeholder=""Escriba el mensaje de la pagina"" />

                </div>
                <div class=""form-group"">

                    <label>Accion:</label>
                    <input type=""text"" autocomplete=""off"" id=""accion"" class=""form-control data requerido"" name=""Accion"" placeholder=""Escriba la accion de la pagina"" />

                </div>
                <div class=""form-group"">

                    <label>Controlador:</label>
                    <input type=""text"" autocomplete=""off"" id=""controlador"" class=""form-control data requerido"" name=""Controlador"" placeholder=""Escriba el controlador de la pagina"" />

                </div>

            </div>
            <!--footer-->
            <div cl");
            WriteLiteral(@"ass=""modal-footer"">
                <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal"" id=""btnCerrar"">Cerrar</button>
                <input type=""button"" class=""btn btn-primary"" id=""btnEnviar"" onclick=""enviar()"" value=""Guardar"" />
            </div>
        </div>
    </div>
</div>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ab2bdf8d62fda7bd50968964af5ac48c6ca13ce6286", async() => {
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
            WriteLiteral(@"
<script>
    $(function () {
        listar();
    });
    function listar() {
        crearTabla(""/Pagina/Listar"", [""mensaje"", ""accion"", ""controlador""], ""iidpagina"",
            [""MENSAJE"", ""ACCION"", ""CONTROLADOR""], document.getElementById(""domDinamico""));
    }
    function detalle(id) {
        document.getElementById(""mensajeVacios"").innerHTML = """";
        $.get(""/pagina/obtenerPorId?id="" + id, function (data) {
            colorDefault();
            $(""#iidpagina"").val(data.iidpagina);
            $(""#mensaje"").val(data.mensaje);
            $(""#accion"").val(data.accion);
            $(""#controlador"").val(data.controlador);
        });
    }
    function eliminar(id) {
        alertify.confirm(""¿Seguro deseas eliminar el registro?"", function (e) {
            if (e) {
                eliminarData(""/pagina/eliminar?id="" + id);
            }
        });
    }
    function enviar() {
        if (validarVacios()) {
            var frm = new FormData();
            capturarDato");
            WriteLiteral("s(frm);\r\n            EnviarInformacion(\"/pagina/guardar\", frm, false);\r\n        }\r\n    }\r\n</script>\r\n\r\n");
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
