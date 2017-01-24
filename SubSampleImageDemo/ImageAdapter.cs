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
using Java.Lang;
using Android.Graphics;

namespace SubSampleImageDemo
{
    public class ImageAdapter : BaseAdapter
    {
        private readonly Context context;
        private ThumbImageFactory thumbFactory;

        private int[] thumbIds = 
        {
            Resource.Drawable.beautifulChristmas,
            Resource.Drawable.beautifulGirl,
            Resource.Drawable.SleepingBaby,
            Resource.Drawable.oceanice,
            Resource.Drawable.grapes,
            Resource.Drawable.children,
            Resource.Drawable.business
        };

        public ImageAdapter(Context c)
        {
            context = c;
            thumbFactory = new ThumbImageFactory(c);
        }
        public override int Count
        {
            get
            {
                return thumbIds.Count();
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ImageView imageView;
            if (convertView == null)
            {
                imageView = new ImageView(this.context);
                imageView.LayoutParameters = new AbsListView.LayoutParams(150, 150);
                imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                imageView.SetPadding(0, 0, 0, 0);
            }
            else
            {
                imageView = (ImageView)convertView;
            }

            Bitmap bitmap = GetThumbImage(thumbIds[position]);
            imageView.SetImageBitmap(bitmap);
            return imageView;
        }

        public  Bitmap GetThumbImage(int resourceId)
        {
            BitmapFactory.Options options = thumbFactory.GetBitmapOptionsOfImage(resourceId);
            Bitmap bitmap=thumbFactory.LoadScaledDownBitmapForDisplay(context.Resources, options, 150, 150, resourceId);
            return bitmap;
        }
    }
}