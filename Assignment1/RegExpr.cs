namespace Assignment1;
using System.Text.RegularExpressions;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines) {
        string pattern = @"[\w]+";
        Regex rg = new Regex(pattern);
        foreach (string l in lines) {
            foreach (Match m in rg.Matches(l)) {
                yield return m.Value;
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions) {
        string pattern = @"(?<width>[\d]+)x(?<height>[\d]+)";
        Regex rg = new Regex(pattern);
        var ms = rg.Matches(resolutions);
        foreach (Match m in ms) {
            var thiswidth = int.Parse(m.Groups[1].Value);
            var thisheight = int.Parse(m.Groups[2].Value);
            yield return (thiswidth, thisheight);
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();
}