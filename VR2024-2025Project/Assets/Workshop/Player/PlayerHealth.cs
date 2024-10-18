using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 5;
    public float health = 5;
    public RawImage bloodImage;
    public GameObject GameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        UpdateBlood();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        UpdateBlood();
        if (health <= 0)
        {
            health = 0;
            GameOverScreen.SetActive(true);
            DeactivateCharacter();
        }
    }

    void UpdateBlood()
    {
        float percentage = health / maxHealth;
        Color c = bloodImage.color;
        c.a = 1 - percentage;
        bloodImage.color = c;
    }

    public void DeactivateCharacter()
    {
        foreach (Component comp in GetComponentsInChildren<Component>())
        {
            if (comp is not Transform) Destroy(comp);
        }
    }
}
