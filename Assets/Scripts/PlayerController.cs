using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using System.Transactions;
using UnityEngine.Rendering;
using System.Runtime.CompilerServices;
using System;
using UnityEngine.SceneManagement;
using System.Net;

public class PlayerController : MonoBehaviour
{
    public int pickUpMax;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI timerText;
    public GameObject winTextObject;
    public Vector3 rise;
    public LayerMask groundLayer;
    
    bool stopwatchActive = true;
    float currentTime;

    private float raycastDistance = 0.6f;
    private float jump = 50;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private bool isGrounded;
    private int count;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        currentTime = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void Update()
    {
        //This is a method of checking to see if the player is touching the ground.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayer))
        {
            isGrounded = true;
        }    
        else
        {
            isGrounded = false;
        }

        // This makes it so the player jumps
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jump triggered");
            rb.AddForce(jump * rise);
        }

        if (stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        //timerText.text = time.ToString(@"mm\ ss\ fff");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(isGrounded == true)
            {
                Vector3 movement = new Vector3(movementX, 0.0f, movementY);
                rb.velocity = Vector3.zero;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rise = new Vector3(movementX, 10.0f, movementY);
        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("ResetPlane"))
        {
            transform.position = new Vector3(0, 0, 0);
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            stopwatchActive = false;
            winTextObject.SetActive(true);
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    //I want to make it so if the player holds down the shift button, that they stop in position so they can plan more with their movement.
}
