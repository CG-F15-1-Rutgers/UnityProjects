using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TreeSharpPlus;

public class Cheer : MonoBehaviour
{

    private BehaviorAgent behaviorAgent;
    public GameObject participant;

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

    protected Node cheer()
    {
        Debug.Log("cheer");
        return
          new Sequence(
                    participant.GetComponent<BehaviorMecanim>().Node_HandAnimation("Cheer", true),

                     new LeafWait(1)
         );


    }

    protected Node BuildTreeRoot()
    {
        return

                new DecoratorLoop(
                new Sequence(
                    this.cheer(),
                    new LeafWait(1)
                    ));
    }
}
