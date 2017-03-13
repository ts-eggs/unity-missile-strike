using UnityEngine;

public class Interactive : MonoBehaviour {

    private bool _selected = false;

    public bool selected { get { return _selected;  } }
    
    public void select()
    {
        _selected = true;

        foreach(var selection in GetComponents<Interaction>())
        {
            selection.select();
        }
    }

    public void deselect()
    {
        _selected = false;

        foreach (var selection in GetComponents<Interaction>())
        {
            selection.deselect();
        }
    }


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }
}
