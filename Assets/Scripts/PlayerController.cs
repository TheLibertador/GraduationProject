using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Maximum slope the character can jump on")]
    [Range(5f, 60f)]
    public float slopeLimit = 45f;
    [Tooltip("Move speed in meters/second")]
    public float moveSpeed = 5f;
    [Tooltip("Turn speed in degrees/second, left (+) or right (-)")]     
    public float turnSpeed = 300;
    [Tooltip("Whether the character can jump")]
    public bool allowJump = false;
    [Tooltip("Upward speed to apply when jumping in meters/second")]
    public float jumpSpeed = 4f;
    
    public bool ısGrounded { get; private set; }
    public float forwardInput { get; set; }
    public float turnInput { get; set; }
    public bool jumpInput { get; set; }
    new private Rigidbody m_Rigidbody;
    private CapsuleCollider m_CapsuleCollider;
    
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_CapsuleCollider = GetComponent<CapsuleCollider>();
    }
    
    private void FixedUpdate()
    {
        CheckGrounded();
        ProcessActions();
        
        int vertical = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));
        int horizontal = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        bool jump = Input.GetKey(KeyCode.Space);
        forwardInput = vertical;
        turnInput = horizontal;
        jumpInput = jump;
    }
    
    /// <summary>
    /// Checks whether the character is on the ground and updates <see cref="ısGrounded"/>
    /// </summary>
    private void CheckGrounded()
    {
        ısGrounded = false;
        float capsuleHeight = Mathf.Max(m_CapsuleCollider.radius * 2f, m_CapsuleCollider.height);
        Vector3 capsuleBottom = transform.TransformPoint(m_CapsuleCollider.center - Vector3.up * capsuleHeight / 2f);
        float radius = transform.TransformVector(m_CapsuleCollider.radius, 0f, 0f).magnitude;
        Ray ray = new Ray(capsuleBottom + transform.up * .01f, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, radius * 5f))
        {
            float normalAngle = Vector3.Angle(hit.normal, transform.up);
            if (normalAngle < slopeLimit)
            {
                float maxDist = radius / Mathf.Cos(Mathf.Deg2Rad * normalAngle) - radius + .02f;
                if (hit.distance < maxDist)
                    ısGrounded = true;
            }
        }
    }
    
    /// <summary>
    /// Processes input actions and converts them into movement
    /// </summary>
    private void ProcessActions()
    {
        // Process Turning
        if (turnInput != 0f)
        {
            float angle = Mathf.Clamp(turnInput, -1f, 1f) * turnSpeed;
            transform.Rotate(Vector3.up, Time.fixedDeltaTime * angle);
        }
        // Process Movement/Jumping
        if (ısGrounded)
        {
            // Reset the velocity
            m_Rigidbody.velocity = Vector3.zero;
            // Check if trying to jump
            if (jumpInput && allowJump)
            {
                // Apply an upward velocity to jump
                m_Rigidbody.velocity += Vector3.up * jumpSpeed;
            }

            // Apply a forward or backward velocity based on player input
            m_Rigidbody.velocity += transform.forward * Mathf.Clamp(forwardInput, -1f, 1f) * moveSpeed;
        }
        else
        {
            // Check if player is trying to change forward/backward movement while jumping/falling
            if (!Mathf.Approximately(forwardInput, 0f))
            {
                // Override just the forward velocity with player input at half speed
                Vector3 verticalVelocity = Vector3.Project(m_Rigidbody.velocity, Vector3.up);
                m_Rigidbody.velocity = verticalVelocity + transform.forward * Mathf.Clamp(forwardInput, -1f, 1f) * moveSpeed / 2f;
            }
        }
    }
}
