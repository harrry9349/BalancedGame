using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalVisitor : IVisitor
{
    public void Visit(GoalAcceptor goalAcceptor)
    {
        Debug.Log("GoalVisitor");
        goalAcceptor.player.GetComponent<Player>().Goal();
    }

    public void Visit(FallOutAcceptor falloutAcceptor)
    {
        throw new System.NotImplementedException();
    }

    public void Visit(RelayAcceptor relayAcceptor)
    {
        throw new System.NotImplementedException();
    }
}
