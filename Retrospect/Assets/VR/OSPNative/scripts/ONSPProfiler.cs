using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;
using System.Net.NetworkInformation;


public class ONSPProfiler : MonoBehaviour
{
    // Import functions
    public const string strONSPS = "AudioPluginOculusSpatializer";

    public bool profilerEnabled = false;
    const int DEFAULT_PORT = 2121;
    public int port = DEFAULT_PORT;

    void Start()
    {
        Application.runInBackground = true;
        if (profilerEnabled)
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            //do what you want with the IP here... add it to a list, just get the first and break out. Whatever.
                            Debug.Log("Oculus Audio Profiler enabled, IP address = " + ip.Address.ToString());
                        }
                    }
                }
            }
        }
    }

    void Update()
    {
        if (port < 0 || port > 65535)
        {
            port = DEFAULT_PORT;
        }
        ONSP_SetProfilerPort(port);
        ONSP_SetProfilerEnabled(profilerEnabled);
    }

    [DllImport(strONSPS)]
    private static extern int ONSP_SetProfilerEnabled(bool enabled);

    [DllImport(strONSPS)]
    private static extern int ONSP_SetProfilerPort(int port);
}
