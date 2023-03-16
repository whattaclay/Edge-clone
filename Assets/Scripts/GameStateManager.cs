using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    private bool _isDead = false;
    public static GameObject _player;
    private int _starCounter = 0;
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
        _player = FindObjectOfType<PlayerInput>().gameObject;
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
        Debug.Log(_starCounter);
    }
}