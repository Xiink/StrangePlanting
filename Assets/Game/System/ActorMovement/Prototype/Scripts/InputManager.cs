using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public float GetHorizontal()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public float GetVertical()
    {
        return Input.GetAxisRaw("Vertical");
    }
}
