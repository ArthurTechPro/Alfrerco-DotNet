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
    public interface IDownloadsApi
    {
        /// <summary>
        /// Cancel a download **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Cancels the creation of a download request.  **Note:** The download node can be deleted using the **DELETE /nodes/{downloadId}** endpoint  By default, if the download node is not deleted it will be picked up by a cleaner job which removes download nodes older than a configurable amount of time (default is 1 hour)  Information about the existing progress at the time of cancelling can be retrieved by calling the **GET /downloads/{downloadId}** endpoint  The cancel operation is done asynchronously. 
        /// </summary>
        /// <param name="downloadId">The identifier of a download node.</param>
        /// <returns></returns>
        void CancelDownload (string downloadId);
        /// <summary>
        /// Create a new download **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Creates a new download node asynchronously, the content of which will be the zipped content of the **nodeIds** specified in the JSON body like this:  &#x60;&#x60;&#x60;JSON {     \&quot;nodeIds\&quot;:      [        \&quot;c8bb482a-ff3c-4704-a3a3-de1c83ccd84c\&quot;,        \&quot;cffa62db-aa01-493d-9594-058bc058eeb1\&quot;      ] } &#x60;&#x60;&#x60;  **Note:** The content of the download node can be obtained using the **GET /nodes/{downloadId}/content** endpoint 
        /// </summary>
        /// <param name="downloadBodyCreate">The nodeIds the content of which will be zipped, which zip will be set as the content of our download node.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>DownloadEntry</returns>
        DownloadEntry CreateDownload (DownloadBodyCreate downloadBodyCreate, List<string> fields);
        /// <summary>
        /// Get a download **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Retrieve status information for download node **downloadId** 
        /// </summary>
        /// <param name="downloadId">The identifier of a download node.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>DownloadEntry</returns>
        DownloadEntry GetDownload (string downloadId, List<string> fields);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DownloadsApi : IDownloadsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public DownloadsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DownloadsApi(String basePath)
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
        /// Cancel a download **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Cancels the creation of a download request.  **Note:** The download node can be deleted using the **DELETE /nodes/{downloadId}** endpoint  By default, if the download node is not deleted it will be picked up by a cleaner job which removes download nodes older than a configurable amount of time (default is 1 hour)  Information about the existing progress at the time of cancelling can be retrieved by calling the **GET /downloads/{downloadId}** endpoint  The cancel operation is done asynchronously. 
        /// </summary>
        /// <param name="downloadId">The identifier of a download node.</param> 
        /// <returns></returns>            
        public void CancelDownload (string downloadId)
        {
            
            // verify the required parameter 'downloadId' is set
            if (downloadId == null) throw new ApiException(400, "Missing required parameter 'downloadId' when calling CancelDownload");
            
    
            var path = "/downloads/{downloadId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "downloadId" + "}", ApiClient.ParameterToString(downloadId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling CancelDownload: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CancelDownload: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Create a new download **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Creates a new download node asynchronously, the content of which will be the zipped content of the **nodeIds** specified in the JSON body like this:  &#x60;&#x60;&#x60;JSON {     \&quot;nodeIds\&quot;:      [        \&quot;c8bb482a-ff3c-4704-a3a3-de1c83ccd84c\&quot;,        \&quot;cffa62db-aa01-493d-9594-058bc058eeb1\&quot;      ] } &#x60;&#x60;&#x60;  **Note:** The content of the download node can be obtained using the **GET /nodes/{downloadId}/content** endpoint 
        /// </summary>
        /// <param name="downloadBodyCreate">The nodeIds the content of which will be zipped, which zip will be set as the content of our download node.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>DownloadEntry</returns>            
        public DownloadEntry CreateDownload (DownloadBodyCreate downloadBodyCreate, List<string> fields)
        {
            
            // verify the required parameter 'downloadBodyCreate' is set
            if (downloadBodyCreate == null) throw new ApiException(400, "Missing required parameter 'downloadBodyCreate' when calling CreateDownload");
            
    
            var path = "/downloads";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(downloadBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateDownload: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateDownload: " + response.ErrorMessage, response.ErrorMessage);
    
            return (DownloadEntry) ApiClient.Deserialize(response.Content, typeof(DownloadEntry), response.Headers);
        }
    
        /// <summary>
        /// Get a download **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Retrieve status information for download node **downloadId** 
        /// </summary>
        /// <param name="downloadId">The identifier of a download node.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>DownloadEntry</returns>            
        public DownloadEntry GetDownload (string downloadId, List<string> fields)
        {
            
            // verify the required parameter 'downloadId' is set
            if (downloadId == null) throw new ApiException(400, "Missing required parameter 'downloadId' when calling GetDownload");
            
    
            var path = "/downloads/{downloadId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "downloadId" + "}", ApiClient.ParameterToString(downloadId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetDownload: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetDownload: " + response.ErrorMessage, response.ErrorMessage);
    
            return (DownloadEntry) ApiClient.Deserialize(response.Content, typeof(DownloadEntry), response.Headers);
        }
    
    }
}
