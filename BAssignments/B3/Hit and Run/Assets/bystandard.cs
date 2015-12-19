using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TreeSharpPlus;

public class bystandard : MonoBehaviour
{
    public Transform wander1;
    public GameObject participant;
    //   public Text dialog;


    private BehaviorAgent behaviorAgent;
    // Use this for initialization
    void Start()
    {
        behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
        BehaviorManager.Instance.Register(behaviorAgent);
        behaviorAgent.StartBehavior();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected Node goTo(Transform target)
    {

        Val<Vector3> position = Val.V(() => target.position);

        return
          new Sequence(
                    participant.GetComponent<BehaviorMecanim>().Node_GoTo(position),

                     new LeafWait(1)
         );

    }


    protected Node bystand()
    {
        // dialog.transform.position = new Vector3(participant.transform.position.x, participant.transform.position.y + 2, participant.transform.position.z);
        //     dialog.text = "oh!";
        return
            new SelectorShuffle(

           participant.GetComponent<BehaviorMecanim>().Node_HandAnimation("Pointing", true),
           
           participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("Talking on Phone", true)

           );

    }

    protected Node BuildTreeRoot()
    {
        return

                new DecoratorLoop(
                new Sequence(
                    new LeafWait(10000),
                    this.goTo(wander1),
                    this.bystand()
                    ));
    }
}
