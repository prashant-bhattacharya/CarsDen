using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsDen.Foundation.Navigation.Models
{
    public class MainNavigation
    {
        public NavigationItem NavItem { get; set; }
        public List<NavigationItem> SubNavigation { get; set; }
    }
}