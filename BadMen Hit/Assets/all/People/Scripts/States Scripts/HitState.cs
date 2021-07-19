using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class HitState : HumanState
{
    private float _timeOfAttack = 1.0f;
    private float _damage = 20.0f;
    private bool _startedAttack = false;
    private List<Human> _humen = new List<Human>();

    public override void Init()
    {
        base.Init();
        Human.Animator.SetInteger("State", 0);
        Human.FindNearestPeople.StartSearching();
    }

    public override void Run()
    {
        if (_startedAttack == false)
            CheckNearestPeople();
        else
            _timeOfAttack -= Time.deltaTime;

        if (_timeOfAttack <= 0.01f)
            StopAttack();
    }

    private void CheckNearestPeople()
    {
        _humen = Human.FindNearestPeople.GetCurrentResults();

        if (_humen.Count > 0)
            StartAttack();
    }

    private void StartAttack()
    {
        Human.Animator.SetInteger("State", 3);
        _humen[0].GetDamage(_damage);
        _startedAttack = true;
    }

    private void StopAttack()
    {
        Human.FindNearestPeople.StopSearching();
        _timeOfAttack = 1.0f;
        _humen.Clear();
        _startedAttack = false;
        Finished = true;
    }
}
