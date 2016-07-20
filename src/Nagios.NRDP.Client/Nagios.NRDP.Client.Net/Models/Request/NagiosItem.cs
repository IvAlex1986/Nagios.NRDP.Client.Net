using System;
using System.Collections.Generic;
using System.Text;

namespace Nagios.NRDP.Client.Net.Models.Request
{
    public abstract class NagiosItem : INagiosItem
    {
        protected NagiosItem(String hostName)
        {
            HostName = hostName;
            CheckDatas = new List<CheckData>();
        }

        protected abstract String GetItemType();

        protected abstract Int32 GetItemState();

        protected abstract String GenerateAdditionalData();

        #region INagiosItem

        public String Type
        {
            get
            {
                return GetItemType();
            }
        }

        public String HostName
        {
            get;
            set;
        }

        public Int32 State
        {
            get
            {
                return GetItemState();
            }
        }

        public String StatusData
        {
            get;
            set;
        }

        public IList<CheckData> CheckDatas
        {
            get;
            set;
        }

        public String GenerateItemData()
        {
            var builder = new StringBuilder();

            var data = String.Join(" ", CheckDatas);
            var delimiter = String.IsNullOrEmpty(data) ? String.Empty : "|";

            builder.AppendFormat("<checkresult type='{0}'>", GetItemType());
            builder.AppendFormat("<hostname>{0}</hostname>", HostName);
            builder.AppendFormat("<state>{0}</state>", State);
            builder.AppendFormat("<output>{0}{1}{2}</output>", StatusData, delimiter, data);
            builder.Append(GenerateAdditionalData());
            builder.Append("</checkresult>");

            return builder.ToString();
        }

        #endregion
    }
}
