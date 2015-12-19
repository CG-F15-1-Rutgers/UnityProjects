using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TreeSharpPlus;

public class JayWalker : MonoBehaviour
{
    public Transform wander1;
    public GameObject participant;
    public Text dialog;
    public int hitStatus;

    private BehaviorAgent behaviorAgent;
    // Use this for initialization
    void Start()
    {
        dialog.text = "It's unwise to jaywalk across a busy street. Someone could get hurt!";
        hitStatus = 0;
        behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
        BehaviorManager.Instance.Register(behaviorAgent);
        behaviorAgent.StartBehavior();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        hitStatus = 0;
        Debug.Log("Collision detected");
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


    protected Node dying()
    {

        Debug.Log("dead");
        //   dialog.transform.position = new Vector3(participant.transform.position.x, participant.transform.position.y + 2, participant.transform.position.z);
       // dialog.text = "AGH!";
        return
            // new DecoratorLoop(
            //new DecoratorForceStatus(RunStatus.Success,
            new Sequence(

                    participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("Dying", true),

                     new LeafWait(1)
         );
        //);

    }

    protected Node reviving()
    {
        Debug.Log("UNDEAD");
        //   dialog.transform.position = new Vector3(participant.transform.position.x, participant.transform.position.y + 2, participant.transform.position.z);
       // dialog.text = "AGH!";
        return
            new Sequence(
                        // participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("Dying", true),
                        participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("dead", true),
                       participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("Reviving", true),
                       new LeafWait(1)
           );

    }

    protected Node wait()
    {
        Debug.Log("wait");
        return
            // new DecoratorLoop(
            new Sequence(
                       // participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("Dying", true),
                       // participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("Reviving", true),
                       new LeafWait(1000000)
           );//);

    }
    protected Node wait2()
    {
        Debug.Log("wait");
        //dialog.text = "Oh no!";
        return
             new DecoratorLoop(
            new Sequence(
                       // participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("Dying", true),
                       // participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("Reviving", true),
                       new LeafWait(10000)
           ));

    }

    protected Node BuildTreeRoot()
    {
        Node hitIt = new DecoratorForceStatus(RunStatus.Success,
            new Sequence(
                this.goTo(wander1),
               this.dying(),

                new LeafWait(1)
                ));
        Node root = new DecoratorForceStatus(RunStatus.Success, new Sequence(hitIt, wait(), wait2()));
        return root;
        /*
        if (hitStatus == 0) {
            return

                new DecoratorLoop(
            new Sequence(
                this.goTo(wander1),
               this.dying(dialog),

                new LeafWait(1)
                ));
        }
        else
        {
            return new DecoratorLoop(new Sequence(
            this.reviving(dialog),
            new LeafWait(1)
            ));

        }*/

    }
}
