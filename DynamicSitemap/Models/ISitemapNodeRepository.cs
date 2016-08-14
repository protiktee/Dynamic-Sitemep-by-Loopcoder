using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DynamicSitemap.Models
{
    interface ISitemapNodeRepository
    {
        string SetSitemapNodes(UrlHelper urlHelper, string path); 
    }
}
