using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Resource : MonoBehaviour
{
    float distanceToTarget = Mathf.Infinity;
    [SerializeField] float harvestRange = 5f;
    bool isGatherable = true;

    [SerializeField] int hitsToDestroy = 1;
    int damageTaken;
    [SerializeField] int regenTimer = 50000;


    //Prefabs for spawning resources
    public GameObject logs ;
    public GameObject  ore;
    //public GameObject  ;
    //public GameObject  ;


   //End of Prefabs

    void Start()
    {
        damageTaken = 0;

    }


    void Update()
    {
        
       
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = new Color(1, 6, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, harvestRange);
    }
    public void Chop(GameObject tree)
    {
        if (damageTaken >= hitsToDestroy)
        {
            GameObject logSpawn = logs;
            Instantiate(logSpawn, tree.transform.position, Quaternion.identity);
            Destroy(tree);
        }
        else
            damageTaken++;
    }
    public void Mine(GameObject vein) {
        if (damageTaken >= hitsToDestroy)
        {
            GameObject oreSpawn = ore;
            Instantiate(oreSpawn, vein.transform.position, Quaternion.identity);
            Destroy(vein);
        }
        else
            damageTaken++;

    }
}
