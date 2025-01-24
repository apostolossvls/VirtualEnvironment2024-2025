using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceWhenNotLooking : MonoBehaviour
{
    public LayerMask layerMask;
    public Transform eyes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(eyes.transform.position, transform.forward, out hit, 50f, layerMask, QueryTriggerInteraction.Ignore))
        {
            Debug.DrawRay(eyes.transform.position, transform.forward * 5, Color.magenta);
            Debug.Log(hit.transform.name);
        }
    }
}
