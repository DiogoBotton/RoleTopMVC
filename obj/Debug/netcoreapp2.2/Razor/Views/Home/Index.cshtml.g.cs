#pragma checksum "C:\Users\42299106812\Documents\Diogo B - D.E.V TARDE\ROLE TOP\RoleTOP_MVC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6fa81eef73d79d9447ce8648b10849834f78af6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\42299106812\Documents\Diogo B - D.E.V TARDE\ROLE TOP\RoleTOP_MVC\Views\_ViewImports.cshtml"
using RoleTOP_MVC;

#line default
#line hidden
#line 2 "C:\Users\42299106812\Documents\Diogo B - D.E.V TARDE\ROLE TOP\RoleTOP_MVC\Views\_ViewImports.cshtml"
using RoleTOP_MVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6fa81eef73d79d9447ce8648b10849834f78af6a", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abf37fd8b6091f6d582b5d62d4e73d7937644749", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 40, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"pt-br\">\r\n\r\n");
            EndContext();
            BeginContext(40, 364, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6fa81eef73d79d9447ce8648b10849834f78af6a3421", async() => {
                BeginContext(46, 351, true);
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <title>Rolê TOP</title>
    <link rel=""stylesheet"" href=""css/style.css"">
    <link rel=""stylesheet"" href=""css/gallery.min.css"">
    <link rel=""stylesheet"" href=""css/gallery.theme.css"">
    <link href=""Img/Logo role top.png"" rel=""icon"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(404, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(408, 6126, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6fa81eef73d79d9447ce8648b10849834f78af6a4978", async() => {
                BeginContext(414, 5687, true);
                WriteLiteral(@"
    <header>
        <!--Input e label para dar ao site a funcionalidade de design responsivo-->
        <input type=""checkbox"" id=""check"">
        <label id=""icone"" for=""check""><img src=""Img/menu opcoes.png"" height=""67px""></label>

        <div class=""bg-mobile""></div>
        <div class=""barra"">
            <nav class=""menu"">
                <ul>
                    <li><img src=""Img/Logo role top.png"" class=""logo""></li>
                    <li><a href=""Index.html"">Home</a></li>
                    <li><a href=""Estrutura.html"">Estrutura</a></li>
                    <li><a href=""Programacao.html"">Programação</a></li>
                    <li><a href=""Agende Aqui.html"">Agende Aqui</a></li>
                    <li><a href=""Perguntas frequentes.html"">Perguntas Frequentes</a></li>
                    <li><a href=""Cadastro.html"">Cadastre-se</a></li>
                    <li><a href=""Login.html"">Login</a></li>
                </ul>
            </nav>
        </div>
    </header>
    <main>
  ");
                WriteLiteral(@"      <div class=""banner-area"">
            <p class=""space-banner""></p>
            <a href=""Agende Aqui.html"">Agende Seu Evento Aqui</a>
            <p class=""space-banner""></p>
        </div>
        <div id=""sobrenos"">
            <p>Sobre nós</p>
            <p> Em química e física, Teoria atômica ou teoria atómica é a teoria científica que afirma que a matéria é
                constituída por unidades fundamentais chamadas átomos. Um átomo, de acordo com esta teoria, é uma
                partícula extremamente pequena, porém não é infinitamente pequena.
                A Teoria atômica havia sido proposta por filósofos, como Descartes, antes dela ter uma base
                experimental. Havia, desde os tempos antigos, duas hipóteses sobre a composição da matéria: ou ela seria
                formada por partículas que não poderiam ser mais divididas, ou não haveria nenhum limite à
                divisibilidade da matéria. A primeira ideia costuma ser atribuída aos epicuristas, porém su");
                WriteLiteral(@"as origens
                podem ser ainda mais antigas. A cosmogenia de Demócrito se baseia nesta ideia, que ele derivou de
                Leucipo. Segundo Daubeny, Mosco, um fenício que floresceu antes da Guerra de Troia, teria estas ideias,
                assim como as mônadas de Pitágoras, cuja origem seria egípcia. Segundo Mr. Colebrooke, citado por
                Daubeny, os hindus também tinham, no passado, uma teoria atômica.
            </p>
        </div>
        <div class=""programacao"">
            <p class=""programacao-top"">ProgramacAo</p>
            <div class=""gallery autoplay items-4"">
                <div id=""item-1"" class=""control-operator""></div>
                <div id=""item-2"" class=""control-operator""></div>
                <div id=""item-3"" class=""control-operator""></div>
                <div id=""item-4"" class=""control-operator""></div>

                <figure class=""item"">
                    <h1><a href=""evento-publico.html""><img src=""Img/Pink floyd.png""></a></h1>
 ");
                WriteLiteral(@"               </figure>
                <figure class=""item"">
                    <h1><img src=""Img/legiao urbana.jpg""></h1>
                </figure>
                <figure class=""item"">
                    <h1><img src=""Img/metallica.jpg""></h1>
                </figure>
                <figure class=""item"">
                    <h1><img src=""Img/velhas virgens.jpg""></h1>
                </figure>

                <div class=""controls"">
                    <a href=""#item-1"" class=""control-button"">.</a>
                    <a href=""#item-2"" class=""control-button"">.</a>
                    <a href=""#item-3"" class=""control-button"">.</a>
                    <a href=""#item-4"" class=""control-button"">.</a>
                </div>
            </div>
            <p class=""programacao-bottom"">Role tOp</p>
        </div>
        
        <div id=""tabela-precos"">
            <p>Estimativa de precos</p>
            <img src=""Img/tabela-de-precos.svg"">
        </div>

        <div id=""localizacao");
                WriteLiteral(@""">
            <p>LocalizacAo</p>
            <iframe
                src=""https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d14631.441758630948!2d-46.646275746032714!3d-23.53752146705796!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xb23619858bc7e63e!2sEscola%20SENAI%20de%20Inform%C3%A1tica!5e0!3m2!1spt-BR!2sbr!4v1567281677957!5m2!1spt-BR!2sbr""
                frameborder=""0"" style=""border:0;"" allowfullscreen=""""></iframe>
        </div>

        <p class=""divisoria-rodape""></p>
    </main>
    <footer>
        <div class=""rodape"">
            <div class=""rodape-img"">

                <div>
                    <img src=""Img/Logo role top.png"" class=""logo"">
                </div>
                <div>
                    <img src=""Img/whatsapp.png"" usemap=""#whatsapp"">
                    <map name=""whatsapp"">
                        <area shape=""rect"" coords=""112,37,266,57""
                            href=""https://api.whatsapp.com/send?phone=55111234-5678"" target=""_blank"">
                  ");
                WriteLiteral(@"      <area shape=""rect"" coords=""111,62,264,78""
                            href=""https://api.whatsapp.com/send?phone=55114098-7654"" target=""_blank"">
                    </map>
                </div>
            </div>
        </div>
        <p class=""divisoria-rodape""></p>
        <div class=""rodape-meio"">
            <div>
                <p>Localização</p>
                <p>Alameda Barão de Limeira,539 - Santa Cecilia,<br> São Paulo - SP, 01202-001</p>
            </div>
            <div>
                <p>Email</p>
                <p>roletop");
                EndContext();
                BeginContext(6102, 255, true);
                WriteLiteral("@gmail.com</p>\r\n            </div>\r\n            <div>\r\n                <p>Funcionamento</p>\r\n                <p>Quinta à Domingo - 20h às 05h</p>\r\n            </div>\r\n        </div>\r\n        <div class=\"rodape-fim\">\r\n            <div>\r\n                <p>");
                EndContext();
                BeginContext(6358, 169, true);
                WriteLiteral("@Rolê Top 2019</p>\r\n            </div>\r\n            <div>\r\n                <p>® Todos os direitos reservados</p>\r\n            </div>\r\n        </div>\r\n\r\n    </footer>\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6534, 15, true);
            WriteLiteral("\r\n\r\n</html>\r\n\r\n");
            EndContext();
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