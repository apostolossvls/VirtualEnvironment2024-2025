using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimated : Door
{
    [SerializeField] protected Animator animator;

    public override bool Open()
    {
        bool result = base.Open();
        if (!result) return false; 

        animator.SetBool("isOpen", true);
        return true;
    }

    public override bool Close()
    {
        base.Close();

        animator.SetBool("isOpen", false);
        return true;
    }
}
