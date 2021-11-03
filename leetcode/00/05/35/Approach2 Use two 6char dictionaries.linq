<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 535. Encode and Decode TinyURL
// https://leetcode.com/problems/encode-and-decode-tinyurl/

/*
    Time: O()
    Space: O()
    
    This solution awoid to duplicate same url with different code for O(1)
*/
public class Codec
{
    public const string host = "http://tinyurl.com/";
    
    private const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    private Dictionary<string, string> code2url = new Dictionary<string, string>();
    
    private Dictionary<string, string> url2code = new Dictionary<string, string>();

    private static Random random = new Random();

    // Encodes a URL to a shortened URL
    public string encode(string longUrl)
    {
        if(url2code.ContainsKey(longUrl))
            return $"{host}{url2code[longUrl]}";
            
        var code = GetFreeUrl();
        code2url.Add(code, longUrl);
        url2code.Add(longUrl, code);
        return $"{host}{code}";
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl)
    {
        var code = shortUrl.Substring(host.Length);
        if (!code2url.ContainsKey(code))
            throw new ArgumentNullException();

        return code2url[code];
    }

    private string GetFreeUrl()
    {
        string result;
        do
        {
            result = GetRandomUrl();
        } while (code2url.ContainsKey(result));
        return result;
    }

    // total (10+26*2)6 = 56,800,235,584 codes with length 6
    private string GetRandomUrl(int length = 6)
    {
        return new string(Enumerable.Repeat(alphabet, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }
}

[Test]
[TestCase("https://leetcode.com/problems/design-tinyurl")]
public void SolutionTests(string originalUrl)
{
    var codec = new Codec();
    var shortenedUrl = codec.encode(originalUrl);
    var restoredUrl = codec.decode(shortenedUrl);
    Assert.That(restoredUrl, Is.EquivalentTo(originalUrl));

    var shortenedUrl2 = codec.encode(originalUrl);
    Assert.That(shortenedUrl, Is.EquivalentTo(shortenedUrl2));
}

#region unit tests runner

void Main()
{
    var workDir = Path.Combine(Util.MyQueriesFolder, "nunit-work");

    var args = new string[]
    {
         "-noheader",
         $"--work={workDir}",
    };

    RunUnitTests(args);
}

void RunUnitTests(string[] args, Assembly assembly = null)
{
    Console.SetOut(new NoDisposeTextWriter(Console.Out));
    Console.SetError(new NoDisposeTextWriter(Console.Error));
    new AutoRun(assembly ?? Assembly.GetExecutingAssembly()).Execute(args);
}

// https://stackoverflow.com/q/52883672/5752652
class NoDisposeTextWriter : TextWriter
{
    private readonly TextWriter writer;
    public NoDisposeTextWriter(TextWriter writer) => this.writer = writer;

    public override Encoding Encoding => writer.Encoding;
    public override IFormatProvider FormatProvider => writer.FormatProvider;
    public override void Write(char value) => writer.Write(value);
    public override void Flush() => writer.Flush();
    // forward all other overrides as necessary

    protected override void Dispose(bool disposing)
    {
        // no nothing
    }
}

#endregion