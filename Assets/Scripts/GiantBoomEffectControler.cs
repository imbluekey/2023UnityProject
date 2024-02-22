using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantBoomEffectControler : MonoBehaviour
{
    public Animator EffectAnimator;
    public GameObject Giant;
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
        
        gameObject.transform.position = Giant.transform.position;    

    }
}
