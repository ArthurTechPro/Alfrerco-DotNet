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
    public interface IPeopleApi
    {
        /// <summary>
        /// Create person **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Create a person.  If applicable, the given person&#39;s login access can also be optionally disabled.  You must have admin rights to create a person.  You can set custom properties when you create a person: &#x60;&#x60;&#x60;JSON {   \&quot;id\&quot;: \&quot;abeecher\&quot;,   \&quot;firstName\&quot;: \&quot;Alice\&quot;,   \&quot;lastName\&quot;: \&quot;Beecher\&quot;,   \&quot;email\&quot;: \&quot;abeecher@example.com\&quot;,   \&quot;password\&quot;: \&quot;secret\&quot;,   \&quot;properties\&quot;:   {     \&quot;my:property\&quot;: \&quot;The value\&quot;   } } &#x60;&#x60;&#x60; **Note:** setting properties of type d:content and d:category are not supported. 
        /// </summary>
        /// <param name="personBodyCreate">The person details.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>PersonEntry</returns>
        PersonEntry CreatePerson (PersonBodyCreate personBodyCreate, List<string> fields);
        /// <summary>
        /// Delete avatar image **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Deletes the avatar image related to person **personId**.  You must be the person or have admin rights to update a person&#39;s avatar.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <returns></returns>
        void DeleteAvatarImage (string personId);
        /// <summary>
        /// Get avatar image **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Gets the avatar image related to the person **personId**. If the person has no related avatar then the **placeholder** query parameter can be optionally used to request a placeholder image to be returned.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="attachment">**true** enables a web browser to download the file as an attachment. **false** means a web browser may preview the file in a new tab or window, but not download the file.  You can only set this parameter to **false** if the content type of the file is in the supported list; for example, certain image files and PDF files.  If the content type is not supported for preview, then a value of **false**  is ignored, and the attachment will be returned in the response. </param>
        /// <param name="ifModifiedSince">Only returns the content if it has been modified since the date provided. Use the date format defined by HTTP. For example, &#x60;Wed, 09 Mar 2016 16:56:34 GMT&#x60;. </param>
        /// <param name="placeholder">If **true** and there is no avatar for this **personId** then the placeholder image is returned, rather than a 404 response. </param>
        /// <returns></returns>
        void GetAvatarImage (string personId, bool? attachment, DateTime? ifModifiedSince, bool? placeholder);
        /// <summary>
        /// Get a person Gets information for the person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>PersonEntry</returns>
        PersonEntry GetPerson (string personId, List<string> fields);
        /// <summary>
        /// List people **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  List people.  You can use the **include** parameter to return any additional information.  The default sort order for the returned list is for people to be sorted by ascending id. You can override the default by using the **orderBy** parameter.  You can use any of the following fields to order the results: * id * firstName * lastName 
        /// </summary>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param>
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param>
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param>
        /// <param name="include">Returns additional information about the person. The following optional fields can be requested: * properties * aspectNames * capabilities </param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>PersonPaging</returns>
        PersonPaging ListPeople (int? skipCount, int? maxItems, List<string> orderBy, List<string> include, List<string> fields);
        /// <summary>
        /// Request password reset **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Initiates the reset password workflow to send an email with reset password instruction to the user&#39;s registered email.  The client is mandatory in the request body. For example: &#x60;&#x60;&#x60;JSON {   \&quot;client\&quot;: \&quot;myClient\&quot; } &#x60;&#x60;&#x60; **Note:** The client must be registered before this API can send an email. See [server documentation]. However, out-of-the-box share is registered as a default client, so you could pass **share** as the client name: &#x60;&#x60;&#x60;JSON {   \&quot;client\&quot;: \&quot;share\&quot; } &#x60;&#x60;&#x60; **Note:** No authentication is required to call this endpoint. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="clientBody">The client name to send email with app-specific url.</param>
        /// <returns></returns>
        void RequestPasswordReset (string personId, ClientBody clientBody);
        /// <summary>
        /// Reset password **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Resets user&#39;s password  The password, id and key properties are mandatory in the request body. For example: &#x60;&#x60;&#x60;JSON {   \&quot;password\&quot;:\&quot;newPassword\&quot;,   \&quot;id\&quot;:\&quot;activiti$10\&quot;,   \&quot;key\&quot;:\&quot;4dad6d00-0daf-413a-b200-f64af4e12345\&quot; } &#x60;&#x60;&#x60; **Note:** No authentication is required to call this endpoint. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="passwordResetBody">The reset password details</param>
        /// <returns></returns>
        void ResetPassword (string personId, PasswordResetBody passwordResetBody);
        /// <summary>
        /// Update avatar image **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Updates the avatar image related to the person **personId**.  The request body should be the binary stream for the avatar image. The content type of the file should be an image file. This will be used to generate an \&quot;avatar\&quot; thumbnail rendition.  You must be the person or have admin rights to update a person&#39;s avatar.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="contentBodyUpdate">The binary content</param>
        /// <returns></returns>
        void UpdateAvatarImage (string personId, byte[] contentBodyUpdate);
        /// <summary>
        /// Update person **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Update the given person&#39;s details.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user.  If applicable, the given person&#39;s login access can also be optionally disabled or re-enabled.  You must have admin rights to update a person — unless updating your own details.  If you are changing your password, as a non-admin user, then the existing password must also be supplied (using the oldPassword field in addition to the new password value).  Admin users cannot be disabled by setting enabled to false.  Non-admin users may not disable themselves.  You can set custom properties when you update a person: &#x60;&#x60;&#x60;JSON {   \&quot;firstName\&quot;: \&quot;Alice\&quot;,   \&quot;properties\&quot;:   {     \&quot;my:property\&quot;: \&quot;The value\&quot;   } } &#x60;&#x60;&#x60; **Note:** setting properties of type d:content and d:category are not supported. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param>
        /// <param name="personBodyUpdate">The person details.</param>
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param>
        /// <returns>PersonEntry</returns>
        PersonEntry UpdatePerson (string personId, PersonBodyUpdate personBodyUpdate, List<string> fields);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PeopleApi : IPeopleApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public PeopleApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PeopleApi(String basePath)
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
        /// Create person **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Create a person.  If applicable, the given person&#39;s login access can also be optionally disabled.  You must have admin rights to create a person.  You can set custom properties when you create a person: &#x60;&#x60;&#x60;JSON {   \&quot;id\&quot;: \&quot;abeecher\&quot;,   \&quot;firstName\&quot;: \&quot;Alice\&quot;,   \&quot;lastName\&quot;: \&quot;Beecher\&quot;,   \&quot;email\&quot;: \&quot;abeecher@example.com\&quot;,   \&quot;password\&quot;: \&quot;secret\&quot;,   \&quot;properties\&quot;:   {     \&quot;my:property\&quot;: \&quot;The value\&quot;   } } &#x60;&#x60;&#x60; **Note:** setting properties of type d:content and d:category are not supported. 
        /// </summary>
        /// <param name="personBodyCreate">The person details.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>PersonEntry</returns>            
        public PersonEntry CreatePerson (PersonBodyCreate personBodyCreate, List<string> fields)
        {
            
            // verify the required parameter 'personBodyCreate' is set
            if (personBodyCreate == null) throw new ApiException(400, "Missing required parameter 'personBodyCreate' when calling CreatePerson");
            
    
            var path = "/people";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(personBodyCreate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreatePerson: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreatePerson: " + response.ErrorMessage, response.ErrorMessage);
    
            return (PersonEntry) ApiClient.Deserialize(response.Content, typeof(PersonEntry), response.Headers);
        }
    
        /// <summary>
        /// Delete avatar image **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Deletes the avatar image related to person **personId**.  You must be the person or have admin rights to update a person&#39;s avatar.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <returns></returns>            
        public void DeleteAvatarImage (string personId)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling DeleteAvatarImage");
            
    
            var path = "/people/{personId}/avatar";
            path = path.Replace("{format}", "json");
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
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteAvatarImage: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeleteAvatarImage: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get avatar image **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Gets the avatar image related to the person **personId**. If the person has no related avatar then the **placeholder** query parameter can be optionally used to request a placeholder image to be returned.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="attachment">**true** enables a web browser to download the file as an attachment. **false** means a web browser may preview the file in a new tab or window, but not download the file.  You can only set this parameter to **false** if the content type of the file is in the supported list; for example, certain image files and PDF files.  If the content type is not supported for preview, then a value of **false**  is ignored, and the attachment will be returned in the response. </param> 
        /// <param name="ifModifiedSince">Only returns the content if it has been modified since the date provided. Use the date format defined by HTTP. For example, &#x60;Wed, 09 Mar 2016 16:56:34 GMT&#x60;. </param> 
        /// <param name="placeholder">If **true** and there is no avatar for this **personId** then the placeholder image is returned, rather than a 404 response. </param> 
        /// <returns></returns>            
        public void GetAvatarImage (string personId, bool? attachment, DateTime? ifModifiedSince, bool? placeholder)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling GetAvatarImage");
            
    
            var path = "/people/{personId}/avatar";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (attachment != null) queryParams.Add("attachment", ApiClient.ParameterToString(attachment)); // query parameter
 if (placeholder != null) queryParams.Add("placeholder", ApiClient.ParameterToString(placeholder)); // query parameter
             if (ifModifiedSince != null) headerParams.Add("If-Modified-Since", ApiClient.ParameterToString(ifModifiedSince)); // header parameter
                            
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAvatarImage: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAvatarImage: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get a person Gets information for the person **personId**.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>PersonEntry</returns>            
        public PersonEntry GetPerson (string personId, List<string> fields)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling GetPerson");
            
    
            var path = "/people/{personId}";
            path = path.Replace("{format}", "json");
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetPerson: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetPerson: " + response.ErrorMessage, response.ErrorMessage);
    
            return (PersonEntry) ApiClient.Deserialize(response.Content, typeof(PersonEntry), response.Headers);
        }
    
        /// <summary>
        /// List people **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  List people.  You can use the **include** parameter to return any additional information.  The default sort order for the returned list is for people to be sorted by ascending id. You can override the default by using the **orderBy** parameter.  You can use any of the following fields to order the results: * id * firstName * lastName 
        /// </summary>
        /// <param name="skipCount">The number of entities that exist in the collection before those included in this list. If not supplied then the default value is 0. </param> 
        /// <param name="maxItems">The maximum number of items to return in the list. If not supplied then the default value is 100. </param> 
        /// <param name="orderBy">A string to control the order of the entities returned in a list. You can use the **orderBy** parameter to sort the list by one or more fields.  Each field has a default sort order, which is normally ascending order. Read the API method implementation notes above to check if any fields used in this method have a descending default search order.  To sort the entities in a specific order, you can use the **ASC** and **DESC** keywords for any field. </param> 
        /// <param name="include">Returns additional information about the person. The following optional fields can be requested: * properties * aspectNames * capabilities </param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>PersonPaging</returns>            
        public PersonPaging ListPeople (int? skipCount, int? maxItems, List<string> orderBy, List<string> include, List<string> fields)
        {
            
    
            var path = "/people";
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
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListPeople: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListPeople: " + response.ErrorMessage, response.ErrorMessage);
    
            return (PersonPaging) ApiClient.Deserialize(response.Content, typeof(PersonPaging), response.Headers);
        }
    
        /// <summary>
        /// Request password reset **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Initiates the reset password workflow to send an email with reset password instruction to the user&#39;s registered email.  The client is mandatory in the request body. For example: &#x60;&#x60;&#x60;JSON {   \&quot;client\&quot;: \&quot;myClient\&quot; } &#x60;&#x60;&#x60; **Note:** The client must be registered before this API can send an email. See [server documentation]. However, out-of-the-box share is registered as a default client, so you could pass **share** as the client name: &#x60;&#x60;&#x60;JSON {   \&quot;client\&quot;: \&quot;share\&quot; } &#x60;&#x60;&#x60; **Note:** No authentication is required to call this endpoint. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="clientBody">The client name to send email with app-specific url.</param> 
        /// <returns></returns>            
        public void RequestPasswordReset (string personId, ClientBody clientBody)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling RequestPasswordReset");
            
            // verify the required parameter 'clientBody' is set
            if (clientBody == null) throw new ApiException(400, "Missing required parameter 'clientBody' when calling RequestPasswordReset");
            
    
            var path = "/people/{personId}/request-password-reset";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(clientBody); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RequestPasswordReset: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RequestPasswordReset: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Reset password **Note:** this endpoint is available in Alfresco 5.2.1 and newer versions.  Resets user&#39;s password  The password, id and key properties are mandatory in the request body. For example: &#x60;&#x60;&#x60;JSON {   \&quot;password\&quot;:\&quot;newPassword\&quot;,   \&quot;id\&quot;:\&quot;activiti$10\&quot;,   \&quot;key\&quot;:\&quot;4dad6d00-0daf-413a-b200-f64af4e12345\&quot; } &#x60;&#x60;&#x60; **Note:** No authentication is required to call this endpoint. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="passwordResetBody">The reset password details</param> 
        /// <returns></returns>            
        public void ResetPassword (string personId, PasswordResetBody passwordResetBody)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling ResetPassword");
            
            // verify the required parameter 'passwordResetBody' is set
            if (passwordResetBody == null) throw new ApiException(400, "Missing required parameter 'passwordResetBody' when calling ResetPassword");
            
    
            var path = "/people/{personId}/reset-password";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(passwordResetBody); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ResetPassword: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ResetPassword: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Update avatar image **Note:** this endpoint is available in Alfresco 5.2.2 and newer versions.  Updates the avatar image related to the person **personId**.  The request body should be the binary stream for the avatar image. The content type of the file should be an image file. This will be used to generate an \&quot;avatar\&quot; thumbnail rendition.  You must be the person or have admin rights to update a person&#39;s avatar.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="contentBodyUpdate">The binary content</param> 
        /// <returns></returns>            
        public void UpdateAvatarImage (string personId, byte[] contentBodyUpdate)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling UpdateAvatarImage");
            
            // verify the required parameter 'contentBodyUpdate' is set
            if (contentBodyUpdate == null) throw new ApiException(400, "Missing required parameter 'contentBodyUpdate' when calling UpdateAvatarImage");
            
    
            var path = "/people/{personId}/avatar";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(contentBodyUpdate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateAvatarImage: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateAvatarImage: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Update person **Note:** this endpoint is available in Alfresco 5.2 and newer versions.  Update the given person&#39;s details.  You can use the &#x60;-me-&#x60; string in place of &#x60;&lt;personId&gt;&#x60; to specify the currently authenticated user.  If applicable, the given person&#39;s login access can also be optionally disabled or re-enabled.  You must have admin rights to update a person — unless updating your own details.  If you are changing your password, as a non-admin user, then the existing password must also be supplied (using the oldPassword field in addition to the new password value).  Admin users cannot be disabled by setting enabled to false.  Non-admin users may not disable themselves.  You can set custom properties when you update a person: &#x60;&#x60;&#x60;JSON {   \&quot;firstName\&quot;: \&quot;Alice\&quot;,   \&quot;properties\&quot;:   {     \&quot;my:property\&quot;: \&quot;The value\&quot;   } } &#x60;&#x60;&#x60; **Note:** setting properties of type d:content and d:category are not supported. 
        /// </summary>
        /// <param name="personId">The identifier of a person.</param> 
        /// <param name="personBodyUpdate">The person details.</param> 
        /// <param name="fields">A list of field names.  You can use this parameter to restrict the fields returned within a response if, for example, you want to save on overall bandwidth.  The list applies to a returned individual entity or entries within a collection.  If the API method also supports the **include** parameter, then the fields specified in the **include** parameter are returned in addition to those specified in the **fields** parameter. </param> 
        /// <returns>PersonEntry</returns>            
        public PersonEntry UpdatePerson (string personId, PersonBodyUpdate personBodyUpdate, List<string> fields)
        {
            
            // verify the required parameter 'personId' is set
            if (personId == null) throw new ApiException(400, "Missing required parameter 'personId' when calling UpdatePerson");
            
            // verify the required parameter 'personBodyUpdate' is set
            if (personBodyUpdate == null) throw new ApiException(400, "Missing required parameter 'personBodyUpdate' when calling UpdatePerson");
            
    
            var path = "/people/{personId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "personId" + "}", ApiClient.ParameterToString(personId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                                    postBody = ApiClient.Serialize(personBodyUpdate); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] { "basicAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdatePerson: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdatePerson: " + response.ErrorMessage, response.ErrorMessage);
    
            return (PersonEntry) ApiClient.Deserialize(response.Content, typeof(PersonEntry), response.Headers);
        }
    
    }
}
