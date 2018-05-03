using System;
using System.Collections.Generic;
using System.Web;
using System.Xml.Linq;
using NET.S._2018.Dvorkin.Task.v._2.Interfaces;

namespace NET.S._2018.Dvorkin.Task.v._2.Implementations
{
    /// <summary>
    /// Contains methods for parsing.
    /// </summary>
    /// <seealso cref="NET.S._2018.Dvorkin.Task.v._2.Interfaces.IParser{System.Uri}" />    
    public class Parser : IParser<Uri>
    {
        /// <summary>
        /// Parses the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>Root XElement</returns>
        public XElement Parse(IEnumerable<Uri> list)
        {
            XElement root = new XElement("urlAdresses");
            foreach (Uri uri in list)
            {
                XElement adress = new XElement("urlAdress");
                adress.Add(new XElement("host", new XAttribute("name", $"{uri.Host}")), Segment(uri), Parameter(uri));
                root.Add(adress);
            }

            return root;
        }

        /// <summary>
        /// Segments the specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>Xelement with segments of URI</returns>
        private XElement Segment(Uri uri)
        {
            XElement segments = new XElement("uri");
            foreach (string uriSegment in uri.Segments)
            {
                if (uriSegment == @"/")
                {
                    continue;
                }

                segments.Add(new XElement("segment", uriSegment.Trim('/')));
            }

            if (segments.IsEmpty)
            {
                return null;
            }

            return segments;
        }

        /// <summary>
        /// Parametrses the specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>Xelement with parameters of URI</returns>
        private XElement Parameter(Uri uri)
        {
            XElement parametrs = new XElement("parameters");
            foreach (string paramerer in HttpUtility.ParseQueryString(uri.Query).AllKeys)
            {
                if (string.IsNullOrWhiteSpace(paramerer))
                {
                    continue;
                }
                else
                {
                    parametrs.Add(new XElement("parameter", new XAttribute("value", $"{HttpUtility.ParseQueryString(uri.Query)[paramerer]}"),
                        new XAttribute("key", $"{paramerer}")));
                }
            }

            if (parametrs.IsEmpty)
            {
                return null;
            }

            return parametrs;
        }
    }
}