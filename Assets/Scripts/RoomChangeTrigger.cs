using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class RoomChangeTrigger : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Vector3 cameraMovement;
    [SerializeField] private Vector3 playerMovement;
    [SerializeField] private List<GameObject> monsters;
    [SerializeField] private string hintText;
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
            cam.transform.position += cameraMovement;
            GameObject.Find("Player").transform.position += playerMovement;

            alreadyMoved = true;

            foreach (var monster in monsters)
                monster.GetComponent<Enemy>().SetSpeed();

            GameObject.Find("HintCanvas").transform.GetChild(0).GetChild(0).GetComponent<Text>().text = hintText;
        }
    }
}
