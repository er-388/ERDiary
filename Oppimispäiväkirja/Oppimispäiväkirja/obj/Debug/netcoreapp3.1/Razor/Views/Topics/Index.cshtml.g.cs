#pragma checksum "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33a33f15519d8bbfbd9d43838dab07d11652fa64"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Topics_Index), @"mvc.1.0.view", @"/Views/Topics/Index.cshtml")]
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
#line 1 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\_ViewImports.cshtml"
using Oppimispäiväkirja;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\_ViewImports.cshtml"
using Oppimispäiväkirja.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33a33f15519d8bbfbd9d43838dab07d11652fa64", @"/Views/Topics/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"599ee2915f89661e27a2f77632287bf72081608c", @"/Views/_ViewImports.cshtml")]
    public class Views_Topics_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Oppimispäiväkirja.Models.Topic>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("link-small"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("link-small text-small"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-3\">\r\n            <p>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33a33f15519d8bbfbd9d43838dab07d11652fa646098", async() => {
                WriteLiteral("Lisää uusi aihe");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n\r\n        <div class=\"col-3\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33a33f15519d8bbfbd9d43838dab07d11652fa647432", async() => {
                WriteLiteral(@"
                <label for=""hakusana""></label>
                <input type=""text"" placeholder=""Hae aihetta"" name=""hakusana"" onFocus=""kohdistus(this)"" onblur=""focusPois(this)"">
                <button type=""submit"" class=""search-button"">
                    <!--oletustyyppi = submit (=> ei pakollinen)-->
                    <img src=""images/search.png"">
                </button>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>

        <div class=""col-3"">
            <button class=""link-small text-small"" id=""nayta-kaikki-tiedot"">Näytä/piilota lisätiedot</button>
        </div>

        <div class=""col-1"">
        </div>

        <div class=""col-2"">
            <button class=""nayta-info text-medium"">Ohje</button>
        </div>

    </div>
    <div class=""row"">
        <div class=""col-4""></div>
        <div class=""col-7"">
            <div class=""piilotettu-sisalto text-small"">
                Vasemmasta yläkulmasta voit lisätä uuden aiheen. <br />
                Hakukentästä voit hakea aiheita.<br />
                Kunkin aiheen oikealta puolelta näet aiheen tarkat tiedot. Voit myös poistaa aiheen tai muokata sitä.
            </div>
        </div>
        <div class=""col-1"">

        </div>

    </div>

</div>

<br />
<br />

<div class=""container"">
    <div class=""row"">
        <div class=""col"">
            <h1>Aiheen nimi</h1>
        </div>
        <div class=""col"">
    ");
            WriteLiteral("        <h1>Aiheen kuvaus</h1>\r\n        </div>\r\n\r\n        <div class=\"col\">\r\n            <h1>Aiheen opiskelun aloituspäivä</h1>\r\n        </div>\r\n\r\n        <div class=\"col-1\">\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"container\">\r\n\r\n");
#nullable restore
#line 79 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"
     foreach (var item in Model)
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row topic-border-top\">\r\n            <div class=\"col text-medium col-iso\">\r\n                ");
#nullable restore
#line 84 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"col text-medium col-iso attribuutti\">\r\n                ");
#nullable restore
#line 88 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"col text-medium col-iso attribuutti\">\r\n                ");
#nullable restore
#line 92 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.StartLearningDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </div>\r\n\r\n            <div class=\"col-1 col-iso\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33a33f15519d8bbfbd9d43838dab07d11652fa6412243", async() => {
                WriteLiteral("Poista");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 97 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"
                                                                       WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33a33f15519d8bbfbd9d43838dab07d11652fa6414542", async() => {
                WriteLiteral("Muokkaa");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 98 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"
                                                                     WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n");
#nullable restore
#line 102 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"
        //table - responsive

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table table-hover text-small lisatietotaulukko"">
            <thead>
                <tr>
                    <th scope=""col"">Opiskelun vaatima aika</th>
                    <th scope=""col"">Opiskeluun käytetty aika</th>
                    <th scope=""col"">Lähde</th>
                    <th scope=""col"">Kesken</th>
                    <th scope=""col"">Opiskelu valmistunut</th>
                </tr>
            </thead>

            <tbody>
                <tr>
                    <td class=""lisatieto-attribuutti"">");
#nullable restore
#line 116 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"
                                                 Write(Html.DisplayFor(modelItem => item.TimeToMaster));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"lisatieto-attribuutti\">");
#nullable restore
#line 117 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"
                                                 Write(Html.DisplayFor(modelItem => item.TimeSpent));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"lisatieto-attribuutti\">");
#nullable restore
#line 118 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"
                                                 Write(Html.DisplayFor(modelItem => item.Source));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                    <td class=\"lisatieto-attribuutti\">\r\n");
#nullable restore
#line 121 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"
                           if (item.InProgress == true)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p>Kyllä</p>\r\n");
#nullable restore
#line 124 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"
                            }
                            else if (item.InProgress == null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p></p>\r\n");
#nullable restore
#line 128 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"
                            }
                            else if (!item.InProgress == true)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p>Ei</p>\r\n");
#nullable restore
#line 132 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td class=\"lisatieto-attribuutti\">");
#nullable restore
#line 135 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"
                                                 Write(Html.DisplayFor(modelItem => item.CompletionDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>        \r\n");
#nullable restore
#line 139 "C:\Users\Erkki\source\repos\ERDiary\Oppimispäiväkirja\Oppimispäiväkirja\Views\Topics\Index.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Oppimispäiväkirja.Models.Topic>> Html { get; private set; }
    }
}
#pragma warning restore 1591
