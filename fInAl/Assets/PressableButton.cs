using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableButton : MonoBehaviour
{
    public int method;
    public GameObject soup;

    public void Pressed()
    {
        this.GetComponent<Animator>().Play("button_pressed");
        if (method == 0)
        {
            Soup_Button();
        }
    }

    private void Soup_Button()
    {
        soup.SetActive(!soup.activeSelf);
    }
}
