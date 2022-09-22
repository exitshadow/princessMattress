using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    [HideInInspector] public LevelManager manager;
    [HideInInspector] public bool isOpen = false;

    [SerializeField] public bool isExit = false;
    [SerializeField] public bool isLoad = false;

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
        Debug.Log($"isExit: {isExit}");
        if (other.CompareTag("Player"))
        {
            if (isOpen)
            {
                if (isLoad)
                {
                    DataManager.Load();
                }
                else
                {
                    if (!isExit && manager != null)
                        manager.DoorIsReached();
                    else
                    {
                        Debug.Log("Qutting.");
                        Application.Quit();
                    }
                }

            }
        }
    }

}
