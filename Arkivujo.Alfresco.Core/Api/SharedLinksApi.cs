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
    public interface ISharedLinksApi
    {
        /// <summary>
        /// Create a shared link to a file **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Create a shared link to the file **nodeId** in the request body. Also, an optional expiry date could be set, so the shared link would become invalid when the expiry date is reached. For example:  &#x60;&#x60;&#x60;JSON   {     \&quot;nodeId\&quot;: \&quot;1ff9da1a-ee2f-4b9c-8c34-3333333333\&quot;,     \&quot;expiresAt\&quot;: \&quot;2017-03-23T23:00:00.000+0000\&quot;   } &#x60;&#x60;&#x60;  **Note:** You can create shared links to more than one file specifying a list of **nodeId**s in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {     \&quot;nodeId\&quot;: \&quot;1ff9da1a-ee2f-4b9c-8c34-4444444444\&quot;   },   {     \&quot;nodeId\&quot;: \&quot;1ff9da1a-ee2f-4b9c-8c34-5555555555\&quot;   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="sharedLinkBodyCreate">The nodeId to create a shared link for.</param>
        /// <param name="include">Returns additional information about the shared link, the following optional fields can be requested: * allowableOperations * path </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SharedLinkEntry</returns>
        SharedLinkEntry CreateSharedLink (SharedLinkBodyCreate sharedLinkBodyCreate, List<string> include, List<string> fields);
        /// <summary>
        /// Deletes a shared link **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Deletes the shared link with identifier **sharedId**. 
        /// </summary>
        /// <param name="sharedId">The identifier of a shared link to a file.</param>
        /// <returns></returns>
        void DeleteSharedLink (string sharedId);
        /// <summary>
        /// Email shared link **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Sends email with app-specific url including identifier **sharedId**.  The client and recipientEmails properties are mandatory in the request body. For example, to email a shared link with minimum info: &#x60;&#x60;&#x60;JSON {     \&quot;client\&quot;: \&quot;myClient\&quot;,     \&quot;recipientEmails\&quot;: [\&quot;john.doe@acme.com\&quot;, \&quot;joe.bloggs@acme.com\&quot;] } &#x60;&#x60;&#x60; A plain text message property can be optionally provided in the request body to customise the sent email. Also, a locale property can be optionally provided in the request body to send the emails in a particular language (if the locale is supported by Alfresco). For example, to email a shared link with a messages and a locale: &#x60;&#x60;&#x60;JSON {     \&quot;client\&quot;: \&quot;myClient\&quot;,     \&quot;recipientEmails\&quot;: [\&quot;john.doe@acme.com\&quot;, \&quot;joe.bloggs@acme.com\&quot;],     \&quot;message\&quot;: \&quot;myMessage\&quot;,     \&quot;locale\&quot;:\&quot;en-GB\&quot; } &#x60;&#x60;&#x60; **Note:** The client must be registered before you can send a shared link email. See [server documentation]. However, out-of-the-box  share is registered as a default client, so you could pass **share** as the client name: &#x60;&#x60;&#x60;JSON {     \&quot;client\&quot;: \&quot;share\&quot;,     \&quot;recipientEmails\&quot;: [\&quot;john.doe@acme.com\&quot;] } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="sharedId">The identifier of a shared link to a file.</param>
        /// <param name="sharedLinkBodyEmail">The shared link email to send.</param>
        /// <returns></returns>
        void EmailSharedLink (string sharedId, SharedLinkBodyEmail sharedLinkBodyEmail);
        /// <summary>
        /// Get a shared link **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets minimal information for the file with shared link identifier **sharedId**.  **Note:** No authentication is required to call this endpoint. 
        /// </summary>
        /// <param name="sharedId">The identifier of a shared link to a file.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SharedLinkEntry</returns>
        SharedLinkEntry GetSharedLink (string sharedId, List<string> fields);
        /// <summary>
        /// Get shared link content **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets the content of the file with shared link identifier **sharedId**.  **Note:** No authentication is required to call this endpoint. 
        /// </summary>
        /// <param name="sharedId">The identifier of a shared link to a file.</param>
        /// <param name="attachment">**true** enables a web browser to download the file as an attachment. **false** means a web browser may preview the file in a new tab or window, but not download the file.  You can only set this parameter to **false** if the content type of the file is in the supported list; for example, certain image files and PDF files.  If the content type is not supported for preview, then a value of **false**  is ignored, and the attachment will be returned in the response. </param>
        /// <param name="ifModifiedSince">Only returns the content if it has been modified since the date provided. Use the date format defined by HTTP. For example, &#x60;Wed, 09 Mar 2016 16:56:34 GMT&#x60;. </param>
        /// <param name="range">The Range header indicates the part of a document that the server should return. Single part request supported, for example: bytes&#x3D;1-10. </param>
        /// <returns></returns>
        void GetSharedLinkContent (string sharedId, bool? attachment, DateTime? ifModifiedSince, string range);
        /// <summary>
        /// Get shared link rendition information **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets rendition information for the file with shared link identifier **sharedId**.  This API method returns rendition information where the rendition status is CREATED, which means the rendition is available to view/download.  **Note:** No authentication is required to call this endpoint. 
        /// </summary>
        /// <param name="sharedId">The identifier of a shared link to a file.</param>
        /// <param name="renditionId">The name of a thumbnail rendition, for example *doclib*, or *pdf*.</param>
        /// <returns>RenditionEntry</returns>
        RenditionEntry GetSharedLinkRendition (string sharedId, string renditionId);
        /// <summary>
        /// Get shared link rendition content **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets the rendition content for file with shared link identifier **sharedId**.  **Note:** No authentication is required to call this endpoint. 
        /// </summary>
        /// <param name="sharedId">The identifier of a shared link to a file.</param>
        /// <param name="renditionId">The name of a thumbnail rendition, for example *doclib*, or *pdf*.</param>
        /// <param name="attachment">**true** enables a web browser to download the file as an attachment. **false** means a web browser may preview the file in a new tab or window, but not download the file.  You can only set this parameter to **false** if the content type of the file is in the supported list; for example, certain image files and PDF files.  If the content type is not supported for preview, then a value of **false**  is ignored, and the attachment will be returned in the response. </param>
        /// <param name="ifModifiedSince">Only returns the content if it has been modified since the date provided. Use the date format defined by HTTP. For example, &#x60;Wed, 09 Mar 2016 16:56:34 GMT&#x60;. </param>
        /// <param name="range">The Range header indicates the part of a document that the server should return. Single part request supported, for example: bytes&#x3D;1-10. </param>
        /// <returns></returns>
        void GetSharedLinkRenditionContent (string sharedId, string renditionId, bool? attachment, DateTime? ifModifiedSince, string range);
        /// <summary>
        /// List renditions for a shared link **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets a list of the rendition information for the file with shared link identifier **sharedId**.  This API method returns rendition information, including the rendition id, for each rendition where the rendition status is CREATED, which means the rendition is available to view/download.  **Note:** No authentication is required to call this endpoint. 
        /// </summary>
        /// <param name="sharedId">The identifier of a shared link to a file.</param>
        /// <returns>RenditionPaging</returns>
        RenditionPaging ListSharedLinkRenditions (string sharedId);
        /// <summary>
        /// List shared links **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Get a list of links that the current user has read permission on source node.  The list is ordered in descending modified order.  **Note:** The list of links is eventually consistent so newly created shared links may not appear immediately. 
        /// </summary>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="where">Optionally filter the list by \&quot;sharedByUser\&quot; userid of person who shared the link (can also use -me-)  *   &#x60;&#x60;&#x60;where&#x3D;(sharedByUser&#x3D;&#39;jbloggs&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(sharedByUser&#x3D;&#39;-me-&#39;)&#x60;&#x60;&#x60; </param>
        /// <param name="include">Returns additional information about the shared link, the following optional fields can be requested: * allowableOperations * path </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SharedLinkPaging</returns>
        SharedLinkPaging ListSharedLinks (int? skipCount, int? maxItems, string where, List<string> include, List<string> fields);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class SharedLinksApi : ISharedLinksApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SharedLinksApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public SharedLinksApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="SharedLinksApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SharedLinksApi(String basePath)
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
        /// Create a shared link to a file **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Create a shared link to the file **nodeId** in the request body. Also, an optional expiry date could be set, so the shared link would become invalid when the expiry date is reached. For example:  &#x60;&#x60;&#x60;JSON   {     \&quot;nodeId\&quot;: \&quot;1ff9da1a-ee2f-4b9c-8c34-3333333333\&quot;,     \&quot;expiresAt\&quot;: \&quot;2017-03-23T23:00:00.000+0000\&quot;   } &#x60;&#x60;&#x60;  **Note:** You can create shared links to more than one file specifying a list of **nodeId**s in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {     \&quot;nodeId\&quot;: \&quot;1ff9da1a-ee2f-4b9c-8c34-4444444444\&quot;   },   {     \&quot;nodeId\&quot;: \&quot;1ff9da1a-ee2f-4b9c-8c34-5555555555\&quot;   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="sharedLinkBodyCreate">The nodeId to create a shared link for.</param> 
        /// <param name="include">Returns additional information about the shared link, the following optional fields can be requested: * allowableOperations * path </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SharedLinkEntry</returns>            
        public SharedLinkEntry CreateSharedLink (SharedLinkBodyCreate sharedLinkBodyCreate, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'sharedLinkBodyCreate' is set
            if (sharedLinkBodyCreate == null) throw new ApiException(400, "Missing required parameter 'sharedLinkBodyCreate' when calling CreateSharedLink");
            
    
            var path = "/shared-links";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(sharedLinkBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateSharedLink: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateSharedLink: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SharedLinkEntry) ApiClient.Deserialize(response.Content, typeof(SharedLinkEntry), response.Headers);
        }
    
        /// <summary>
        /// Deletes a shared link **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Deletes the shared link with identifier **sharedId**. 
        /// </summary>
        /// <param name="sharedId">The identifier of a shared link to a file.</param> 
        /// <returns></returns>            
        public void DeleteSharedLink (string sharedId)
        {
            
            // verify the required parameter 'sharedId' is set
            if (sharedId == null) throw new ApiException(400, "Missing required parameter 'sharedId' when calling DeleteSharedLink");
            
    
            var path = "/shared-links/{sharedId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "sharedId" + "}", ApiClient.ParameterToString(sharedId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteSharedLink: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteSharedLink: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Email shared link **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Sends email with app-specific url including identifier **sharedId**.  The client and recipientEmails properties are mandatory in the request body. For example, to email a shared link with minimum info: &#x60;&#x60;&#x60;JSON {     \&quot;client\&quot;: \&quot;myClient\&quot;,     \&quot;recipientEmails\&quot;: [\&quot;john.doe@acme.com\&quot;, \&quot;joe.bloggs@acme.com\&quot;] } &#x60;&#x60;&#x60; A plain text message property can be optionally provided in the request body to customise the sent email. Also, a locale property can be optionally provided in the request body to send the emails in a particular language (if the locale is supported by Alfresco). For example, to email a shared link with a messages and a locale: &#x60;&#x60;&#x60;JSON {     \&quot;client\&quot;: \&quot;myClient\&quot;,     \&quot;recipientEmails\&quot;: [\&quot;john.doe@acme.com\&quot;, \&quot;joe.bloggs@acme.com\&quot;],     \&quot;message\&quot;: \&quot;myMessage\&quot;,     \&quot;locale\&quot;:\&quot;en-GB\&quot; } &#x60;&#x60;&#x60; **Note:** The client must be registered before you can send a shared link email. See [server documentation]. However, out-of-the-box  share is registered as a default client, so you could pass **share** as the client name: &#x60;&#x60;&#x60;JSON {     \&quot;client\&quot;: \&quot;share\&quot;,     \&quot;recipientEmails\&quot;: [\&quot;john.doe@acme.com\&quot;] } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="sharedId">The identifier of a shared link to a file.</param> 
        /// <param name="sharedLinkBodyEmail">The shared link email to send.</param> 
        /// <returns></returns>            
        public void EmailSharedLink (string sharedId, SharedLinkBodyEmail sharedLinkBodyEmail)
        {
            
            // verify the required parameter 'sharedId' is set
            if (sharedId == null) throw new ApiException(400, "Missing required parameter 'sharedId' when calling EmailSharedLink");
            
            // verify the required parameter 'sharedLinkBodyEmail' is set
            if (sharedLinkBodyEmail == null) throw new ApiException(400, "Missing required parameter 'sharedLinkBodyEmail' when calling EmailSharedLink");
            
    
            var path = "/shared-links/{sharedId}/email";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "sharedId" + "}", ApiClient.ParameterToString(sharedId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(sharedLinkBodyEmail); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling EmailSharedLink: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling EmailSharedLink: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get a shared link **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets minimal information for the file with shared link identifier **sharedId**.  **Note:** No authentication is required to call this endpoint. 
        /// </summary>
        /// <param name="sharedId">The identifier of a shared link to a file.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SharedLinkEntry</returns>            
        public SharedLinkEntry GetSharedLink (string sharedId, List<string> fields)
        {
            
            // verify the required parameter 'sharedId' is set
            if (sharedId == null) throw new ApiException(400, "Missing required parameter 'sharedId' when calling GetSharedLink");
            
    
            var path = "/shared-links/{sharedId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "sharedId" + "}", ApiClient.ParameterToString(sharedId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetSharedLink: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetSharedLink: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SharedLinkEntry) ApiClient.Deserialize(response.Content, typeof(SharedLinkEntry), response.Headers);
        }
    
        /// <summary>
        /// Get shared link content **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets the content of the file with shared link identifier **sharedId**.  **Note:** No authentication is required to call this endpoint. 
        /// </summary>
        /// <param name="sharedId">The identifier of a shared link to a file.</param> 
        /// <param name="attachment">**true** enables a web browser to download the file as an attachment. **false** means a web browser may preview the file in a new tab or window, but not download the file.  You can only set this parameter to **false** if the content type of the file is in the supported list; for example, certain image files and PDF files.  If the content type is not supported for preview, then a value of **false**  is ignored, and the attachment will be returned in the response. </param> 
        /// <param name="ifModifiedSince">Only returns the content if it has been modified since the date provided. Use the date format defined by HTTP. For example, &#x60;Wed, 09 Mar 2016 16:56:34 GMT&#x60;. </param> 
        /// <param name="range">The Range header indicates the part of a document that the server should return. Single part request supported, for example: bytes&#x3D;1-10. </param> 
        /// <returns></returns>            
        public void GetSharedLinkContent (string sharedId, bool? attachment, DateTime? ifModifiedSince, string range)
        {
            
            // verify the required parameter 'sharedId' is set
            if (sharedId == null) throw new ApiException(400, "Missing required parameter 'sharedId' when calling GetSharedLinkContent");
            
    
            var path = "/shared-links/{sharedId}/content";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "sharedId" + "}", ApiClient.ParameterToString(sharedId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetSharedLinkContent: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetSharedLinkContent: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get shared link rendition information **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets rendition information for the file with shared link identifier **sharedId**.  This API method returns rendition information where the rendition status is CREATED, which means the rendition is available to view/download.  **Note:** No authentication is required to call this endpoint. 
        /// </summary>
        /// <param name="sharedId">The identifier of a shared link to a file.</param> 
        /// <param name="renditionId">The name of a thumbnail rendition, for example *doclib*, or *pdf*.</param> 
        /// <returns>RenditionEntry</returns>            
        public RenditionEntry GetSharedLinkRendition (string sharedId, string renditionId)
        {
            
            // verify the required parameter 'sharedId' is set
            if (sharedId == null) throw new ApiException(400, "Missing required parameter 'sharedId' when calling GetSharedLinkRendition");
            
            // verify the required parameter 'renditionId' is set
            if (renditionId == null) throw new ApiException(400, "Missing required parameter 'renditionId' when calling GetSharedLinkRendition");
            
    
            var path = "/shared-links/{sharedId}/renditions/{renditionId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "sharedId" + "}", ApiClient.ParameterToString(sharedId));
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetSharedLinkRendition: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetSharedLinkRendition: " + response.ErrorMessage, response.ErrorMessage);
    
            return (RenditionEntry) ApiClient.Deserialize(response.Content, typeof(RenditionEntry), response.Headers);
        }
    
        /// <summary>
        /// Get shared link rendition content **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets the rendition content for file with shared link identifier **sharedId**.  **Note:** No authentication is required to call this endpoint. 
        /// </summary>
        /// <param name="sharedId">The identifier of a shared link to a file.</param> 
        /// <param name="renditionId">The name of a thumbnail rendition, for example *doclib*, or *pdf*.</param> 
        /// <param name="attachment">**true** enables a web browser to download the file as an attachment. **false** means a web browser may preview the file in a new tab or window, but not download the file.  You can only set this parameter to **false** if the content type of the file is in the supported list; for example, certain image files and PDF files.  If the content type is not supported for preview, then a value of **false**  is ignored, and the attachment will be returned in the response. </param> 
        /// <param name="ifModifiedSince">Only returns the content if it has been modified since the date provided. Use the date format defined by HTTP. For example, &#x60;Wed, 09 Mar 2016 16:56:34 GMT&#x60;. </param> 
        /// <param name="range">The Range header indicates the part of a document that the server should return. Single part request supported, for example: bytes&#x3D;1-10. </param> 
        /// <returns></returns>            
        public void GetSharedLinkRenditionContent (string sharedId, string renditionId, bool? attachment, DateTime? ifModifiedSince, string range)
        {
            
            // verify the required parameter 'sharedId' is set
            if (sharedId == null) throw new ApiException(400, "Missing required parameter 'sharedId' when calling GetSharedLinkRenditionContent");
            
            // verify the required parameter 'renditionId' is set
            if (renditionId == null) throw new ApiException(400, "Missing required parameter 'renditionId' when calling GetSharedLinkRenditionContent");
            
    
            var path = "/shared-links/{sharedId}/renditions/{renditionId}/content";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "sharedId" + "}", ApiClient.ParameterToString(sharedId));
path = path.Replace("{" + "renditionId" + "}", ApiClient.ParameterToString(renditionId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetSharedLinkRenditionContent: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetSharedLinkRenditionContent: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// List renditions for a shared link **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets a list of the rendition information for the file with shared link identifier **sharedId**.  This API method returns rendition information, including the rendition id, for each rendition where the rendition status is CREATED, which means the rendition is available to view/download.  **Note:** No authentication is required to call this endpoint. 
        /// </summary>
        /// <param name="sharedId">The identifier of a shared link to a file.</param> 
        /// <returns>RenditionPaging</returns>            
        public RenditionPaging ListSharedLinkRenditions (string sharedId)
        {
            
            // verify the required parameter 'sharedId' is set
            if (sharedId == null) throw new ApiException(400, "Missing required parameter 'sharedId' when calling ListSharedLinkRenditions");
            
    
            var path = "/shared-links/{sharedId}/renditions";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "sharedId" + "}", ApiClient.ParameterToString(sharedId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling ListSharedLinkRenditions: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListSharedLinkRenditions: " + response.ErrorMessage, response.ErrorMessage);
    
            return (RenditionPaging) ApiClient.Deserialize(response.Content, typeof(RenditionPaging), response.Headers);
        }
    
        /// <summary>
        /// List shared links **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Get a list of links that the current user has read permission on source node.  The list is ordered in descending modified order.  **Note:** The list of links is eventually consistent so newly created shared links may not appear immediately. 
        /// </summary>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="where">Optionally filter the list by \&quot;sharedByUser\&quot; userid of person who shared the link (can also use -me-)  *   &#x60;&#x60;&#x60;where&#x3D;(sharedByUser&#x3D;&#39;jbloggs&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(sharedByUser&#x3D;&#39;-me-&#39;)&#x60;&#x60;&#x60; </param> 
        /// <param name="include">Returns additional information about the shared link, the following optional fields can be requested: * allowableOperations * path </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SharedLinkPaging</returns>            
        public SharedLinkPaging ListSharedLinks (int? skipCount, int? maxItems, string where, List<string> include, List<string> fields)
        {
            
    
            var path = "/shared-links";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (skipCount != null) queryParams.Add("skipCount", ApiClient.ParameterToString(skipCount)); // query parameter
 if (maxItems != null) queryParams.Add("maxItems", ApiClient.ParameterToString(maxItems)); // query parameter
 if (where != null) queryParams.Add("where", ApiClient.ParameterToString(where)); // query parameter
 if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListSharedLinks: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListSharedLinks: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SharedLinkPaging) ApiClient.Deserialize(response.Content, typeof(SharedLinkPaging), response.Headers);
        }
    
    }
}
