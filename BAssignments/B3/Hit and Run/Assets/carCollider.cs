using UnityEngine;
using System.Collections;

public class carCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Jay") == true)
        {

            Debug.Log("Collision detected2");
        }
    }

}
