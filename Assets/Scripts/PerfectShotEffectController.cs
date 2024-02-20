using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectShotEffectController : MonoBehaviour
{
    public Animator EffectAnimator;
    public GameObject Bow;
    public AudioSource PerfectShotAudioEffect;

    public void PlayAnimation()
    {
        EffectAnimator.SetBool("Perfect", true);
        PerfectShotAudioEffect.Play();
    }

    public void StopAnimation()
    {
        EffectAnimator.SetBool("Perfect", false);
    }


    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.position = Bow.transform.position;    

    }
}
