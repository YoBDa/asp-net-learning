﻿using System.Net.Http;
using System.Threading.Tasks;

namespace LangFeatures.Models
{
    public class MyAsyncMethods
    {
        public async static Task<long?> GetPageLength()
        {
            
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("https://cloud.netele.ga/");
            return httpMessage.Content.Headers.ContentLength; 
        }
    }
}
