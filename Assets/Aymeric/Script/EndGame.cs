using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Canvas Score;
    private void update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Score.gameObject.SetActive(true);
            gameObject.SetActive(false);

        }
    }
}
