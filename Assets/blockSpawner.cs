using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class blockSpawner : MonoBehaviour
{


    public float InstantiationTimer;
    public GameObject prefab;
    public int mintime;
    public int maxtime;
    int lasttime;



    Material ball_Material;

    





    // Start is called before the first frame update
    void Start()
    {

        ball_Material = prefab.GetComponent<MeshRenderer>().sharedMaterial;
 

        
       


    }

    // Update is called once per frame
    void Update()
    {
       


    }

    void OnCollisionEnter(Collision collision)
    {
        MeshRenderer hitRender = collision.collider.GetComponent<MeshRenderer>();

        if (collision.collider.tag == "Player")
        {

            if (hitRender.material.color == ball_Material.color)
            {

                Destroy(prefab.gameObject, 0);
            }

        }
    }


    void randomTime()
    {
         lasttime = Random.Range(mintime, maxtime);
    }


    void CreatePrefab()
    {
        InstantiationTimer -= Time.deltaTime;
        if (InstantiationTimer <= 0)
        {
            randomTime();
           
            


            Instantiate(prefab, transform.position, Quaternion.identity);
            InstantiationTimer = lasttime ;
        }
    }

    private void FixedUpdate()
    {
        CreatePrefab();
    }

   

}
