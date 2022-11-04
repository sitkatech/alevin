﻿/*-----------------------------------------------------------------------
<copyright file="ImageHelper.cs" company="Environmental Science Associates">
Copyright (c) Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace LtInfo.Common
{
    public class Jpeg : IDisposable
    {
        public enum RotationDirection
        {
            Clockwise,
            CounterClockwise
        }

        private readonly Bitmap _bitmap;
        private readonly ImageCodecInfo _codecInfo;

        private readonly string _fileName;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Jpeg(string fileName)
        {
            _fileName = fileName;
            _bitmap = new Bitmap(_fileName);
            Width = _bitmap.Width;
            Height = _bitmap.Height;

            _codecInfo = GetEncoderInfo("image/jpeg");
            if (_codecInfo == null)
            {
                throw new Exception("no jpeg encoder found.");
            }
        }

        public Jpeg(Bitmap bitmap)
        {
            _bitmap = bitmap;
            Width = _bitmap.Width;
            Height = _bitmap.Height;

            _codecInfo = GetEncoderInfo("image/jpeg");
            if (_codecInfo == null)
            {
                throw new Exception("no jpeg encoder found.");
            }
        }


        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        public string SaveResized(string fileName, int maxDimension, long quality)
        {
            if (Path.GetExtension(fileName) != ".jpg")
            {
                fileName = String.Format(@"{0}\{1}.jpg", Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName));
                //fileName = Path.GetDirectoryName(fileName) + @"\" + Path.GetFileNameWithoutExtension(fileName) + ".jpg";
            }


            Encoder encoder = Encoder.Quality;
            var parameters = new EncoderParameters(1);
            var parameter = new EncoderParameter(encoder, quality);
            parameters.Param[0] = parameter;

            //using (Bitmap image = new Bitmap(_fileName))
            {
                Image thumb;
                double factor = _bitmap.Width/((float)_bitmap.Height);
                if (factor > 1.0 && _bitmap.Width > maxDimension)
                {
                    // wide
                    Width = maxDimension;
                    Height = (int)(maxDimension/factor);

                    //thumb = new Bitmap(_bitmap, maxDimension, (int)(maxDimension / factor));
                    thumb = new Bitmap(Width, Height);

                    Graphics g = Graphics.FromImage(thumb);
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(_bitmap, 0, 0, maxDimension, (int)(maxDimension/factor));
                }
                else if (_bitmap.Height > maxDimension)
                {
                    // tall
                    Width = (int)(maxDimension*factor);
                    Height = maxDimension;

                    thumb = new Bitmap(Width, Height);

                    Graphics g = Graphics.FromImage(thumb);
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(_bitmap, 0, 0, (int)(maxDimension*factor), maxDimension);
                }
                else
                {
                    // small enough already
                    thumb = new Bitmap(_bitmap);
                }

                thumb.Save(fileName, _codecInfo, parameters);
            }

            return Path.GetFileName(fileName);
        }

        public MemoryStream SaveResized(int maxDimension, long quality, string mimeType)
        {
            Encoder encoder = Encoder.Quality;
            var parameters = new EncoderParameters(1);
            var parameter = new EncoderParameter(encoder, quality);
            parameters.Param[0] = parameter;

            Image thumb;
            double factor = _bitmap.Width/((float)_bitmap.Height);
            if (factor > 1.0 && _bitmap.Width > maxDimension)
            {
                // wide
                Width = maxDimension;
                Height = (int)(maxDimension/factor);

                thumb = new Bitmap(Width, Height);
            
                var rect = new Rectangle(0, 0, maxDimension, (int) (maxDimension / factor));

                switch (mimeType)
                {
                    case "image/png":
                        ((Bitmap)thumb).MakeTransparent(((Bitmap)thumb).GetPixel(0,0));
                        break;
                    case "image/gif":
                        //thumb = MakeTransparentGif((Bitmap)thumb, ((Bitmap) thumb).GetPixel(0, 0));
                        break;
                }

                Graphics g = Graphics.FromImage(thumb);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(_bitmap, rect,0,0, _bitmap.Width, _bitmap.Height, GraphicsUnit.Pixel);
            }
            else if (_bitmap.Height > maxDimension)
            {
                // tall
                Width = (int)(maxDimension*factor);
                Height = maxDimension;

                thumb = new Bitmap(Width, Height);
                
                var rect = new Rectangle(0, 0, (int)(maxDimension*factor), maxDimension);
                
                switch (mimeType)
                {
                    case "image/gif":
                    case "image/png":
                        ((Bitmap)thumb).MakeTransparent(((Bitmap)thumb).GetPixel(0,0));
                        break;
                }

                Graphics g = Graphics.FromImage(thumb);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(_bitmap, rect, 0, 0, _bitmap.Width, _bitmap.Height, GraphicsUnit.Pixel);
            }
            else
            {
                // small enough already
                thumb = new Bitmap(_bitmap);
            }

            var stream = new MemoryStream();
            thumb.Save(stream, ImageFormat.Png);// always save as a png, this makes transparent gif's that are uploaded stay transparent in their thumbnails

            return stream;
        }
        
        public MemoryStream SaveSquared(int maxDimension, long quality)
        {
            var encoder = Encoder.Quality;
            var parameters = new EncoderParameters(1);
            var parameter = new EncoderParameter(encoder, quality);
            parameters.Param[0] = parameter;

            //using (Bitmap image = new Bitmap(_fileName))


            Image thumb;
            double factor = _bitmap.Width/((float)_bitmap.Height);
            if (factor > 1.0 && _bitmap.Width > maxDimension)
            {
                // wide
                //thumb = new Bitmap(_bitmap, maxDimension, (int)(maxDimension / factor));
                thumb = new Bitmap(maxDimension, maxDimension);


                var offset = (int)((_bitmap.Width - (float)_bitmap.Height)/2*(maxDimension/(float)_bitmap.Height));

                Graphics g = Graphics.FromImage(thumb);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(_bitmap, -offset, 0, (int)(maxDimension*factor), maxDimension);
            }
            else if (_bitmap.Height > maxDimension)
            {
                // tall
                //thumb = new Bitmap(_bitmap, (int)(maxDimension * factor), maxDimension);
                thumb = new Bitmap(maxDimension, maxDimension);

                var offset = (int)((_bitmap.Height - (float)_bitmap.Width)/2*(maxDimension/(float)_bitmap.Width));

                Graphics g = Graphics.FromImage(thumb);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(_bitmap, 0, -offset, maxDimension, (int)(maxDimension/factor));
            }
            else
            {
                // small enough already
                thumb = new Bitmap(_bitmap);
            }

            var stream = new MemoryStream();
            thumb.Save(stream, _codecInfo, parameters);

            return stream;
        }

        public static void Rotate(string fileName, RotationDirection direction, long quality)
        {
            // this JPeg Rotation is lossy.  We'll need to get the below working to avoid setting jpeg quality to zero.
            var bitmap = new Bitmap(fileName);

            bitmap.RotateFlip(direction == RotationDirection.Clockwise ? RotateFlipType.Rotate90FlipNone : RotateFlipType.Rotate270FlipNone);

            bitmap.Save(fileName);
        }

        #region IDisposable Members

        public void Dispose()
        {
            _bitmap.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }

    public class ImageHelper
    {
        public static byte[] CreateAndSquarePhotoFromJpeg(Jpeg photo, int maxDimension)
        {
            var stream = photo.SaveSquared(maxDimension, 100);
            return stream.ToArray();
        }

        public static byte[] CreateAndResizePhotoFromJpeg(Jpeg photo, int maxDimension, string mimeType)
        {
            var stream = photo.SaveResized(maxDimension, 100, mimeType);
            return stream.ToArray();
        }

        public static int ScaledImageHeight(int imageWidth, int imageHeight, int maxWidth, int maxHeight) 
        {
            var scale = (float) imageHeight / maxHeight;
            if (imageWidth / scale > maxWidth)
            {
                //use height scale instead
                var widthScale = (float)imageWidth / maxWidth;

                return (int) (imageHeight / widthScale);
            }
            return maxHeight;
        } 
        
        public static int ScaledImageWidth(int imageWidth, int imageHeight, int maxWidth, int maxHeight) 
        {
            var scale = (float) imageWidth / maxWidth;
            if (imageHeight / scale > maxHeight)
            {
                //use height scale instead
                var heightScale = (float)imageHeight / maxHeight;

                return (int) (imageWidth / heightScale);
            }
            return maxWidth;
        }

        public static Image ScaleImage(byte[] imageData, int maxWidth, int maxHeight)
        {
            using (var ms = new MemoryStream(imageData))
            {
                using (var image = Image.FromStream(ms))
                {
                    return ScaleImage(image, maxWidth, maxHeight);
                }
            }
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            RotateImageByExifOrientationData(image, false);

            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        /// <summary>
        /// Rotate the given bitmap according to Exif Orientation data
        /// </summary>
        /// <param name="img">source image</param>
        /// <param name="updateExifData">set it to TRUE to update image Exif data after rotation (default is TRUE)</param>
        /// <returns>The RotateFlipType value corresponding to the applied rotation. If no rotation occurred, RotateFlipType.RotateNoneFlipNone will be returned.</returns>
        public static RotateFlipType RotateImageByExifOrientationData(Image img, bool updateExifData = true)
        {
            int orientationId = 0x0112;
            var fType = RotateFlipType.RotateNoneFlipNone;
            var propertyList = new List<int>(img.PropertyIdList);
            if (propertyList.Contains(orientationId))
            {
                var pItem = img.GetPropertyItem(orientationId);
                fType = GetRotateFlipTypeByExifOrientationData(pItem.Value[0]);
                if (fType != RotateFlipType.RotateNoneFlipNone)
                {
                    img.RotateFlip(fType);
                    // Remove Exif orientation tag (if requested)
                    if (updateExifData) img.RemovePropertyItem(orientationId);
                }
            }
            return fType;
        }

        /// <summary>
        /// Return the proper System.Drawing.RotateFlipType according to given orientation EXIF metadata
        /// </summary>
        /// <param name="orientation">Exif "Orientation"</param>
        /// <returns>the corresponding System.Drawing.RotateFlipType enum value</returns>
        public static RotateFlipType GetRotateFlipTypeByExifOrientationData(int orientation)
        {
            switch (orientation)
            {
                case 1:
                default:
                    return RotateFlipType.RotateNoneFlipNone;
                case 2:
                    return RotateFlipType.RotateNoneFlipX;
                case 3:
                    return RotateFlipType.Rotate180FlipNone;
                case 4:
                    return RotateFlipType.Rotate180FlipX;
                case 5:
                    return RotateFlipType.Rotate90FlipX;
                case 6:
                    return RotateFlipType.Rotate90FlipNone;
                case 7:
                    return RotateFlipType.Rotate270FlipX;
                case 8:
                    return RotateFlipType.Rotate270FlipNone;
            }
        }
    }
}
