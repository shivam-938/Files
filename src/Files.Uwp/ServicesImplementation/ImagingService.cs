﻿using Files.Backend.Models.Imaging;
using Files.Backend.Services;
using Files.Helpers;
using Files.Uwp.Imaging;
using Microsoft.Toolkit.Uwp;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Storage.FileProperties;
using Windows.UI.Core;

namespace Files.Uwp.ServicesImplementation
{
    internal sealed class ImagingService : IImagingService
    {
        public async Task<ImageModel?> GetImageModelFromDataAsync(byte[] rawData)
        {
            return new BitmapImageModel(await BitmapHelper.ToBitmapAsync(rawData));
        }

        public async Task<ImageModel?> GetImageModelFromPathAsync(string filePath, uint thumbnailSize = 64)
        {
            ImageModel? imageModel = null;

            if (await FileThumbnailHelper.LoadIconFromPathAsync(filePath, thumbnailSize, ThumbnailMode.ListView) is byte[] imageBuffer)
            {
                imageModel = await GetImageModelFromDataAsync(imageBuffer);
            }

            return imageModel;
        }
    }
}
