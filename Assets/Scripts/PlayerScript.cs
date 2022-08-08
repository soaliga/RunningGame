using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // 플레이어가 한명일때.
    private static Vector3 m_PlayerPos;
    public static Vector3 PlayerPos { get { return m_PlayerPos; } }
 
    private int m_JumpCount;
    private Rigidbody m_Rigid = null;

    private void Awake()
    {
        Debug.Log("플레이어 어웨이크");
        m_Rigid = GetComponent<Rigidbody>();
        m_JumpCount = LogicValue.JumpCount;
        if (m_Rigid == null) Debug.LogError("Rigid == null");
    }

    private void Jump()
    {
        m_Rigid.velocity = Vector3.zero;
        m_Rigid.AddForce(Vector3.up * LogicValue.JumpPower);       
        --m_JumpCount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //m_isJump = false;
            m_JumpCount = LogicValue.JumpCount;
        }
    }
    private void Death()
    {
        //사망처리
        if (transform.position.y <= -MoveCamera.Cam.orthographicSize)
        {
            transform.position = Vector3.zero; // 플레이어 원위치
            MoveCamera.CameraReset(); // 카메라 원위치
            GroundManager.GroundReset(); // 그라운드 리셋 처음상태로
        }
    }

    void Update()
    {
        Death();
        // 게임이 실행해줄수 있는 프레임의 최대한도로 업데이트.
        // Fixed Update는 게임 프레임 하나하나마다 무조건 실행.
        // Debug.Log("업데이트");
        transform.position += Vector3.right * Time.deltaTime * LogicValue.Speed;
        m_PlayerPos = transform.position;

        if (Input.GetKeyDown(KeyCode.Space) == true && m_JumpCount > 0)
        {
            Jump();
        }
    }
    
}
