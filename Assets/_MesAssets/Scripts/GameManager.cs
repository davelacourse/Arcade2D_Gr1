using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int _pointage = 0;
    public int Pointage => _pointage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
            
    }

    public void AugmenterPointage(int p_points)
    {
        _pointage += p_points;
        UIManager.Instance.UpdatePointage();
    }
}
