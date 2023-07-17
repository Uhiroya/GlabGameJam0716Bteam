using UnityEngine;

public class fishRand : MonoBehaviour
{
    [SerializeField] private GameObject fish;     //動かしたいオブジェクトをインスペクターから代入
    [SerializeField] private int speed = 0;       //自動移動のスピード
    Vector3 movePosition;                         //目的地
    
    void Start()
    {
        //目的地を設定
        movePosition = moveRandomPosition();  
    }

    void Update()
    {
        //playerオブジェクトが目的地に到達すると、目的地を再設定
        if (movePosition == fish.transform.position)    
        {
            movePosition = moveRandomPosition();        
        }
        //③引数⇒(playerオブジェクト,目的地に移動, 移動速度)
        this.fish.transform.position =                  
            Vector3.MoveTowards(fish.transform.position, movePosition, speed * Time.deltaTime);  
    }

    private Vector3 moveRandomPosition()   
    {
        // 目的地生成（xとyをランダム値）
        Vector3 randomPos = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 30);
        return randomPos;
    }
}