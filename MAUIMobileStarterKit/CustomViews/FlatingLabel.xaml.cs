using System.Runtime.CompilerServices;

namespace MAUIMobileStarterKit.CustomViews;

public partial class FlatingLabel : ContentView
{
    int _placeholderFontSize = 18;
    int _titleFontSize = 14;
    int _topMargin = -32;

    public event EventHandler Completed;

    public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(string), string.Empty, BindingMode.TwoWay, null, HandleBindingPropertyChangedDelegate);

    public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(string), string.Empty, BindingMode.TwoWay, null);
    public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create(nameof(ReturnType), typeof(ReturnType), typeof(FlatingLabel), ReturnType.Default);
    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create("IsPassword", typeof(bool), typeof(FlatingLabel), default(bool));
    public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create("MaxLength", typeof(int), typeof(FlatingLabel), 100);
    public static readonly BindableProperty KeyboardProperty = BindableProperty.Create("Keyboard", typeof(Keyboard), typeof(FlatingLabel), Keyboard.Default, coerceValue: (o, v) => (Keyboard)v ?? Keyboard.Default);

    static async void HandleBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
    {
        var control = bindable as FlatingLabel;
        if (!control.EntryField.IsFocused)
        {
            if (!string.IsNullOrEmpty((string)newValue))
            {
                await control.TransitionToTitle(false);
            }
            else
            {
                await control.TransitionToPlaceholder(false);
            }
        }
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public ReturnType ReturnType
    {
        get => (ReturnType)GetValue(ReturnTypeProperty);
        set => SetValue(ReturnTypeProperty, value);
    }

    public bool IsPassword
    {
        get { return (bool)GetValue(IsPasswordProperty); }
        set { SetValue(IsPasswordProperty, value); }
    }

    public Keyboard Keyboard
    {
        get { return (Keyboard)GetValue(KeyboardProperty); }
        set { SetValue(KeyboardProperty, value); }
    }

    public int MaxLength
    {
        get { return (int)GetValue(MaxLengthProperty); }
        set { SetValue(MaxLengthProperty, value); }
    }

    public FlatingLabel()
    {
        InitializeComponent();
        LabelTitle.TranslationX = 10;
        LabelTitle.FontSize = _placeholderFontSize;
    }

    public new void Focus()
    {
        if (IsEnabled)
        {
            EntryField.Focus();
        }
    }

    async void Handle_Focused(object sender, FocusEventArgs e)
    {
        if (string.IsNullOrEmpty(Text))
        {
            await TransitionToTitle(true);
        }
    }

    async void Handle_Unfocused(object sender, FocusEventArgs e)
    {
        if (string.IsNullOrEmpty(Text))
        {
            await TransitionToPlaceholder(true);
        }
    }

    async Task TransitionToTitle(bool animated)
    {
        if (animated)
        {
            var t1 = LabelTitle.TranslateTo(0, _topMargin, 100);
            var t2 = SizeTo(_titleFontSize);
            await Task.WhenAll(t1, t2);
        }
        else
        {
            LabelTitle.TranslationX = 0;
            LabelTitle.TranslationY = -20;
            LabelTitle.FontSize = 14;
        }
    }

    async Task TransitionToPlaceholder(bool animated)
    {
        if (animated)
        {
            var t1 = LabelTitle.TranslateTo(10, 0, 100);
            var t2 = SizeTo(_placeholderFontSize);
            await Task.WhenAll(t1, t2);
        }
        else
        {
            LabelTitle.TranslationX = 10;
            LabelTitle.TranslationY = 0;
            LabelTitle.FontSize = _placeholderFontSize;
        }
    }

    Task SizeTo(int fontSize)
    {
        var taskCompletionSource = new TaskCompletionSource<bool>();

        // setup information for animation
        Action<double> callback = input => { LabelTitle.FontSize = input; };
        double startingHeight = LabelTitle.FontSize;
        double endingHeight = fontSize;
        uint rate = 5;
        uint length = 100;
        Easing easing = Easing.Linear;

        // now start animation with all the setup information
        LabelTitle.Animate("invis", callback, startingHeight, endingHeight, rate, length, easing, (v, c) => taskCompletionSource.SetResult(c));

        return taskCompletionSource.Task;
    }

    void Handle_Completed(object sender, EventArgs e)
    {
        Completed?.Invoke(this, e);
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == nameof(IsEnabled))
        {
            EntryField.IsEnabled = IsEnabled;
        }
    }
}