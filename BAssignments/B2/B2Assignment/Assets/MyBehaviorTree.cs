using UnityEngine;
using System.Collections;
using TreeSharpPlus;

public class MyBehaviorTree : MonoBehaviour
{
	public Transform wander1;
	public Transform wander2;
	public Transform wander3;
	public GameObject participant1;
    public GameObject participant2;
    public GameObject participant3;

    private BehaviorAgent behaviorAgent;
	// Use this for initialization
	void Start ()
	{
		behaviorAgent = new BehaviorAgent (this.BuildTreeRoot ());
		BehaviorManager.Instance.Register (behaviorAgent);
		behaviorAgent.StartBehavior ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	protected Node ST_ApproachAndWait(Transform target)
	{
   
            Val<Vector3> position = Val.V(() => target.position);
        return new SelectorShuffle(
            new SelectorParallel(
           participant1.GetComponent<BehaviorMecanim>().Node_GoTo(position),
           participant2.GetComponent<BehaviorMecanim>().Node_GoTo(position)),
           participant3.GetComponent<BehaviorMecanim>().Node_HandAnimation("Cheer", true)
          , new LeafWait(1000)
                    );
      
	}


    protected Node BuildTreeRoot()
	{
		return
			new DecoratorLoop(
				new SelectorShuffle(
                    
					this.ST_ApproachAndWait(this.wander1),
					this.ST_ApproachAndWait(this.wander2),
					this.ST_ApproachAndWait(this.wander3)));
	}
}
