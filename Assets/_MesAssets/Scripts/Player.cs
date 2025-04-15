using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _vitesseJoueur = 10f;
    [SerializeField] GameObject _laserPrefab = default(GameObject);
    [SerializeField] float _cadenceTir = 0.5f;

    private float _tempsTir = -1f;
    
    private InputSystem_Actions _playerInputActions;

    private void Awake()
    {
        _playerInputActions = new InputSystem_Actions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Attack.performed += Attack_performed;
    }

    private void OnDestroy()
    {
        _playerInputActions.Player.Disable();
        _playerInputActions.Player.Attack.performed -= Attack_performed;
    }

    private void Attack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (Time.time > _tempsTir)
        {
            Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            _tempsTir = Time.time + _cadenceTir;
        }
        
    }

    private void Update()
    {
        MouvementsJoueur();
    }

    private void MouvementsJoueur()
    {
        Vector2 direction2D = _playerInputActions.Player.Move.ReadValue<Vector2>();

        direction2D.Normalize();

        transform.Translate(direction2D * Time.deltaTime * _vitesseJoueur);
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -4.5f, 0f));

        if (transform.position.x < -9.5f)
        {
            transform.position = new Vector2(9.5f, transform.position.y);
        }
        else if (transform.position.x > 9.5f)
        {
            transform.position = new Vector2(-9.5f, transform.position.y);
        }
    }
}
