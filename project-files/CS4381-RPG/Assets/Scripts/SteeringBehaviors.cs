//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SteeringBehaviors : MonoBehaviour
//{
//    private Rigidbody2D rb2d;   // A reference to the RigidBody2D component of the game object

//    public float maxSpeed;
//    public float maxForce;
//    public float maxTurnRate;
//    private readonly float wanderRadius = 500;
//    private readonly float wanderDistance = 100;
//    private readonly float wanderJitter = 6;

////    public SteeringBehaviors (float mS,float mF, float mTR)
////    {
////        maxSpeed = mS;
////        maxForce = mF;
////        maxTurnRate = mTR;
////    }

//    void Start()
//    {
//        rb2d = GetComponent<Rigidbody2D>(); // Store a reference to object's rigidbody2d component to allow access
//    }
//    private Vector2 Seek(Vector2 TargetPos)
//    {
//        Vector2 move = TargetPos - rb2d.position;
//        move.Normalize();
//        Vector2 DesiredVelocity = move * maxSpeed;
//        return (DesiredVelocity - rb2d.velocity);
//    }

//    private Vector2 Wander()
//    {
//        Vector2 wanderTarget = new Vector2();
//        Vector2 temp = new Vector2(Random.Range(-1, 1) * wanderJitter, Random.Range(-1, 1) * wanderJitter);
//        wanderTarget += temp;
//        wanderTarget.Normalize();
//        wanderTarget *= wanderRadius;

//        temp = new Vector2(wanderDistance, 0);
//        Vector2 targetLocal = wanderTarget + temp;

//        return targetLocal - rb2d.position;
//    }

//    public Vector2 Calculate()
//    {
//        Vector2 SteeringForce = new Vector2(0, 0);

//        SteeringForce += Wander();
//        print(SteeringForce);

//        return SteeringForce;
//    } 
//}
