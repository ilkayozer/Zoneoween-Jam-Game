using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestTextManager : MonoBehaviour
{

    public TextMeshProUGUI textComponent; // TextMeshPro bileþeni
    public float typingSpeed; // Harfler arasýndaki bekleme süresi

    private string fullText; // Tam metin
    private string currentText = ""; // Þu anda ekranda görünen metin


    // Start is called before the first frame update
    void Start()
    {

        fullText = textComponent.text; // Tam metni TextMeshPro bileþeninden al
        textComponent.text = ""; // Baþlangýçta metni boþ yap
        StartCoroutine(TypeText()); // Yazdýrma coroutine'ini baþlat



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TypeText()
    {
        foreach (char letter in fullText.ToCharArray())
        {
            currentText += letter;
            textComponent.text = currentText;
            yield return new WaitForSeconds(typingSpeed); // Belirlenen hýzda karakter ekle
        }
    }
}
