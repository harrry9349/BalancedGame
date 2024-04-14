using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayAcceptor : IAcceptor
{
    public GameObject player;
    public RelayAcceptor(GameObject player)
    {
        this.player = player;
    }
    public void Accept(IVisitor visitor)

    {
        Debug.Log("RelayAcceptor");
        visitor.Visit(this);
    }
}
