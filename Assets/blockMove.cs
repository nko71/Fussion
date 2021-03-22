using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class blockMove : MonoBehaviour
{

    Rigidbody rig;

    int score;
    public delegate void OnCollide();

    public static event OnCollide onColliddde;

    public delegate void onWallhit();

    public static event onWallhit wallhit;

   
   

    Material ball_Material;

    MeshRenderer Ball_rend;


    Color[] Ballcolor = new Color[] { Color.red, Color.green, Color.blue, Color.cyan };

    public float movespeed = 200;

    // Start is called before the first frame update
    void Start()
    {
        Ball_rend = this.gameObject.GetComponent<MeshRenderer>();


        ball_Material = Ball_rend.material;

        ball_Material.color = Ballcolor[Random.Range(0, Ballcolor.Length)];



        rig = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        

        rig.velocity = new Vector3(0, rig.velocity.y, -1 * movespeed *  Time.fixedDeltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        MeshRenderer hitmesh = collision.gameObject.GetComponent<MeshRenderer>();

        if(collision.collider.tag == "Player")
        {
            if(hitmesh.material.color == ball_Material.color)
            {
                Scoredddd();
                
                Destroy(this.gameObject, 0);
            }
        }

        if(collision.collider.tag == "End")
        {
            NEgative();

            Destroy(this.gameObject, 0);
        }
    }



   

    public void Scoredddd()
    {

        if (onColliddde != null)
        {
            onColliddde();
        }


    }

    public void NEgative()
    {
        if(wallhit != null)
        {
            wallhit();
        }
    }
}
