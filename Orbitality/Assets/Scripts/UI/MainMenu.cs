using System;
using System.Collections;
using System.Collections.Generic;
using Comon.SceneManagment;
using Game.SaveLoad;
using Game.World.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _newGame;
    [SerializeField] private Button _loadGame;
    [SerializeField] private Slider _playersCountSlider;
    [SerializeField] private TMP_Text _playersCountText;
    private void Awake()
    {
        LaunchGameSettings.Instance.StateToLoad = default;
        _newGame.onClick.AddListener(NewGame);
        _loadGame.onClick.AddListener(LoadGame);
        _loadGame.enabled = SaveLoadController.Instance.HasSave();
        _playersCountText.text = _playersCountSlider.value.ToString();
        _playersCountSlider.onValueChanged.AddListener(v => _playersCountText.text = v.ToString());
    }

    public void NewGame()
    {
        SceneController.LoadScene(Scene.Game);
        LaunchGameSettings.Instance.PlayersCount = (int) _playersCountSlider.value;
    }

    public void LoadGame()
    {
        LaunchGameSettings.Instance.StateToLoad = SaveLoadController.Instance.LoadGame();
        SceneController.LoadScene(Scene.Game);
    }
}
