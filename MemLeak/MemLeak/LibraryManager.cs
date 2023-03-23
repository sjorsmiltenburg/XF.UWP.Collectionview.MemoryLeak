using System.Collections.Generic;

namespace MemLeak
{
    internal class LibraryManager
    {
        private static LibraryManager _instance;
        public static LibraryManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LibraryManager();
                }
                return _instance;
            }
        }

        public LibraryManager()
        {
        }

        private List<LibraryPublicationViewModel> BuildPubVms()
        {
            List<LibraryPublicationViewModel> result = new List<LibraryPublicationViewModel>();
            List<string> sourceUrls = new List<string>();
            for (int i = 0; i < 150; i++)
            {
                sourceUrls.Add($@"https://loremflickr.com/200/271/lock=" + i);
            }

            foreach (var sourceUrl in sourceUrls)
            {
                LibraryPublicationViewModel viewModel = new LibraryPublicationViewModel();
                viewModel.Init(sourceUrl);
                result.Add(viewModel);
            }
            return result;
        }

        public List<LibraryPublicationViewModel> AllPublicationViewModels
        {
            get
            {

                return BuildPubVms();
            }
        }
    }
}