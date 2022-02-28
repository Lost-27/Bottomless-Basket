using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    #region Variables

    [Header("Score Setting")]
    [SerializeField] private TextMeshProUGUI _dynamicScoreLabel;

    [Header("Lives Bar Setting")]
    [SerializeField] private GameObject _heartCellPrefab;
    [SerializeField] private Transform _heartsBar;

    private List<GameObject> _maxHearts = new List<GameObject>();

    #endregion


    #region Unity lifecycle
    private void Start()
    {
        InstantiateHearts();
        UpdatingLifeCells();
        GameManager.Instance.OnLivesChanged += UpdatingLifeCells;
        GameManager.Instance.OnScoreChanged += UpdateScoreLabel;        
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnLivesChanged -= UpdatingLifeCells;
        GameManager.Instance.OnScoreChanged -= UpdateScoreLabel;
    }

    #endregion


    #region Private methods

    private void UpdateScoreLabel()
    {
        _dynamicScoreLabel.text = GameManager.Instance.Score.ToString();
    }

    private void InstantiateHearts()
    {
        for (int i = 0; i < GameManager.Instance.MaxLives; i++)
        {
            GameObject heart = Instantiate(_heartCellPrefab, _heartsBar);
            _maxHearts.Add(heart);
        }
    }

    private void UpdatingLifeCells()
    {
        for (int i = 0; i < _maxHearts.Count; i++)
        {
            GameObject heart = _maxHearts[i];
            bool isActive = GameManager.Instance.CurrentLives > i;
            heart.SetActive(isActive);
        }
    }

    #endregion
}
