using System;
using Core.Events.Channels;
using Core.Events.Interfaces;
using Core.Session;
using VContainer.Unity;

namespace Features.Progression
{
    public sealed class ProgressionController : IStartable, IDisposable
    {
        private readonly IEventListener<GameOverEvent> _gameOverListener;
        private readonly IEventListener<RockDestroyedEvent> _rockDestroyedListener;

        private readonly IProgressionModel _model;
        private readonly IProgressionView _view;

        private readonly GameSessionData _session;

        public ProgressionController(
            IEventListener<GameOverEvent> gameOverListener,
            IEventListener<RockDestroyedEvent> rockDestroyedListener,
            IProgressionModel model,
            IProgressionView view,
            GameSessionData session)
        {
            _gameOverListener = gameOverListener;
            _rockDestroyedListener = rockDestroyedListener;
            _model = model;
            _view = view;
            _session = session;
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

        private void HandleGameOver(GameOverEvent @event)
        {
            _model.UpdateHighScore();

            _session.Score = (int)(_model.CurrentScore + 0.5f);
            _session.HighScore = (int)(_model.HighScore + 0.5f);
        }

        private void HandleRockDestroyed(RockDestroyedEvent @event)
        {
            // TODO: Consider cleaning up the score roundings
            var prevHigh = (int)(_model.HighScore + 0.5f);

            _model.AddScore(@event.Durability);
            _view.SetScore(_model.CurrentScore);
            _view.SetHighScore(_model.HighScore);

            if ((int)(_model.HighScore + 0.5f) > prevHigh) _session.IsNewHighScore = true;
        }
    }
}