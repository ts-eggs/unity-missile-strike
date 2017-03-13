using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Manager : MonoBehaviour {

    public static Manager current = null;

    public List<PlayerSetupDefinition> players = new List<PlayerSetupDefinition>();
    
    public TerrainCollider mapCollider;

    public TerrainData terrain;

    public GameObject fog = null;

    public bool showFog = true;

    public Vector3? ScreenPointToMapPosition(Vector2 point)
    {
        var ray = Camera.main.ScreenPointToRay(point);
        RaycastHit hit;

        if(!mapCollider.Raycast(ray, out hit, Mathf.Infinity))
        {
            return null;
        }

        return hit.point;
    }

    public bool isMissileSaveToLaunch(GameObject missile)
    {
        return true;
    }

    public bool isGameObjectSaveToPlace(GameObject go)
    {
        var verts = go.GetComponent<MeshFilter>().mesh.vertices;
        var obstacles = GameObject.FindObjectsOfType<NavMeshObstacle>();
        var cols = new List<Collider>();

        foreach (var t in terrain.treeInstances)
        {
            if(go.GetComponent<Collider>().bounds.Contains(Vector3.Scale(t.position, terrain.size)))
            {
                return false;
            }
        }

        foreach(var o in obstacles)
        {
            if (o.gameObject != go)
            {
                cols.Add(o.gameObject.GetComponent<Collider>());
            }
        }

        foreach(var v in verts)
        {
            NavMeshHit hit;
            var vReal = go.transform.TransformPoint(v);
            NavMesh.SamplePosition(vReal, out hit, 20, NavMesh.AllAreas);

            bool onXAxis = Mathf.Abs(hit.position.x - vReal.x) < 1.5f;
            bool onZAxis = Mathf.Abs(hit.position.z - vReal.z) < 1.5f;
            bool hitCollider = cols.Any(c => c.bounds.Contains(vReal));

            if(!onXAxis || !onZAxis || hitCollider)
            {
                return false;
            }
        }

        return true;
    }

	// Use this for initialization
	void Start () {
        current = this;

        foreach(var p in players)
        {
            if (!p.isAi && Player.Default == null)
            {
                Player.Default = p;
            }

            if(p.isAi)
            {
                var aiController = gameObject.AddComponent<AiController>();
                aiController.playerInfo = p;
            }
        }

        if(!showFog)
        {
            fog.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
    }
}
