using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionsManager : MonoBehaviour {

    public static ActionsManager current;

    public Button[] buttons;

    private List<Action> actionCalls = new List<Action>();

    public ActionsManager()
    {
        current = this;
    }

    public void clearButtons()
    {
        foreach(var b in buttons)
        {
            b.gameObject.SetActive(false);
        }

        actionCalls.Clear();
    }

    public void addPlayerButtons()
    {
        foreach (var b in Player.Default.availableBuildings)
        {
            var ab = b.GetComponent<CreateBuildingAction>();
            addButton(ab.buttonImage, ab.getClickAction());
        }
    }

    public void addButton(Sprite image, Action onClick)
    {
        int index = actionCalls.Count;
        buttons[index].gameObject.SetActive(true);
        buttons[index].GetComponent<Image>().sprite = image;
        actionCalls.Add(onClick);
    }

    public void onButtonClick(int index)
    {
        actionCalls[index]();
    }

	// Use this for initialization
	void Start () {
        for (int i = 0; i < buttons.Length; i++)
        {
            var index = i;
            buttons[index].onClick.AddListener(delegate ()
            {
                onButtonClick(index);
            });
        }

        clearButtons();
        addPlayerButtons();
    }
	
}
