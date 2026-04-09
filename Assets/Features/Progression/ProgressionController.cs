using System;
using Core.Enums;
using Core.Events.Interfaces;
using Features.Progression.Interfaces;
using VContainer;
using VContainer.Unity;

namespace Features.Progression
{
    public class ProgressionController : IStartable, IDisposable
    {
        private readonly IProgressionModel _model;
        private readonly IProgressionView _view;

        private readonly IEventListener<float> _rockDestroyedListener;

        public ProgressionController(IProgressionModel model, IProgressionView view,
            [Key(GameEventType.RockDestroyed)] IEventListener<float> rockDestroyedListener)
        {
            _model = model;
            _view = view;
            _rockDestroyedListener = rockDestroyedListener;
        }

        public void Start()
        {
            _rockDestroyedListener.OnPublished += HandleRockDestroyed;
            
            _view.SetScore(_model.CurrentScore);
        }

        public void Dispose() => _rockDestroyedListener.OnPublished -= HandleRockDestroyed;

        private void HandleRockDestroyed(float score)
        {
            _model.AddScore(score);
            _view.SetScore(_model.CurrentScore);
        }
    }
}