using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private float rotationSpeed = 50;
    private float movementSpeed = 30;
    private int health = 200;
    private bool isCrouching = false;
    private bool isJumping = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float x = Input.GetAxisRaw(ConstClass.MOUSEX) * rotationSpeed * Time.deltaTime;
        float y = Input.GetAxisRaw(ConstClass.MOUSEY) * rotationSpeed * Time.deltaTime;
    }
}
