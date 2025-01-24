using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = Vector3.one * 5;
    public List<Vector3> lastPositions;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = target.position - transform.position;
        Vector3 dir = diff.normalized;

        Debug.DrawRay(transform.position, diff, Color.magenta);
        Debug.DrawRay(transform.position + Vector3.up * 0.5f, dir, Color.blue);

        transform.position += dir * Time.deltaTime;
    }
}
