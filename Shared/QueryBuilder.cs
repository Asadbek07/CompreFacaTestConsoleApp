using System.Web;

namespace Shared;

public class QueryBuilder
{
    private string _url;
    
    public QueryBuilder(string url)
    {
        _url = url;
    }
    public QueryBuilder SetQuery<T>(T request)
    {
        var uriBuilder = new UriBuilder(_url);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query.AssignPropertyValue(request);
        uriBuilder.Query = query.ToString();
        _url = uriBuilder.ToString();

        return this;
    }

    public string Build() => _url;
}