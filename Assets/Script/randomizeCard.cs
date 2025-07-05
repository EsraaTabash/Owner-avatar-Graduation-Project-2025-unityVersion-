using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizeCard : MonoBehaviour
{
    [SerializeField] private float offsetH = 1.5f; // المسافة بين الكروت
    [SerializeField] private float offsetV = 2.0f; // المسافة بين الصفين
    [SerializeField] private GameObject[] cardsTop;
    [SerializeField] private GameObject[] cardsBottom;

    void Start()
    {
        ShuffleCards(cardsTop);
        ShuffleCards(cardsBottom);

        ArrangeCards(cardsTop, new Vector2(0, offsetV));
        ArrangeCards(cardsBottom, new Vector2(0, -offsetV));
    }

    void ShuffleCards(GameObject[] cards)
    {
        int n = cards.Length;
        for (int i = 0; i < n; i++)
        {
            int rnd = Random.Range(i, n);
            GameObject temp = cards[rnd];
            cards[rnd] = cards[i];
            cards[i] = temp;
        }
    }

    void ArrangeCards(GameObject[] cards, Vector2 rowCenter)
    {
        float spacing = offsetH;
        int count = cards.Length;

        float startX = rowCenter.x - ((count - 1) * spacing / 2f); // بداية الصف

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = new Vector3(startX + i * spacing, rowCenter.y, 0);
            cards[i].transform.position = pos;
        }
    }
}


