using UnityEngine;

public class Egg : MonoBehaviour
{
    public float respawnTime = 3f; // Tiempo antes de que el huevo reaparezca
    private AudioSource audioSource ;
    // Método para despawn y respawn del huevo

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Collect()
    {
        gameObject.SetActive(false); // Desactivar el huevo
        Invoke("Respawn", respawnTime); // Programar la reaparición
    }

    private void Respawn()
    {
        // Elegir una nueva posición aleatoria para el huevo
        transform.position = new Vector3(Random.Range(-3f, 3f), 0.5f, Random.Range(-3f, 3f));
        gameObject.SetActive(true); // Activar el huevo de nuevo
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Type1Spider"))
        {
            ScoreManager.AddScore(5, collision.gameObject.tag); // Actualizar la puntuación para Type 1 Spider
            Collect(); // Llamar al método Collect() para desactivar el huevo
        }
        else if (collision.gameObject.CompareTag("Type2Spider"))
        {
            ScoreManager.AddScore(10, collision.gameObject.tag); // Actualizar la puntuación para Type 2 Spider
            Collect(); // Llamar al método Collect() para desactivar el huevo
            
            if (audioSource != null)
            {
              audioSource.Play();
            }
        } else if (collision.gameObject.CompareTag("Cube")) {
            ScoreManager.AddScore(15, collision.gameObject.tag); // Actualizar la puntuación para Cube
            Collect(); // Llamar al método Collect() para desactivar el huevo
            if (audioSource != null)
            {
              audioSource.Play();
            }
        }
    }
}
