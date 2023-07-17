using UnityEngine;

public class fishQuater : MonoBehaviour
{
    // 最大の回転角速度[deg/s]
    [SerializeField] private float _maxAngularSpeed = Mathf.Infinity;

    // 進行方向に向くのにかかるおおよその時間[s]
    [SerializeField] private float _smoothTime =0;

    private Transform _transform;

    // 前フレームの位置
    private Vector3 _prevPos;

    private float _currentAngularVelocity;

    private void Start()
    {
        _transform = transform;

        _prevPos = _transform.position;
    }

    private void Update()
    {
        // 現在フレームの位置
        var position = _transform.position;

        // 移動量を計算
        var move = position - _prevPos;

        // 次のUpdateで使うための前フレーム位置更新
        _prevPos = position;

        // 静止している状態だと、進行方向を特定できないため回転しない
        if (move == Vector3.zero) return;

        // 進行方向（移動量ベクトル）に向くようなクォータニオンを取得
        var targetRot = Quaternion.LookRotation(move, Vector3.up);

        // 現在の向きと進行方向との角度差を計算
        var diffAngle = Vector3.Angle(_transform.forward, move);
        // 現在フレームで回転する角度の計算
        var rotAngle = 
            Mathf.SmoothDampAngle(0,diffAngle,ref _currentAngularVelocity,_smoothTime,_maxAngularSpeed);
        // 現在フレームにおける回転を計算
        var nextRot = Quaternion.RotateTowards(_transform.rotation,targetRot,rotAngle);

        // オブジェクトの回転に反映
        _transform.rotation = nextRot;
    }
}