using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using MediaListingApp.Core.Helpers;
using MediaListingApp.Core.Interfaces;
using MediaListingApp.Core.Models;

namespace MediaListingApp.Core.Services
{
    public class MediaService: IMediaService
    {
        private string baseUrl;

        public MediaService()
        {
            baseUrl = "https://pastebin.com/";
        }

        public async Task<List<CategoryModel>> LoadMedia()
        {
            List<CategoryModel> result = new List<CategoryModel>();
            try
            {
                var resp = await baseUrl
                    .AppendPathSegment("raw/8LiEHfwU")
                    .GetAsync();

                if(resp.IsSuccessStatusCode)
                {
                    var data = await resp.Content.ReadAsStringAsync();
                    result = data.ToObject<List<CategoryModel>>();
                }
            }
            catch(Exception ex)
            {
                
            }

            return result;
        }
    }
}
