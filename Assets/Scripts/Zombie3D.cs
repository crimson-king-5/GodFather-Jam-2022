using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie3D : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            //attack
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            //lose pv
        }
    }
}