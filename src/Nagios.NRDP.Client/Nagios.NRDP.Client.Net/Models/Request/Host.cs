using Nagios.NRDP.Client.Net.Enums;
using System;

namespace Nagios.NRDP.Client.Net.Models.Request
{
    public class Host : NagiosItem
    {
        public Host(String hostName)
            : base(hostName)
        {
        }

        public HostState HostState { get; set; }

        #region NagiosItem

        protected override String GetItemType()
        {
            return "host";
        }

        protected override Int32 GetItemState()
        {
            return (Int32)HostState;
        }

        protected override String GenerateAdditionalData()
        {
            return String.Empty;
        }

        #endregion
    }
}
