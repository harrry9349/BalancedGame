using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOutVisitor : IVisitor
{
    public void Visit(FallOutAcceptor falloutAcceptor)
    {
        Debug.Log("FallOutVisitor");
        RespawnPlayer(falloutAcceptor);
    }

    public void Visit(GoalAcceptor goalAcceptor)
    {
        throw new System.NotImplementedException();
    }

    public void Visit(RelayAcceptor relayAcceptor)
    {
        throw new System.NotImplementedException();
    }

    private void RespawnPlayer(FallOutAcceptor falloutAcceptor)
    {
        Vector3 pos;
        bool isRelayed = falloutAcceptor.player.GetComponent<Player>().GetIsRelayed();
        if (!isRelayed) pos = falloutAcceptor.player.GetComponent<Player>().respawnStart.transform.position; 
        else pos = falloutAcceptor.player.GetComponent<Player>().respawnRelay.transform.position;

        falloutAcceptor.player.transform.position = pos;
    }
}
