using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _vitesseEnnemi = 5f;
    [SerializeField] private int _points = 100;
    [SerializeField] private GameObject _explosionPrefab = default(GameObject);
    
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
            collision.gameObject.GetComponent<Player>().DommageJoueur();
        }
        else if (collision.tag == "Laser")
        {
            GameManager.Instance.AugmenterPointage(_points);
            Destroy(collision.gameObject);
        }
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
