using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    private GameObject _gameManager;
    private GameKeeper _gameKeeper;
    private GameObject _jetManager;
    private JetKeeper _jetKeeper;
    private double JetStrong;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager");
        _gameKeeper = _gameManager.GetComponent<GameKeeper>();
        _jetManager = GameObject.Find("Cylinder1");
        _jetKeeper = _jetManager.GetComponent<JetKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameKeeper.isFinished)
        {
            var main = particle.main;
            JetStrong = _jetKeeper.JetStrongPlayer1;
            main.startSpeed = (float)JetStrong / 24;
            particle.Stop(true);
        }

        if (_gameKeeper.isFinished)
        {
            particle.Play();
        }
    }
}
