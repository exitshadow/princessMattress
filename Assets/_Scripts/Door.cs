using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    [HideInInspector] public LevelManager manager;
    [HideInInspector] public bool isOpen = false;

    [SerializeField] public bool isExit = false;

    private Animator animator;

    public void Open()
    {
        isOpen = true;
        animator.SetBool("isOpen", isOpen);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isOpen && !isExit && manager != null) manager.DoorIsReached();
            else if (isOpen && isExit) Application.Quit();
        }
    }

}
