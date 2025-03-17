using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private PlayerProgressPresenter _playerProgressPresenter;

    [Inject]
    public void Construct(PlayerProgressPresenter playerProgressPresenter)
    {
        _playerProgressPresenter = playerProgressPresenter;
    }

    //private async void Start()
    //{
    //    await _playerProgressPresenter.AddXP(50);
    //    await _playerProgressPresenter.AddXP(60); 
    //}
}
