using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Move : MonoBehaviour
{
    public SteamVR_Action_Vector2 axis;
    public float speed;
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = cam.transform.forward * axis.axis.y;
        Vector3 right = cam.transform.right * axis.axis.x;
        forward.y = 0;
        right.y = 0;
        this.transform.position += forward * speed;
        this.transform.position += right * speed;


    }
}
