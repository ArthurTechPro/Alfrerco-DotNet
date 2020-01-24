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
    public interface ITagsApi
    {
        /// <summary>
        /// Create a tag for a node Creates a tag on the node **nodeId**. You specify the tag in a JSON body like this:  &#x60;&#x60;&#x60;JSON {   \&quot;tag\&quot;:\&quot;test-tag-1\&quot; } &#x60;&#x60;&#x60;  **Note:** You can create more than one tag by specifying a list of tags in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {     \&quot;tag\&quot;:\&quot;test-tag-1\&quot;   },   {     \&quot;tag\&quot;:\&quot;test-tag-2\&quot;   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {          ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="tagBodyCreate">The new tag</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>TagEntry</returns>
        TagEntry CreateTagForNode (string nodeId, TagBody tagBodyCreate, List<string> fields);
        /// <summary>
        /// Delete a tag from a node Deletes tag **tagId** from node **nodeId**.
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="tagId">The identifier of a tag.</param>
        /// <returns></returns>
        void DeleteTagFromNode (string nodeId, string tagId);
        /// <summary>
        /// Get a tag Get a specific tag with **tagId**.
        /// </summary>
        /// <param name="tagId">The identifier of a tag.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>TagEntry</returns>
        TagEntry GetTag (string tagId, List<string> fields);
        /// <summary>
        /// List tags Gets a list of tags in this repository.  You can use the **include** parameter to return additional **values** information. 
        /// </summary>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <param name="include">Returns additional information about the tag. The following optional fields can be requested: * count </param>
        /// <returns>TagPaging</returns>
        TagPaging ListTags (int? skipCount, int? maxItems, List<string> fields, List<string> include);
        /// <summary>
        /// List tags for a node Gets a list of tags for node **nodeId**.
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>TagPaging</returns>
        TagPaging ListTagsForNode (string nodeId, int? skipCount, int? maxItems, List<string> fields);
        /// <summary>
        /// Update a tag Updates the tag **tagId**.
        /// </summary>
        /// <param name="tagId">The identifier of a tag.</param>
        /// <param name="tagBodyUpdate">The updated tag</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>TagEntry</returns>
        TagEntry UpdateTag (string tagId, TagBody tagBodyUpdate, List<string> fields);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TagsApi : ITagsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public TagsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TagsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TagsApi(String basePath)
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
        /// Create a tag for a node Creates a tag on the node **nodeId**. You specify the tag in a JSON body like this:  &#x60;&#x60;&#x60;JSON {   \&quot;tag\&quot;:\&quot;test-tag-1\&quot; } &#x60;&#x60;&#x60;  **Note:** You can create more than one tag by specifying a list of tags in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {     \&quot;tag\&quot;:\&quot;test-tag-1\&quot;   },   {     \&quot;tag\&quot;:\&quot;test-tag-2\&quot;   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {          ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="tagBodyCreate">The new tag</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>TagEntry</returns>            
        public TagEntry CreateTagForNode (string nodeId, TagBody tagBodyCreate, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling CreateTagForNode");
            
            // verify the required parameter 'tagBodyCreate' is set
            if (tagBodyCreate == null) throw new ApiException(400, "Missing required parameter 'tagBodyCreate' when calling CreateTagForNode");
            
    
            var path = "/nodes/{nodeId}/tags";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(tagBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateTagForNode: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateTagForNode: " + response.ErrorMessage, response.ErrorMessage);
    
            return (TagEntry) ApiClient.Deserialize(response.Content, typeof(TagEntry), response.Headers);
        }
    
        /// <summary>
        /// Delete a tag from a node Deletes tag **tagId** from node **nodeId**.
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="tagId">The identifier of a tag.</param> 
        /// <returns></returns>            
        public void DeleteTagFromNode (string nodeId, string tagId)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling DeleteTagFromNode");
            
            // verify the required parameter 'tagId' is set
            if (tagId == null) throw new ApiException(400, "Missing required parameter 'tagId' when calling DeleteTagFromNode");
            
    
            var path = "/nodes/{nodeId}/tags/{tagId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
path = path.Replace("{" + "tagId" + "}", ApiClient.ParameterToString(tagId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteTagFromNode: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteTagFromNode: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get a tag Get a specific tag with **tagId**.
        /// </summary>
        /// <param name="tagId">The identifier of a tag.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>TagEntry</returns>            
        public TagEntry GetTag (string tagId, List<string> fields)
        {
            
            // verify the required parameter 'tagId' is set
            if (tagId == null) throw new ApiException(400, "Missing required parameter 'tagId' when calling GetTag");
            
    
            var path = "/tags/{tagId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "tagId" + "}", ApiClient.ParameterToString(tagId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetTag: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetTag: " + response.ErrorMessage, response.ErrorMessage);
    
            return (TagEntry) ApiClient.Deserialize(response.Content, typeof(TagEntry), response.Headers);
        }
    
        /// <summary>
        /// List tags Gets a list of tags in this repository.  You can use the **include** parameter to return additional **values** information. 
        /// </summary>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <param name="include">Returns additional information about the tag. The following optional fields can be requested: * count </param> 
        /// <returns>TagPaging</returns>            
        public TagPaging ListTags (int? skipCount, int? maxItems, List<string> fields, List<string> include)
        {
            
    
            var path = "/tags";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (skipCount != null) queryParams.Add("skipCount", ApiClient.ParameterToString(skipCount)); // query parameter
 if (maxItems != null) queryParams.Add("maxItems", ApiClient.ParameterToString(maxItems)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
 if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListTags: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListTags: " + response.ErrorMessage, response.ErrorMessage);
    
            return (TagPaging) ApiClient.Deserialize(response.Content, typeof(TagPaging), response.Headers);
        }
    
        /// <summary>
        /// List tags for a node Gets a list of tags for node **nodeId**.
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>TagPaging</returns>            
        public TagPaging ListTagsForNode (string nodeId, int? skipCount, int? maxItems, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling ListTagsForNode");
            
    
            var path = "/nodes/{nodeId}/tags";
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
                throw new ApiException ((int)response.StatusCode, "Error calling ListTagsForNode: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListTagsForNode: " + response.ErrorMessage, response.ErrorMessage);
    
            return (TagPaging) ApiClient.Deserialize(response.Content, typeof(TagPaging), response.Headers);
        }
    
        /// <summary>
        /// Update a tag Updates the tag **tagId**.
        /// </summary>
        /// <param name="tagId">The identifier of a tag.</param> 
        /// <param name="tagBodyUpdate">The updated tag</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>TagEntry</returns>            
        public TagEntry UpdateTag (string tagId, TagBody tagBodyUpdate, List<string> fields)
        {
            
            // verify the required parameter 'tagId' is set
            if (tagId == null) throw new ApiException(400, "Missing required parameter 'tagId' when calling UpdateTag");
            
            // verify the required parameter 'tagBodyUpdate' is set
            if (tagBodyUpdate == null) throw new ApiException(400, "Missing required parameter 'tagBodyUpdate' when calling UpdateTag");
            
    
            var path = "/tags/{tagId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "tagId" + "}", ApiClient.ParameterToString(tagId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(tagBodyUpdate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateTag: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateTag: " + response.ErrorMessage, response.ErrorMessage);
    
            return (TagEntry) ApiClient.Deserialize(response.Content, typeof(TagEntry), response.Headers);
        }
    
    }
}
