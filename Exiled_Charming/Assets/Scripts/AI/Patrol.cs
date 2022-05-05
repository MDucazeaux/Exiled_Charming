using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class Patrol : Node
{
    private int _currentWaypointIndex = 0;

    private float _waitTime = 1f; // in seconds
    private float _waitCounter = 0f;
    private bool _waiting = false;


    private Animator _animGuard;
    private Transform wp;
    private Transform _transform;
    private Transform[] _waypoints;
    public Patrol(Transform transform, Animator animGuard, Transform[] waypoints)
    {
        _transform = transform;
        _waypoints = waypoints;
        _animGuard = animGuard;
    }

    public override NodeState Evaluate()
    {
        wp = _waypoints[_currentWaypointIndex];
        float angle = Vector2.Angle(Vector2.up, wp.position);
        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter >= _waitTime)
            {
                _waiting = false;
            }
        }
        else
        {
            if (Vector2.Distance(_transform.position, wp.position) < 0.01f)
            {
                _transform.position = wp.position;
                _waitCounter = 0f;
                _waiting = true;

                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            }
            else
            {
                int limit = 0;
                if (angle > 340 && angle < 20 && limit == 0)
                {
                    if (_transform.CompareTag("Rguard"))
                    {
                        _animGuard.SetInteger("RGBehaviour", 0);
                        limit++;
                    }
                    if (_transform.CompareTag("Bguard"))
                    {
                        _animGuard.SetInteger("BGBehaviour", 0);
                    }
                }
                else if (angle > 70 && angle < 110 && limit == 0)
                {
                    if (_transform.CompareTag("Rguard"))
                    {
                        _animGuard.SetInteger("RGBehaviour", 1);
                        limit++;
                    }
                    if (_transform.CompareTag("Bguard"))
                    {
                        _animGuard.SetInteger("BGBehaviour", 1);
                    }
                }
                else if (angle > 160 && angle < 200 && limit == 0)
                {
                    if (_transform.CompareTag("Rguard"))
                    {
                        _animGuard.SetInteger("RGBehaviour", 2);
                        limit++;
                    }
                    if (_transform.CompareTag("Bguard"))
                    {
                        _animGuard.SetInteger("BGBehaviour", 2);
                    }
                }
                else if (angle > 250 && angle < 290 && limit == 0)
                {
                    if (_transform.CompareTag("Rguard"))
                    {
                        _animGuard.SetInteger("RGBehaviour", 3);
                        limit++;
                    }
                    if (_transform.CompareTag("Bguard"))
                    {
                        _animGuard.SetInteger("BGBehaviour", 3);
                    }
                    
                }
                else
                {
                    _animGuard.SetInteger("RGBehaviour", -1);
                    limit = 0;
                }
                _transform.position = Vector3.MoveTowards(
                    _transform.position,
                    wp.position,
                    AIBT.speed * Time.deltaTime);
            }
        }
        state = NodeState.RUNNING;
        return state;
    }
}
