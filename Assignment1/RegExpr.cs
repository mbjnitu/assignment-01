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

    public static IEnumerable<string> InnerText(string html, string tag) {
        string pattern = "<"+ tag + @".*?>(.*?)</"+ tag +"+>";
        Regex rg = new Regex(pattern);
        var ms = rg.Matches(html);
        foreach (Match m in ms) {
            yield return Regex.Replace(m.Groups[1].Value, @"<.*?>", "");
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html) {
        string pattern = @"<a.*?href=""(?<url>.*?)""(?:.*?title=""(?<title>.*?)"")?.*?>(?<inner>.*?)</a>";
        Regex rg = new Regex(pattern);
        var ms = rg.Matches(html);
        foreach (Match m in ms) {
            Uri url = new Uri(m.Groups["url"].Value, UriKind.Absolute);
            string title;
            if (m.Groups["title"].Value != "") {
                title = m.Groups[2].Value;
            }
            else {
                title = "<t>" + m.Groups["inner"].Value + "</t>";
                title = InnerText(title, "t").First();
            }
            yield return (url, title);
        }
    }
}