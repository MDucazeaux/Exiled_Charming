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
    public static float fovRange = 10f;
    public static float attackRange = 2f;
    
    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new PrincesseDetector(transform,Player,rguard)
            
        });

        return root;
    }
}