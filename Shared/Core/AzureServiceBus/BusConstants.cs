using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AzureServiceBus
{
    public class BusConstants
    {
        public const string ConnectionString = "Endpoint=sb://pempati.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=tFONrwvEz50LN4uomy/TT690iyY7GgnHx+ASbBzUScw=";
        public const string ConnectionString2 = "Endpoint=sb://pempati.servicebus.windows.net/;SharedAccessKeyName=test;SharedAccessKey=a6E16JaQJp1sVSO+t5/WN56rvY/J03kBp+ASbFtPhh8=";

        public const string MailCreatedQueue = "mailp";
        public const string directoryCreatedQueue = "directory";

        public const string OrderDeletedQueueName = "OrderDeletedQueue";

        public const string OrderTopic = "OrderTopic";
        public const string OrderCreatedSubName = "OrderCreatedSub";
        public const string OrderDeletedSubName = "OrderDeletedSub";
    }
}
