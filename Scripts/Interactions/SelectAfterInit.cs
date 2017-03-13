using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAfterInit : MonoBehaviour {

    public Interactive interactive = null;

	void Start () {
        MouseManager.current.selectInteractive(interactive);
    }
}
