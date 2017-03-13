using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {

    private List<Interactive> selections = new List<Interactive>();

    public static MouseManager current;
    
    public MouseManager()
    {
        current = this;
    }
    
	// Update is called once per frame
	void Update () {
        if (!Input.GetMouseButtonDown (0)) {
            return;
        }

        var es = UnityEngine.EventSystems.EventSystem.current;

        if (es != null && es.IsPointerOverGameObject())
        {
            return;
        }

        if (selections.Count > 0)
        {
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {
                foreach (var sel in selections)
                {
                    if (sel != null)
                    {
                        sel.deselect();
                    }
                }

                selections.Clear();
            }
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit))
        {
            return;
        }

        Debug.Log("ray: " + ray.origin);
        Debug.Log("hit: " + hit.transform.position);
        Debug.Log("collider: " + hit.collider);

        var interactive = hit.transform.GetComponent<Interactive>();

        if (interactive == null)
        {
            return;
        }

        Debug.Log("interactive: " + interactive);

        addInteractive(interactive);
        interactive.select();
    }

    public void addInteractive(Interactive interactive)
    {
        selections.Add(interactive);
    }

    public void selectInteractive(Interactive interactive)
    {
        selections.Add(interactive);
        interactive.select();
    }
}
