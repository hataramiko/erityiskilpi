using System;
using UnityEngine;

public static class PrefsHolder
{
    private const string Language = "Lang";

    public static void SaveLang(SystemLanguage lang)
    {
        PlayerPrefs.SetString(Language, lang.ToString());
    }

    public static SystemLanguage GetLang()
    {
        Enum.TryParse(PlayerPrefs.GetString(Language, Application.systemLanguage.ToString()),out SystemLanguage language);
        return language;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private const int _base = 0;
    private const bool disableA = false;
    private const bool disable2 = false;
    private const bool disable3 = false;

}
