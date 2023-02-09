using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingEntity : MonoBehaviour
{
    //CharacterController charController;

    public float maxSpeed;
    public float maxForce;
    public float maxTurnRate;   // Rotation speed
    public Transform target;    // Player's Transform data
    public float distance;      // Distance from player
    public float senseRange = 3.5f;    // AI sensing range
    public bool objectSensed = false;
    public float heading;
    public Vector3 targetRotation;
    public float max;
    public float min;
    public Vector3 forward;
    public bool Collision = false;
    public RaycastHit2D rayHit1;
    public RaycastHit2D rayHit2;
    public RaycastHit2D rayHit3;
    public RaycastHit2D rayHit4;

    private Rigidbody2D rb2d;   // A reference to the RigidBody2D component of the game object
    private BoxCollider2D[] box2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Store a reference to object's rigidbody2d component to allow access
        box2d = GetComponents<BoxCollider2D>();
        //charController = GetComponent<CharacterController>();
        heading = Random.Range(0, 360);
        rb2d.transform.eulerAngles = new Vector3(0, 0, heading);
        

        //StartCoroutine(ChangeHeading());
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (rb2d.transform != null && scene.name == "Wilderness")
        {
            distance = Vector2.Distance(transform.position, target.transform.position);

            print(distance);

            if (target != null)
            {
                if (distance <= senseRange && objectSensed == false)
                {
                    Vector3 targetPosition = target.transform.position;
                    //Vector3 targetPosition2D = new Vector3(targetPosition.x, targetPosition.y, 0);
                    transform.up = targetPosition - transform.position;
                    transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * maxSpeed);
                }
                // Move object forward
                rb2d.transform.Translate(Vector3.up * Time.deltaTime * 1);

                Transform leftRay = transform;
                Transform rightRay = transform;

                rayHit1 = Physics2D.Raycast((rightRay.position + transform.right * 0.3f), transform.up, senseRange);
                print("Ray Hit = " + rayHit1);
                rayHit2 = Physics2D.Raycast((leftRay.position - (transform.right) * 0.3f), transform.up, senseRange);
                print("Ray hit = " + rayHit2);
                //if (Physics2D.Raycast((rightRay.position + transform.right*0.5f), transform.up, senseRange, LayerMask.NameToLayer("Default")) || Physics2D.Raycast((leftRay.position - (transform.right)*0.5f), transform.up, senseRange, LayerMask.NameToLayer("Default")))
                if (rayHit1.rigidbody != null || rayHit2.rigidbody != null)
                {
                    print("rayHit1 =" + rayHit1.collider);
                    print("rayHit2 =" + rayHit2.collider);
                    if (rayHit1.collider != null)// && rayHit.collider.gameObject.CompareTag("Collider"))
                    {
                        print("Collision detected");
                        objectSensed = true;
                        rb2d.transform.Rotate(Vector3.forward * Time.deltaTime * maxTurnRate);
                    }
                    else if (rayHit2.collider != null)// && rayHit.collider.gameObject.CompareTag("Collider"))
                    {
                        print("Collision detected");
                        objectSensed = true;
                        rb2d.transform.Rotate(Vector3.forward * Time.deltaTime * maxTurnRate);
                    }
                }

                rayHit3 = Physics2D.Raycast((transform.position - transform.up * 0.5f), -transform.right, senseRange);
                rayHit4 = Physics2D.Raycast((transform.position - transform.up * 0.5f), transform.right, senseRange);

                // Rear Rays
                //if (Physics2D.Raycast((transform.position - transform.up*0.5f), -transform.right, senseRange, LayerMask.NameToLayer("Default")) || Physics2D.Raycast((transform.position - transform.up * 0.5f), transform.right, senseRange, LayerMask.NameToLayer("Default")))
                if (rayHit3.collider || rayHit4.collider)
                {
                    print("rayHit3 =" + rayHit3.collider);
                    print("rayHit4 =" + rayHit4.collider);
               
                    if (rayHit3.collider != null)// && rayHit.collider.gameObject.CompareTag("Collider"))
                    {
                        print("Collision detected");
                        objectSensed = false;                       
                    }
                    else if (rayHit4.collider != null)// && rayHit.collider.gameObject.CompareTag("Collider"))
                    {
                        print("Collision detected");
                        objectSensed = false;
                    }
                }
                // Debug code
                //Debug.DrawRay(rightRay.position + (transform.right * 0.3f), transform.up * senseRange, Color.blue);

                //Debug.DrawRay(leftRay.position - (transform.right * 0.3f), transform.up * senseRange, Color.blue);

                //Debug.DrawRay(transform.position - (transform.up * 0.5f), -transform.right * senseRange, Color.yellow);

                //Debug.DrawRay(transform.position - (transform.up * 0.5f), transform.right * senseRange, Color.yellow);
                
            }
        }
    }
}

