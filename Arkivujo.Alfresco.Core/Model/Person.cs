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
  public class Person {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets FirstName
    /// </summary>
    [DataMember(Name="firstName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "firstName")]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or Sets LastName
    /// </summary>
    [DataMember(Name="lastName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lastName")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or Sets Description
    /// </summary>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or Sets AvatarId
    /// </summary>
    [DataMember(Name="avatarId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "avatarId")]
    public string AvatarId { get; set; }

    /// <summary>
    /// Gets or Sets Email
    /// </summary>
    [DataMember(Name="email", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }

    /// <summary>
    /// Gets or Sets SkypeId
    /// </summary>
    [DataMember(Name="skypeId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "skypeId")]
    public string SkypeId { get; set; }

    /// <summary>
    /// Gets or Sets GoogleId
    /// </summary>
    [DataMember(Name="googleId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "googleId")]
    public string GoogleId { get; set; }

    /// <summary>
    /// Gets or Sets InstantMessageId
    /// </summary>
    [DataMember(Name="instantMessageId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "instantMessageId")]
    public string InstantMessageId { get; set; }

    /// <summary>
    /// Gets or Sets JobTitle
    /// </summary>
    [DataMember(Name="jobTitle", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "jobTitle")]
    public string JobTitle { get; set; }

    /// <summary>
    /// Gets or Sets Location
    /// </summary>
    [DataMember(Name="location", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "location")]
    public string Location { get; set; }

    /// <summary>
    /// Gets or Sets Company
    /// </summary>
    [DataMember(Name="company", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "company")]
    public Company Company { get; set; }

    /// <summary>
    /// Gets or Sets Mobile
    /// </summary>
    [DataMember(Name="mobile", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mobile")]
    public string Mobile { get; set; }

    /// <summary>
    /// Gets or Sets Telephone
    /// </summary>
    [DataMember(Name="telephone", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "telephone")]
    public string Telephone { get; set; }

    /// <summary>
    /// Gets or Sets StatusUpdatedAt
    /// </summary>
    [DataMember(Name="statusUpdatedAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "statusUpdatedAt")]
    public DateTime? StatusUpdatedAt { get; set; }

    /// <summary>
    /// Gets or Sets UserStatus
    /// </summary>
    [DataMember(Name="userStatus", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "userStatus")]
    public string UserStatus { get; set; }

    /// <summary>
    /// Gets or Sets Enabled
    /// </summary>
    [DataMember(Name="enabled", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or Sets EmailNotificationsEnabled
    /// </summary>
    [DataMember(Name="emailNotificationsEnabled", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "emailNotificationsEnabled")]
    public bool? EmailNotificationsEnabled { get; set; }

    /// <summary>
    /// Gets or Sets AspectNames
    /// </summary>
    [DataMember(Name="aspectNames", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "aspectNames")]
    public List<string> AspectNames { get; set; }

    /// <summary>
    /// Gets or Sets Properties
    /// </summary>
    [DataMember(Name="properties", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "properties")]
    public Dictionary<string, string> Properties { get; set; }

    /// <summary>
    /// Gets or Sets Capabilities
    /// </summary>
    [DataMember(Name="capabilities", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "capabilities")]
    public Capabilities Capabilities { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Person {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  FirstName: ").Append(FirstName).Append("\n");
      sb.Append("  LastName: ").Append(LastName).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  AvatarId: ").Append(AvatarId).Append("\n");
      sb.Append("  Email: ").Append(Email).Append("\n");
      sb.Append("  SkypeId: ").Append(SkypeId).Append("\n");
      sb.Append("  GoogleId: ").Append(GoogleId).Append("\n");
      sb.Append("  InstantMessageId: ").Append(InstantMessageId).Append("\n");
      sb.Append("  JobTitle: ").Append(JobTitle).Append("\n");
      sb.Append("  Location: ").Append(Location).Append("\n");
      sb.Append("  Company: ").Append(Company).Append("\n");
      sb.Append("  Mobile: ").Append(Mobile).Append("\n");
      sb.Append("  Telephone: ").Append(Telephone).Append("\n");
      sb.Append("  StatusUpdatedAt: ").Append(StatusUpdatedAt).Append("\n");
      sb.Append("  UserStatus: ").Append(UserStatus).Append("\n");
      sb.Append("  Enabled: ").Append(Enabled).Append("\n");
      sb.Append("  EmailNotificationsEnabled: ").Append(EmailNotificationsEnabled).Append("\n");
      sb.Append("  AspectNames: ").Append(AspectNames).Append("\n");
      sb.Append("  Properties: ").Append(Properties).Append("\n");
      sb.Append("  Capabilities: ").Append(Capabilities).Append("\n");
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
