using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Camera : MonoBehaviour
{
    [SerializeField] float cameraSensitivity;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Mouse X")*cameraSensitivity*Time.deltaTime;
        player.Rotate(0,moveX,0);
    }
}
