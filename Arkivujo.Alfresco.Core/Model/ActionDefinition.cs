using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Core.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class ActionDefinition {
    /// <summary>
    /// Identifier of the action definition — used for example when executing an action
    /// </summary>
    /// <value>Identifier of the action definition — used for example when executing an action</value>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// name of the action definition, e.g. \"move\"
    /// </summary>
    /// <value>name of the action definition, e.g. \"move\"</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// title of the action definition, e.g. \"Move\"
    /// </summary>
    /// <value>title of the action definition, e.g. \"Move\"</value>
    [DataMember(Name="title", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; }

    /// <summary>
    /// describes the action definition, e.g. \"This will move the matched item to another space.\"
    /// </summary>
    /// <value>describes the action definition, e.g. \"This will move the matched item to another space.\"</value>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// QNames of the types this action applies to
    /// </summary>
    /// <value>QNames of the types this action applies to</value>
    [DataMember(Name="applicableTypes", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "applicableTypes")]
    public List<string> ApplicableTypes { get; set; }

    /// <summary>
    /// whether the basic action definition supports action tracking or not
    /// </summary>
    /// <value>whether the basic action definition supports action tracking or not</value>
    [DataMember(Name="trackStatus", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "trackStatus")]
    public bool? TrackStatus { get; set; }

    /// <summary>
    /// Gets or Sets ParameterDefinitions
    /// </summary>
    [DataMember(Name="parameterDefinitions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parameterDefinitions")]
    public List<ActionParameterDefinition> ParameterDefinitions { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ActionDefinition {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Title: ").Append(Title).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  ApplicableTypes: ").Append(ApplicableTypes).Append("\n");
      sb.Append("  TrackStatus: ").Append(TrackStatus).Append("\n");
      sb.Append("  ParameterDefinitions: ").Append(ParameterDefinitions).Append("\n");
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
