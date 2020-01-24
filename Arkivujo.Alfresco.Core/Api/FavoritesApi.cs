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
    public interface IFavoritesApi
    {
        /// <summary>
        /// Create a favorite Favorite a **site**, **file**, or **folder** in the repository.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user.  **Note:** You can favorite more than one entity by specifying a list of objects in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {        \&quot;target\&quot;: {           \&quot;file\&quot;: {              \&quot;guid\&quot;: \&quot;abcde-01234-....\&quot;           }        }    },    {        \&quot;target\&quot;: {           \&quot;file\&quot;: {              \&quot;guid\&quot;: \&quot;abcde-09863-....\&quot;           }        }    }, ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="favoriteBodyCreate">An object identifying the entity to be favorited.  The object consists of a single property which is an object with the name &#x60;site&#x60;, &#x60;file&#x60;, or &#x60;folder&#x60;. The content of that object is the &#x60;guid&#x60; of the target entity.  For example, to favorite a file the following body would be used:  &#x60;&#x60;&#x60;JSON {    \&quot;target\&quot;: {       \&quot;file\&quot;: {          \&quot;guid\&quot;: \&quot;abcde-01234-....\&quot;       }    } } &#x60;&#x60;&#x60; </param>
        /// <param name="include">Returns additional information about favorites, the following optional fields can be requested: * path (note, this only applies to files and folders) </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>FavoriteEntry</returns>
        FavoriteEntry CreateFavorite (string personId, FavoriteBodyCreate favoriteBodyCreate, List<string> include, List<string> fields);
        /// <summary>
        /// Create a site favorite **Note:** this endpoint is deprecated as of Alfresco 4.2, and will be removed in the future. Use &#x60;/people/{personId}/favorites&#x60; instead.  Create a site favorite for person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user.   **Note:** You can favorite more than one site by specifying a list of sites in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {     \&quot;id\&quot;: \&quot;test-site-1\&quot;   },   {     \&quot;id\&quot;: \&quot;test-site-2\&quot;   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="favoriteSiteBodyCreate">The id of the site to favorite.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>FavoriteSiteEntry</returns>
        FavoriteSiteEntry CreateSiteFavorite (string personId, FavoriteSiteBodyCreate favoriteSiteBodyCreate, List<string> fields);
        /// <summary>
        /// Delete a favorite Deletes **favoriteId** as a favorite of person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="favoriteId">The identifier of a favorite.</param>
        /// <returns></returns>
        void DeleteFavorite (string personId, string favoriteId);
        /// <summary>
        /// Delete a site favorite **Note:** this endpoint is deprecated as of Alfresco 4.2, and will be removed in the future. Use &#x60;/people/{personId}/favorites/{favoriteId}&#x60; instead.  Deletes site **siteId** from the favorite site list of person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="siteId">The identifier of a site.</param>
        /// <returns></returns>
        void DeleteSiteFavorite (string personId, string siteId);
        /// <summary>
        /// Get a favorite Gets favorite **favoriteId** for person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="favoriteId">The identifier of a favorite.</param>
        /// <param name="include">Returns additional information about favorites, the following optional fields can be requested: * path (note, this only applies to files and folders) </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>FavoriteEntry</returns>
        FavoriteEntry GetFavorite (string personId, string favoriteId, List<string> include, List<string> fields);
        /// <summary>
        /// Get a favorite site **Note:** this endpoint is deprecated as of Alfresco 4.2, and will be removed in the future. Use &#x60;/people/{personId}/favorites/{favoriteId}&#x60; instead.  Gets information on favorite site **siteId** of person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="siteId">The identifier of a site.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SiteEntry</returns>
        SiteEntry GetFavoriteSite (string personId, string siteId, List<string> fields);
        /// <summary>
        /// List favorite sites **Note:** this endpoint is deprecated as of Alfresco 4.2, and will be removed in the future. Use &#x60;/people/{personId}/favorites&#x60; instead.  Gets a list of a person&#39;s favorite sites.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SitePaging</returns>
        SitePaging ListFavoriteSitesForPerson (string personId, int? skipCount, int? maxItems, List<string> fields);
        /// <summary>
        /// List favorites Gets a list of favorites for person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user.  You can use the **where** parameter to restrict the list in the response to entries of a specific kind. The **where** parameter takes a value. The value is a single predicate that can include one or more **EXISTS** conditions. The **EXISTS** condition uses a single operand to limit the list to include entries that include that one property. The property values are:  *   &#x60;target/file&#x60; *   &#x60;target/folder&#x60; *   &#x60;target/site&#x60;  For example, the following **where** parameter restricts the returned list to the file favorites for a person:  &#x60;&#x60;&#x60;SQL (EXISTS(target/file)) &#x60;&#x60;&#x60; You can specify more than one condition using **OR**. The predicate must be enclosed in parentheses.   For example, the following **where** parameter restricts the returned list to the file and folder favorites for a person:  &#x60;&#x60;&#x60;SQL (EXISTS(target/file) OR EXISTS(target/folder)) &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="where">A string to restrict the returned objects by using a predicate.</param>
        /// <param name="include">Returns additional information about favorites, the following optional fields can be requested: * path (note, this only applies to files and folders) </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>FavoritePaging</returns>
        FavoritePaging ListFavorites (string personId, int? skipCount, int? maxItems, string where, List<string> include, List<string> fields);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class FavoritesApi : IFavoritesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FavoritesApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public FavoritesApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="FavoritesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FavoritesApi(String basePath)
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
        /// Create a favorite Favorite a **site**, **file**, or **folder** in the repository.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user.  **Note:** You can favorite more than one entity by specifying a list of objects in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {        \&quot;target\&quot;: {           \&quot;file\&quot;: {              \&quot;guid\&quot;: \&quot;abcde-01234-....\&quot;           }        }    },    {        \&quot;target\&quot;: {           \&quot;file\&quot;: {              \&quot;guid\&quot;: \&quot;abcde-09863-....\&quot;           }        }    }, ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="favoriteBodyCreate">An object identifying the entity to be favorited.  The object consists of a single property which is an object with the name &#x60;site&#x60;, &#x60;file&#x60;, or &#x60;folder&#x60;. The content of that object is the &#x60;guid&#x60; of the target entity.  For example, to favorite a file the following body would be used:  &#x60;&#x60;&#x60;JSON {    \&quot;target\&quot;: {       \&quot;file\&quot;: {          \&quot;guid\&quot;: \&quot;abcde-01234-....\&quot;       }    } } &#x60;&#x60;&#x60; </param> 
        /// <param name="include">Returns additional information about favorites, the following optional fields can be requested: * path (note, this only applies to files and folders) </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>FavoriteEntry</returns>            
        public FavoriteEntry CreateFavorite (string personId, FavoriteBodyCreate favoriteBodyCreate, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling CreateFavorite");
            
            // verify the required parameter 'favoriteBodyCreate' is set
            if (favoriteBodyCreate == null) throw new ApiException(400, "Missing required parameter 'favoriteBodyCreate' when calling CreateFavorite");
            
    
            var path = "/people/{personId}/favorites";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(favoriteBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateFavorite: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateFavorite: " + response.ErrorMessage, response.ErrorMessage);
    
            return (FavoriteEntry) ApiClient.Deserialize(response.Content, typeof(FavoriteEntry), response.Headers);
        }
    
        /// <summary>
        /// Create a site favorite **Note:** this endpoint is deprecated as of Alfresco 4.2, and will be removed in the future. Use &#x60;/people/{personId}/favorites&#x60; instead.  Create a site favorite for person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user.   **Note:** You can favorite more than one site by specifying a list of sites in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {     \&quot;id\&quot;: \&quot;test-site-1\&quot;   },   {     \&quot;id\&quot;: \&quot;test-site-2\&quot;   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="favoriteSiteBodyCreate">The id of the site to favorite.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>FavoriteSiteEntry</returns>            
        public FavoriteSiteEntry CreateSiteFavorite (string personId, FavoriteSiteBodyCreate favoriteSiteBodyCreate, List<string> fields)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling CreateSiteFavorite");
            
            // verify the required parameter 'favoriteSiteBodyCreate' is set
            if (favoriteSiteBodyCreate == null) throw new ApiException(400, "Missing required parameter 'favoriteSiteBodyCreate' when calling CreateSiteFavorite");
            
    
            var path = "/people/{personId}/favorite-sites";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(favoriteSiteBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateSiteFavorite: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateSiteFavorite: " + response.ErrorMessage, response.ErrorMessage);
    
            return (FavoriteSiteEntry) ApiClient.Deserialize(response.Content, typeof(FavoriteSiteEntry), response.Headers);
        }
    
        /// <summary>
        /// Delete a favorite Deletes **favoriteId** as a favorite of person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="favoriteId">The identifier of a favorite.</param> 
        /// <returns></returns>            
        public void DeleteFavorite (string personId, string favoriteId)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling DeleteFavorite");
            
            // verify the required parameter 'favoriteId' is set
            if (favoriteId == null) throw new ApiException(400, "Missing required parameter 'favoriteId' when calling DeleteFavorite");
            
    
            var path = "/people/{personId}/favorites/{favoriteId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
path = path.Replace("{" + "favoriteId" + "}", ApiClient.ParameterToString(favoriteId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteFavorite: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteFavorite: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Delete a site favorite **Note:** this endpoint is deprecated as of Alfresco 4.2, and will be removed in the future. Use &#x60;/people/{personId}/favorites/{favoriteId}&#x60; instead.  Deletes site **siteId** from the favorite site list of person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="siteId">The identifier of a site.</param> 
        /// <returns></returns>            
        public void DeleteSiteFavorite (string personId, string siteId)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling DeleteSiteFavorite");
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling DeleteSiteFavorite");
            
    
            var path = "/people/{personId}/favorite-sites/{siteId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
path = path.Replace("{" + "siteId" + "}", ApiClient.ParameterToString(siteId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteSiteFavorite: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteSiteFavorite: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get a favorite Gets favorite **favoriteId** for person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="favoriteId">The identifier of a favorite.</param> 
        /// <param name="include">Returns additional information about favorites, the following optional fields can be requested: * path (note, this only applies to files and folders) </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>FavoriteEntry</returns>            
        public FavoriteEntry GetFavorite (string personId, string favoriteId, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling GetFavorite");
            
            // verify the required parameter 'favoriteId' is set
            if (favoriteId == null) throw new ApiException(400, "Missing required parameter 'favoriteId' when calling GetFavorite");
            
    
            var path = "/people/{personId}/favorites/{favoriteId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
path = path.Replace("{" + "favoriteId" + "}", ApiClient.ParameterToString(favoriteId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetFavorite: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetFavorite: " + response.ErrorMessage, response.ErrorMessage);
    
            return (FavoriteEntry) ApiClient.Deserialize(response.Content, typeof(FavoriteEntry), response.Headers);
        }
    
        /// <summary>
        /// Get a favorite site **Note:** this endpoint is deprecated as of Alfresco 4.2, and will be removed in the future. Use &#x60;/people/{personId}/favorites/{favoriteId}&#x60; instead.  Gets information on favorite site **siteId** of person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="siteId">The identifier of a site.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SiteEntry</returns>            
        public SiteEntry GetFavoriteSite (string personId, string siteId, List<string> fields)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling GetFavoriteSite");
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling GetFavoriteSite");
            
    
            var path = "/people/{personId}/favorite-sites/{siteId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
path = path.Replace("{" + "siteId" + "}", ApiClient.ParameterToString(siteId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetFavoriteSite: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetFavoriteSite: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteEntry) ApiClient.Deserialize(response.Content, typeof(SiteEntry), response.Headers);
        }
    
        /// <summary>
        /// List favorite sites **Note:** this endpoint is deprecated as of Alfresco 4.2, and will be removed in the future. Use &#x60;/people/{personId}/favorites&#x60; instead.  Gets a list of a person&#39;s favorite sites.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SitePaging</returns>            
        public SitePaging ListFavoriteSitesForPerson (string personId, int? skipCount, int? maxItems, List<string> fields)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling ListFavoriteSitesForPerson");
            
    
            var path = "/people/{personId}/favorite-sites";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling ListFavoriteSitesForPerson: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListFavoriteSitesForPerson: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SitePaging) ApiClient.Deserialize(response.Content, typeof(SitePaging), response.Headers);
        }
    
        /// <summary>
        /// List favorites Gets a list of favorites for person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user.  You can use the **where** parameter to restrict the list in the response to entries of a specific kind. The **where** parameter takes a value. The value is a single predicate that can include one or more **EXISTS** conditions. The **EXISTS** condition uses a single operand to limit the list to include entries that include that one property. The property values are:  *   &#x60;target/file&#x60; *   &#x60;target/folder&#x60; *   &#x60;target/site&#x60;  For example, the following **where** parameter restricts the returned list to the file favorites for a person:  &#x60;&#x60;&#x60;SQL (EXISTS(target/file)) &#x60;&#x60;&#x60; You can specify more than one condition using **OR**. The predicate must be enclosed in parentheses.   For example, the following **where** parameter restricts the returned list to the file and folder favorites for a person:  &#x60;&#x60;&#x60;SQL (EXISTS(target/file) OR EXISTS(target/folder)) &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="where">A string to restrict the returned objects by using a predicate.</param> 
        /// <param name="include">Returns additional information about favorites, the following optional fields can be requested: * path (note, this only applies to files and folders) </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>FavoritePaging</returns>            
        public FavoritePaging ListFavorites (string personId, int? skipCount, int? maxItems, string where, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling ListFavorites");
            
    
            var path = "/people/{personId}/favorites";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling ListFavorites: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListFavorites: " + response.ErrorMessage, response.ErrorMessage);
    
            return (FavoritePaging) ApiClient.Deserialize(response.Content, typeof(FavoritePaging), response.Headers);
        }
    
    }
}
