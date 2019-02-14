public interface IGameModeBehavior
{
    void Init(HogerSpawner objectSpawner);
    bool IsGameOver();
    int GetScore();
    int GetLives();
    void HandleCut(string type);
    void HandleMiss(string type);
    void Update();
    float GetDelay();
    string GetGameState();
}