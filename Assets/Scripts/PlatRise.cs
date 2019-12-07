using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatRise : MonoBehaviour
{
    private BoxCollider2D bc2d;
    private Rigidbody2D rb2d;
    //private int lvlMark = 10;
    public int level;
    //private float timer = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        bc2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        Debug.Log("This is the current level: " + level);
        level = Destroyer.level;
    }

    // Update is called once per frame
    void Update()
    {
        LayerMask roof = LayerMask.GetMask("Roof");

        //Collider2D test;

        //test.gameObject.name()

        //Debug.Log(rb2d.IsTouching());
        //timer += Time.deltaTime;

        //if (timer >= lvlMark)
        //{
        //    timer = timer - lvlMark;
        //    level += 1;
        //    //PlatformController.test += 1;

        //}

        if (level < Destroyer.level)
        {
            level = Destroyer.level;
        }
        
        transform.Translate(0, Time.deltaTime * level, 0, Space.World);
        


    }
}
