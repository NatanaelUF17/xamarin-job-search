using System;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(Shell), typeof(JobSearch.iOS.Renderers.CustomShellRenderer))]
namespace JobSearch.iOS.Renderers
{
	public class CustomShellRenderer : ShellRenderer
	{
		private CAGradientLayer _flyoutBackground = null;

		private void OnFlyoutWillAppear(object sender, EventArgs e)
		{
			if (_flyoutBackground == null &&
				sender != null &&
				sender is IShellFlyoutContentRenderer flyout)
			{
				var view = flyout.ViewController.View;

				_flyoutBackground = new CAGradientLayer
				{
					Frame = new CGRect(0, 0, view.Bounds.Width, view.Bounds.Height)
				};

				_flyoutBackground.Colors = new CGColor[]
				{
                    ((Color)App.LookupColor("FlyoutGradientEnd")).ToCGColor(),
                    ((Color)App.LookupColor("FlyoutGradientStart")).ToCGColor()
                };

				flyout.ViewController.View.Layer.InsertSublayer(_flyoutBackground, 0);

				flyout.WillAppear -= OnFlyoutWillAppear;
			}
		}

        protected override IShellFlyoutContentRenderer CreateShellFlyoutContentRenderer()
        {
            var flyout = base.CreateShellFlyoutContentRenderer();
			flyout.WillAppear += OnFlyoutWillAppear;

			var tableView = (UITableView)flyout.ViewController.View.Subviews[0];
			var tableViewSource = (ShellTableViewSource)tableView.Source;

			tableViewSource.Groups.RemoveAt(1);

			return flyout;
        }
    }
}

