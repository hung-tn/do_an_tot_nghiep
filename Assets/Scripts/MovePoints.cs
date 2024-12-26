using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoints : MonoBehaviour
{
    [SerializeField] private float moveSpeed;      // Tốc độ di chuyển
    [SerializeField] private Transform[] nPoints; // Các điểm di chuyển

    private int currentPoint = 0;                 // Điểm hiện tại

    private void Update()
    {
        if (nPoints.Length == 0) return; // Kiểm tra nếu không có điểm nào

        // Xác định điểm tiếp theo
        int nextPoint = (currentPoint + 1) % nPoints.Length;

        // Di chuyển dần về phía điểm tiếp theo
        transform.position = Vector3.MoveTowards(transform.position, nPoints[nextPoint].position, moveSpeed * Time.deltaTime);

        // Kiểm tra nếu đã đến điểm tiếp theo
        if (Vector3.Distance(transform.position, nPoints[nextPoint].position) < 0.1f)
        {
            currentPoint = nextPoint; // Cập nhật điểm hiện tại
        }
    }
}
