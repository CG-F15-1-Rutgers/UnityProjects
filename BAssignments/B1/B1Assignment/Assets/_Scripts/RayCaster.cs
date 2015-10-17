using UnityEngine;
using System.Collections;

public class RayCaster : MonoBehaviour
{
    public Camera camera;
    bool firstClick, secondClick;
    NavMeshAgent agent;
    public Transform objectHit;

    void Start()
    {
        firstClick = false;
        secondClick = false;

    }
    void Update()
    {
        RaycastHit hit;
        //Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            objectHit = hit.transform;
            //print(objectHit);
            // Do something with the object that was hit by the raycast.
            //camera.transform.Translate(objectHit.position, Space.World);
            if (Input.GetMouseButtonDown(0))
            {
                if (objectHit.tag.ToString().Equals("Agent") && firstClick ==false)
                {
                   // collisionObj = hit.transform;
                    print("DETECTED AGENT!");
                    agent = objectHit.gameObject.GetComponent<NavMeshAgent>();
                    firstClick = true;
                }
                else if (firstClick == true && secondClick == false)
                {
                    agent.destination = hit.point;
                    print(hit.point);
                    secondClick = true;
                }
                else
                {
                    firstClick = false;
                    secondClick = false;
                    
                }
            }
        }
    }

}
