namespace Features.Menu.GameOver
{
    public sealed class GameOverMenuModel : IGameOverMenuModel
    {
        public int SceneLoadDelay => _config.SceneLoadDelay;
        
        private readonly GameOverMenuConfig _config;
        
        public GameOverMenuModel(GameOverMenuConfig config) => _config = config;
    }
}