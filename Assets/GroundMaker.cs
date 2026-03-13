using UnityEngine;

public class GroundMaker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float OffsetMax = 3f;

    public float OffsetMin = -1f;
    int GroundCount = 0;

    public GameObject[] prefabs;              //遊戲物件宣告
    void Start()
    {

        InvokeRepeating("MakeGround", 1f, 2f);
        //InvokeRepeating重複執行(執行物,初始執行時間,每幾秒執行次數)
    }

    // Update is called once per frame
  void MakeGround()
    {
        int Number = Random.Range(0, 4);
        Instantiate(prefabs[Number],
        transform.position + new Vector3(Random.Range(OffsetMin, OffsetMax), 0, 0),
        transform.rotation);
        //Instantiate實體化物件(生成物,生成為值以上為位子不變,生成角度以上為預設)
        //Vector 3 為三向量也就是xyz，Random是隨機Range是範圍小到大
        GroundCount++;
        Debug.Log("生成第" + GroundCount + "地板了");
        if (GroundCount % 10 == 0)
        {
            GroundMove.speed *= 1.5f;
        }
    }
}
