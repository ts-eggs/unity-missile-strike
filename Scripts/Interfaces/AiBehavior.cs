using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiBehavior : MonoBehaviour {

    public abstract float getWeight();

    public abstract void execute(PlayerSetupDefinition info);

    public float weightMultiplier = 1;

    public float timePassed = 0;

    public bool obsolete = false;
}
