using UnityEngine;
using System.Collections;

public class ObstacleControl : MonoBehaviour {

    public Transform objectHit;
    public Camera camera;
    public float speed;
    bool clicked;
    private Rigidbody rb;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        clicked = false;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {

            if (Input.GetMouseButtonDown(0))
            {
                clicked = !clicked;
            }
                objectHit = hit.transform;
            
                if (objectHit.tag.ToString().Equals("Obstacle"))
                {
                    print("here we go!");
                    rb = objectHit.transform.gameObject.GetComponent<Rigidbody>();
                    float moveHorizontal = 0;
                    float moveVertical = 0;
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        print("left");
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
                    //rb = GetComponent<Rigidbody>();
                    //rb.AddForce(movement * speed);
                    print(movement);
                    rb.AddForce(movement * speed);
                
            }
        }
        
    }
}
