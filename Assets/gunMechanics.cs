using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class gunMechanics : MonoBehaviour
{
    public SteamVR_Action_Boolean trigger;
    public bool held = false;
    public Light muzzleFlash;
    private bool fireRateLock;
    public LineRenderer lazer;
    
    public void grabbed()
    {
        held = true;
    }

    public void dropped()
    {
        held = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        fireRateLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger.GetState(SteamVR_Input_Sources.Any) && held && !fireRateLock)
        {
            fireRateLock = true;
            StartCoroutine("gunShotDelay");
        }
    }

    private IEnumerator gunShotDelay()
    {
        muzzleFlash.enabled = true;
        lazer.enabled = true;
        yield return new WaitForSeconds(.05f);
        muzzleFlash.enabled = false;
        lazer.enabled = false;
        yield return new WaitForSeconds(.1f);
        fireRateLock = false;
    }
}
