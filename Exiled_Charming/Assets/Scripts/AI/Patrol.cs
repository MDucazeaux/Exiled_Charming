using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class Patrol : Node
{
    private int currentWaypointIndex = 0;

    private float waitTime = 1f; // in seconds
    private float waitCounter = 0f;
    private float posangle;

    private bool wasMovingRight = false;
    private bool wasMovingLeft = false;
    private bool wasMovingUp = false;
    private bool wasMovingDown = false;
    private bool waiting = false;
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
        //Define the point where the transform should go
        wp = _waypoints[currentWaypointIndex];
        if (waiting)
        {
            //Put some delai for go to the next target
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime)
            {
                limit = 0;
                waiting = false;
            }
        }
        else
        {
            if (Vector2.Distance(_transform.position, wp.position) < 0.01f)
            {
                _transform.position = wp.position;
                waitCounter = 0f;
                isMoving = false;
                waiting = true;

                currentWaypointIndex = (currentWaypointIndex + 1) % _waypoints.Length;
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


        //float angle = Vector2.SignedAngle(_transform.forward, wp.position);
        //posangle = angle + 180;
        ////How to know where the eye is looking
        //if (angle2 >=0 && angle2 <45 && limit == 0)
        //{
        //    //left
        //    if (_transform.CompareTag("ennemi"))
        //    {
        //        _animGuard.SetInteger("RGBehaviour", 0);
        //        Debug.Log(angle2);
        //        limit++;
        //    }
        //    //if (_transform.CompareTag("Bguard"))
        //    //{
        //    //    _animGuard.SetInteger("BGBehaviour", 0);
        //    //    limit++;
        //    //}
        //    //wasMovingLeft = true;
        //    //wasMovingUp = false;
        //    //wasMovingRight = false;
        //    //wasMovingDown = false;
        //}
        //if (angle2 >=45 && angle2 < 90 && limit == 0)
        //{
        //    //down
        //    if (_transform.CompareTag("ennemi"))
        //    {
        //        _animGuard.SetInteger("RGBehaviour", 3);
        //        Debug.Log(angle2);
        //        limit++;
        //    }
        //    //if (_transform.CompareTag("Bguard"))
        //    //{
        //    //    _animGuard.SetInteger("BGBehaviour", 3);
        //    //    limit++;
        //    //}
        //    //wasMovingLeft = false;
        //    //wasMovingUp = false;
        //    //wasMovingRight = false;
        //    //wasMovingDown = true;
        //}
        //if (angle2 >= 0 && angle2 < 45 && limit == 0)
        //{
        //    //right
        //    if (_transform.CompareTag("ennemi"))
        //    {
        //        _animGuard.SetInteger("RGBehaviour", 1);
        //        limit++;
        //        Debug.Log(angle2);
        //    }
        //    //if (_transform.CompareTag("Bguard"))
        //    //{
        //    //    _animGuard.SetInteger("BGBehaviour", 1);
        //    //    limit++;
        //    //}
        //    //wasMovingLeft = false;
        //    //wasMovingUp = false;
        //    //wasMovingRight = true;
        //    //wasMovingDown = false;
        //}
        //if (angle2 >45 && angle2 <110 && limit == 0)
        //{
        //    //up
        //    if (_transform.CompareTag("ennemi"))
        //    {
        //        _animGuard.SetInteger("RGBehaviour", 2);
        //        limit++;
        //        Debug.Log(angle2);
        //    }
        //    //if (_transform.CompareTag("Bguard"))
        //    //{
        //    //    _animGuard.SetInteger("BGBehaviour", 2);
        //    //    limit++;
        //    //}
        //    //wasMovingLeft = false;
        //    //wasMovingUp = true;
        //    //wasMovingRight = false;
        //    //wasMovingDown = false;
        //}

        ////if (!isMoving)
        ////{
        ////    if (_transform.CompareTag("ennemi"))
        ////    {
        ////        _animGuard.SetInteger("RGBehaviour", -1);
        ////    }
        //    //if (_transform.CompareTag("Bguard"))
        //    //{
        //    //    _animGuard.SetInteger("BGBehaviour", -1);
        //    //}
        ////}

        ////if (!isMoving && wasMovingDown)
        ////{
        ////    if (_transform.CompareTag("ennemi"))
        ////    {
        ////        _animGuard.SetInteger("RGBehaviour", -1);
        ////    }
        ////    //if (_transform.CompareTag("Bguard"))
        ////    //{
        ////    //    _animGuard.SetInteger("BGBehaviour", -1);
        ////    //}
        ////}

        ////if (!isMoving && wasMovingLeft)
        ////{
        ////    if (_transform.CompareTag("ennemi"))
        ////    {
        ////        _animGuard.SetInteger("RGBehaviour", -2);
        ////    }
        ////    //if (_transform.CompareTag("Bguard"))
        ////    //{
        ////    //    _animGuard.SetInteger("BGBehaviour", -2);
        ////    //}
        ////}

        ////if (!isMoving && wasMovingUp)
        ////{
        ////    if (_transform.CompareTag("ennemi"))
        ////    {
        ////        _animGuard.SetInteger("RGBehaviour", -4);
        ////    }
        ////    //if (_transform.CompareTag("Bguard"))
        ////    //{
        ////    //    _animGuard.SetInteger("BGBehaviour", -4);
        ////    //}
        ////}

        ////if (!isMoving && wasMovingRight)
        ////{
        ////    if (_transform.CompareTag("ennemi"))
        ////    {
        ////        _animGuard.SetInteger("RGBehaviour", -3);
        ////    }
        ////    //if (_transform.CompareTag("Bguard"))
        ////    //{
        ////    //    _animGuard.SetInteger("BGBehaviour", -3);
        ////    //}
        ////}

        state = NodeState.RUNNING;
        return state;
    }
}
