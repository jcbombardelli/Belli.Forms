using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Belli.Forms.Control.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryTitled : ContentView
    {

        #region Bindable Properties

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string),
                typeof(EntryTitled), string.Empty);

        public static readonly BindableProperty TitleColorProperty =
            BindableProperty.Create(nameof(TitleColor), typeof(Color),
                typeof(EntryTitled), Extensions.Colors.Primary);

        public static readonly BindableProperty MessageProperty =
            BindableProperty.Create(nameof(Message), typeof(string),
        typeof(EntryTitled), string.Empty);

        public static readonly BindableProperty MessageColorProperty =
            BindableProperty.Create(nameof(MessageColor), typeof(Color),
                typeof(EntryTitled), Color.Accent);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string),
                typeof(EntryTitled), string.Empty);

        public static readonly BindableProperty IconStartProperty =
            BindableProperty.Create(nameof(IconStart), typeof(ImageSource),
                typeof(EntryTitled), null);

        public static readonly BindableProperty IconEndProperty =
            BindableProperty.Create(nameof(IconEnd), typeof(ImageSource),
                typeof(EntryTitled), null);

        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(Keyboard), typeof(Keyboard),
                typeof(EntryTitled), Keyboard.Default);

        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create(nameof(IsPassword), typeof(bool),
                typeof(EntryTitled), false);

        public static readonly BindableProperty IconStartColorProperty =
            BindableProperty.Create(nameof(IconStartColor), typeof(Color),
                typeof(EntryTitled), Color.Accent);

        public static readonly BindableProperty IconEndColorProperty =
            BindableProperty.Create(nameof(IconEndColor), typeof(Color),
                typeof(EntryTitled), Color.Accent);

        public static readonly BindableProperty HorizontalTextAlignmentProperty =
            BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment),
                typeof(EntryTitled), TextAlignment.Start);


        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double),
                typeof(EntryTitled), -1d, propertyChanged: FontSizeOnPropertyChganged);

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand),
                typeof(EntryTitled), null);


        #endregion

        #region Bindable Getters and Setters

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public Color TitleColor
        {
            get { return (Color)GetValue(TitleColorProperty); }
            set { SetValue(TitleColorProperty, value); }
        }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public Color MessageColor
        {
            get { return (Color)GetValue(MessageColorProperty); }
            set { SetValue(MessageColorProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public ImageSource IconStart
        {
            get { return (ImageSource)GetValue(IconStartProperty); }
            set { SetValue(IconStartProperty, value); }
        }

        public ImageSource IconEnd
        {
            get { return (ImageSource)GetValue(IconEndProperty); }
            set { SetValue(IconEndProperty, value); }
        }

        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        public Color IconStartColor
        {
            get { return (Color)GetValue(IconStartColorProperty); }
            set { SetValue(IconStartColorProperty, value); }
        }

        public Color IconEndColor
        {
            get { return (Color)GetValue(IconEndColorProperty); }
            set { SetValue(IconEndColorProperty, value); }
        }

        public IList<Behavior> ListBehaviors
        {
            get { return (IList<Behavior>)GetValue(BehaviorsProperty); }
            set { SetValue(BehaviorsProperty, value); }
        }

        public TextAlignment HorizontalTextAlignment
        {
            get { return (TextAlignment)GetValue(HorizontalTextAlignmentProperty); }
            set { SetValue(HorizontalTextAlignmentProperty, value); }
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }



        #endregion

        #region Getters and Setters

        public Image ImgStart { get { return imgStart; } }
        public Image ImgEnd { get { return imgEnd; } }
        public Entry EntryValue { get { return entryValue; } }
        public StackLayout gEntryCustom { get { return entryTitled; } }
        public Label LblTitle { get { return lblTitle; } }
        public Label LblRequired { get { return lblRequired; } }

        #endregion

        #region Constructor

        public EntryTitled()
        {
            InitializeComponent();
            entryTitled.BindingContext = this;

            TapGestureRecognizer tapStartImage = new TapGestureRecognizer();
            TapGestureRecognizer tapEndImage = new TapGestureRecognizer();
            TapGestureRecognizer tapEntryValue = new TapGestureRecognizer();

            tapStartImage.Tapped += TapStartImage_Tapped;
            tapEndImage.Tapped += TapEndImage_Tapped;
            // tapEntryValue.Tapped += TapEntryValue_Tapped;

            imgStart.GestureRecognizers.Add(tapStartImage);
            imgEnd.GestureRecognizers.Add(tapEndImage);
            //entryValue.GestureRecognizers.Add(tapEntryValue);

            imgStart.HeightRequest = imgStart.WidthRequest = (imgStart.Source != null ? 25 : 0);
            imgEnd.HeightRequest = imgEnd.WidthRequest = (imgEnd.Source != null ? 25 : 0);



            entryValue.Focused += EntryTitled_Focused;

        }

        private void EntryTitled_Focused(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;

            if (Command != null)
            {
                entry.Focused -= EntryTitled_Focused;
                entry.Unfocus();
                Command.Execute(null);
                entry.Focused += EntryTitled_Focused;
            }

        }

        ~EntryTitled()
        {

        }

        #endregion

        #region Events
        public event EventHandler<EventArgs> StartImageClick;
        public event EventHandler<EventArgs> EndImageClick;
        public event EventHandler<EventArgs> EntryValueClick;

        private void EntryValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblTitle.FadeTo((!string.IsNullOrEmpty(Text) ? 1 : 0), 250);
            lblRequired.FadeTo((!string.IsNullOrEmpty(Text) ? 1 : 0), 250);
        }

        private void TapStartImage_Tapped(object sender, EventArgs e)
        {
            StartImageClick?.Invoke(sender, e);
        }

        private void TapEndImage_Tapped(object sender, EventArgs e)
        {
            EndImageClick?.Invoke(sender, e);
        }

        private void TapEntryValue_Tapped(object sender, FocusEventArgs e)
        {
            EntryValueClick?.Invoke(sender, e);
        }

        #endregion


        private static void FontSizeOnPropertyChganged(BindableObject bindable, object oldValue, object newValue)
        {
            EntryTitled et = bindable as EntryTitled;

            et.EntryValue.FontSize = (double)newValue;
        }


    }
}