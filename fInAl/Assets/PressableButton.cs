using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableButton : MonoBehaviour
{
    public int method;
    public GameObject text;

    public void Pressed()
    {
        this.GetComponent<Animator>().Play("button_pressed");
        if (method == 0)
        {
            Soup_Button();
        }
        TextButton();
    }

    private void Soup_Button()
    {

    }

    private void TextButton() {
        text.SetActive(!text.activeSelf);
    }
}
