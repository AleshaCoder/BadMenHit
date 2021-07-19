using UnityEngine;
[CreateAssetMenu]
public class IdleState : HumanState
{
    private float _time = 2.1f;

    public override void Init()
    {
        base.Init();
        Human.Animator.SetInteger("State", 0);
    }

    public override void Run()
    {
        if (Finished)
            return;
        if (_time <= 0)
            Finished = true;
        _time -= Time.deltaTime;
    }
}
