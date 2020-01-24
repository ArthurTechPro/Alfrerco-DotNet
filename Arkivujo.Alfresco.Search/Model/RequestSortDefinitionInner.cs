using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class RequestSortDefinitionInner {
    /// <summary>
    /// How to order - using a field, when position of the document in the index, score/relevance.
    /// </summary>
    /// <value>How to order - using a field, when position of the document in the index, score/relevance.</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// The name of the field
    /// </summary>
    /// <value>The name of the field</value>
    [DataMember(Name="field", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "field")]
    public string Field { get; set; }

    /// <summary>
    /// The sort order. (The ordering of nulls is determined by the SOLR configuration)
    /// </summary>
    /// <value>The sort order. (The ordering of nulls is determined by the SOLR configuration)</value>
    [DataMember(Name="ascending", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ascending")]
    public bool? Ascending { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestSortDefinitionInner {\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  Field: ").Append(Field).Append("\n");
      sb.Append("  Ascending: ").Append(Ascending).Append("\n");
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
