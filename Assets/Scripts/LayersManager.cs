using UnityEngine;

public class LayersManager : MonoBehaviour
{
    private static LayersManager _instance;
    private int _player;
    private int _springBarrel;

    public static LayersManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LayersManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("LayersManager");
                    _instance = container.AddComponent<LayersManager>();
                    _instance.InitializeManager();
                }
            }

            return _instance;
        }
    }

    private void InitializeManager()
    {
        _player = LayerMask.NameToLayer("Player");
        _springBarrel = LayerMask.NameToLayer("SpringBarrel");
    }

    public static int GetPlayer()
    {
        return Instance._player;
    }

    public static int GetSpringBarrel()
    {
        return Instance._springBarrel;
    }
}