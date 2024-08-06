namespace Test.Views.Entry;
#region EntryHandler
#if ANDROID
using Android.Content.Res;
using Microsoft.Maui.Platform;
#endif
#if IOS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endif
#endregion
public partial class CustomEntry1View : ContentView
{
	public CustomEntry1View()
	{
		InitializeComponent();
        #region EntryHandler

#if ANDROID
        Microsoft.Maui.Handlers.EntryHandler.Mapper.ModifyMapping(nameof(CustomEntry1View), (h, v, d) =>
        {
            h.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
        });
#endif
#if IOS
        Microsoft.Maui.Handlers.EntryHandler.Mapper.ModifyMapping(nameof(CustomEntry1View), (handler, view, property) =>
        {
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
        });
#endif
        #endregion
    }
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
                                                     propertyName: nameof(Title),
                                                     returnType: typeof(string),
                                                     declaringType: typeof(CustomEntry1View),
                                                     defaultValue: "",
                                                     defaultBindingMode: BindingMode.TwoWay,
                                                     propertyChanged: TitlePropertyChanged);
    private static void TitlePropertyChanged(BindableObject bendable, object oldValue, object newValue)
    {
        var Control = (CustomEntry1View)bendable;
        Control.TitleLabel.Text = (string)newValue;
    }
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
                                                     propertyName: nameof(Text),
                                                     returnType: typeof(string),
                                                     declaringType: typeof(CustomEntry1View),
                                                     defaultValue: "",
                                                     defaultBindingMode: BindingMode.TwoWay,
                                                     propertyChanged: TextPropertyChanged);
    private static void TextPropertyChanged(BindableObject bendable, object oldValue, object newValue)
    {
        var Control = (CustomEntry1View)bendable;
        Control.InputEntry.Text = (string)newValue;
    }

    private void InputEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        Text = InputEntry.Text;
    }
}