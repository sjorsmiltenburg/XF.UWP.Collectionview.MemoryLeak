using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MemLeak
{
    public sealed class LibraryPublicationViewModel : BaseViewModel<string>
    {

        private ImageSource _myImage;
        public ImageSource MyImage
        {
            get => _myImage;
            set
            {
                _myImage = value;
                OnPropertyChanged();
            }
        }


        public LibraryPublicationViewModel() : base()
        {

        }

        public override Task Init(string imagesource)
        {
            MyImage = ImageSource.FromUri(new Uri(imagesource));

            return Task.CompletedTask;
        }


    }
}