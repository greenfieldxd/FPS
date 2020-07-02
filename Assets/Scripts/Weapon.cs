using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform mainCamera;
    [SerializeField] protected AudioSource shootAudioSource;
    [SerializeField] protected AudioClip shootSound;

    [SerializeField] protected int maxAmmo;
    [SerializeField] protected float fireRate = 0.3f;

    protected float fire;
    protected int ammo;

    void Start()
    {
        fire = fireRate;
        ammo = maxAmmo;
    }

    void Update()
    {
        fire -= Time.deltaTime;

        if (Input.GetButton("Fire1") && fire < 0)
        {

            if (ammo > 0)
            {
                shootAudioSource.PlayOneShot(shootSound);
                Shoot();
                ammo--;
            }
        }
    }


    protected abstract void Shoot();

}
