using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phonebook.WebMVC.Helpers
{
    public static class PhoneHelper
    {
        public static MvcHtmlString CreatePhoneForm(this HtmlHelper html)
        {
            var form = new TagBuilder("form");
            form.Attributes.Add("id", "add");
            form.Attributes.Add("action", "/dist/addsave");
            form.Attributes.Add("method", "POST");

            var submitBTN = new TagBuilder("button");
            submitBTN.Attributes.Add("type", "submit");
            submitBTN.Attributes.Add("id", "addBtn");
            submitBTN.Attributes.Add("disabled", "true");
            submitBTN.InnerHtml = "Добавить";

            form.InnerHtml = submitBTN.ToString();
            return new MvcHtmlString(form.ToString());
        }
    }
}