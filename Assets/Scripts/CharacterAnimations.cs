using UnityEngine;

public class CharacterAnimations: MonoBehaviour
{
    public States states;
    private Animator anim;

    public enum States
    {
        Walk,
        Idle
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void DoAnimation(bool Idle, bool Walk)
    {
        anim.SetBool("IsIdle", Idle);
        anim.SetBool("IsWalking", Walk);    
    }

    private void Walk()
    {
        DoAnimation(false, true);
    }
 
    private void Idle()
    {
        DoAnimation(true, false);
    }

    public void Punch()
    {
        anim.SetTrigger("IsPunch");
    }

    private void Update()
    {
        StateSwitch();
    }

    private void StateSwitch()
    {
        switch (states)
        {
            case States.Idle:
                {
                    Idle();
                    break;
                }
            case States.Walk:
                {
                    Walk();
                    break;
                }           
              default:
                {
                    break;
                }          
        }
    }
}