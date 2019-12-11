using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableTarget : Selectable
{
    [SerializeField]
    private Material def, selected;
    private bool isHit = false;
    public Animator anim;
    public int TriggerNum;
    public AudioSource sound;


    // Start is called before the first frame update
    public override GameObject OnHit()
    {
        Debug.Log("Hit");
        anim.SetInteger("Trigger", 1);
        isHit = true;
        sound.Play();
    }

    public override GameObject OnMiss()
    {
        Debug.Log("Miss");
        anim.SetInteger("Trigger", 2);
        isHit = false;
    }
}
