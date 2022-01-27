using System.Collections.Generic;
using UnityEngine;

public class BarrelsManager : MonoBehaviour
{
    private static BarrelsManager _instance;
    private int _activeBarrels;
    private List<BarrelScript> _barrels = new List<BarrelScript>();


    public static BarrelsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<BarrelsManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("BarrelsManager");
                    _instance = container.AddComponent<BarrelsManager>();
                }
            }

            return _instance;
        }
    }

    public void BarrelActive(bool active)
    {
        if (active)
        {
            _activeBarrels++;
        }
        else
        {
            _activeBarrels--;
        }

        AddScore();
    }

    public void RegisterBarrel(BarrelScript barrel)
    {
        _barrels.Add(barrel);
    }

    private void AddScore()
    {
        if (_activeBarrels == _barrels.Count)
        {
            ScoreManager.Instance.AddScore(1000);
            foreach (var barrel in _barrels)
            {
                barrel.LightOff();
            }

            _activeBarrels = 0;
        }
    }
}