using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Core.Model {

  /// <summary>
  /// A network is the group of users and sites that belong to an organization. Networks are organized by email domain. When a user signs up for an Alfresco account , their email domain becomes their Home Network. 
  /// </summary>
  [DataContract]
  public class PersonNetwork {
    /// <summary>
    /// This network's unique id
    /// </summary>
    /// <value>This network's unique id</value>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Is this the home network?
    /// </summary>
    /// <value>Is this the home network?</value>
    [DataMember(Name="homeNetwork", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "homeNetwork")]
    public bool? HomeNetwork { get; set; }

    /// <summary>
    /// Gets or Sets IsEnabled
    /// </summary>
    [DataMember(Name="isEnabled", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isEnabled")]
    public bool? IsEnabled { get; set; }

    /// <summary>
    /// Gets or Sets CreatedAt
    /// </summary>
    [DataMember(Name="createdAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Gets or Sets PaidNetwork
    /// </summary>
    [DataMember(Name="paidNetwork", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "paidNetwork")]
    public bool? PaidNetwork { get; set; }

    /// <summary>
    /// Gets or Sets SubscriptionLevel
    /// </summary>
    [DataMember(Name="subscriptionLevel", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "subscriptionLevel")]
    public string SubscriptionLevel { get; set; }

    /// <summary>
    /// Gets or Sets Quotas
    /// </summary>
    [DataMember(Name="quotas", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "quotas")]
    public List<NetworkQuota> Quotas { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PersonNetwork {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  HomeNetwork: ").Append(HomeNetwork).Append("\n");
      sb.Append("  IsEnabled: ").Append(IsEnabled).Append("\n");
      sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
      sb.Append("  PaidNetwork: ").Append(PaidNetwork).Append("\n");
      sb.Append("  SubscriptionLevel: ").Append(SubscriptionLevel).Append("\n");
      sb.Append("  Quotas: ").Append(Quotas).Append("\n");
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
