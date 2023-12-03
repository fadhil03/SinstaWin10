using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SecurityQuestionPanel : MonoBehaviour
{
    public Dropdown[] securityQuestionDropdowns;
    public InputField[] securityAnswerFields;
    public GameObject twoOf3;
    public GameObject treeOf3;


    private const string selectedQuestionsKey = "SelectedSecurityQuestions";
    private const string answersKey = "SecurityQuestionAnswers";

    private List<string> availableQuestions;

    private void Start()
    {
        twoOf3.SetActive(false);
        treeOf3.SetActive(false);
        // Inisialisasi pertanyaan keamanan
        availableQuestions = new List<string>
        {
            "What was your first pet's name?",
            "What's the name of the city where you were born?",
            "What was your childhood nickname?",
            "What's the name of the city where your parents met?",
            "What's the first name of your oldest cousin?",
            "What's the name of the first school you attended?"
        };

        // Set jumlah pertanyaan yang dapat dipilih
        int selectableQuestionCount = 6;

        // Acak pertanyaan yang tersedia dan ambil yang pertama sesuai jumlah yang dipilih
        List<string> selectedQuestions = new List<string>(availableQuestions);
        Shuffle(selectedQuestions);
        selectedQuestions = selectedQuestions.GetRange(0, selectableQuestionCount);

        // Set pertanyaan yang dipilih ke dropdown
        for (int i = 0; i < securityQuestionDropdowns.Length; i++)
        {
            securityQuestionDropdowns[i].ClearOptions();
            securityQuestionDropdowns[i].AddOptions(selectedQuestions);
        }
    }

    public void Update()
    {
        SaveSecurityQuestions();
        SaveSecurityAnswers();
    }

    // Fungsi untuk menyimpan jawaban keamanan
    public void SaveSecurityAnswers()
    {
        List<string> selectedQuestions = new List<string>();

        // Ambil pertanyaan yang dipilih dari dropdown
        for (int i = 0; i < securityQuestionDropdowns.Length; i++)
        {
            string selectedQuestion = securityQuestionDropdowns[i].options[securityQuestionDropdowns[i].value].text;
            selectedQuestions.Add(selectedQuestion);
        }

        // Simpan pertanyaan yang dipilih ke PlayerPrefs
        //PlayerPrefs.SetString(selectedQuestionsKey, string.Join(",", selectedQuestions.ToArray()));

        // Simpan jawaban keamanan ke PlayerPrefs
        for (int i = 0; i < securityAnswerFields.Length; i++)
        {
            PlayerPrefs.SetString($"{answersKey}{i}", securityAnswerFields[i].text);
        }

        // Simpan perubahan
        PlayerPrefs.Save();

        Debug.Log("Security answers saved.");
    }

    // Metode untuk menyimpan pertanyaan keamanan
    public void SaveSecurityQuestions()
    {
        // Ambil pertanyaan yang dipilih dari dropdown
        for (int i = 0; i < securityQuestionDropdowns.Length; i++)
        {
            string selectedQuestion = securityQuestionDropdowns[i].options[securityQuestionDropdowns[i].value].text;

            // Simpan pertanyaan yang dipilih ke PlayerPrefs dengan key yang sesuai
            PlayerPrefs.SetString($"{selectedQuestionsKey}{i}", selectedQuestion);
        }

        // Simpan perubahan
        PlayerPrefs.Save();

        Debug.Log("Security questions saved.");
    }

    // Metode untuk mengacak elemen-elemen dalam List
    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
