using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaListingApp.Core.Models;

namespace MediaListingApp.Core.Interfaces
{
    public interface IMediaService
    {
        Task<List<CategoryModel>> LoadMedia();
    }
}
