using UnityEngine;
using System.Collections.Generic;

public class SaveSystem : MonoBehaviour
{
    [System.Serializable]
    public class ScoreEntry
    {
        public string playerName;
        public int score;
    }

    private List<ScoreEntry> highScores = new List<ScoreEntry>();

    private void Start()
    {

        LoadHighScores();
    }

    public void AddHighScore(string playerName, int score)
    {

        ScoreEntry newEntry = new ScoreEntry
        {
            playerName = playerName,
            score = score
        };


        highScores.Add(newEntry);

        highScores.Sort((x, y) => y.score.CompareTo(x.score));


        if (highScores.Count > 10)
        {
            highScores.RemoveAt(highScores.Count - 1);
        }


        SaveHighScores();
    }

    private void SaveHighScores()
    {

        string json = JsonUtility.ToJson(highScores);


        PlayerPrefs.SetString("HighScores", json);
        PlayerPrefs.Save();
        //debug.Log all the high scores
        foreach (ScoreEntry scoreEntry in highScores)
        {
            Debug.Log(scoreEntry.playerName + " : " + scoreEntry.score);
        }

    }

    private void LoadHighScores()
    {

        string json = PlayerPrefs.GetString("HighScores");


        highScores = JsonUtility.FromJson<List<ScoreEntry>>(json);


        if (highScores == null)
        {
            highScores = new List<ScoreEntry>();
        }
    }

    public List<ScoreEntry> GetHighScores()
    {
        return highScores;
    }

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
