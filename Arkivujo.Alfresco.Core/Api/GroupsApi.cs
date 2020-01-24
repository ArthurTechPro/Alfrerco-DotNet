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
    public interface IGroupsApi
    {
        /// <summary>
        /// Create a group **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Create a group.  The group id must start with \&quot;GROUP\\_\&quot;. If this is omitted it will be added automatically. This format is also returned when listing groups or group memberships. It should be noted that the other group-related operations also expect the id to start with \&quot;GROUP\\_\&quot;.  If one or more parentIds are specified then the group will be created and become a member of each of the specified parent groups.  If no parentIds are specified then the group will be created as a root group.  The group will be created in the **APP.DEFAULT** and **AUTH.ALF** zones.  You must have admin rights to create a group. 
        /// </summary>
        /// <param name="groupBodyCreate">The group to create.</param>
        /// <param name="include">Returns additional information about the group. The following optional fields can be requested: * parentIds * zones </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>GroupEntry</returns>
        GroupEntry CreateGroup (GroupBodyCreate groupBodyCreate, List<string> include, List<string> fields);
        /// <summary>
        /// Create a group membership **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Create a group membership (for an existing person or group) within a group **groupId**.  If the added group was previously a root group then it becomes a non-root group since it now has a parent.  It is an error to specify an **id** that does not exist.  You must have admin rights to create a group membership. 
        /// </summary>
        /// <param name="groupId">The identifier of a group.</param>
        /// <param name="groupMembershipBodyCreate">The group membership to add (person or sub-group).</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>GroupMemberEntry</returns>
        GroupMemberEntry CreateGroupMembership (string groupId, GroupMembershipBodyCreate groupMembershipBodyCreate, List<string> fields);
        /// <summary>
        /// Delete a group **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Delete group **groupId**.  The option to cascade delete applies this recursively to any hierarchy of group members. In this case, removing a group member does not delete the person or sub-group itself. If a removed sub-group no longer has any parent groups then it becomes a root group.  You must have admin rights to delete a group. 
        /// </summary>
        /// <param name="groupId">The identifier of a group.</param>
        /// <param name="cascade">If **true** then the delete will be applied in cascade to sub-groups. </param>
        /// <returns></returns>
        void DeleteGroup (string groupId, bool? cascade);
        /// <summary>
        /// Delete a group membership **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Delete group member **groupMemberId** (person or sub-group) from group **groupId**.  Removing a group member does not delete the person or sub-group itself.  If a removed sub-group no longer has any parent groups then it becomes a root group.  You must have admin rights to delete a group membership. 
        /// </summary>
        /// <param name="groupId">The identifier of a group.</param>
        /// <param name="groupMemberId">The identifier of a person or group.</param>
        /// <returns></returns>
        void DeleteGroupMembership (string groupId, string groupMemberId);
        /// <summary>
        /// Get group details **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Get details for group **groupId**.  You can use the **include** parameter to return additional information. 
        /// </summary>
        /// <param name="groupId">The identifier of a group.</param>
        /// <param name="include">Returns additional information about the group. The following optional fields can be requested: * parentIds * zones </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>GroupEntry</returns>
        GroupEntry GetGroup (string groupId, List<string> include, List<string> fields);
        /// <summary>
        /// List memberships of a group **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Gets a list of the group memberships for the group **groupId**.  You can use the **where** parameter to filter the returned groups by **memberType**.  Example to filter by **memberType**, use any one of:  &#x60;&#x60;&#x60; (memberType&#x3D;&#39;GROUP&#39;) (memberType&#x3D;&#39;PERSON&#39;) &#x60;&#x60;&#x60;  The default sort order for the returned list is for group members to be sorted by ascending displayName. You can override the default by using the **orderBy** parameter. You can specify one of the following fields in the **orderBy** parameter: * id * displayName 
        /// </summary>
        /// <param name="groupId">The identifier of a group.</param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param>
        /// <param name="where">A string to restrict the returned objects by using a predicate.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>GroupMemberPaging</returns>
        GroupMemberPaging ListGroupMemberships (string groupId, int? skipCount, int? maxItems, List<string> orderBy, string where, List<string> fields);
        /// <summary>
        /// List group memberships **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.   Gets a list of group membership information for person **personId**.   You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user.   You can use the **include** parameter to return additional information.   You can use the **where** parameter to filter the returned groups by **isRoot**. For example, the following **where**  clause will return just the root groups:   &#x60;&#x60;&#x60;  (isRoot&#x3D;true)  &#x60;&#x60;&#x60;   The **where** parameter can also be used to filter by ***zone***. This may be combined with isRoot to narrow  a result set even further. For example, the following where clause will only return groups belonging to the  &#x60;MY.ZONE&#x60; zone.   &#x60;&#x60;&#x60;  where&#x3D;(zones in (&#39;MY.ZONE&#39;))  &#x60;&#x60;&#x60;   This may be combined with the isRoot filter, as shown below:   &#x60;&#x60;&#x60;  where&#x3D;(isRoot&#x3D;false AND zones in (&#39;MY.ZONE&#39;))  &#x60;&#x60;&#x60;   ***Note:*** restrictions include  * &#x60;AND&#x60; is the only supported operator when combining &#x60;isRoot&#x60; and &#x60;zones&#x60; filters  * Only one zone is supported by the filter  * The quoted zone name must be placed in parenthesis — a 400 error will result if these are omitted.    The default sort order for the returned list is for groups to be sorted by ascending displayName.  You can override the default by using the **orderBy** parameter. You can specify one or more of the following fields in the **orderBy** parameter:  * id  * displayName 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param>
        /// <param name="include">Returns additional information about the group. The following optional fields can be requested: * parentIds * zones </param>
        /// <param name="where">A string to restrict the returned objects by using a predicate.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>GroupPaging</returns>
        GroupPaging ListGroupMembershipsForPerson (string personId, int? skipCount, int? maxItems, List<string> orderBy, List<string> include, string where, List<string> fields);
        /// <summary>
        /// List groups **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Gets a list of groups.  You can use the **include** parameter to return additional information.  You can use the **where** parameter to filter the returned groups by **isRoot**. For example, the following **where** clause will return just the root groups:  &#x60;&#x60;&#x60; (isRoot&#x3D;true) &#x60;&#x60;&#x60;  The **where** parameter can also be used to filter by ***zone***. This may be combined with isRoot to narrow a result set even further. For example, the following where clause will only return groups belonging to the &#x60;MY.ZONE&#x60; zone.  &#x60;&#x60;&#x60; where&#x3D;(zones in (&#39;MY.ZONE&#39;)) &#x60;&#x60;&#x60;  This may be combined with the isRoot filter, as shown below:  &#x60;&#x60;&#x60; where&#x3D;(isRoot&#x3D;false AND zones in (&#39;MY.ZONE&#39;)) &#x60;&#x60;&#x60;  ***Note:*** restrictions include * &#x60;AND&#x60; is the only supported operator when combining &#x60;isRoot&#x60; and &#x60;zones&#x60; filters * Only one zone is supported by the filter * The quoted zone name must be placed in parenthesis — a 400 error will result if these are omitted.  The default sort order for the returned list is for groups to be sorted by ascending displayName. You can override the default by using the **orderBy** parameter. You can specify one of the following fields in the **orderBy** parameter: * id * displayName 
        /// </summary>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param>
        /// <param name="include">Returns additional information about the group. The following optional fields can be requested: * parentIds * zones </param>
        /// <param name="where">A string to restrict the returned objects by using a predicate.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>GroupPaging</returns>
        GroupPaging ListGroups (int? skipCount, int? maxItems, List<string> orderBy, List<string> include, string where, List<string> fields);
        /// <summary>
        /// Update group details **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Update details (displayName) for group **groupId**.  You must have admin rights to update a group. 
        /// </summary>
        /// <param name="groupId">The identifier of a group.</param>
        /// <param name="groupBodyUpdate">The group information to update.</param>
        /// <param name="include">Returns additional information about the group. The following optional fields can be requested: * parentIds * zones </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>GroupEntry</returns>
        GroupEntry UpdateGroup (string groupId, GroupBodyUpdate groupBodyUpdate, List<string> include, List<string> fields);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class GroupsApi : IGroupsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public GroupsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GroupsApi(String basePath)
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
        /// Create a group **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Create a group.  The group id must start with \&quot;GROUP\\_\&quot;. If this is omitted it will be added automatically. This format is also returned when listing groups or group memberships. It should be noted that the other group-related operations also expect the id to start with \&quot;GROUP\\_\&quot;.  If one or more parentIds are specified then the group will be created and become a member of each of the specified parent groups.  If no parentIds are specified then the group will be created as a root group.  The group will be created in the **APP.DEFAULT** and **AUTH.ALF** zones.  You must have admin rights to create a group. 
        /// </summary>
        /// <param name="groupBodyCreate">The group to create.</param> 
        /// <param name="include">Returns additional information about the group. The following optional fields can be requested: * parentIds * zones </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>GroupEntry</returns>            
        public GroupEntry CreateGroup (GroupBodyCreate groupBodyCreate, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'groupBodyCreate' is set
            if (groupBodyCreate == null) throw new ApiException(400, "Missing required parameter 'groupBodyCreate' when calling CreateGroup");
            
    
            var path = "/groups";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(groupBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateGroup: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateGroup: " + response.ErrorMessage, response.ErrorMessage);
    
            return (GroupEntry) ApiClient.Deserialize(response.Content, typeof(GroupEntry), response.Headers);
        }
    
        /// <summary>
        /// Create a group membership **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Create a group membership (for an existing person or group) within a group **groupId**.  If the added group was previously a root group then it becomes a non-root group since it now has a parent.  It is an error to specify an **id** that does not exist.  You must have admin rights to create a group membership. 
        /// </summary>
        /// <param name="groupId">The identifier of a group.</param> 
        /// <param name="groupMembershipBodyCreate">The group membership to add (person or sub-group).</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>GroupMemberEntry</returns>            
        public GroupMemberEntry CreateGroupMembership (string groupId, GroupMembershipBodyCreate groupMembershipBodyCreate, List<string> fields)
        {
            
            // verify the required parameter 'groupId' is set
            if (groupId == null) throw new ApiException(400, "Missing required parameter 'groupId' when calling CreateGroupMembership");
            
            // verify the required parameter 'groupMembershipBodyCreate' is set
            if (groupMembershipBodyCreate == null) throw new ApiException(400, "Missing required parameter 'groupMembershipBodyCreate' when calling CreateGroupMembership");
            
    
            var path = "/groups/{groupId}/members";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "groupId" + "}", ApiClient.ParameterToString(groupId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(groupMembershipBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateGroupMembership: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateGroupMembership: " + response.ErrorMessage, response.ErrorMessage);
    
            return (GroupMemberEntry) ApiClient.Deserialize(response.Content, typeof(GroupMemberEntry), response.Headers);
        }
    
        /// <summary>
        /// Delete a group **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Delete group **groupId**.  The option to cascade delete applies this recursively to any hierarchy of group members. In this case, removing a group member does not delete the person or sub-group itself. If a removed sub-group no longer has any parent groups then it becomes a root group.  You must have admin rights to delete a group. 
        /// </summary>
        /// <param name="groupId">The identifier of a group.</param> 
        /// <param name="cascade">If **true** then the delete will be applied in cascade to sub-groups. </param> 
        /// <returns></returns>            
        public void DeleteGroup (string groupId, bool? cascade)
        {
            
            // verify the required parameter 'groupId' is set
            if (groupId == null) throw new ApiException(400, "Missing required parameter 'groupId' when calling DeleteGroup");
            
    
            var path = "/groups/{groupId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "groupId" + "}", ApiClient.ParameterToString(groupId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (cascade != null) queryParams.Add("cascade", ApiClient.ParameterToString(cascade)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteGroup: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteGroup: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Delete a group membership **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Delete group member **groupMemberId** (person or sub-group) from group **groupId**.  Removing a group member does not delete the person or sub-group itself.  If a removed sub-group no longer has any parent groups then it becomes a root group.  You must have admin rights to delete a group membership. 
        /// </summary>
        /// <param name="groupId">The identifier of a group.</param> 
        /// <param name="groupMemberId">The identifier of a person or group.</param> 
        /// <returns></returns>            
        public void DeleteGroupMembership (string groupId, string groupMemberId)
        {
            
            // verify the required parameter 'groupId' is set
            if (groupId == null) throw new ApiException(400, "Missing required parameter 'groupId' when calling DeleteGroupMembership");
            
            // verify the required parameter 'groupMemberId' is set
            if (groupMemberId == null) throw new ApiException(400, "Missing required parameter 'groupMemberId' when calling DeleteGroupMembership");
            
    
            var path = "/groups/{groupId}/members/{groupMemberId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "groupId" + "}", ApiClient.ParameterToString(groupId));
path = path.Replace("{" + "groupMemberId" + "}", ApiClient.ParameterToString(groupMemberId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteGroupMembership: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteGroupMembership: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get group details **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Get details for group **groupId**.  You can use the **include** parameter to return additional information. 
        /// </summary>
        /// <param name="groupId">The identifier of a group.</param> 
        /// <param name="include">Returns additional information about the group. The following optional fields can be requested: * parentIds * zones </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>GroupEntry</returns>            
        public GroupEntry GetGroup (string groupId, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'groupId' is set
            if (groupId == null) throw new ApiException(400, "Missing required parameter 'groupId' when calling GetGroup");
            
    
            var path = "/groups/{groupId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "groupId" + "}", ApiClient.ParameterToString(groupId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetGroup: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetGroup: " + response.ErrorMessage, response.ErrorMessage);
    
            return (GroupEntry) ApiClient.Deserialize(response.Content, typeof(GroupEntry), response.Headers);
        }
    
        /// <summary>
        /// List memberships of a group **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Gets a list of the group memberships for the group **groupId**.  You can use the **where** parameter to filter the returned groups by **memberType**.  Example to filter by **memberType**, use any one of:  &#x60;&#x60;&#x60; (memberType&#x3D;&#39;GROUP&#39;) (memberType&#x3D;&#39;PERSON&#39;) &#x60;&#x60;&#x60;  The default sort order for the returned list is for group members to be sorted by ascending displayName. You can override the default by using the **orderBy** parameter. You can specify one of the following fields in the **orderBy** parameter: * id * displayName 
        /// </summary>
        /// <param name="groupId">The identifier of a group.</param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param> 
        /// <param name="where">A string to restrict the returned objects by using a predicate.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>GroupMemberPaging</returns>            
        public GroupMemberPaging ListGroupMemberships (string groupId, int? skipCount, int? maxItems, List<string> orderBy, string where, List<string> fields)
        {
            
            // verify the required parameter 'groupId' is set
            if (groupId == null) throw new ApiException(400, "Missing required parameter 'groupId' when calling ListGroupMemberships");
            
    
            var path = "/groups/{groupId}/members";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "groupId" + "}", ApiClient.ParameterToString(groupId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (skipCount != null) queryParams.Add("skipCount", ApiClient.ParameterToString(skipCount)); // query parameter
 if (maxItems != null) queryParams.Add("maxItems", ApiClient.ParameterToString(maxItems)); // query parameter
 if (orderBy != null) queryParams.Add("orderBy", ApiClient.ParameterToString(orderBy)); // query parameter
 if (where != null) queryParams.Add("where", ApiClient.ParameterToString(where)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListGroupMemberships: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListGroupMemberships: " + response.ErrorMessage, response.ErrorMessage);
    
            return (GroupMemberPaging) ApiClient.Deserialize(response.Content, typeof(GroupMemberPaging), response.Headers);
        }
    
        /// <summary>
        /// List group memberships **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.   Gets a list of group membership information for person **personId**.   You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user.   You can use the **include** parameter to return additional information.   You can use the **where** parameter to filter the returned groups by **isRoot**. For example, the following **where**  clause will return just the root groups:   &#x60;&#x60;&#x60;  (isRoot&#x3D;true)  &#x60;&#x60;&#x60;   The **where** parameter can also be used to filter by ***zone***. This may be combined with isRoot to narrow  a result set even further. For example, the following where clause will only return groups belonging to the  &#x60;MY.ZONE&#x60; zone.   &#x60;&#x60;&#x60;  where&#x3D;(zones in (&#39;MY.ZONE&#39;))  &#x60;&#x60;&#x60;   This may be combined with the isRoot filter, as shown below:   &#x60;&#x60;&#x60;  where&#x3D;(isRoot&#x3D;false AND zones in (&#39;MY.ZONE&#39;))  &#x60;&#x60;&#x60;   ***Note:*** restrictions include  * &#x60;AND&#x60; is the only supported operator when combining &#x60;isRoot&#x60; and &#x60;zones&#x60; filters  * Only one zone is supported by the filter  * The quoted zone name must be placed in parenthesis — a 400 error will result if these are omitted.    The default sort order for the returned list is for groups to be sorted by ascending displayName.  You can override the default by using the **orderBy** parameter. You can specify one or more of the following fields in the **orderBy** parameter:  * id  * displayName 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param> 
        /// <param name="include">Returns additional information about the group. The following optional fields can be requested: * parentIds * zones </param> 
        /// <param name="where">A string to restrict the returned objects by using a predicate.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>GroupPaging</returns>            
        public GroupPaging ListGroupMembershipsForPerson (string personId, int? skipCount, int? maxItems, List<string> orderBy, List<string> include, string where, List<string> fields)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling ListGroupMembershipsForPerson");
            
    
            var path = "/people/{personId}/groups";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (skipCount != null) queryParams.Add("skipCount", ApiClient.ParameterToString(skipCount)); // query parameter
 if (maxItems != null) queryParams.Add("maxItems", ApiClient.ParameterToString(maxItems)); // query parameter
 if (orderBy != null) queryParams.Add("orderBy", ApiClient.ParameterToString(orderBy)); // query parameter
 if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (where != null) queryParams.Add("where", ApiClient.ParameterToString(where)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListGroupMembershipsForPerson: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListGroupMembershipsForPerson: " + response.ErrorMessage, response.ErrorMessage);
    
            return (GroupPaging) ApiClient.Deserialize(response.Content, typeof(GroupPaging), response.Headers);
        }
    
        /// <summary>
        /// List groups **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Gets a list of groups.  You can use the **include** parameter to return additional information.  You can use the **where** parameter to filter the returned groups by **isRoot**. For example, the following **where** clause will return just the root groups:  &#x60;&#x60;&#x60; (isRoot&#x3D;true) &#x60;&#x60;&#x60;  The **where** parameter can also be used to filter by ***zone***. This may be combined with isRoot to narrow a result set even further. For example, the following where clause will only return groups belonging to the &#x60;MY.ZONE&#x60; zone.  &#x60;&#x60;&#x60; where&#x3D;(zones in (&#39;MY.ZONE&#39;)) &#x60;&#x60;&#x60;  This may be combined with the isRoot filter, as shown below:  &#x60;&#x60;&#x60; where&#x3D;(isRoot&#x3D;false AND zones in (&#39;MY.ZONE&#39;)) &#x60;&#x60;&#x60;  ***Note:*** restrictions include * &#x60;AND&#x60; is the only supported operator when combining &#x60;isRoot&#x60; and &#x60;zones&#x60; filters * Only one zone is supported by the filter * The quoted zone name must be placed in parenthesis — a 400 error will result if these are omitted.  The default sort order for the returned list is for groups to be sorted by ascending displayName. You can override the default by using the **orderBy** parameter. You can specify one of the following fields in the **orderBy** parameter: * id * displayName 
        /// </summary>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param> 
        /// <param name="include">Returns additional information about the group. The following optional fields can be requested: * parentIds * zones </param> 
        /// <param name="where">A string to restrict the returned objects by using a predicate.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>GroupPaging</returns>            
        public GroupPaging ListGroups (int? skipCount, int? maxItems, List<string> orderBy, List<string> include, string where, List<string> fields)
        {
            
    
            var path = "/groups";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (skipCount != null) queryParams.Add("skipCount", ApiClient.ParameterToString(skipCount)); // query parameter
 if (maxItems != null) queryParams.Add("maxItems", ApiClient.ParameterToString(maxItems)); // query parameter
 if (orderBy != null) queryParams.Add("orderBy", ApiClient.ParameterToString(orderBy)); // query parameter
 if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (where != null) queryParams.Add("where", ApiClient.ParameterToString(where)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListGroups: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListGroups: " + response.ErrorMessage, response.ErrorMessage);
    
            return (GroupPaging) ApiClient.Deserialize(response.Content, typeof(GroupPaging), response.Headers);
        }
    
        /// <summary>
        /// Update group details **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Update details (displayName) for group **groupId**.  You must have admin rights to update a group. 
        /// </summary>
        /// <param name="groupId">The identifier of a group.</param> 
        /// <param name="groupBodyUpdate">The group information to update.</param> 
        /// <param name="include">Returns additional information about the group. The following optional fields can be requested: * parentIds * zones </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>GroupEntry</returns>            
        public GroupEntry UpdateGroup (string groupId, GroupBodyUpdate groupBodyUpdate, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'groupId' is set
            if (groupId == null) throw new ApiException(400, "Missing required parameter 'groupId' when calling UpdateGroup");
            
            // verify the required parameter 'groupBodyUpdate' is set
            if (groupBodyUpdate == null) throw new ApiException(400, "Missing required parameter 'groupBodyUpdate' when calling UpdateGroup");
            
    
            var path = "/groups/{groupId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "groupId" + "}", ApiClient.ParameterToString(groupId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(groupBodyUpdate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateGroup: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateGroup: " + response.ErrorMessage, response.ErrorMessage);
    
            return (GroupEntry) ApiClient.Deserialize(response.Content, typeof(GroupEntry), response.Headers);
        }
    
    }
}
