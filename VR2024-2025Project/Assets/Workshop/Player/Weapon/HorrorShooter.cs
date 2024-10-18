using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorShooter : MonoBehaviour
{
    [Header("--- Setup ---")]
    [Space(5)]
    public Animator playerAnimator;
    public Animator crosshairAnimator;
    [Space(15)]
    [Header("--- Gun Properties ---")]
    [Space(5)]
    [Range(0.01f, 100f)] public float fireRate = 5;
    public float damage = 100;
    [Space(15)]
    [Header("--- Visual & Audio Effects ---")]
    [Space(5)]
    public ParticleSystem muzzleFlash;
    public AudioClip[] shootClips;
    [Range(0, 1)] public float shootAudioVolume = 0.5f;
    public GameObject hitEnemy;
    public GameObject hitOther;
    [Range(0.01f, 100f)] public float hitDestroyAfterSeconds = 20;
    public LayerMask WhatToHit;

    private Camera cam;
    private float shootTimer;

    // Start is called before the first frame update
    void Start()
    {
        shootTimer = 0;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && shootTimer >= 1 / fireRate)
        {
            shootTimer = 0;
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        playerAnimator.SetTrigger("Shoot");
        crosshairAnimator?.SetTrigger("Shoot");

        int index = Random.Range(0, shootClips.Length);
        AudioSource.PlayClipAtPoint(shootClips[index], muzzleFlash.transform.position, shootAudioVolume);

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 150, WhatToHit))
        {
            Quaternion rot = Quaternion.LookRotation(hit.normal, Vector3.up);
            GameObject impactClone;
            if (hit.transform.tag == "Enemy")
            {
                impactClone = Instantiate(hitEnemy, hit.point, rot);

                hit.transform.GetComponent<HorrorEnemy>()?.TakeDamage(damage);
            }
            else
            {
                impactClone = Instantiate(hitOther, hit.point, rot);
            }

            Destroy(impactClone, hitDestroyAfterSeconds);
        }
    }
}
