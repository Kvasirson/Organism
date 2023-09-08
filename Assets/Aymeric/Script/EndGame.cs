using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Canvas Score;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Q");
            Score.gameObject.SetActive(true);
            gameObject.SetActive(false);

        }
    }
}
