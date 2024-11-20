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
    public TextMeshProUGUI scoreText;
    public GameObject winTextObject;
    public Vector3 rise;
    public LayerMask groundLayer;
    public bool isTimeRunning;

    private float raycastDistance = 0.6f;
    private float jump = 50;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private bool isGrounded;
    private int count;
    float stopWatch;

    bool isGoalReached;
    public int pickupScore;
    public int timeScore;
    public int totalScore;


    // Start is called before the first frame update
    void Start()
    {
        pickupScore = 0;
        timeScore = 1000;

        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        isTimeRunning = true;
        isGoalReached = false;
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
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            if (isGrounded == true)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
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
            pickupScore += 15;
            SetCountText();
        }

        if (other.gameObject.CompareTag("ResetPlane"))
        {
            transform.position = new Vector3(0, 0.5f, 0);

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (other.gameObject.CompareTag("Goal"))
        { 
            isTimeRunning = false;
            ScoreTracker();
            winTextObject.SetActive(true);
            Time.timeScale = 0f;
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

        // This makes it so the zero disappears whenever the seconds reach 10 or higher
        if(seconds >= 10)
        {
            timerText.text = "Timer: " + minutes + ":" + seconds;
        }
        else
        {
            timerText.text = "Timer: " + minutes + ":0" + seconds;
        }
    }

    void ScoreTracker()
    {
            timeScore -= Mathf.FloorToInt(stopWatch * 15);
            
            totalScore = timeScore + pickupScore;

        scoreText.text = $"Score: {timeScore} + {pickupScore} = {totalScore}";
    }
}
