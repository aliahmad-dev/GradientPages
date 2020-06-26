using System;
using CoreAnimation;
using CoreGraphics;
using GradientPages.Abstractions;
using GradientPages.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientContentPage), typeof(GradientContentPageRenderer))]
namespace GradientPages.iOS
{
    public class GradientContentPageRenderer : PageRenderer
    {
        new public static void Init() { DateTime temp = DateTime.Now; }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (!(e.NewElement is GradientContentPage))
                return;

            SetGradientBackground();
        }

        protected override void Dispose(bool disposing)
        {
            Element.PropertyChanged -= Control_PropertyChanged;
            base.Dispose(disposing);
        }

        private void SetGradientBackground(bool updateLayer = false)
        {
            var control = (GradientContentPage)Element;

            var gradientLayer = new CAGradientLayer();

            switch (control.Direction)
            {
                default:
                case GradientDirection.ToRight:
                    gradientLayer.StartPoint = new CGPoint(0, 0.5);
                    gradientLayer.EndPoint = new CGPoint(1, 0.5);
                    break;
                case GradientDirection.ToLeft:
                    gradientLayer.StartPoint = new CGPoint(1, 0.5);
                    gradientLayer.EndPoint = new CGPoint(0, 0.5);
                    break;
                case GradientDirection.ToTop:
                    gradientLayer.StartPoint = new CGPoint(0.5, 1);
                    gradientLayer.EndPoint = new CGPoint(0.5, 0);
                    break;
                case GradientDirection.ToBottom:
                    gradientLayer.StartPoint = new CGPoint(0.5, 0);
                    gradientLayer.EndPoint = new CGPoint(0.5, 1);
                    break;
                case GradientDirection.ToTopLeft:
                    gradientLayer.StartPoint = new CGPoint(1, 1);
                    gradientLayer.EndPoint = new CGPoint(0, 0);
                    break;
                case GradientDirection.ToTopRight:
                    gradientLayer.StartPoint = new CGPoint(0, 1);
                    gradientLayer.EndPoint = new CGPoint(1, 0);
                    break;
                case GradientDirection.ToBottomLeft:
                    gradientLayer.StartPoint = new CGPoint(1, 0);
                    gradientLayer.EndPoint = new CGPoint(0, 1);
                    break;
                case GradientDirection.ToBottomRight:
                    gradientLayer.StartPoint = new CGPoint(0, 0);
                    gradientLayer.EndPoint = new CGPoint(1, 1);
                    break;
            }
            gradientLayer.Frame = View.Bounds;
            gradientLayer.Colors = new CGColor[] { control.StartColor.ToCGColor(), control.EndColor.ToCGColor() };
            if(!updateLayer)
            {
                NativeView.Layer.InsertSublayer(gradientLayer, 0);
                control.PropertyChanged += Control_PropertyChanged;
            }
            else
                NativeView.Layer.ReplaceSublayer(NativeView.Layer.Sublayers[0], gradientLayer);
        }

        private void Control_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SetGradientBackground(true);
        }
    }
}
