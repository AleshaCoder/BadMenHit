using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HumanBehaviour), typeof(Animator))]

public class Human : MonoBehaviour
{
    public float Health = 100;
    public float Reputation = 0;

    [SerializeField] private SpriteRenderer HumanReputationIndicator;

    [HideInInspector] public Planet Planet;
    [HideInInspector] public Animator Animator;
    [HideInInspector] public FindNearestPeople FindNearestPeople;
    [HideInInspector] public bool CanUseBehaviour => !Menu.Active;

    public void DieOfLightning()
    {
        Health = 0;
    }

    public void GetDamage(float damage)
    {
        Health -= damage;
    }

    public void AcceptChanges(ChangesInHumanCondition changes)
    {
        Health += changes.HealthChange;
        Reputation += changes.ReputationChange;
        if (Reputation < -50)
            HumanReputationIndicator.color = Color.red;
        else if (Reputation < -10)
            HumanReputationIndicator.color = Color.yellow;
        else
            HumanReputationIndicator.color = Color.green;
    }

    private void Awake()
    {
        Animator = GetComponent(typeof(Animator)) as Animator;
        Planet = FindObjectOfType(typeof(Planet)) as Planet;
        FindNearestPeople = GetComponent(typeof(FindNearestPeople)) as FindNearestPeople;
    }
}
