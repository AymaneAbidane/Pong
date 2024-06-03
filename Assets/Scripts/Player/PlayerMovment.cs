using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private DynamicJoystick dynanicJoystick;
    [SerializeField] private float movmentSpeed;
    [SerializeField] private float yClampValue;

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 playerPos = transform.position;

        playerPos += movmentSpeed * Time.deltaTime * new Vector2(0f, dynanicJoystick.Direction.y);

        playerPos.y = Mathf.Clamp(playerPos.y, -yClampValue, yClampValue);

        transform.position = playerPos;
    }
}
