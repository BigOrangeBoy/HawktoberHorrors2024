using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lean : MonoBehaviour
{
    public Animator cameraAnim;
    public LayerMask layers;
    public float rayDistance = 5.0f; // Defined ray distance
    RaycastHit hit;

    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && !Physics.Raycast(transform.position, -transform.right, out hit, rayDistance, layers))
        {
            cameraAnim.ResetTrigger("idle");
            cameraAnim.ResetTrigger("right");
            cameraAnim.SetTrigger("left"); 
        }
        else if (Input.GetKey(KeyCode.E) && !Physics.Raycast(transform.position, transform.right, out hit, rayDistance, layers))
        {
            cameraAnim.ResetTrigger("idle");
            cameraAnim.ResetTrigger("left");
            cameraAnim.SetTrigger("right");
        }
        else
        {
            cameraAnim.ResetTrigger("right");
            cameraAnim.ResetTrigger("left");
            cameraAnim.SetTrigger("idle");
        }
    }
}
