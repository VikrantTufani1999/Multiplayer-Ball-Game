using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        if(photonView.IsMine)
        {
           transform.GetComponent<BallControl>().enabled = true;
        }
        else
        {
            transform.GetComponent<BallControl>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
