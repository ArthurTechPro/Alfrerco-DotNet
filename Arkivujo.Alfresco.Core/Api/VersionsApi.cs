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
    public interface IVersionsApi
    {
        /// <summary>
        /// Delete a version **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Delete the version identified by **versionId** and **nodeId*.  If the version is successfully deleted then the content and metadata for that versioned node will be deleted and will no longer appear in the version history. This operation cannot be undone.  If the most recent version is deleted the live node will revert to the next most recent version.  We currently do not allow the last version to be deleted. If you wish to clear the history then you can remove the \&quot;cm:versionable\&quot; aspect (via update node) which will also disable versioning. In this case, you can re-enable versioning by adding back the \&quot;cm:versionable\&quot; aspect or using the version params (majorVersion and comment) on a subsequent file content update. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="versionId">The identifier of a version, ie. version label, within the version history of a node.</param>
        /// <returns></returns>
        void DeleteVersion (string nodeId, string versionId);
        /// <summary>
        /// Get version information **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets the version information for **versionId** of file node **nodeId**. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="versionId">The identifier of a version, ie. version label, within the version history of a node.</param>
        /// <returns>VersionEntry</returns>
        VersionEntry GetVersion (string nodeId, string versionId);
        /// <summary>
        /// Get version content **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets the version content for **versionId** of file node **nodeId**. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="versionId">The identifier of a version, ie. version label, within the version history of a node.</param>
        /// <param name="attachment">**true** enables a web browser to download the file as an attachment. **false** means a web browser may preview the file in a new tab or window, but not download the file.  You can only set this parameter to **false** if the content type of the file is in the supported list; for example, certain image files and PDF files.  If the content type is not supported for preview, then a value of **false**  is ignored, and the attachment will be returned in the response. </param>
        /// <param name="ifModifiedSince">Only returns the content if it has been modified since the date provided. Use the date format defined by HTTP. For example, &#x60;Wed, 09 Mar 2016 16:56:34 GMT&#x60;. </param>
        /// <param name="range">The Range header indicates the part of a document that the server should return. Single part request supported, for example: bytes&#x3D;1-10. </param>
        /// <returns></returns>
        void GetVersionContent (string nodeId, string versionId, bool? attachment, DateTime? ifModifiedSince, string range);
        /// <summary>
        /// List version history **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets the version history as an ordered list of versions for the specified **nodeId**.  The list is ordered in descending modified order. So the most recent version is first and the original version is last in the list. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="include">Returns additional information about the version node. The following optional fields can be requested: * properties * aspectNames </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <returns>VersionPaging</returns>
        VersionPaging ListVersionHistory (string nodeId, List<string> include, List<string> fields, int? skipCount, int? maxItems);
        /// <summary>
        /// Revert a version **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Attempts to revert the version identified by **versionId** and **nodeId** to the live node.  If the node is successfully reverted then the content and metadata for that versioned node will be promoted to the live node and a new version will appear in the version history. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="versionId">The identifier of a version, ie. version label, within the version history of a node.</param>
        /// <param name="revertBody">Optionally, specify a version comment and whether this should be a major version, or not.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>VersionEntry</returns>
        VersionEntry RevertVersion (string nodeId, string versionId, RevertBody revertBody, List<string> fields);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class VersionsApi : IVersionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public VersionsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public VersionsApi(String basePath)
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
        /// Delete a version **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Delete the version identified by **versionId** and **nodeId*.  If the version is successfully deleted then the content and metadata for that versioned node will be deleted and will no longer appear in the version history. This operation cannot be undone.  If the most recent version is deleted the live node will revert to the next most recent version.  We currently do not allow the last version to be deleted. If you wish to clear the history then you can remove the \&quot;cm:versionable\&quot; aspect (via update node) which will also disable versioning. In this case, you can re-enable versioning by adding back the \&quot;cm:versionable\&quot; aspect or using the version params (majorVersion and comment) on a subsequent file content update. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="versionId">The identifier of a version, ie. version label, within the version history of a node.</param> 
        /// <returns></returns>            
        public void DeleteVersion (string nodeId, string versionId)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling DeleteVersion");
            
            // verify the required parameter 'versionId' is set
            if (versionId == null) throw new ApiException(400, "Missing required parameter 'versionId' when calling DeleteVersion");
            
    
            var path = "/nodes/{nodeId}/versions/{versionId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
path = path.Replace("{" + "versionId" + "}", ApiClient.ParameterToString(versionId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteVersion: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteVersion: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get version information **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets the version information for **versionId** of file node **nodeId**. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="versionId">The identifier of a version, ie. version label, within the version history of a node.</param> 
        /// <returns>VersionEntry</returns>            
        public VersionEntry GetVersion (string nodeId, string versionId)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling GetVersion");
            
            // verify the required parameter 'versionId' is set
            if (versionId == null) throw new ApiException(400, "Missing required parameter 'versionId' when calling GetVersion");
            
    
            var path = "/nodes/{nodeId}/versions/{versionId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
path = path.Replace("{" + "versionId" + "}", ApiClient.ParameterToString(versionId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetVersion: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetVersion: " + response.ErrorMessage, response.ErrorMessage);
    
            return (VersionEntry) ApiClient.Deserialize(response.Content, typeof(VersionEntry), response.Headers);
        }
    
        /// <summary>
        /// Get version content **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets the version content for **versionId** of file node **nodeId**. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="versionId">The identifier of a version, ie. version label, within the version history of a node.</param> 
        /// <param name="attachment">**true** enables a web browser to download the file as an attachment. **false** means a web browser may preview the file in a new tab or window, but not download the file.  You can only set this parameter to **false** if the content type of the file is in the supported list; for example, certain image files and PDF files.  If the content type is not supported for preview, then a value of **false**  is ignored, and the attachment will be returned in the response. </param> 
        /// <param name="ifModifiedSince">Only returns the content if it has been modified since the date provided. Use the date format defined by HTTP. For example, &#x60;Wed, 09 Mar 2016 16:56:34 GMT&#x60;. </param> 
        /// <param name="range">The Range header indicates the part of a document that the server should return. Single part request supported, for example: bytes&#x3D;1-10. </param> 
        /// <returns></returns>            
        public void GetVersionContent (string nodeId, string versionId, bool? attachment, DateTime? ifModifiedSince, string range)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling GetVersionContent");
            
            // verify the required parameter 'versionId' is set
            if (versionId == null) throw new ApiException(400, "Missing required parameter 'versionId' when calling GetVersionContent");
            
    
            var path = "/nodes/{nodeId}/versions/{versionId}/content";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
path = path.Replace("{" + "versionId" + "}", ApiClient.ParameterToString(versionId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (attachment != null) queryParams.Add("attachment", ApiClient.ParameterToString(attachment)); // query parameter
             if (ifModifiedSince != null) headerParams.Add("If-Modified-Since", ApiClient.ParameterToString(ifModifiedSince)); // header parameter
 if (range != null) headerParams.Add("Range", ApiClient.ParameterToString(range)); // header parameter
                            
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetVersionContent: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetVersionContent: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// List version history **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets the version history as an ordered list of versions for the specified **nodeId**.  The list is ordered in descending modified order. So the most recent version is first and the original version is last in the list. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="include">Returns additional information about the version node. The following optional fields can be requested: * properties * aspectNames </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <returns>VersionPaging</returns>            
        public VersionPaging ListVersionHistory (string nodeId, List<string> include, List<string> fields, int? skipCount, int? maxItems)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling ListVersionHistory");
            
    
            var path = "/nodes/{nodeId}/versions";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
 if (skipCount != null) queryParams.Add("skipCount", ApiClient.ParameterToString(skipCount)); // query parameter
 if (maxItems != null) queryParams.Add("maxItems", ApiClient.ParameterToString(maxItems)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListVersionHistory: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListVersionHistory: " + response.ErrorMessage, response.ErrorMessage);
    
            return (VersionPaging) ApiClient.Deserialize(response.Content, typeof(VersionPaging), response.Headers);
        }
    
        /// <summary>
        /// Revert a version **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Attempts to revert the version identified by **versionId** and **nodeId** to the live node.  If the node is successfully reverted then the content and metadata for that versioned node will be promoted to the live node and a new version will appear in the version history. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="versionId">The identifier of a version, ie. version label, within the version history of a node.</param> 
        /// <param name="revertBody">Optionally, specify a version comment and whether this should be a major version, or not.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>VersionEntry</returns>            
        public VersionEntry RevertVersion (string nodeId, string versionId, RevertBody revertBody, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling RevertVersion");
            
            // verify the required parameter 'versionId' is set
            if (versionId == null) throw new ApiException(400, "Missing required parameter 'versionId' when calling RevertVersion");
            
            // verify the required parameter 'revertBody' is set
            if (revertBody == null) throw new ApiException(400, "Missing required parameter 'revertBody' when calling RevertVersion");
            
    
            var path = "/nodes/{nodeId}/versions/{versionId}/revert";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
path = path.Replace("{" + "versionId" + "}", ApiClient.ParameterToString(versionId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(revertBody); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RevertVersion: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RevertVersion: " + response.ErrorMessage, response.ErrorMessage);
    
            return (VersionEntry) ApiClient.Deserialize(response.Content, typeof(VersionEntry), response.Headers);
        }
    
    }
}
