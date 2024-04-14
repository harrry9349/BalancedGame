using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOutAcceptor :IAcceptor
{
    public GameObject  player;
    public FallOutAcceptor(GameObject player)
    {
        this.player = player;
    }

    public void Accept(IVisitor visitor)
    {
        Debug.Log("FallOutAcceptor");
        visitor.Visit(this);
    }
}
