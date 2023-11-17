using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeteManeger : MonoBehaviour
{
    public Animator animator;
    public List<animatorSetup> animatorSetups;
    public enum AnimationType
    {
        IDLE,
        RUN,
        DEAD
    }
    
    public void Play(AnimationType type, float correntSpeedFactor = 1f)
    {
        foreach (var animation in animatorSetups)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                animator.speed = animation.speed * correntSpeedFactor;
                break;
            }
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
          Play(AnimationType.RUN);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            Play(AnimationType.DEAD);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            Play(AnimationType.IDLE);
        }
    }


}


[System.Serializable]
public class animatorSetup
{
    public AnimeteManeger.AnimationType type;
    public string trigger;
    public float speed = 1f; 
}