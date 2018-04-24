using Prism.Regions;
using System;

namespace RockPaperScissors.Common.Helpers
{
    public static class RegionExtensions
    {
        public static void NavigateTo(this IRegion region, Type type)
        {
            region.NavigateTo(type.Name);
        }

        public static void NavigateTo(this IRegion region, string viewName)
        {
            region.RequestNavigate(new Uri(viewName, UriKind.Relative));
        }
    }
}
