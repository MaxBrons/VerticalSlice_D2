using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private Rigidbody rb;
    private float rotationSpeed = 50;
    private float movementSpeed = 5;
    private int health = 200;
    private bool isCrouching = false;
    private bool isJumping = false;
    private Vector2 mouseLook;
    private Vector2 smoothV;
    private float mouseX = 0;
    private float mouseY = 0;
    private bool jumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        mouseY += Input.GetAxisRaw(ConstClass.MOUSEX) * rotationSpeed * Time.deltaTime;
        mouseX -= Input.GetAxisRaw(ConstClass.MOUSEY) * rotationSpeed * Time.deltaTime;

        mouseX = Mathf.Clamp(mouseX, -90, 90);
        transform.rotation = Quaternion.Euler(0, mouseY, 0);
        cam.transform.rotation = Quaternion.Euler(mouseX, mouseY, 0);

        if (Input.GetKeyDown(KeyCode.Space) && jumping == false) 
            rb.AddForce(new Vector3(0, 500, 0));
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

    private void OnCollisionExit(Collision collision)
    {
        jumping = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == ConstClass.GROUND_TAG)
            jumping = false;
    }
}
