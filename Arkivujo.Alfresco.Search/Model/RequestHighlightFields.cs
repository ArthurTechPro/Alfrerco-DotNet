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
  public class RequestHighlightFields {
    /// <summary>
    /// The name of the field to highlight.
    /// </summary>
    /// <value>The name of the field to highlight.</value>
    [DataMember(Name="field", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "field")]
    public string Field { get; set; }

    /// <summary>
    /// Gets or Sets SnippetCount
    /// </summary>
    [DataMember(Name="snippetCount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "snippetCount")]
    public int? SnippetCount { get; set; }

    /// <summary>
    /// Gets or Sets FragmentSize
    /// </summary>
    [DataMember(Name="fragmentSize", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fragmentSize")]
    public int? FragmentSize { get; set; }

    /// <summary>
    /// Gets or Sets MergeContiguous
    /// </summary>
    [DataMember(Name="mergeContiguous", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mergeContiguous")]
    public bool? MergeContiguous { get; set; }

    /// <summary>
    /// Gets or Sets Prefix
    /// </summary>
    [DataMember(Name="prefix", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "prefix")]
    public string Prefix { get; set; }

    /// <summary>
    /// Gets or Sets Postfix
    /// </summary>
    [DataMember(Name="postfix", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "postfix")]
    public string Postfix { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestHighlightFields {\n");
      sb.Append("  Field: ").Append(Field).Append("\n");
      sb.Append("  SnippetCount: ").Append(SnippetCount).Append("\n");
      sb.Append("  FragmentSize: ").Append(FragmentSize).Append("\n");
      sb.Append("  MergeContiguous: ").Append(MergeContiguous).Append("\n");
      sb.Append("  Prefix: ").Append(Prefix).Append("\n");
      sb.Append("  Postfix: ").Append(Postfix).Append("\n");
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
