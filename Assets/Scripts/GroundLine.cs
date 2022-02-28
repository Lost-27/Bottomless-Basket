using UnityEngine;

public class GroundLine : MonoBehaviour
{
    #region Veriables

    [Header("Audio")]
    [SerializeField] private AudioClip _hitClip;

    #endregion


    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Instance.PlayOnShot(_hitClip);

        if (collision.gameObject.CompareTag(Tags.GoodItem))
        {
            GameManager.Instance.RemoveLive();
        }

        collision.gameObject.GetComponent<Target>().DestroyTarget();
    }

    #endregion
}