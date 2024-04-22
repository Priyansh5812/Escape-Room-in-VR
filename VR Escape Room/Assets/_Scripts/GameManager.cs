using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class GameManager
{

    #region Service References        
    private AudioService _audioService;
    private InputActionManager _inputService;
    private InputService _customInputService;
    private PlayerView _playerView;
    #endregion Service References

    #region Booleans
    private bool isGameOver;

    #endregion Booleans


    #region Constructors
    GameManager() { }


    GameManager(bool isGameOver)
    {
        this.isGameOver = isGameOver;
    }

    #endregion Constructors


    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager(false);
            }
            return _instance;
        }
    }

    public AudioService GetAudioService()
    {
        if (_audioService == null)
        {   //Almost 0 chances to get this condition validated
            this._audioService = GameObject.FindGameObjectWithTag("AudioService").GetComponent<AudioService>();
        }
        return _audioService;
    }
    public InputActionManager GetInputActionManager()
    {
        if (_inputService == null)
        {   //Almost 0 chances to get this condition validated
            this._inputService = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputActionManager>();
        }
        return _inputService;
    }
    public InputService GetInputService()
    {
        return _customInputService;
    }

    public PlayerView GetPlayerView() 
    {
        return _playerView;
    }


    public void SetGameOver(bool val)
    {
        this.isGameOver = val;
        if (val)
        {
            OnGameOver();
        }
        
    }

    public bool IsGameOver()
    {
        return this.isGameOver;
    }



    public void SetInputActionManager(InputActionManager service)
    {
        _inputService = service;
    }
    public void SetInputService(InputService service)
    {
        _customInputService = service;
    }


    public void SetAudioService(AudioService service)
    {
        _audioService = service;
    }

    public void SetPlayerView(PlayerView view)
    {
        _playerView = view;
    }

    private void OnGameOver()
    {
        _playerView.TranslateViewPitch();
    }

}
