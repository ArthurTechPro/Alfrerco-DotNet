using System;
using System.Collections.Generic;
using Arkivujo.Alfresco.Discovery.Client;
using Arkivujo.Alfresco.Discovery.Model;
using RestSharp;

namespace Arkivujo.Alfresco.Discovery.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDiscoveryApi
    {
        /// <summary>
        /// Get repository information **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Retrieves the capabilities and detailed version information from the repository. 
        /// </summary>
        /// <returns>DiscoveryEntry</returns>
        DiscoveryEntry GetRepositoryInformation ();
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DiscoveryApi : IDiscoveryApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoveryApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public DiscoveryApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoveryApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DiscoveryApi(String basePath)
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
        /// Get repository information **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Retrieves the capabilities and detailed version information from the repository. 
        /// </summary>
        /// <returns>DiscoveryEntry</returns>            
        public DiscoveryEntry GetRepositoryInformation ()
        {
            
    
            var path = "/discovery";
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetRepositoryInformation: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetRepositoryInformation: " + response.ErrorMessage, response.ErrorMessage);
    
            return (DiscoveryEntry) ApiClient.Deserialize(response.Content, typeof(DiscoveryEntry), response.Headers);
        }
    
    }
}
