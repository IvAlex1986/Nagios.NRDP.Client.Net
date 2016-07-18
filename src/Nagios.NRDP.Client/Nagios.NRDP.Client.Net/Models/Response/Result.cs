using System;

namespace Nagios.NRDP.Client.Net.Models.Response
{
    public class Result
    {
        public Int32 Status { get; set; }

        public String Message { get; set; }

        public String Output { get; set; }

        public Boolean IsSuccess
        {
            get { return Status == 0; }
        }
    }
}
