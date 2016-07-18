using Nagios.NRDP.Client.Net.Enums;
using System;

namespace Nagios.NRDP.Client.Net.Models.Request
{
    public class Service : NagiosItem
    {
        public Service(String hostName, String serviceName)
            : base(hostName)
        {
            ServiceName = serviceName;
        }

        public String ServiceName
        {
            get;
            set;
        }

        public ServiceState ServiceState
        {
            get;
            set;
        }

        #region NagiosItem

        protected override String GetItemType()
        {
            return "service";
        }

        protected override Int32 GetItemState()
        {
            return (Int32)ServiceState;
        }

        protected override string GenerateAdditionalData()
        {
            return String.Format("<servicename>{0}</servicename>", ServiceName);
        }

        #endregion
    }
}
