# GradientPages

## In MainActivity Initlize the package like this.

```
global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
GradientPages.Droid.GradientContentPageRenderer.Init(this);
```

## In AppDelegate Initlize the package like this.

```
global::Xamarin.Forms.Forms.Init();
GradientPages.iOS.GradientContentPageRenderer.Init();
```

## In XAML add NameSpace like this

```
xmlns:gradient="clr-namespace:GradientPages.Abstractions;assembly=GradientPages.Abstractions"
```

## Then you can use GradientPage Like this.

```
<?xml version="1.0" encoding="utf-8" ?>
<gradient:GradientContentPage
    x:Class="GradientTest.MainPage"
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:gradient="clr-namespace:GradientPages.Abstractions;assembly=GradientPages.Abstractions"
    StartColor="Black"
    EndColor="Green"
    Direction="ToBottom">
    <StackLayout>
        <!--  Place new controls here  -->
        <Label
            TextColor="White"
            HorizontalOptions="Center"
            Text="Welcome to Xamarin.Forms!"
            VerticalOptions="CenterAndExpand" />
    </StackLayout>
</gradient:GradientContentPage>
```
