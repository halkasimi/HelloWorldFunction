{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Calibri;}}
{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard\sa200\sl276\slmult1\lang9\f0\fs22 using System.Net;\par
\par
public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)\par
\{\par
    log.Info($"C# HTTP trigger function processed a request. RequestUri=\{req.RequestUri\}");\par
\par
    // parse query parameter\par
    string name = req.GetQueryNameValuePairs()\par
        .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)\par
        .Value;\par
\par
    // Get request body\par
    dynamic data = await req.Content.ReadAsAsync<object>();\par
\par
    // Set name to query string or body data\par
    name = name ?? data?.name;\par
\par
    return name == null\par
        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")\par
        : req.CreateResponse(HttpStatusCode.OK, "Howdy " + name);\par
\}\par
}
 