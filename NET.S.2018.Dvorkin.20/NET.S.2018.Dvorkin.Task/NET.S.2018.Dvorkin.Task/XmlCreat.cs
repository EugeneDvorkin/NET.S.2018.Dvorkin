using System;
using System.IO;
using System.Xml.Serialization;
using NET.S._2018.Dvorkin.Task.Model;

namespace NET.S._2018.Dvorkin.Task
{
    /// <summary>
    /// Contains definition of creating XML file.
    /// </summary>
    public class XmlCreat
    {
        private Adresses uris;
        private string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlCreat"/> class.
        /// </summary>
        /// <param name="uris">The uris.</param>
        /// <param name="path">The path.</param>
        /// <exception cref="System.ArgumentNullException">uris</exception>
        public XmlCreat(Adresses uris, string path)
        {
            if (ReferenceEquals(uris, null) || string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException($"{nameof(uris)} or {nameof(path)} is null");
            }

            this.uris = uris;
            this.path = path;
        }

        /// <summary>
        /// Writes the XML.
        /// </summary>
        public void WriteXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Adresses));
            using (Stream stream = File.Create(path))
            {
                serializer.Serialize(stream, uris);
            }
        }
    }
}