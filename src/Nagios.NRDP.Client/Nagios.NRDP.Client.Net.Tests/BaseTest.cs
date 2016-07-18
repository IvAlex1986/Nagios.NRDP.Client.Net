using System;
using System.Configuration;

namespace Nagios.NRDP.Client.Net.Tests
{
    public class BaseTest
    {
        public BaseTest()
        {
            ApiUrl = ConfigurationManager.AppSettings.Get("ApiUrl");
            Token = ConfigurationManager.AppSettings.Get("Token");
        }

        protected String ApiUrl { get; set; }

        protected String Token { get; set; }

        protected INagiosNrdpClient GetNagiosNrdpClient()
        {
            return new NagiosNrdpClient(ApiUrl, Token);
        }
    }
}
