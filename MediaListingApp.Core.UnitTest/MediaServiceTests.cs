using System;
using MediaListingApp.Core.Services;
using NUnit.Framework;

namespace MediaListingApp.Core.UnitTest
{
    [TestFixture]
    public class MediaServiceTests
    {
        [Test]
        public async void LoadMediaTest()
        {
            var mediaService = new MediaService();

            var medias = await mediaService.LoadMedia();

        	Assert.NotNull(medias);
            Assert.AreNotEqual(medias.Count, 0);
        }
    }
}
