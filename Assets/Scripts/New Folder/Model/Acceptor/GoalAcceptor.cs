using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAcceptor : IAcceptor
{
    public GameObject player;
    public GoalAcceptor(GameObject player)
    {
        this.player = player;
    }
    public void Accept(IVisitor visitor)
    {
        Debug.Log("GoalAcceptor");
        visitor.Visit(this);
    }
}
