using UnityEngine;

public class ProgressBarManual : MonoBehaviour
{
    [SerializeField] private RectTransform fillTransform;
    [SerializeField] private float fullWidth = 360f;
    [SerializeField] private int totalCorrectAnswers = 3;

    [Header("Objects To Show On Completion")]
    [SerializeField] private GameObject panelToShow; // اللوحة
    [SerializeField] private GameObject buttonToShow; // الزر

    [Header("Audio")]
    [SerializeField] private AudioSource progressSound;

    private int currentCorrectAnswers = 0;

    public void IncreaseProgress()
    {
        currentCorrectAnswers++;

        float targetWidth = fullWidth * currentCorrectAnswers / totalCorrectAnswers;
        Vector2 size = fillTransform.sizeDelta;
        size.x = targetWidth;
        fillTransform.sizeDelta = size;

        // ✅ تشغيل صوت التقدم
        if (progressSound != null)
        {
            progressSound.Play();
        }

        // ✅ عندما ينتهي الشريط
        if (currentCorrectAnswers >= totalCorrectAnswers)
        {
            if (panelToShow != null)
            {
                panelToShow.SetActive(true);
            }

            if (buttonToShow != null)
            {
                buttonToShow.SetActive(true);
            }
        }
    }
}




