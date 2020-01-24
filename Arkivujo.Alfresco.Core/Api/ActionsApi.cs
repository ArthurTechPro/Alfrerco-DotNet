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
    public interface IActionsApi
    {
        /// <summary>
        /// Retrieve the details of an action definition **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Retrieve the details of the action denoted by **actionDefinitionId**. 
        /// </summary>
        /// <param name="actionDefinitionId">The identifier of an action definition.</param>
        /// <returns>ActionDefinitionEntry</returns>
        ActionDefinitionEntry ActionDetails (string actionDefinitionId);
        /// <summary>
        /// Execute an action **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Executes an action  An action may be executed against a node specified by **targetId**. For example:  &#x60;&#x60;&#x60; {   \&quot;actionDefinitionId\&quot;: \&quot;copy\&quot;,   \&quot;targetId\&quot;: \&quot;4c4b3c43-f18b-43ff-af84-751f16f1ddfd\&quot;,   \&quot;params\&quot;: {     \&quot;destination-folder\&quot;: \&quot;34219f79-66fa-4ebf-b371-118598af898c\&quot;   } } &#x60;&#x60;&#x60;  Performing a POST with the request body shown above will result in the node identified by &#x60;&#x60;&#x60;targetId&#x60;&#x60;&#x60; being copied to the destination folder specified in the &#x60;&#x60;&#x60;params&#x60;&#x60;&#x60; object by the key &#x60;&#x60;&#x60;destination-folder&#x60;&#x60;&#x60;.  **targetId** is optional, however, currently **targetId** must be a valid node ID. In the future, actions may be executed against different entity types or executed without the need for the context of an entity.   Parameters supplied to the action within the &#x60;&#x60;&#x60;params&#x60;&#x60;&#x60; object will be converted to the expected type, where possible using the DefaultTypeConverter class. In addition:  * Node IDs may be supplied in their short form (implicit workspace://SpacesStore prefix) * Aspect names may be supplied using their short form, e.g. cm:versionable or cm:auditable  In this example, we add the aspect &#x60;&#x60;&#x60;cm:versionable&#x60;&#x60;&#x60; to a node using the QName resolution mentioned above:  &#x60;&#x60;&#x60; {   \&quot;actionDefinitionId\&quot;: \&quot;add-features\&quot;,   \&quot;targetId\&quot;: \&quot;16349e3f-2977-44d1-93f2-73c12b8083b5\&quot;,   \&quot;params\&quot;: {     \&quot;aspect-name\&quot;: \&quot;cm:versionable\&quot;   } } &#x60;&#x60;&#x60;  The &#x60;&#x60;&#x60;actionDefinitionId&#x60;&#x60;&#x60; is the &#x60;&#x60;&#x60;id&#x60;&#x60;&#x60; of an action definition as returned by the _list actions_ operations (e.g. GET /action-definitions).  The action will be executed **asynchronously** with a &#x60;202&#x60; HTTP response signifying that the request has been accepted successfully. The response body contains the unique ID of the action pending execution. The ID may be used, for example to correlate an execution with output in the server logs. 
        /// </summary>
        /// <param name="actionBodyExec">Action execution details</param>
        /// <returns>ActionExecResultEntry</returns>
        ActionExecResultEntry ActionExec (ActionBodyExec actionBodyExec);
        /// <summary>
        /// Retrieve list of available actions **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Gets a list of all available actions  The default sort order for the returned list is for actions to be sorted by ascending name. You can override the default by using the **orderBy** parameter.  You can use any of the following fields to order the results: * name * title 
        /// </summary>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>ActionDefinitionList</returns>
        ActionDefinitionList ListActions (int? skipCount, int? maxItems, List<string> orderBy, List<string> fields);
        /// <summary>
        /// Retrieve actions for a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Retrieve the list of actions that may be executed against the given **nodeId**.  The default sort order for the returned list is for actions to be sorted by ascending name. You can override the default by using the **orderBy** parameter.  You can use any of the following fields to order the results: * name * title 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>ActionDefinitionList</returns>
        ActionDefinitionList NodeActions (string nodeId, int? skipCount, int? maxItems, List<string> orderBy, List<string> fields);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ActionsApi : IActionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public ActionsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ActionsApi(String basePath)
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
        /// Retrieve the details of an action definition **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Retrieve the details of the action denoted by **actionDefinitionId**. 
        /// </summary>
        /// <param name="actionDefinitionId">The identifier of an action definition.</param> 
        /// <returns>ActionDefinitionEntry</returns>            
        public ActionDefinitionEntry ActionDetails (string actionDefinitionId)
        {
            
            // verify the required parameter 'actionDefinitionId' is set
            if (actionDefinitionId == null) throw new ApiException(400, "Missing required parameter 'actionDefinitionId' when calling ActionDetails");
            
    
            var path = "/action-definitions/{actionDefinitionId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "actionDefinitionId" + "}", ApiClient.ParameterToString(actionDefinitionId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling ActionDetails: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ActionDetails: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ActionDefinitionEntry) ApiClient.Deserialize(response.Content, typeof(ActionDefinitionEntry), response.Headers);
        }
    
        /// <summary>
        /// Execute an action **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Executes an action  An action may be executed against a node specified by **targetId**. For example:  &#x60;&#x60;&#x60; {   \&quot;actionDefinitionId\&quot;: \&quot;copy\&quot;,   \&quot;targetId\&quot;: \&quot;4c4b3c43-f18b-43ff-af84-751f16f1ddfd\&quot;,   \&quot;params\&quot;: {     \&quot;destination-folder\&quot;: \&quot;34219f79-66fa-4ebf-b371-118598af898c\&quot;   } } &#x60;&#x60;&#x60;  Performing a POST with the request body shown above will result in the node identified by &#x60;&#x60;&#x60;targetId&#x60;&#x60;&#x60; being copied to the destination folder specified in the &#x60;&#x60;&#x60;params&#x60;&#x60;&#x60; object by the key &#x60;&#x60;&#x60;destination-folder&#x60;&#x60;&#x60;.  **targetId** is optional, however, currently **targetId** must be a valid node ID. In the future, actions may be executed against different entity types or executed without the need for the context of an entity.   Parameters supplied to the action within the &#x60;&#x60;&#x60;params&#x60;&#x60;&#x60; object will be converted to the expected type, where possible using the DefaultTypeConverter class. In addition:  * Node IDs may be supplied in their short form (implicit workspace://SpacesStore prefix) * Aspect names may be supplied using their short form, e.g. cm:versionable or cm:auditable  In this example, we add the aspect &#x60;&#x60;&#x60;cm:versionable&#x60;&#x60;&#x60; to a node using the QName resolution mentioned above:  &#x60;&#x60;&#x60; {   \&quot;actionDefinitionId\&quot;: \&quot;add-features\&quot;,   \&quot;targetId\&quot;: \&quot;16349e3f-2977-44d1-93f2-73c12b8083b5\&quot;,   \&quot;params\&quot;: {     \&quot;aspect-name\&quot;: \&quot;cm:versionable\&quot;   } } &#x60;&#x60;&#x60;  The &#x60;&#x60;&#x60;actionDefinitionId&#x60;&#x60;&#x60; is the &#x60;&#x60;&#x60;id&#x60;&#x60;&#x60; of an action definition as returned by the _list actions_ operations (e.g. GET /action-definitions).  The action will be executed **asynchronously** with a &#x60;202&#x60; HTTP response signifying that the request has been accepted successfully. The response body contains the unique ID of the action pending execution. The ID may be used, for example to correlate an execution with output in the server logs. 
        /// </summary>
        /// <param name="actionBodyExec">Action execution details</param> 
        /// <returns>ActionExecResultEntry</returns>            
        public ActionExecResultEntry ActionExec (ActionBodyExec actionBodyExec)
        {
            
            // verify the required parameter 'actionBodyExec' is set
            if (actionBodyExec == null) throw new ApiException(400, "Missing required parameter 'actionBodyExec' when calling ActionExec");
            
    
            var path = "/action-executions";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(actionBodyExec); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ActionExec: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ActionExec: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ActionExecResultEntry) ApiClient.Deserialize(response.Content, typeof(ActionExecResultEntry), response.Headers);
        }
    
        /// <summary>
        /// Retrieve list of available actions **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Gets a list of all available actions  The default sort order for the returned list is for actions to be sorted by ascending name. You can override the default by using the **orderBy** parameter.  You can use any of the following fields to order the results: * name * title 
        /// </summary>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>ActionDefinitionList</returns>            
        public ActionDefinitionList ListActions (int? skipCount, int? maxItems, List<string> orderBy, List<string> fields)
        {
            
    
            var path = "/action-definitions";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (skipCount != null) queryParams.Add("skipCount", ApiClient.ParameterToString(skipCount)); // query parameter
 if (maxItems != null) queryParams.Add("maxItems", ApiClient.ParameterToString(maxItems)); // query parameter
 if (orderBy != null) queryParams.Add("orderBy", ApiClient.ParameterToString(orderBy)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListActions: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListActions: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ActionDefinitionList) ApiClient.Deserialize(response.Content, typeof(ActionDefinitionList), response.Headers);
        }
    
        /// <summary>
        /// Retrieve actions for a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Retrieve the list of actions that may be executed against the given **nodeId**.  The default sort order for the returned list is for actions to be sorted by ascending name. You can override the default by using the **orderBy** parameter.  You can use any of the following fields to order the results: * name * title 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>ActionDefinitionList</returns>            
        public ActionDefinitionList NodeActions (string nodeId, int? skipCount, int? maxItems, List<string> orderBy, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling NodeActions");
            
    
            var path = "/nodes/{nodeId}/action-definitions";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (skipCount != null) queryParams.Add("skipCount", ApiClient.ParameterToString(skipCount)); // query parameter
 if (maxItems != null) queryParams.Add("maxItems", ApiClient.ParameterToString(maxItems)); // query parameter
 if (orderBy != null) queryParams.Add("orderBy", ApiClient.ParameterToString(orderBy)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling NodeActions: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling NodeActions: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ActionDefinitionList) ApiClient.Deserialize(response.Content, typeof(ActionDefinitionList), response.Headers);
        }
    
    }
}
