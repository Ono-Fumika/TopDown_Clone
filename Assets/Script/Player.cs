using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Plane glound; // 地面
    [SerializeField] Hand hand_;
    private float speed_ = 3.0f; // 移動速度
    private float distance_ = 0; // 地面とのキョリ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 移動
        Move();
        // マウスの方向を向く
        Direction();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed_, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed_, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, speed_) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 0, speed_) * Time.deltaTime;
        }
    }
    private void Direction()
    {
        // カメラとマウスの位置を元にRayを準備
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // プレイヤーの高さにPlaneを更新して、カメラの情報を元に地面判定して距離を取得
        glound.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (glound.Raycast(ray, out distance_))
        {
            // 距離を元に交点を算出して、交点の方を向く
            var lookPoint = ray.GetPoint(distance_);
            transform.LookAt(lookPoint);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        // 銃に当たったら
        if (collider.tag == "Gun")
        {
            // 銃の座標を設定、親子関係を作る
            hand_.SetPerrent(this);
        }
    }
}
