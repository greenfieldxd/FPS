using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour
{
    [SerializeField] Transform target;


    void Update()
    {
        transform.LookAt(target.position);
    }
}
