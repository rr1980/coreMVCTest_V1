using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Main.TagHelpers
{
    [HtmlTargetElement("th-label-input", Attributes = "th-label , th-input")]
    public class TH_label_input : TagHelper
    {
        [HtmlAttributeName("th-label")]
        public string Label { get; set; }

        [HtmlAttributeName("th-input")]
        public string Input { get; set; }

        [HtmlAttributeName("th-col")]
        public int Col { get; set; } = 12;

        [HtmlAttributeName("th-span-width")]
        public string Col_Span { get; set; } = "100px";


        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //var Col_Input = 12 - Col_Span;

            //output.TagName = "div";
            //output.TagMode = TagMode.StartTagAndEndTag;

            //output.Attributes.SetAttribute("class", $"form-group col-md-{Col}");

            var template = "";

            //template += $"<span style='min-width:{Col_Span}' class='input-group-addon' for='{Label}'>{Label}&nbsp</span>";
            //template += $"<label for='{Label}'>{Label}&nbsp";
            //template += $"<input type='text' class='form-control' placeholder='. . .' name='{Label}' data-bind='value {Input}' />";
            //template += "</label>";


            template += "<div style='margin-bottom: 25px' class='input-group'>";
            template += "<span class='input-group-addon'><i class='glyphicon glyphicon-user'></i></span>";
            template += "<input type='text' class='form-control' name='username' value='' placeholder='Username'>";
            template += "</div>";

            output.Content.SetHtmlContent(template);
        }
    }
}
