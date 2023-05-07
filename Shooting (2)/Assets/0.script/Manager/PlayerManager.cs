using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField]
    Player player;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    
}
