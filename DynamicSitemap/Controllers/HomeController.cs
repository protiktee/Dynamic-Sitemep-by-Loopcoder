using DynamicSitemap.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;
using System.Xml.Linq;

namespace DynamicSitemap.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        static readonly ISitemapNodeRepository repositorySitemap = new SitemapNodeRepository(); 
        public ActionResult Index()
        { 
            string xml = repositorySitemap.SetSitemapNodes(this.Url, HostingEnvironment.ApplicationPhysicalPath + "sitemap.xml");  
            return View();
        }  
    }
}
