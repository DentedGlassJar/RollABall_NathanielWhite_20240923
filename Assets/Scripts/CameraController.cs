using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector2 turn;
    public Vector3 objectCamera;
    public Vector3 newLeftPos;
    public Vector3 newRightPos;

    private Vector3 offset;
    private int xMax = 30;
    private int yMax = 25;
    private int xMin = -30;
    private int yMin = -25;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");

        if (turn.y >= yMin)
        {
            transform.localRotation = Quaternion.Euler(turn.y, turn.x, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(-30, turn.x, 0);
            turn.y = yMin;
        }

        if (turn.y <= yMax)
        {
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(-30, turn.x, 0);
            turn.y = yMax;
        }

        if (turn.x <= xMax)
        {
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(-turn.y, -30, 0);
            turn.x = xMax;
        }

        if (turn.x >= xMin)
        {
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(-turn.y, -30, 0);
            turn.x = xMin;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

        }
    }
}
