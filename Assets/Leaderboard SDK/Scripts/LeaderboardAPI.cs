using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class LeaderboardAPI : MonoBehaviour
{
    public static LeaderboardAPI Instance;
    public LeaderboardSO config;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayerNameManager.SetName(Random.value.ToString());
    }

    public void SubmitScore(int score)
    {
        StartCoroutine(SendScore(score));
    }

    IEnumerator SendScore(int score)
    {
        string url = config.apiUrl + "/submit-score";

        ScoreData data = new ScoreData
        {
            gameId = config.gameId,
            playerName = PlayerNameManager.GetName(),
            score = score
        };

        string json = JsonUtility.ToJson(data);

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] body = System.Text.Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(body);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Score submitted!");

            ResponseData res = JsonUtility.FromJson<ResponseData>(request.downloadHandler.text);
            Debug.Log("Rank: " + res.rank);
        }
        else
        {
            Debug.LogError(request.error);
        }
    }

    [System.Serializable]
    class ScoreData
    {
        public string gameId;
        public string playerName;
        public int score;
    }

    [System.Serializable]
    class ResponseData
    {
        public int rank;
    }
}