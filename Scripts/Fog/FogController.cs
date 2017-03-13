using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Camera))]
public class FogController : MonoBehaviour {

    public bool noClearAfterStart = false;

	void Start () {
        GetComponent<Camera>().clearFlags = CameraClearFlags.Color;
	}

    void OnPostRender()
    {
        if(!noClearAfterStart)
        {
            GetComponent<Camera>().clearFlags = CameraClearFlags.Depth;
        }
    }
    
}
