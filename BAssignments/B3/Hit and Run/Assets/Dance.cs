using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TreeSharpPlus;
public class Dance : MonoBehaviour {

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


    protected Node dance()
    {
        // dialog.transform.position = new Vector3(participant.transform.position.x, participant.transform.position.y + 2, participant.transform.position.z);
        //     dialog.text = "oh!";
        return
            new SelectorShuffle(

           participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("Breakdance", true)

           );

    }

    protected Node BuildTreeRoot()
    {
        return

                new DecoratorLoop(
                new Sequence(
                    this.dance(),
                    new LeafWait(1)
                    ));
    }
}
