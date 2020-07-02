using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAK : Weapon
{
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 30;
    [SerializeField] LayerMask damageLayerMask;
    [SerializeField] ParticleSystem flashFX;

    [Header("Impact Force")]
    [SerializeField] float impactForce = 3f;

    [Header("FX Settings")]
    [SerializeField] GameObject impactEffect;

    

    protected override void Shoot()
    {
        fire = fireRate;

        flashFX.Play();
        //TODO Play Sound

        RaycastHit hit;

        Debug.DrawRay(mainCamera.position, mainCamera.forward * range, Color.red, 10f);
        if (Physics.Raycast(mainCamera.position, mainCamera.forward, out hit, range, damageLayerMask))
        {
            //TODO Use POOL
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce((hit.point - mainCamera.position).normalized * impactForce);
            }

            ITarget target = hit.collider.GetComponent<ITarget>();
            if (target != null)
            {
                target.DoDamage(damage);
            }

            //DestroyableObject destroyable = hit.collider.GetComponent<DestroyableObject>();
            //if (destroyable != null)
            //{
            //    destroyable.DoDamage(damage);
            //}

            //Bomb bomb = hit.collider.GetComponent<Bomb>();
            //if (bomb != null)
            //{
            //    bomb.DoDamage(damage);
            //}
        }
    }
}
