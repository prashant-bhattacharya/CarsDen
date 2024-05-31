using CarsDen.Feature.CarCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsDen.Feature.Booking.Models
{
    public class BookingModel
    {
        public HtmlString BookingTitle { get; set; }
        public HtmlString CarModel { get; set; }
        public HtmlString SelectCarModel { get; set; }
        public HtmlString StartDate { get; set; }
        public HtmlString EndDate { get; set; }
        public HtmlString TotalPrice { get; set; }
        public HtmlString BookBtn { get; set; }
        public List<CarModel> CarModels { get; set; }
        public string StartDateValue { get; set; }
        public string EndDateValue { get; set; }
    }
}