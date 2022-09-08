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
    [HideInInspector]public HumaneNature humaneNature = HumaneNature.OldHuman;
    List<HumaneNature> ListHumanNature = new List<HumaneNature>();

    private void Start()
    {
        ListHumanNature.Add(HumaneNature.Adult);
        ListHumanNature.Add(HumaneNature.Baby);
        ListHumanNature.Add(HumaneNature.OldHuman);

        humanchoice();
    }
   public void humanchoice()
    {
        int counter = 0;
        switch (counter)
        {
            case 0:
                humaneNature = HumaneNature.OldHuman;
                break;
            case 1:
                humaneNature = HumaneNature.Adult;
                break;
            case 2:
                humaneNature = HumaneNature.Baby;
                break;
        }
        counter++;
    }

}
