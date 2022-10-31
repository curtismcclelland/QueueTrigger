using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class QueueTrigger2
    {
        [FunctionName("QueueTrigger2")]
        public void Run([QueueTrigger("myqueue-items", Connection = "southcentralqueue_STORAGE")]string myQueueItem, 
        [Blob("outcontainer/out.txt", FileAccess.Write, Connection="southcentralqueue_STORAGE")] out string myBlob1, ILogger log)
        {
            myBlob1 = myQueueItem;
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
