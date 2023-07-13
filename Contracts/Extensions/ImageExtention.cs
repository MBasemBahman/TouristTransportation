using Entities.DBModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Extensions
{
    public static class ImageExtention
    {
        public static async Task<string> GetImageAsBase64Url(this string url)
        {
            using var handler = new HttpClientHandler { };
            using var client = new HttpClient(handler);
            var bytes = await client.GetByteArrayAsync(url);
            return "image/jpeg;base64," + Convert.ToBase64String(bytes);
        }
    }
}
