using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _ennemi = default(GameObject);
    [SerializeField] private float _delaiApparitionInitial = 4f;
    [SerializeField] private float _delaiApparitionMin = 3f;
    [SerializeField] private float _delaiApparitionMax = 6f;

    private bool _stopSpawn = false;

    private void Start()
    {
        StartCoroutine(SpawnEnnemi());

    }
     
    IEnumerator SpawnEnnemi()
    {
        yield return new WaitForSeconds(_delaiApparitionInitial);  // Délai initial de 4 secondes
        while (!_stopSpawn)
        {
            Vector2 positionSpawn = new Vector2(Random.Range(-8.3f, 8.3f), 6f);
            Instantiate(_ennemi, positionSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(_delaiApparitionMin, _delaiApparitionMax));
        }
    }

    public void ArreterSpawn()
    {
        _stopSpawn = true;
    }
}
