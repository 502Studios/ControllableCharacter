using net.fiveotwo.controllableCharacter;
using UnityEngine;

public class CharacterAnimationController : CharacterAction
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private CharacterAim characterAim;

    public override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterAim = GetComponent<CharacterAim>();
    }

    public override void UpdateAction()
    {
        if (!active)
        {
            return;
        }

        if (Mathf.Abs(characterAim.AimingDirection().x) > Mathf.Epsilon)
        {
            spriteRenderer.flipX = characterAim.AimingDirection().x > 0 ? false : true;
        }

        if (!controllableCharacter.GetStateMachine().GetCurrentState().Equals(CharacterState.jumping))
        {
            if (Mathf.Abs(controllableCharacter.GetVelocity().x) > 1f)
            {
                animator.Play("Walk");
            } else
            {
                if (characterAim.AimingDirection().y > 0)
                {
                    animator.Play("AimUpwards");
                } else
                {
                    animator.Play("Idle");
                }
            }
        } else {
            if (characterAim.AimingDirection().y > 0)
            {
                animator.Play("AimUpwardsJump");
            } else
            {
                animator.Play("Jump");
            }
        }
    }
}
