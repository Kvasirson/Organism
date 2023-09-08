using UnityEngine;

public class Title : MonoBehaviour
{
    public float moveDistance = 10f; // La distance de déplacement de l'image.
    public float moveSpeed = 2f; // La vitesse de déplacement.

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
        // Déplacez l'image de manière sinusoïdale entre la position initiale et la position cible.
        float t = (Mathf.Sin(Time.time * moveSpeed) + 1) / 2; // Utilisation de Sin pour créer un mouvement de haut en bas fluide.
        transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
    }
}
