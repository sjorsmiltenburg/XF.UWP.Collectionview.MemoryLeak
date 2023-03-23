using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace MemLeak
{
    public sealed class LibraryBookSizer : NotifyPropertyBase
    {
        private MainPageViewModel _libraryViewModel;

        public void Init(MainPageViewModel libraryViewModel)
        {
            _libraryViewModel = libraryViewModel;
        }

        private double _bookWidth = 100;
        public double BookWidth
        {
            get => _bookWidth;
            set
            {
                _bookWidth = value;
                OnPropertyChanged();
            }
        }

        private double _bookHeight;
        public double BookHeight
        {
            get => _bookHeight;
            set
            {
                _bookHeight = value;
                OnPropertyChanged();
            }
        }

        private double _bookHasNarratorImageWidth;
        public double BookHasNarratorImageWidth
        {
            get { return _bookHasNarratorImageWidth; }
            set
            {
                _bookHasNarratorImageWidth = value;
                OnPropertyChanged();
            }
        }

        private Thickness _bookHasNarratorImageMargin;
        public Thickness BookHasNarratorImageMargin
        {
            get { return _bookHasNarratorImageMargin; }
            set
            {
                _bookHasNarratorImageMargin = value;
                OnPropertyChanged();
            }
        }

        private Thickness _previewLabelMargin;
        public Thickness PreviewLabelMargin
        {
            get => _previewLabelMargin; set
            {
                _previewLabelMargin = value;
                OnPropertyChanged();
            }
        }

        private static object myLock = new object();

        private static LibraryBookSizer _instance;
        public static LibraryBookSizer Instance
        {
            get
            {
                lock (myLock)
                {
                    if (_instance == null)
                    {
                        _instance = new LibraryBookSizer();
                    }

                    return _instance;
                }
            }
        }

        private string _windowSize;
        public string WindowSize
        {
            get => _windowSize;
            set
            {
                _windowSize = value;
                OnPropertyChanged();
            }
        }

        private string _screenSize;
        public string ScreenSize
        {
            get => _screenSize;
            set
            {
                _screenSize = value;
                OnPropertyChanged();
            }
        }

        private int _nrOfBooksPerRow = 1;
        public int NrOfBooksPerRow
        {
            get => _nrOfBooksPerRow;
            set
            {
                bool changed = _nrOfBooksPerRow != value;
                _nrOfBooksPerRow = value;
                if (changed)
                {
                    OnPropertyChanged();
                    if (_libraryViewModel != null)
                    {
                        _libraryViewModel.HandleNrOfBooksPerRowChanged();
                    }
                }
            }
        }

        private double _lastCalculatedWindowWidth;
        private double _lastCalculatedWindowHeight;


        public void WindowSizeChanged(double windowWidth, double windowHeight, double horizontalPaddingParent)
        {
            if (windowWidth < 1 || windowHeight < 1)
            {
                //encountered a case where these values were -1
                return;
            }

            if (Math.Abs(windowWidth - _lastCalculatedWindowWidth) < 1 && Math.Abs(windowHeight - _lastCalculatedWindowHeight) < 1)
            {
                //this is heavy operation, let's not do it unnecessarily
                //event gets triggered a lot when resizing a window on windows
                Debug.WriteLine("Calculate library book size: skipping recalculating booksize because sizechanged is too small");//todo do we come here?
                return;
            }
            _lastCalculatedWindowHeight = windowHeight;
            _lastCalculatedWindowWidth = windowWidth;

            var bookSizeResult = CalculateBookSize(windowWidth, windowHeight, horizontalPaddingParent);

            NrOfBooksPerRow = bookSizeResult.NrOfBooksPerRow;

            BookWidth = bookSizeResult.BookWidth;
            BookHeight = bookSizeResult.BookHeight;

            BookHasNarratorImageWidth = BookWidth / 5;
            BookHasNarratorImageMargin = new Thickness(BookHasNarratorImageWidth / 3, BookHasNarratorImageWidth / 10);

            var labelHeight = 25; //25=uwp
            PreviewLabelMargin = new Thickness(0, BookHasNarratorImageMargin.Bottom + ((BookHasNarratorImageWidth - labelHeight) / 2));
            //Debug.WriteLine($"Calculated library book size: BookWidth={BookWidth}, BookHeight={BookHeight}, NrOfBooksPerRow={NrOfBooksPerRow}");
        }

        private BookSizeResult CalculateBookSize(double windowWidth, double windowHeight, double horizontalPaddingParent)
        {
            int minNrOfBooks = 3;
            double targetBookWidth = 200d;
            int horizontalBookPadding = 5; //(defined as a 2,5 margin on the publicationview grid)
            int nrOfBooksPerRow;
            double bookWidth;
            double bookHeight;

            var nrOfBooksPerRow_double = (windowWidth - horizontalPaddingParent) / (targetBookWidth + horizontalBookPadding);
            if (nrOfBooksPerRow_double < minNrOfBooks)//show a minimum nr of books in a row, if it does not fit scale the books down
            {
                nrOfBooksPerRow = 3;
            }
            else
            {
                //if < x.5 books fit -> round down and resize books to fit x in a row
                //if >= x.5 books fit -> round up and resize books to fit x+1 in a row
                nrOfBooksPerRow = (int)Math.Round(nrOfBooksPerRow_double);
            }
            bookWidth = Math.Floor((windowWidth - horizontalPaddingParent - (horizontalBookPadding * nrOfBooksPerRow)) / nrOfBooksPerRow);
            bookHeight = Math.Floor(707d / 521d * bookWidth); //keep aspect ratio of original image

            if (windowHeight / bookHeight < 2)
            {
                //this is probably a narrow screen in landscape mode (phone)
                //we need to make the books even smaller, time to recalculate
                bookHeight = windowHeight / 2;
                targetBookWidth = bookHeight / (707d / 521d);
                nrOfBooksPerRow_double = (windowWidth - horizontalPaddingParent) / (targetBookWidth + horizontalBookPadding);
                nrOfBooksPerRow = (int)Math.Ceiling(nrOfBooksPerRow_double); //here we always round up because rounding down would mean bigger books

                bookWidth = Math.Floor((windowWidth - horizontalPaddingParent - (horizontalBookPadding * nrOfBooksPerRow)) / nrOfBooksPerRow);
                bookHeight = Math.Floor(707d / 521d * bookWidth); //keep aspect ratio of original image
            }

            return new BookSizeResult(bookWidth, bookHeight, nrOfBooksPerRow);
        }

        public sealed class BookSizeResult
        {
            public double BookWidth { get; set; }
            public double BookHeight { get; set; }
            public int NrOfBooksPerRow { get; set; }

            public BookSizeResult(double bookWidth, double bookHeight, int nrOfBooksPerRow)
            {
                BookWidth = bookWidth;
                BookHeight = bookHeight;
                NrOfBooksPerRow = nrOfBooksPerRow;
            }
        }
    }
}
