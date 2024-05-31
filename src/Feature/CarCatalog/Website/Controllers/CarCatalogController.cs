using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarsDen.Feature.CarCatalog.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using Sitecore.Web.UI.WebControls;

namespace CarsDen.Feature.CarCatalog.Controllers
{
    public class CarCatalogController : Controller
    {
        // GET: CarCatalog
        public ActionResult CarCatalog()
        {
            var item = RenderingContext.Current.Rendering.Item;
            List<CarModel> carCatalog = new List<CarModel>();
            MultilistField carsList = item.Fields["CarsList"];
            if(carsList != null)
            {
                carCatalog = carsList.GetItems()
                    .Select(x => new Models.CarModel
                    {
                        CarImage = GetImageUrl(x, "CarImage"),
                        CarImageAlt = GetImageAlt(x, "CarImage"),
                        Model = new HtmlString(FieldRenderer.Render(x, "CarModel")),
                        Seaters = new HtmlString(FieldRenderer.Render(x, "Seaters")),
                        CarMakeYear = new HtmlString(FieldRenderer.Render(x, "CarMakeYear")),
                        CarFuelType = new HtmlString(FieldRenderer.Render(x, "CarFuelType")),
                        CarMileage = new HtmlString(FieldRenderer.Render(x, "CarMileage")),
                        CarTransmission = new HtmlString(FieldRenderer.Render(x, "Transmission")),
                        CarRentPerDay = new HtmlString(FieldRenderer.Render(x, "CarRentPerDay")),
                    }).ToList();
            }
            return View("/Views/CarsDen/CarCatalog/CarCatalog.cshtml", carCatalog);
        }
        private string GetImageUrl(Item item, string fieldName) 
        {
            ImageField imageField = item.Fields[fieldName];
            return MediaManager.GetMediaUrl(imageField.MediaItem);
        }

        private string GetImageAlt(Item item, string fieldName)
        {
            ImageField imageField = item.Fields[fieldName];
            return imageField.Alt;
        }
    }
}