using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [SerializeField] TMP_Text _txtPointage = default(TMP_Text);
    [SerializeField] TMP_Text _txtVies = default(TMP_Text);

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdatePointage();    
    }

    public void UpdatePointage()
    {
        _txtPointage.text = "Pointage : " + GameManager.Instance.Pointage.ToString();
    }

    public void UpdateVies(int p_vies)
    {
        _txtVies.text = "Vies : " + p_vies.ToString();
    }
}
