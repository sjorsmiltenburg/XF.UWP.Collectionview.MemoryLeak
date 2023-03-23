using System.Threading.Tasks;

namespace MemLeak
{
    public abstract class BaseViewModel<TParameter> : BaseViewModel
    {
        protected BaseViewModel()
        {
        }

        public override async Task Init()
        {
            await Init(default);
        }

        public abstract Task Init(TParameter parameter);
    }
}
