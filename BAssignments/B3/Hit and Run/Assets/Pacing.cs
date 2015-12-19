using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TreeSharpPlus;

public class Pacing : MonoBehaviour
{
    public Transform wander1;
    public Transform wander2;
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


    protected Node dying(Text dialog)
    {
        // dialog.transform.position = new Vector3(participant.transform.position.x, participant.transform.position.y +2, participant.transform.position.z);
        // dialog.text = "AGH!";
        return
            new Sequence(
                      participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("Dying", true),
                       // participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("Reviving", true),
                       new LeafWait(1)
           );

    }


    protected Node bystandard()
    {
        // dialog.transform.position = new Vector3(participant.transform.position.x, participant.transform.position.y + 2, participant.transform.position.z);
        //     dialog.text = "oh!";
        return
            new SelectorShuffle(

           participant.GetComponent<BehaviorMecanim>().Node_HandAnimation("Pointing", true),
           new LeafWait(1000),
           participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("Talking on Phone", true)

           );

    }

    protected Node BuildTreeRoot()
    {
        return

                new DecoratorLoop(
                new Sequence(
                    this.goTo(wander1),
                    //this.dying(dialog),
                    this.goTo(wander2),
                    new LeafWait(1)
                    ));
    }
}
