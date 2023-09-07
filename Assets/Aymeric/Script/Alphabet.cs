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

    private void Start()
    {
        lastMouseX = Input.mousePosition.x;
        UpdateDisplayText();
    }

    private void Update()
    {
        // Handle letter selection with 'A' key.
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A key pressed.");
            // Confirm the current letter.
            letterIndices[selectedIndex] = Mathf.Clamp(letterIndices[selectedIndex], 0, alphabet.Length - 1);

            // Move to the next letter for modification.
            selectedIndex = (selectedIndex + 1) % 3;
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
