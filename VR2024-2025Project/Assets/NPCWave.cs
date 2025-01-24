using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWave : MonoBehaviour
{
    [SerializeField] private Animator anim;
    bool wavedOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        wavedOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.tag == "Player" && !wavedOnce)
        {
            wavedOnce = true;
            anim.SetTrigger("Wave");
        }
    }
}
