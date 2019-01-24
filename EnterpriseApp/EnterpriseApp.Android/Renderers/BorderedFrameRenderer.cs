using Android.Content;
using EnterpriseApp.Controls;
using EnterpriseApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderedFrame), typeof(BorderedFrameRenderer))]
namespace EnterpriseApp.Droid.Renderers
{
    class BorderedFrameRenderer: FrameRenderer
    {
        public BorderedFrameRenderer(Context context) : base(context)
        {

        }
    }
}