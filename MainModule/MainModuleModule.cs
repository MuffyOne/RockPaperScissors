using MainModule.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using RockPaperScissors.Common.Resources;

namespace MainModule
{
    public class MainModuleModule : IModule
    {
        #region fields
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;
        #endregion

        public MainModuleModule(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
        }
        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(NewGameView));
        }
    }
}
