using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateExemple : MonoBehaviour
{
    public Animation Animation;
    public AnimationClip idle;
    public AnimationClip run;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayAnimation(run);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            PlayAnimation(idle);
        }
    }

    private void PlayAnimation(AnimationClip c)
    {
        Animation.clip = c;
        Animation.CrossFade(c.name);

    }
}
