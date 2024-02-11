using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {

	public UDPReceiver updReceiver;
	public TMPro.TextMeshProUGUI axtext;
	private double ax;

	// Use this for initialization
	void Start () {
		UDPReceiver.AccelCallBack += AccelAction;

		updReceiver.UDPStart ();
	}

	public void AccelAction(double xx, double  yy, double zz){
		ax = xx;
	}


	void Update()
	{
		axtext.text = ax.ToString();
	}
}
