using System;

namespace Nagios.NRDP.Client.Net.Models.Request
{
    public class CheckData
    {
        public CheckData(String name, Double value)
        {
            Name = name;
            Value = value;
        }

        public String Name
        {
            get;
            set;
        }

        public Double Value
        {
            get;
            set;
        }

        public String Dimension
        {
            get;
            set;
        }

        public Double? WarningScale
        {
            get;
            set;
        }

        public Double? ErrorScale
        {
            get;
            set;
        }

        public Double? MinScale
        {
            get;
            set;
        }

        public Double? MaxScale
        {
            get;
            set;
        }

        public override string ToString()
        {
            var values = String.Join(";", new[] {WarningScale, ErrorScale, MinScale, MaxScale});
            return String.Format("{0}={1}{2} {3}", Name, Value, Dimension, values);
        }
    }
}
