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
        // �v���C���[�ƃ}�E�X�̈ʒu���擾
        Vector3 playerPosition = player_.position;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // �v���C���[�ƃ}�E�X�̊Ԃ̈ʒu���v�Z
        Vector3 middlePoint = (playerPosition + worldMousePosition) / 2;

        // �J�����̈ʒu���X�V (X��Z�̂�)
        Vector3 cameraPosition = new Vector3(middlePoint.x, transform.position.y, middlePoint.z);
        transform.position = cameraPosition;
    }

}
