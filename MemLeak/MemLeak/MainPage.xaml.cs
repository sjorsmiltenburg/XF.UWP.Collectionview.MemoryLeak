using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MemLeak
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.SizeChanged += LibraryView_SizeChanged;
        }

        private void LibraryView_SizeChanged(object sender, EventArgs e)
        {
            UpdateLayout();
        }


        private double _bookLayoutConfiguredForHeight;
        private double _bookLayoutConfiguredForWidth;

        private void UpdateLayout()
        {
            Debug.WriteLine($"LibraryView.Xaml.cs LibraryView_SizeChanged -> UpdateLayout w{Width} h{Height}");


            var minHorizontalMargin = 20d; //10 left and 10 right;

            //1) determine the safe area of the screen where we want to position
            var effectiveScreenWidth = Width;
            var effectiveScreenHeight = Height;

            //in LibraryView.xaml we have defined ios:Page.UseSafeArea=True
            //this creates an extra padding making the effective space for the controls smaller.                
            if (Device.RuntimePlatform == Device.iOS)
            {
                var safeInsets = On<iOS>().SafeAreaInsets();
                effectiveScreenWidth -= safeInsets.HorizontalThickness;
                effectiveScreenHeight -= safeInsets.VerticalThickness;
                Debug.WriteLine($"IOS SafeArea VerticalThickness:{safeInsets.VerticalThickness}");
            }
            effectiveScreenWidth -= minHorizontalMargin; //preview book cover should stay 10 pixels from the side of the screen
            //Debug.WriteLine($"1) ScreenWidth:{Width} ScreenHeight:{Height}");
            //Debug.WriteLine($"1) ScreenWidth minus SafeInset:{effectiveScreenWidth} ScreenHeight minus SafeInset: {effectiveScreenHeight}");

            if (effectiveScreenWidth != _bookLayoutConfiguredForWidth || effectiveScreenHeight != _bookLayoutConfiguredForHeight)
            {
                //todo if I remember correctly this if clause is inserted to reduce repaints in Windows when you drag-to-resize, but maybe it is no longer needed
                //it became a little confusing when i found out that the safeinsets are not yet populated when the onappearing event get's triggered https://stackoverflow.com/questions/65519177/safeareainsets-are-0-when-view-sizechanged-initially-gets-triggered
                //that's why we now use the calculated effectivewidth to see if a redraw is neccesary

                //Debug.WriteLine("Calculate PreviewSize: try and fit the cover on 75% of the height");
                var targetPreviewHeight = effectiveScreenHeight * 0.75;
                var targetPreviewWidth = 548d / 738d * targetPreviewHeight;
                //Debug.WriteLine($"Calculate PreviewSize: TargetPreviewWidth:{targetPreviewWidth} TargetPreviewHeight:{targetPreviewHeight}");

                var actualCoverHeight = targetPreviewHeight;
                if (effectiveScreenWidth < targetPreviewWidth)
                {
                    //Debug.WriteLine($"Calculate PreviewSize: The screen is too narrow to show the cover on 75% of the screenheight keeping the image it's height/width ratio, use the max screen width");
                    actualCoverHeight = effectiveScreenWidth / (548d / 738d);
                }
                var actualCoverWidth = 548d / 738d * actualCoverHeight;
                //Debug.WriteLine($"Calculate PreviewSize: ActualCoverWidth:{actualCoverWidth} ActualCoverHeight:{actualCoverHeight}");

                //3) center the cover in the screen
                var bookCoverTopMargin = (effectiveScreenHeight - actualCoverHeight) / 2;
                //Debug.WriteLine($"Calculate PreviewSize: BookCoverTopMargin:{bookCoverTopMargin}");

                //4) language selection height 15%
                var languageHeight = effectiveScreenHeight * .15d;
                // position language so 25% covers the book
                var languageTopMargin = bookCoverTopMargin - (languageHeight * .75d);
                var languageBottomMargin = effectiveScreenHeight - languageHeight - languageTopMargin;
                //Debug.WriteLine($"Calculate PreviewSize: LanguageTopMargin:{languageTopMargin} LanguageBottomMargin:{languageBottomMargin} LanguageHeight:{languageHeight}");

                //5) narration selection height 20%
                var narrationHeight = effectiveScreenHeight * .2d;
                //position narration so 50% covers the book
                var narrationTopMargin = bookCoverTopMargin + actualCoverHeight - (narrationHeight / 2);
                var narrationBottomMargin = effectiveScreenHeight - narrationHeight - narrationTopMargin;
                //Debug.WriteLine($"Calculate PreviewSize: NarrationTopMargin:{narrationTopMargin} NarrationBottomMargin:{narrationBottomMargin} NarrationHeight:{narrationHeight}");


                _bookLayoutConfiguredForHeight = effectiveScreenHeight;
                _bookLayoutConfiguredForWidth = effectiveScreenWidth;


                //library book covers
                if (BindingContext is MainPageViewModel vm)
                {
                    var horizontalMargin = 20d; //10 left and 10 right
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        var safeInsets = On<iOS>().SafeAreaInsets();
                        horizontalMargin += safeInsets.HorizontalThickness;
                    }

                    LibraryBookSizer.Instance.WindowSize = $"Window: h:{Height}*w:{Width}";
                    LibraryBookSizer.Instance.WindowSizeChanged(Width, Height, horizontalMargin);
                }
            }
        }
    }
}
