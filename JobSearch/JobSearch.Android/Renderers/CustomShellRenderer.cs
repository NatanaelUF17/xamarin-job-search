using System;
using Android.Content;
using Android.Graphics.Drawables;
using AndroidX.CoordinatorLayout.Widget;
using Google.Android.Material.AppBar;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(Shell), typeof(JobSearch.Droid.Renderers.CustomShellRenderer))]
namespace JobSearch.Droid.Renderers
{
	public class CustomShellRenderer : ShellRenderer
	{
		public CustomShellRenderer(Context context) : base(context) { }

        protected override IShellFlyoutContentRenderer CreateShellFlyoutContentRenderer()
        {
            var flyout = base.CreateShellFlyoutContentRenderer();

            GradientDrawable gradient = new GradientDrawable(
                GradientDrawable.Orientation.BottomTop, new Int32[]
                {
                    ((Color)App.LookupColor("FlyoutGradientEnd")).ToAndroid(),
                    ((Color)App.LookupColor("FlyoutGradientStart")).ToAndroid()
                });

            var coordinatorLayout = ((CoordinatorLayout)flyout.AndroidView);
            coordinatorLayout.SetBackground(gradient);

            var appBarLayout = (AppBarLayout)coordinatorLayout.GetChildAt(0);
            appBarLayout.SetBackgroundColor(Color.Transparent.ToAndroid());
            appBarLayout.OutlineProvider = null;

            var header = appBarLayout.GetChildAt(0);
            header.SetBackgroundColor(Color.Transparent.ToAndroid());

            return flyout;
        }
    }
}

