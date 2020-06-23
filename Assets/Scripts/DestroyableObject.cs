using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    [SerializeField] GameObject destroyVersion;
    [SerializeField] int health = 150;

    public void DoDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(destroyVersion, transform.position, transform.rotation);
        }
    }
}
