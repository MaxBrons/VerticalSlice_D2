using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private float rotationSpeed = 50;
    private float movementSpeed = 5;
    private int health = 200;
    private bool isCrouching = false;
    private bool isJumping = false;
    private Vector2 mouseLook;
    private Vector2 smoothV;
    private float mouseX = 0;
    private float mouseY = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        /*Vector2 md = new Vector2(-Input.GetAxisRaw(ConstClass.MOUSEY), Input.GetAxisRaw(ConstClass.MOUSEX));
        mouseLook.x = Mathf.Clamp(mouseLook.x, -45f, 45f);
        mouseLook += md;
        cam.transform.localRotation = Quaternion.Euler(mouseLook);
        Quaternion rot = cam.transform.localRotation;*/
        mouseY += Input.GetAxisRaw(ConstClass.MOUSEX) * rotationSpeed * Time.deltaTime;
        mouseX -= Input.GetAxisRaw(ConstClass.MOUSEY) * rotationSpeed * Time.deltaTime;

        mouseX = Mathf.Clamp(mouseX, -90, 90);
        transform.rotation = Quaternion.Euler(0, mouseY, 0);
        cam.transform.rotation = Quaternion.Euler(mouseX, mouseY, 0);
    }

    private void FixedUpdate()
    {
        float hAxis = Input.GetAxis(ConstClass.HORIZONTAL);
        float vAxis = Input.GetAxis(ConstClass.VERTICAL);

        Vector3 hMove = hAxis * transform.right;
        Vector3 vMove = vAxis * cam.transform.forward;
        Vector3 Movement = (hMove + vMove) * movementSpeed * Time.deltaTime;

        transform.position += Movement;
    }
}
