using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayVisitor : IVisitor
{
    public void Visit(RelayAcceptor relayAcceptor)
    {
        Debug.Log("GoalVisitor");
        relayAcceptor.player.GetComponent<Player>().SetIsRelayed(true);
    }

    public void Visit(FallOutAcceptor falloutAcceptor)
    {
        throw new System.NotImplementedException();
    }

    public void Visit(GoalAcceptor goalAcceptor)
    {
        throw new System.NotImplementedException();
    }
}
