using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int pickUpMax;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI timerText;
    public GameObject winTextObject;
    public Vector3 rise;
    public LayerMask groundLayer;
    public float stopWatch;
    public bool isTimeRunning;

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
        SetCountText();
        winTextObject.SetActive(false);
        isTimeRunning = true;
        stopWatch = 0;
        SetTimerText();
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

        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(isGrounded == true)
            {
                Vector3 movement = new Vector3(movementX, 0.0f, movementY);
                rb.velocity = Vector3.zero;
            }
        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            if (isGrounded == true)
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

        if(isTimeRunning == true)
        {
            stopWatch += Time.deltaTime;
            SetTimerText();
        }
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
            isTimeRunning = false;
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

    void SetTimerText()
    {
        float minutes = Mathf.FloorToInt(stopWatch / 60);
        float seconds = Mathf.FloorToInt(stopWatch % 60);

        if(seconds >= 10)
        {
            timerText.text = "Timer: " + minutes + ":" + seconds;
        }
        else
        {
            timerText.text = "Timer: " + minutes + ":0" + seconds;
        }
    }
}
