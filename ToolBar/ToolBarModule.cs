using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using RockPaperScissors.Common.Resources;

namespace ToolBar
{
    public class ToolBarModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;

        public ToolBarModule(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
        }
        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ToolBar, typeof(ToolBarView));
        }
    }
}
