using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// A simple facet field
  /// </summary>
  [DataContract]
  public class RequestFacetField {
    /// <summary>
    /// The facet field
    /// </summary>
    /// <value>The facet field</value>
    [DataMember(Name="field", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "field")]
    public string Field { get; set; }

    /// <summary>
    /// A label to include in place of the facet field
    /// </summary>
    /// <value>A label to include in place of the facet field</value>
    [DataMember(Name="label", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "label")]
    public string Label { get; set; }

    /// <summary>
    /// Restricts the possible constraints to only indexed values with a specified prefix.
    /// </summary>
    /// <value>Restricts the possible constraints to only indexed values with a specified prefix.</value>
    [DataMember(Name="prefix", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "prefix")]
    public string Prefix { get; set; }

    /// <summary>
    /// Gets or Sets Sort
    /// </summary>
    [DataMember(Name="sort", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sort")]
    public string Sort { get; set; }

    /// <summary>
    /// Gets or Sets Method
    /// </summary>
    [DataMember(Name="method", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "method")]
    public string Method { get; set; }

    /// <summary>
    /// When true, count results that match the query but which have no facet value for the field (in addition to the Term-based constraints).
    /// </summary>
    /// <value>When true, count results that match the query but which have no facet value for the field (in addition to the Term-based constraints).</value>
    [DataMember(Name="missing", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "missing")]
    public bool? Missing { get; set; }

    /// <summary>
    /// Gets or Sets Limit
    /// </summary>
    [DataMember(Name="limit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// Gets or Sets Offset
    /// </summary>
    [DataMember(Name="offset", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "offset")]
    public int? Offset { get; set; }

    /// <summary>
    /// The minimum count required for a facet field to be included in the response.
    /// </summary>
    /// <value>The minimum count required for a facet field to be included in the response.</value>
    [DataMember(Name="mincount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mincount")]
    public int? Mincount { get; set; }

    /// <summary>
    /// Gets or Sets FacetEnumCacheMinDf
    /// </summary>
    [DataMember(Name="facetEnumCacheMinDf", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "facetEnumCacheMinDf")]
    public int? FacetEnumCacheMinDf { get; set; }

    /// <summary>
    /// Filter Queries with tags listed here will not be included in facet counts. This is used for multi-select facetting. 
    /// </summary>
    /// <value>Filter Queries with tags listed here will not be included in facet counts. This is used for multi-select facetting. </value>
    [DataMember(Name="excludeFilters", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "excludeFilters")]
    public List<string> ExcludeFilters { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestFacetField {\n");
      sb.Append("  Field: ").Append(Field).Append("\n");
      sb.Append("  Label: ").Append(Label).Append("\n");
      sb.Append("  Prefix: ").Append(Prefix).Append("\n");
      sb.Append("  Sort: ").Append(Sort).Append("\n");
      sb.Append("  Method: ").Append(Method).Append("\n");
      sb.Append("  Missing: ").Append(Missing).Append("\n");
      sb.Append("  Limit: ").Append(Limit).Append("\n");
      sb.Append("  Offset: ").Append(Offset).Append("\n");
      sb.Append("  Mincount: ").Append(Mincount).Append("\n");
      sb.Append("  FacetEnumCacheMinDf: ").Append(FacetEnumCacheMinDf).Append("\n");
      sb.Append("  ExcludeFilters: ").Append(ExcludeFilters).Append("\n");
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
