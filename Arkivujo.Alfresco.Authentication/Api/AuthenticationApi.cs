using System;
using System.Collections.Generic;
using Arkivujo.Alfresco.Authentication.Client;
using Arkivujo.Alfresco.Authentication.Model;
using RestSharp;

namespace Arkivujo.Alfresco.Authentication.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAuthenticationApi
    {
        /// <summary>
        /// Create ticket (login) **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Logs in and returns the new authentication ticket.  The userId and password properties are mandatory in the request body. For example: &#x60;&#x60;&#x60;JSON {     \&quot;userId\&quot;: \&quot;jbloggs\&quot;,     \&quot;password\&quot;: \&quot;password\&quot; } &#x60;&#x60;&#x60; To use the ticket in future requests you should pass it in the request header. For example using Javascript:   &#x60;&#x60;&#x60;Javascript     request.setRequestHeader (\&quot;Authorization\&quot;, \&quot;Basic \&quot; + btoa(ticket));   &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="ticketBodyCreate">The user credential.</param>
        /// <returns>TicketEntry</returns>
        TicketEntry CreateTicket (TicketBody ticketBodyCreate);
        /// <summary>
        /// Delete ticket (logout) **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Deletes logged in ticket (logout). 
        /// </summary>
        /// <returns></returns>
        void DeleteTicket ();
        /// <summary>
        /// Validate ticket **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Validates the specified ticket (derived from Authorization header) is still valid.  For example, you can pass the Authorization request header using Javascript:   &#x60;&#x60;&#x60;Javascript     request.setRequestHeader (\&quot;Authorization\&quot;, \&quot;Basic \&quot; + btoa(ticket));   &#x60;&#x60;&#x60; 
        /// </summary>
        /// <returns>ValidTicketEntry</returns>
        ValidTicketEntry ValidateTicket ();
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AuthenticationApi : IAuthenticationApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public AuthenticationApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthenticationApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        /// Create ticket (login) **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Logs in and returns the new authentication ticket.  The userId and password properties are mandatory in the request body. For example: &#x60;&#x60;&#x60;JSON {     \&quot;userId\&quot;: \&quot;jbloggs\&quot;,     \&quot;password\&quot;: \&quot;password\&quot; } &#x60;&#x60;&#x60; To use the ticket in future requests you should pass it in the request header. For example using Javascript:   &#x60;&#x60;&#x60;Javascript     request.setRequestHeader (\&quot;Authorization\&quot;, \&quot;Basic \&quot; + btoa(ticket));   &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="ticketBodyCreate">The user credential.</param> 
        /// <returns>TicketEntry</returns>            
        public TicketEntry CreateTicket (TicketBody ticketBodyCreate)
        {
            
            // verify the required parameter 'ticketBodyCreate' is set
            if (ticketBodyCreate == null) throw new ApiException(400, "Missing required parameter 'ticketBodyCreate' when calling CreateTicket");
            
    
            var path = "/tickets";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(ticketBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateTicket: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateTicket: " + response.ErrorMessage, response.ErrorMessage);
    
            return (TicketEntry) ApiClient.Deserialize(response.Content, typeof(TicketEntry), response.Headers);
        }
    
        /// <summary>
        /// Delete ticket (logout) **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Deletes logged in ticket (logout). 
        /// </summary>
        /// <returns></returns>            
        public void DeleteTicket ()
        {
            
    
            var path = "/tickets/-me-";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteTicket: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteTicket: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Validate ticket **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Validates the specified ticket (derived from Authorization header) is still valid.  For example, you can pass the Authorization request header using Javascript:   &#x60;&#x60;&#x60;Javascript     request.setRequestHeader (\&quot;Authorization\&quot;, \&quot;Basic \&quot; + btoa(ticket));   &#x60;&#x60;&#x60; 
        /// </summary>
        /// <returns>ValidTicketEntry</returns>            
        public ValidTicketEntry ValidateTicket ()
        {
            
    
            var path = "/tickets/-me-";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ValidateTicket: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ValidateTicket: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ValidTicketEntry) ApiClient.Deserialize(response.Content, typeof(ValidTicketEntry), response.Headers);
        }
    
    }
}
