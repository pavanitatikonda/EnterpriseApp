using EnterpriseApp.Controls;
using EnterpriseApp.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryRmUnderline), typeof(EntryRmUnderlineRenderer))]
namespace EnterpriseApp.iOS.Renderers
{
    class EntryRmUnderlineRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
                Control.Layer.CornerRadius = 10;
                Control.TintColor = UIColor.Black;
            }
        }
    }
}