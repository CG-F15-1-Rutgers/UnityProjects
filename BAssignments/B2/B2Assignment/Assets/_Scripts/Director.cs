using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {
    public Camera camera;
    bool firstClick, secondClick;
    NavMeshAgent agent;
    public Transform objectHit;
    public ArrayList agents;

    void Start()
    {
        firstClick = false;
        secondClick = false;
        agents = new ArrayList();

    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            objectHit = hit.transform;
            if (Input.GetMouseButtonDown(0))
            {
                //selecting agents
                if (objectHit.tag.ToString().Equals("Agent"))
                {
                    
                    //objectHit.gameObject.GetComponent<AgentMover>().enabled = true;
                    print("Agent queued");
                    //objectHit.gameObject.GetComponent<AgentMover>().loc = hit;
                    //print(hit.transform);
                    agents.Add(objectHit.gameObject);
                    //agent = objectHit.gameObject.GetComponent<NavMeshAgent>();
                    firstClick = true;
                }
                else if (firstClick == true)
                {
                    //agent.destination = hit.point;
                    print("Deploying!");
                    foreach (GameObject obj in agents)
                    {
                        obj.GetComponent<AgentMover>().setLoc(hit);
                        obj.GetComponent<AgentMover>().enabled = true;
                    }
                    agents.Clear();
                    firstClick = false;
                }
            }
        }
    }

}
