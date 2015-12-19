using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interact : MonoBehaviour {


    public bool enter;
    //  NavMeshAgent agent;
    public Transform objectHit;
    //    public ArrayList agents;
    public GameObject deadman;
    public GameObject ghost;
    public Text dialog;

    void Start()
    {
        dialog.text = "";
        this.ghost.SetActive(false);
        this.deadman.SetActive(true);
        this.enter = false;
        //    agents = new ArrayList();

    }

    void OnTriggerEnter(Collider other)
    {
        //print("ColliderR");

        if (other.CompareTag("Jay"))
        {
            this.enter = true;
        }
    }

    void OnTriggernExit(Collider other)
    {
        this.enter = false;
    }
    void Update()
    {
        /*
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            objectHit = hit.transform;
            */
        
        if (Input.GetKey(KeyCode.R) == true && enter == true)
        {
            dialog.text = "YOU REVIVED HIM!";
            this.ghost.SetActive(true);
            this.deadman.SetActive(false);
            //selecting agents


            //objectHit.gameObject.GetComponent<AgentMover>().enabled = true;
            print("KeyPRessed R");
            //objectHit.gameObject.GetComponent<AgentMover>().loc = hit;
            //print(hit.transform);
            //   agents.Add(objectHit.gameObject);
            //agent = objectHit.gameObject.GetComponent<NavMeshAgent>();



            // }
        }
        else if (Input.GetKey(KeyCode.B) == true && enter == true && ghost.active == true)
        {
            dialog.text = "HE'S BREAKDANCING BACK TO LIFE!";
            ghost.GetComponent<Dance>().enabled = true;
            //selecting agents


            //objectHit.gameObject.GetComponent<AgentMover>().enabled = true;
            print("KeyPRessed R");
            //objectHit.gameObject.GetComponent<AgentMover>().loc = hit;
            //print(hit.transform);
            //   agents.Add(objectHit.gameObject);
            //agent = objectHit.gameObject.GetComponent<NavMeshAgent>();



            // }
        }
    }
}
