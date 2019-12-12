using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoupCan : MonoBehaviour
{
    public GameObject lights;
    public ParticleSystem particles;

    public string angry_soup;
    public string passive_aggressive_soup;

    public TextMeshProUGUI text;
    // Start is called before the first frame update

    public void Grabbed()
    {
        particles.Play();
        lights.GetComponent<Animator>().SetTrigger("angry");
        text.SetText(angry_soup);
    }

    public void Degrabbed()
    {
        lights.GetComponent<Animator>().SetTrigger("not_angry");

        text.SetText(passive_aggressive_soup);
    }
}
