using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMotion : MonoBehaviour
{


    public float hor;
    public float ver;

    public bool grounded;
    public float jumpPower = 20;

    public float horizontalVelocity = 200;

    Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = this.gameObject.GetComponent<Rigidbody>();

        grounded = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            grounded = true;
        }
    }


    private void FixedUpdate()
    {

        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");

        rig.velocity = new Vector3(hor,rig.velocity.y, ver) * Time.fixedDeltaTime * horizontalVelocity;

     
        
    }
}
