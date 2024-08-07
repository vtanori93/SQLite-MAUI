using System.Windows.Input;

namespace Test.Views.Entry;
public partial class CustomEntry1View : ContentView
{
	public CustomEntry1View()
	{
		InitializeComponent();
    }
    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
                                                        nameof(Command),
                                                        typeof(ICommand),
                                                        typeof(CustomEntry1View), null);
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
    public bool IsDataPicker
    {
        get => (bool)GetValue(IsDataPickerProperty);
        set => SetValue(IsDataPickerProperty, value);
    }
    public static readonly BindableProperty IsDataPickerProperty = BindableProperty.Create(
                                                     propertyName: nameof(IsDataPicker),
                                                     returnType: typeof(bool),
                                                     declaringType: typeof(CustomEntry1View),
                                                     defaultValue: false,
                                                     defaultBindingMode: BindingMode.TwoWay,
                                                     propertyChanged: IsDataPickerPropertyChanged);
    private static void IsDataPickerPropertyChanged(BindableObject bendable, object oldValue, object newValue)
    {
        var Control = (CustomEntry1View)bendable;
        if ((bool)newValue)
        {
            Control.InputEntry.IsVisible = false;
            Control.DatePickerSelector1.IsVisible = true;
            Control.DatePickerSelector1.MaximumDate = DateTime.Now.AddYears(-18);
        }
    }
    private void DatePickerSelector1_DateSelected(object sender, DateChangedEventArgs e)
    {
        Text = DatePickerSelector1.Date.ToString("dd/MM/yyyy");
    }
    public bool IsCombobox
    {
        get => (bool)GetValue(IsComboboxProperty);
        set => SetValue(IsComboboxProperty, value);
    }
    public static readonly BindableProperty IsComboboxProperty = BindableProperty.Create(
                                                     propertyName: nameof(IsCombobox),
                                                     returnType: typeof(bool),
                                                     declaringType: typeof(CustomEntry1View),
                                                     defaultValue: false,
                                                     defaultBindingMode: BindingMode.TwoWay,
                                                     propertyChanged: IsComboboxPropertyChanged);
    private static void IsComboboxPropertyChanged(BindableObject bendable, object oldValue, object newValue)
    {
        var Control = (CustomEntry1View)bendable;
        if ((bool)newValue)
        {
            Control.InputEntry.InputTransparent = true;
            Control.ComboboxImage.InputTransparent = true;
            Control.ComboboxImage.IsVisible = true;
        }
    }
    public bool IsKeyboardNumeric
    {
        get => (bool)GetValue(IsKeyboardNumericProperty);
        set => SetValue(IsKeyboardNumericProperty, value);
    }
    public static readonly BindableProperty IsKeyboardNumericProperty = BindableProperty.Create(
                                                     propertyName: nameof(IsKeyboardNumeric),
                                                     returnType: typeof(bool),
                                                     declaringType: typeof(CustomEntry1View),
                                                     defaultValue: false,
                                                     defaultBindingMode: BindingMode.TwoWay,
                                                     propertyChanged: IsKeyboardNumericPropertyChanged);
    private static void IsKeyboardNumericPropertyChanged(BindableObject bendable, object oldValue, object newValue)
    {
        var Control = (CustomEntry1View)bendable;
        if ((bool)newValue)
        {
            Control.InputEntry.Keyboard = Keyboard.Numeric;
        }
    }

    private void ComboboxCommand_Tapped(object sender, TappedEventArgs e)
    {
        if (IsCombobox)
        {
            Command?.Execute(null);
        }
    }
}