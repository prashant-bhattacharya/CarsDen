using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsDen.Foundation.Navigation.Models
{
    public class NavigationMenu
    {
        public string LogoImage { get; set; }
        public string LogoImageAlt { get; set; }
        public NavigationItem HomePage { get; set; }
        public List<MainNavigation> MainNavigation { get; set; }
        public string BookRideUrl { get; set; }

    }
}