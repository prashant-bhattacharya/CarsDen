using CarsDen.Feature.BasicContent.Models;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace CarsDen.Feature.BasicContent.Controllers
{
    public class FooterController : Controller
    {
        public ActionResult Footer()
        {
            var item = RenderingContext.Current.Rendering.Item;
            FooterModel footerModel = new FooterModel()
            {
                LogoImage = GetImageUrl(item, "LogoImage"),
                LogoImageAlt = GetImageAlt(item, "LogoImage"),
                CompanyDescription = new HtmlString(FieldRenderer.Render(item, "CompanyDescription")),
                CompanyTitle = new HtmlString(FieldRenderer.Render(item, "CompanyTitle")),
                Home = GetLinkUrl(item, "Home"),
                HomePlaceholder = new HtmlString(FieldRenderer.Render(item, "HomePlaceholder")),
                About = GetLinkUrl(item, "About"),
                AboutPlaceholder = new HtmlString(FieldRenderer.Render(item, "AboutPlaceholder")),
                Featured = GetLinkUrl(item, "Featured"),
                FeaturedPlaceholder = new HtmlString(FieldRenderer.Render(item, "FeaturedPlaceholder")),
                SupportTitle = new HtmlString(FieldRenderer.Render(item, "SupportTitle")),
                HelpCenterPlaceholder = new HtmlString(FieldRenderer.Render(item, "HelpCenterPlaceholder")),
                AskQuestionPlaceholder = new HtmlString(FieldRenderer.Render(item, "AskQuestionPlaceholder")),
                PrivacyPolicyPlaceholder = new HtmlString(FieldRenderer.Render(item, "PrivacyPolicyPlaceholder")),
                TnCPlaceholder = new HtmlString(FieldRenderer.Render(item, "TnCPlaceholder")),
                ServiceLocations = new HtmlString(FieldRenderer.Render(item, "ServiceLocations")),
                Bangalore = new HtmlString(FieldRenderer.Render(item, "Bangalore")),
                Mumbai = new HtmlString(FieldRenderer.Render(item, "Mumbai")),
                Gurugram = new HtmlString(FieldRenderer.Render(item, "Gurugram")),
                Kolkata = new HtmlString(FieldRenderer.Render(item, "Kolkata")),
                Chennai = new HtmlString(FieldRenderer.Render(item, "Chennai")),
                Hyderabad = new HtmlString(FieldRenderer.Render(item, "Hyderabad")),
                Ahmedabad = new HtmlString(FieldRenderer.Render(item, "Ahmedabad")),
                Kochi = new HtmlString(FieldRenderer.Render(item, "Kochi")),
                Copyright = new HtmlString(FieldRenderer.Render(item, "Copyright"))
            };

            return View("/Views/CarsDen/BasicContent/Footer.cshtml", footerModel);
        }

        private string GetLinkUrl(Item item, string fieldName)
        {
            if (item == null || string.IsNullOrEmpty(fieldName))
                return null;

            if (item.Fields[fieldName] != null)
            {
                LinkField linkField = (LinkField)item.Fields[fieldName];

                // Parse the XML representation of the link
                var fieldXml = linkField.Value;
                var fieldElement = XElement.Parse(fieldXml);

                // Extract the URL from the XML
                var urlAttribute = fieldElement.Attribute("url");
                if (urlAttribute != null)
                {
                    string url = urlAttribute.Value;
                    return url;
                }
            }
            return null;
        }

        private string GetImageUrl(Item item, string fieldName)
        {
            ImageField imageField = item.Fields[fieldName];
            return imageField?.MediaItem != null ? MediaManager.GetMediaUrl(imageField.MediaItem) : string.Empty;
        }

        private string GetImageAlt(Item item, string fieldName)
        {
            ImageField imageField = item.Fields[fieldName];
            return imageField?.Alt;
        }

    }

}

   

