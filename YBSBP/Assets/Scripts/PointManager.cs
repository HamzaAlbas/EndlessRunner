using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    #region VARIABLES

    public TMP_Text score, highScore, gold, endScore, menuGold;
    private int _intScore;
    
    private int _highScore, _gold;

    #endregion

    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("highScore").ToString();
        menuGold.text = PlayerPrefs.GetInt("gold").ToString();
        gold.text = PlayerPrefs.GetInt("gold").ToString();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Score"))
        {
            _intScore ++;
            score.text = _intScore.ToString();
            endScore.text = "Score \n" + _intScore;
            other.gameObject.SetActive(false);
            HighScoreSet();
            GoldSet();
        }

        if (_intScore % 15 == 0)
        {
            PlayerController.Instance.speed *= 1.2f;
        }
    }

    private void HighScoreSet()
    {
        if (_intScore>PlayerPrefs.GetInt("highScore"))
        {
            _highScore = _intScore;
            PlayerPrefs.SetInt("highScore", _highScore);
            highScore.text = PlayerPrefs.GetInt("highScore").ToString();
        }
    }

    private void GoldSet()
    {
        bool isMultiple = _intScore % 5 == 0;

        var currentGold = PlayerPrefs.GetInt("gold");
        if (isMultiple)
        {
            _gold++;
            currentGold += _gold;
            PlayerPrefs.SetInt("gold", currentGold);
            gold.text = PlayerPrefs.GetInt("gold").ToString();
        }
    }
}
