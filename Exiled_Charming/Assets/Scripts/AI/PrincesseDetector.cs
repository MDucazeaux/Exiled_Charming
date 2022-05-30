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
        //float dist = Vector2.Distance(_transform.position, _player.position);
        //Debug.DrawLine(_player.position, _transform.position, Color.red);
        //if(dist < 10 && fightManager.Instance.Ennemi != null)
        //{
        //    fightManager.Instance.Ennemi = _transform.gameObject;
        //    gameManager.Instance.updateState(gameState.Fight);
        //    return NodeState.SUCCESS;
        //}

        return NodeState.FAILURE;
    }
}
