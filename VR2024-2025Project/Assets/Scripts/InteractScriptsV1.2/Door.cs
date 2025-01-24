using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject indicator;
    [SerializeField] protected bool isOpen;
    [SerializeField] protected bool isLocked;

    public virtual bool Open()
    {
        if (isLocked) return false;

        isOpen = true;
        return true;
    }

    public virtual bool Close()
    {
        isOpen = false;
        return true;
    }

    public virtual void Lock()
    {
        if (isOpen) return;

        isLocked = true;
    }

    public virtual void Unlock()
    {
        isLocked = false;
    }


    public virtual void OnAbortInteract()
    {
        indicator.SetActive(false);
    }

    public virtual void OnEndInteract()
    {
    }

    public virtual void OnInteract(Interactor interactor)
    {
        indicator.SetActive(false);

        if (isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public virtual void OnReadyInteract()
    {
        indicator.SetActive(true);
    }
}
