using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class WASD : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Animator anim;
    public Rigidbody rb;

    public KeyControl upKey;
    public KeyControl downKey;
    public KeyControl leftKey;
    public KeyControl rightKey;

    public int speed = 5;

    void Start()
    {
        upKey = Keyboard.current.wKey;
        leftKey = Keyboard.current.aKey;
        rightKey = Keyboard.current.dKey;

    }

    // Update is called once per frame
    void Update()
    {
        if (rightKey.isPressed)
        {
            transform.Rotate(0, 1, 0);
            anim.SetBool("Moving", true);
            rb.linearVelocity = transform.forward*speed;
        }
        if (leftKey.isPressed)
        {
            transform.Rotate(0, -1, 0);
            anim.SetBool("Moving", true);
            rb.linearVelocity = transform.forward*speed;
        }
        if (upKey.isPressed)
        {
            anim.SetBool("Moving", true);
            rb.linearVelocity = transform.forward*speed;
        }
        else
        {
            anim.SetBool("Moving", false);
            rb.linearVelocity = new Vector3(0,0,0);
        }
        rb.angularVelocity = new Vector3(0, 0, 0);
    }
}
