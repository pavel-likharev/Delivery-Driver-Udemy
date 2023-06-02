using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    [SerializeField] float steerSpeed = 250f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float speedCooldown = 1f;

    float speedTime = 1f;
    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {    
        moveSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * -steerSpeed * Time.deltaTime;
        float moveAmount =  Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, moveAmount, 0);

        if (speedTime <= speedCooldown)
            speedTime += Time.deltaTime;
        else
            moveSpeed = baseSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            speedTime = 0;
            moveSpeed = boostSpeed;
        }

        if (other.tag == "Obstacle")
        {
            speedTime = 0;
            moveSpeed = slowSpeed;
        }
    }
}
