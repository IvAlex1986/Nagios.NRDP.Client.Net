using System;
using System.Collections.Generic;

namespace Nagios.NRDP.Client.Net.Models.Request
{
    public interface INagiosItem
    {
        String Type { get; }

        String HostName { get; }

        Int32 State { get; }

        String StatusData { get; }

        IEnumerable<CheckData> CheckDatas { get; }

        String GenerateItemData();
    }
}
