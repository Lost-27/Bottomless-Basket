using UnityEngine;
using UnityEngine.UI;

public class GOS : MonoBehaviour
{
    #region Veriables

    [SerializeField] private GameObject _innerContainer;
    //[SerializeField] private TextMeshProUGUI _dynamicScoreLabel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _quitButton;

    #endregion


    #region Unity lifcycle

    private void Awake()
    {
        _restartButton.onClick.AddListener(RestartButtonClick);
        _quitButton.onClick.AddListener(QuitButtonClick);
        _innerContainer.SetActive(false);
    }   


    private void Update()
    {
        if (GameManager.Instance.CurrentLives < 1)
        {
            _innerContainer.SetActive(true);
        }
        
    }

    #endregion


    #region Private methods
    private void QuitButtonClick()
    {
        SceneHelper.Instance.Quit();
    }

    private void RestartButtonClick()
    {
        SceneHelper.Instance.ResetActiveScene();
        GameManager.Instance.Reload();
    }
    #endregion
}
