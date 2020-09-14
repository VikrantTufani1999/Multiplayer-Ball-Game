using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{
    private Rigidbody rb;
    public float playerMoveSpeed = 500f;
    bool isGrounded = false;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                if (touch.position.x < Screen.width / 2)
                    rb.AddForce(new Vector3(-100, 0, 0));

                if (touch.position.x > Screen.width / 2)
                    rb.AddForce(new Vector3(100, 0, 0));
            }
        }
    }

    private void OnMouseDown()
    {
       
        Debug.Log("Jump Action");
        if (this.enabled == true && isGrounded == true)
        {
            this.rb.AddForce(Vector3.up * 1000, ForceMode.Acceleration);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
            isGrounded = false;
    }
}
