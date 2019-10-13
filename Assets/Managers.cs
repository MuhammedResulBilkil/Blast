using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    void Start()
    {
        GameController gameController = GameController.Instance;
        AudioController audioController = AudioController.Instance;
    }
}
