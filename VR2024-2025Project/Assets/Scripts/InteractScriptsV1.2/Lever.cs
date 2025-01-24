using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] protected bool isOn;
    [SerializeField] protected UnityEvent onActivation;
    [SerializeField] protected UnityEvent onDeactivation;

    public void OnAbortInteract()
    {
    }

    public void OnEndInteract()
    {
    }

    public void OnInteract(Interactor interactor)
    {
        isOn = !isOn;
        if (isOn)
        {
            onActivation.Invoke();
        }
        else
        {
            onDeactivation.Invoke();
        }
    }

    public void OnReadyInteract()
    {
    }
}
