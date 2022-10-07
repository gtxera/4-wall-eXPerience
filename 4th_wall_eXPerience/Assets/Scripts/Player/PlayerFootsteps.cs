using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    // Start is called before the first frame update
    public FMODUnity.EventReference Footstep;
    public float walkingspeed;
    private bool playerismoving;

    void Update()
    {
        if (Input.GetAxis("Horizontal") >= 0.01f | Input.GetAxis("Horizontal") <= -0.01f | Input.GetAxis("Vertical") >= 0.01f | Input.GetAxis("Vertical") <= -0.01f)
        {
            playerismoving = true;
        }

        else
        {
            playerismoving = false;
        }
    }
    void CallFootsteps()
    {
        if (playerismoving == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot(Footstep);
        }
    }
    private void Start()
    {
        InvokeRepeating("CallFootsteps", 0f, walkingspeed);
    }
}