using UnityEngine;

public class Title : MonoBehaviour
{
    public float moveDistance = 10f; // La distance de d�placement de l'image.
    public float moveSpeed = 2f; // La vitesse de d�placement.

    private Vector3 initialPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        // Enregistrez la position initiale et la position cible.
        initialPosition = transform.position;
        targetPosition = transform.position - Vector3.up * moveDistance;
    }

    private void Update()
    {
        // D�placez l'image de mani�re sinuso�dale entre la position initiale et la position cible.
        float t = (Mathf.Sin(Time.time * moveSpeed) + 1) / 2; // Utilisation de Sin pour cr�er un mouvement de haut en bas fluide.
        transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
    }
}
