using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class lucio : MonoBehaviour
{
    public SteamVR_Action_Vector2 joyAxisL; 
    public SteamVR_Action_Boolean jumpButton;
    private float vAngle = 0;
    public GameObject player;
    public float moveSpeed;
    public float jumpPower;
    public Vector3 speed;
    public float horiz;
    public float vert;
    public float prevHorizontal;
    public float prevVertical;
    private Vector3 prevPosition;
    private Vector3 inputDirection;
    public Vector3 prevDirection;
    private Vector3 prevSpeed;
    int jumps = 2;
    bool floating;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor" && collision.transform.position.y < this.transform.position.y)
        {
            floating = false;
             jumps = 2;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor" && collision.transform.position.y < this.transform.position.y)
        {
            floating = false;
            jumps = 2;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            floating = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        var horizontal = player.transform.right * joyAxisL.axis.x;
        var vertical = player.transform.forward * joyAxisL.axis.y ;
        inputDirection = new Vector3(horizontal.x + vertical.x, 0, horizontal.z + vertical.z);
        //inputDirection = player.transform.TransformDirection(inputDirection);
        inputDirection = inputDirection.normalized;
        //horiz = horizontal;
        //vert = vertical;
        if (prevPosition != null)
        {
            speed = prevPosition - player.transform.position;
            prevPosition = player.transform.position;
        }

        if (floating)
        {
            if (inputDirection.x != 0 || inputDirection.z != 0)
            {
                transform.Translate(((prevDirection) * moveSpeed * Time.deltaTime * 1000)); //+ (new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime * 500));
                                                                                               //transform.Translate(new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime * 500);
                //if (Mathf.Abs(horizontal + prevDirection.x) < 1)
                //{
                //    prevDirection += transform.TransformDirection((new Vector3(horizontal, 0, 0) * moveSpeed * Time.deltaTime * 50));
                //}
                //if (Mathf.Abs(vertical + prevDirection.z) < 1)
                //{
                //    prevDirection += transform.TransformDirection(new Vector3(0, 0, vertical) * moveSpeed * Time.deltaTime * 50);
                //    //prevDirection += transform.TransformDirection((new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime * 50));
                //}
            }
            else
            {
                transform.Translate(prevDirection * moveSpeed * Time.deltaTime * 1000);
                //transform.Translate(new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime * 500);
            }

            //transform.position += transform.TransformDirection(prevDirection * moveSpeed * Time.deltaTime * 1000);
        }
        else
        {
            transform.Translate((inputDirection) * moveSpeed * Time.deltaTime * 1000);

            //transform.Translate(new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime * 1000);
            prevHorizontal = inputDirection.x;
            prevVertical = inputDirection.z;
            prevDirection = inputDirection;
            //prevDirection = player.transform.TransformDirection(new Vector3(prevHorizontal, 0, prevVertical));
            prevDirection = prevDirection.normalized;
            prevSpeed = prevDirection;
        }
        


        if (jumpButton.GetStateDown(SteamVR_Input_Sources.Any) && jumps > 0)
        {
            if(jumps > 1)
            {
                Rigidbody rigid = this.GetComponent<Rigidbody>();
                if (rigid.velocity.y < 0)
                {
                    rigid.velocity = new Vector3(rigid.velocity.x, 0, rigid.velocity.z);
                }
                rigid.AddForce(transform.up * jumpPower);
            }
            else
            {
                Rigidbody rigid = this.GetComponent<Rigidbody>();
                if(rigid.velocity.y < 0)
                {
                    rigid.velocity = new Vector3(rigid.velocity.x, 0, rigid.velocity.z);
                }
                rigid.AddForce(transform.up * jumpPower);
            }
            //--jumps;
        }
    }

}
