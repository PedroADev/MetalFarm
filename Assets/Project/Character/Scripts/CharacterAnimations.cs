using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SkeletonMecanim skeletonMecanim;
    
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Speed = Animator.StringToHash("Speed");

    public void CallAnimation(string trigger)
    {
        animator.SetTrigger(trigger);
    }
    
    public void SetMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat(Horizontal, horizontal);
        animator.SetFloat(Vertical, vertical);
    }

    public void SetIdleMovement(float speed)
    {
        animator.SetFloat(Speed, speed);
    }
    
    public void ChangeSkinByHeldItem(CharacterHeldData heldData)
    {
        var skin = heldData.currentHeldItem == null || string.IsNullOrEmpty(heldData.currentHeldItem.skinName)
            ? skeletonMecanim.initialSkinName
            : heldData.currentHeldItem.skinName;

        skeletonMecanim.skeleton.SetSkin(skin);
        skeletonMecanim.skeleton.SetSlotsToSetupPose();
    }

    public void PlayInteractionAnimation(CharacterHeldData heldData)
    {
        if(heldData.currentHeldItem == null || string.IsNullOrEmpty(heldData.currentHeldItem.animationName))
        {
            return;
        }
        
        animator.SetTrigger(heldData.currentHeldItem.animationName);
    }
}
