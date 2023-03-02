using System.Text.Json;
using AppSample.CoreTools.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace AppSample.CoreTools.Exceptions;

public class UnifiedException : Exception
{
	public UnifiedException(OAuth2Error error) : base(error.ToString())
	{
		Error = error;
	}

	public UnifiedException(OAuth2Error error, string? errorDescription)
		: base(error + ": " + errorDescription)
	{
		Error = error;
		ErrorDescription = errorDescription;
	}
	
	public UnifiedException(OAuth2Error error, string? errorDescription, int statusCode)
		: base(error + ": " + errorDescription)
	{
		Error = error;
		ErrorDescription = errorDescription;
		StatusCode = statusCode;
	}

	public OAuth2Error Error { get; }
	public string? ErrorDescription { get; }
	public int? StatusCode { get; set; }
	public int? RetryCount { get; set; }

    Dictionary<string, string> FormResponseObject()
    {
	    Dictionary<string, string> response = new() { [OpenIdConnectParameterNames.Error] = OAuth2ErrorDetails.GetText(Error) };
	    if (ErrorDescription != null)
		    response.Add(OpenIdConnectParameterNames.ErrorDescription, ErrorDescription);
	    if (RetryCount != null)
		    response.Add("retry_count", RetryCount.Value.ToString());
	    return response;
    }

    public string FormResponseJson()
    {
	    var response = FormResponseObject();
	    var json = JsonSerializer.Serialize(response);
	    return json;
    }

    public IActionResult FormResponse()
    {
	    Dictionary<string, string> response = FormResponseObject();
	    return new ObjectResult(response) { StatusCode = GetResponseStatusCode() };
    }
    public int GetResponseStatusCode()
    {
	    return StatusCode ?? (int) OAuth2ErrorDetails.GetCode(Error);
    }
}