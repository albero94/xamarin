﻿using Microsoft.WindowsAzure.MobileServices;
using TaskList.Abstractions;

namespace TaskList.Services
{
    public class AzureCloudService : ICloudService
    {
        private readonly MobileServiceClient client;

        public AzureCloudService()
        {
            client = new MobileServiceClient(@"https://websitecoktqqpz3mcog.azurewebsites.net");
        }

        public ICloudTable<T> GetTable<T>() where T : TableData
        {
            return new AzureCloudTable<T>(client);
        }
    }
}