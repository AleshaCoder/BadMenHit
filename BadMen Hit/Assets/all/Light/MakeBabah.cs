using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FindNearestPeople))]
public class MakeBabah : MonoBehaviour
{
    public Animator BabahAnimator;

    private bool _touchDown = false;

    private FindNearestPeople _findNearestPeople;
    private List<HumanBehaviour> _humansInLightZone = new List<HumanBehaviour>();

    private void KillHumenAfterAnimation()
    {
        foreach (var human in _findNearestPeople.GetResults())
        {
            human.DieOfLightning();
        }
    }

    private void Awake()
    {
        _findNearestPeople = GetComponent(typeof(FindNearestPeople)) as FindNearestPeople;
    }

    private void Update()
    {
        if (Menu.Active == false)
        {
            if ((Input.touchCount == 1) || (Input.GetMouseButtonDown(0)))
            {
                if (_touchDown == false)
                {
                    BabahAnimator.SetTrigger("babah");
                }
                _touchDown = true;
            }
            else if ((Input.touchCount == 0) || (Input.GetMouseButtonUp(0)))
            {
                _touchDown = false;
            }
        }
    }
}
