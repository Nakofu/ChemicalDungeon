using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChangeTrigger : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float moveDistanceX;
    [SerializeField] private float moveDistanceY;
    [SerializeField] private List<GameObject> monsters;
    private bool alreadyMoved;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
        alreadyMoved = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!alreadyMoved && collision.gameObject.name == "Player")
        {
            cam.transform.position += new Vector3(moveDistanceX, moveDistanceY, 0);
            GameObject.Find("Player").transform.position += new Vector3(4, 0, 0);

            alreadyMoved = true;

            foreach (var monster in monsters)
                monster.GetComponent<Enemy>().MoveSpeed = 1;
        }
    }
}
