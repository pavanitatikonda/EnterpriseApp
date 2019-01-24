using Android.Content;
using EnterpriseApp.Controls;
using EnterpriseApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CurvedButton), typeof(CurvedButtonRenderer))]
namespace EnterpriseApp.Droid.Renderers
{
    class CurvedButtonRenderer : ButtonRenderer
    {
        public CurvedButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.button_border);
                Control.SetAllCaps(false);
            }
        }
    }
}