using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    
    
    #region VARIABLES

    public float speed;
    private Animator _anim;

    private Vector3 _mousePos;
    private Vector3 _mousePosAfter;
    private bool _clickEnded;

    private bool _onPress;
    private bool _onRelease;
    private bool _gameStarted;

    private Rigidbody _rb;

    [SerializeField] private GameObject mainMenu, inGame;//, store, settings;
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Roll = Animator.StringToHash("Roll");
    private static readonly int StartTheGame = Animator.StringToHash("StartTheGame");

    #endregion

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GetReferences();
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mousePos = Input.mousePosition;
            _clickEnded = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _mousePosAfter = Input.mousePosition;
            _clickEnded = true;
        }
        if (_gameStarted)
        {
            _anim.SetTrigger(StartTheGame);
            AnimationsHandler();
        }
    }

    private void AnimationsHandler()
    {
        var errorMargin = _mousePosAfter.y - _mousePos.y;
        var errorMargin2 = _mousePos.y - _mousePosAfter.y;

        if (errorMargin > 50 && _mousePosAfter.y > _mousePos.y && _clickEnded)
        {
            _mousePos = Vector3.zero;
            _mousePosAfter = Vector3.zero;
            _anim.SetTrigger(Jump);
        }
        if (errorMargin2 > 50 && _mousePos.y > _mousePosAfter.y && _clickEnded)
        {
            _mousePos = Vector3.zero;
            _mousePosAfter = Vector3.zero;
            _anim.SetTrigger(Roll);
        }
        else
        {
            Move(speed);
        }
    }

    private void Move(float playerSpeed)
    {
        _rb.velocity = new Vector3(0, 0, playerSpeed);
    }
    private void GetReferences()
    {
        _anim = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    public void StartRunning()
    {
        _gameStarted = true;
        mainMenu.SetActive(false);
        inGame.SetActive(true);
    }
}