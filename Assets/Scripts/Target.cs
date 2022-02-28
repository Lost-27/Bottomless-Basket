using UnityEngine;

public class Target : MonoBehaviour
{
    #region Veriables

    [Header("Base Settings")]
    [SerializeField] private int _pointValue;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private float _xRange;
    [SerializeField] private float _yRange;
    [SerializeField] private bool _isAddsLives;

    [Header("Audio")]
    [SerializeField] private AudioClip _targetClip;

    #endregion


    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.BottomBasket))
        {
            AudioManager.Instance.PlayOnShot(_targetClip);
            GameManager.Instance.AddScore(_pointValue);
        
            if (_isAddsLives)
                GameManager.Instance.AddLive();
            
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        transform.position = RandomSpawnPos();
    }

    #endregion

    #region Public methods

    public void DestroyTarget()
    {
        if (GameManager.Instance.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            //gameManager.UpdateScore(pointValue);
        }
    }

    #endregion

    #region Private methods

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _yRange);
    }

    #endregion
}