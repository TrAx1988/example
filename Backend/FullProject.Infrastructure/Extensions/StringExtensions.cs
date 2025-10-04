namespace FullProject.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Erweitert Umgebungsvariablen im angegebenen String.
        /// Unterstützt sowohl Standard-Umgebungsvariablen-Syntax (%VAR%) als auch ${VAR}-Platzhalter.
        /// </summary>
        /// <param name="value">Der Eingabestring, der Umgebungsvariablen enthalten kann.</param>
        /// <returns>
        /// Den String mit ersetzten Umgebungsvariablen.
        /// Falls der Eingabestring leer oder nur aus Leerzeichen besteht, wird er unverändert zurückgegeben.
        /// </returns>
        public static string ExpandEnvironmentVariables(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            var result = Environment.ExpandEnvironmentVariables(value);

            var envVariables = Environment.GetEnvironmentVariables();

            foreach (var key in envVariables.Keys)
            {
                if (key == null || key is not string)
                {
                    continue;
                }

                result = result.Replace("${" + key.ToString() + "}", envVariables[key]?.ToString() ?? string.Empty, StringComparison.OrdinalIgnoreCase);
            }

            return result;
        }
    }
}
