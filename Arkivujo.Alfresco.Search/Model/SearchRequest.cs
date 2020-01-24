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
  public class SearchRequest {
    /// <summary>
    /// Gets or Sets Query
    /// </summary>
    [DataMember(Name="query", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "query")]
    public RequestQuery Query { get; set; }

    /// <summary>
    /// Gets or Sets Paging
    /// </summary>
    [DataMember(Name="paging", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "paging")]
    public RequestPagination Paging { get; set; }

    /// <summary>
    /// Gets or Sets Include
    /// </summary>
    [DataMember(Name="include", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "include")]
    public RequestInclude Include { get; set; }

    /// <summary>
    /// When true, include the original request in the response
    /// </summary>
    /// <value>When true, include the original request in the response</value>
    [DataMember(Name="includeRequest", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "includeRequest")]
    public bool? IncludeRequest { get; set; }

    /// <summary>
    /// Gets or Sets Fields
    /// </summary>
    [DataMember(Name="fields", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fields")]
    public RequestFields Fields { get; set; }

    /// <summary>
    /// Gets or Sets Sort
    /// </summary>
    [DataMember(Name="sort", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sort")]
    public RequestSortDefinition Sort { get; set; }

    /// <summary>
    /// Gets or Sets Templates
    /// </summary>
    [DataMember(Name="templates", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "templates")]
    public RequestTemplates Templates { get; set; }

    /// <summary>
    /// Gets or Sets Defaults
    /// </summary>
    [DataMember(Name="defaults", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "defaults")]
    public RequestDefaults Defaults { get; set; }

    /// <summary>
    /// Gets or Sets Localization
    /// </summary>
    [DataMember(Name="localization", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "localization")]
    public RequestLocalization Localization { get; set; }

    /// <summary>
    /// Gets or Sets FilterQueries
    /// </summary>
    [DataMember(Name="filterQueries", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "filterQueries")]
    public RequestFilterQueries FilterQueries { get; set; }

    /// <summary>
    /// Gets or Sets FacetQueries
    /// </summary>
    [DataMember(Name="facetQueries", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "facetQueries")]
    public RequestFacetQueries FacetQueries { get; set; }

    /// <summary>
    /// Gets or Sets FacetFields
    /// </summary>
    [DataMember(Name="facetFields", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "facetFields")]
    public RequestFacetFields FacetFields { get; set; }

    /// <summary>
    /// Gets or Sets FacetIntervals
    /// </summary>
    [DataMember(Name="facetIntervals", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "facetIntervals")]
    public RequestFacetIntervals FacetIntervals { get; set; }

    /// <summary>
    /// Gets or Sets Pivots
    /// </summary>
    [DataMember(Name="pivots", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pivots")]
    public List<RequestPivot> Pivots { get; set; }

    /// <summary>
    /// Gets or Sets Stats
    /// </summary>
    [DataMember(Name="stats", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "stats")]
    public List<RequestStats> Stats { get; set; }

    /// <summary>
    /// Gets or Sets Spellcheck
    /// </summary>
    [DataMember(Name="spellcheck", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "spellcheck")]
    public RequestSpellcheck Spellcheck { get; set; }

    /// <summary>
    /// Gets or Sets Scope
    /// </summary>
    [DataMember(Name="scope", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "scope")]
    public RequestScope Scope { get; set; }

    /// <summary>
    /// Gets or Sets Limits
    /// </summary>
    [DataMember(Name="limits", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "limits")]
    public RequestLimits Limits { get; set; }

    /// <summary>
    /// Gets or Sets Highlight
    /// </summary>
    [DataMember(Name="highlight", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "highlight")]
    public RequestHighlight Highlight { get; set; }

    /// <summary>
    /// Gets or Sets Ranges
    /// </summary>
    [DataMember(Name="ranges", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ranges")]
    public List<RequestRange> Ranges { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SearchRequest {\n");
      sb.Append("  Query: ").Append(Query).Append("\n");
      sb.Append("  Paging: ").Append(Paging).Append("\n");
      sb.Append("  Include: ").Append(Include).Append("\n");
      sb.Append("  IncludeRequest: ").Append(IncludeRequest).Append("\n");
      sb.Append("  Fields: ").Append(Fields).Append("\n");
      sb.Append("  Sort: ").Append(Sort).Append("\n");
      sb.Append("  Templates: ").Append(Templates).Append("\n");
      sb.Append("  Defaults: ").Append(Defaults).Append("\n");
      sb.Append("  Localization: ").Append(Localization).Append("\n");
      sb.Append("  FilterQueries: ").Append(FilterQueries).Append("\n");
      sb.Append("  FacetQueries: ").Append(FacetQueries).Append("\n");
      sb.Append("  FacetFields: ").Append(FacetFields).Append("\n");
      sb.Append("  FacetIntervals: ").Append(FacetIntervals).Append("\n");
      sb.Append("  Pivots: ").Append(Pivots).Append("\n");
      sb.Append("  Stats: ").Append(Stats).Append("\n");
      sb.Append("  Spellcheck: ").Append(Spellcheck).Append("\n");
      sb.Append("  Scope: ").Append(Scope).Append("\n");
      sb.Append("  Limits: ").Append(Limits).Append("\n");
      sb.Append("  Highlight: ").Append(Highlight).Append("\n");
      sb.Append("  Ranges: ").Append(Ranges).Append("\n");
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
