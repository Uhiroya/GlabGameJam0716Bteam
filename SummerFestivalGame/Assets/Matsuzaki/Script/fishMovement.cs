using UnityEngine;
using UnityEngine.UIElements;

public class fishMovement : MonoBehaviour
{
    [Header("移動速度")]       public float moveSpeed;             // 移動速度
    /*[Header("スコア（金額）")] public int Score;          */         //スコア（金額）
    [Header("最小回転速度")]   public float minRotationTime = 1f;  // 最小回転時間（現状モデルと合わせないと判別しづらいです）
    [Header("最大回転速度")]   public float maxRotationTime = 3f;  // 最大回転時間（現状モデルと合わせないと判別しづらいです）
    [Header("最小停止時間")]   public float minIdleTime;           // 最小停止時間
    [Header("最大停止時間")]   public float maxIdleTime;           // 最大停止時間
    [Header("金魚の座標取得")] public Transform _transform;                                    //

    private Vector3 targetPosition;                                 // 目的地の座標
    private Quaternion targetRotation;                              // 目的地の回転

    private float rotationTimer;                                    // 回転タイマー
    private float idleTimer;                                        // 停止タイマー
    /*private float rotationSpeed = Mathf.Infinity;    */               // 回転速度

    private void Start()
    {
        //次の目的地を決定し回転する
        SetNewTarget();
    }

    private void Update()
    {
        //目的地に移動を終えた場合
        if (IsAtTargetPosition())
        {
            //一定時間ランダムで静止
            idleTimer -= Time.deltaTime;
            //停止中に次の目的地を決定し回転する
            if (idleTimer <= 0f) { SetNewTarget(); }
        }
        else
        { MoveTowardsTarget(); }
    }

    private void SetNewTarget()
    {
        // ランダムな座標を決定
        targetPosition = GenerateRandomPosition();

        // 回転時間をランダムに設定
        rotationTimer = Random.Range(minRotationTime, maxRotationTime);

        // 停止時間をランダムに設定
        idleTimer = Random.Range(minIdleTime, maxIdleTime);

        // 目的地の回転を設定
        targetRotation = Quaternion.LookRotation(targetPosition - transform.position, Vector3.up);

        RotateTowardsTarget(targetPosition - transform.position);
    }

    private Vector3 GenerateRandomPosition()
    {
        //画面外へ出すぎないように調節
        float minX = -12f;
        float maxX = 12f;
        float minY = -7f;
        float maxY = 9f;

        //ランダムで次の座標を決定
        Vector3 randomPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        return randomPos;
    }

    private bool IsAtTargetPosition()
    {
        //目的値の座標変換
        return transform.position == targetPosition;
    }

    private void MoveTowardsTarget()
    {
        //現在の座標から目的地への移動
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void RotateTowardsTarget(Vector3 dir)
    {
        if (rotationTimer <= 0f) { return; }

        rotationTimer -= Time.deltaTime;

        dir = dir.normalized;

        float angle = Mathf.Atan2(dir.x,dir.y) * Mathf.Rad2Deg - 90;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        var angles = new Vector3(angle, 90, -90);
        _transform.rotation = Quaternion.Euler(angles);
    }
}

//親クラスに空のオブジェクトを配置（スクリプト添付）⇒子クラスに金魚のモデル添付で使用


