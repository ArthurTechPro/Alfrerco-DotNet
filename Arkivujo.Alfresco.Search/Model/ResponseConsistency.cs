using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// The consistency state of the index used to execute the query
  /// </summary>
  [DataContract]
  public class ResponseConsistency {
    /// <summary>
    /// The id of the last indexed transaction
    /// </summary>
    /// <value>The id of the last indexed transaction</value>
    [DataMember(Name="lastTxId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lastTxId")]
    public int? LastTxId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ResponseConsistency {\n");
      sb.Append("  LastTxId: ").Append(LastTxId).Append("\n");
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
