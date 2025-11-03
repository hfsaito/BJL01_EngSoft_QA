using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Player player;
    [SerializeField] private Image BarVida;

    [SerializeField] private TextMeshProUGUI Moedas;
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private TMP_Dropdown langDropdown;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuCanvas.gameObject.SetActive(!menuCanvas.gameObject.activeSelf);
        }
    }
    
    public void SetVida()
    {
        BarVida.rectTransform.localScale = new Vector3((float)  player.vida / (float) player.vidaMaxima, 1, 1) ;
    }

    public void SetMoeda()
    {
        Moedas.text = player.moedas.ToString();
    }

    public void Restart()
    {
        
    }

    public void ChangeLang(string localeIdentifier)
    {
        switch (langDropdown.value)
        {
            case 0:
                localeIdentifier = "pt-BR";
                break;
            
            case 1:
                localeIdentifier = "en-US";
                break;
        }
        
        print(localeIdentifier);
        
        Locale newLocale = null;
        foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
        {
            if (locale.Identifier.Code == localeIdentifier)
            {
                newLocale = locale;
                break;
            }
        }
        
        if (newLocale != null)
        {
            LocalizationSettings.SelectedLocale = newLocale;
        }
    }
}
