using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player_;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーとマウスの位置を取得
        Vector3 playerPosition = player_.position;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // プレイヤーとマウスの間の位置を計算
        Vector3 middlePoint = (playerPosition + worldMousePosition) / 2;

        // カメラの位置を更新 (XとZのみ)
        Vector3 cameraPosition = new Vector3(middlePoint.x, transform.position.y, middlePoint.z);
        transform.position = cameraPosition;
    }

}
