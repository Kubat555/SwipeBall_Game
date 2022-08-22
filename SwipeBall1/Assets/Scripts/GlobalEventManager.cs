using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent OpenDoor = new UnityEvent();
    public static UnityEvent CloseDoor = new UnityEvent();
    public static UnityEvent RefreshDoor = new UnityEvent();
    public static UnityEvent RefreshCoin = new UnityEvent();

    public static UnityEvent Win = new UnityEvent();
    public static UnityEvent Lose = new UnityEvent();

}
