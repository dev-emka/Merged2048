
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    BoardManager boardManager;
    [SerializeField] GameObject box_2, box_4, box_8, box_16, box_32, box_64, box_128, box_256, box_512, box_1024, box_2048;
    [SerializeField] Sprite box_2i, box_4i, box_8i, box_16i, box_32i, box_64i, box_128i, box_256i, box_512i, box_1024i, box_2048i;
    public List<Vector2> boardMemory= new List<Vector2>();
    public bool isGamePlay,isDone;
    public int values;
    public int State;
    
    [SerializeField] Image boxImage;
    public GameObject box;

    
    private void Start()
    {
        State = 0;
        isGamePlay = false;
        boardManager = GameObject.FindObjectOfType<BoardManager>();
        values = GetRandomValue();
        GetSelectedBoxes(values);
        GetSelectedImage(values);
    }

    void Update()
    {
       TouchEvent();
    }

    private void TouchEvent()
    {
        if (Input.touchCount > 0)
        {
            boardManager.CheckToStates();
            Touch touch = Input.touches[0];
            print("burada eleman");
            Vector2 touchPos = VectorToInt(Camera.main.ScreenToWorldPoint(touch.position));
            bool IsBoardValid = boardManager.IsBoardValid(touchPos);
            bool IsSquareFull = boardManager.IsSquareFull((int)touchPos.x, (int)touchPos.y);
            if (touch.phase == TouchPhase.Ended&&isDone || touch.phase == TouchPhase.Canceled&&isDone)
            {
                print("bitti");
                boardMemory.Clear();
                values = GetRandomValue();
                GetSelectedBoxes(values);
                GetSelectedImage(values);
                isDone = false;
            }

            
            if (boardManager.IsBoardValid(touchPos))
            {
                return;
            }
            if (boardManager.IsSquareFull((int)touchPos.x, (int)touchPos.y))
            {
                return;
            }
           

            if (touch.phase == TouchPhase.Began)
            {
                if (values == 2)
                {
                    boardMemory.Add(touchPos);
                    CreateGameBox(touchPos);
                    values = 0;
                    isDone = true;
                    return;
                }
                boardMemory.Add(touchPos);
                CreateGameBox(touchPos);
                isDone = true;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                boardMemory.Add(touchPos);
                values /= 2;
                if (values == 0)
                    return;
                if (values < 2)
                {
                    print("values" + values);
                    values = 2;
                    GetSelectedBoxes(values);
                    CreateGameBox(touchPos);
                    values = 0;
                    isDone = true;
                    return;
                }

                GetSelectedBoxes(values);
                CreateGameBox(touchPos);
                isDone = true;
            }

        }
        
    }

    public void CreateGameBox(Vector2 touchPos)
    {
        GameObject TurnGameBox = Instantiate(box, touchPos, Quaternion.identity);
        boardManager.GetToShapeinGrid(TurnGameBox, values);
    }

    int GetRandomValue()
    {
        switch (State)
        {
            case 0:

                int random = Random.Range(0, 100);
                if (random <= 9)
                    return 2; 
                if (random <= 19 && random > 9)
                    return 4; 
                if (random <= 39 && random > 19)
                    return 8; 
                if (random <= 59 && random > 39)
                    return 16; 
                if (random <= 79 && random > 59)
                    return 32;
                if (random <= 99 && random > 79)
                    return 64;

                break;
            case 1:

                int random2 = Random.Range(0, 100);
                if (random2 <= 4)
                    return 2; 
                if (random2 <= 12 && random2 > 4)
                    return 4;
                if (random2 <= 27 && random2 > 12)
                    return 8;
                if (random2 <= 47 && random2 > 27)
                    return 16;
                if (random2 <= 77 && random2 > 47)
                    return 32;
                if (random2 <= 97 && random2 > 77)
                    return 64;
                if (random2 <= 99 && random2 > 97)
                    return 128;
                break;
            case 2:

                int random3 = Random.Range(0, 100);
                if (random3 <= 0)
                    return 2;
                if (random3 <= 2 && random3 > 0)
                    return 4;
                if (random3 <= 17 && random3 > 2)
                    return 8;
                if (random3 <= 37 && random3 > 17)
                    return 16;
                if (random3 <= 67 && random3 > 37)
                    return 32;
                if (random3 <= 92 && random3 > 67)
                    return 64;
                if (random3 <= 97 && random3 > 92)
                    return 128;
                if (random3 <= 99 && random3 > 97)
                    return 256;
                break; 
            case 3:

                int random4 = Random.Range(0, 100);
                if (random4 <= 0)
                    return 2;
                if (random4 <= 2 && random4 > 0)
                    return 4;
                if (random4 <= 12 && random4 > 2)
                    return 8;
                if (random4 <= 32 && random4 > 12)
                    return 16;
                if (random4 <= 59 && random4 > 32)
                    return 32;
                if (random4 <= 84 && random4 > 59)
                    return 64;
                if (random4 <= 94 && random4 > 84)
                    return 128;
                if (random4 <= 99 && random4 > 94)
                    return 256;
                break;
        }
        return 16;
    }


    public void GetSelectedBoxes(int i)
    {
        switch (i)
        {
            case 2:
                box = box_2;
                break;

            case 4:
                box = box_4;
                break;
            case 8:
                box = box_8;
                break;

            case 16:
                box = box_16;
                break;

            case 32:
                box = box_32;
                break;
            case 64:
                box = box_64;
                break;

            case 128:
                box = box_128;
                break;

            case 256:
                box = box_256;
                break;

            case 512:
                box = box_512;
                break;

            case 1024:
                box = box_1024;
                break;

            case 2048:
                box = box_2048;
                boxImage.sprite = box_2048i;
                break;
            default:
                box = box_2;
                break;
        }
    }
    void GetSelectedImage(int value)
    {

        switch (value)
        {
            case 2:
                boxImage.sprite = box_2i;
                break;

            case 4:
                boxImage.sprite = box_4i;
                break;
            case 8:
                boxImage.sprite = box_8i;
                break;

            case 16:
                boxImage.sprite = box_16i;
                break;

            case 32:
                boxImage.sprite = box_32i;
                break;
            case 64:
                boxImage.sprite = box_64i;
                break;

            case 128:
                boxImage.sprite = box_128i;
                break;

            case 256:
                boxImage.sprite = box_256i;
                break;

            case 512:
                boxImage.sprite = box_512i;
                break;

            case 1024:
                boxImage.sprite = box_1024i;
                break;

            case 2048:
                boxImage.sprite = box_2048i;
                break;
        }
    }
    Vector2 VectorToInt(Vector2 vector)
    {
        return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
    }

    //public void Click(Image ımage)
    ////{
    ////    int values = GetRandomValue();
    ////    ımage.sprite = SelectedSprite(values);
    //}
}

