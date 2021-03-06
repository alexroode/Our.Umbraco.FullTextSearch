﻿using Our.Umbraco.FullTextSearch.Interfaces;
using System.Web;
using Umbraco.Core;
using Umbraco.Web.Composing;

namespace Our.Umbraco.FullTextSearch.Helpers
{
    public static class RequestHelper
    {
        /// <summary>
        /// Check whether the current page is being rendered by the indexer
        /// </summary>
        /// <returns>true if being indexed</returns>
        public static bool IsIndexingActive(this HttpRequest request)
        {
            if (!(Current.Factory.TryGetInstance(typeof(IConfig)) is IConfig config)) return false;

            var searchActiveStringName = config.GetSearchActiveStringName();;

            return !searchActiveStringName.IsNullOrWhiteSpace() && (request.QueryString[searchActiveStringName] != null || request.Cookies[searchActiveStringName] != null);
        }

        public static bool IsIndexingActive()
        {
            return HttpContext.Current.Request.IsIndexingActive();
        }
    }
}
