using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Text.Encodings.Web;

namespace Expense_Management_Software.Areas.ADMN_PaymentMode.Controllers
{
    [HtmlTargetElement("encrypted-edit", TagStructure = TagStructure.WithoutEndTag)]
    public class EncryptedEditTagHelper : TagHelper
    {
        public int Id { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Encrypt the ID
            string encryptedId = Encrypt(Id.ToString());

            // Generate the edit link
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"edit?id={UrlEncoder.Default.Encode(encryptedId)}");
            output.Content.SetContent("Edit");
        }

        private string Encrypt(string input)
        {
            // Your encryption logic here
            throw new NotImplementedException("Implement your encryption logic here.");
        }

    }
}
