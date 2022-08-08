using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    private static Vector3 StartPos = Vector3.zero;
    private static MoveCamera GameCamera = null;
    public static Camera Cam;
    public static void CameraReset()
    {
        GameCamera.transform.position = StartPos;
    }
    private void Awake()
    {
        Debug.Log("무브카메라 어웨이크");
        Cam = GetComponent<Camera>();
        StartPos = transform.position;
        GameCamera = this;
    }
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * LogicValue.Speed;
    }
}
