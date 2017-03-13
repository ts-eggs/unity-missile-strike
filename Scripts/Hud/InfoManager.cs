using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour {

    public static InfoManager current;

    public Image profileImage;

    public Text line1, line2, line3;

    public InfoManager()
    {
        current = this;
    }

    public void setLines(string l1, string l2, string l3)
    {
        line1.text = l1;
        line2.text = l2;
        line3.text = l3;

        if(!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }

    public void clearLines()
    {
        setLines("", "", "");
    }

    public void setImage(Sprite img)
    {
        profileImage.sprite = img;
        profileImage.color = Color.white;
        
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }

    public void clearImage()
    {
        profileImage.color = Color.clear;
    }

    public void clear()
    {
        clearLines();
        clearImage();
        gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () {
        clear();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
