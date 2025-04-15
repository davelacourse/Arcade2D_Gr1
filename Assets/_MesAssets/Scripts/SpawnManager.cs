using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _ennemi = default(GameObject);

    private void Start()
    {
        Vector2 positionSpawn = new Vector2(Random.Range(-8.3f, 8.3f), 6f);
        Instantiate(_ennemi, positionSpawn, Quaternion.identity);
    }
}
