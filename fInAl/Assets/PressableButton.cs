using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableButton : MonoBehaviour
{
    public int method;
    public GameObject text;

    public GameObject soupPrefab;
    public GameObject soupSpawnSpot;

    public GameObject paperPrefab;
    public GameObject paperSpawnSpot;


    public void Pressed()
    {
        this.GetComponent<Animator>().Play("button_pressed");
        if (method == 0)
        {
            SoupButton();
        } else if (method == 2) {
            StackablePaperButton();
        }
    }

    private void SoupButton()
    {
        
    }

    private void StackablePaperButton()
    {

    }
}
