using CarsDen.Foundation.Navigation.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsDen.Foundation.Navigation.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult GetNavigationItems()
        {
            var StartPath = Sitecore.Context.Site.StartPath;
            var homeItem = Sitecore.Context.Database.GetItem(StartPath);

            var result = homeItem.Children?
                .Where(x => checkForNavigableItem(x))
                .Select(x => new MainNavigation()
                {
                    NavItem = new NavigationItem
                    {
                        NavigationItemName = x.DisplayName,
                        NavigationItemUrl = LinkManager.GetItemUrl(x)
                    },
                    SubNavigation = GetSubNavigationItem(x) ?? new List<NavigationItem>()
                }).ToList();

            NavigationMenu menu = new NavigationMenu()
            {
                LogoImage = GetImageUrl(homeItem, "LogoImage"),
                LogoImageAlt = GetImageAlt(homeItem, "LogoImageAlt"),
                HomePage = new NavigationItem
                {
                    NavigationItemName = homeItem.DisplayName,
                    NavigationItemUrl = LinkManager.GetItemUrl(homeItem)
                },
                MainNavigation = result,
                BookRideUrl = GetBookRideUrl(homeItem, "BookRideUrl")
            };


            return View("/Views/CarsDen/Navigation/Navigation.cshtml", menu);
        }

        private bool checkForNavigableItem(Item item)
        {
            CheckboxField navigablePageField = item.Fields["IsNavigablePage"];
            if (navigablePageField != null)
            {
                return navigablePageField.Checked;
            }
            else
            {
                return false;
            }
        }

        private List<NavigationItem> GetSubNavigationItem(Item item)
        {
            return
                  item.Children?
                        .Where(x => checkForNavigableItem(x))
                        .Select(x => new NavigationItem()
                        {
                            NavigationItemUrl = LinkManager.GetItemUrl(x),
                            NavigationItemName = x.DisplayName
                        }).ToList();
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

        private string GetBookRideUrl(Item item, string fieldName)
        {
            LinkField linkField = item.Fields[fieldName];
            return linkField?.TargetItem != null ? LinkManager.GetItemUrl(linkField.TargetItem) : string.Empty;
        }
    }
}