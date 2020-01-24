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
    public interface IRenditionsApi
    {
        /// <summary>
        /// Create rendition **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  An asynchronous request to create a rendition for file **nodeId**.  The rendition is specified by name **id** in the request body: &#x60;&#x60;&#x60;JSON {   \&quot;id\&quot;:\&quot;doclib\&quot; } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="renditionBodyCreate">The rendition \&quot;id\&quot;.</param>
        /// <returns></returns>
        void CreateRendition (string nodeId, RenditionBodyCreate renditionBodyCreate);
        /// <summary>
        /// Get rendition information **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets the rendition information for **renditionId** of file **nodeId**. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="renditionId">The name of a thumbnail rendition, for example *doclib*, or *pdf*.</param>
        /// <returns>RenditionEntry</returns>
        RenditionEntry GetRendition (string nodeId, string renditionId);
        /// <summary>
        /// Get rendition content **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets the rendition content for **renditionId** of file **nodeId**. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="renditionId">The name of a thumbnail rendition, for example *doclib*, or *pdf*.</param>
        /// <param name="attachment">**true** enables a web browser to download the file as an attachment. **false** means a web browser may preview the file in a new tab or window, but not download the file.  You can only set this parameter to **false** if the content type of the file is in the supported list; for example, certain image files and PDF files.  If the content type is not supported for preview, then a value of **false**  is ignored, and the attachment will be returned in the response. </param>
        /// <param name="ifModifiedSince">Only returns the content if it has been modified since the date provided. Use the date format defined by HTTP. For example, &#x60;Wed, 09 Mar 2016 16:56:34 GMT&#x60;. </param>
        /// <param name="range">The Range header indicates the part of a document that the server should return. Single part request supported, for example: bytes&#x3D;1-10. </param>
        /// <param name="placeholder">If **true** and there is no rendition for this **nodeId** and **renditionId**, then the placeholder image for the mime type of this rendition is returned, rather than a 404 response. </param>
        /// <returns></returns>
        void GetRenditionContent (string nodeId, string renditionId, bool? attachment, DateTime? ifModifiedSince, string range, bool? placeholder);
        /// <summary>
        /// List renditions **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets a list of the rendition information for each rendition of the the file **nodeId**, including the rendition id.  Each rendition returned has a **status**: CREATED means it is available to view or download, NOT_CREATED means the rendition can be requested.  You can use the **where** parameter to filter the returned renditions by **status**. For example, the following **where** clause will return just the CREATED renditions:  &#x60;&#x60;&#x60; (status&#x3D;&#39;CREATED&#39;) &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="where">A string to restrict the returned objects by using a predicate.</param>
        /// <returns>RenditionPaging</returns>
        RenditionPaging ListRenditions (string nodeId, string where);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class RenditionsApi : IRenditionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenditionsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public RenditionsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="RenditionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public RenditionsApi(String basePath)
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
        /// Create rendition **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  An asynchronous request to create a rendition for file **nodeId**.  The rendition is specified by name **id** in the request body: &#x60;&#x60;&#x60;JSON {   \&quot;id\&quot;:\&quot;doclib\&quot; } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="renditionBodyCreate">The rendition \&quot;id\&quot;.</param> 
        /// <returns></returns>            
        public void CreateRendition (string nodeId, RenditionBodyCreate renditionBodyCreate)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling CreateRendition");
            
            // verify the required parameter 'renditionBodyCreate' is set
            if (renditionBodyCreate == null) throw new ApiException(400, "Missing required parameter 'renditionBodyCreate' when calling CreateRendition");
            
    
            var path = "/nodes/{nodeId}/renditions";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(renditionBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateRendition: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateRendition: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get rendition information **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets the rendition information for **renditionId** of file **nodeId**. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="renditionId">The name of a thumbnail rendition, for example *doclib*, or *pdf*.</param> 
        /// <returns>RenditionEntry</returns>            
        public RenditionEntry GetRendition (string nodeId, string renditionId)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling GetRendition");
            
            // verify the required parameter 'renditionId' is set
            if (renditionId == null) throw new ApiException(400, "Missing required parameter 'renditionId' when calling GetRendition");
            
    
            var path = "/nodes/{nodeId}/renditions/{renditionId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
path = path.Replace("{" + "renditionId" + "}", ApiClient.ParameterToString(renditionId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetRendition: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetRendition: " + response.ErrorMessage, response.ErrorMessage);
    
            return (RenditionEntry) ApiClient.Deserialize(response.Content, typeof(RenditionEntry), response.Headers);
        }
    
        /// <summary>
        /// Get rendition content **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets the rendition content for **renditionId** of file **nodeId**. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="renditionId">The name of a thumbnail rendition, for example *doclib*, or *pdf*.</param> 
        /// <param name="attachment">**true** enables a web browser to download the file as an attachment. **false** means a web browser may preview the file in a new tab or window, but not download the file.  You can only set this parameter to **false** if the content type of the file is in the supported list; for example, certain image files and PDF files.  If the content type is not supported for preview, then a value of **false**  is ignored, and the attachment will be returned in the response. </param> 
        /// <param name="ifModifiedSince">Only returns the content if it has been modified since the date provided. Use the date format defined by HTTP. For example, &#x60;Wed, 09 Mar 2016 16:56:34 GMT&#x60;. </param> 
        /// <param name="range">The Range header indicates the part of a document that the server should return. Single part request supported, for example: bytes&#x3D;1-10. </param> 
        /// <param name="placeholder">If **true** and there is no rendition for this **nodeId** and **renditionId**, then the placeholder image for the mime type of this rendition is returned, rather than a 404 response. </param> 
        /// <returns></returns>            
        public void GetRenditionContent (string nodeId, string renditionId, bool? attachment, DateTime? ifModifiedSince, string range, bool? placeholder)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling GetRenditionContent");
            
            // verify the required parameter 'renditionId' is set
            if (renditionId == null) throw new ApiException(400, "Missing required parameter 'renditionId' when calling GetRenditionContent");
            
    
            var path = "/nodes/{nodeId}/renditions/{renditionId}/content";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
path = path.Replace("{" + "renditionId" + "}", ApiClient.ParameterToString(renditionId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (attachment != null) queryParams.Add("attachment", ApiClient.ParameterToString(attachment)); // query parameter
 if (placeholder != null) queryParams.Add("placeholder", ApiClient.ParameterToString(placeholder)); // query parameter
             if (ifModifiedSince != null) headerParams.Add("If-Modified-Since", ApiClient.ParameterToString(ifModifiedSince)); // header parameter
 if (range != null) headerParams.Add("Range", ApiClient.ParameterToString(range)); // header parameter
                            
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetRenditionContent: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetRenditionContent: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// List renditions **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets a list of the rendition information for each rendition of the the file **nodeId**, including the rendition id.  Each rendition returned has a **status**: CREATED means it is available to view or download, NOT_CREATED means the rendition can be requested.  You can use the **where** parameter to filter the returned renditions by **status**. For example, the following **where** clause will return just the CREATED renditions:  &#x60;&#x60;&#x60; (status&#x3D;&#39;CREATED&#39;) &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="where">A string to restrict the returned objects by using a predicate.</param> 
        /// <returns>RenditionPaging</returns>            
        public RenditionPaging ListRenditions (string nodeId, string where)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling ListRenditions");
            
    
            var path = "/nodes/{nodeId}/renditions";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (where != null) queryParams.Add("where", ApiClient.ParameterToString(where)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListRenditions: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListRenditions: " + response.ErrorMessage, response.ErrorMessage);
    
            return (RenditionPaging) ApiClient.Deserialize(response.Content, typeof(RenditionPaging), response.Headers);
        }
    
    }
}
