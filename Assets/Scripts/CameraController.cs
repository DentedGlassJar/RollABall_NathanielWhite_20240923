using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    public float rotationSpeed;
    //private float mouseTurnX = Input.GetAxis("Horizontal");

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after all Updates
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        //I want the camera to orbit around the player, and have it move when I move my camera left to right.
        /*  Whenever my mouse moves 
         */
    }
}
