using DynamicSitemap.Biz;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace DynamicSitemap.Models
{
    public class SitemapNodeRepository : ISitemapNodeRepository
    {
        public string SetSitemapNodes(UrlHelper urlHelper, string path)
        {
            return clsSitemap.SetSitemap(urlHelper, path);
        }
    } 
}