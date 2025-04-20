using Game.Assets.Code.Gameplay.Production.Buildings;
using Game.Assets.Code.Gameplay.ProductionResources;
using System;
using System.Collections.Generic;
using VContainer.Unity;


namespace Game.Assets.Code.Gameplay.Production.Systems
{
    internal sealed class UpdateProductionWidgetsSystem : IStartable, ITickable, IDisposable
    {
        private readonly ProductionResourcesStaticData _staticData;
        private readonly ProductionBuildingContainer _buildingsContainer;
        private readonly BuildingModelsContainer _modelsContainer;

        private LinkedList<ProductionBuildingPresenter> _presenters = new();

        public UpdateProductionWidgetsSystem(
            ProductionResourcesStaticData staticData,
            ProductionBuildingContainer buildingsContainer,
            BuildingModelsContainer modelsContainer)
        {
            _staticData = staticData;
            _buildingsContainer = buildingsContainer;
            _modelsContainer = modelsContainer;
        }

        void IStartable.Start()
        {
            foreach (var build in _buildingsContainer.Buildings)
            {
                var config = build.Config;
                var widget = build.BuildingWidget;
                var data = _staticData.ResourcesData.Get(config.ResourceType);
                var model = _modelsContainer.GetModel(build.UniqId);

                widget.SetupWidget(data.Icon, data.VisualName);

                var presenter = new ProductionBuildingPresenter(build, model);
                _presenters.AddLast(presenter);
            }
        }

        void ITickable.Tick()
        {
            foreach (var presenter in _presenters)
            {
                presenter.UpdateView();
            }
        }

        void IDisposable.Dispose()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Dispose();
            }

            _presenters.Clear();
        }
    }
}
