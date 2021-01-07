namespace ReceitaFederal.Utils
{
    class StringUtils
    {
        public static string RemoveDoubleQuotes(string word)
        {
            return word.Replace("\"", "");
        }
    }
}
