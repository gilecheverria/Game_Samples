/*
Change the animation of an agent based on the direction of its movement

Using information from the manual:
https://docs.unity3d.com/Manual/nav-CouplingAnimationAndNavigation.html

Gilberto Echeverria
2023-03-16
*/

using UnityEngine;
using UnityEngine.AI;


[RequireComponent (typeof (NavMeshAgent))]

public class AgentAnimation : MonoBehaviour
{
    [SerializeField] float threshold;

    Animator animator;
    NavMeshAgent nvAgent;

    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();        
        nvAgent = GetComponent<NavMeshAgent>();
        // Don’t update position automatically
        //nvAgent.updatePosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimation();
    }

    void SetAnimation()
    {
        Vector3 worldDeltaPosition = nvAgent.destination - transform.position;
        //Vector3 worldDeltaPosition = nvAgent.nextPosition - transform.position;

        // Map 'worldDeltaPosition' to local space
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        // Low-pass filter the deltaMove
        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        // Update velocity if time advances
        if (Time.deltaTime > 1e-5f)
            velocity = smoothDeltaPosition / Time.deltaTime;

        bool shouldMove = velocity.magnitude > 0.5f
                          && nvAgent.remainingDistance > nvAgent.radius;

        // Update animation parameters
        animator.SetBool("move", shouldMove);
        animator.SetFloat ("velx", velocity.x);
        animator.SetFloat ("vely", velocity.y);

        /*
        GetComponent<LookAt>().lookAtTargetPosition = nvAgent.steeringTarget
                                                        + transform.forward;
        */
    }

    /*
    void OnAnimatorMove ()
    {
        // Update position to agent position
        transform.position = nvAgent.nextPosition;
    }
    */

    void SetAnimationGEF()
    {
        if (Mathf.Abs(nvAgent.velocity.x) > Mathf.Abs(nvAgent.velocity.y)) {
            animator.SetFloat("velx", nvAgent.velocity.x);
            animator.SetFloat("vely", 0);
            /*
            if (nvAgent.velocity.x > threshold) {
                animator.SetInteger("Direction", (int)Direction.Right);
            } else if (nvAgent.velocity.x < -threshold) {
                animator.SetInteger("Direction", (int)Direction.Left);
            } else {
                animator.SetInteger("Direction", (int)Direction.None);
            }
            */
        } else {
            animator.SetFloat("velx", 0);
            animator.SetFloat("vely", nvAgent.velocity.y);
            /*
            if (nvAgent.velocity.y > threshold) {
                animator.SetInteger("Direction", (int)Direction.Up);
            } else if (nvAgent.velocity.y < -threshold) {
                animator.SetInteger("Direction", (int)Direction.Down);
            } else {
                animator.SetInteger("Direction", (int)Direction.None);
            }
            */
        }
    }
}
