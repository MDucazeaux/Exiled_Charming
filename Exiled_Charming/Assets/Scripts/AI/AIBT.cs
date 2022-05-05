using System.Collections.Generic;
using BehaviorTree;
using UnityEngine.AI;
using UnityEngine;

public class AIBT : TreeBehav
{
    public UnityEngine.Transform[] waypoints;
    public Transform Player;
    public Animator rguard;

    public static float speed = 10f;
    
    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new PrincesseDetector(transform,Player,rguard),
            new Patrol(transform,rguard,waypoints)
        });

        return root;
    }
}