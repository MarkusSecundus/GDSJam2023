using MarkusSecundus.MultiInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootControl : MonoBehaviour
{
    Vector2 mousePosL;
    Vector2 mousePosR;

    float starty;
    [SerializeField] float maxHeight;

    [SerializeField] GameObject footL;
    [SerializeField] GameObject footR;

    // Start is called before the first frame update
    void Start()
    {
        mousePosL = MouseCheck.mouseL.ViewportPosition;
        mousePosR = MouseCheck.mouseR.ViewportPosition;
        starty = footL.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosL = MouseCheck.mouseL.ViewportPosition;
        Vector2 deltaPos = newPosL - mousePosL;

        if (footL.transform.position.y > starty)
        {
            footL.transform.position = footL.transform.position + new Vector3(deltaPos.x, 0, deltaPos.y) * 0.01f;
            mousePosL = newPosL;
        }
        else
        {
            MouseCheck.mouseL.ViewportPosition = mousePosL;
        }


        if (MouseCheck.mouseL.IsAnyButtonPressed)
        {
            if (footL.transform.position.y < starty + maxHeight)
            {
                footL.transform.position = footL.transform.position + Vector3.up * Time.deltaTime * 3;
            }
        }
        else
        {
            if (footL.transform.position.y > starty)
            {
                footL.transform.position = footL.transform.position - Vector3.up * Time.deltaTime * 3;
            }
        }     

        Vector2 newPosR = MouseCheck.mouseR.ViewportPosition;
        deltaPos = newPosR - mousePosR;

        if (footR.transform.position.y > starty)
        {
            footR.transform.position = footR.transform.position + new Vector3(deltaPos.x, 0, deltaPos.y) * 0.01f;
            mousePosR = newPosR;
        }
        else
        {
            MouseCheck.mouseR.ViewportPosition = mousePosR;
        }


        if (MouseCheck.mouseR.IsAnyButtonPressed)
        {
            if (footR.transform.position.y < starty + maxHeight)
            {
                footR.transform.position = footR.transform.position + Vector3.up * Time.deltaTime * 3;
            }
        }
        else
        {
            if (footR.transform.position.y > starty)
            {
                footR.transform.position = footR.transform.position - Vector3.up * Time.deltaTime * 3;
            }
        }
    }
}
