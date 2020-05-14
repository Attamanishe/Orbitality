using System;
using System.Collections;
using System.Collections.Generic;
using Comon.SceneManagment;
using Game.SaveLoad;
using Game.World.Manager;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private Button _pause;
    [SerializeField] private Button _resume;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _backToMenu;
    [SerializeField] private Button _saveGame;

    private void Awake()
    {
        _pause.onClick.AddListener(Pause);
        _resume.onClick.AddListener(Resume);
        _backToMenu.onClick.AddListener(ToMenu);
        _saveGame.onClick.AddListener(Save);
        _resume.gameObject.SetActive(false);
    }

    public void Pause()
    {
        WorldManager.Instance.Pause();
        _pausePanel.SetActive(true);
        _resume.gameObject.SetActive(true);
        _pause.gameObject.SetActive(false);
    }

    public void Resume()
    {
        WorldManager.Instance.Resume();
        _pausePanel.SetActive(false);
        _resume.gameObject.SetActive(false);
        _pause.gameObject.SetActive(true);
    }

    public void Save()
    {
        SaveLoadController.Instance.Save(WorldManager.Instance.GetCurrentState());
    }

    public void ToMenu()
    {
        SceneController.LoadScene(Scene.Menu);
    }
}
