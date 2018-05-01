using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NET.S._2018.Dvorkin.Task.Model
{
    /// <summary>
    /// Contains definitions of each URI.
    /// </summary>
    public class UriScheme
    {
        [XmlElement("name")]
        public string Host { get; set; }

        [XmlElement("uri")]
        public List<Segment> Segments { get; set; }

        [XmlArray("parameters")]
        [XmlArrayItem("parameter")]
        public List<Parameter> Parameters { get; set; }
    }

    /// <summary>
    /// Contains definitions of each URI's Segment.
    /// </summary>
    public class Segment
    {
        [XmlElement("segment")]
        public string Path { get; set; }
    }

    /// <summary>
    /// Contains definitions of each URI's parameter.
    /// </summary>
    public class Parameter
    {
        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("key")]
        public string Key { get; set; }
    }

    /// <summary>
    /// Contains definitions of root element of the file.
    /// </summary>
    [XmlRoot("urlAddresses")]
    public class Adresses
    {
        public Adresses()
        {
            Uris = new List<UriScheme>();
        }

        [XmlElement("urlAdress")]
        public List<UriScheme> Uris { get; set; }
    }
}