#pragma checksum "C:\Users\Bryan J. Campos\Desktop\CatalogoProductos2\docs\Views\Categoria\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fff5176056c38c906058e1764eff3af43aedcbb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categoria_Index), @"mvc.1.0.view", @"/Views/Categoria/Index.cshtml")]
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
#line 1 "C:\Users\Bryan J. Campos\Desktop\CatalogoProductos2\docs\Views\_ViewImports.cshtml"
using CompratodoUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Bryan J. Campos\Desktop\CatalogoProductos2\docs\Views\_ViewImports.cshtml"
using CompratodoUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fff5176056c38c906058e1764eff3af43aedcbb3", @"/Views/Categoria/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"600ef8310b43f5aeb54d3ecc6ccf670f7d3df3c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Categoria_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 2 "C:\Users\Bryan J. Campos\Desktop\CatalogoProductos2\docs\Views\Categoria\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h3>Categoria</h3>
<div class=""row"">
    <div class=""col-lg-12 col-sm-12 col-md-12"">
        <div class=""mb-3"">
            <input type=""button"" id=""btnNuevo"" class=""btn btn-primary"" value=""Nuevo"" data-toggle=""modal"" data-target=""#exampleModal"" onclick=""limpiar()"" />
        </div>
        <div id=""domDinamico""><span>Cargando...</span></div>
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
                <div class=""modal-body"">
                    <div id");
            WriteLiteral(@"=""mensajeVacios""></div>
                    <input type=""hidden"" id=""txtId"" class=""form-control data"" name=""IIDCATEGORIA"" />
                    <div class=""form-group"">
                        <label>Nombre:</label>
                        <input type=""text"" style=""resize: none;"" autocomplete=""off"" class=""form-control data requerido"" id=""txtNombre"" name=""NOMBRE"" placeholder=""Escriba el nombre de la categoria"" />
                    </div>
                </div>
                <!--footer-->
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal"" id=""btnCerrar"">Cerrar</button>
                    <input type=""button"" class=""btn btn-primary"" id=""btnEnviar"" onclick=""enviar()"" value=""Guardar"" />
                </div>
            </div>
        </div>
    </div>
</div>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fff5176056c38c906058e1764eff3af43aedcbb35751", async() => {
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
        pintarTabla(""/categoria/listar"", [""ID"", ""NOMBRE""], [""iidcategoria"", ""nombre""], ""iidcategoria"","""");
    }
    function eliminar(id) {
        alertify.confirm(""Estas seguro de eliminar este registro?"", function (e) {
            if (e) {
                $.get(""/categoria/eliminar?id="" + id, function (r) {
                    if (r) {
                        alertify.success(""Registro eliminado"");
                        listar();
                    }
                })
            }
        })
    }
    function enviar() {
        if (validarVacios()) {
            var frm = new FormData();
            capturarDatos(frm);
            $.ajax({
                url: ""/categoria/guardar"",
                type: ""POST"",
                processData: false,
                contentType: false,
                data: frm,
                success: function (respuesta) {
                    if (respuesta ");
            WriteLiteral(@"> 0) {
                        alertify.success(""Registro agregado"");
                        document.getElementById(""btnCerrar"").click();
                        listar();
                        limpiar();
                    } else if (respuesta < 0) {
                        alertify.error(""Este registro ya existe en la base de datos"");
                    } else {
                        alertify.error(""Ocurrio un error en el sistema"");
                    }
                }
            })
        } else {
            alertify.error(""Llene los espacios en rojo"");
        }
    }
    function editar(id) {
        $.get(""/categoria/obtenerPorId?id="" + id, function (data) {
            $(""#txtId"").val(data.iidcategoria);
            $(""#txtNombre"").val(data.nombre);
        })
        colorDefault();
    }
    //pintar la tabla
    function pintarTabla(url, cabecera, propiedades, llavePrimaria, estadoVenta = """") {
        $.get(url, function (data) {
            var html = """";//c");
            WriteLiteral(@"on esta pintaremos la tabla
            //inicio tabla
            html += '<table class=""table table-dark table-responsive-sm"" id=""paginar"">';
            /*cabecera de la tabla*/
            html += '<thead class="""">';
            //pintamos las cabeceras utilizando un for
            html += '<tr>';
            for (var i = 0; i < cabecera.length; i++) {
                html += '<th>' + cabecera[i] + '</th>';
            }
            html += '<th>OPERACIONES</th>';
            html += '</tr>';
            html += '</thead>';
            /*cuerpo de la tabla*/
            html += '<tbody>';
            //pintaremos el cuerpo utilizando dos for
            for (var f = 0; f < data.length; f++) {
                html += '<tr>';
                for (var c = 0; c < propiedades.length; c++) {
                    var propiedadActual = propiedades[c];
                    var objeto = data[f];
                    html += '<td>';
                    html += objeto[propiedadActual];
          ");
            WriteLiteral(@"          html += '</td>';
                }
                //la botonera con las cuales podremos editar y eliminar registros
                html += '<td>';
                html += '<button class=""badge badge-primary"" onclick=""editar(' + objeto[llavePrimaria] + ')"" data-toggle=""modal"" data-target=""#exampleModal"">editar</button> ';
                html += '<button class=""badge badge-primary"" onclick=""eliminar(' + objeto[llavePrimaria] + ')"">eliminar</button> ';
                if (estadoVenta != """") {
                    if (objeto[estadoVenta] == 1) {
                        html += '<button class=""badge badge-success"" onclick=""cambiarEstado(' + objeto[llavePrimaria] + "","" + 1 + ')"">en venta</button>';
                    } else {
                        html += '<button class=""badge badge-danger"" onclick=""cambiarEstado(' + objeto[llavePrimaria] + "","" + 0 + ')"">vendido</button>';
                    }
                }
                html += '</td>';
                html += '</tr>';
        ");
            WriteLiteral(@"    }
            html += '</tbody>';
            html += '</table>';
            //fin tabla
            //pintamos la tabla
            document.getElementById(""domDinamico"").innerHTML = html;
            //agregamos el paginado
            $('#paginar').DataTable({
                pageLength: 8,
                lengthMenu: [8, 15, 20, 25]
            });
        });
    }
</script>

");
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
