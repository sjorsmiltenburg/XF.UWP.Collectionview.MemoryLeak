using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MemLeak
{
    public class MainPageViewModel : BaseViewModel
    {
        public void HandleNrOfBooksPerRowChanged()
        {
            OnPropertyChanged("CollectionViewItemsLayout");
            OnPropertyChanged("CollectionViewItemsLayout2");
            RepaintLibrary();
        }

        private async void RepaintLibrary()
        {
            using (new Busy(this))
            {
                UnloadLibrary();
                await Task.Run(async () =>
                {
                    var lib = await BuildNewLibrary();

                    await Device.InvokeOnMainThreadAsync(() =>
                    {
                        lock (_lock)
                        {
                            foreach (var item in lib)
                            {
                                GroupedPublications.Add(item);
                            }
                        }
                    });
                });
            }
        }

        private async Task<List<GroupedPublicationViewModel>> BuildNewLibrary()
        {
            var groupedPubsNew = new List<GroupedPublicationViewModel>()
            {
                new GroupedPublicationViewModel(PublicationGroupType.One,new List<LibraryPublicationViewModel>()),
                new GroupedPublicationViewModel(PublicationGroupType.Two,new List<LibraryPublicationViewModel>()),
                new GroupedPublicationViewModel(PublicationGroupType.Three,new List<LibraryPublicationViewModel>()),
        };

            foreach (var pubVm in LibraryManager.Instance.AllPublicationViewModels)
            {
                if (groupedPubsNew[0].Count < LibraryBookSizer.Instance.NrOfBooksPerRow)
                {
                    groupedPubsNew[0].Add(pubVm);

                }
                else if (groupedPubsNew[1].Count < LibraryBookSizer.Instance.NrOfBooksPerRow)
                {
                    groupedPubsNew[1].Add(pubVm);
                }
                else
                {
                    groupedPubsNew[2].Add(pubVm);
                }
            }
            return groupedPubsNew;
        }

        public async override Task Init()
        {
            await BuildNewLibrary();
        }

        public GridItemsLayout CollectionViewItemsLayout
        {
            get
            {
                var x = new GridItemsLayout(LibraryBookSizer.Instance.NrOfBooksPerRow, ItemsLayoutOrientation.Vertical);
                x.VerticalItemSpacing = 0;
                x.HorizontalItemSpacing = 0;
                return x;
            }
        }

        private ObservableCollection<GroupedPublicationViewModel> _groupedPublications = new ObservableCollection<GroupedPublicationViewModel>();
        public ObservableCollection<GroupedPublicationViewModel> GroupedPublications
        {
            get
            {
                Debug.WriteLine("2 - Get GroupedPublications");
                return _groupedPublications;
            }
            set
            {
                _groupedPublications = value;
                OnPropertyChanged();
            }
        }

        private object _lock = new object();

        private void UnloadLibrary()
        {
            lock (_lock)
            {
                GroupedPublications.Clear();
            }
        }
    }

    public sealed class GroupedPublicationViewModel : List<LibraryPublicationViewModel>
    {
        public PublicationGroupType GroupType { get; set; }
        public string Name { get; set; }
        public int OrderIndex { get; set; }

        public GroupedPublicationViewModel(PublicationGroupType groupType, List<LibraryPublicationViewModel> publicationViewModels) : base(publicationViewModels)
        {
            GroupType = groupType;

            switch (groupType)
            {
                case PublicationGroupType.One:
                    Name = "MaxOneRow - Group one";
                    OrderIndex = 0;
                    break;
                case PublicationGroupType.Two:
                    Name = "MaxOneRow - Group two";
                    OrderIndex = 1;
                    break;
                case PublicationGroupType.Three:
                    Name = "OverFlow - Group three";
                    OrderIndex = 2;
                    break;
            }
        }
    }

    public enum PublicationGroupType
    {
        One,
        Two,
        Three,
    }
}



