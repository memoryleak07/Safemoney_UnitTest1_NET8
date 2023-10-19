﻿using Client.Models;
using Safemoney_UnitTest1_NET8.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Classes
{
    public class RestClient
    {
        private HTTPClient client;

        public RestClient(string baseUrl)
        {
            client = new HTTPClient(baseUrl);
        }
        public async Task<SMBase> Reboot()
        {
            return await client.PutAsJsonAsync<SMBase>("reboot");
        }
        public async Task<SMBase> PowerOff()
        {
            return await client.PutAsJsonAsync<SMBase>("poweroff");
        }
        public async Task<SMPayCreated> Pay(object payload)
        {
            return await client.PostAsJsonAsync<SMPayCreated>("pay", payload);
        }
        public async Task<SMPay> PayBegin(object payload)
        {
            return await client.PostAsJsonAsync<SMPay>("pay", payload);
        }
        public async Task<SMPay> PayDelete(object payload)
        {
            return await client.DeleteAsync<SMPay>("pay", payload);
        }
    }
}