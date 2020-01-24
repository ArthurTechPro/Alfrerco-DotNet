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
    public interface INodesApi
    {
        /// <summary>
        /// Copy a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Copies the node **nodeId** to the parent folder node **targetParentId**. You specify the **targetParentId** in the request body.  The new node has the same name as the source node unless you specify a new **name** in the request body.  If the source **nodeId** is a folder, then all of its children are also copied.  If the source **nodeId** is a file, it&#39;s properties, aspects and tags are copied, it&#39;s ratings, comments and locks are not. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="nodeBodyCopy">The targetParentId and, optionally, a new name which should include the file extension.</param>
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * association * isLink * isFavorite * isLocked * path * permissions </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>NodeEntry</returns>
        NodeEntry CopyNode (string nodeId, NodeBodyCopy nodeBodyCopy, List<string> include, List<string> fields);
        /// <summary>
        /// Create node association **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Create an association, with the given association type, between the source **nodeId** and a target node.  **Note:** You can create more than one association by specifying a list of associations in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {      \&quot;targetId\&quot;: \&quot;string\&quot;,      \&quot;assocType\&quot;: \&quot;string\&quot;   },   {     \&quot;targetId\&quot;: \&quot;string\&quot;,     \&quot;assocType\&quot;: \&quot;string\&quot;   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="nodeId">The identifier of a source node.</param>
        /// <param name="associationBodyCreate">The target node id and assoc type.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>AssociationEntry</returns>
        AssociationEntry CreateAssociation (string nodeId, AssociationBody associationBodyCreate, List<string> fields);
        /// <summary>
        /// Create a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Create a node and add it as a primary child of node **nodeId**.  This endpoint supports both JSON and multipart/form-data (file upload).  **Using multipart/form-data**  Use the **filedata** field to represent the content to upload, for example, the following curl command will create a node with the contents of test.txt in the test user&#39;s home folder.  &#x60;&#x60;&#x60;curl -utest:test -X POST host:port/alfresco/api/-default-/public/alfresco/versions/1/nodes/-my-/children -F filedata&#x3D;@test.txt&#x60;&#x60;&#x60;  You can use the **name** field to give an alternative name for the new file.  You can use the **nodeType** field to create a specific type. The default is cm:content.  You can use the **renditions** field to create renditions (e.g. doclib) asynchronously upon upload. Note that currently only one rendition can be requested. Also, as requesting rendition is a background process, any rendition failure (e.g. No transformer is currently available) will not fail the whole upload and has the potential to silently fail.  Use **overwrite** to overwrite an existing file, matched by name. If the file is versionable, the existing content is replaced.  When you overwrite existing content, you can set the **majorVersion** boolean field to **true** to indicate a major version should be created. The default for **majorVersion** is **false**. Setting  **majorVersion** enables versioning of the node, if it is not already versioned.  When you overwrite existing content, you can use the **comment** field to add a version comment that appears in the version history. This also enables versioning of this node, if it is not already versioned.  You can set the **autoRename** boolean field to automatically resolve name clashes. If there is a name clash, then the API method tries to create a unique name using an integer suffix.  You can use the **relativePath** field to specify the folder structure to create relative to the node **nodeId**. Folders in the **relativePath** that do not exist are created before the node is created.  Any other field provided will be treated as a property to set on the newly created node.  **Note:** setting properties of type d:content and d:category are not supported.  **Using JSON**  You must specify at least a **name** and **nodeType**. For example, to create a folder: &#x60;&#x60;&#x60;JSON {   \&quot;name\&quot;:\&quot;My Folder\&quot;,   \&quot;nodeType\&quot;:\&quot;cm:folder\&quot; } &#x60;&#x60;&#x60;  You can create an empty file like this: &#x60;&#x60;&#x60;JSON {   \&quot;name\&quot;:\&quot;My text file.txt\&quot;,   \&quot;nodeType\&quot;:\&quot;cm:content\&quot; } &#x60;&#x60;&#x60; You can update binary content using the &#x60;&#x60;&#x60;PUT /nodes/{nodeId}&#x60;&#x60;&#x60; API method.  You can create a folder, or other node, inside a folder hierarchy: &#x60;&#x60;&#x60;JSON {   \&quot;name\&quot;:\&quot;My Special Folder\&quot;,   \&quot;nodeType\&quot;:\&quot;cm:folder\&quot;,   \&quot;relativePath\&quot;:\&quot;X/Y/Z\&quot; } &#x60;&#x60;&#x60; The **relativePath** specifies the folder structure to create relative to the node **nodeId**. Folders in the **relativePath** that do not exist are created before the node is created.  You can set properties when you create a new node: &#x60;&#x60;&#x60;JSON {   \&quot;name\&quot;:\&quot;My Other Folder\&quot;,   \&quot;nodeType\&quot;:\&quot;cm:folder\&quot;,   \&quot;properties\&quot;:   {     \&quot;cm:title\&quot;:\&quot;Folder title\&quot;,     \&quot;cm:description\&quot;:\&quot;This is an important folder\&quot;   } } &#x60;&#x60;&#x60; Any missing aspects are applied automatically. For example, **cm:titled** in the JSON shown above. You can set aspects explicitly, if needed, using an **aspectNames** field.  **Note:** setting properties of type d:content and d:category are not supported.  Typically, for files and folders, the primary children are created within the parent folder using the default \&quot;cm:contains\&quot; assocType. If the content model allows then it is also possible to create primary children with a different assoc type. For example: &#x60;&#x60;&#x60;JSON {   \&quot;name\&quot;:\&quot;My Node\&quot;,   \&quot;nodeType\&quot;:\&quot;my:specialNodeType\&quot;,   \&quot;association\&quot;:   {     \&quot;assocType\&quot;:\&quot;my:specialAssocType\&quot;   } } &#x60;&#x60;&#x60;  Additional associations can be added after creating a node. You can also add associations at the time the node is created. This is required, for example, if the content model specifies that a node has mandatory associations to one or more existing nodes. You can optionally specify an array of **secondaryChildren** to create one or more secondary child associations, such that the newly created node acts as a parent node. You can optionally specify an array of **targets** to create one or more peer associations such that the newly created node acts as a source node. For example, to associate one or more secondary children at time of creation: &#x60;&#x60;&#x60;JSON {   \&quot;name\&quot;:\&quot;My Folder\&quot;,   \&quot;nodeType\&quot;:\&quot;cm:folder\&quot;,   \&quot;secondaryChildren\&quot;:     [ {\&quot;childId\&quot;:\&quot;abcde-01234-...\&quot;, \&quot;assocType\&quot;:\&quot;my:specialChildAssocType\&quot;} ] } &#x60;&#x60;&#x60; For example, to associate one or more targets at time of creation: &#x60;&#x60;&#x60;JSON {   \&quot;name\&quot;:\&quot;My Folder\&quot;,   \&quot;nodeType\&quot;:\&quot;cm:folder\&quot;,   \&quot;targets\&quot;:     [ {\&quot;targetId\&quot;:\&quot;abcde-01234-...\&quot;, \&quot;assocType\&quot;:\&quot;my:specialPeerAssocType\&quot;} ] } &#x60;&#x60;&#x60;  **Note:** You can create more than one child by specifying a list of nodes in the JSON body. For example, the following JSON body creates two folders inside the specified **nodeId**, if the **nodeId** identifies a folder:  &#x60;&#x60;&#x60;JSON [   {     \&quot;name\&quot;:\&quot;My Folder 1\&quot;,     \&quot;nodeType\&quot;:\&quot;cm:folder\&quot;   },   {     \&quot;name\&quot;:\&quot;My Folder 2\&quot;,     \&quot;nodeType\&quot;:\&quot;cm:folder\&quot;   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="nodeId">The identifier of a node. You can also use one of these well-known aliases: * -my- * -shared- * -root- </param>
        /// <param name="nodeBodyCreate">The node information to create.</param>
        /// <param name="autoRename">If true, then  a name clash will cause an attempt to auto rename by finding a unique name using an integer suffix.</param>
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * association * isLink * isFavorite * isLocked * path * permissions </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>NodeEntry</returns>
        NodeEntry CreateNode (string nodeId, NodeBodyCreate nodeBodyCreate, bool? autoRename, List<string> include, List<string> fields);
        /// <summary>
        /// Create secondary child **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Create a secondary child association, with the given association type, between the parent **nodeId** and a child node.  **Note:** You can create more than one secondary child association by specifying a list of associations in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {     \&quot;childId\&quot;: \&quot;string\&quot;,     \&quot;assocType\&quot;: \&quot;string\&quot;   },   {     \&quot;childId\&quot;: \&quot;string\&quot;,     \&quot;assocType\&quot;: \&quot;string\&quot;   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="nodeId">The identifier of a parent node.</param>
        /// <param name="secondaryChildAssociationBodyCreate">The child node id and assoc type.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>ChildAssociationEntry</returns>
        ChildAssociationEntry CreateSecondaryChildAssociation (string nodeId, ChildAssociationBody secondaryChildAssociationBodyCreate, List<string> fields);
        /// <summary>
        /// Delete node association(s) **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Delete an association, or associations, from the source **nodeId* to a target node for the given association type.  If the association type is **not** specified, then all peer associations, of any type, in the direction from source to target, are deleted.  **Note:** After removal of the peer association, or associations, from source to target, the two nodes may still have peer associations in the other direction. 
        /// </summary>
        /// <param name="nodeId">The identifier of a source node.</param>
        /// <param name="targetId">The identifier of a target node.</param>
        /// <param name="assocType">Only delete associations of this type.</param>
        /// <returns></returns>
        void DeleteAssociation (string nodeId, string targetId, string assocType);
        /// <summary>
        /// Delete a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Deletes the node **nodeId**.  If **nodeId** is a folder, then its children are also deleted.  Deleted nodes move to the trashcan unless the **permanent** query parameter is **true** and the current user is the owner of the node or an admin.  Deleting a node deletes it from its primary parent and also from any secondary parents. Peer associations are also deleted, where the deleted node is either a source or target of an association. This applies recursively to any hierarchy of primary children of the deleted node.  **Note:** If the node is not permanently deleted, and is later successfully restored to its former primary parent, then the primary child association is restored. This applies recursively for any primary children. No other secondary child associations or peer associations are restored for any of the nodes in the primary parent-child hierarchy of restored nodes, regardless of whether the original associations were to nodes inside or outside the restored hierarchy. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="permanent">If **true** then the node is deleted permanently, without moving to the trashcan. Only the owner of the node or an admin can permanently delete the node. </param>
        /// <returns></returns>
        void DeleteNode (string nodeId, bool? permanent);
        /// <summary>
        /// Delete secondary child or children **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Delete secondary child associations between the parent **nodeId** and child nodes for the given association type.  If the association type is **not** specified, then all secondary child associations, of any type in the direction from parent to secondary child, will be deleted. The child will still have a primary parent and may still be associated as a secondary child with other secondary parents. 
        /// </summary>
        /// <param name="nodeId">The identifier of a parent node.</param>
        /// <param name="childId">The identifier of a child node.</param>
        /// <param name="assocType">Only delete associations of this type.</param>
        /// <returns></returns>
        void DeleteSecondaryChildAssociation (string nodeId, string childId, string assocType);
        /// <summary>
        /// Get a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Get information for node **nodeId**.  You can use the **include** parameter to return additional information. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node. You can also use one of these well-known aliases: * -my- * -shared- * -root- </param>
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * association * isLink * isFavorite * isLocked * path * permissions </param>
        /// <param name="relativePath">A path relative to the **nodeId**. If you set this, information is returned on the node resolved by this path. </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>NodeEntry</returns>
        NodeEntry GetNode (string nodeId, List<string> include, string relativePath, List<string> fields);
        /// <summary>
        /// Get node content **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets the content of the node with identifier **nodeId**. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="attachment">**true** enables a web browser to download the file as an attachment. **false** means a web browser may preview the file in a new tab or window, but not download the file.  You can only set this parameter to **false** if the content type of the file is in the supported list; for example, certain image files and PDF files.  If the content type is not supported for preview, then a value of **false**  is ignored, and the attachment will be returned in the response. </param>
        /// <param name="ifModifiedSince">Only returns the content if it has been modified since the date provided. Use the date format defined by HTTP. For example, &#x60;Wed, 09 Mar 2016 16:56:34 GMT&#x60;. </param>
        /// <param name="range">The Range header indicates the part of a document that the server should return. Single part request supported, for example: bytes&#x3D;1-10. </param>
        /// <returns></returns>
        void GetNodeContent (string nodeId, bool? attachment, DateTime? ifModifiedSince, string range);
        /// <summary>
        /// List node children **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets a list of children of the parent node **nodeId**.  Minimal information for each child is returned by default.  You can use the **include** parameter to return additional information.  The list of child nodes includes primary children and secondary children, if there are any.  You can use the **include** parameter (include&#x3D;association) to return child association details for each child, including the **assocTyp**e and the **isPrimary** flag.  The default sort order for the returned list is for folders to be sorted before files, and by ascending name.  You can override the default using **orderBy** to specify one or more fields to sort by. The default order is always ascending, but you can use an optional **ASC** or **DESC** modifier to specify an ascending or descending sort order.  For example, specifying &#x60;&#x60;&#x60;orderBy&#x3D;name DESC&#x60;&#x60;&#x60; returns a mixed folder/file list in descending **name** order.  You can use any of the following fields to order the results: * isFolder * name * mimeType * nodeType * sizeInBytes * modifiedAt * createdAt * modifiedByUser * createdByUser 
        /// </summary>
        /// <param name="nodeId">The identifier of a node. You can also use one of these well-known aliases: * -my- * -shared- * -root- </param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param>
        /// <param name="where">Optionally filter the list. Here are some examples:  *   &#x60;&#x60;&#x60;where&#x3D;(isFolder&#x3D;true)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(isFile&#x3D;true)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(nodeType&#x3D;&#39;my:specialNodeType&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(nodeType&#x3D;&#39;my:specialNodeType INCLUDESUBTYPES&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(isPrimary&#x3D;true)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(assocType&#x3D;&#39;my:specialAssocType&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(isPrimary&#x3D;false and assocType&#x3D;&#39;my:specialAssocType&#39;)&#x60;&#x60;&#x60; </param>
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * aspectNames * association * isLink * isFavorite * isLocked * path * properties * permissions </param>
        /// <param name="relativePath">Return information on children in the folder resolved by this path. The path is relative to **nodeId**.</param>
        /// <param name="includeSource">Also include **source** in addition to **entries** with folder information on the parent node – either the specified parent **nodeId**, or as resolved by **relativePath**.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>NodeChildAssociationPaging</returns>
        NodeChildAssociationPaging ListNodeChildren (string nodeId, int? skipCount, int? maxItems, List<string> orderBy, string where, List<string> include, string relativePath, bool? includeSource, List<string> fields);
        /// <summary>
        /// List parents **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets a list of parent nodes that are associated with the current child **nodeId**.  The list includes both the primary parent and any secondary parents. 
        /// </summary>
        /// <param name="nodeId">The identifier of a child node. You can also use one of these well-known aliases: * -my- * -shared- * -root- </param>
        /// <param name="where">Optionally filter the list by **assocType** and/or **isPrimary**. Here are some example filters:  *   &#x60;&#x60;&#x60;where&#x3D;(assocType&#x3D;&#39;my:specialAssocType&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(isPrimary&#x3D;true)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(isPrimary&#x3D;false and assocType&#x3D;&#39;my:specialAssocType&#39;)&#x60;&#x60;&#x60; </param>
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * aspectNames * isLink * isFavorite * isLocked * path * properties </param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="includeSource">Also include **source** (in addition to **entries**) with folder information on **nodeId**</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>NodeAssociationPaging</returns>
        NodeAssociationPaging ListParents (string nodeId, string where, List<string> include, int? skipCount, int? maxItems, bool? includeSource, List<string> fields);
        /// <summary>
        /// List secondary children **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets a list of secondary child nodes that are associated with the current parent **nodeId**, via a secondary child association. 
        /// </summary>
        /// <param name="nodeId">The identifier of a parent node. You can also use one of these well-known aliases: * -my- * -shared- * -root- </param>
        /// <param name="where">Optionally filter the list by assocType. Here&#39;s an example:  *   &#x60;&#x60;&#x60;where&#x3D;(assocType&#x3D;&#39;my:specialAssocType&#39;)&#x60;&#x60;&#x60; </param>
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * aspectNames * isLink * isFavorite * isLocked * path * properties </param>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="includeSource">Also include **source** (in addition to **entries**) with folder information on **nodeId**</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>NodeChildAssociationPaging</returns>
        NodeChildAssociationPaging ListSecondaryChildren (string nodeId, string where, List<string> include, int? skipCount, int? maxItems, bool? includeSource, List<string> fields);
        /// <summary>
        /// List source associations **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets a list of source nodes that are associated with the current target **nodeId**. 
        /// </summary>
        /// <param name="nodeId">The identifier of a target node.</param>
        /// <param name="where">Optionally filter the list by **assocType**. Here&#39;s an example:  *   &#x60;&#x60;&#x60;where&#x3D;(assocType&#x3D;&#39;my:specialAssocType&#39;)&#x60;&#x60;&#x60; </param>
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * aspectNames * isLink * isFavorite * isLocked * path * properties </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>NodeAssociationPaging</returns>
        NodeAssociationPaging ListSourceAssociations (string nodeId, string where, List<string> include, List<string> fields);
        /// <summary>
        /// List target associations **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets a list of target nodes that are associated with the current source **nodeId**. 
        /// </summary>
        /// <param name="nodeId">The identifier of a source node.</param>
        /// <param name="where">Optionally filter the list by **assocType**. Here&#39;s an example:  *   &#x60;&#x60;&#x60;where&#x3D;(assocType&#x3D;&#39;my:specialAssocType&#39;)&#x60;&#x60;&#x60; </param>
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * aspectNames * isLink * isFavorite * isLocked * path * properties </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>NodeAssociationPaging</returns>
        NodeAssociationPaging ListTargetAssociations (string nodeId, string where, List<string> include, List<string> fields);
        /// <summary>
        /// Lock a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Places a lock on node **nodeId**.  **Note:** you can only lock files. More specifically, a node can only be locked if it is of type &#x60;cm:content&#x60; or a subtype of &#x60;cm:content&#x60;.  The lock is owned by the current user, and prevents other users or processes from making updates to the node until the lock is released.  If the **timeToExpire** is not set or is zero, then the lock never expires.  Otherwise, the **timeToExpire** is the number of seconds before the lock expires.  When a lock expires, the lock is released.  If the node is already locked, and the user is the lock owner, then the lock is renewed with the new **timeToExpire**.  By default, a lock is applied that allows the owner to update or delete the node. You can use **type** to change the lock type to one of the following: * **ALLOW_OWNER_CHANGES** (default) changes to the node can be made only by the lock owner. This enum is the same value as the deprecated WRITE_LOCK described in &#x60;org.alfresco.service.cmr.lock.LockType&#x60; in the Alfresco Public Java API. This is the default value. * **FULL** no changes by any user are allowed. This enum is the same value as the deprecated READ_ONLY_LOCK described in &#x60;org.alfresco.service.cmr.lock.LockType&#x60; in the Alfresco Public Java API.  By default, a lock is persisted in the database. You can create a volatile in-memory lock by setting the **lifetime** property to EPHEMERAL. You might choose use EPHEMERAL locks, for example, if you are taking frequent short-term locks that you don&#39;t need to be kept over a restart of the repository. In this case you don&#39;t need the overhead of writing the locks to the database.  If a lock on the node cannot be taken, then an error is returned. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="nodeBodyLock">Lock details.</param>
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * association * isLink * isFavorite * isLocked * path * permissions </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>NodeEntry</returns>
        NodeEntry LockNode (string nodeId, NodeBodyLock nodeBodyLock, List<string> include, List<string> fields);
        /// <summary>
        /// Move a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Move the node **nodeId** to the parent folder node **targetParentId**.  The **targetParentId** is specified in the in request body.  The moved node retains its name unless you specify a new **name** in the request body.  If the source **nodeId** is a folder, then its children are also moved.  The move will effectively change the primary parent. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="nodeBodyMove">The targetParentId and, optionally, a new name which should include the file extension.</param>
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * association * isLink * isFavorite * isLocked * path * permissions </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>NodeEntry</returns>
        NodeEntry MoveNode (string nodeId, NodeBodyMove nodeBodyMove, List<string> include, List<string> fields);
        /// <summary>
        /// Unlock a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Deletes a lock on node **nodeId**.  The current user must be the owner of the locks or have admin rights, otherwise an error is returned.  If a lock on the node cannot be released, then an error is returned. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * association * isLink * isFavorite * isLocked * path * permissions </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>NodeEntry</returns>
        NodeEntry UnlockNode (string nodeId, List<string> include, List<string> fields);
        /// <summary>
        /// Update a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Updates the node **nodeId**. For example, you can rename a file or folder: &#x60;&#x60;&#x60;JSON {   \&quot;name\&quot;:\&quot;My new name\&quot; } &#x60;&#x60;&#x60; You can also set or update one or more properties: &#x60;&#x60;&#x60;JSON {   \&quot;properties\&quot;:   {     \&quot;cm:title\&quot;:\&quot;Folder title\&quot;   } } &#x60;&#x60;&#x60; **Note:** setting properties of type d:content and d:category are not supported.  **Note:** if you want to add or remove aspects, then you must use **GET /nodes/{nodeId}** first to get the complete set of *aspectNames*.  You can add (or remove) *locallySet* permissions, if any, in addition to any inherited permissions. You can also optionally disable (or re-enable) inherited permissions via *isInheritanceEnabled* flag: &#x60;&#x60;&#x60;JSON {   \&quot;permissions\&quot;:     {       \&quot;isInheritanceEnabled\&quot;: false,       \&quot;locallySet\&quot;:         [           {\&quot;authorityId\&quot;: \&quot;GROUP_special\&quot;, \&quot;name\&quot;: \&quot;Read\&quot;, \&quot;accessStatus\&quot;:\&quot;DENIED\&quot;},           {\&quot;authorityId\&quot;: \&quot;testuser\&quot;, \&quot;name\&quot;: \&quot;Contributor\&quot;, \&quot;accessStatus\&quot;:\&quot;ALLOWED\&quot;}         ]     } } &#x60;&#x60;&#x60; **Note:** if you want to add or remove locally set permissions then you must use **GET /nodes/{nodeId}** first to get the complete set of *locallySet* permissions.  **Note:** Currently there is no optimistic locking for updates, so they are applied in \&quot;last one wins\&quot; order. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="nodeBodyUpdate">The node information to update.</param>
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * association * isLink * isFavorite * isLocked * path * permissions </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>NodeEntry</returns>
        NodeEntry UpdateNode (string nodeId, NodeBodyUpdate nodeBodyUpdate, List<string> include, List<string> fields);
        /// <summary>
        /// Update node content **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Updates the content of the node with identifier **nodeId**.  The request body for this endpoint can be any text or binary stream.  The **majorVersion** and **comment** parameters can be used to control versioning behaviour. If the content is versionable, a new minor version is created by default.  Optionally a new **name** parameter can also be specified that must be unique within the parent folder. If specified and valid then this will rename the node. If invalid then an error is returned and the content is not updated.  **Note:** This API method accepts any content type, but for testing with this tool text based content can be provided. This is because the OpenAPI Specification does not allow a wildcard to be provided or the ability for tooling to accept an arbitrary file. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param>
        /// <param name="contentBodyUpdate">The binary content</param>
        /// <param name="majorVersion">If **true**, create a major version. Setting this parameter also enables versioning of this node, if it is not already versioned. </param>
        /// <param name="comment">Add a version comment which will appear in version history. Setting this parameter also enables versioning of this node, if it is not already versioned. </param>
        /// <param name="name">Optional new name. This should include the file extension. The name must not contain spaces or the following special characters: * \&quot; &lt; &gt; \\ / ? : and |. The character &#x60;.&#x60; must not be used at the end of the name. </param>
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * association * isLink * isFavorite * isLocked * path * permissions </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>NodeEntry</returns>
        NodeEntry UpdateNodeContent (string nodeId, byte[] contentBodyUpdate, bool? majorVersion, string comment, string name, List<string> include, List<string> fields);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class NodesApi : INodesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NodesApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public NodesApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="NodesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public NodesApi(String basePath)
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
        /// Copy a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Copies the node **nodeId** to the parent folder node **targetParentId**. You specify the **targetParentId** in the request body.  The new node has the same name as the source node unless you specify a new **name** in the request body.  If the source **nodeId** is a folder, then all of its children are also copied.  If the source **nodeId** is a file, it&#39;s properties, aspects and tags are copied, it&#39;s ratings, comments and locks are not. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="nodeBodyCopy">The targetParentId and, optionally, a new name which should include the file extension.</param> 
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * association * isLink * isFavorite * isLocked * path * permissions </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>NodeEntry</returns>            
        public NodeEntry CopyNode (string nodeId, NodeBodyCopy nodeBodyCopy, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling CopyNode");
            
            // verify the required parameter 'nodeBodyCopy' is set
            if (nodeBodyCopy == null) throw new ApiException(400, "Missing required parameter 'nodeBodyCopy' when calling CopyNode");
            
    
            var path = "/nodes/{nodeId}/copy";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(nodeBodyCopy); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CopyNode: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CopyNode: " + response.ErrorMessage, response.ErrorMessage);
    
            return (NodeEntry) ApiClient.Deserialize(response.Content, typeof(NodeEntry), response.Headers);
        }
    
        /// <summary>
        /// Create node association **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Create an association, with the given association type, between the source **nodeId** and a target node.  **Note:** You can create more than one association by specifying a list of associations in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {      \&quot;targetId\&quot;: \&quot;string\&quot;,      \&quot;assocType\&quot;: \&quot;string\&quot;   },   {     \&quot;targetId\&quot;: \&quot;string\&quot;,     \&quot;assocType\&quot;: \&quot;string\&quot;   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="nodeId">The identifier of a source node.</param> 
        /// <param name="associationBodyCreate">The target node id and assoc type.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>AssociationEntry</returns>            
        public AssociationEntry CreateAssociation (string nodeId, AssociationBody associationBodyCreate, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling CreateAssociation");
            
            // verify the required parameter 'associationBodyCreate' is set
            if (associationBodyCreate == null) throw new ApiException(400, "Missing required parameter 'associationBodyCreate' when calling CreateAssociation");
            
    
            var path = "/nodes/{nodeId}/targets";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(associationBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateAssociation: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateAssociation: " + response.ErrorMessage, response.ErrorMessage);
    
            return (AssociationEntry) ApiClient.Deserialize(response.Content, typeof(AssociationEntry), response.Headers);
        }
    
        /// <summary>
        /// Create a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Create a node and add it as a primary child of node **nodeId**.  This endpoint supports both JSON and multipart/form-data (file upload).  **Using multipart/form-data**  Use the **filedata** field to represent the content to upload, for example, the following curl command will create a node with the contents of test.txt in the test user&#39;s home folder.  &#x60;&#x60;&#x60;curl -utest:test -X POST host:port/alfresco/api/-default-/public/alfresco/versions/1/nodes/-my-/children -F filedata&#x3D;@test.txt&#x60;&#x60;&#x60;  You can use the **name** field to give an alternative name for the new file.  You can use the **nodeType** field to create a specific type. The default is cm:content.  You can use the **renditions** field to create renditions (e.g. doclib) asynchronously upon upload. Note that currently only one rendition can be requested. Also, as requesting rendition is a background process, any rendition failure (e.g. No transformer is currently available) will not fail the whole upload and has the potential to silently fail.  Use **overwrite** to overwrite an existing file, matched by name. If the file is versionable, the existing content is replaced.  When you overwrite existing content, you can set the **majorVersion** boolean field to **true** to indicate a major version should be created. The default for **majorVersion** is **false**. Setting  **majorVersion** enables versioning of the node, if it is not already versioned.  When you overwrite existing content, you can use the **comment** field to add a version comment that appears in the version history. This also enables versioning of this node, if it is not already versioned.  You can set the **autoRename** boolean field to automatically resolve name clashes. If there is a name clash, then the API method tries to create a unique name using an integer suffix.  You can use the **relativePath** field to specify the folder structure to create relative to the node **nodeId**. Folders in the **relativePath** that do not exist are created before the node is created.  Any other field provided will be treated as a property to set on the newly created node.  **Note:** setting properties of type d:content and d:category are not supported.  **Using JSON**  You must specify at least a **name** and **nodeType**. For example, to create a folder: &#x60;&#x60;&#x60;JSON {   \&quot;name\&quot;:\&quot;My Folder\&quot;,   \&quot;nodeType\&quot;:\&quot;cm:folder\&quot; } &#x60;&#x60;&#x60;  You can create an empty file like this: &#x60;&#x60;&#x60;JSON {   \&quot;name\&quot;:\&quot;My text file.txt\&quot;,   \&quot;nodeType\&quot;:\&quot;cm:content\&quot; } &#x60;&#x60;&#x60; You can update binary content using the &#x60;&#x60;&#x60;PUT /nodes/{nodeId}&#x60;&#x60;&#x60; API method.  You can create a folder, or other node, inside a folder hierarchy: &#x60;&#x60;&#x60;JSON {   \&quot;name\&quot;:\&quot;My Special Folder\&quot;,   \&quot;nodeType\&quot;:\&quot;cm:folder\&quot;,   \&quot;relativePath\&quot;:\&quot;X/Y/Z\&quot; } &#x60;&#x60;&#x60; The **relativePath** specifies the folder structure to create relative to the node **nodeId**. Folders in the **relativePath** that do not exist are created before the node is created.  You can set properties when you create a new node: &#x60;&#x60;&#x60;JSON {   \&quot;name\&quot;:\&quot;My Other Folder\&quot;,   \&quot;nodeType\&quot;:\&quot;cm:folder\&quot;,   \&quot;properties\&quot;:   {     \&quot;cm:title\&quot;:\&quot;Folder title\&quot;,     \&quot;cm:description\&quot;:\&quot;This is an important folder\&quot;   } } &#x60;&#x60;&#x60; Any missing aspects are applied automatically. For example, **cm:titled** in the JSON shown above. You can set aspects explicitly, if needed, using an **aspectNames** field.  **Note:** setting properties of type d:content and d:category are not supported.  Typically, for files and folders, the primary children are created within the parent folder using the default \&quot;cm:contains\&quot; assocType. If the content model allows then it is also possible to create primary children with a different assoc type. For example: &#x60;&#x60;&#x60;JSON {   \&quot;name\&quot;:\&quot;My Node\&quot;,   \&quot;nodeType\&quot;:\&quot;my:specialNodeType\&quot;,   \&quot;association\&quot;:   {     \&quot;assocType\&quot;:\&quot;my:specialAssocType\&quot;   } } &#x60;&#x60;&#x60;  Additional associations can be added after creating a node. You can also add associations at the time the node is created. This is required, for example, if the content model specifies that a node has mandatory associations to one or more existing nodes. You can optionally specify an array of **secondaryChildren** to create one or more secondary child associations, such that the newly created node acts as a parent node. You can optionally specify an array of **targets** to create one or more peer associations such that the newly created node acts as a source node. For example, to associate one or more secondary children at time of creation: &#x60;&#x60;&#x60;JSON {   \&quot;name\&quot;:\&quot;My Folder\&quot;,   \&quot;nodeType\&quot;:\&quot;cm:folder\&quot;,   \&quot;secondaryChildren\&quot;:     [ {\&quot;childId\&quot;:\&quot;abcde-01234-...\&quot;, \&quot;assocType\&quot;:\&quot;my:specialChildAssocType\&quot;} ] } &#x60;&#x60;&#x60; For example, to associate one or more targets at time of creation: &#x60;&#x60;&#x60;JSON {   \&quot;name\&quot;:\&quot;My Folder\&quot;,   \&quot;nodeType\&quot;:\&quot;cm:folder\&quot;,   \&quot;targets\&quot;:     [ {\&quot;targetId\&quot;:\&quot;abcde-01234-...\&quot;, \&quot;assocType\&quot;:\&quot;my:specialPeerAssocType\&quot;} ] } &#x60;&#x60;&#x60;  **Note:** You can create more than one child by specifying a list of nodes in the JSON body. For example, the following JSON body creates two folders inside the specified **nodeId**, if the **nodeId** identifies a folder:  &#x60;&#x60;&#x60;JSON [   {     \&quot;name\&quot;:\&quot;My Folder 1\&quot;,     \&quot;nodeType\&quot;:\&quot;cm:folder\&quot;   },   {     \&quot;name\&quot;:\&quot;My Folder 2\&quot;,     \&quot;nodeType\&quot;:\&quot;cm:folder\&quot;   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="nodeId">The identifier of a node. You can also use one of these well-known aliases: * -my- * -shared- * -root- </param> 
        /// <param name="nodeBodyCreate">The node information to create.</param> 
        /// <param name="autoRename">If true, then  a name clash will cause an attempt to auto rename by finding a unique name using an integer suffix.</param> 
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * association * isLink * isFavorite * isLocked * path * permissions </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>NodeEntry</returns>            
        public NodeEntry CreateNode (string nodeId, NodeBodyCreate nodeBodyCreate, bool? autoRename, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling CreateNode");
            
            // verify the required parameter 'nodeBodyCreate' is set
            if (nodeBodyCreate == null) throw new ApiException(400, "Missing required parameter 'nodeBodyCreate' when calling CreateNode");
            
    
            var path = "/nodes/{nodeId}/children";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (autoRename != null) queryParams.Add("autoRename", ApiClient.ParameterToString(autoRename)); // query parameter
 if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(nodeBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateNode: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateNode: " + response.ErrorMessage, response.ErrorMessage);
    
            return (NodeEntry) ApiClient.Deserialize(response.Content, typeof(NodeEntry), response.Headers);
        }
    
        /// <summary>
        /// Create secondary child **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Create a secondary child association, with the given association type, between the parent **nodeId** and a child node.  **Note:** You can create more than one secondary child association by specifying a list of associations in the JSON body like this:  &#x60;&#x60;&#x60;JSON [   {     \&quot;childId\&quot;: \&quot;string\&quot;,     \&quot;assocType\&quot;: \&quot;string\&quot;   },   {     \&quot;childId\&quot;: \&quot;string\&quot;,     \&quot;assocType\&quot;: \&quot;string\&quot;   } ] &#x60;&#x60;&#x60; If you specify a list as input, then a paginated list rather than an entry is returned in the response body. For example:  &#x60;&#x60;&#x60;JSON {   \&quot;list\&quot;: {     \&quot;pagination\&quot;: {       \&quot;count\&quot;: 2,       \&quot;hasMoreItems\&quot;: false,       \&quot;totalItems\&quot;: 2,       \&quot;skipCount\&quot;: 0,       \&quot;maxItems\&quot;: 100     },     \&quot;entries\&quot;: [       {         \&quot;entry\&quot;: {           ...         }       },       {         \&quot;entry\&quot;: {           ...         }       }     ]   } } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="nodeId">The identifier of a parent node.</param> 
        /// <param name="secondaryChildAssociationBodyCreate">The child node id and assoc type.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>ChildAssociationEntry</returns>            
        public ChildAssociationEntry CreateSecondaryChildAssociation (string nodeId, ChildAssociationBody secondaryChildAssociationBodyCreate, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling CreateSecondaryChildAssociation");
            
            // verify the required parameter 'secondaryChildAssociationBodyCreate' is set
            if (secondaryChildAssociationBodyCreate == null) throw new ApiException(400, "Missing required parameter 'secondaryChildAssociationBodyCreate' when calling CreateSecondaryChildAssociation");
            
    
            var path = "/nodes/{nodeId}/secondary-children";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(secondaryChildAssociationBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateSecondaryChildAssociation: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateSecondaryChildAssociation: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ChildAssociationEntry) ApiClient.Deserialize(response.Content, typeof(ChildAssociationEntry), response.Headers);
        }
    
        /// <summary>
        /// Delete node association(s) **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Delete an association, or associations, from the source **nodeId* to a target node for the given association type.  If the association type is **not** specified, then all peer associations, of any type, in the direction from source to target, are deleted.  **Note:** After removal of the peer association, or associations, from source to target, the two nodes may still have peer associations in the other direction. 
        /// </summary>
        /// <param name="nodeId">The identifier of a source node.</param> 
        /// <param name="targetId">The identifier of a target node.</param> 
        /// <param name="assocType">Only delete associations of this type.</param> 
        /// <returns></returns>            
        public void DeleteAssociation (string nodeId, string targetId, string assocType)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling DeleteAssociation");
            
            // verify the required parameter 'targetId' is set
            if (targetId == null) throw new ApiException(400, "Missing required parameter 'targetId' when calling DeleteAssociation");
            
    
            var path = "/nodes/{nodeId}/targets/{targetId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
path = path.Replace("{" + "targetId" + "}", ApiClient.ParameterToString(targetId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (assocType != null) queryParams.Add("assocType", ApiClient.ParameterToString(assocType)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteAssociation: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteAssociation: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Delete a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Deletes the node **nodeId**.  If **nodeId** is a folder, then its children are also deleted.  Deleted nodes move to the trashcan unless the **permanent** query parameter is **true** and the current user is the owner of the node or an admin.  Deleting a node deletes it from its primary parent and also from any secondary parents. Peer associations are also deleted, where the deleted node is either a source or target of an association. This applies recursively to any hierarchy of primary children of the deleted node.  **Note:** If the node is not permanently deleted, and is later successfully restored to its former primary parent, then the primary child association is restored. This applies recursively for any primary children. No other secondary child associations or peer associations are restored for any of the nodes in the primary parent-child hierarchy of restored nodes, regardless of whether the original associations were to nodes inside or outside the restored hierarchy. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="permanent">If **true** then the node is deleted permanently, without moving to the trashcan. Only the owner of the node or an admin can permanently delete the node. </param> 
        /// <returns></returns>            
        public void DeleteNode (string nodeId, bool? permanent)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling DeleteNode");
            
    
            var path = "/nodes/{nodeId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteNode: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteNode: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Delete secondary child or children **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Delete secondary child associations between the parent **nodeId** and child nodes for the given association type.  If the association type is **not** specified, then all secondary child associations, of any type in the direction from parent to secondary child, will be deleted. The child will still have a primary parent and may still be associated as a secondary child with other secondary parents. 
        /// </summary>
        /// <param name="nodeId">The identifier of a parent node.</param> 
        /// <param name="childId">The identifier of a child node.</param> 
        /// <param name="assocType">Only delete associations of this type.</param> 
        /// <returns></returns>            
        public void DeleteSecondaryChildAssociation (string nodeId, string childId, string assocType)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling DeleteSecondaryChildAssociation");
            
            // verify the required parameter 'childId' is set
            if (childId == null) throw new ApiException(400, "Missing required parameter 'childId' when calling DeleteSecondaryChildAssociation");
            
    
            var path = "/nodes/{nodeId}/secondary-children/{childId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
path = path.Replace("{" + "childId" + "}", ApiClient.ParameterToString(childId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (assocType != null) queryParams.Add("assocType", ApiClient.ParameterToString(assocType)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteSecondaryChildAssociation: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteSecondaryChildAssociation: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Get information for node **nodeId**.  You can use the **include** parameter to return additional information. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node. You can also use one of these well-known aliases: * -my- * -shared- * -root- </param> 
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * association * isLink * isFavorite * isLocked * path * permissions </param> 
        /// <param name="relativePath">A path relative to the **nodeId**. If you set this, information is returned on the node resolved by this path. </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>NodeEntry</returns>            
        public NodeEntry GetNode (string nodeId, List<string> include, string relativePath, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling GetNode");
            
    
            var path = "/nodes/{nodeId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (relativePath != null) queryParams.Add("relativePath", ApiClient.ParameterToString(relativePath)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetNode: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetNode: " + response.ErrorMessage, response.ErrorMessage);
    
            return (NodeEntry) ApiClient.Deserialize(response.Content, typeof(NodeEntry), response.Headers);
        }
    
        /// <summary>
        /// Get node content **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets the content of the node with identifier **nodeId**. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="attachment">**true** enables a web browser to download the file as an attachment. **false** means a web browser may preview the file in a new tab or window, but not download the file.  You can only set this parameter to **false** if the content type of the file is in the supported list; for example, certain image files and PDF files.  If the content type is not supported for preview, then a value of **false**  is ignored, and the attachment will be returned in the response. </param> 
        /// <param name="ifModifiedSince">Only returns the content if it has been modified since the date provided. Use the date format defined by HTTP. For example, &#x60;Wed, 09 Mar 2016 16:56:34 GMT&#x60;. </param> 
        /// <param name="range">The Range header indicates the part of a document that the server should return. Single part request supported, for example: bytes&#x3D;1-10. </param> 
        /// <returns></returns>            
        public void GetNodeContent (string nodeId, bool? attachment, DateTime? ifModifiedSince, string range)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling GetNodeContent");
            
    
            var path = "/nodes/{nodeId}/content";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetNodeContent: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetNodeContent: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// List node children **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets a list of children of the parent node **nodeId**.  Minimal information for each child is returned by default.  You can use the **include** parameter to return additional information.  The list of child nodes includes primary children and secondary children, if there are any.  You can use the **include** parameter (include&#x3D;association) to return child association details for each child, including the **assocTyp**e and the **isPrimary** flag.  The default sort order for the returned list is for folders to be sorted before files, and by ascending name.  You can override the default using **orderBy** to specify one or more fields to sort by. The default order is always ascending, but you can use an optional **ASC** or **DESC** modifier to specify an ascending or descending sort order.  For example, specifying &#x60;&#x60;&#x60;orderBy&#x3D;name DESC&#x60;&#x60;&#x60; returns a mixed folder/file list in descending **name** order.  You can use any of the following fields to order the results: * isFolder * name * mimeType * nodeType * sizeInBytes * modifiedAt * createdAt * modifiedByUser * createdByUser 
        /// </summary>
        /// <param name="nodeId">The identifier of a node. You can also use one of these well-known aliases: * -my- * -shared- * -root- </param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param> 
        /// <param name="where">Optionally filter the list. Here are some examples:  *   &#x60;&#x60;&#x60;where&#x3D;(isFolder&#x3D;true)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(isFile&#x3D;true)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(nodeType&#x3D;&#39;my:specialNodeType&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(nodeType&#x3D;&#39;my:specialNodeType INCLUDESUBTYPES&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(isPrimary&#x3D;true)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(assocType&#x3D;&#39;my:specialAssocType&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(isPrimary&#x3D;false and assocType&#x3D;&#39;my:specialAssocType&#39;)&#x60;&#x60;&#x60; </param> 
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * aspectNames * association * isLink * isFavorite * isLocked * path * properties * permissions </param> 
        /// <param name="relativePath">Return information on children in the folder resolved by this path. The path is relative to **nodeId**.</param> 
        /// <param name="includeSource">Also include **source** in addition to **entries** with folder information on the parent node – either the specified parent **nodeId**, or as resolved by **relativePath**.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>NodeChildAssociationPaging</returns>            
        public NodeChildAssociationPaging ListNodeChildren (string nodeId, int? skipCount, int? maxItems, List<string> orderBy, string where, List<string> include, string relativePath, bool? includeSource, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling ListNodeChildren");
            
    
            var path = "/nodes/{nodeId}/children";
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
 if (where != null) queryParams.Add("where", ApiClient.ParameterToString(where)); // query parameter
 if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (relativePath != null) queryParams.Add("relativePath", ApiClient.ParameterToString(relativePath)); // query parameter
 if (includeSource != null) queryParams.Add("includeSource", ApiClient.ParameterToString(includeSource)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListNodeChildren: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListNodeChildren: " + response.ErrorMessage, response.ErrorMessage);
    
            return (NodeChildAssociationPaging) ApiClient.Deserialize(response.Content, typeof(NodeChildAssociationPaging), response.Headers);
        }
    
        /// <summary>
        /// List parents **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets a list of parent nodes that are associated with the current child **nodeId**.  The list includes both the primary parent and any secondary parents. 
        /// </summary>
        /// <param name="nodeId">The identifier of a child node. You can also use one of these well-known aliases: * -my- * -shared- * -root- </param> 
        /// <param name="where">Optionally filter the list by **assocType** and/or **isPrimary**. Here are some example filters:  *   &#x60;&#x60;&#x60;where&#x3D;(assocType&#x3D;&#39;my:specialAssocType&#39;)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(isPrimary&#x3D;true)&#x60;&#x60;&#x60;  *   &#x60;&#x60;&#x60;where&#x3D;(isPrimary&#x3D;false and assocType&#x3D;&#39;my:specialAssocType&#39;)&#x60;&#x60;&#x60; </param> 
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * aspectNames * isLink * isFavorite * isLocked * path * properties </param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="includeSource">Also include **source** (in addition to **entries**) with folder information on **nodeId**</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>NodeAssociationPaging</returns>            
        public NodeAssociationPaging ListParents (string nodeId, string where, List<string> include, int? skipCount, int? maxItems, bool? includeSource, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling ListParents");
            
    
            var path = "/nodes/{nodeId}/parents";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (where != null) queryParams.Add("where", ApiClient.ParameterToString(where)); // query parameter
 if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (skipCount != null) queryParams.Add("skipCount", ApiClient.ParameterToString(skipCount)); // query parameter
 if (maxItems != null) queryParams.Add("maxItems", ApiClient.ParameterToString(maxItems)); // query parameter
 if (includeSource != null) queryParams.Add("includeSource", ApiClient.ParameterToString(includeSource)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListParents: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListParents: " + response.ErrorMessage, response.ErrorMessage);
    
            return (NodeAssociationPaging) ApiClient.Deserialize(response.Content, typeof(NodeAssociationPaging), response.Headers);
        }
    
        /// <summary>
        /// List secondary children **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets a list of secondary child nodes that are associated with the current parent **nodeId**, via a secondary child association. 
        /// </summary>
        /// <param name="nodeId">The identifier of a parent node. You can also use one of these well-known aliases: * -my- * -shared- * -root- </param> 
        /// <param name="where">Optionally filter the list by assocType. Here&#39;s an example:  *   &#x60;&#x60;&#x60;where&#x3D;(assocType&#x3D;&#39;my:specialAssocType&#39;)&#x60;&#x60;&#x60; </param> 
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * aspectNames * isLink * isFavorite * isLocked * path * properties </param> 
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="includeSource">Also include **source** (in addition to **entries**) with folder information on **nodeId**</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>NodeChildAssociationPaging</returns>            
        public NodeChildAssociationPaging ListSecondaryChildren (string nodeId, string where, List<string> include, int? skipCount, int? maxItems, bool? includeSource, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling ListSecondaryChildren");
            
    
            var path = "/nodes/{nodeId}/secondary-children";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (where != null) queryParams.Add("where", ApiClient.ParameterToString(where)); // query parameter
 if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (skipCount != null) queryParams.Add("skipCount", ApiClient.ParameterToString(skipCount)); // query parameter
 if (maxItems != null) queryParams.Add("maxItems", ApiClient.ParameterToString(maxItems)); // query parameter
 if (includeSource != null) queryParams.Add("includeSource", ApiClient.ParameterToString(includeSource)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListSecondaryChildren: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListSecondaryChildren: " + response.ErrorMessage, response.ErrorMessage);
    
            return (NodeChildAssociationPaging) ApiClient.Deserialize(response.Content, typeof(NodeChildAssociationPaging), response.Headers);
        }
    
        /// <summary>
        /// List source associations **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets a list of source nodes that are associated with the current target **nodeId**. 
        /// </summary>
        /// <param name="nodeId">The identifier of a target node.</param> 
        /// <param name="where">Optionally filter the list by **assocType**. Here&#39;s an example:  *   &#x60;&#x60;&#x60;where&#x3D;(assocType&#x3D;&#39;my:specialAssocType&#39;)&#x60;&#x60;&#x60; </param> 
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * aspectNames * isLink * isFavorite * isLocked * path * properties </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>NodeAssociationPaging</returns>            
        public NodeAssociationPaging ListSourceAssociations (string nodeId, string where, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling ListSourceAssociations");
            
    
            var path = "/nodes/{nodeId}/sources";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (where != null) queryParams.Add("where", ApiClient.ParameterToString(where)); // query parameter
 if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListSourceAssociations: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListSourceAssociations: " + response.ErrorMessage, response.ErrorMessage);
    
            return (NodeAssociationPaging) ApiClient.Deserialize(response.Content, typeof(NodeAssociationPaging), response.Headers);
        }
    
        /// <summary>
        /// List target associations **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Gets a list of target nodes that are associated with the current source **nodeId**. 
        /// </summary>
        /// <param name="nodeId">The identifier of a source node.</param> 
        /// <param name="where">Optionally filter the list by **assocType**. Here&#39;s an example:  *   &#x60;&#x60;&#x60;where&#x3D;(assocType&#x3D;&#39;my:specialAssocType&#39;)&#x60;&#x60;&#x60; </param> 
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * aspectNames * isLink * isFavorite * isLocked * path * properties </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>NodeAssociationPaging</returns>            
        public NodeAssociationPaging ListTargetAssociations (string nodeId, string where, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling ListTargetAssociations");
            
    
            var path = "/nodes/{nodeId}/targets";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (where != null) queryParams.Add("where", ApiClient.ParameterToString(where)); // query parameter
 if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListTargetAssociations: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListTargetAssociations: " + response.ErrorMessage, response.ErrorMessage);
    
            return (NodeAssociationPaging) ApiClient.Deserialize(response.Content, typeof(NodeAssociationPaging), response.Headers);
        }
    
        /// <summary>
        /// Lock a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Places a lock on node **nodeId**.  **Note:** you can only lock files. More specifically, a node can only be locked if it is of type &#x60;cm:content&#x60; or a subtype of &#x60;cm:content&#x60;.  The lock is owned by the current user, and prevents other users or processes from making updates to the node until the lock is released.  If the **timeToExpire** is not set or is zero, then the lock never expires.  Otherwise, the **timeToExpire** is the number of seconds before the lock expires.  When a lock expires, the lock is released.  If the node is already locked, and the user is the lock owner, then the lock is renewed with the new **timeToExpire**.  By default, a lock is applied that allows the owner to update or delete the node. You can use **type** to change the lock type to one of the following: * **ALLOW_OWNER_CHANGES** (default) changes to the node can be made only by the lock owner. This enum is the same value as the deprecated WRITE_LOCK described in &#x60;org.alfresco.service.cmr.lock.LockType&#x60; in the Alfresco Public Java API. This is the default value. * **FULL** no changes by any user are allowed. This enum is the same value as the deprecated READ_ONLY_LOCK described in &#x60;org.alfresco.service.cmr.lock.LockType&#x60; in the Alfresco Public Java API.  By default, a lock is persisted in the database. You can create a volatile in-memory lock by setting the **lifetime** property to EPHEMERAL. You might choose use EPHEMERAL locks, for example, if you are taking frequent short-term locks that you don&#39;t need to be kept over a restart of the repository. In this case you don&#39;t need the overhead of writing the locks to the database.  If a lock on the node cannot be taken, then an error is returned. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="nodeBodyLock">Lock details.</param> 
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * association * isLink * isFavorite * isLocked * path * permissions </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>NodeEntry</returns>            
        public NodeEntry LockNode (string nodeId, NodeBodyLock nodeBodyLock, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling LockNode");
            
            // verify the required parameter 'nodeBodyLock' is set
            if (nodeBodyLock == null) throw new ApiException(400, "Missing required parameter 'nodeBodyLock' when calling LockNode");
            
    
            var path = "/nodes/{nodeId}/lock";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(nodeBodyLock); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling LockNode: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling LockNode: " + response.ErrorMessage, response.ErrorMessage);
    
            return (NodeEntry) ApiClient.Deserialize(response.Content, typeof(NodeEntry), response.Headers);
        }
    
        /// <summary>
        /// Move a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Move the node **nodeId** to the parent folder node **targetParentId**.  The **targetParentId** is specified in the in request body.  The moved node retains its name unless you specify a new **name** in the request body.  If the source **nodeId** is a folder, then its children are also moved.  The move will effectively change the primary parent. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="nodeBodyMove">The targetParentId and, optionally, a new name which should include the file extension.</param> 
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * association * isLink * isFavorite * isLocked * path * permissions </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>NodeEntry</returns>            
        public NodeEntry MoveNode (string nodeId, NodeBodyMove nodeBodyMove, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling MoveNode");
            
            // verify the required parameter 'nodeBodyMove' is set
            if (nodeBodyMove == null) throw new ApiException(400, "Missing required parameter 'nodeBodyMove' when calling MoveNode");
            
    
            var path = "/nodes/{nodeId}/move";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(nodeBodyMove); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling MoveNode: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling MoveNode: " + response.ErrorMessage, response.ErrorMessage);
    
            return (NodeEntry) ApiClient.Deserialize(response.Content, typeof(NodeEntry), response.Headers);
        }
    
        /// <summary>
        /// Unlock a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Deletes a lock on node **nodeId**.  The current user must be the owner of the locks or have admin rights, otherwise an error is returned.  If a lock on the node cannot be released, then an error is returned. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * association * isLink * isFavorite * isLocked * path * permissions </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>NodeEntry</returns>            
        public NodeEntry UnlockNode (string nodeId, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling UnlockNode");
            
    
            var path = "/nodes/{nodeId}/unlock";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
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
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling UnlockNode: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling UnlockNode: " + response.ErrorMessage, response.ErrorMessage);
    
            return (NodeEntry) ApiClient.Deserialize(response.Content, typeof(NodeEntry), response.Headers);
        }
    
        /// <summary>
        /// Update a node **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Updates the node **nodeId**. For example, you can rename a file or folder: &#x60;&#x60;&#x60;JSON {   \&quot;name\&quot;:\&quot;My new name\&quot; } &#x60;&#x60;&#x60; You can also set or update one or more properties: &#x60;&#x60;&#x60;JSON {   \&quot;properties\&quot;:   {     \&quot;cm:title\&quot;:\&quot;Folder title\&quot;   } } &#x60;&#x60;&#x60; **Note:** setting properties of type d:content and d:category are not supported.  **Note:** if you want to add or remove aspects, then you must use **GET /nodes/{nodeId}** first to get the complete set of *aspectNames*.  You can add (or remove) *locallySet* permissions, if any, in addition to any inherited permissions. You can also optionally disable (or re-enable) inherited permissions via *isInheritanceEnabled* flag: &#x60;&#x60;&#x60;JSON {   \&quot;permissions\&quot;:     {       \&quot;isInheritanceEnabled\&quot;: false,       \&quot;locallySet\&quot;:         [           {\&quot;authorityId\&quot;: \&quot;GROUP_special\&quot;, \&quot;name\&quot;: \&quot;Read\&quot;, \&quot;accessStatus\&quot;:\&quot;DENIED\&quot;},           {\&quot;authorityId\&quot;: \&quot;testuser\&quot;, \&quot;name\&quot;: \&quot;Contributor\&quot;, \&quot;accessStatus\&quot;:\&quot;ALLOWED\&quot;}         ]     } } &#x60;&#x60;&#x60; **Note:** if you want to add or remove locally set permissions then you must use **GET /nodes/{nodeId}** first to get the complete set of *locallySet* permissions.  **Note:** Currently there is no optimistic locking for updates, so they are applied in \&quot;last one wins\&quot; order. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="nodeBodyUpdate">The node information to update.</param> 
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * association * isLink * isFavorite * isLocked * path * permissions </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>NodeEntry</returns>            
        public NodeEntry UpdateNode (string nodeId, NodeBodyUpdate nodeBodyUpdate, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling UpdateNode");
            
            // verify the required parameter 'nodeBodyUpdate' is set
            if (nodeBodyUpdate == null) throw new ApiException(400, "Missing required parameter 'nodeBodyUpdate' when calling UpdateNode");
            
    
            var path = "/nodes/{nodeId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(nodeBodyUpdate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateNode: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateNode: " + response.ErrorMessage, response.ErrorMessage);
    
            return (NodeEntry) ApiClient.Deserialize(response.Content, typeof(NodeEntry), response.Headers);
        }
    
        /// <summary>
        /// Update node content **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Updates the content of the node with identifier **nodeId**.  The request body for this endpoint can be any text or binary stream.  The **majorVersion** and **comment** parameters can be used to control versioning behaviour. If the content is versionable, a new minor version is created by default.  Optionally a new **name** parameter can also be specified that must be unique within the parent folder. If specified and valid then this will rename the node. If invalid then an error is returned and the content is not updated.  **Note:** This API method accepts any content type, but for testing with this tool text based content can be provided. This is because the OpenAPI Specification does not allow a wildcard to be provided or the ability for tooling to accept an arbitrary file. 
        /// </summary>
        /// <param name="nodeId">The identifier of a node.</param> 
        /// <param name="contentBodyUpdate">The binary content</param> 
        /// <param name="majorVersion">If **true**, create a major version. Setting this parameter also enables versioning of this node, if it is not already versioned. </param> 
        /// <param name="comment">Add a version comment which will appear in version history. Setting this parameter also enables versioning of this node, if it is not already versioned. </param> 
        /// <param name="name">Optional new name. This should include the file extension. The name must not contain spaces or the following special characters: * \&quot; &lt; &gt; \\ / ? : and |. The character &#x60;.&#x60; must not be used at the end of the name. </param> 
        /// <param name="include">Returns additional information about the node. The following optional fields can be requested: * allowableOperations * association * isLink * isFavorite * isLocked * path * permissions </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>NodeEntry</returns>            
        public NodeEntry UpdateNodeContent (string nodeId, byte[] contentBodyUpdate, bool? majorVersion, string comment, string name, List<string> include, List<string> fields)
        {
            
            // verify the required parameter 'nodeId' is set
            if (nodeId == null) throw new ApiException(400, "Missing required parameter 'nodeId' when calling UpdateNodeContent");
            
            // verify the required parameter 'contentBodyUpdate' is set
            if (contentBodyUpdate == null) throw new ApiException(400, "Missing required parameter 'contentBodyUpdate' when calling UpdateNodeContent");
            
    
            var path = "/nodes/{nodeId}/content";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "nodeId" + "}", ApiClient.ParameterToString(nodeId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (majorVersion != null) queryParams.Add("majorVersion", ApiClient.ParameterToString(majorVersion)); // query parameter
 if (comment != null) queryParams.Add("comment", ApiClient.ParameterToString(comment)); // query parameter
 if (name != null) queryParams.Add("name", ApiClient.ParameterToString(name)); // query parameter
 if (include != null) queryParams.Add("include", ApiClient.ParameterToString(include)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(contentBodyUpdate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateNodeContent: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateNodeContent: " + response.ErrorMessage, response.ErrorMessage);
    
            return (NodeEntry) ApiClient.Deserialize(response.Content, typeof(NodeEntry), response.Headers);
        }
    
    }
}
