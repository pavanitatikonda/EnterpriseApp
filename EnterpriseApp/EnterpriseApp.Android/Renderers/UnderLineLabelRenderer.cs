using Android.Content;
using Android.Graphics;
using EnterpriseApp.Controls;
using EnterpriseApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(UnderLineLabel), typeof(UnderLineLabelRenderer))]
namespace EnterpriseApp.Droid.Renderers
{
    class UnderLineLabelRenderer : LabelRenderer
    {
        public UnderLineLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                Control.PaintFlags = PaintFlags.UnderlineText;
            }
        }
    }
}
   