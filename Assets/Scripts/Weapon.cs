using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform mainCamera;
    [SerializeField] float range = 100f;
    [SerializeField] LayerMask damageLayerMask;
    //[SerializeField] ParticleSystem flashEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //flashEffect.Play();
            //TODO Play Sound

            RaycastHit hit;

            Debug.DrawRay(mainCamera.position, mainCamera.forward * range, Color.red, 10f);
            if (Physics.Raycast(mainCamera.position, mainCamera.forward, out hit, range, damageLayerMask))
            {
                /*
                 * 
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce()
                }
                 * Destroy(hit.collider.gameObject);
                 * 
                 * if hit.GetComponent<Enemy>() != null =>> DoDamage()
                 * 
                 */
            }
        }
    }
}
