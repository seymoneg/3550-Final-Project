using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreKeeper : MonoBehaviour
{
    public int score { get; private set; }

    public UnityEvent<ScoreKeeper> onCollect;

    public void collected()
    {
        score++;
        onCollect.Invoke(this);
    }

}
