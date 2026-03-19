using UnityEngine;
using System.Runtime.InteropServices;

public class WebGLBridge : MonoBehaviour
{
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void OpenLeaderboard(string gameId);
#endif

    public void OpenLeaderboardPage(string gameId)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        OpenLeaderboard(gameId);
#else
        Debug.Log("Open leaderboard: " + gameId);
#endif
    }
}