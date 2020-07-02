using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, ITarget
{
    [SerializeField] int health = 100;
    [SerializeField] float explosionRadius = 5f;
    [SerializeField] float explosionForce = 2000f;
    [SerializeField] int explosionDamage = 150;
    [SerializeField] float yForce = 10f;
    [SerializeField] LayerMask explosionLayerMask;


    public void DoDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            Explode();
        }
    }


    private void Explode()
    {
        //TODO play sound
        //TODO play FX
        

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, explosionLayerMask);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, yForce);
            }

            ITarget target = collider.GetComponent<ITarget>();

            if (target != null)
            {
                target.DoDamage(explosionDamage);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
