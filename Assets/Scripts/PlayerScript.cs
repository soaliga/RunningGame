using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // �÷��̾ �Ѹ��϶�.
    private static Vector3 m_PlayerPos;
    public static Vector3 PlayerPos { get { return m_PlayerPos; } }
 
    private int m_JumpCount;
    private Rigidbody m_Rigid = null;

    private void Awake()
    {
        Debug.Log("�÷��̾� �����ũ");
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
        //���ó��
        if (transform.position.y <= -MoveCamera.Cam.orthographicSize)
        {
            transform.position = Vector3.zero; // �÷��̾� ����ġ
            MoveCamera.CameraReset(); // ī�޶� ����ġ
            GroundManager.GroundReset(); // �׶��� ���� ó�����·�
        }
    }

    void Update()
    {
        Death();
        // ������ �������ټ� �ִ� �������� �ִ��ѵ��� ������Ʈ.
        // Fixed Update�� ���� ������ �ϳ��ϳ����� ������ ����.
        // Debug.Log("������Ʈ");
        transform.position += Vector3.right * Time.deltaTime * LogicValue.Speed;
        m_PlayerPos = transform.position;

        if (Input.GetKeyDown(KeyCode.Space) == true && m_JumpCount > 0)
        {
            Jump();
        }
    }
    
}
