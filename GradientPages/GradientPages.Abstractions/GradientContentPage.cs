using Xamarin.Forms;

namespace GradientPages.Abstractions
{
    public class GradientContentPage : ContentPage
    {
        public static readonly BindableProperty StartColorProperty =
            BindableProperty.Create(
                propertyName: nameof(StartColor),
                returnType: typeof(Color),
                declaringType: typeof(GradientContentPage),
                defaultValue: Color.Transparent);

        public static readonly BindableProperty EndColorProperty =
            BindableProperty.Create(
                propertyName: nameof(EndColor),
                returnType: typeof(Color),
                declaringType: typeof(GradientContentPage),
                defaultValue: Color.Transparent);

        public static readonly BindableProperty DirectionProperty =
            BindableProperty.Create(
                propertyName: nameof(Direction),
                returnType: typeof(GradientDirection),
                declaringType: typeof(GradientContentPage),
                defaultValue: GradientDirection.ToRight);

        public Color StartColor
        {
            get { return (Color)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }

        public Color EndColor
        {
            get { return (Color)GetValue(EndColorProperty); }
            set { SetValue(EndColorProperty, value); }
        }

        public GradientDirection Direction
        {
            get { return (GradientDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }
    }

    public enum GradientDirection
    {
        ToRight,
        ToLeft,
        ToTop,
        ToBottom,
        ToTopLeft,
        ToTopRight,
        ToBottomLeft,
        ToBottomRight
    }
}
