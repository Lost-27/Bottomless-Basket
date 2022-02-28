using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBasket : MonoBehaviour
{
    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // collision.gameObject.CompareTag()
        // Destroy(collision.gameObject);
    }

    #endregion
}
