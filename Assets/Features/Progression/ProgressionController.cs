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

        private readonly IEventListener _gameOverListener;
        private readonly IEventListener<float> _rockDestroyedListener;

        public ProgressionController(IProgressionModel model, IProgressionView view,
            [Key(GameEventType.GameOver)] IEventListener gameOverListener,
            [Key(GameEventType.RockDestroyed)] IEventListener<float> rockDestroyedListener)
        {
            _model = model;
            _view = view;
            _gameOverListener = gameOverListener;
            _rockDestroyedListener = rockDestroyedListener;
        }

        //===== Lifecycle =====

        public void Start()
        {
            _gameOverListener.OnPublished += HandleGameOver;
            _rockDestroyedListener.OnPublished += HandleRockDestroyed;

            _view.SetScore(_model.CurrentScore);
            _view.SetHighScore(_model.HighScore);
        }

        public void Dispose()
        {
            _gameOverListener.OnPublished -= HandleGameOver;
            _rockDestroyedListener.OnPublished -= HandleRockDestroyed;
        }

        //===== Event Handlers =====

        private void HandleGameOver() => _model.UpdateHighScore();

        private void HandleRockDestroyed(float score)
        {
            _model.AddScore(score);
            _view.SetScore(_model.CurrentScore);
            _view.SetHighScore(_model.HighScore);
        }
    }
}