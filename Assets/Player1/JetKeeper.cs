using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetKeeper : MonoBehaviour
{
    public UDPReceiver updReceiver;
    private GameObject _gameManager;
    private GameKeeper _gameKeeper;
    private double ax, ay, az;
    private bool isDetect = false;
    private int JetCountPlayer1 = 0;
    public double JetStrongPlayer1 = 0;
    private int pushCountPlayer1 = 0;
    public TMPro.TextMeshProUGUI axtext;//デバッグ用

    private Vector3 _direction = new Vector3(10.0f, 10.0f, 0f);
    void Start()
    {
        _gameManager = GameObject.Find("GameManager");
        _gameKeeper = _gameManager.GetComponent<GameKeeper>();
		UDPReceiver.AccelCallBack += AccelAction;
		updReceiver.UDPStart ();
    }
    public void AccelAction(double xx, double  yy, double zz){
        ax = xx;
        ay = yy;
        az = zz;
	}

    void Update()
    {
        if (_gameKeeper.isStarted)
        {
            isDetect = detectBythreshold(ax, ay, az);
            if (isDetect)
            {
                pushCountPlayer1++;

                if (pushCountPlayer1 % 10 == 0) {
                    JetCountPlayer1++;
                    if (JetCountPlayer1 % 2 == 0)
                    {
                        transform.Translate(_direction);
                    } 
                    else
                    {
                        transform.Translate(-1 * _direction);
                    }
                    JetStrongPlayer1 += Math.Sqrt(ax*ax + ay*ay + az*az) ;
                    axtext.text = JetStrongPlayer1.ToString();
                }
            }
        }
    }
        

    bool detectBythreshold(double ax, double ay, double az)
    {
        double powerX2 = ax * ax;
        double powerY2 = ay * ay;
        double powerZ2 = az * az;
        double threshold = 0.5d;

        if(powerX2 > powerY2 && powerX2 > powerZ2)
        {
            if(powerX2 > threshold)
            {
                return true;
            }
        }
        else if (powerY2 > powerX2 && powerY2 > powerZ2)
        {
            if (powerY2 > threshold)
            {
                return true;
            }

        }
        else if (powerZ2 > powerY2 && powerZ2 > powerX2)
        {
            if (powerZ2 > threshold)
            {
                return true;
            }
        }

        return false;
    }
}
