using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    //Display the actual score 
    public TMPro.TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //Ensure that you have a reference to the TextMeshPro Text component
        if (scoreText == null)
        {
            Debug.LogError("TMP_Text component for score not assigned.");
        }
        
        //Get the score from the SaveSystem script
        var score = GameManager.Instance.Score;

        //Display the score
        scoreText.text = "Score: " + score;
    }

}
