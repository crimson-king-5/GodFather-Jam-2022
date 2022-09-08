using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCaller : MonoBehaviour
{
    private Animator anim;
    public GameObject Killer;
    private void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetMouseButtonDown("Animation"))
        {
            Killer.GetComponent<Animator>().Play("Anim name");
        }*/
            
    }
}
