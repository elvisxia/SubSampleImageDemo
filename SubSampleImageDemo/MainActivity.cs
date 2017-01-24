using Android.App;
using Android.Widget;
using Android.OS;

namespace SubSampleImageDemo
{
    [Activity(Label = "SubSampleImageDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            var gridview = FindViewById<GridView>(Resource.Id.mGridView);
            gridview.Adapter = new ImageAdapter(this);

        }
    }
}

