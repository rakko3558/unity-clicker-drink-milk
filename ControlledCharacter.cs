using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.WSA;
using TMPro;

public class ControlledCharacter : MonoBehaviour
{

    public GameObject plusOneSign; 
    public TextMeshPro counterText;
    private int CupsCounter=0;

    public SpriteRenderer spriteRenderer;
    public Sprite[] dirnkArray=new Sprite[] { }; 

    public Sprite[] dirnkArrayFunc;
    public Sprite idle; // Sprite for idle 狀態
    public Sprite splash; 
    public Sprite finish; 

    public int drinkIndex = 0;  


    public int drinkLength = 0;
    public bool BackClicking = false; // 檢查點 if the character is drinking

    public bool isSplash = false; // 檢查點  if the character is drinking

    public AudioSource audioSource;
    public AudioClip drinksound;
    public AudioClip drinksound2;
    public AudioClip finishOne;
    public AudioClip spit;

    // Start is called before the first frame update4
    void Start()
    {
        dirnkArrayFunc = new Sprite[(dirnkArray.Length-2)*3+2];
        dirnkArrayFunc[0]=dirnkArray[0];
        dirnkArrayFunc[1] = dirnkArray[1];
        for (int i = 2; i < dirnkArray.Length; i+=2)
        {
            Debug.Log(i);
            for (int j = 0; j < 6; j+=2)
            {
                dirnkArrayFunc[(i-2)*3+j+2] = dirnkArray[i];
                dirnkArrayFunc[(i-2)*3+j+1+2] = dirnkArray[i+1];
            }
        }
        drinkLength = dirnkArrayFunc.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (BackClicking)
            StartCoroutine(DrinkBack());
        
    }

    public void Drink()
    {
        if (isSplash==false)
        {
            drinkIndex++;
            if (drinkIndex / drinkLength == 1)
            {
                spriteRenderer.sprite = finish;
                drinkIndex = -1;
                GameObject theSign = Instantiate(plusOneSign, plusOneSign.transform.position ,Quaternion.identity);
                theSign.SetActive(true);
                CupsCounter++;
                counterText.text=CupsCounter.ToString();


                audioSource.PlayOneShot(finishOne);
            }
            else if (drinkIndex > 1)
            {

                spriteRenderer.sprite = dirnkArrayFunc[drinkIndex]; // 循環 drink sprites
                BackClicking = true;

                if(drinkIndex%2==0)
                    audioSource.PlayOneShot(drinksound);
                else
                    audioSource.PlayOneShot(drinksound2);
            }
            else
            {
                spriteRenderer.sprite = dirnkArrayFunc[drinkIndex]; // 循環 sprites
            }
        }
    }

    private IEnumerator DrinkBack()
    {
        int drinkIndexTmp = drinkIndex;
        yield return new WaitForSeconds(0.3f);
        if (drinkIndexTmp+2 < drinkIndex)
        {

            audioSource.PlayOneShot(spit);
            spriteRenderer.sprite = splash;
            isSplash = true;
            drinkIndex = 0;
            yield return new WaitForSeconds(1f);
            isSplash = false;
            spriteRenderer.sprite = dirnkArrayFunc[drinkIndex];


        }
        /*else if (drinkIndex>1)
        {
            spriteRenderer.sprite = dirnkArrayFunc[drinkIndex - 1];
        }*/
        BackClicking = false;
    }

    public void ResetCharacter()
    {
        drinkIndex = 0;
        spriteRenderer.sprite = idle;
        BackClicking = false;
        isSplash = false;
        CupsCounter = 0;
        counterText.text = CupsCounter.ToString();
    }

}
