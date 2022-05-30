#pragma checksum "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d1fb765df3e1033d322dcbd96e3aafd39b09b62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\Study\NET105\ASM\NET105\Views\_ViewImports.cshtml"
using NET105;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Study\NET105\ASM\NET105\Views\_ViewImports.cshtml"
using NET105.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Study\NET105\ASM\NET105\Views\_ViewImports.cshtml"
using NET105.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Study\NET105\ASM\NET105\Views\_ViewImports.cshtml"
using NET105.Helper;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d1fb765df3e1033d322dcbd96e3aafd39b09b62", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd21d3b2b1bc3e6539e23a600b3b848f4a8c4ccf", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IDictionary<string , IEnumerable<Product>>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("max-height: 400px; min-height: 400px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("min-height: 250px; max-height: 250px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ProductDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Trang món ăn";

	IEnumerable<Category> categories = ViewData["listCategories"] as  IEnumerable<Category>;

	IEnumerable<Product> products = ViewData["ProductPrice"] as IEnumerable<Product>;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!-- start banner Area -->\r\n\t<section class=\"banner-area\">\r\n\t\t<div class=\"container\">\r\n\t\t\t<div class=\"row fullscreen align-items-center justify-content-start\">\r\n\t\t\t\t<div class=\"col-lg-12\">\r\n\t\t\t\t\t<div class=\"active-banner-slider owl-carousel\">\r\n");
#nullable restore
#line 15 "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml"
                         foreach (var category in categories)
						{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t<!-- single-slide -->\r\n\t\t\t\t\t\t<div class=\"row single-slide align-items-center d-flex\">\r\n\t\t\t\t\t\t\t<div class=\"col-lg-5 col-md-6\">\r\n\t\t\t\t\t\t\t\t<div class=\"banner-content\">\r\n\t\t\t\t\t\t\t\t\t<h1>");
#nullable restore
#line 21 "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml"
                                   Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\t\t\t\t\t\t\t\t\t<p>");
#nullable restore
#line 22 "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml"
                                  Write(category.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t\t\t\t\t\t\t<div class=\"add-bag d-flex align-items-center\">\r\n\t\t\t\t\t\t\t\t\t\t<a class=\"add-btn\"");
            BeginWriteAttribute("href", " href=\"", 901, "\"", 908, 0);
            EndWriteAttribute();
            WriteLiteral("><span class=\"lnr lnr-cross\"></span></a>\r\n\t\t\t\t\t\t\t\t\t\t<span class=\"add-text text-uppercase\">Add to Bag</span>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t<div class=\"col-lg-7\">\r\n\t\t\t\t\t\t\t\t<div class=\"banner-img\">\r\n\t\t\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6d1fb765df3e1033d322dcbd96e3aafd39b09b627674", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1214, "~/Images/Products/", 1214, 18, true);
#nullable restore
#line 31 "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 1232, category.ImageUrl, 1232, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 35 "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml"
						}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"					
					</div>
				</div>
			</div>
		</div>
	</section>
	<!-- End banner Area -->

	<!-- start features Area -->
	<section class=""features-area section_gap"">
		<div class=""container"">
			<div class=""row features-inner"">
				<!-- single features -->
				<div class=""col-lg-3 col-md-6 col-sm-6"">
					<div class=""single-features"">
						<div class=""f-icon"">
							<img src=""img/features/f-icon1.png""");
            BeginWriteAttribute("alt", " alt=\"", 1733, "\"", 1739, 0);
            EndWriteAttribute();
            WriteLiteral(@">
						</div>
						<h6>Free Delivery</h6>
						<p>Free Shipping on all order</p>
					</div>
				</div>
				<!-- single features -->
				<div class=""col-lg-3 col-md-6 col-sm-6"">
					<div class=""single-features"">
						<div class=""f-icon"">
							<img src=""img/features/f-icon2.png""");
            BeginWriteAttribute("alt", " alt=\"", 2035, "\"", 2041, 0);
            EndWriteAttribute();
            WriteLiteral(@">
						</div>
						<h6>Return Policy</h6>
						<p>Free Shipping on all order</p>
					</div>
				</div>
				<!-- single features -->
				<div class=""col-lg-3 col-md-6 col-sm-6"">
					<div class=""single-features"">
						<div class=""f-icon"">
							<img src=""img/features/f-icon3.png""");
            BeginWriteAttribute("alt", " alt=\"", 2337, "\"", 2343, 0);
            EndWriteAttribute();
            WriteLiteral(@">
						</div>
						<h6>24/7 Support</h6>
						<p>Free Shipping on all order</p>
					</div>
				</div>
				<!-- single features -->
				<div class=""col-lg-3 col-md-6 col-sm-6"">
					<div class=""single-features"">
						<div class=""f-icon"">
							<img src=""img/features/f-icon4.png""");
            BeginWriteAttribute("alt", " alt=\"", 2638, "\"", 2644, 0);
            EndWriteAttribute();
            WriteLiteral(@">
						</div>
						<h6>Secure Payment</h6>
						<p>Free Shipping on all order</p>
					</div>
				</div>
			</div>
		</div>
	</section>
	<!-- end features Area -->

	<!-- Start category Area -->
	<section class=""category-area"">
		<div class=""container"">
			<div class=""row justify-content-center"">
				<div class=""col-lg-8 col-md-12"">
					<div class=""row"">
						<div class=""col-lg-8 col-md-8"">
							<div class=""single-deal"">
								<div class=""overlay""></div>
								<img class=""img-fluid w-100"" src=""img/category/c1.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 3195, "\"", 3201, 0);
            EndWriteAttribute();
            WriteLiteral(@">
								<a href=""img/category/c1.jpg"" class=""img-pop-up"" target=""_blank"">
									<div class=""deal-details"">
										<h6 class=""deal-title"">Sneaker for Sports</h6>
									</div>
								</a>
							</div>
						</div>
						<div class=""col-lg-4 col-md-4"">
							<div class=""single-deal"">
								<div class=""overlay""></div>
								<img class=""img-fluid w-100"" src=""img/category/c2.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 3607, "\"", 3613, 0);
            EndWriteAttribute();
            WriteLiteral(@">
								<a href=""img/category/c2.jpg"" class=""img-pop-up"" target=""_blank"">
									<div class=""deal-details"">
										<h6 class=""deal-title"">Sneaker for Sports</h6>
									</div>
								</a>
							</div>
						</div>
						<div class=""col-lg-4 col-md-4"">
							<div class=""single-deal"">
								<div class=""overlay""></div>
								<img class=""img-fluid w-100"" src=""img/category/c3.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 4019, "\"", 4025, 0);
            EndWriteAttribute();
            WriteLiteral(@">
								<a href=""img/category/c3.jpg"" class=""img-pop-up"" target=""_blank"">
									<div class=""deal-details"">
										<h6 class=""deal-title"">Product for Couple</h6>
									</div>
								</a>
							</div>
						</div>
						<div class=""col-lg-8 col-md-8"">
							<div class=""single-deal"">
								<div class=""overlay""></div>
								<img class=""img-fluid w-100"" src=""img/category/c4.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 4431, "\"", 4437, 0);
            EndWriteAttribute();
            WriteLiteral(@">
								<a href=""img/category/c4.jpg"" class=""img-pop-up"" target=""_blank"">
									<div class=""deal-details"">
										<h6 class=""deal-title"">Sneaker for Sports</h6>
									</div>
								</a>
							</div>
						</div>
					</div>
				</div>
				<div class=""col-lg-4 col-md-6"">
					<div class=""single-deal"">
						<div class=""overlay""></div>
						<img class=""img-fluid w-100"" src=""img/category/c5.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 4860, "\"", 4866, 0);
            EndWriteAttribute();
            WriteLiteral(@">
						<a href=""img/category/c5.jpg"" class=""img-pop-up"" target=""_blank"">
							<div class=""deal-details"">
								<h6 class=""deal-title"">Sneaker for Sports</h6>
							</div>
						</a>
					</div>
				</div>
			</div>
		</div>
	</section>
	<!-- End category Area -->

	<!-- start product Area -->
	<section class=""owl-carousel active-product-area section_gap"">
");
#nullable restore
#line 163 "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml"
         foreach (var item in Model)
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<!-- single product slide -->\r\n\t\t<div class=\"single-product-slider\">\r\n\t\t\t<div class=\"container\">\r\n\t\t\t\t<div class=\"row justify-content-center\">\r\n\t\t\t\t\t<div class=\"col-lg-6 text-center\">\r\n\t\t\t\t\t\t<div class=\"section-title\">\r\n\t\t\t\t\t\t\t<h1>");
#nullable restore
#line 171 "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml"
                           Write(item.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
            WriteLiteral("\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t\t<div class=\"row\">\r\n\t\t\t\t\t\r\n                   \r\n");
#nullable restore
#line 181 "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml"
                      foreach (var product in item.Value)
					 {

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t    <!-- single product -->\r\n\t\t\t\t\t\t<div class=\"col-lg-3 col-md-6\">\r\n\t\t\t\t\t\t\t<div class=\"single-product\">\r\n\t\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d1fb765df3e1033d322dcbd96e3aafd39b09b6216163", async() => {
                WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6d1fb765df3e1033d322dcbd96e3aafd39b09b6216437", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 6149, "~/Images/products/", 6149, 18, true);
#nullable restore
#line 187 "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 6167, product.ImageUrl, 6167, 17, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t<h6>");
#nullable restore
#line 188 "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml"
                                   Write(product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n\t\t\t\t\t\t\t\t\t");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 186 "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml"
                                                                                         WriteLiteral(product.ProductId);

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
            WriteLiteral("\r\n\t\t\t\t\t\t\t\t<div class=\"product-details\">\r\n\t\t\t\t\t\t\t\t\t<div class=\"prd-bottom\">\r\n\r\n\t\t\t\t\t\t\t\t\t\t<a");
            BeginWriteAttribute("ng-click", " ng-click=\"", 6331, "\"", 6371, 3);
            WriteAttributeValue("", 6342, "AddCart(\'", 6342, 9, true);
#nullable restore
#line 193 "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml"
WriteAttributeValue("", 6351, product.ProductId, 6351, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6369, "\')", 6369, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"social-info hover\">\r\n\t\t\t\t\t\t\t\t\t\t\t<span class=\"ti-bag\"></span>\r\n\t\t\t\t\t\t\t\t\t\t\t<p class=\"hover-text\">add to bag</p>\r\n\t\t\t\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 6519, "\"", 6526, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"social-info\">\r\n\t\t\t\t\t\t\t\t\t\t\t<span class=\"lnr lnr-heart\"></span>\r\n\t\t\t\t\t\t\t\t\t\t\t<p class=\"hover-text\">Wishlist</p>\r\n\t\t\t\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 6673, "\"", 6680, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"social-info\">\r\n\t\t\t\t\t\t\t\t\t\t\t<span class=\"lnr lnr-sync\"></span>\r\n\t\t\t\t\t\t\t\t\t\t\t<p class=\"hover-text\">compare</p>\r\n\t\t\t\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 6825, "\"", 6832, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"social-info\">\r\n\t\t\t\t\t\t\t\t\t\t\t<span class=\"lnr lnr-move\"></span>\r\n\t\t\t\t\t\t\t\t\t\t\t<p class=\"hover-text\">view more</p>\r\n\t\t\t\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 214 "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml"
					 }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \r\n\t\t\t\t\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n");
#nullable restore
#line 220 "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"		<!-- single product slide -->
		
	</section>
	<!-- end product Area -->

	<!-- Start exclusive deal Area -->
	<section class=""exclusive-deal-area"">
		<div class=""container-fluid"">
			<div class=""row justify-content-center align-items-center"">
				<div class=""col-lg-6 no-padding exclusive-left"">
					<div class=""row clock_sec clockdiv"" id=""clockdiv"">
						<div class=""col-lg-12"">
							<h1>Exclusive Hot Deal Ends Soon!</h1>
							<p>Who are in extremely love with eco friendly system.</p>
						</div>
						<div class=""col-lg-12"">
							<div class=""row clock-wrap"">
								<div class=""col clockinner1 clockinner"">
									<h1 class=""days"">150</h1>
									<span class=""smalltext"">Days</span>
								</div>
								<div class=""col clockinner clockinner1"">
									<h1 class=""hours"">23</h1>
									<span class=""smalltext"">Hours</span>
								</div>
								<div class=""col clockinner clockinner1"">
									<h1 class=""minutes"">47</h1>
									<span class=""smalltext"">Mins</span>
	");
            WriteLiteral("\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t<div class=\"col clockinner clockinner1\">\r\n\t\t\t\t\t\t\t\t\t<h1 class=\"seconds\">59</h1>\r\n\t\t\t\t\t\t\t\t\t<span class=\"smalltext\">Secs</span>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 8352, "\"", 8359, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""primary-btn"">Shop Now</a>
				</div>
				<div class=""col-lg-6 no-padding exclusive-right"">
					<div class=""active-exclusive-product-slider"">
						<!-- single exclusive carousel -->
						<div class=""single-exclusive-slider"">
							<img class=""img-fluid"" src=""img/product/e-p1.png""");
            BeginWriteAttribute("alt", " alt=\"", 8657, "\"", 8663, 0);
            EndWriteAttribute();
            WriteLiteral(@">
							<div class=""product-details"">
								<div class=""price"">
									<h6>$150.00</h6>
									<h6 class=""l-through"">$210.00</h6>
								</div>
								<h4>addidas New Hammer sole
									for Sports person</h4>
								<div class=""add-bag d-flex align-items-center justify-content-center"">
									<a class=""add-btn""");
            BeginWriteAttribute("href", " href=\"", 8999, "\"", 9006, 0);
            EndWriteAttribute();
            WriteLiteral(@"><span class=""ti-bag""></span></a>
									<span class=""add-text text-uppercase"">Add to Bag</span>
								</div>
							</div>
						</div>
						<!-- single exclusive carousel -->
						<div class=""single-exclusive-slider"">
							<img class=""img-fluid"" src=""img/product/e-p1.png""");
            BeginWriteAttribute("alt", " alt=\"", 9296, "\"", 9302, 0);
            EndWriteAttribute();
            WriteLiteral(@">
							<div class=""product-details"">
								<div class=""price"">
									<h6>$150.00</h6>
									<h6 class=""l-through"">$210.00</h6>
								</div>
								<h4>addidas New Hammer sole
									for Sports person</h4>
								<div class=""add-bag d-flex align-items-center justify-content-center"">
									<a class=""add-btn""");
            BeginWriteAttribute("href", " href=\"", 9638, "\"", 9645, 0);
            EndWriteAttribute();
            WriteLiteral(@"><span class=""ti-bag""></span></a>
									<span class=""add-text text-uppercase"">Add to Bag</span>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>
	<!-- End exclusive deal Area -->

	<!-- Start brand Area -->
	<section class=""brand-area section_gap"">
		<div class=""container"">
			<div class=""row"">
				<a class=""col single-img"" href=""#"">
					<img class=""img-fluid d-block mx-auto"" src=""img/brand/1.png""");
            BeginWriteAttribute("alt", " alt=\"", 10114, "\"", 10120, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t\t</a>\r\n\t\t\t\t<a class=\"col single-img\" href=\"#\">\r\n\t\t\t\t\t<img class=\"img-fluid d-block mx-auto\" src=\"img/brand/2.png\"");
            BeginWriteAttribute("alt", " alt=\"", 10240, "\"", 10246, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t\t</a>\r\n\t\t\t\t<a class=\"col single-img\" href=\"#\">\r\n\t\t\t\t\t<img class=\"img-fluid d-block mx-auto\" src=\"img/brand/3.png\"");
            BeginWriteAttribute("alt", " alt=\"", 10366, "\"", 10372, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t\t</a>\r\n\t\t\t\t<a class=\"col single-img\" href=\"#\">\r\n\t\t\t\t\t<img class=\"img-fluid d-block mx-auto\" src=\"img/brand/4.png\"");
            BeginWriteAttribute("alt", " alt=\"", 10492, "\"", 10498, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t\t</a>\r\n\t\t\t\t<a class=\"col single-img\" href=\"#\">\r\n\t\t\t\t\t<img class=\"img-fluid d-block mx-auto\" src=\"img/brand/5.png\"");
            BeginWriteAttribute("alt", " alt=\"", 10618, "\"", 10624, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t\t</a>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</section>\r\n\t<!-- End brand Area -->\r\n\r\n\t<!-- Start related-product Area -->\r\n\t");
#nullable restore
#line 325 "D:\Study\NET105\ASM\NET105\Views\Home\Index.cshtml"
Write(await Html.PartialAsync("_ListProducts"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t<!-- End related-product Area -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IDictionary<string , IEnumerable<Product>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
