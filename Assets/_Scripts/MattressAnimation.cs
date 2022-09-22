using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MattressAnimation : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [Range(0,10)] [SerializeField] private float animTime;
    private Vector3 start;
    private Vector3 end;
    private bool reverse = false;
    private IEnumerator Move()
    {
        float time = 0f;
        float t = 0f; // lerp ratio

        while (true)
        {
            while (t < 1)
            {
                time += Time.deltaTime;
                t = time / animTime;

                if (reverse)
                    transform.position = Vector3.Lerp(end, start, t);
                else
                    transform.position = Vector3.Lerp(start, end, t);
                
                yield return null;
            }
            time = 0f;
            t = 0f;
            reverse = !reverse;
        }
    }

    private void Start()
    {
        start = transform.position;
        end =   destination.position;

        StartCoroutine(Move());
    }

    private void OnDrawGizmos()
    {
        bool warning = false;
        if (destination != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, destination.position);
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(destination.position, new Vector3(2f,.4f,.1f));
        }
        else if (destination == null && warning == false)
        {
            warning = true;
            Debug.LogWarning("Mattress has no destination to animate");
        }
    }

}
