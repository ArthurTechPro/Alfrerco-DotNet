using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// A bucket of facet results
  /// </summary>
  [DataContract]
  public class GenericBucket {
    /// <summary>
    /// The bucket label
    /// </summary>
    /// <value>The bucket label</value>
    [DataMember(Name="label", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "label")]
    public string Label { get; set; }

    /// <summary>
    /// The filter query you can use to apply this facet
    /// </summary>
    /// <value>The filter query you can use to apply this facet</value>
    [DataMember(Name="filterQuery", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "filterQuery")]
    public string FilterQuery { get; set; }

    /// <summary>
    /// An optional field for additional display information
    /// </summary>
    /// <value>An optional field for additional display information</value>
    [DataMember(Name="display", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "display")]
    public Object Display { get; set; }

    /// <summary>
    /// An array of buckets and values
    /// </summary>
    /// <value>An array of buckets and values</value>
    [DataMember(Name="metrics", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "metrics")]
    public List<GenericMetric> Metrics { get; set; }

    /// <summary>
    /// Additional list of nested facets
    /// </summary>
    /// <value>Additional list of nested facets</value>
    [DataMember(Name="facets", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "facets")]
    public List<Object> Facets { get; set; }

    /// <summary>
    /// Gets or Sets BucketInfo
    /// </summary>
    [DataMember(Name="bucketInfo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bucketInfo")]
    public GenericBucketBucketInfo BucketInfo { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class GenericBucket {\n");
      sb.Append("  Label: ").Append(Label).Append("\n");
      sb.Append("  FilterQuery: ").Append(FilterQuery).Append("\n");
      sb.Append("  Display: ").Append(Display).Append("\n");
      sb.Append("  Metrics: ").Append(Metrics).Append("\n");
      sb.Append("  Facets: ").Append(Facets).Append("\n");
      sb.Append("  BucketInfo: ").Append(BucketInfo).Append("\n");
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
