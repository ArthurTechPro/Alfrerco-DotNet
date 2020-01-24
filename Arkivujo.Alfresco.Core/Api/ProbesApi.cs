using System;
using System.Collections.Generic;
using Arkivujo.Alfresco.Core.Client;
using Arkivujo.Alfresco.Core.Model;
using RestSharp;

namespace Arkivujo.Alfresco.Core.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IProbesApi
    {
        /// <summary>
        /// Check readiness and liveness of the repository **Note:** this endpoint is available in Alfresco 6.0 and newer versions.  Returns a status of 200 to indicate success and 503 for failure.  The readiness probe is normally only used to check repository startup.  The liveness probe should then be used to check the repository is still responding to requests.  **Note:** No authentication is required to call this endpoint. 
        /// </summary>
        /// <param name="probeId">The name of the probe: * -ready- * -live- </param>
        /// <returns>ProbeEntry</returns>
        ProbeEntry GetProbe (string probeId);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ProbesApi : IProbesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProbesApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public ProbesApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="ProbesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ProbesApi(String basePath)
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
        /// Check readiness and liveness of the repository **Note:** this endpoint is available in Alfresco 6.0 and newer versions.  Returns a status of 200 to indicate success and 503 for failure.  The readiness probe is normally only used to check repository startup.  The liveness probe should then be used to check the repository is still responding to requests.  **Note:** No authentication is required to call this endpoint. 
        /// </summary>
        /// <param name="probeId">The name of the probe: * -ready- * -live- </param> 
        /// <returns>ProbeEntry</returns>            
        public ProbeEntry GetProbe (string probeId)
        {
            
            // verify the required parameter 'probeId' is set
            if (probeId == null) throw new ApiException(400, "Missing required parameter 'probeId' when calling GetProbe");
            
    
            var path = "/probes/{probeId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "probeId" + "}", ApiClient.ParameterToString(probeId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetProbe: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetProbe: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ProbeEntry) ApiClient.Deserialize(response.Content, typeof(ProbeEntry), response.Headers);
        }
    
    }
}
