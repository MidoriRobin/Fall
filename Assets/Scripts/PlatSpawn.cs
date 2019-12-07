using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatSpawn : MonoBehaviour
{
    public int maxPlatforms = 4;
    public GameObject pType1;
    public GameObject pType2;
    public GameObject pType3;
    public float horizontalMin = -8f;
    public float horizontalMax = 8f;
    public float verticalMin = 0f;
    public float verticalMax = 8f;

    private GameObject[] platCount  = new GameObject[0];
    private GameObject[] lastPlat;
    private Vector2 originPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        //initiates origin position as under the previous block but from the center of the screen
        originPosition = new Vector2(0,-8);
        //originPosition = (0, 0);
        Debug.Log(transform.position);
        //Spawn();
        SpawnManager();
    }

    private void Update()
    {
        //platCount = GameObject.FindGameObjectsWithTag("Platform");
        int count = GameObject.FindGameObjectsWithTag("Platform").Length;

        if (count == 2)
        {
            //if (count > 0)
            //{
            //    //Debug.Log
            //    originPosition = new Vector2(0,-8);
            //    //Debug.Log("Current Origin position: " + originPosition);
            //}

            //Debug.Log("Current Origin position: " + originPosition);

            originPosition = new Vector2(0, -8);

            //Spawn();
            SpawnManager();
        }

    }

    /// <summary>
    /// This method serves to spawn platforms, it accepts a platform  of type GameObject to clone.
    /// </summary>
    void Spawn(GameObject platform)
    {
            
        //Each sucessive platform has to be instantiated below the previous

        Vector2 randPosi = originPosition + new Vector2(UnityEngine.Random.Range(horizontalMin, horizontalMax), UnityEngine.Random.Range(verticalMin, verticalMax));
        Instantiate(platform, randPosi, Quaternion.identity);

        originPosition = new Vector2 (0, randPosi.y);
        //Debug.Log(originPosition);
        
    }

    void SpawnManager()
    {

        System.Random rand = new System.Random();
        GameObject[] plat = { pType1, pType2, pType3 };

        for (int i = 0; i < maxPlatforms; i++)
        {
            Spawn(plat[rand.Next(3)]);
        }
        
        
        
    }
}
