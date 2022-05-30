using System.Collections.Generic;
using BehaviorTree;
using UnityEngine.AI;
using UnityEngine;

//This scrip gonna be placed on the GameObject

public class AIBT : TreeBehav
{
    public UnityEngine.Transform[] waypoints;
    public Transform Player;
    public Animator rguard;

    public static float speed = 5f;
    
    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            //new PrincesseDetector(transform,Player,rguard),
            new Patrol(transform,rguard,waypoints)
        });

        return root;
    }
}