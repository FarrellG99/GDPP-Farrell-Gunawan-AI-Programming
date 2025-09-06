using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Action OnPowerUpStart;
    public Action OnPowerUpEnd;

    [SerializeField] private float speed;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float powerUpDuration;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private int health;
    [SerializeField] private TextMeshProUGUI healthText;

    private Rigidbody _rigidbody;
    private Coroutine _powerUpCoroutine;
    private bool _isPowerUpActive;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        mainCamera = Camera.main?.transform;
    }

    private void Start()
    {
        UpdateUi();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 horizontalDirection =  horizontal * mainCamera.right;
        Vector3 verticalDirection =  vertical * mainCamera.forward;
        verticalDirection.y = 0;
        horizontalDirection.y = 0;
        Vector3 movementDirection = horizontalDirection + verticalDirection;
        _rigidbody.linearVelocity = movementDirection * (speed * Time.fixedDeltaTime);
    }

    public void PickPowerUp()
    {
        Debug.Log("Picking PowerUp");
        if (_powerUpCoroutine != null) StopCoroutine(_powerUpCoroutine);
        _powerUpCoroutine = StartCoroutine(StartPowerUp());
    }

    public void Dead()
    {
        health -= 1;
        if (health > 0)
        {
            transform.position = respawnPoint.position;
        }
        else
        {
            health = 0;
            Debug.Log("Lose");
        }

        UpdateUi();
    }

    private IEnumerator StartPowerUp()
    {
        Debug.Log("Start Power Up");
        _isPowerUpActive = true;
        OnPowerUpStart?.Invoke();
        yield return new WaitForSeconds(powerUpDuration);
        Debug.Log("Stop Power Up");
        _isPowerUpActive = false;
        OnPowerUpEnd?.Invoke();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_isPowerUpActive)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemy>().Dead();
            }
        }
    }

    private void UpdateUi()
    {
        healthText.text = "Health: " + health;
    }
}