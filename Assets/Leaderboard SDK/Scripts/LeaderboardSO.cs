using UnityEngine;

[CreateAssetMenu(fileName = "LeaderboardSO", menuName = "Scriptable Objects/LeaderboardSO")]
public class LeaderboardSO : ScriptableObject
{
    public string gameId;
    public string apiUrl;
}
