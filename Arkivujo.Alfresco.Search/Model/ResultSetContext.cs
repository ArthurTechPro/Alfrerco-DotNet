using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// Context that applies to the whole result set
  /// </summary>
  [DataContract]
  public class ResultSetContext {
    /// <summary>
    /// Gets or Sets Consistency
    /// </summary>
    [DataMember(Name="consistency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "consistency")]
    public ResponseConsistency Consistency { get; set; }

    /// <summary>
    /// Gets or Sets Request
    /// </summary>
    [DataMember(Name="request", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "request")]
    public SearchRequest Request { get; set; }

    /// <summary>
    /// The counts from facet queries
    /// </summary>
    /// <value>The counts from facet queries</value>
    [DataMember(Name="facetQueries", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "facetQueries")]
    public List<ResultSetContextFacetQueries> FacetQueries { get; set; }

    /// <summary>
    /// The counts from field facets
    /// </summary>
    /// <value>The counts from field facets</value>
    [DataMember(Name="facetsFields", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "facetsFields")]
    public List<ResultBuckets> FacetsFields { get; set; }

    /// <summary>
    /// The faceted response
    /// </summary>
    /// <value>The faceted response</value>
    [DataMember(Name="facets", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "facets")]
    public List<GenericFacetResponse> Facets { get; set; }

    /// <summary>
    /// Suggested corrections  If zero results were found for the original query then a single entry of type \"searchInsteadFor\" will be returned. If alternatives were found that return more results than the original query they are returned as \"didYouMean\" options. The highest quality suggestion is first. 
    /// </summary>
    /// <value>Suggested corrections  If zero results were found for the original query then a single entry of type \"searchInsteadFor\" will be returned. If alternatives were found that return more results than the original query they are returned as \"didYouMean\" options. The highest quality suggestion is first. </value>
    [DataMember(Name="spellcheck", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "spellcheck")]
    public List<ResultSetContextSpellcheck> Spellcheck { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ResultSetContext {\n");
      sb.Append("  Consistency: ").Append(Consistency).Append("\n");
      sb.Append("  Request: ").Append(Request).Append("\n");
      sb.Append("  FacetQueries: ").Append(FacetQueries).Append("\n");
      sb.Append("  FacetsFields: ").Append(FacetsFields).Append("\n");
      sb.Append("  Facets: ").Append(Facets).Append("\n");
      sb.Append("  Spellcheck: ").Append(Spellcheck).Append("\n");
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
