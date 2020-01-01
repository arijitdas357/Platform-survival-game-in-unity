using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float jumpFoerce;
    private Vector3 moveDirrection;

    // Player controller starter
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirrection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        transform.position = transform.position + (moveDirrection * Time.deltaTime * moveSpeed);
    }
}
