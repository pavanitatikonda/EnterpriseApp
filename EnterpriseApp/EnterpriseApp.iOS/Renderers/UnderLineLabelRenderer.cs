using EnterpriseApp.Controls;
using EnterpriseApp.iOS.Renderers;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(UnderLineLabel), typeof(UnderLineLabelRenderer))]
namespace EnterpriseApp.iOS.Renderers
{
    class UnderLineLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                if (e.NewElement != null)
                {
                    var label = (UnderLineLabel)this.Element;
                    this.Control.AttributedText = new NSAttributedString(label.Text, underlineStyle: NSUnderlineStyle.Single);
                }
            }
        }
    }
}