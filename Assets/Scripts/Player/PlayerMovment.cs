using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public enum PlayerId { P1, P2 };

    [SerializeField] private PlayerId playerId;
    [SerializeField] private InputsManager inputManager;
    [SerializeField] private float movmentSpeed;
    [SerializeField] private float yClampValue;
    private DynamicJoystick ownJoystick;
    private Vector2 initialPos;

    private void Start()
    {
        initialPos = transform.position;
        GetOwnJoyStick();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 playerPos = transform.position;
#if UNITY_EDITOR || UNITY_ANDROID || UNITY_IOS       
        MovmentMobile(playerPos);
#endif
#if UNITY_STANDALONE_WIN
         MovmentPc(playerPos);
#endif
    }

    private void MovmentPc(Vector2 playerPos)
    {
        if (playerId == PlayerId.P1)
        {
            MovmentWithPcInputs(playerPos, Input.GetKey(KeyCode.UpArrow), Input.GetKey(KeyCode.DownArrow));
        }

        else if (playerId == PlayerId.P2)
        {
            MovmentWithPcInputs(playerPos, Input.GetKey(KeyCode.W), Input.GetKey(KeyCode.S));
        }

    }

    private void MovmentWithPcInputs(Vector2 playerPos, bool v, bool v1)
    {
        if (v)
        {
            playerPos += new Vector2(0f, movmentSpeed * Time.deltaTime);
        }
        else if (v1)
        {
            playerPos -= new Vector2(0f, movmentSpeed * Time.deltaTime);
        }

        ApplyPosition(playerPos);
    }

    private void MovmentMobile(Vector2 playerPos)
    {
        playerPos += movmentSpeed * Time.deltaTime * new Vector2(0f, ownJoystick.Direction.y);
        ApplyPosition(playerPos);
    }

    private void ApplyPosition(Vector2 finalPos)
    {
        finalPos.y = Mathf.Clamp(finalPos.y, -yClampValue, yClampValue);
        transform.position = finalPos;
    }

    private void GetOwnJoyStick()
    {
        foreach (var input in inputManager.Inputs)
        {
            if (input.playerId == this.playerId)
            {
                ownJoystick = input.joystick;
                break;
            }
        }
    }

    public void ResetPosition()
    {
        transform.position = initialPos;
    }
}
