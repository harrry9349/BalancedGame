using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollisionManager : MonoBehaviour
{

    private FallOutAcceptor fallOutAcceptor;
    private GoalAcceptor goalAcceptor;
    private RelayAcceptor relayAcceptor;

    private FallOutVisitor fallOutVisitor;
    private GoalVisitor goalVisitor;
    private RelayVisitor relayVisitor;

    // Start is called before the first frame update
    void Start()
    {
        fallOutAcceptor = new FallOutAcceptor(gameObject);
        goalAcceptor = new GoalAcceptor(gameObject);
        relayAcceptor = new RelayAcceptor(gameObject);

        fallOutVisitor = new FallOutVisitor();
        goalVisitor = new GoalVisitor();
        relayVisitor = new RelayVisitor();

    }

    private void OnCollisionEnter(Collision collision)
    {
        string collName = collision.gameObject.name;
        switch(collName){

            case "FallOut":
                fallOutAcceptor.Accept(fallOutVisitor);
                break;
            case "Goal":
                goalAcceptor.Accept(goalVisitor);
                break;
            case "Relay":
                relayAcceptor.Accept(relayVisitor);
                Destroy(collision.gameObject);
                break;
            default:
                break;
        }

    }


}
