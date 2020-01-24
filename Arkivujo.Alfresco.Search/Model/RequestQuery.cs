using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// Query.
  /// </summary>
  [DataContract]
  public class RequestQuery {
    /// <summary>
    /// The query language in which the query is written.
    /// </summary>
    /// <value>The query language in which the query is written.</value>
    [DataMember(Name="language", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "language")]
    public string Language { get; set; }

    /// <summary>
    /// The exact search request typed in by the user
    /// </summary>
    /// <value>The exact search request typed in by the user</value>
    [DataMember(Name="userQuery", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "userQuery")]
    public string UserQuery { get; set; }

    /// <summary>
    /// The query which may have been generated in some way from the userQuery
    /// </summary>
    /// <value>The query which may have been generated in some way from the userQuery</value>
    [DataMember(Name="query", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "query")]
    public string Query { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestQuery {\n");
      sb.Append("  Language: ").Append(Language).Append("\n");
      sb.Append("  UserQuery: ").Append(UserQuery).Append("\n");
      sb.Append("  Query: ").Append(Query).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
