using UnityEngine;
using System.Collections;

public class AgentMover : MonoBehaviour {
    public RaycastHit loc;
    NavMeshAgent agent;
    // Use this for initialization
    void Start () {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        agent.destination = loc.point;
        //print(loc.point);
        this.gameObject.GetComponent<AgentMover>().enabled = false;
    }

    public void setLoc(RaycastHit hit)
    {
        loc = hit;
    }
}
