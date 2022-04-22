using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followObject : MonoBehaviour
{
    public GameObject followBlock;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = followBlock.transform.position;
    }
}
