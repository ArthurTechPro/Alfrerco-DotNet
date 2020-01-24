using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// Common query defaults
  /// </summary>
  [DataContract]
  public class RequestDefaults {
    /// <summary>
    /// A list of query fields/properties used to expand TEXT: queries. The default is cm:content. You could include all content properties using d:content or list all individual content properties or types. As more terms are included the query size, complexity, memory impact and query time will increase. 
    /// </summary>
    /// <value>A list of query fields/properties used to expand TEXT: queries. The default is cm:content. You could include all content properties using d:content or list all individual content properties or types. As more terms are included the query size, complexity, memory impact and query time will increase. </value>
    [DataMember(Name="textAttributes", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "textAttributes")]
    public List<string> TextAttributes { get; set; }

    /// <summary>
    /// The default way to combine query parts when AND or OR is not explicitly stated - includes ! - + one two three (one two three) 
    /// </summary>
    /// <value>The default way to combine query parts when AND or OR is not explicitly stated - includes ! - + one two three (one two three) </value>
    [DataMember(Name="defaultFTSOperator", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "defaultFTSOperator")]
    public string DefaultFTSOperator { get; set; }

    /// <summary>
    /// The default way to combine query parts in field query groups when AND or OR is not explicitly stated - includes ! - + FIELD:(one two three) 
    /// </summary>
    /// <value>The default way to combine query parts in field query groups when AND or OR is not explicitly stated - includes ! - + FIELD:(one two three) </value>
    [DataMember(Name="defaultFTSFieldOperator", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "defaultFTSFieldOperator")]
    public string DefaultFTSFieldOperator { get; set; }

    /// <summary>
    /// The default name space to use if one is not provided
    /// </summary>
    /// <value>The default name space to use if one is not provided</value>
    [DataMember(Name="namespace", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "namespace")]
    public string Namespace { get; set; }

    /// <summary>
    /// Gets or Sets DefaultFieldName
    /// </summary>
    [DataMember(Name="defaultFieldName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "defaultFieldName")]
    public string DefaultFieldName { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestDefaults {\n");
      sb.Append("  TextAttributes: ").Append(TextAttributes).Append("\n");
      sb.Append("  DefaultFTSOperator: ").Append(DefaultFTSOperator).Append("\n");
      sb.Append("  DefaultFTSFieldOperator: ").Append(DefaultFTSFieldOperator).Append("\n");
      sb.Append("  Namespace: ").Append(Namespace).Append("\n");
      sb.Append("  DefaultFieldName: ").Append(DefaultFieldName).Append("\n");
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
