using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBehavior : MonoBehaviour {

    public abstract Action getClickAction();

    public Sprite buttonImage;

    internal bool showOnSelect = false;
}
