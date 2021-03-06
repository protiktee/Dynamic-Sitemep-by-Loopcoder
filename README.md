# Dynamic-Sitemep-by-Loopcoder

A Sitemap is an XML file that lists URLs for a site along with additional metadata about each URL so that search engines can more intelligently crawl the site.

This document describes the XML schema for the Sitemap protocol. The Sitemap protocol format consists of XML tags. All data values in a Sitemap must be entity-escaped. The file itself must be UTF-8 encoded.

The Sitemap must:
•    Begin with an opening urlset tag and end with a closing urlset tag.
•    Specify the namespace (protocol standard) within the urlset tag.
•    Include a url entry for each URL, as a parent XML tag.
•    Include a loc child entry for each url parent tag.
All other tags are optional. Support for these optional tags may vary among search engines. Refer to each search engines documentation for details. Also, all URLs in a Sitemap must be from a single host, such as www.loopcoder.com or store.loopcoder.com.

Sample XML Sitemap
The following example shows a Sitemap that contains just one URL and uses all optional tags.
 


XML tag definitions

The available XML tags which are required are described below.

    urlset    : Encapsulates the file and references the current protocol standard.
    url        : Parent tag for each URL entry. The remaining tags are children of this tag.
    loc       :URL of the page. This URL must begin with the protocol (such as http) and end with a trailing slash, if your web server requires it. This value must be less than 2,048 characters. 

