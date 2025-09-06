using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action OnPowerUpStart;
    public Action OnPowerUpEnd;

    [SerializeField] private float speed;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float powerUpDuration;

    private Rigidbody _rigidbody;
    private Coroutine _powerUpCoroutine;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        mainCamera = Camera.main?.transform;
    }

    private void Start()
    {
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

    private IEnumerator StartPowerUp()
    {
        Debug.Log("Start Power Up");
        OnPowerUpStart?.Invoke();
        yield return new WaitForSeconds(powerUpDuration);
        Debug.Log("Stop Power Up");
        OnPowerUpEnd?.Invoke();
    }
}