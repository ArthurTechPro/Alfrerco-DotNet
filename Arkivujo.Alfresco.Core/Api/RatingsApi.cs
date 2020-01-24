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
    public interface IRatingsApi
    {
        /// <summary>
        /// Create a rating Create a rating for the node with identifier **nodeId**
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="ratingBodyCreate">For \&quot;myRating\&quot; the type is specific to the rating scheme, boolean for the likes and an integer for the fiveStar.  For example, to \&quot;like\&quot; a file the following body would be used:  &#x60;&#x60;&#x60;JSON   {     \&quot;id\&quot;: \&quot;likes\&quot;,     \&quot;myRating\&quot;: true   } &#x60;&#x60;&#x60; </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>RatingEntry</returns>
        RatingEntry CreateRating (string nodeId, RatingBody ratingBodyCreate, List<string> fields);
        /// <summary>
        /// Delete a rating Deletes rating **ratingId** from node **nodeId**.
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="ratingId">The identifier of a rating.</param>
        /// <returns></returns>
        void DeleteRating (string nodeId, string ratingId);
        /// <summary>
        /// Get a rating Get the specific rating **ratingId** on node **nodeId**.
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="ratingId">The identifier of a rating.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>RatingEntry</returns>
        RatingEntry GetRating (string nodeId, string ratingId, List<string> fields);
        /// <summary>
        /// List ratings Gets a list of ratings for node **nodeId**.
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>RatingPaging</returns>
        RatingPaging ListRatings (string nodeId, int? skipCount, int? maxItems, List<string> fields);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class RatingsApi : IRatingsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RatingsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public RatingsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="RatingsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public RatingsApi(String basePath)
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
        /// Create a rating Create a rating for the node with identifier **nodeId**
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="ratingBodyCreate">For \&quot;myRating\&quot; the type is specific to the rating scheme, boolean for the likes and an integer for the fiveStar.  For example, to \&quot;like\&quot; a file the following body would be used:  &#x60;&#x60;&#x60;JSON   {     \&quot;id\&quot;: \&quot;likes\&quot;,     \&quot;myRating\&quot;: true   } &#x60;&#x60;&#x60; </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>RatingEntry</returns>            
        public RatingEntry CreateRating (string nodeId, RatingBody ratingBodyCreate, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling CreateRating");
            
            // verify the required parameter 'ratingBodyCreate' is set
            if (ratingBodyCreate == null) throw new ApiException(400, "Missing required parameter 'ratingBodyCreate' when calling CreateRating");
            
    
            var path = "/nodes/{nodeId}/ratings";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(ratingBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateRating: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateRating: " + response.ErrorMessage, response.ErrorMessage);
    
            return (RatingEntry) ApiClient.Deserialize(response.Content, typeof(RatingEntry), response.Headers);
        }
    
        /// <summary>
        /// Delete a rating Deletes rating **ratingId** from node **nodeId**.
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="ratingId">The identifier of a rating.</param> 
        /// <returns></returns>            
        public void DeleteRating (string nodeId, string ratingId)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling DeleteRating");
            
            // verify the required parameter 'ratingId' is set
            if (ratingId == null) throw new ApiException(400, "Missing required parameter 'ratingId' when calling DeleteRating");
            
    
            var path = "/nodes/{nodeId}/ratings/{ratingId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
path = path.Replace("{" + "ratingId" + "}", ApiClient.ParameterToString(ratingId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteRating: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteRating: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get a rating Get the specific rating **ratingId** on node **nodeId**.
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="ratingId">The identifier of a rating.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>RatingEntry</returns>            
        public RatingEntry GetRating (string nodeId, string ratingId, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling GetRating");
            
            // verify the required parameter 'ratingId' is set
            if (ratingId == null) throw new ApiException(400, "Missing required parameter 'ratingId' when calling GetRating");
            
    
            var path = "/nodes/{nodeId}/ratings/{ratingId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
path = path.Replace("{" + "ratingId" + "}", ApiClient.ParameterToString(ratingId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetRating: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetRating: " + response.ErrorMessage, response.ErrorMessage);
    
            return (RatingEntry) ApiClient.Deserialize(response.Content, typeof(RatingEntry), response.Headers);
        }
    
        /// <summary>
        /// List ratings Gets a list of ratings for node **nodeId**.
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>RatingPaging</returns>            
        public RatingPaging ListRatings (string nodeId, int? skipCount, int? maxItems, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling ListRatings");
            
    
            var path = "/nodes/{nodeId}/ratings";
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
                throw new ApiException ((int)response.StatusCode, "Error calling ListRatings: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListRatings: " + response.ErrorMessage, response.ErrorMessage);
    
            return (RatingPaging) ApiClient.Deserialize(response.Content, typeof(RatingPaging), response.Headers);
        }
    
    }
}
