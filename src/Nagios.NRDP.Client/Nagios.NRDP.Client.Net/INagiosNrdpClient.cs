using Nagios.NRDP.Client.Net.Models.Request;
using Nagios.NRDP.Client.Net.Models.Response;
using System;

namespace Nagios.NRDP.Client.Net
{
    public interface INagiosNrdpClient
    {
        Uri ApiUri { get; }

        String Token { get; }

        Result SubmitCheckData(params INagiosItem[] items);
    }
}
