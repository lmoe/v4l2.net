// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Iot.Device.Media;

namespace V4l2.Samples
{
    class Program
    {
        public static void CompareType<T>()
        {
            
            var safe = Unsafe.SizeOf<T>();
            var marshal = Marshal.SizeOf<T>();
            
            Debug.WriteLine(typeof(T).Name + $"{safe.ToString()},{marshal.ToString()}");

            
        }
        
        static void Main(string[] args)
        {
            CompareType<v4l2_capability>();
            CompareType<v4l2_fmtdesc>();
            CompareType<v4l2_requestbuffers>();
            CompareType<int>();
            CompareType<v4l2_control>();
            CompareType<v4l2_queryctrl>();
            CompareType<v4l2_cropcap>();
            CompareType<v4l2_crop>();
            CompareType<v4l2_format>();
            CompareType<v4l2_format_aligned>();
            CompareType<v4l2_frmsizeenum>();
            CompareType<v4l2_buffer>();
            
            VideoConnectionSettings settings = new VideoConnectionSettings(0)
            {
                CaptureSize = (1920, 1080),
                PixelFormat = PixelFormat.MJPEG,
                ExposureType = ExposureType.Auto
            };
            using VideoDevice device = VideoDevice.Create(settings);
            
            string path = Directory.GetCurrentDirectory();

            // Take photos
            device.Capture($"{path}/jpg_direct_output.jpg");

            // Change capture setting
           // device.Settings.PixelFormat = PixelFormat.YUV420;

            // Convert pixel format
          //  Color[] colors = VideoDevice.Yv12ToRgb(device.Capture(), settings.CaptureSize);
          //  Bitmap bitmap = VideoDevice.RgbToBitmap(settings.CaptureSize, colors);
          //  bitmap.Save($"{path}/yuyv_to_jpg.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
