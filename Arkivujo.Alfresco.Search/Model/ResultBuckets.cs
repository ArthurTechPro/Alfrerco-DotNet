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
  public class ResultBuckets {
    /// <summary>
    /// The field name or its explicit label, if provided on the request
    /// </summary>
    /// <value>The field name or its explicit label, if provided on the request</value>
    [DataMember(Name="label", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "label")]
    public string Label { get; set; }

    /// <summary>
    /// An array of buckets and values
    /// </summary>
    /// <value>An array of buckets and values</value>
    [DataMember(Name="buckets", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "buckets")]
    public List<ResultBucketsBuckets> Buckets { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ResultBuckets {\n");
      sb.Append("  Label: ").Append(Label).Append("\n");
      sb.Append("  Buckets: ").Append(Buckets).Append("\n");
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
