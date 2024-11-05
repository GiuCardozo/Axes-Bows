using System;

public static class GameEvents
{
    public static event Action OnPlayerDeath;

    public static void PlayerDied()
    {
        OnPlayerDeath?.Invoke();
    }
}

