using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// Request that spellcheck fragments to be added to result set rows The properties reflect SOLR spellcheck parameters. 
  /// </summary>
  [DataContract]
  public class RequestSpellcheck {
    /// <summary>
    /// Gets or Sets Query
    /// </summary>
    [DataMember(Name="query", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "query")]
    public string Query { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestSpellcheck {\n");
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
