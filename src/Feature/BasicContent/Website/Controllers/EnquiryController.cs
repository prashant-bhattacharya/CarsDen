using CarsDen.Feature.BasicContent.Models;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsDen.Feature.BasicContent.Controllers
{
    public class EnquiryController : Controller
    {
        // GET: Enquiry
        public ActionResult Enquiry()
        {
            var item = RenderingContext.Current.Rendering.Item;
            EnquiryModel enquiryModel = new EnquiryModel()
            {
                EnquiryTitle = new HtmlString(FieldRenderer.Render(item, "EnquiryTitle"))
            };
            return View("/Views/CarsDen/BasicContent/Enquiry.cshtml", enquiryModel);
        }
    }
}