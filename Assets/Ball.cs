using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public int colorNO;

    Material ball_Material;

    MeshRenderer Ball_rend;

    Color[] Ballcolor = new Color[] { Color.red, Color.green, Color.blue, Color.cyan };



    // Start is called before the first frame update
    void Start()
    {
        Ball_rend = this.GetComponent<MeshRenderer>();


        ball_Material = Ball_rend.material;


        ball_Material.color = Ballcolor[colorNO];

       
    }

    // Update is called once per frame
    void Update()
    {
       // ball_Material.color = Color.green;


    }

    /*void OnCollisionEnter(Collision collision)
    {
        MeshRenderer hitRender = collision.collider.GetComponent<MeshRenderer>();

        if (collision.collider.tag == "Ball")
        {

            if (hitRender.material.color == ball_Material.color)
            {

            Destroy(this.gameObject, 0);
            }

        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        MeshRenderer hitmesh = other.gameObject.GetComponent<MeshRenderer>();
        
        if(other.gameObject.tag == "Player")
        {
            hitmesh.material.color = ball_Material.color;

        }
    }
}
