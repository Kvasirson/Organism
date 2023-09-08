using UnityEngine;
using TMPro;


public class ArcadeLetterSelection : MonoBehaviour
{
    public TMP_Text displayText; // Reference to the TextMeshProUGUI component.
    public float scrollSpeed = 1.0f; // Adjust the scrolling speed.
    public int letterChangeIncrement = 5; // The increment to change letters.

    private string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // The alphabet.
    private int[] letterIndices = new int[3]; // Store the indices for each letter.
    private int selectedIndex = 0; // Index of the currently selected letter.
    private float lastMouseX; // Store the last mouse X position.
    private int countletter = 0; // Count the number of letter selected

    private SaveSystem saveSystem; // Reference to the SaveSystem script.
    private GameManager gameManager; // Reference to the GameManager script.


    private void Start()
    {
        lastMouseX = Input.mousePosition.x;
        UpdateDisplayText();
        saveSystem = FindObjectOfType<SaveSystem>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {

        if (countletter < 3 && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("A key pressed.");
            // Confirm the current letter.
            letterIndices[selectedIndex] = Mathf.Clamp(letterIndices[selectedIndex], 0, alphabet.Length - 1);
            countletter++;

            // Move to the next letter for modification.
            selectedIndex = (selectedIndex + 1) % 3;
            if (countletter == 3 && gameManager != null)
            {
                string playerName = displayText.text;

                saveSystem.AddHighScore(playerName, gameManager.Score);

                Debug.Log("HighScore updated A key");
                gameObject.SetActive(false);
            }
            
            else if (countletter == 3 && gameManager == null)
            {
                string playerName = displayText.text;

                saveSystem.AddHighScore(playerName, 0);

                Debug.Log("HighScore updated A key");
                gameObject.SetActive(false);
            }
            
        }

        // Get the current mouse X position.
        float currentMouseX = Input.mousePosition.x;

        // Calculate the change in mouse X position.
        float mouseXChange = currentMouseX - lastMouseX;

        // Update the current index based on the change.
        letterIndices[selectedIndex] += Mathf.RoundToInt(mouseXChange * scrollSpeed);

        // Ensure the index stays within bounds.
        letterIndices[selectedIndex] = Mathf.Clamp(letterIndices[selectedIndex], 0, alphabet.Length - 1);

        // Update the displayed text with the selected 3 letters.
        UpdateDisplayText();

        // Update the last mouse X position.
        lastMouseX = currentMouseX;
    }

    private void UpdateDisplayText()
    {
        // Update the displayed text with the selected 3 letters.
        string selectedLetters = string.Empty;
        for (int i = 0; i < 3; i++)
        {
            selectedLetters += alphabet[letterIndices[i]];
        }
        displayText.text = selectedLetters;
    }

}
