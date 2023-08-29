using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] GameObject backTile;
    GameManager manager;
    public int height=5,weight=5;
    Transform[,]TheGrid;
    public int[,] gridValues;
    private void Start()
    {
        manager=GameObject.FindObjectOfType<GameManager>();
        height = 5;
        weight = 5;
        TheGrid=new Transform[weight, height];
        gridValues = new int[height,weight];
        print(gridValues[0, 0]);
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < weight; j++)
            {
                GameObject backTiles = Instantiate(backTile, new Vector2(j, i), Quaternion.identity, transform);
            }
        }
        manager.isGamePlay=true;

    }
   
    public void CheckToStates()
    {
        for(int i = 0;i < height; i++)
        {
            for (int j = 0; j < weight; j++)
            {
                if (gridValues[j, i] == 256)
                    manager.State = 1;

                if (gridValues[j, i] == 512)
                    manager.State = 2;

                if (gridValues[j, i] == 1024)
                    manager.State = 3;
            }
        }
    }

    public bool IsBoardValid(Vector2 pos)
    {
        if (pos.x !> weight || pos.x !< 0 || pos.y !> height || pos.y !< 0)
        {    
            return true;
        }
        else
            return false;
    }

    public bool IsSquareFull(int x, int y)
    {
        return (TheGrid[x, y] != null);
        
    }

    public void GetToShapeinGrid(GameObject box,int value)
    {
        Vector2 pos = VectorToInt(box.transform.position);
        box.transform.SetParent(transform);
        TheGrid[(int)pos.x, (int)pos.y] = box.transform;
        gridValues[(int)pos.x, (int)pos.y] = value;
        print(gridValues[(int)pos.x, (int)pos.y]);
        CheckToValues();
    }

    public void CheckToValues()
    {
        #region horizontalBool
        bool zeroZeroRight = gridValues[0, 0] == gridValues[1, 0] && gridValues[0, 0] == gridValues[2, 0] && gridValues[0,0]!=0;
        bool zeroOneRight = gridValues[2, 0] == gridValues[1, 0] && gridValues[1, 0] == gridValues[3, 0] && gridValues[1, 0] != 0;
        bool zeroTwoRight = gridValues[3, 0] == gridValues[2, 0] && gridValues[2, 0] == gridValues[4, 0] && gridValues[2, 0] != 0;
       
        bool oneZeroRight = gridValues[0, 1] == gridValues[1, 1] && gridValues[0, 1] == gridValues[2, 1] && gridValues[0,1]!=0;
        bool oneOneRight = gridValues[2, 1] == gridValues[1, 1] && gridValues[1, 1] == gridValues[3, 1] && gridValues[1, 1] != 0;
        bool oneTwoRight = gridValues[3, 1] == gridValues[2, 1] && gridValues[2, 1] == gridValues[4, 1] && gridValues[2, 1] != 0;
        
        bool twoZeroRight = gridValues[0, 2] == gridValues[1, 2] && gridValues[0, 2] == gridValues[2, 2] && gridValues[0,2]!=0;
        bool twoOneRight = gridValues[2, 2] == gridValues[1, 2] && gridValues[1, 2] == gridValues[3, 2] && gridValues[1, 2] != 0;
        bool twoTwoRight = gridValues[3, 2] == gridValues[2, 2] && gridValues[2, 2] == gridValues[4, 2] && gridValues[2, 2] != 0;
        
        bool threeZeroRight = gridValues[0, 3] == gridValues[1, 3] && gridValues[0, 3] == gridValues[2, 3] && gridValues[0,3]!=0;
        bool threeOneRight = gridValues[2, 3] == gridValues[1, 3] && gridValues[1, 3] == gridValues[3, 3] && gridValues[1, 3] != 0;
        bool threeTwoRight = gridValues[3, 3] == gridValues[2, 3] && gridValues[2, 3] == gridValues[4, 3] && gridValues[2, 3] != 0;
       
        bool fourZeroRight = gridValues[0, 4] == gridValues[1, 4] && gridValues[0, 4] == gridValues[2, 4] && gridValues[0,4]!=0;
        bool fourOneRight = gridValues[2, 4] == gridValues[1, 4] && gridValues[1, 4] == gridValues[3, 4] && gridValues[1, 4] != 0;
        bool fourTwoRight = gridValues[3, 4] == gridValues[2, 4] && gridValues[2, 4] == gridValues[4, 4] && gridValues[2, 4] != 0;

        //Y=0
        if (zeroZeroRight)
        {
            manager.values = gridValues[2, 0] * 2;
            Destroy(TheGrid[0, 0].gameObject);
            Destroy(TheGrid[1, 0].gameObject);
            Destroy(TheGrid[2, 0].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(2, 0));
        }
        if (zeroOneRight)
        {
            manager.values = gridValues[2, 0] * 2;
            Destroy(TheGrid[3, 0].gameObject);
            Destroy(TheGrid[1, 0].gameObject);
            Destroy(TheGrid[2, 0].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(3, 0));
        }
        if (zeroTwoRight)
        {
            manager.values = gridValues[2, 0] * 2;
            Destroy(TheGrid[4, 0].gameObject);
            Destroy(TheGrid[3, 0].gameObject);
            Destroy(TheGrid[2, 0].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(4, 0));
        }

        //Y=1
        if (oneZeroRight)
        {
            manager.values = gridValues[2, 1] * 2;
            Destroy(TheGrid[0, 1].gameObject);
            Destroy(TheGrid[1, 1].gameObject);
            Destroy(TheGrid[2, 1].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(2, 1));
        }
        if (oneOneRight)
        {
            manager.values = gridValues[2, 1] * 2;
            Destroy(TheGrid[3, 1].gameObject);
            Destroy(TheGrid[1, 1].gameObject);
            Destroy(TheGrid[2, 1].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(3, 1));
        }
        if (oneTwoRight)
        {
            manager.values = gridValues[2, 1] * 2;
            Destroy(TheGrid[4, 1].gameObject);
            Destroy(TheGrid[3, 1].gameObject);
            Destroy(TheGrid[2, 1].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(4, 1));
        }
        
        //Y=2
        if (twoZeroRight)
        {
            manager.values = gridValues[2, 2] * 2;
            Destroy(TheGrid[0, 2].gameObject);
            Destroy(TheGrid[1, 2].gameObject);
            Destroy(TheGrid[2, 2].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(2, 2));
        }
        if (twoOneRight)
        {
            manager.values = gridValues[2, 2] * 2;
            Destroy(TheGrid[3, 2].gameObject);
            Destroy(TheGrid[1, 2].gameObject);
            Destroy(TheGrid[2, 2].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(3, 2));
        }
        if (twoTwoRight)
        {
            manager.values = gridValues[2, 2] * 2;
            Destroy(TheGrid[4, 2].gameObject);
            Destroy(TheGrid[3, 2].gameObject);
            Destroy(TheGrid[2, 2].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(4, 2));
        }

        //Y=3
        if (threeZeroRight)
        {
            manager.values = gridValues[2, 3] * 2;
            Destroy(TheGrid[0, 3].gameObject);
            Destroy(TheGrid[1, 3].gameObject);
            Destroy(TheGrid[2, 3].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(2, 3));
        }
        if (threeOneRight)
        {
            manager.values = gridValues[2, 3] * 2;
            Destroy(TheGrid[3, 3].gameObject);
            Destroy(TheGrid[1, 3].gameObject);
            Destroy(TheGrid[2, 3].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(3, 2));
        }
        if (threeTwoRight)
        {
            manager.values = gridValues[2, 3] * 2;
            
            Destroy(TheGrid[4, 3].gameObject);
            Destroy(TheGrid[3, 3].gameObject);
            Destroy(TheGrid[2, 3].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(4, 3));
        }

        //Y=4
        if (fourZeroRight)
        {
            manager.values = gridValues[2, 4] * 2;
            Destroy(TheGrid[0, 4].gameObject);
            Destroy(TheGrid[1, 4].gameObject);
            Destroy(TheGrid[2, 4].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(2, 4));
        }
        if (fourOneRight)
        {
            manager.values = gridValues[2, 4] * 2;
            Destroy(TheGrid[3, 4].gameObject);
            Destroy(TheGrid[1, 4].gameObject);
            Destroy(TheGrid[2, 4].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(3, 4));
        }
        if (fourTwoRight)
        {
            manager.values = gridValues[2, 4] * 2;

            Destroy(TheGrid[4, 4].gameObject);
            Destroy(TheGrid[3, 4].gameObject);
            Destroy(TheGrid[2, 4].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(4, 4));
        }



        #endregion

        #region verticalBool
        bool zeroOneUp = gridValues[0, 1] == gridValues[0, 3] && gridValues[0, 1] == gridValues[0, 2] && gridValues[0, 1] != 0;
        bool zeroZeroUp = gridValues[0, 0] == gridValues[0, 1] && gridValues[0, 0] == gridValues[0, 2] && gridValues[0, 0] != 0;
        bool zeroTwoUp = gridValues[0, 2] == gridValues[0, 4] && gridValues[0, 3] == gridValues[0, 2] && gridValues[0, 2] != 0;

        bool oneOneUp = gridValues[1, 1] == gridValues[1, 3] && gridValues[1, 1] == gridValues[1, 2] && gridValues[1, 1] != 0;
        bool oneZeroUp = gridValues[1, 0] == gridValues[1, 1] && gridValues[1, 0] == gridValues[1, 2] && gridValues[1, 0] != 0;
        bool oneTwoUp = gridValues[1, 2] == gridValues[1, 4] && gridValues[1, 3] == gridValues[1, 2] && gridValues[1, 2] != 0;
        
        bool twoOneUp = gridValues[2, 1] == gridValues[2, 3] && gridValues[2, 1] == gridValues[2, 2] && gridValues[2, 1] != 0;
        bool twoZeroUp = gridValues[2, 0] == gridValues[2, 1] && gridValues[2, 0] == gridValues[2, 2] && gridValues[2, 0] != 0;
        bool twoTwoUp = gridValues[2, 2] == gridValues[2, 4] && gridValues[2, 3] == gridValues[2, 2] && gridValues[2, 2] != 0;

        bool threeOneUp = gridValues[3, 1] == gridValues[3, 3] && gridValues[3, 1] == gridValues[3, 2] && gridValues[3, 1] != 0;
        bool threeZeroUp = gridValues[3, 0] == gridValues[3, 1] && gridValues[3, 0] == gridValues[3, 2] && gridValues[3, 0] != 0;
        bool threeTwoUp = gridValues[3, 2] == gridValues[3, 4] && gridValues[3, 3] == gridValues[3, 2] && gridValues[3, 2] != 0;

        bool fourOneUp = gridValues[4, 1] == gridValues[4, 3] && gridValues[4, 1] == gridValues[4, 2] && gridValues[4, 1] != 0;
        bool fourZeroUp = gridValues[4, 0] == gridValues[4, 1] && gridValues[4, 0] == gridValues[4, 2] && gridValues[4, 0] != 0;
        bool fourTwoUp = gridValues[4, 2] == gridValues[4, 4] && gridValues[4, 3] == gridValues[4, 2] && gridValues[4, 2] != 0;

        //X=0
        if (zeroZeroUp)
        {
            manager.values = gridValues[0, 0] * 2;
            Destroy(TheGrid[0, 0].gameObject);
            Destroy(TheGrid[0, 1].gameObject);
            Destroy(TheGrid[0, 2].gameObject);
            manager.GetSelectedBoxes(manager.values); 
            manager.CreateGameBox(new Vector2Int(0, 1));
        }
        if (zeroOneUp)
        {
            manager.values = gridValues[1, 0] * 2;
            Destroy(TheGrid[0, 1].gameObject);
            Destroy(TheGrid[0, 2].gameObject);
            Destroy(TheGrid[0, 3].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(0, 1));
        }
        if (zeroTwoUp)
        {
            manager.values = gridValues[0, 2] * 2;
            Destroy(TheGrid[0, 2].gameObject);
            Destroy(TheGrid[0, 4].gameObject);
            Destroy(TheGrid[0, 3].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(0, 2));
        }


        //X=1
        if (oneZeroUp)
        {
            manager.values = gridValues[1, 0] * 2;
            Destroy(TheGrid[1, 0].gameObject);
            Destroy(TheGrid[1, 1].gameObject);
            Destroy(TheGrid[1, 2].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(0, 1));
        }
        if (oneOneUp)
        {
            manager.values = gridValues[1, 0] * 2;
            Destroy(TheGrid[1, 1].gameObject);
            Destroy(TheGrid[1, 2].gameObject);
            Destroy(TheGrid[1, 3].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(1, 1));
        }
        if (oneTwoUp)
        {
            manager.values = gridValues[1, 2] * 2;
            Destroy(TheGrid[1, 2].gameObject);
            Destroy(TheGrid[1, 4].gameObject);
            Destroy(TheGrid[1, 3].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(1, 2));
        }

        //X=2
        if (twoZeroUp)
        {
            manager.values = gridValues[2, 0] * 2;
            Destroy(TheGrid[2, 0].gameObject);
            Destroy(TheGrid[2, 1].gameObject);
            Destroy(TheGrid[2, 2].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(2, 1));
        }
        if (twoOneUp)
        {
            manager.values = gridValues[2, 0] * 2;
            Destroy(TheGrid[2, 1].gameObject);
            Destroy(TheGrid[2, 2].gameObject);
            Destroy(TheGrid[2, 3].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(2, 1));
        }
        if (twoTwoUp)
        {
            manager.values = gridValues[2, 2] * 2;
            Destroy(TheGrid[2, 2].gameObject);
            Destroy(TheGrid[2, 4].gameObject);
            Destroy(TheGrid[2, 3].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(2, 2));
        }

        //X=3
        if (threeZeroUp)
        {
            manager.values = gridValues[3, 0] * 2;
            Destroy(TheGrid[3, 0].gameObject);
            Destroy(TheGrid[3, 1].gameObject);
            Destroy(TheGrid[3, 2].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(3, 1));
        }
        if (threeOneUp)
        {
            manager.values = gridValues[3, 0] * 2;
            Destroy(TheGrid[3, 1].gameObject);
            Destroy(TheGrid[3, 2].gameObject);
            Destroy(TheGrid[3, 3].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(3, 1));
        }
        if (threeTwoUp)
        {
            manager.values = gridValues[3, 2] * 2;
            Destroy(TheGrid[3, 2].gameObject);
            Destroy(TheGrid[3, 4].gameObject);
            Destroy(TheGrid[3, 3].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(3, 2));
        }

        //X=4
        if (fourZeroUp)
        {
            manager.values = gridValues[4, 0] * 2;
            Destroy(TheGrid[4, 0].gameObject);
            Destroy(TheGrid[4, 1].gameObject);
            Destroy(TheGrid[4, 2].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(4, 1));
        }
        if (fourOneUp)
        {
            manager.values = gridValues[4, 0] * 2;
            Destroy(TheGrid[4, 1].gameObject);
            Destroy(TheGrid[4, 2].gameObject);
            Destroy(TheGrid[4, 3].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(4, 1));
        }
        if (fourTwoUp)
        {
            manager.values = gridValues[4, 2] * 2;
            Destroy(TheGrid[4, 2].gameObject);
            Destroy(TheGrid[4, 4].gameObject);
            Destroy(TheGrid[4, 3].gameObject);
            manager.GetSelectedBoxes(manager.values);
            manager.CreateGameBox(new Vector2Int(4, 2));
        }
        #endregion








    }

    Vector2 VectorToInt(Vector2 vector)
    {
        return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
    }
}
