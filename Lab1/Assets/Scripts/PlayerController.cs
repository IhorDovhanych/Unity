using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    public float sprintDuration = 3f; // Тривалість прискорення в секундах
    public float jumpForce = 10f;
    public float rotationSpeed = 5f; // Швидкість обертання персонажа
    private Rigidbody rb;
    private bool isSprinting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Отримання руху мишки
        float mouseX = Input.GetAxis("Mouse X");

        // Обертання персонажа
        Vector3 rotation = new Vector3(0f, mouseX, 0f) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // Запуск корутини для встановлення прискорення на певний час
            StartCoroutine(StartSprintTimer());
        }

        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput) * currentSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + transform.TransformDirection(moveDirection));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    IEnumerator StartSprintTimer()
    {
        isSprinting = true;
        yield return new WaitForSeconds(sprintDuration);
        isSprinting = false;
    }
}
