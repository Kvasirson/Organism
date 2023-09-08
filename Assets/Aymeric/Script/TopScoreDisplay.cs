using UnityEngine;
using TMPro;

public class TopScoreDisplayTMP : MonoBehaviour
{
    public TMP_Text topScoreText; // Reference to the TextMeshPro Text component
    public SaveSystem saveSystem; // Reference to the SaveSystem script

    private void Start()
    {
        // Ensure that you have a reference to the TextMeshPro Text component
        if (topScoreText == null)
        {
            Debug.LogError("TMP_Text component for top score not assigned.");
        }

        // Ensure that you have a reference to the SaveSystem script
        if (saveSystem == null)
        {
            Debug.LogError("SaveSystem script not assigned.");
        }

        // Get the high scores from the SaveSystem script
        var highScores = saveSystem.GetHighScores();

        // Check if there are any high scores
        if (highScores.Count > 0)
        {
            //Display all the scores
            string topScoreString = "Top Scores:\n \n";
            foreach (var score in highScores)
            {
                topScoreString += score + "\n";
            }
            topScoreText.text = topScoreString;
        }
        else
        {
            // No high scores to display
            topScoreText.text = "Top Score: N/A";
        }
    }
}
