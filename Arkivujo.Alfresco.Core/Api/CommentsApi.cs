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
    public interface ICommentsApi
    {
        /// <summary>
        /// Create a comment Creates a comment on node **nodeId**. You specify the comment in a JSON body like this:  &#x60;&#x60;&#x60;JSON {   \&quot;content\&quot;: \&quot;This is a comment\&quot; } &#x60;&#x60;&#x60;  **Note:** You can create more than one comment by specifying a list of comments in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {     \&quot;content\&quot;: \&quot;This is a comment\&quot;   },   {     \&quot;content\&quot;: \&quot;This is another comment\&quot;   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="commentBodyCreate">The comment text. Note that you can also provide a list of comments.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>CommentEntry</returns>
        CommentEntry CreateComment (string nodeId, CommentBody commentBodyCreate, List<string> fields);
        /// <summary>
        /// Delete a comment Deletes the comment **commentId** from node **nodeId**.
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="commentId">The identifier of a comment.</param>
        /// <returns></returns>
        void DeleteComment (string nodeId, string commentId);
        /// <summary>
        /// List comments Gets a list of comments for the node **nodeId**, sorted chronologically with the newest comment first.
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>CommentPaging</returns>
        CommentPaging ListComments (string nodeId, int? skipCount, int? maxItems, List<string> fields);
        /// <summary>
        /// Update a comment Updates an existing comment **commentId** on node **nodeId**.
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="commentId">The identifier of a comment.</param>
        /// <param name="commentBodyUpdate">The JSON representing the comment to be updated.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>CommentEntry</returns>
        CommentEntry UpdateComment (string nodeId, string commentId, CommentBody commentBodyUpdate, List<string> fields);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class CommentsApi : ICommentsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public CommentsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CommentsApi(String basePath)
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
        /// Create a comment Creates a comment on node **nodeId**. You specify the comment in a JSON body like this:  &#x60;&#x60;&#x60;JSON {   \&quot;content\&quot;: \&quot;This is a comment\&quot; } &#x60;&#x60;&#x60;  **Note:** You can create more than one comment by specifying a list of comments in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {     \&quot;content\&quot;: \&quot;This is a comment\&quot;   },   {     \&quot;content\&quot;: \&quot;This is another comment\&quot;   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="commentBodyCreate">The comment text. Note that you can also provide a list of comments.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>CommentEntry</returns>            
        public CommentEntry CreateComment (string nodeId, CommentBody commentBodyCreate, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling CreateComment");
            
            // verify the required parameter 'commentBodyCreate' is set
            if (commentBodyCreate == null) throw new ApiException(400, "Missing required parameter 'commentBodyCreate' when calling CreateComment");
            
    
            var path = "/nodes/{nodeId}/comments";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(commentBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateComment: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateComment: " + response.ErrorMessage, response.ErrorMessage);
    
            return (CommentEntry) ApiClient.Deserialize(response.Content, typeof(CommentEntry), response.Headers);
        }
    
        /// <summary>
        /// Delete a comment Deletes the comment **commentId** from node **nodeId**.
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="commentId">The identifier of a comment.</param> 
        /// <returns></returns>            
        public void DeleteComment (string nodeId, string commentId)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling DeleteComment");
            
            // verify the required parameter 'commentId' is set
            if (commentId == null) throw new ApiException(400, "Missing required parameter 'commentId' when calling DeleteComment");
            
    
            var path = "/nodes/{nodeId}/comments/{commentId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
path = path.Replace("{" + "commentId" + "}", ApiClient.ParameterToString(commentId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteComment: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteComment: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// List comments Gets a list of comments for the node **nodeId**, sorted chronologically with the newest comment first.
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>CommentPaging</returns>            
        public CommentPaging ListComments (string nodeId, int? skipCount, int? maxItems, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling ListComments");
            
    
            var path = "/nodes/{nodeId}/comments";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (skipCount != null) queryParams.Add("skipCount", ApiClient.ParameterToString(skipCount)); // query parameter
 if (maxItems != null) queryParams.Add("maxItems", ApiClient.ParameterToString(maxItems)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListComments: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListComments: " + response.ErrorMessage, response.ErrorMessage);
    
            return (CommentPaging) ApiClient.Deserialize(response.Content, typeof(CommentPaging), response.Headers);
        }
    
        /// <summary>
        /// Update a comment Updates an existing comment **commentId** on node **nodeId**.
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="commentId">The identifier of a comment.</param> 
        /// <param name="commentBodyUpdate">The JSON representing the comment to be updated.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>CommentEntry</returns>            
        public CommentEntry UpdateComment (string nodeId, string commentId, CommentBody commentBodyUpdate, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling UpdateComment");
            
            // verify the required parameter 'commentId' is set
            if (commentId == null) throw new ApiException(400, "Missing required parameter 'commentId' when calling UpdateComment");
            
            // verify the required parameter 'commentBodyUpdate' is set
            if (commentBodyUpdate == null) throw new ApiException(400, "Missing required parameter 'commentBodyUpdate' when calling UpdateComment");
            
    
            var path = "/nodes/{nodeId}/comments/{commentId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
path = path.Replace("{" + "commentId" + "}", ApiClient.ParameterToString(commentId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(commentBodyUpdate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateComment: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateComment: " + response.ErrorMessage, response.ErrorMessage);
    
            return (CommentEntry) ApiClient.Deserialize(response.Content, typeof(CommentEntry), response.Headers);
        }
    
    }
}
