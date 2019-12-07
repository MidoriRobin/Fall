using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float v, dy;
    public float speed;

    private float hInput = 0;

    // Start is called before the first frame update

    //void awake()
    //{

    //}

    // Update is called once per frame
    void Update()
    {


        #if !UNITY_ANDROID
        Move(Input.GetAxis("Horizontal"));
        #else
        Move(hInput);
        #endif

    }

    private void Move(float horizontalInput)
    {
        speed = 6;
        //v = Input.GetAxis("Horizontal");
        dy = horizontalInput * speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + dy, transform.position.y);
    }

    public void startMoving(float horizontalInput)
    {
        hInput = horizontalInput;
    }
}
