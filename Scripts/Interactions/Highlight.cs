using UnityEngine;

public class Highlight : Interaction {

    public GameObject displayItem;
    
    public override void deselect()
    {
        displayItem.SetActive(false);
    }

    public override void select()
    {
        displayItem.SetActive(true);
    }

    // Use this for initialization
    void Start ()
    {
        displayItem.SetActive(false);
    }
}
