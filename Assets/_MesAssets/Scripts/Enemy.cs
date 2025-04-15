using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _vitesseEnnemi = 5f;
    
    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _vitesseEnnemi);
        if (transform.position.y < -6f)
        {
            float randomX = Random.Range(-8.3f, 8.3f);
            transform.position = new Vector2(randomX, 6f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Enleve vie au joueur
            Destroy(gameObject);
        }
        else if (collision.tag == "Laser")
        {
            // Donne des points au joueurs
            // Détruire le laser et l'ennemi
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
