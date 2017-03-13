using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public static Map current;

    public RectTransform viewPort;

    public Transform corner1, corner2;

    public GameObject blipPrefab;

    private Vector2 terrainSize;

    private RectTransform mapRect;

    private Vector2 viewPortNorm;

    private float camYNorm = 0;

    public Map()
    {
        current = this;
    }

	// Use this for initialization
	void Start () {
        terrainSize = new Vector2(corner2.position.x - corner1.position.x, corner2.position.z - corner1.position.z);
        mapRect = GetComponent<RectTransform>();
        viewPortNorm = viewPort.sizeDelta;
        camYNorm = Camera.main.transform.position.y;
    }

    public Vector2 WorldPositionToMap(Vector3 point)
    {
        var mapPos = new Vector2(point.x / terrainSize.x * mapRect.rect.width, point.z / terrainSize.y * mapRect.rect.height);
        return mapPos;
    }

    public Vector3 MapPositionToWorld(Vector2 point)
    {
        var worldPos = new Vector3(point.x / mapRect.rect.width * terrainSize.x, 0, point.y / mapRect.rect.height * terrainSize.y);
        return worldPos;
    }
    
    // Update is called once per frame
    void Update () {
        viewPort.position = WorldPositionToMap(Camera.main.transform.position);
        var scrollFactor = Camera.main.transform.position.y / camYNorm;
        viewPort.sizeDelta = new Vector2(viewPortNorm.x * scrollFactor, viewPortNorm.y * scrollFactor);
	}
}
