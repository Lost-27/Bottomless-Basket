using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    #region Veriables

    [SerializeField] private float _xRange;
    [SerializeField] private float _yMinRange;
    [SerializeField] private float _yMaxRange;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
    }

    private void Update()
    {
        MovingPadWithMouse();
    }

    #endregion


    #region Private methods

    private void MovingPadWithMouse()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(worldPos.x, -_xRange, _xRange);
        currentPos.y = Mathf.Clamp(worldPos.y, -_yMinRange, _yMaxRange);
        transform.position = currentPos;
    }

    #endregion
}