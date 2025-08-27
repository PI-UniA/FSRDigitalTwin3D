using System.Text;
using VDS.RDF;

namespace FSR.DigitalTwin.App.Common.Utils.Semantic;

public static class KnownPrefix
{

    public const string SO = "http://schema.org/";
    public const string EX = "http://www.example.org/";
    public const string RDF = "http://www.w3.org/1999/02/22-rdf-syntax-ns#";
    public const string RDFS = "http://www.w3.org/2000/01/rdf-schema#";
    public const string DUL = "http://www.loa-cnr.it/ontologies/DUL.owl#";
    public const string SSN = "http://purl.oclc.org/NET/ssnx/ssn#";
    public const string SOHO = "http://pst.istc.cnr.it/ontologies/2019/01/soho#";
    public const string SOBOTS = "https://www.uni-augsburg.de/de/fakultaet/fai/informatik/prof/pi/projekte/forschung/forsocialrobots/sobots#";
    public const string XSD = "http://www.w3.org/2001/XMLSchema";

    public static string GetSparql()
    {
        StringBuilder sb = new();
        string[] prefixes = [
            SO, EX, RDF, RDFS, DUL, SSN, SOHO, SOBOTS, XSD
        ];
        string[] ns = [
            "so", "ex", "rdf", "rdfs", "DUL", "ssn", "soho", "sobots", "xds"
        ];
        for (int i = 0; i < prefixes.Length; i++)
        {
            sb.Append("PREFIX ");
            sb.Append(ns[i]);
            sb.Append(": <");
            sb.Append(prefixes[i]);
            sb.Append("> \n");
        }
        return sb.ToSafeString();
    }

}