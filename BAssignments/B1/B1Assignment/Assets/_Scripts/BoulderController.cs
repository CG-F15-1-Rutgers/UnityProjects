using UnityEngine;
using System.Collections;

public class BoulderController : MonoBehaviour {
    public Transform objectHit;
    public Camera camera;
    public float speed;
    bool clicked;

    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        clicked = false;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            objectHit = hit.transform;
            print(clicked);
            if (Input.GetMouseButtonDown(0) && clicked == false)
            {

                print("HERE");
                if (objectHit.transform.gameObject.Equals(this.gameObject)) {
                    //print(objectHit.transform.gameObject.name + " GO GO GO!");
                    //print(this.gameObject.name);
                    objectHit = hit.transform;
                    clicked = true;
                }
                    
            
            }
        }
        if (Input.GetMouseButtonDown(0) && clicked == true && !objectHit.transform.gameObject.Equals(this.gameObject))
        {
            print("UNEQUIPPED!");
            clicked = false;
        }
        if (clicked)
        {
            float moveHorizontal = 0;
            float moveVertical = 0;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveHorizontal = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                moveHorizontal = 1;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveVertical = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                moveVertical = -1;
            }
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            print(movement);
            rb.AddForce(movement * speed);
            
        }
    }
}
