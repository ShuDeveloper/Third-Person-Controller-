using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float WalkSpeed;

    Vector3 directions;
    Vector3 vilocity;

    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveZ = Input.GetAxis("Vertical");
        directions = new Vector3(0,0, moveZ);
        directions *= moveSpeed*Time.deltaTime;
        directions = transform.TransformDirection(directions);
        controller.Move(directions);
    }
}
