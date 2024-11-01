using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] Gun gun_;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPerrent(Player player)
    {
        // 銃の座標を設定する
        Vector3 offset = new Vector3(0.1f, 0.1f, 0.5f); // 銃の位置のオフセット
        Vector3 pos = player.transform.position + player.transform.TransformDirection(offset);
        gun_.transform.position = pos;

        // 銃をプレイヤーの子にする
        gun_.transform.parent = player.transform;
    }
}
