using Nagios.NRDP.Client.Net.Enums;
using Nagios.NRDP.Client.Net.Models.Request;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Nagios.NRDP.Client.Net.Tests
{
    public class SubmitCheckDataTest : BaseTest
    {
        [Test]
        public void TestInvalidArguments()
        {
            var client = GetNagiosNrdpClient();
            Assert.Throws<ArgumentException>(() => client.SubmitCheckData());
        }

        [Test]
        public void TestInvalidToken()
        {
            var client = GetNagiosNrdpClient(ApiUrl, String.Empty);
            var result = client.SubmitCheckData(new Host("Test"));

            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void TestSubmitData()
        {
            var client = GetNagiosNrdpClient();

            var host = new Host("Test")
            {
                HostState = HostState.Up,
                StatusData = "Host works fine"
            };

            var service = new Service("Test", "Test Service")
            {
                ServiceState = ServiceState.Critical,
                StatusData = "Critical Error!",
                CheckDatas = new List<CheckData>
                {
                    new CheckData("Ampers", 10.567)
                    {
                        Dimension = "A",
                        WarningScale = 20,
                        ErrorScale = 40,
                        MinScale = 0,
                        MaxScale = 50
                    },
                    new CheckData("Volts", 220.123)
                    {
                        Dimension = "V",
                        MinScale = 0,
                        MaxScale = 340
                    }
                }
            };

            var result = client.SubmitCheckData(host, service);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccess);
            Assert.IsNotEmpty(result.Message);
            Assert.IsNotEmpty(result.Outputs);
            Assert.IsNotEmpty(result.Output);
        }
    }
}
