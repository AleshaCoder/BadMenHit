using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNearestPeople : MonoBehaviour
{
    [HideInInspector] public List<Human> NearestHumen = new List<Human>();
    [HideInInspector] private bool _activeSearch = false;

    public void StartSearching()
    {
        NearestHumen.Clear();
        _activeSearch = true;
    }

    public void StopSearching()
    {
        _activeSearch = false;
    }

    public List<Human> GetCurrentResults()
    {
        return NearestHumen;
    }

    public List<Human> GetResults()
    {
        StopSearching();
        return NearestHumen;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_activeSearch == true)
        {
            if (other.TryGetComponent(typeof(Human), out var behaviour))
            {
                NearestHumen.Add(behaviour as Human);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_activeSearch == true)
        {
            if (other.TryGetComponent(typeof(Human), out var behaviour))
            {
                if (!NearestHumen.Contains(behaviour as Human))
                    NearestHumen.Add(behaviour as Human);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_activeSearch == true)
        {
            if (other.TryGetComponent(typeof(Human), out var behaviour))
            {
                NearestHumen.Remove(behaviour as Human);
            }
        }
    }
}
