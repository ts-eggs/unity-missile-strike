using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerSetupDefinition info;

    public static PlayerSetupDefinition Default;

    void Start()
    {
        info.activeBuildings.Add(this.gameObject);
    }

    void OnDestroy()
    {
        info.activeBuildings.Remove(this.gameObject);
    }
}
