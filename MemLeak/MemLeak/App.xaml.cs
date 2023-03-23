using Xamarin.Forms;

namespace MemLeak
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            MainPageViewModel vm = (MainPageViewModel)MainPage.BindingContext;
            LibraryBookSizer.Instance.Init(vm);
            vm.Init();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
