using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
    public Camera camera;

    private void Start()
    {
        camera = FindObjectOfType<Camera>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            var tr=camera.GetComponent<Transform>();
            tr.position = new Vector3(tr.position.x + 10, tr.position.y, tr.position.z);
        }
    }
}
