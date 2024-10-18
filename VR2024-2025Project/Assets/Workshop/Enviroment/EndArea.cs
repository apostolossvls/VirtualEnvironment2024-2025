using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndArea : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject endCamera;

    private void Start()
    {
        endScreen = FindFirstObjectByType<Canvas>().transform.Find("EndScreen").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            endScreen?.SetActive(true);
            endCamera?.SetActive(true);
            other.GetComponentInParent<PlayerHealth>()?.DeactivateCharacter();
            Destroy(this);
        }
    }
}
