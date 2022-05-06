using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class Patrol : Node
{
    private int _currentWaypointIndex = 0;

    private float _waitTime = 1f; // in seconds
    private float _waitCounter = 0f;
    private float posangle;

    private bool wasMovingRight = false;
    private bool wasMovingLeft = false;
    private bool wasMovingUp = false;
    private bool wasMovingDown = false;
    private bool _waiting = false;
    private bool isMoving = false;

    private int limit = 0;
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
        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter >= _waitTime)
            {
                limit = 0;
                _waiting = false;
            }
        }
        else
        {
            if (Vector2.Distance(_transform.position, wp.position) < 0.01f)
            {
                _transform.position = wp.position;
                _waitCounter = 0f;
                isMoving = false;
                _waiting = true;

                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            }
            else
            {
                _transform.position = Vector3.MoveTowards(
                    _transform.position,
                    wp.position,
                    AIBT.speed * Time.deltaTime);
                isMoving = true;
            }
        }
        float angle = Vector2.SignedAngle(Vector2.up, wp.position);
        posangle = angle + 180;

        if (posangle > 210 && posangle < 220 && limit == 0)
        {
            //gauche
            if (_transform.CompareTag("Rguard"))
            {
                _animGuard.SetInteger("RGBehaviour", 0);
                limit++;
            }
            if (_transform.CompareTag("Bguard"))
            {
                _animGuard.SetInteger("BGBehaviour", 0);
                limit++;
            }
            wasMovingLeft = true;
            wasMovingUp = false;
            wasMovingRight = false;
            wasMovingDown = false;
        }
        if (posangle > 260 && posangle < 270 && limit == 0)
        {
            //bas
            if (_transform.CompareTag("Rguard"))
            {
                _animGuard.SetInteger("RGBehaviour", 3);
                limit++;
            }
            if (_transform.CompareTag("Bguard"))
            {
                _animGuard.SetInteger("BGBehaviour", 3);
                limit++;
            }
            wasMovingLeft = false;
            wasMovingUp = false;
            wasMovingRight = false;
            wasMovingDown = true;
        }
        if (posangle > 80 && posangle < 100 && limit == 0)
        {
            //droite
            if (_transform.CompareTag("Rguard"))
            {
                _animGuard.SetInteger("RGBehaviour", 1);
                limit++;
            }
            if (_transform.CompareTag("Bguard"))
            {
                _animGuard.SetInteger("BGBehaviour", 1);
                limit++;
            }
            wasMovingLeft = false;
            wasMovingUp = false;
            wasMovingRight = true;
            wasMovingDown = false;
        }
        if (posangle > 120 && posangle < 135 && limit == 0)
        {
            //haut
            if (_transform.CompareTag("Rguard"))
            {
                _animGuard.SetInteger("RGBehaviour", 2);
                limit++;
            }
            if (_transform.CompareTag("Bguard"))
            {
                _animGuard.SetInteger("BGBehaviour", 2);
                limit++;
            }
            wasMovingLeft = false;
            wasMovingUp = true;
            wasMovingRight = false;
            wasMovingDown = false;
        }

        //if(!isMoving)
        //{
        //    if (_transform.CompareTag("Rguard"))
        //    {
        //        _animGuard.SetInteger("RGBehaviour", -1);
        //    }
        //    if (_transform.CompareTag("Bguard"))
        //    {
        //        _animGuard.SetInteger("BGBehaviour", -1);
        //    }
        //}

        //if (!isMoving && wasMovingDown)
        //{
        //    if (_transform.CompareTag("Rguard"))
        //    {
        //        _animGuard.SetInteger("RGBehaviour", -1);
        //    }
        //    if (_transform.CompareTag("Bguard"))
        //    {
        //        _animGuard.SetInteger("BGBehaviour", -1);
        //    }
        //}

        //if (!isMoving && wasMovingLeft)
        //{
        //    if (_transform.CompareTag("Rguard"))
        //    {
        //        _animGuard.SetInteger("RGBehaviour", -2);
        //    }
        //    if (_transform.CompareTag("Bguard"))
        //    {
        //        _animGuard.SetInteger("BGBehaviour", -2);
        //    }
        //}

        //if (!isMoving && wasMovingUp)
        //{
        //    if (_transform.CompareTag("Rguard"))
        //    {
        //        _animGuard.SetInteger("RGBehaviour", -4);
        //    }
        //    if (_transform.CompareTag("Bguard"))
        //    {
        //        _animGuard.SetInteger("BGBehaviour", -4);
        //    }
        //}

        //if (!isMoving && wasMovingRight)
        //{
        //    if (_transform.CompareTag("Rguard"))
        //    {
        //        _animGuard.SetInteger("RGBehaviour", -3);
        //    }
        //    if (_transform.CompareTag("Bguard"))
        //    {
        //        _animGuard.SetInteger("BGBehaviour", -3);
        //    }
        //}

        state = NodeState.RUNNING;
        return state;
    }
}
