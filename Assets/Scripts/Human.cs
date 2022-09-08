using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public enum HumaneNature
    {
        OldHuman,
        Adult,
        Baby
    }

    private HumaneNature _nature;
    private void Start()
    {
        
    
    int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                _nature = HumaneNature.OldHuman;
                break;
            case 1:
                _nature = HumaneNature.Adult;
                break;
            case 2:
                _nature = HumaneNature.Baby;
                break;
        }
    }
}
