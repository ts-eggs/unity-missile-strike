using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapBlip : MonoBehaviour {

    private GameObject _blip;

    public GameObject blip { get { return _blip; } }

	// Use this for initialization
	void Start () {
        _blip = GameObject.Instantiate(Map.current.blipPrefab);
        _blip.transform.SetParent(Map.current.transform);
        var color = GetComponent<Player>().info.accentColor;
        _blip.GetComponent<Image>().color = color;
	}
	
	// Update is called once per frame
	void Update () {
        blip.transform.position = Map.current.WorldPositionToMap(transform.position);
	}

    void OnDestroy()
    {
        GameObject.Destroy(_blip);
    }
}
