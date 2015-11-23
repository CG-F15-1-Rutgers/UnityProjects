using UnityEngine;
using System.Collections;

public class MouseCam : MonoBehaviour {
    public Camera camera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        camera.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y + 25, Input.mousePosition.z);
	}
}
