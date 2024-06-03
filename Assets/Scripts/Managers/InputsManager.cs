using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsManager : MonoBehaviour
{
    [Serializable]
    public struct PlayersInputs
    {
        public PlayerMovment.PlayerId playerId;
        public DynamicJoystick joystick;
    }

    [SerializeField] private PlayersInputs[] inputs;

    public PlayersInputs[] Inputs { get => inputs; }
}
