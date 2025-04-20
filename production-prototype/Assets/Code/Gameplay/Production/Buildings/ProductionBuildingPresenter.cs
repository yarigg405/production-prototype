using Game.Assets.Code.Gameplay.Ui;
using System;


namespace Game.Assets.Code.Gameplay.Production.Buildings
{
    internal sealed class ProductionBuildingPresenter : IDisposable
    {
        private readonly ProductionBuildingModel _model;
        private readonly ProductionBuilding _view;
        private readonly ProductionBuildingConfig _config;
        private readonly ProductionBuildingWidget _widget;

        public ProductionBuildingPresenter(ProductionBuilding view, ProductionBuildingModel model)
        {
            _view = view;
            _model = model;

            _config = _view.Config;
            _widget = _view.BuildingWidget;

            _model.OnResourcesProducted += OnResourceProducedHandler;
            _model.CurrentResourcesCount.OnChange += OnResourcesChangedHandler;

            OnResourcesChangedHandler(_model.CurrentResourcesCount);
            _widget.UpdateProductionPercent(_model.CurrentProductionTimer / _config.ProductionTickTime);
        }

        internal void UpdateView()
        {
            _widget.UpdateProductionPercent(_model.CurrentProductionTimer / _config.ProductionTickTime);
        }

        private void OnResourceProducedHandler()
        {
            _widget.AnimateResourceProducted();
        }

        private void OnResourcesChangedHandler(int count)
        {
            _widget.UpdateCount(count);
        }

        public void Dispose()
        {
            _model.OnResourcesProducted -= OnResourceProducedHandler;
            _model.CurrentResourcesCount.OnChange -= OnResourcesChangedHandler;
        }
    }
}
