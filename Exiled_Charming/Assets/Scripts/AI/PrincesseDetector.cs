using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class PrincesseDetector : Node
{
    private Transform _transform;
    private Transform _player;
    private Vector2 InFrontOf = Vector2.down;
    private Animator _rguard;

    public PrincesseDetector(Transform transform, Transform player, Animator rguard)
    {
        _transform = transform;
        _player = player;
        _rguard = rguard;
    }

    public override NodeState Evaluate()
    {
        //To know what Animator we are on betwin the blue and the red one
        if(_transform.CompareTag("Rguard"))
        {
            if (_rguard.GetInteger("RGBehaviour") == 3)
                InFrontOf = Vector2.down;
            if (_rguard.GetInteger("RGBehaviour") == 1)
                InFrontOf = Vector2.right;
            if (_rguard.GetInteger("RGBehaviour") == 0)
                InFrontOf = Vector2.left;
            if (_rguard.GetInteger("RGBehaviour") == 2)
                InFrontOf = Vector2.up;
        }
        
        if(_transform.CompareTag("Bguard"))
        {
            if (_rguard.GetInteger("BGBehaviour") == 3)
                InFrontOf = Vector2.down;
            if (_rguard.GetInteger("BGBehaviour") == 1)
                InFrontOf = Vector2.right;
            if (_rguard.GetInteger("BGBehaviour") == 0)
                InFrontOf = Vector2.left;
            if (_rguard.GetInteger("BGBehaviour") == 2)
                InFrontOf = Vector2.up;
        }
        

        Vector2 dir = _player.position - _transform.position;
        float dist = Vector2.Distance(_player.position, _transform.position);
        float angle = Vector2.Angle(dir, InFrontOf);
        //Serching if the enemyUnitss is a circle around us or if she is in our view 
        if (dist <2f||angle<60f)
        {

            gameManager.Instance.state = gameState.Fight;
            fightManager.Instance.Ennemi = this._transform.gameObject;

            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }
}
