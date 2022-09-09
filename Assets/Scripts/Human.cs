using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public enum HumaneNature
    {
        Blue,
        Green,
        Red
    }

    public GameObject chirt;
    public HumaneNature humaneNature = HumaneNature.Blue;

    private void Start()
    {
        humanchoice();
    }
   public void humanchoice()
    {
        int count = HumanManager.instance.counter;
        switch (count)
        {
            case 0:
                humaneNature = HumaneNature.Blue;
                chirt.GetComponent<Renderer>().materials[1].color = HumanManager.instance.RandomColor(0);
                break;
            case 1:
                humaneNature = HumaneNature.Green;
                chirt.GetComponent<Renderer>().materials[1].color = HumanManager.instance.RandomColor(1);
                break;
            case 2:
                humaneNature = HumaneNature.Red;
                chirt.GetComponent<Renderer>().materials[1].color = HumanManager.instance.RandomColor(2);
                break;
        }

        if (count > 2)
            HumanManager.instance.counter = 0;
        else
            HumanManager.instance.counter++;
    }

}
