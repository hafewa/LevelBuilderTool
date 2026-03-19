using UnityEngine;

public static class PlayerNameManager
{
    const string KEY = "playerName_Leaderboard";

    public static void SetName(string name)
    {
        PlayerPrefs.SetString(KEY, name);
    }

    public static string GetName()
    {
        return PlayerPrefs.GetString(KEY, "Guest");
    }

    public static bool HasName()
    {
        return PlayerPrefs.HasKey(KEY);
    }
}