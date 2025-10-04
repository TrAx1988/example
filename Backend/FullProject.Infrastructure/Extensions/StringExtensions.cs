namespace FullProject.Infrastructure.Extensions
{
    public static class StringExtensions
    {
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
