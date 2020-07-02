using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour, ITarget
{
    

    public void DoDamage(int damage)
    {
        Debug.Log("Do Damage!");
    }
}
