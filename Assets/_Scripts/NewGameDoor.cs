using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameDoor : MonoBehaviour
{
    private Door door;

    private void Start()
    {
        door = transform.parent.GetComponent<Door>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        door.Open();
    }
}
