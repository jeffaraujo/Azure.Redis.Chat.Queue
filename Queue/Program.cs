﻿using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;


namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            //DefaultEndpointsProtocol=https;AccountName=trezenet;AccountKey=AXwUsljgM169Q3c9IvcunCdagOXypuVtbaSs/mMmPCrPuMADu9rW7BYeEAE/B5Qm5v9sM956wpbBjpJYoj/8UQ==;EndpointSuffix=core.windows.net
            CloudStorageAccount account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=trezenet;AccountKey=AXwUsljgM169Q3c9IvcunCdagOXypuVtbaSs/mMmPCrPuMADu9rW7BYeEAE/B5Qm5v9sM956wpbBjpJYoj/8UQ==;EndpointSuffix=core.windows.net");
            var queueClient = account.CreateCloudQueueClient();

            var queue = queueClient.GetQueueReference("rm331132");
            queue.CreateIfNotExistsAsync().Wait();

            Console.WriteLine("Digite uma mensagem");
            var msg = Console.ReadLine();

            queue.AddMessageAsync(new CloudQueueMessage(msg));

            var messages = queue.GetMessagesAsync(10).Result;

            foreach (var m in messages)
            {
                Console.WriteLine($"Mensagem: {m.AsString}");

            }
            Console.Read();
        }
    }
}
