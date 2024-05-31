using CarsDen.Feature.Booking.Models;
using CarsDen.Feature.CarCatalog.Models;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CarsDen.Feature.Booking.Controllers
{
    public class BookingController : Controller
    {
        public ActionResult Booking()
        {
            var item = RenderingContext.Current.Rendering.Item;

            var carCatalogRoot = Sitecore.Context.Database.GetItem("/sitecore/content/CarsDen-Website/Home/CarList/CarsFolder"); 
            var carItems = carCatalogRoot.GetChildren().Where(c => c.TemplateName == "CarModel");

            List<CarModel> carModels = carItems.Select(x => new CarModel
            {
                Model = new HtmlString(FieldRenderer.Render(x, "CarModel")),
                CarRentPerDay = new HtmlString(FieldRenderer.Render(x, "CarRentPerDay"))
            }).ToList();

            string today = DateTime.Now.ToString("yyyy-MM-dd");

            BookingModel bookingModel = new BookingModel()
            {
                BookingTitle = new HtmlString(FieldRenderer.Render(item, "BookingTitle")),
                CarModel = new HtmlString(FieldRenderer.Render(item, "CarModel")),
                SelectCarModel = new HtmlString(FieldRenderer.Render(item, "SelectCarModel")),
                StartDate = new HtmlString(FieldRenderer.Render(item, "StartDate")),
                EndDate = new HtmlString(FieldRenderer.Render(item, "EndDate")),
                TotalPrice = new HtmlString(FieldRenderer.Render(item, "TotalPrice")),
                BookBtn = new HtmlString(FieldRenderer.Render(item, "BookBtn")),
                CarModels = carModels,
                StartDateValue = today,
                EndDateValue = today
            };
            return View("/Views/CarsDen/Booking/Booking.cshtml", bookingModel);
        }
    }
}