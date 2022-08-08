using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    //스프라이트
    public Sprite groundSp;
    public GameObject firstGround;
    // Y위치 랜덤설정 범위
    [SerializeField]
    private float createRandomRangeYStart = -2.0f;
    [SerializeField]
    private float createRandomRangeYEnd = 2.0f;
    // X 스케일 랜덤설정 범위
    [SerializeField]
    private float createRandomScaleXStart = 5.0f;
    [SerializeField]
    private float createRandomScaleXEnd = 10.0f;
    // 만들어질 범위
    [SerializeField]
    private float CreateRange = 20.0f;
    // 마지막으로 만들어진 판자의 X
    [SerializeField]
    private float LastCreatePosX = 0;
    // 마지막으로 만들어진 판자의 크기
    [SerializeField]
    private float LastCreateScaleX = 0;

    private float ResetScaleX = 0;
    private float ResetPosX = 0;

    public static GroundManager MainGroundMgr;
    public static void GroundReset()
    {
        MainGroundMgr.ResetData();
    }
    void Awake()
    {
        ResetPosX = LastCreatePosX;
        ResetScaleX = LastCreateScaleX;

        MainGroundMgr = this;

        Debug.Log("그라운드 어웨이크");
        LastCreateScaleX = firstGround.transform.localScale.x;
        Debug.Log(LastCreateScaleX);
    }

    public void ResetData()
    {
        LastCreatePosX = ResetPosX;
        LastCreateScaleX = ResetScaleX;
    }
    bool NewGroundLogic()
    {
        if (LastCreatePosX >= PlayerScript.PlayerPos.x + CreateRange)
        {
            return false;
        }
        GameObject newGround = new GameObject("Grond");
        newGround.gameObject.tag = "Ground";
        newGround.transform.localScale = new Vector3((int)Random.Range(createRandomScaleXStart, createRandomScaleXEnd), 1, 1);

        Vector3 createPos = newGround.transform.position;

        float newScale = 5;
        newScale = newGround.transform.localScale.x;
        createPos.x = LastCreatePosX + LastCreateScaleX * 0.5f + newScale * 0.5f + Random.Range(1, 3); // x의 위치
        createPos.y = Random.Range(createRandomRangeYStart, createRandomRangeYEnd); // y 위치
        createPos.z = 0;

        newGround.transform.position = createPos;

        newGround.gameObject.AddComponent<SpriteRenderer>();
        SpriteRenderer newSprite = newGround.GetComponent<SpriteRenderer>();
        newSprite.sprite = groundSp;

        LastCreatePosX = createPos.x;
        LastCreateScaleX = newGround.transform.localScale.x;       

        newGround.gameObject.AddComponent<BoxCollider>();
        newGround.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);

        newGround.gameObject.AddComponent<GroundScript>();
        return true;
    }
    
    void Update()
    {
        NewGroundLogic();
    }
}
