#pragma checksum "C:\Users\Bryan J. Campos\Desktop\CatalogoProductos2\CompratodoUI\Views\TipoUsuario\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "773bd1b503394793ae7481949e71a634014d3b42"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TipoUsuario_Index), @"mvc.1.0.view", @"/Views/TipoUsuario/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"773bd1b503394793ae7481949e71a634014d3b42", @"/Views/TipoUsuario/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"600ef8310b43f5aeb54d3ecc6ccf670f7d3df3c1", @"/Views/_ViewImports.cshtml")]
    public class Views_TipoUsuario_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 2 "C:\Users\Bryan J. Campos\Desktop\CatalogoProductos2\CompratodoUI\Views\TipoUsuario\Index.cshtml"
  
    ViewData["Title"] = "Tipo usuario";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h3>Tipo usuario</h3>
<div class=""row"">
    <div class=""col-12"">
        <div class=""mb-3"">
            <button class=""btn btn-primary"" data-toggle=""modal"" data-target=""#exampleModal"" onclick=""limpiar()"">Nuevo</button>
        </div>
        <div id=""domDinamico"">
            <span>Cargando...</span>
        </div>
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
           ");
            WriteLiteral(@"     <input type=""hidden"" id=""iidtipousuario"" class=""form-control data"" name=""Iidtipousuario"" />
                <div class=""form-group"">
                    <label>Nombre:</label>
                    <input type=""text"" autocomplete=""off"" autofocus id=""nombre"" class=""form-control data requerido"" name=""Nombre"" placeholder=""Escriba el nombre del tipo usuario"" />
                </div>
                <div class=""form-group"">
                    <label>Descripcion:</label>
                    <input type=""text"" autocomplete=""off"" id=""descripcion"" class=""form-control data requerido"" name=""Descripcion"" placeholder=""Escriba una breve descripcion de los permisos"" />
                </div>
                <div class=""form-group"">
                    <label>Paginas que podra ver:</label>
                    <div id=""listadoPaginas""></div>
                </div>
            </div>
            <!--footer-->
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-danger");
            WriteLiteral("\" data-dismiss=\"modal\" id=\"btnCerrar\">Cerrar</button>\r\n                <input type=\"button\" class=\"btn btn-primary\" id=\"btnEnviar\" onclick=\"enviar()\" value=\"Guardar\" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "773bd1b503394793ae7481949e71a634014d3b426243", async() => {
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
        listarPaginas();
    })
    function listar() {
        crearTabla(""/tipousuario/listar"", [""nombre"", ""descripcion""], ""iidtipousuario"",
            [""NOMBRE"", ""DESCRIPCION""], document.getElementById(""domDinamico""));
    }
    function detalle(id) {
        $.get(""/tipousuario/obtenerPorId?id="" + id, function (data) {
            $(""#iidtipousuario"").val(data.iidtipousuario);
            $(""#nombre"").val(data.nombre);
            $(""#descripcion"").val(data.descripcion);
        })
    }
    function enviar() {
        if (validarVacios()) {
            var frm = new FormData();
            capturarDatos(frm);
            var checkes = document.getElementsByClassName(""paginasCheck"");
            for (var i = 0; i < checkes.length; i++) {
                if (checkes[i].checked == true) {// si el input esta marcado
                    var idpagina = checkes[i].value;
                    frm.append(""idPaginas[]"", idpagina.replace(""chec");
            WriteLiteral(@"k"", """"));
                }
            }
            EnviarInformacion(""/tipousuario/guardar"",frm,false);
        }
    }
    function eliminar(id) {
        alertify.confirm(""¿Seguro deseas eliminar el registro?"", function (r) {
            if (r) {
                eliminarData(""/tipousuario/eliminar?id="" + id);
            }
        })
    }
    function listarPaginas() {
        $.get(""/pagina/listar"", function (data) {
            var html = '';
            html += '<table>';
            for (var i = 0; i < data.length; i++) {
                html += '<tr>';
                html += '<td><label>' + data[i].mensaje + '</label></td>';
                html += '<td>';
                html += '<input type=""checkbox"" class=""paginasCheck"" value=""check' + data[i].iidpagina + '""/>';
                html += '</td>';
                html += '</tr>';
            }
            html += '</table>';
            $(""#listadoPaginas"").html(html);//pintamos el contenido
        });
    }
</script");
            WriteLiteral(">\r\n\r\n");
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
