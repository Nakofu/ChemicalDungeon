using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            var tr = cam.GetComponent<Transform>();
            tr.position = new Vector3(tr.position.x + 10, tr.position.y, tr.position.z);
        }
    }
}
