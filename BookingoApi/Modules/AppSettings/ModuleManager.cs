using Ninject;
using System.Reflection;

namespace BookingoApi.Modules.AppSettings
{
    public static class ModuleManager
    {
        private static StandardKernel _kernel;

        public static StandardKernel Kernel
        {
            get
            {
                if (_kernel == null)
                {
                    Load();
                }
                return _kernel;
            }
            set
            {
                _kernel = value;
            }
        }

        public static void Load()
        {
            Kernel = new StandardKernel();
            Kernel.Load(Assembly.GetExecutingAssembly());
        }
    }
}