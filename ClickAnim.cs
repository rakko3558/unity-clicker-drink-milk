using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnim : MonoBehaviour
{
    public GameObject animPrefab; // 動畫
    void Update()
    {
        // 偵測滑鼠輸入
        if (Input.GetMouseButtonDown(0))
        {
            SpawnAtPosition(Input.mousePosition);
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SpawnAtPosition(Input.GetTouch(0).position);
        }

    }

    void SpawnAtPosition(Vector2 screenPos)//滑鼠點擊特效(跟隨特效)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos); //(滑鼠位置)
        worldPos.z = 0;

        GameObject animObj = Instantiate(animPrefab, worldPos, Quaternion.identity);
        //播放特效動畫在滑鼠點擊位置
        Animator animator = animObj.GetComponent<Animator>();
        if (animator != null && animator.runtimeAnimatorController != null)
        {
            float clipLength = animator.GetCurrentAnimatorStateInfo(0).length;
            Destroy(animObj, clipLength);
        }
        else
        {
            Destroy(animObj, 1f);  
        }
    }
}
