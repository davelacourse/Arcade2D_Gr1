using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _vitesseJoueur = 10f;
    [SerializeField] GameObject _laserPrefab = default(GameObject);
    [SerializeField] float _cadenceTir = 0.5f;
    [SerializeField] int _viesJoueur = 3;

    private float _tempsTir = -1f;
    
    private InputSystem_Actions _playerInputActions;
    private Animator _animator;

    private void Awake()
    {
        _playerInputActions = new InputSystem_Actions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Attack.performed += Attack_performed;
        
        _animator = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        _playerInputActions.Player.Disable();
        _playerInputActions.Player.Attack.performed -= Attack_performed;
    }

    private void Update()
    {
        MouvementsJoueur();
    }

    private void Attack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (Time.time > _tempsTir)
        {
            Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            _tempsTir = Time.time + _cadenceTir;
        }
        
    }

    private void MouvementsJoueur()
    {
        Vector2 direction2D = _playerInputActions.Player.Move.ReadValue<Vector2>();

        direction2D.Normalize();

        transform.Translate(direction2D * Time.deltaTime * _vitesseJoueur);
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -4f, 0f));

        //Gérer les animations
        if(direction2D.x < 0f)
        {
            //Se déplace vers la gauche
            _animator.SetBool("TurnLeft", true);
            _animator.SetBool("TurnRight", false);
        }
        else if(direction2D.x > 0f)
        {
            _animator.SetBool("TurnRight", true);
            _animator.SetBool("TurnLeft", false);
        }
        else
        {
            _animator.SetBool("TurnLeft", false);
            _animator.SetBool("TurnRight", false);
        }
        
        if (transform.position.x < -9.5f)
        {
            transform.position = new Vector2(9.5f, transform.position.y);
        }
        else if (transform.position.x > 9.5f)
        {
            transform.position = new Vector2(-9.5f, transform.position.y);
        }
    }

// ============================ Méthodes publiques =========================================

    public void DommageJoueur()
    {
        _viesJoueur--;
        UIManager.Instance.UpdateVies(_viesJoueur);
        if(_viesJoueur <= 0)
        {
            // Mort du joueur / fin de partie
            SpawnManager spawnManager = FindAnyObjectByType<SpawnManager>();
            spawnManager.ArreterSpawn();
            Destroy(gameObject);
        }
    }
}
