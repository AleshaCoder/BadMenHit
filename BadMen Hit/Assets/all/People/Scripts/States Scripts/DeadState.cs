using UnityEngine;

[CreateAssetMenu]
public class DeadState : HumanState
{
    private float _durationOfDeath = 1.2f;
    private float _durationOfConcealment = 2f;
    private bool _died = false;

    public override void Init()
    {
        base.Init();
        Human.Animator.SetInteger("State", 2);
        Dead();
    }

    private void Dead()
    {
        Destroy(Human.gameObject, Human.Animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
