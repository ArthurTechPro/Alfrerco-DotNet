using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// A list of stats request.
  /// </summary>
  [DataContract]
  public class RequestStats {
    /// <summary>
    /// The stats field
    /// </summary>
    /// <value>The stats field</value>
    [DataMember(Name="field", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "field")]
    public string Field { get; set; }

    /// <summary>
    /// A label to include for reference the stats field
    /// </summary>
    /// <value>A label to include for reference the stats field</value>
    [DataMember(Name="label", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "label")]
    public string Label { get; set; }

    /// <summary>
    /// The minimum value of the field
    /// </summary>
    /// <value>The minimum value of the field</value>
    [DataMember(Name="min", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "min")]
    public bool? Min { get; set; }

    /// <summary>
    /// The maximum value of the field
    /// </summary>
    /// <value>The maximum value of the field</value>
    [DataMember(Name="max", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "max")]
    public bool? Max { get; set; }

    /// <summary>
    /// The sum of all values of the field
    /// </summary>
    /// <value>The sum of all values of the field</value>
    [DataMember(Name="sum", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sum")]
    public bool? Sum { get; set; }

    /// <summary>
    /// The number which have a value for this field
    /// </summary>
    /// <value>The number which have a value for this field</value>
    [DataMember(Name="countValues", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "countValues")]
    public bool? CountValues { get; set; }

    /// <summary>
    /// The number which do not have a value for this field
    /// </summary>
    /// <value>The number which do not have a value for this field</value>
    [DataMember(Name="missing", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "missing")]
    public bool? Missing { get; set; }

    /// <summary>
    /// The average
    /// </summary>
    /// <value>The average</value>
    [DataMember(Name="mean", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mean")]
    public bool? Mean { get; set; }

    /// <summary>
    /// Standard deviation
    /// </summary>
    /// <value>Standard deviation</value>
    [DataMember(Name="stddev", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "stddev")]
    public bool? Stddev { get; set; }

    /// <summary>
    /// Sum of all values squared
    /// </summary>
    /// <value>Sum of all values squared</value>
    [DataMember(Name="sumOfSquares", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sumOfSquares")]
    public bool? SumOfSquares { get; set; }

    /// <summary>
    /// The set of all distinct values for the field (This can be very expensive to calculate)
    /// </summary>
    /// <value>The set of all distinct values for the field (This can be very expensive to calculate)</value>
    [DataMember(Name="distinctValues", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "distinctValues")]
    public bool? DistinctValues { get; set; }

    /// <summary>
    /// The number of distinct values  (This can be very expensive to calculate)
    /// </summary>
    /// <value>The number of distinct values  (This can be very expensive to calculate)</value>
    [DataMember(Name="countDistinct", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "countDistinct")]
    public bool? CountDistinct { get; set; }

    /// <summary>
    /// A statistical approximation of the number of distinct values
    /// </summary>
    /// <value>A statistical approximation of the number of distinct values</value>
    [DataMember(Name="cardinality", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cardinality")]
    public bool? Cardinality { get; set; }

    /// <summary>
    /// Number between 0.0 and 1.0 indicating how aggressively the algorithm should try to be accurate. Used with boolean cardinality flag.
    /// </summary>
    /// <value>Number between 0.0 and 1.0 indicating how aggressively the algorithm should try to be accurate. Used with boolean cardinality flag.</value>
    [DataMember(Name="cardinalityAccuracy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cardinalityAccuracy")]
    public float? CardinalityAccuracy { get; set; }

    /// <summary>
    /// A list of filters to exclude
    /// </summary>
    /// <value>A list of filters to exclude</value>
    [DataMember(Name="excludeFilters", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "excludeFilters")]
    public List<string> ExcludeFilters { get; set; }

    /// <summary>
    /// A list of percentile values, e.g. \"1,99,99.9\"
    /// </summary>
    /// <value>A list of percentile values, e.g. \"1,99,99.9\"</value>
    [DataMember(Name="percentiles", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "percentiles")]
    public List<float?> Percentiles { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestStats {\n");
      sb.Append("  Field: ").Append(Field).Append("\n");
      sb.Append("  Label: ").Append(Label).Append("\n");
      sb.Append("  Min: ").Append(Min).Append("\n");
      sb.Append("  Max: ").Append(Max).Append("\n");
      sb.Append("  Sum: ").Append(Sum).Append("\n");
      sb.Append("  CountValues: ").Append(CountValues).Append("\n");
      sb.Append("  Missing: ").Append(Missing).Append("\n");
      sb.Append("  Mean: ").Append(Mean).Append("\n");
      sb.Append("  Stddev: ").Append(Stddev).Append("\n");
      sb.Append("  SumOfSquares: ").Append(SumOfSquares).Append("\n");
      sb.Append("  DistinctValues: ").Append(DistinctValues).Append("\n");
      sb.Append("  CountDistinct: ").Append(CountDistinct).Append("\n");
      sb.Append("  Cardinality: ").Append(Cardinality).Append("\n");
      sb.Append("  CardinalityAccuracy: ").Append(CardinalityAccuracy).Append("\n");
      sb.Append("  ExcludeFilters: ").Append(ExcludeFilters).Append("\n");
      sb.Append("  Percentiles: ").Append(Percentiles).Append("\n");
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
