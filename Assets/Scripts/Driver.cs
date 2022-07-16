using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField]
    float steerSpeed = 300f;

    [SerializeField]
    float moveSpeed = 20f;

    [SerializeField]
    float slowSpeed = 15f;

    [SerializeField]
    float boostSpeed = 40f;

    // Update is called once per frame
    void LateUpdate()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; 

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boost"))
        {
            moveSpeed = boostSpeed;
            Invoke("DefaultSpeedAfterTime", 5);
        }
        if (other.CompareTag("Slow"))
        {
            moveSpeed = slowSpeed;
            Invoke("DefaultSpeedAfterTime", 5);
        }
    }

    private void DefaultSpeedAfterTime()
    {
        Debug.Log("am i really getting executed");
        moveSpeed = 20f;
    }
}
