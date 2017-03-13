using UnityEngine;
using UnityEngine.AI;

public class RightClickNavigation : Interaction
{
    public float RelaxDistance = 2;

    public float speed = 10;

    public float acceleration = 2;

    public bool fly = false;

    public float flyBreakingDistance = 10;

    private NavMeshAgent agent;

    private Vector3 target = Vector3.zero;

    private bool selected = false;

    private bool isActive = false;

    private bool isBreaking = false;

    private float flySpeed = 0;

    private float flyFactor = 0.02f;

    public override void deselect()
    {
        selected = false;
    }

    public override void select()
    {
        selected = true;
    }

    public void SendToTarget(Vector3 pos)
    {
        target = pos;
        SendToTarget();
    }

    public void SendToTarget()
    {

        Debug.Log("send fly: " + fly);

        if (!fly)
        {
            agent.SetDestination(target);
            agent.Resume();
        }

        flySpeed = 0;
        isActive = true;
        isBreaking = false;
    }

    // Use this for initialization
    void Start()
    {
        if(!fly)
        {
            agent = GetComponent<NavMeshAgent>();
            agent.speed = speed;
            agent.acceleration = acceleration;
        } else {
            Vector3 pos = transform.position;
            pos.y = 7;
            transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (selected && Input.GetMouseButtonDown(1))
        {
            var tempTarget = Manager.current.ScreenPointToMapPosition(Input.mousePosition);

            if (tempTarget.HasValue)
            {
                target = tempTarget.Value;
                SendToTarget();
            }
        }
        
        if (isActive && Vector3.Distance(target, transform.position) < (fly ? Mathf.Abs(speed * flyFactor * 3) : RelaxDistance))
        {
            if (!fly)
            {
                agent.Stop();
            }

            isActive = false;
        }

        if(isActive && fly)
        {
            var localSpeed = (speed * flyFactor);
            var localAcceleration = (acceleration * flyFactor);

            if(isBreaking && flySpeed > 1)
            {
                flySpeed -= localAcceleration;
            }
            else if (flySpeed < localSpeed)
            {
                flySpeed += localAcceleration;

                if(flySpeed > localSpeed)
                {
                    flySpeed = localSpeed;
                }
            }

            Vector3 pos = transform.position;

            float xWay = target.x - pos.x;
            float zWay = target.z - pos.z;

            var xSpeed = xWay > 0 ? flySpeed : -flySpeed;
            var zSpeed = zWay > 0 ? flySpeed : -flySpeed;
            
            if (Mathf.Abs(xWay) > Mathf.Abs(zWay))
            {
                zSpeed *= Mathf.Abs(zWay) / Mathf.Abs(xWay);
            }
            else
            {
                xSpeed *= Mathf.Abs(xWay) / Mathf.Abs(zWay);
            }

            if (Mathf.Abs(xWay) < Mathf.Abs(xSpeed) && Mathf.Abs(zWay) < Mathf.Abs(zSpeed))
            {
                isActive = false;
                return;
            }

            pos.x += xSpeed;
            pos.z += zSpeed;
            transform.position = pos;

            if(!isBreaking && Vector3.Distance(target, transform.position) < flyBreakingDistance)
            {
                isBreaking = true;
            }
        }
    }
}
