using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : GeneralSingleton<GameManager>
{
    #region Variables

    [Header("Lives Settings")]
    [SerializeField] private int _maxLives = 5;
    [SerializeField] private int _startLives = 3;

    [SerializeField] private List<GameObject> _targets;
    [SerializeField] private float _spawnRate = 1f;

    public bool isGameActive;

    #endregion


    #region Events

    public event Action OnScoreChanged;
    public event Action OnLivesChanged;

    #endregion


    #region Properties

    public int Score { get; private set; }
    public int CurrentLives { get; private set; }

    public int MaxLives => _maxLives;

    #endregion


    #region Unity lifecycle

    protected override void Awake()
    {
        base.Awake();
        Reload();
    }    

    #endregion


    #region Public methods

    public void Reload()
    {
        isGameActive = true;
        Score = 0;
        CurrentLives = _startLives;
        StartCoroutine(SpawnTarget());
    }

    public void AddScore(int pointValue)
    {
        Score += pointValue;
        OnScoreChanged?.Invoke();
    }

    public void AddLive()
    {
        if (CurrentLives >= _maxLives)
            return;

        CurrentLives++;

        OnLivesChanged?.Invoke();
    }

    public void RemoveLive()
    {
        CurrentLives--;

        if (CurrentLives < 1)
            isGameActive = false;

        OnLivesChanged?.Invoke();
    }

    #endregion


    #region Private methods

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, _targets.Count);
            Instantiate(_targets[index]);
        }
    }

    #endregion
}