using UnityEngine;
using UnityEngine.UI;

public class FollowCharacter : MonoBehaviour
{
    public Transform target; // 角色的Transform
    public Vector3 offset; // 物体相对于角色的偏移量
    public float smoothSpeed = 0.125f; // 平滑移动的速度
    public float rotationSpeed = 5f; // 旋转的平滑速度

    void LateUpdate()
    {
        // 平滑跟随位置
        Vector3 desiredPosition = target.position + target.right * offset.x + target.up * offset.y + target.forward * offset.z;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // 平滑旋转
        Quaternion targetRotation = Quaternion.LookRotation(target.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    } 
    
}
