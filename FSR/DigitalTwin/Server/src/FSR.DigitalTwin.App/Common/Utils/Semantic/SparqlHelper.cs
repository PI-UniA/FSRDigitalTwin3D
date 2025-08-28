namespace FSR.DigitalTwin.App.Common.Utils.Semantic;

using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public static class SparqlHelper
{
    /// <summary>
    /// Loads a SPARQL query from a file.
    /// </summary>
    /// <param name="filePath">Path to the .rq or .sparql file.</param>
    /// <returns>SPARQL query string.</returns>
    public static string LoadQuery(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("SPARQL query file not found.", filePath);

        return File.ReadAllText(filePath);
    }

    /// <summary>
    /// Substitutes placeholders like pi:tmp0, pi:tmp1, ... with actual URIs from a list.
    /// </summary>
    /// <param name="filePath">Path to the .rq or .sparql file.</param>
    /// <param name="replacementUris">A list of URIs to replace the placeholders.</param>
    /// <returns>The query string with placeholders replaced.</returns>
    public static string LoadQuery(string filePath, IList<string> replacementUris)
    {
        string substitutedQuery = LoadQuery(filePath);

        for (int i = 0; i < replacementUris.Count; i++)
        {
            string placeholderPattern = $@"\bpi:tmp{i}\b";
            substitutedQuery = Regex.Replace(substitutedQuery, placeholderPattern, $"<{replacementUris[i]}>");
        }

        return substitutedQuery;
    }

    /// <summary>
    /// Substitutes placeholders like pi:tmp0, pi:tmp1, ... with actual URIs from a dictionary.
    /// </summary>
    /// <param name="filePath">Path to the .rq or .sparql file.</param>
    /// <param name="replacements">Dictionary with keys like 'tmp0' and values as URIs.</param>
    /// <returns>The query string with placeholders replaced.</returns>
    public static string LoadQuery(string filePath, IDictionary<string, string> replacements)
    {
        string substitutedQuery = LoadQuery(filePath);

        foreach (var pair in replacements)
        {
            string placeholderPattern = $@"\bpi:{Regex.Escape(pair.Key)}\b";
            substitutedQuery = Regex.Replace(substitutedQuery, placeholderPattern, $"<{pair.Value}>");
        }

        return substitutedQuery;
    }
}