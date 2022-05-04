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
            wp = _waypoints[_currentWaypointIndex];
            if (Vector3.Distance(_transform.position, wp.position) < 0.01f)
            {
                _transform.position = wp.position;
                _waitCounter = 0f;
                _waiting = true;

                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            }
            else
            {
                _transform.position = Vector3.MoveTowards(
                    _transform.position,
                    wp.position,
                    AIBT.speed *Time.deltaTime);
                _transform.LookAt(wp.position);
            }
        }

        float angle = Vector2.Angle(Vector2.up, wp.position);

        if(angle == 0)
        {
            if(_transform.CompareTag("Rguard"))
            {
                _animGuard.SetInteger("RGBehaviour", 0);
            }
            if(_transform.CompareTag("Bguard"))
            {
                _animGuard.SetInteger("BGBehaviour", 0);
            }
        }
        if(angle == 90)
        {
            if(_transform.CompareTag("Rguard"))
            {
                _animGuard.SetInteger("RGBehaviour", 1);
            }
            if(_transform.CompareTag("Bguard"))
            {
                _animGuard.SetInteger("BGBehaviour", 1);
            }
        }
        if(angle == 180)
        {
            if(_transform.CompareTag("Rguard"))
            {
                _animGuard.SetInteger("RGBehaviour", 2);
            }
            if(_transform.CompareTag("Bguard"))
            {
                _animGuard.SetInteger("BGBehaviour", 2);
            }
        }
        if(angle == 270)
        {
            if(_transform.CompareTag("Rguard"))
            {
                _animGuard.SetInteger("RGBehaviour", 3);
            }
            if(_transform.CompareTag("Bguard"))
            {
                _animGuard.SetInteger("BGBehaviour", 3);
            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}
