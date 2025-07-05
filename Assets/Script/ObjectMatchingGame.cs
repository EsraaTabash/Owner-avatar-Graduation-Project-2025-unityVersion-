using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(LineRenderer))]
public class ObjectMatchingGame : MonoBehaviour
{
    private LineRenderer lineRender;
    [SerializeField] private int matchId;
    private bool isDragging;
    private Vector3 endPoint;
    private ObjectMatchForm objectMatchForm;

    [Header("Sounds")]
    public AudioSource dragStartSound;
    public AudioSource matchSuccessSound;

    private void Start()
    {
        lineRender = GetComponent<LineRenderer>();
        lineRender.positionCount = 2;
        lineRender.startWidth = 0.05f;
        lineRender.endWidth = 0.05f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;

                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                lineRender.SetPosition(0, mousePosition);

                // تشغيل صوت بداية السحب
                if (dragStartSound != null)
                {
                    dragStartSound.Play();
                }
            }
        }

        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            lineRender.SetPosition(1, mousePosition);
            endPoint = mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;

            RaycastHit2D hit = Physics2D.Raycast(endPoint, Vector2.zero);

            if (hit.collider != null && hit.collider.TryGetComponent(out objectMatchForm) && matchId == objectMatchForm.Get_ID())
            {
                Debug.Log("Correct Form");

                // تشغيل صوت النجاح
                if (matchSuccessSound != null)
                {
                    matchSuccessSound.Play();
                }

                FindObjectOfType<ProgressBarManual>().IncreaseProgress();
                this.enabled = false;
            }
            else
            {
                lineRender.positionCount = 0;
            }

            // إعادة ضبط الخط
            lineRender.positionCount = 2;
        }
    }
}
