using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeScript : MonoBehaviour
{
    private float speed = 2f,openSpeed=2f,final_pose;
    public Boolean target_open = false,open_done=false;
    private GameObject uPipe, dPipe;
    // Start is called before the first frame update
    void Start()
    {
        uPipe = transform.Find("uPipe").gameObject;
        dPipe = transform.Find("dPipe").gameObject;

        final_pose = uPipe.transform.position.y + 2.15f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -20)
            Destroy(gameObject);

        if(target_open && uPipe.transform.position.y < final_pose)
        {
            uPipe.transform.position += Vector3.up * openSpeed * Time.deltaTime;
            dPipe.transform.position += Vector3.down * openSpeed * Time.deltaTime;
        }
    }
}
