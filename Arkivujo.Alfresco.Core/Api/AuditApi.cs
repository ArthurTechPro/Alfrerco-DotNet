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
    public interface IAuditApi
    {
        /// <summary>
        /// Permanently delete audit entries for an audit application **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Permanently delete audit entries for an audit application **auditApplicationId**.  The **where** clause must be specified, either with an inclusive time period or for an inclusive range of ids. The delete is within the context of the given audit application.  For example:  *   &#x60;&#x60;&#x60;where&#x3D;(createdAt BETWEEN (&#39;2017-06-02T12:13:51.593+01:00&#39; , &#39;2017-06-04T10:05:16.536+01:00&#39;)&#x60;&#x60;&#x60; *   &#x60;&#x60;&#x60;where&#x3D;(id BETWEEN (&#39;1234&#39;, &#39;4321&#39;)&#x60;&#x60;&#x60;  You must have admin rights to delete audit information. 
        /// </summary>
        /// <param name="auditApplicationId">The identifier of an audit application.</param>
        /// <param name="where">Audit entries to permanently delete for an audit application, given an inclusive time period or range of ids. For example:  *   &#x60;&#x60;&#x60;where&#x3D;(createdAt BETWEEN (&#39;2017-06-02T12:13:51.593+01:00&#39; , &#39;2017-06-04T10:05:16.536+01:00&#39;)&#x60;&#x60;&#x60; *   &#x60;&#x60;&#x60;where&#x3D;(id BETWEEN (&#39;1234&#39;, &#39;4321&#39;)&#x60;&#x60;&#x60; </param>
        /// <returns></returns>
        void DeleteAuditEntriesForAuditApp (string auditApplicationId, string where);
        /// <summary>
        /// Permanently delete an audit entry **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Permanently delete a single audit entry **auditEntryId**.  You must have admin rights to delete audit information. 
        /// </summary>
        /// <param name="auditApplicationId">The identifier of an audit application.</param>
        /// <param name="auditEntryId">The identifier of an audit entry.</param>
        /// <returns></returns>
        void DeleteAuditEntry (string auditApplicationId, string auditEntryId);
        /// <summary>
        /// Get audit application info **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Get status of an audit application **auditApplicationId**.  You must have admin rights to retrieve audit information. 
        /// </summary>
        /// <param name="auditApplicationId">The identifier of an audit application.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>AuditApp</returns>
        AuditApp GetAuditApp (string auditApplicationId, List<string> fields);
        /// <summary>
        /// Get audit entry **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Gets audit entry **auditEntryId**.  You must have admin rights to access audit information. 
        /// </summary>
        /// <param name="auditApplicationId">The identifier of an audit application.</param>
        /// <param name="auditEntryId">The identifier of an audit entry.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>AuditEntryEntry</returns>
        AuditEntryEntry GetAuditEntry (string auditApplicationId, string auditEntryId, List<string> fields);
        /// <summary>
        /// List audit applications **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Gets a list of audit applications in this repository.  This list may include pre-configured audit applications, if enabled, such as:  * alfresco-access * CMISChangeLog * Alfresco Tagging Service * Alfresco Sync Service (used by Enterprise Cloud Sync)  You must have admin rights to retrieve audit information. 
        /// </summary>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>AuditAppPaging</returns>
        AuditAppPaging ListAuditApps (int? skipCount, int? maxItems, List<string> fields);
        /// <summary>
        /// List audit entries for an audit application **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Gets a list of audit entries for audit application **auditApplicationId**.  You can use the **include** parameter to return additional **values** information.  The list can be filtered by one or more of: * **createdByUser** person id * **createdAt** inclusive time period * **id** inclusive range of ids * **valuesKey** audit entry values contains the exact matching key * **valuesValue** audit entry values contains the exact matching value  The default sort order is **createdAt** ascending, but you can use an optional **ASC** or **DESC** modifier to specify an ascending or descending sort order.  For example, specifying &#x60;&#x60;&#x60;orderBy&#x3D;createdAt DESC&#x60;&#x60;&#x60; returns audit entries in descending **createdAt** order.  You must have admin rights to retrieve audit information. 
        /// </summary>
        /// <param name="auditApplicationId">The identifier of an audit application.</param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="where">Optionally filter the list. Here are some examples:  *   &#x60;&#x60;&#x60;where&#x3D;(createdByUser&#x3D;&#39;jbloggs&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(id BETWEEN (&#39;1234&#39;, &#39;4321&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(createdAt BETWEEN (&#39;2017-06-02T12:13:51.593+01:00&#39; , &#39;2017-06-04T10:05:16.536+01:00&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(createdByUser&#x3D;&#39;jbloggs&#39; and createdAt BETWEEN (&#39;2017-06-02T12:13:51.593+01:00&#39; , &#39;2017-06-04T10:05:16.536+01:00&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(valuesKey&#x3D;&#39;/alfresco-access/login/user&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(valuesKey&#x3D;&#39;/alfresco-access/transaction/action&#39; and valuesValue&#x3D;&#39;DELETE&#39;)&#x60;&#x60;&#x60; </param>
        /// <param name="include">Returns additional information about the audit entry. The following optional fields can be requested: * values </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>AuditEntryPaging</returns>
        AuditEntryPaging ListAuditEntriesForAuditApp (string auditApplicationId, int? skipCount, List<string> orderBy, int? maxItems, string where, List<string> include, List<string> fields);
        /// <summary>
        /// List audit entries for a node **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Gets a list of audit entries for node **nodeId**.  The list can be filtered by **createdByUser** and for a given inclusive time period.  The default sort order is **createdAt** ascending, but you can use an optional **ASC** or **DESC** modifier to specify an ascending or descending sort order.  For example, specifying &#x60;&#x60;&#x60;orderBy&#x3D;createdAt DESC&#x60;&#x60;&#x60; returns audit entries in descending **createdAt** order.  This relies on the pre-configured &#39;alfresco-access&#39; audit application. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="where">Optionally filter the list. Here are some examples:  *   &#x60;&#x60;&#x60;where&#x3D;(createdByUser&#x3D;&#39;-me-&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(createdAt BETWEEN (&#39;2017-06-02T12:13:51.593+01:00&#39; , &#39;2017-06-04T10:05:16.536+01:00&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(createdByUser&#x3D;&#39;jbloggs&#39; and createdAt BETWEEN (&#39;2017-06-02T12:13:51.593+01:00&#39; , &#39;2017-06-04T10:05:16.536+01:00&#39;)&#x60;&#x60;&#x60; </param>
        /// <param name="include">Returns additional information about the audit entry. The following optional fields can be requested: * values </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>AuditEntryPaging</returns>
        AuditEntryPaging ListAuditEntriesForNode (string nodeId, int? skipCount, List<string> orderBy, int? maxItems, string where, List<string> include, List<string> fields);
        /// <summary>
        /// Update audit application info **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Disable or re-enable the audit application **auditApplicationId**.  New audit entries will not be created for a disabled audit application until it is re-enabled (and system-wide auditing is also enabled).  Note, it is still possible to query &amp;/or delete any existing audit entries even if auditing is disabled for the audit application.  You must have admin rights to update audit application. 
        /// </summary>
        /// <param name="auditApplicationId">The identifier of an audit application.</param>
        /// <param name="auditAppBodyUpdate">The audit application to update.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>AuditApp</returns>
        AuditApp UpdateAuditApp (string auditApplicationId, AuditBodyUpdate auditAppBodyUpdate, List<string> fields);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AuditApi : IAuditApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public AuditApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuditApi(String basePath)
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
        /// Permanently delete audit entries for an audit application **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Permanently delete audit entries for an audit application **auditApplicationId**.  The **where** clause must be specified, either with an inclusive time period or for an inclusive range of ids. The delete is within the context of the given audit application.  For example:  *   &#x60;&#x60;&#x60;where&#x3D;(createdAt BETWEEN (&#39;2017-06-02T12:13:51.593+01:00&#39; , &#39;2017-06-04T10:05:16.536+01:00&#39;)&#x60;&#x60;&#x60; *   &#x60;&#x60;&#x60;where&#x3D;(id BETWEEN (&#39;1234&#39;, &#39;4321&#39;)&#x60;&#x60;&#x60;  You must have admin rights to delete audit information. 
        /// </summary>
        /// <param name="auditApplicationId">The identifier of an audit application.</param> 
        /// <param name="where">Audit entries to permanently delete for an audit application, given an inclusive time period or range of ids. For example:  *   &#x60;&#x60;&#x60;where&#x3D;(createdAt BETWEEN (&#39;2017-06-02T12:13:51.593+01:00&#39; , &#39;2017-06-04T10:05:16.536+01:00&#39;)&#x60;&#x60;&#x60; *   &#x60;&#x60;&#x60;where&#x3D;(id BETWEEN (&#39;1234&#39;, &#39;4321&#39;)&#x60;&#x60;&#x60; </param> 
        /// <returns></returns>            
        public void DeleteAuditEntriesForAuditApp (string auditApplicationId, string where)
        {
            
            // verify the required parameter 'auditApplicationId' is set
            if (auditApplicationId == null) throw new ApiException(400, "Missing required parameter 'auditApplicationId' when calling DeleteAuditEntriesForAuditApp");
            
            // verify the required parameter 'where' is set
            if (where == null) throw new ApiException(400, "Missing required parameter 'where' when calling DeleteAuditEntriesForAuditApp");
            
    
            var path = "/audit-applications/{auditApplicationId}/audit-entries";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "auditApplicationId" + "}", ApiClient.ParameterToString(auditApplicationId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (where != null) queryParams.Add("where", ApiClient.ParameterToString(where)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteAuditEntriesForAuditApp: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteAuditEntriesForAuditApp: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Permanently delete an audit entry **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Permanently delete a single audit entry **auditEntryId**.  You must have admin rights to delete audit information. 
        /// </summary>
        /// <param name="auditApplicationId">The identifier of an audit application.</param> 
        /// <param name="auditEntryId">The identifier of an audit entry.</param> 
        /// <returns></returns>            
        public void DeleteAuditEntry (string auditApplicationId, string auditEntryId)
        {
            
            // verify the required parameter 'auditApplicationId' is set
            if (auditApplicationId == null) throw new ApiException(400, "Missing required parameter 'auditApplicationId' when calling DeleteAuditEntry");
            
            // verify the required parameter 'auditEntryId' is set
            if (auditEntryId == null) throw new ApiException(400, "Missing required parameter 'auditEntryId' when calling DeleteAuditEntry");
            
    
            var path = "/audit-applications/{auditApplicationId}/audit-entries/{auditEntryId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "auditApplicationId" + "}", ApiClient.ParameterToString(auditApplicationId));
path = path.Replace("{" + "auditEntryId" + "}", ApiClient.ParameterToString(auditEntryId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteAuditEntry: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteAuditEntry: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get audit application info **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Get status of an audit application **auditApplicationId**.  You must have admin rights to retrieve audit information. 
        /// </summary>
        /// <param name="auditApplicationId">The identifier of an audit application.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>AuditApp</returns>            
        public AuditApp GetAuditApp (string auditApplicationId, List<string> fields)
        {
            
            // verify the required parameter 'auditApplicationId' is set
            if (auditApplicationId == null) throw new ApiException(400, "Missing required parameter 'auditApplicationId' when calling GetAuditApp");
            
    
            var path = "/audit-applications/{auditApplicationId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "auditApplicationId" + "}", ApiClient.ParameterToString(auditApplicationId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetAuditApp: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAuditApp: " + response.ErrorMessage, response.ErrorMessage);
    
            return (AuditApp) ApiClient.Deserialize(response.Content, typeof(AuditApp), response.Headers);
        }
    
        /// <summary>
        /// Get audit entry **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Gets audit entry **auditEntryId**.  You must have admin rights to access audit information. 
        /// </summary>
        /// <param name="auditApplicationId">The identifier of an audit application.</param> 
        /// <param name="auditEntryId">The identifier of an audit entry.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>AuditEntryEntry</returns>            
        public AuditEntryEntry GetAuditEntry (string auditApplicationId, string auditEntryId, List<string> fields)
        {
            
            // verify the required parameter 'auditApplicationId' is set
            if (auditApplicationId == null) throw new ApiException(400, "Missing required parameter 'auditApplicationId' when calling GetAuditEntry");
            
            // verify the required parameter 'auditEntryId' is set
            if (auditEntryId == null) throw new ApiException(400, "Missing required parameter 'auditEntryId' when calling GetAuditEntry");
            
    
            var path = "/audit-applications/{auditApplicationId}/audit-entries/{auditEntryId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "auditApplicationId" + "}", ApiClient.ParameterToString(auditApplicationId));
path = path.Replace("{" + "auditEntryId" + "}", ApiClient.ParameterToString(auditEntryId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetAuditEntry: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAuditEntry: " + response.ErrorMessage, response.ErrorMessage);
    
            return (AuditEntryEntry) ApiClient.Deserialize(response.Content, typeof(AuditEntryEntry), response.Headers);
        }
    
        /// <summary>
        /// List audit applications **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Gets a list of audit applications in this repository.  This list may include pre-configured audit applications, if enabled, such as:  * alfresco-access * CMISChangeLog * Alfresco Tagging Service * Alfresco Sync Service (used by Enterprise Cloud Sync)  You must have admin rights to retrieve audit information. 
        /// </summary>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>AuditAppPaging</returns>            
        public AuditAppPaging ListAuditApps (int? skipCount, int? maxItems, List<string> fields)
        {
            
    
            var path = "/audit-applications";
            path = path.Replace("{format}", "json");
                
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
                throw new ApiException ((int)response.StatusCode, "Error calling ListAuditApps: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListAuditApps: " + response.ErrorMessage, response.ErrorMessage);
    
            return (AuditAppPaging) ApiClient.Deserialize(response.Content, typeof(AuditAppPaging), response.Headers);
        }
    
        /// <summary>
        /// List audit entries for an audit application **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Gets a list of audit entries for audit application **auditApplicationId**.  You can use the **include** parameter to return additional **values** information.  The list can be filtered by one or more of: * **createdByUser** person id * **createdAt** inclusive time period * **id** inclusive range of ids * **valuesKey** audit entry values contains the exact matching key * **valuesValue** audit entry values contains the exact matching value  The default sort order is **createdAt** ascending, but you can use an optional **ASC** or **DESC** modifier to specify an ascending or descending sort order.  For example, specifying &#x60;&#x60;&#x60;orderBy&#x3D;createdAt DESC&#x60;&#x60;&#x60; returns audit entries in descending **createdAt** order.  You must have admin rights to retrieve audit information. 
        /// </summary>
        /// <param name="auditApplicationId">The identifier of an audit application.</param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="where">Optionally filter the list. Here are some examples:  *   &#x60;&#x60;&#x60;where&#x3D;(createdByUser&#x3D;&#39;jbloggs&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(id BETWEEN (&#39;1234&#39;, &#39;4321&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(createdAt BETWEEN (&#39;2017-06-02T12:13:51.593+01:00&#39; , &#39;2017-06-04T10:05:16.536+01:00&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(createdByUser&#x3D;&#39;jbloggs&#39; and createdAt BETWEEN (&#39;2017-06-02T12:13:51.593+01:00&#39; , &#39;2017-06-04T10:05:16.536+01:00&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(valuesKey&#x3D;&#39;/alfresco-access/login/user&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(valuesKey&#x3D;&#39;/alfresco-access/transaction/action&#39; and valuesValue&#x3D;&#39;DELETE&#39;)&#x60;&#x60;&#x60; </param> 
        /// <param name="include">Returns additional information about the audit entry. The following optional fields can be requested: * values </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>AuditEntryPaging</returns>            
        public AuditEntryPaging ListAuditEntriesForAuditApp (string auditApplicationId, int? skipCount, List<string> orderBy, int? maxItems, string where, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'auditApplicationId' is set
            if (auditApplicationId == null) throw new ApiException(400, "Missing required parameter 'auditApplicationId' when calling ListAuditEntriesForAuditApp");
            
    
            var path = "/audit-applications/{auditApplicationId}/audit-entries";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "auditApplicationId" + "}", ApiClient.ParameterToString(auditApplicationId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (skipCount != null) queryParams.Add("skipCount", ApiClient.ParameterToString(skipCount)); // query parameter
 if (orderBy != null) queryParams.Add("orderBy", ApiClient.ParameterToString(orderBy)); // query parameter
 if (maxItems != null) queryParams.Add("maxItems", ApiClient.ParameterToString(maxItems)); // query parameter
 if (where != null) queryParams.Add("where", ApiClient.ParameterToString(where)); // query parameter
 if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListAuditEntriesForAuditApp: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListAuditEntriesForAuditApp: " + response.ErrorMessage, response.ErrorMessage);
    
            return (AuditEntryPaging) ApiClient.Deserialize(response.Content, typeof(AuditEntryPaging), response.Headers);
        }
    
        /// <summary>
        /// List audit entries for a node **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Gets a list of audit entries for node **nodeId**.  The list can be filtered by **createdByUser** and for a given inclusive time period.  The default sort order is **createdAt** ascending, but you can use an optional **ASC** or **DESC** modifier to specify an ascending or descending sort order.  For example, specifying &#x60;&#x60;&#x60;orderBy&#x3D;createdAt DESC&#x60;&#x60;&#x60; returns audit entries in descending **createdAt** order.  This relies on the pre-configured &#39;alfresco-access&#39; audit application. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="where">Optionally filter the list. Here are some examples:  *   &#x60;&#x60;&#x60;where&#x3D;(createdByUser&#x3D;&#39;-me-&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(createdAt BETWEEN (&#39;2017-06-02T12:13:51.593+01:00&#39; , &#39;2017-06-04T10:05:16.536+01:00&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(createdByUser&#x3D;&#39;jbloggs&#39; and createdAt BETWEEN (&#39;2017-06-02T12:13:51.593+01:00&#39; , &#39;2017-06-04T10:05:16.536+01:00&#39;)&#x60;&#x60;&#x60; </param> 
        /// <param name="include">Returns additional information about the audit entry. The following optional fields can be requested: * values </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>AuditEntryPaging</returns>            
        public AuditEntryPaging ListAuditEntriesForNode (string nodeId, int? skipCount, List<string> orderBy, int? maxItems, string where, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling ListAuditEntriesForNode");
            
    
            var path = "/nodes/{nodeId}/audit-entries";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (skipCount != null) queryParams.Add("skipCount", ApiClient.ParameterToString(skipCount)); // query parameter
 if (orderBy != null) queryParams.Add("orderBy", ApiClient.ParameterToString(orderBy)); // query parameter
 if (maxItems != null) queryParams.Add("maxItems", ApiClient.ParameterToString(maxItems)); // query parameter
 if (where != null) queryParams.Add("where", ApiClient.ParameterToString(where)); // query parameter
 if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListAuditEntriesForNode: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListAuditEntriesForNode: " + response.ErrorMessage, response.ErrorMessage);
    
            return (AuditEntryPaging) ApiClient.Deserialize(response.Content, typeof(AuditEntryPaging), response.Headers);
        }
    
        /// <summary>
        /// Update audit application info **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Disable or re-enable the audit application **auditApplicationId**.  New audit entries will not be created for a disabled audit application until it is re-enabled (and system-wide auditing is also enabled).  Note, it is still possible to query &amp;/or delete any existing audit entries even if auditing is disabled for the audit application.  You must have admin rights to update audit application. 
        /// </summary>
        /// <param name="auditApplicationId">The identifier of an audit application.</param> 
        /// <param name="auditAppBodyUpdate">The audit application to update.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>AuditApp</returns>            
        public AuditApp UpdateAuditApp (string auditApplicationId, AuditBodyUpdate auditAppBodyUpdate, List<string> fields)
        {
            
            // verify the required parameter 'auditApplicationId' is set
            if (auditApplicationId == null) throw new ApiException(400, "Missing required parameter 'auditApplicationId' when calling UpdateAuditApp");
            
            // verify the required parameter 'auditAppBodyUpdate' is set
            if (auditAppBodyUpdate == null) throw new ApiException(400, "Missing required parameter 'auditAppBodyUpdate' when calling UpdateAuditApp");
            
    
            var path = "/audit-applications/{auditApplicationId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "auditApplicationId" + "}", ApiClient.ParameterToString(auditApplicationId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(auditAppBodyUpdate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateAuditApp: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateAuditApp: " + response.ErrorMessage, response.ErrorMessage);
    
            return (AuditApp) ApiClient.Deserialize(response.Content, typeof(AuditApp), response.Headers);
        }
    
    }
}
