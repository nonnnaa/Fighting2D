public enum E_CharactorState
{
    Idle,
    Walk,
    Run,
    Jump,
    Dash,
    Climb,
    Die,
    WallSlide,
    Attack,
}
public enum GameState
{
    StartGame,
    LoadingGame,
    EndGame
}

public static class PlayerString
{
    public static string yVelocity = "yVelocity";
    public static string attackId = "AttackId";
}

