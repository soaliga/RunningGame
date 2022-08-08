using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CameraAndPlayerData
{
    public float m_Speed = 5;
    public float m_JumpPower = 5;
    public int m_JumpCount = 3;
}

public class LogicValue : MonoBehaviour
{
    private static LogicValue Inst = null;

    [SerializeField]
    private CameraAndPlayerData m_CameraAndPlayerData = new CameraAndPlayerData();

    public static float Speed { get { return Inst.m_CameraAndPlayerData.m_Speed; } }
    public static float JumpPower { get { return Inst.m_CameraAndPlayerData.m_JumpPower; } }
    public static int JumpCount { get { return Inst.m_CameraAndPlayerData.m_JumpCount; } }

    private void Awake()
    {
        Debug.Log("로직밸류 어웨이크");
        Inst = this;
    }
}
