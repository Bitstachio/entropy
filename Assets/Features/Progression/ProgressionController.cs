using Core.Enums;
using Core.Events.Interfaces;
using Features.Progression.Interfaces;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.Progression
{
    public class ProgressionController : IStartable
    {
        private readonly IEventListener<float> _rockDestroyedListener;

        private readonly IProgressionModel _model;

        public ProgressionController(
            [Key(GameEventType.RockDestroyed)] IEventListener<float> rockDestroyedListener,
            IProgressionModel model)
        {
            _rockDestroyedListener = rockDestroyedListener;
            _model = model;
        }

        public void Start()
        {
            Debug.Log("Adding score."); // TODO: Remove
            _rockDestroyedListener.OnPublished += MyHandler;
        }
        
        // TODO: Remove
        private void MyHandler(float score)
        {
            _model.AddScore(score);
            Debug.Log($"Score: {score}");
        }
    }
}