using DynamicSitemap.Models;
using System;
using System.Collections.Generic;
using System.Configuration; 
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace DynamicSitemap.Biz
{
    public class clsSitemap
    {
        private static string connectionstring = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        public static string SetSitemap(UrlHelper urlHelper, string path)
        {
            string xml = GetSitemapDocument(GetNode(urlHelper));
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.Save(path);
            return xml;
        }

        public static List<SitemapNode> GetNode(UrlHelper urlHelper)
        {
            List<SitemapNode> nodes = new List<SitemapNode>();
            //Domain = urlHelper.RequestContext.HttpContext.Request.Url.ToString().Substring(0, urlHelper.RequestContext.HttpContext.Request.Url.ToString().Length - 1);
            string Domain = urlHelper.RequestContext.HttpContext.Request.Url.Scheme + "://" + urlHelper.RequestContext.HttpContext.Request.Url.Host;
            nodes.Add(
                new SitemapNode()
                {
                    Url = Domain + urlHelper.Action("Index", "Home"),
                    Priority = 1
                });
            nodes.Add(
               new SitemapNode()
               {
                   Url = Domain + urlHelper.Action("Research", "Home"),
                   Priority = 0.9
               });
            nodes.Add(
               new SitemapNode()
               {
                   Url = Domain + urlHelper.Action("Contact", "Home"),
                   Priority = 0.9
               }); 
            /*You can add more node by using your database*/
            return nodes;
        }
        public static string GetSitemapDocument(List<SitemapNode> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                    sitemapNode.LastModified == null ? null : new XElement(
                        xmlns + "lastmod",
                        sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    sitemapNode.Frequency == null ? null : new XElement(
                        xmlns + "changefreq",
                        sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();
        }
        
    }
}