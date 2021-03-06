using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using System.Threading.Tasks;
using Android.Content.Res;

namespace SubSampleImageDemo
{
    public class ThumbImageFactory
    {
        public readonly Context context;
        public ThumbImageFactory(Context c)
        {
            context = c;
        }

        public static int CalculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight)
        {
            // Raw height and width of image
            float height = options.OutHeight;
            float width = options.OutWidth;
            double inSampleSize = 1D;

            if (height > reqHeight || width > reqWidth)
            {
                int halfHeight = (int)(height / 2);
                int halfWidth = (int)(width / 2);

                // Calculate a inSampleSize that is a power of 2 - the decoder will use a value that is a power of two anyway.
                while ((halfHeight / inSampleSize) > reqHeight && (halfWidth / inSampleSize) > reqWidth)
                {
                    inSampleSize *= 2;
                }

            }
            return (int)inSampleSize;
        }

        public  Bitmap LoadScaledDownBitmapForDisplay(Resources res, BitmapFactory.Options options, int reqWidth, int reqHeight,int resourceId)
        {
            // Calculate inSampleSize
            options.InSampleSize = CalculateInSampleSize(options, reqWidth, reqHeight);

            // Decode bitmap with inSampleSize set
            options.InJustDecodeBounds = false;

            return BitmapFactory.DecodeResource(res, resourceId, options);
        }

        public BitmapFactory.Options GetBitmapOptionsOfImage(int resourceId)
        {
            BitmapFactory.Options options = new BitmapFactory.Options
            {
                InJustDecodeBounds = true
            };

            // The result will be null because InJustDecodeBounds == true.
            Bitmap result = BitmapFactory.DecodeResource(context.Resources, resourceId, options);


            int imageHeight = options.OutHeight;
            int imageWidth = options.OutWidth;
            

            return options;
        }
    }
}