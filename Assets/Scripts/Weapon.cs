using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform mainCamera;
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 30;
    [SerializeField] float fireRate = 0.3f;
    [SerializeField] LayerMask damageLayerMask;
    [SerializeField] Transform flashFXPos;

    [Header("Impact Force")]
    [SerializeField] float impactForce = 3f;

    [Header("FX Settings")]
    [SerializeField] GameObject flashEffect;
    [SerializeField] GameObject impactEffect;

    private float fire;

    // Start is called before the first frame update
    void Start()
    {
        flashEffect.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
        fire = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        fire -= Time.deltaTime;

        if (Input.GetButton("Fire1") && fire < 0)
        {
            fire = fireRate;

            Instantiate(flashEffect, flashFXPos.position, Quaternion.identity);
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

                DestroyableObject destroyable = hit.collider.GetComponent<DestroyableObject>();
                if (destroyable != null)
                {
                    destroyable.DoDamage(damage);
                }

                Bomb bomb = hit.collider.GetComponent<Bomb>();
                if (bomb != null)
                {
                    bomb.DoDamage(damage);
                }
            }
        }
    }
}
