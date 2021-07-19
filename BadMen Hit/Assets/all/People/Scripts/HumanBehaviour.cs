using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Human))]
public class HumanBehaviour : MonoBehaviour
{
    [HideInInspector] public Human Human;
    public delegate void Action();
    public static Action OnChangeHumanState;

    public HumanState WalkState;
    public HumanState IdleState;
    public HumanState HitState;
    public HumanState DeadState;

    private HumanState _currentState;

    private void SetState(HumanState humanState)
    {
        OnChangeHumanState?.Invoke();
        _currentState = Instantiate(humanState);
        _currentState.Human = Human;
        _currentState.Init();
    }

    private void SelectNewState()
    {
        if (Random.Range(0, 100) > 40)
            SetState(IdleState);
        else if (Random.Range(0, 100) > 20)
            SetState(WalkState);
        else SetState(HitState);
    }

    private void RunState() => _currentState.Run();

    private void SelectStartState() => SetState(IdleState);

    private void Awake()
    {
        Human = GetComponent(typeof(Human)) as Human;
        SelectStartState();
    }

    private void Update()
    {
        Human.Health -= Time.deltaTime;
        if (Human.CanUseBehaviour == true)
        {
            if (Human.Health <= 0)
                SetState(DeadState);
            else if (_currentState.Finished)
                SelectNewState();
            else
                RunState();
        }
        else
            SelectStartState();
    }
}
