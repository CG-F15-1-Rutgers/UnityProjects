using UnityEngine;
using System.Collections;

public class AgentMover : MonoBehaviour {
    public RaycastHit loc;
    NavMeshAgent agent;

    [System.NonSerialized]
    public float lookWeight;                    // the amount to transition when using head look

    [System.NonSerialized]
    public Transform enemy;                     // a transform to Lerp the camera to during head look

    public float animSpeed = 100f;              // a public setting for overall animator animation speed
    public float lookSmoother = 3f;             // a smoothing setting for camera motion
    public bool useCurves;                      // a setting for teaching purposes to show use of curves


    private Animator anim;                          // a reference to the animator on the character
    private AnimatorStateInfo currentBaseState;         // a reference to the current state of the animator, used for base layer
    private AnimatorStateInfo layer2CurrentState;   // a reference to the current state of the animator, used for layer 2
    private CapsuleCollider col;                    // a reference to the capsule collider of the character


    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int locoState = Animator.StringToHash("Base Layer.Locomotion");          // these integers are references to our animator's states
    static int jumpState = Animator.StringToHash("Base Layer.Jump");                // and are used to check state for various actions to occur
    static int jumpDownState = Animator.StringToHash("Base Layer.JumpDown");        // within our FixedUpdate() function below
    static int fallState = Animator.StringToHash("Base Layer.Fall");
    static int rollState = Animator.StringToHash("Base Layer.Roll");
    static int waveState = Animator.StringToHash("Layer2.Wave");

    // Use this for initialization
    void Start () {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        anim = this.gameObject.GetComponent<Animator>();
        col = this.gameObject.GetComponent<CapsuleCollider>();

        if (anim.layerCount == 2)
            anim.SetLayerWeight(1, 1);
    }
	
	// Update is called once per frame
	void Update () {

        agent.destination = loc.point;
        anim.SetFloat("Speed", 100f);		
        anim.SetFloat("Direction", 100f);

        anim.speed = animSpeed;
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	// set our currentState variable to the current state of the Base Layer (0) of animation
        //print(loc.point);
        this.gameObject.GetComponent<AgentMover>().enabled = false;
    }

    public void setLoc(RaycastHit hit)
    {
        loc = hit;
    }
}
