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
        public int Col { get; set; } = 18;

        [HtmlAttributeName("th-col-label")]
        public int Col_label { get; set; } = 9;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var Col_input = 18 - Col_label;

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.SetAttribute("class", $"control col-{Col}");

            var template = "";
            template += $"<label class='control-label col-{Col_label}' for='{Label}'>{Label}&nbsp</label>";
            template += $"<input type='text' class='control-input col-{Col_input}' name='{Label}' data-bind='value {Input}' />";

            output.Content.SetHtmlContent(template);
        }
    }
}
