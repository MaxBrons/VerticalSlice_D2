using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private float rotationSpeed = 50;
    private float movementSpeed = 20;
    private int health = 200;
    private bool isCrouching = false;
    private bool isJumping = false;
    private Vector2 mouseLook;
    private Vector2 smoothV;
    private Rigidbody rb;
    private float xRot = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        /*Vector2 md = new Vector2(-Input.GetAxisRaw(ConstClass.MOUSEY), Input.GetAxisRaw(ConstClass.MOUSEX));
        mouseLook.x = Mathf.Clamp(mouseLook.x, -45f, 45f);
        mouseLook += md;
        cam.transform.localRotation = Quaternion.Euler(mouseLook);
        Quaternion rot = cam.transform.localRotation;*/
        float mouseX = Input.GetAxisRaw(ConstClass.MOUSEX) * movementSpeed * Time.deltaTime;
        float mouseY = Input.GetAxisRaw(ConstClass.MOUSEY) * movementSpeed * Time.deltaTime;
        xRot += mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.localRotation = cam.transform.rotation;
        cam.transform.Rotate(Vector3.up * mouseX);
    }

    private void FixedUpdate()
    {
        float hAxis = Input.GetAxis(ConstClass.HORIZONTAL);
        float vAxis = Input.GetAxis(ConstClass.VERTICAL);

        Vector3 hMove = hAxis * transform.right;
        Vector3 vMove = vAxis * transform.forward;
        Vector3 Movement = transform.position + (hMove + vMove).normalized * movementSpeed * Time.fixedDeltaTime;

        rb.MovePosition(Movement);
    }
}
