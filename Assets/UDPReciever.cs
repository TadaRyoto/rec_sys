using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

public class UDPReceiver : MonoBehaviour {
	
	int LOCAL_PORT = 22223;
	static UdpClient udp;
	Thread thread;
	public static Action<double, double, double> AccelCallBack;

	public void UDPStart(){
		udp = new UdpClient (LOCAL_PORT);
		thread = new Thread (new ThreadStart (ThreadMethod));
		thread.Start ();
	}

	private static void ThreadMethod()
	{
		while (true)
		{
			IPEndPoint remoteEp = null;
			Debug.Log ("debugnow");
			byte[] data = udp.Receive (ref remoteEp);
			string text = Encoding.ASCII.GetString (data);

			JsonNode jsonNode = JsonNode.Parse (text);

			double ax = jsonNode ["sensordata"] ["accel"] ["x"].Get<double> ();
			double ay = jsonNode ["sensordata"] ["accel"] ["y"].Get<double> ();
			double az = jsonNode ["sensordata"] ["accel"] ["z"].Get<double> ();

			AccelCallBack (ax, ay, az);

			//Debug.Log("ax = " + ax + ", ay = " + ay + ", az = " + az);
		}
	}

	void OnApplicationQuit(){
		thread.Abort ();
	}
}