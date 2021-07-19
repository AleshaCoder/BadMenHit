using UnityEngine;


public struct ChangesInHumanCondition
{
    public int ReputationChange;
    public int HealthChange;

    public ChangesInHumanCondition(int reputationChange, int healthChange)
    {
        ReputationChange = reputationChange;
        HealthChange = healthChange;
    }
}

public abstract class HumanState : ScriptableObject
{
    [SerializeField] private int _reputationChange;
    [SerializeField] private int _healthChange;
    ChangesInHumanCondition changes = new ChangesInHumanCondition();

    public bool Finished { get; protected set; }
    [HideInInspector] public Human Human;

    private void Awake()
    {
        changes = new ChangesInHumanCondition(_reputationChange, _healthChange);
    }

    public virtual void Init()
    {
        Human.AcceptChanges(changes);
    }

    public virtual void Run()
    {
    }
}
