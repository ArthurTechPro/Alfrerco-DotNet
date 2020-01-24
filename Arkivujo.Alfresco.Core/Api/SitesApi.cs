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
    public interface ISitesApi
    {
        /// <summary>
        /// Approve a site membership request Approve a site membership request. 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param>
        /// <param name="inviteeId">The invitee user name.</param>
        /// <param name="siteMembershipApprovalBody">Accepting a request to join, optionally, allows assignment of a role to the user. </param>
        /// <returns></returns>
        void ApproveSiteMembershipRequest (string siteId, string inviteeId, SiteMembershipApprovalBody siteMembershipApprovalBody);
        /// <summary>
        /// Create a site **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Creates a default site with the given details.  Unless explicitly specified, the site id will be generated from the site title. The site id must be unique and only contain alphanumeric and/or dash characters.  Note: the id of a site cannot be updated once the site has been created.  For example, to create a public site called \&quot;Marketing\&quot; the following body could be used: &#x60;&#x60;&#x60;JSON {   \&quot;title\&quot;: \&quot;Marketing\&quot;,   \&quot;visibility\&quot;: \&quot;PUBLIC\&quot; } &#x60;&#x60;&#x60;  The creation of the (surf) configuration files required by Share can be skipped via the **skipConfiguration** query parameter.  **Note:** if skipped then such a site will **not** work within Share.  The addition of the site to the user&#39;s site favorites can be skipped via the **skipAddToFavorites** query parameter.  The creator will be added as a member with Site Manager role.  When you create a site, a container called **documentLibrary** is created for you in the new site. This container is the root folder for content stored in the site. 
        /// </summary>
        /// <param name="siteBodyCreate">The site details</param>
        /// <param name="skipConfiguration">Flag to indicate whether the Share-specific (surf) configuration files for the site should not be created.</param>
        /// <param name="skipAddToFavorites">Flag to indicate whether the site should not be added to the user&#39;s site favorites.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SiteEntry</returns>
        SiteEntry CreateSite (SiteBodyCreate siteBodyCreate, bool? skipConfiguration, bool? skipAddToFavorites, List<string> fields);
        /// <summary>
        /// Create a site membership Creates a site membership for person **personId** on site **siteId**.  You can set the **role** to one of four types:  * SiteConsumer * SiteCollaborator * SiteContributor * SiteManager  **Note:** You can create more than one site membership by specifying a list of people in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {     \&quot;role\&quot;: \&quot;SiteConsumer\&quot;,     \&quot;id\&quot;: \&quot;joe\&quot;   },   {     \&quot;role\&quot;: \&quot;SiteConsumer\&quot;,     \&quot;id\&quot;: \&quot;fred\&quot;   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param>
        /// <param name="siteMembershipBodyCreate">The person to add and their role</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SiteMemberEntry</returns>
        SiteMemberEntry CreateSiteMembership (string siteId, SiteMembershipBodyCreate siteMembershipBodyCreate, List<string> fields);
        /// <summary>
        /// Create a site membership request Create a site membership request for yourself on the site with the identifier of **id**, specified in the JSON body. The result of the request differs depending on the type of site.  * For a **public** site, you join the site immediately as a SiteConsumer. * For a **moderated** site, your request is added to the site membership request list. The request waits for approval from the Site Manager. * You cannot request membership of a **private** site. Members are invited by the site administrator.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user.   **Note:** You can create site membership requests for more than one site by specifying a list of sites in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {     \&quot;message\&quot;: \&quot;Please can you add me\&quot;,     \&quot;id\&quot;: \&quot;test-site-1\&quot;,     \&quot;title\&quot;: \&quot;Request for test site 1\&quot;,   },   {     \&quot;message\&quot;: \&quot;Please can you add me\&quot;,     \&quot;id\&quot;: \&quot;test-site-2\&quot;,     \&quot;title\&quot;: \&quot;Request for test site 2\&quot;,   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="siteMembershipRequestBodyCreate">Site membership request details</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SiteMembershipRequestEntry</returns>
        SiteMembershipRequestEntry CreateSiteMembershipRequestForPerson (string personId, SiteMembershipRequestBodyCreate siteMembershipRequestBodyCreate, List<string> fields);
        /// <summary>
        /// Delete a site **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Deletes the site with **siteId**. 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param>
        /// <param name="permanent">Flag to indicate whether the site should be permanently deleted i.e. bypass the trashcan.</param>
        /// <returns></returns>
        void DeleteSite (string siteId, bool? permanent);
        /// <summary>
        /// Delete a site membership Deletes person **personId** as a member of site **siteId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param>
        /// <param name="personId">The identifier of a person.</param>
        /// <returns></returns>
        void DeleteSiteMembership (string siteId, string personId);
        /// <summary>
        /// Delete a site membership Deletes person **personId** as a member of site **siteId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="siteId">The identifier of a site.</param>
        /// <returns></returns>
        void DeleteSiteMembershipForPerson (string personId, string siteId);
        /// <summary>
        /// Delete a site membership request Deletes the site membership request to site **siteId** for person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="siteId">The identifier of a site.</param>
        /// <returns></returns>
        void DeleteSiteMembershipRequestForPerson (string personId, string siteId);
        /// <summary>
        /// Get a site Gets information for site **siteId**.  You can use the **relations** parameter to include one or more related entities in a single response and so reduce network traffic.  The entity types in Alfresco are organized in a tree structure. The **sites** entity has two children, **containers** and **members**. The following relations parameter returns all the container and member objects related to the site **siteId**:  &#x60;&#x60;&#x60; containers,members &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param>
        /// <param name="relations">Use the relations parameter to include one or more related entities in a single response.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SiteEntry</returns>
        SiteEntry GetSite (string siteId, List<string> relations, List<string> fields);
        /// <summary>
        /// Get a site container Gets information on the container **containerId** in site **siteId**.
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param>
        /// <param name="containerId">The unique identifier of a site container.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SiteContainerEntry</returns>
        SiteContainerEntry GetSiteContainer (string siteId, string containerId, List<string> fields);
        /// <summary>
        /// Get a site membership Gets site membership information for person **personId** on site **siteId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SiteMemberEntry</returns>
        SiteMemberEntry GetSiteMembership (string siteId, string personId, List<string> fields);
        /// <summary>
        /// Get a site membership Gets site membership information for person **personId** on site **siteId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="siteId">The identifier of a site.</param>
        /// <returns>SiteRoleEntry</returns>
        SiteRoleEntry GetSiteMembershipForPerson (string personId, string siteId);
        /// <summary>
        /// Get a site membership request Gets the site membership request for site **siteId** for person **personId**, if one exists.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="siteId">The identifier of a site.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SiteMembershipRequestEntry</returns>
        SiteMembershipRequestEntry GetSiteMembershipRequestForPerson (string personId, string siteId, List<string> fields);
        /// <summary>
        /// Get site membership requests Get the list of site membership requests the user can action.  You can use the **where** parameter to filter the returned site membership requests by **siteId**. For example:  &#x60;&#x60;&#x60; (siteId&#x3D;mySite) &#x60;&#x60;&#x60;  The **where** parameter can also be used to filter by ***personId***. For example:  &#x60;&#x60;&#x60; where&#x3D;(personId&#x3D;person) &#x60;&#x60;&#x60;  This may be combined with the siteId filter, as shown below:  &#x60;&#x60;&#x60; where&#x3D;(siteId&#x3D;mySite AND personId&#x3D;person)) &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="where">A string to restrict the returned objects by using a predicate.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SiteMembershipRequestWithPersonPaging</returns>
        SiteMembershipRequestWithPersonPaging GetSiteMembershipRequests (int? skipCount, int? maxItems, string where, List<string> fields);
        /// <summary>
        /// List site containers Gets a list of containers for the site **siteId**.
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SiteContainerPaging</returns>
        SiteContainerPaging ListSiteContainers (string siteId, int? skipCount, int? maxItems, List<string> fields);
        /// <summary>
        /// List site membership requests Gets a list of the current site membership requests for person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SiteMembershipRequestPaging</returns>
        SiteMembershipRequestPaging ListSiteMembershipRequestsForPerson (string personId, int? skipCount, int? maxItems, List<string> fields);
        /// <summary>
        /// List site memberships Gets a list of site memberships for site **siteId**.
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SiteMemberPaging</returns>
        SiteMemberPaging ListSiteMemberships (string siteId, int? skipCount, int? maxItems, List<string> fields);
        /// <summary>
        /// List site memberships Gets a list of site membership information for person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user.  You can use the **where** parameter to filter the returned sites by **visibility** or site **preset**.  Example to filter by **visibility**, use any one of:  &#x60;&#x60;&#x60; (visibility&#x3D;&#39;PRIVATE&#39;) (visibility&#x3D;&#39;PUBLIC&#39;) (visibility&#x3D;&#39;MODERATED&#39;) &#x60;&#x60;&#x60;  Example to filter by site **preset**:  &#x60;&#x60;&#x60; (preset&#x3D;&#39;site-dashboard&#39;) &#x60;&#x60;&#x60;  The default sort order for the returned list is for sites to be sorted by ascending title. You can override the default by using the **orderBy** parameter. You can specify one or more of the following fields in the **orderBy** parameter: * id * title * role 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param>
        /// <param name="relations">Use the relations parameter to include one or more related entities in a single response.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <param name="where">A string to restrict the returned objects by using a predicate.</param>
        /// <returns>SiteRolePaging</returns>
        SiteRolePaging ListSiteMembershipsForPerson (string personId, int? skipCount, int? maxItems, List<string> orderBy, List<string> relations, List<string> fields, string where);
        /// <summary>
        /// List sites Gets a list of sites in this repository.  You can use the **where** parameter to filter the returned sites by **visibility** or site **preset**.  Example to filter by **visibility**, use any one of:  &#x60;&#x60;&#x60; (visibility&#x3D;&#39;PRIVATE&#39;) (visibility&#x3D;&#39;PUBLIC&#39;) (visibility&#x3D;&#39;MODERATED&#39;) &#x60;&#x60;&#x60;  Example to filter by site **preset**:  &#x60;&#x60;&#x60; (preset&#x3D;&#39;site-dashboard&#39;) &#x60;&#x60;&#x60;  The default sort order for the returned list is for sites to be sorted by ascending title. You can override the default by using the **orderBy** parameter. You can specify one or more of the following fields in the **orderBy** parameter: * id * title * description  You can use the **relations** parameter to include one or more related entities in a single response and so reduce network traffic.  The entity types in Alfresco are organized in a tree structure. The **sites** entity has two children, **containers** and **members**. The following relations parameter returns all the container and member objects related to each site:  &#x60;&#x60;&#x60; containers,members &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param>
        /// <param name="relations">Use the relations parameter to include one or more related entities in a single response.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <param name="where">A string to restrict the returned objects by using a predicate.</param>
        /// <returns>SitePaging</returns>
        SitePaging ListSites (int? skipCount, int? maxItems, List<string> orderBy, List<string> relations, List<string> fields, string where);
        /// <summary>
        /// Reject a site membership request Reject a site membership request. 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param>
        /// <param name="inviteeId">The invitee user name.</param>
        /// <param name="siteMembershipRejectionBody">Rejecting a request to join, optionally, allows the inclusion of comment. </param>
        /// <returns></returns>
        void RejectSiteMembershipRequest (string siteId, string inviteeId, SiteMembershipRejectionBody siteMembershipRejectionBody);
        /// <summary>
        /// Update a site **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Update the details for the given site **siteId**. Site Manager or otherwise a (site) admin can update title, description or visibility.  Note: the id of a site cannot be updated once the site has been created. 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param>
        /// <param name="siteBodyUpdate">The site information to update.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SiteEntry</returns>
        SiteEntry UpdateSite (string siteId, SiteBodyUpdate siteBodyUpdate, List<string> fields);
        /// <summary>
        /// Update a site membership Update the membership of person **personId** in site **siteId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user.  You can set the **role** to one of four types:  * SiteConsumer * SiteCollaborator * SiteContributor * SiteManager 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="siteMembershipBodyUpdate">The persons new role</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SiteMemberEntry</returns>
        SiteMemberEntry UpdateSiteMembership (string siteId, string personId, SiteMembershipBodyUpdate siteMembershipBodyUpdate, List<string> fields);
        /// <summary>
        /// Update a site membership request Updates the message for the site membership request to site **siteId** for person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="siteId">The identifier of a site.</param>
        /// <param name="siteMembershipRequestBodyUpdate">The new message to display</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>SiteMembershipRequestEntry</returns>
        SiteMembershipRequestEntry UpdateSiteMembershipRequestForPerson (string personId, string siteId, SiteMembershipRequestBodyUpdate siteMembershipRequestBodyUpdate, List<string> fields);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class SitesApi : ISitesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SitesApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public SitesApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="SitesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SitesApi(String basePath)
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
        /// Approve a site membership request Approve a site membership request. 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param> 
        /// <param name="inviteeId">The invitee user name.</param> 
        /// <param name="siteMembershipApprovalBody">Accepting a request to join, optionally, allows assignment of a role to the user. </param> 
        /// <returns></returns>            
        public void ApproveSiteMembershipRequest (string siteId, string inviteeId, SiteMembershipApprovalBody siteMembershipApprovalBody)
        {
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling ApproveSiteMembershipRequest");
            
            // verify the required parameter 'inviteeId' is set
            if (inviteeId == null) throw new ApiException(400, "Missing required parameter 'inviteeId' when calling ApproveSiteMembershipRequest");
            
    
            var path = "/sites/{siteId}/site-membership-requests/{inviteeId}/approve";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "siteId" + "}", ApiClient.ParameterToString(siteId));
path = path.Replace("{" + "inviteeId" + "}", ApiClient.ParameterToString(inviteeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(siteMembershipApprovalBody); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ApproveSiteMembershipRequest: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApproveSiteMembershipRequest: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Create a site **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Creates a default site with the given details.  Unless explicitly specified, the site id will be generated from the site title. The site id must be unique and only contain alphanumeric and/or dash characters.  Note: the id of a site cannot be updated once the site has been created.  For example, to create a public site called \&quot;Marketing\&quot; the following body could be used: &#x60;&#x60;&#x60;JSON {   \&quot;title\&quot;: \&quot;Marketing\&quot;,   \&quot;visibility\&quot;: \&quot;PUBLIC\&quot; } &#x60;&#x60;&#x60;  The creation of the (surf) configuration files required by Share can be skipped via the **skipConfiguration** query parameter.  **Note:** if skipped then such a site will **not** work within Share.  The addition of the site to the user&#39;s site favorites can be skipped via the **skipAddToFavorites** query parameter.  The creator will be added as a member with Site Manager role.  When you create a site, a container called **documentLibrary** is created for you in the new site. This container is the root folder for content stored in the site. 
        /// </summary>
        /// <param name="siteBodyCreate">The site details</param> 
        /// <param name="skipConfiguration">Flag to indicate whether the Share-specific (surf) configuration files for the site should not be created.</param> 
        /// <param name="skipAddToFavorites">Flag to indicate whether the site should not be added to the user&#39;s site favorites.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SiteEntry</returns>            
        public SiteEntry CreateSite (SiteBodyCreate siteBodyCreate, bool? skipConfiguration, bool? skipAddToFavorites, List<string> fields)
        {
            
            // verify the required parameter 'siteBodyCreate' is set
            if (siteBodyCreate == null) throw new ApiException(400, "Missing required parameter 'siteBodyCreate' when calling CreateSite");
            
    
            var path = "/sites";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (skipConfiguration != null) queryParams.Add("skipConfiguration", ApiClient.ParameterToString(skipConfiguration)); // query parameter
 if (skipAddToFavorites != null) queryParams.Add("skipAddToFavorites", ApiClient.ParameterToString(skipAddToFavorites)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(siteBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateSite: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateSite: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteEntry) ApiClient.Deserialize(response.Content, typeof(SiteEntry), response.Headers);
        }
    
        /// <summary>
        /// Create a site membership Creates a site membership for person **personId** on site **siteId**.  You can set the **role** to one of four types:  * SiteConsumer * SiteCollaborator * SiteContributor * SiteManager  **Note:** You can create more than one site membership by specifying a list of people in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {     \&quot;role\&quot;: \&quot;SiteConsumer\&quot;,     \&quot;id\&quot;: \&quot;joe\&quot;   },   {     \&quot;role\&quot;: \&quot;SiteConsumer\&quot;,     \&quot;id\&quot;: \&quot;fred\&quot;   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param> 
        /// <param name="siteMembershipBodyCreate">The person to add and their role</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SiteMemberEntry</returns>            
        public SiteMemberEntry CreateSiteMembership (string siteId, SiteMembershipBodyCreate siteMembershipBodyCreate, List<string> fields)
        {
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling CreateSiteMembership");
            
            // verify the required parameter 'siteMembershipBodyCreate' is set
            if (siteMembershipBodyCreate == null) throw new ApiException(400, "Missing required parameter 'siteMembershipBodyCreate' when calling CreateSiteMembership");
            
    
            var path = "/sites/{siteId}/members";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "siteId" + "}", ApiClient.ParameterToString(siteId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(siteMembershipBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateSiteMembership: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateSiteMembership: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteMemberEntry) ApiClient.Deserialize(response.Content, typeof(SiteMemberEntry), response.Headers);
        }
    
        /// <summary>
        /// Create a site membership request Create a site membership request for yourself on the site with the identifier of **id**, specified in the JSON body. The result of the request differs depending on the type of site.  * For a **public** site, you join the site immediately as a SiteConsumer. * For a **moderated** site, your request is added to the site membership request list. The request waits for approval from the Site Manager. * You cannot request membership of a **private** site. Members are invited by the site administrator.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user.   **Note:** You can create site membership requests for more than one site by specifying a list of sites in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {     \&quot;message\&quot;: \&quot;Please can you add me\&quot;,     \&quot;id\&quot;: \&quot;test-site-1\&quot;,     \&quot;title\&quot;: \&quot;Request for test site 1\&quot;,   },   {     \&quot;message\&quot;: \&quot;Please can you add me\&quot;,     \&quot;id\&quot;: \&quot;test-site-2\&quot;,     \&quot;title\&quot;: \&quot;Request for test site 2\&quot;,   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="siteMembershipRequestBodyCreate">Site membership request details</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SiteMembershipRequestEntry</returns>            
        public SiteMembershipRequestEntry CreateSiteMembershipRequestForPerson (string personId, SiteMembershipRequestBodyCreate siteMembershipRequestBodyCreate, List<string> fields)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling CreateSiteMembershipRequestForPerson");
            
            // verify the required parameter 'siteMembershipRequestBodyCreate' is set
            if (siteMembershipRequestBodyCreate == null) throw new ApiException(400, "Missing required parameter 'siteMembershipRequestBodyCreate' when calling CreateSiteMembershipRequestForPerson");
            
    
            var path = "/people/{personId}/site-membership-requests";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(siteMembershipRequestBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateSiteMembershipRequestForPerson: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateSiteMembershipRequestForPerson: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteMembershipRequestEntry) ApiClient.Deserialize(response.Content, typeof(SiteMembershipRequestEntry), response.Headers);
        }
    
        /// <summary>
        /// Delete a site **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Deletes the site with **siteId**. 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param> 
        /// <param name="permanent">Flag to indicate whether the site should be permanently deleted i.e. bypass the trashcan.</param> 
        /// <returns></returns>            
        public void DeleteSite (string siteId, bool? permanent)
        {
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling DeleteSite");
            
    
            var path = "/sites/{siteId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "siteId" + "}", ApiClient.ParameterToString(siteId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (permanent != null) queryParams.Add("permanent", ApiClient.ParameterToString(permanent)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteSite: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteSite: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Delete a site membership Deletes person **personId** as a member of site **siteId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param> 
        /// <param name="personId">The identifier of a person.</param> 
        /// <returns></returns>            
        public void DeleteSiteMembership (string siteId, string personId)
        {
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling DeleteSiteMembership");
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling DeleteSiteMembership");
            
    
            var path = "/sites/{siteId}/members/{personId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "siteId" + "}", ApiClient.ParameterToString(siteId));
path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteSiteMembership: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteSiteMembership: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Delete a site membership Deletes person **personId** as a member of site **siteId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="siteId">The identifier of a site.</param> 
        /// <returns></returns>            
        public void DeleteSiteMembershipForPerson (string personId, string siteId)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling DeleteSiteMembershipForPerson");
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling DeleteSiteMembershipForPerson");
            
    
            var path = "/people/{personId}/sites/{siteId}";
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
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteSiteMembershipForPerson: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteSiteMembershipForPerson: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Delete a site membership request Deletes the site membership request to site **siteId** for person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="siteId">The identifier of a site.</param> 
        /// <returns></returns>            
        public void DeleteSiteMembershipRequestForPerson (string personId, string siteId)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling DeleteSiteMembershipRequestForPerson");
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling DeleteSiteMembershipRequestForPerson");
            
    
            var path = "/people/{personId}/site-membership-requests/{siteId}";
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
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteSiteMembershipRequestForPerson: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteSiteMembershipRequestForPerson: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get a site Gets information for site **siteId**.  You can use the **relations** parameter to include one or more related entities in a single response and so reduce network traffic.  The entity types in Alfresco are organized in a tree structure. The **sites** entity has two children, **containers** and **members**. The following relations parameter returns all the container and member objects related to the site **siteId**:  &#x60;&#x60;&#x60; containers,members &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param> 
        /// <param name="relations">Use the relations parameter to include one or more related entities in a single response.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SiteEntry</returns>            
        public SiteEntry GetSite (string siteId, List<string> relations, List<string> fields)
        {
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling GetSite");
            
    
            var path = "/sites/{siteId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "siteId" + "}", ApiClient.ParameterToString(siteId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (relations != null) queryParams.Add("relations", ApiClient.ParameterToString(relations)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetSite: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetSite: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteEntry) ApiClient.Deserialize(response.Content, typeof(SiteEntry), response.Headers);
        }
    
        /// <summary>
        /// Get a site container Gets information on the container **containerId** in site **siteId**.
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param> 
        /// <param name="containerId">The unique identifier of a site container.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SiteContainerEntry</returns>            
        public SiteContainerEntry GetSiteContainer (string siteId, string containerId, List<string> fields)
        {
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling GetSiteContainer");
            
            // verify the required parameter 'containerId' is set
            if (containerId == null) throw new ApiException(400, "Missing required parameter 'containerId' when calling GetSiteContainer");
            
    
            var path = "/sites/{siteId}/containers/{containerId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "siteId" + "}", ApiClient.ParameterToString(siteId));
path = path.Replace("{" + "containerId" + "}", ApiClient.ParameterToString(containerId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetSiteContainer: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetSiteContainer: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteContainerEntry) ApiClient.Deserialize(response.Content, typeof(SiteContainerEntry), response.Headers);
        }
    
        /// <summary>
        /// Get a site membership Gets site membership information for person **personId** on site **siteId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param> 
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SiteMemberEntry</returns>            
        public SiteMemberEntry GetSiteMembership (string siteId, string personId, List<string> fields)
        {
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling GetSiteMembership");
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling GetSiteMembership");
            
    
            var path = "/sites/{siteId}/members/{personId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "siteId" + "}", ApiClient.ParameterToString(siteId));
path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetSiteMembership: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetSiteMembership: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteMemberEntry) ApiClient.Deserialize(response.Content, typeof(SiteMemberEntry), response.Headers);
        }
    
        /// <summary>
        /// Get a site membership Gets site membership information for person **personId** on site **siteId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="siteId">The identifier of a site.</param> 
        /// <returns>SiteRoleEntry</returns>            
        public SiteRoleEntry GetSiteMembershipForPerson (string personId, string siteId)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling GetSiteMembershipForPerson");
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling GetSiteMembershipForPerson");
            
    
            var path = "/people/{personId}/sites/{siteId}";
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
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetSiteMembershipForPerson: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetSiteMembershipForPerson: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteRoleEntry) ApiClient.Deserialize(response.Content, typeof(SiteRoleEntry), response.Headers);
        }
    
        /// <summary>
        /// Get a site membership request Gets the site membership request for site **siteId** for person **personId**, if one exists.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="siteId">The identifier of a site.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SiteMembershipRequestEntry</returns>            
        public SiteMembershipRequestEntry GetSiteMembershipRequestForPerson (string personId, string siteId, List<string> fields)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling GetSiteMembershipRequestForPerson");
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling GetSiteMembershipRequestForPerson");
            
    
            var path = "/people/{personId}/site-membership-requests/{siteId}";
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetSiteMembershipRequestForPerson: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetSiteMembershipRequestForPerson: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteMembershipRequestEntry) ApiClient.Deserialize(response.Content, typeof(SiteMembershipRequestEntry), response.Headers);
        }
    
        /// <summary>
        /// Get site membership requests Get the list of site membership requests the user can action.  You can use the **where** parameter to filter the returned site membership requests by **siteId**. For example:  &#x60;&#x60;&#x60; (siteId&#x3D;mySite) &#x60;&#x60;&#x60;  The **where** parameter can also be used to filter by ***personId***. For example:  &#x60;&#x60;&#x60; where&#x3D;(personId&#x3D;person) &#x60;&#x60;&#x60;  This may be combined with the siteId filter, as shown below:  &#x60;&#x60;&#x60; where&#x3D;(siteId&#x3D;mySite AND personId&#x3D;person)) &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="where">A string to restrict the returned objects by using a predicate.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SiteMembershipRequestWithPersonPaging</returns>            
        public SiteMembershipRequestWithPersonPaging GetSiteMembershipRequests (int? skipCount, int? maxItems, string where, List<string> fields)
        {
            
    
            var path = "/site-membership-requests";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (skipCount != null) queryParams.Add("skipCount", ApiClient.ParameterToString(skipCount)); // query parameter
 if (maxItems != null) queryParams.Add("maxItems", ApiClient.ParameterToString(maxItems)); // query parameter
 if (where != null) queryParams.Add("where", ApiClient.ParameterToString(where)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetSiteMembershipRequests: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetSiteMembershipRequests: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteMembershipRequestWithPersonPaging) ApiClient.Deserialize(response.Content, typeof(SiteMembershipRequestWithPersonPaging), response.Headers);
        }
    
        /// <summary>
        /// List site containers Gets a list of containers for the site **siteId**.
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SiteContainerPaging</returns>            
        public SiteContainerPaging ListSiteContainers (string siteId, int? skipCount, int? maxItems, List<string> fields)
        {
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling ListSiteContainers");
            
    
            var path = "/sites/{siteId}/containers";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "siteId" + "}", ApiClient.ParameterToString(siteId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling ListSiteContainers: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListSiteContainers: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteContainerPaging) ApiClient.Deserialize(response.Content, typeof(SiteContainerPaging), response.Headers);
        }
    
        /// <summary>
        /// List site membership requests Gets a list of the current site membership requests for person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SiteMembershipRequestPaging</returns>            
        public SiteMembershipRequestPaging ListSiteMembershipRequestsForPerson (string personId, int? skipCount, int? maxItems, List<string> fields)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling ListSiteMembershipRequestsForPerson");
            
    
            var path = "/people/{personId}/site-membership-requests";
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
                throw new ApiException ((int)response.StatusCode, "Error calling ListSiteMembershipRequestsForPerson: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListSiteMembershipRequestsForPerson: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteMembershipRequestPaging) ApiClient.Deserialize(response.Content, typeof(SiteMembershipRequestPaging), response.Headers);
        }
    
        /// <summary>
        /// List site memberships Gets a list of site memberships for site **siteId**.
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SiteMemberPaging</returns>            
        public SiteMemberPaging ListSiteMemberships (string siteId, int? skipCount, int? maxItems, List<string> fields)
        {
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling ListSiteMemberships");
            
    
            var path = "/sites/{siteId}/members";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "siteId" + "}", ApiClient.ParameterToString(siteId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling ListSiteMemberships: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListSiteMemberships: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteMemberPaging) ApiClient.Deserialize(response.Content, typeof(SiteMemberPaging), response.Headers);
        }
    
        /// <summary>
        /// List site memberships Gets a list of site membership information for person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user.  You can use the **where** parameter to filter the returned sites by **visibility** or site **preset**.  Example to filter by **visibility**, use any one of:  &#x60;&#x60;&#x60; (visibility&#x3D;&#39;PRIVATE&#39;) (visibility&#x3D;&#39;PUBLIC&#39;) (visibility&#x3D;&#39;MODERATED&#39;) &#x60;&#x60;&#x60;  Example to filter by site **preset**:  &#x60;&#x60;&#x60; (preset&#x3D;&#39;site-dashboard&#39;) &#x60;&#x60;&#x60;  The default sort order for the returned list is for sites to be sorted by ascending title. You can override the default by using the **orderBy** parameter. You can specify one or more of the following fields in the **orderBy** parameter: * id * title * role 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param> 
        /// <param name="relations">Use the relations parameter to include one or more related entities in a single response.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <param name="where">A string to restrict the returned objects by using a predicate.</param> 
        /// <returns>SiteRolePaging</returns>            
        public SiteRolePaging ListSiteMembershipsForPerson (string personId, int? skipCount, int? maxItems, List<string> orderBy, List<string> relations, List<string> fields, string where)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling ListSiteMembershipsForPerson");
            
    
            var path = "/people/{personId}/sites";
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
 if (relations != null) queryParams.Add("relations", ApiClient.ParameterToString(relations)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
 if (where != null) queryParams.Add("where", ApiClient.ParameterToString(where)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListSiteMembershipsForPerson: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListSiteMembershipsForPerson: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteRolePaging) ApiClient.Deserialize(response.Content, typeof(SiteRolePaging), response.Headers);
        }
    
        /// <summary>
        /// List sites Gets a list of sites in this repository.  You can use the **where** parameter to filter the returned sites by **visibility** or site **preset**.  Example to filter by **visibility**, use any one of:  &#x60;&#x60;&#x60; (visibility&#x3D;&#39;PRIVATE&#39;) (visibility&#x3D;&#39;PUBLIC&#39;) (visibility&#x3D;&#39;MODERATED&#39;) &#x60;&#x60;&#x60;  Example to filter by site **preset**:  &#x60;&#x60;&#x60; (preset&#x3D;&#39;site-dashboard&#39;) &#x60;&#x60;&#x60;  The default sort order for the returned list is for sites to be sorted by ascending title. You can override the default by using the **orderBy** parameter. You can specify one or more of the following fields in the **orderBy** parameter: * id * title * description  You can use the **relations** parameter to include one or more related entities in a single response and so reduce network traffic.  The entity types in Alfresco are organized in a tree structure. The **sites** entity has two children, **containers** and **members**. The following relations parameter returns all the container and member objects related to each site:  &#x60;&#x60;&#x60; containers,members &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param> 
        /// <param name="relations">Use the relations parameter to include one or more related entities in a single response.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <param name="where">A string to restrict the returned objects by using a predicate.</param> 
        /// <returns>SitePaging</returns>            
        public SitePaging ListSites (int? skipCount, int? maxItems, List<string> orderBy, List<string> relations, List<string> fields, string where)
        {
            
    
            var path = "/sites";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (skipCount != null) queryParams.Add("skipCount", ApiClient.ParameterToString(skipCount)); // query parameter
 if (maxItems != null) queryParams.Add("maxItems", ApiClient.ParameterToString(maxItems)); // query parameter
 if (orderBy != null) queryParams.Add("orderBy", ApiClient.ParameterToString(orderBy)); // query parameter
 if (relations != null) queryParams.Add("relations", ApiClient.ParameterToString(relations)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
 if (where != null) queryParams.Add("where", ApiClient.ParameterToString(where)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListSites: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListSites: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SitePaging) ApiClient.Deserialize(response.Content, typeof(SitePaging), response.Headers);
        }
    
        /// <summary>
        /// Reject a site membership request Reject a site membership request. 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param> 
        /// <param name="inviteeId">The invitee user name.</param> 
        /// <param name="siteMembershipRejectionBody">Rejecting a request to join, optionally, allows the inclusion of comment. </param> 
        /// <returns></returns>            
        public void RejectSiteMembershipRequest (string siteId, string inviteeId, SiteMembershipRejectionBody siteMembershipRejectionBody)
        {
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling RejectSiteMembershipRequest");
            
            // verify the required parameter 'inviteeId' is set
            if (inviteeId == null) throw new ApiException(400, "Missing required parameter 'inviteeId' when calling RejectSiteMembershipRequest");
            
    
            var path = "/sites/{siteId}/site-membership-requests/{inviteeId}/reject";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "siteId" + "}", ApiClient.ParameterToString(siteId));
path = path.Replace("{" + "inviteeId" + "}", ApiClient.ParameterToString(inviteeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(siteMembershipRejectionBody); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RejectSiteMembershipRequest: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RejectSiteMembershipRequest: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Update a site **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Update the details for the given site **siteId**. Site Manager or otherwise a (site) admin can update title, description or visibility.  Note: the id of a site cannot be updated once the site has been created. 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param> 
        /// <param name="siteBodyUpdate">The site information to update.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SiteEntry</returns>            
        public SiteEntry UpdateSite (string siteId, SiteBodyUpdate siteBodyUpdate, List<string> fields)
        {
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling UpdateSite");
            
            // verify the required parameter 'siteBodyUpdate' is set
            if (siteBodyUpdate == null) throw new ApiException(400, "Missing required parameter 'siteBodyUpdate' when calling UpdateSite");
            
    
            var path = "/sites/{siteId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "siteId" + "}", ApiClient.ParameterToString(siteId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(siteBodyUpdate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateSite: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateSite: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteEntry) ApiClient.Deserialize(response.Content, typeof(SiteEntry), response.Headers);
        }
    
        /// <summary>
        /// Update a site membership Update the membership of person **personId** in site **siteId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user.  You can set the **role** to one of four types:  * SiteConsumer * SiteCollaborator * SiteContributor * SiteManager 
        /// </summary>
        /// <param name="siteId">The identifier of a site.</param> 
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="siteMembershipBodyUpdate">The persons new role</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SiteMemberEntry</returns>            
        public SiteMemberEntry UpdateSiteMembership (string siteId, string personId, SiteMembershipBodyUpdate siteMembershipBodyUpdate, List<string> fields)
        {
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling UpdateSiteMembership");
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling UpdateSiteMembership");
            
            // verify the required parameter 'siteMembershipBodyUpdate' is set
            if (siteMembershipBodyUpdate == null) throw new ApiException(400, "Missing required parameter 'siteMembershipBodyUpdate' when calling UpdateSiteMembership");
            
    
            var path = "/sites/{siteId}/members/{personId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "siteId" + "}", ApiClient.ParameterToString(siteId));
path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(siteMembershipBodyUpdate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateSiteMembership: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateSiteMembership: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteMemberEntry) ApiClient.Deserialize(response.Content, typeof(SiteMemberEntry), response.Headers);
        }
    
        /// <summary>
        /// Update a site membership request Updates the message for the site membership request to site **siteId** for person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="siteId">The identifier of a site.</param> 
        /// <param name="siteMembershipRequestBodyUpdate">The new message to display</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>SiteMembershipRequestEntry</returns>            
        public SiteMembershipRequestEntry UpdateSiteMembershipRequestForPerson (string personId, string siteId, SiteMembershipRequestBodyUpdate siteMembershipRequestBodyUpdate, List<string> fields)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling UpdateSiteMembershipRequestForPerson");
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling UpdateSiteMembershipRequestForPerson");
            
            // verify the required parameter 'siteMembershipRequestBodyUpdate' is set
            if (siteMembershipRequestBodyUpdate == null) throw new ApiException(400, "Missing required parameter 'siteMembershipRequestBodyUpdate' when calling UpdateSiteMembershipRequestForPerson");
            
    
            var path = "/people/{personId}/site-membership-requests/{siteId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
path = path.Replace("{" + "siteId" + "}", ApiClient.ParameterToString(siteId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(siteMembershipRequestBodyUpdate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateSiteMembershipRequestForPerson: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateSiteMembershipRequestForPerson: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SiteMembershipRequestEntry) ApiClient.Deserialize(response.Content, typeof(SiteMembershipRequestEntry), response.Headers);
        }
    
    }
}
