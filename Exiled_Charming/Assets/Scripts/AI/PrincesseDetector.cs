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
    private  gameManager _gameManager;
    private GameObject _isnear;

    public PrincesseDetector(Transform transform, Transform player, Animator rguard, gameManager gameManager,GameObject isnear)
    {
        _transform = transform;
        _player = player;
        _rguard = rguard;
        _gameManager = gameManager;
        _isnear = isnear;
    }

    public override NodeState Evaluate()
    {
        if(Vector2.Distance(_transform.position, _player.position) > 6)
        {
            _isnear.SetActive(false);
        }

        else if(Vector2.Distance(_transform.position, _player.position) <= 6)
        {
            _isnear.SetActive(true);
        }
        else
        {
            _isnear.SetActive(false);
        }

        if(Vector2.Distance(_transform.position, _player.position) <3)
        {
            fightManager.Instance.Ennemi = _transform.gameObject;
            _gameManager.state = gameState.Fight;
            _isnear.SetActive(false);
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }
}
