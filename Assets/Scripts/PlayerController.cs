using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float rotationSpeed = 50;
    private float movementSpeed = 30;
    private int health = 200;
    private bool isCrouching = false;
    private bool isJumping = false;
    private Vector2 mouseLook;
    private Vector2 smoothV;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 md = new Vector2(-Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"));
        mouseLook.x = Mathf.Clamp(mouseLook.x, -70f, 70f);
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
        mouseLook += md;
        cam.transform.localRotation = Quaternion.Euler(mouseLook);
    }
}
