using UnityEngine;using System;using System.Collections;using System.Collections.Generic; // This class work instead of ChordManager.INetworkListener in unity3d. // You must make child class of this class.// And override functions. public class UniChordManagerNetworkListener{
    // -------------- Virtual functions about ChordManager.INetworkListener ---------------------        // It is called a when specific interface is connected    public virtual void onConnected(UniChordManager.INTERFACE_TYPE interfaceType)    {    }    // It is called when a specific interface is disconnected    public virtual void onDisconnected(UniChordManager.INTERFACE_TYPE interfaceType)    {    }

    // --------------------------------------------------------------------------------------
}