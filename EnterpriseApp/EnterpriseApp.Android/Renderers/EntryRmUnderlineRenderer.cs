using Android.Content;
using Android.Graphics.Drawables;
using Android.Text;
using EnterpriseApp.Controls;
using EnterpriseApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryRmUnderline), typeof(EntryRmUnderlineRenderer))]
namespace EnterpriseApp.Droid.Renderers
{
    class EntryRmUnderlineRenderer : EntryRenderer
    {
        public EntryRmUnderlineRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.Transparent);
                this.Control.SetBackground(gd);
                this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                
            }
        }
    }
}