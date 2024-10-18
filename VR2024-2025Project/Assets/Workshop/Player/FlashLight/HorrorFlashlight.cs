using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorFlashlight : MonoBehaviour
{
    public Light sourceLight;
    public AudioSource audioSource;
    public KeyCode key = KeyCode.F;
    private bool isOn = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            ToggleLight();
        }
    }

    void ToggleLight()
    {
        isOn = !isOn;
        sourceLight.enabled = isOn;
        audioSource.Play();
    }
}
