using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsDen.Feature.CarCatalog.Models
{
    public class CarModel
    {
        public string CarImage { get; set; }
        public string CarImageAlt { get; set; }
        public HtmlString Model { get; set; }
        public HtmlString Seaters { get; set; }
        public HtmlString CarMakeYear { get; set; }
        public HtmlString CarFuelType { get; set; }
        public HtmlString CarMileage { get; set; }
        public HtmlString CarTransmission { get; set; }
        public HtmlString CarRentPerDay { get; set; }
    }
}