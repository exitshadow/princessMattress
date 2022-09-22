using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Trap : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] [Range(0, 1f)] float delay = .5f;
    [SerializeField] [Range(0, 5f)] float weight = 1f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("TriggerTrap", delay);
        }
    }

    private void TriggerTrap()
    {
        rb.gravityScale = weight;
        
        foreach(Collider2D col in GetComponents<Collider2D>())
            col.enabled = false;
    }
}
