using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestTextManager : MonoBehaviour
{

    public TextMeshProUGUI textComponent; // TextMeshPro bile�eni
    public float typingSpeed; // Harfler aras�ndaki bekleme s�resi

    private string fullText; // Tam metin
    private string currentText = ""; // �u anda ekranda g�r�nen metin


    // Start is called before the first frame update
    void Start()
    {

        fullText = textComponent.text; // Tam metni TextMeshPro bile�eninden al
        textComponent.text = ""; // Ba�lang��ta metni bo� yap
        StartCoroutine(TypeText()); // Yazd�rma coroutine'ini ba�lat



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
            yield return new WaitForSeconds(typingSpeed); // Belirlenen h�zda karakter ekle
        }
    }
}
