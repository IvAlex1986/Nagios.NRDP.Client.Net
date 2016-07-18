using System;
using System.Xml.Serialization;

namespace Nagios.NRDP.Client.Net.Models.Response
{
    [XmlRoot(ElementName = "result")]
    public class Result
    {
        [XmlElement(ElementName = "status")]
        public Int32 Status { get; set; }

        [XmlElement(ElementName = "message")]
        public String Message { get; set; }

        [XmlArray("meta")]
        [XmlArrayItem("output")]
        public String[] Outputs { get; set; }

        [XmlIgnore]
        public Boolean IsSuccess
        {
            get { return Status == 0; }
        }

        [XmlIgnore]
        public String Output
        {
            get { return (Outputs == null) ? String.Empty : String.Join(@"\n", Outputs); }
        }
    }
}
