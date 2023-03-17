using System;
using System.Linq;
using System.Net.Mime;
using Events;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    private bool _isDead = false;
    public static GameObject _player;
    private int _starCounter = 0;
    [SerializeField] private TextMeshProUGUI _textStarCounter;
    private GameObject[] _starsOnScene;
    public UnityEvent allStarsCollected;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        _starsOnScene =GameObject.FindGameObjectsWithTag("Star");
        _player = FindObjectOfType<PlayerInput>().gameObject;
        _textStarCounter.text = _starCounter + " / " + _starsOnScene.Length;
    }

    public void Die()
    {
        Destroy(_player);
        _isDead = true;
        _starCounter = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StarCounter()
    {
        _starCounter += 1;
        _textStarCounter.text = _starCounter + " / " + _starsOnScene.Length;
        if (_starCounter == _starsOnScene.Length)
        {
            allStarsCollected.Invoke();
        }
    }

    
}