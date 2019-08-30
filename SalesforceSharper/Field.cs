using Newtonsoft.Json;
using System.Collections.Generic;

namespace SalesforceSharper
{
    public class Field
    {
        [JsonProperty("aggregatable")]
        public bool Aggregatable { get; set; }

        [JsonProperty("aiPredictionField")]
        public bool AiPredictionField { get; set; }

        [JsonProperty("autoNumber")]
        public bool AutoNumber { get; set; }

        [JsonProperty("byteLength")]
        public long ByteLength { get; set; }

        [JsonProperty("calculated")]
        public bool Calculated { get; set; }

        [JsonProperty("calculatedFormula")]
        public string CalculatedFormula { get; set; }

        [JsonProperty("cascadeDelete")]
        public bool CascadeDelete { get; set; }

        [JsonProperty("caseSensitive")]
        public bool CaseSensitive { get; set; }

        [JsonProperty("compoundFieldName")]
        public string CompoundFieldName { get; set; }

        [JsonProperty("controllerName")]
        public string ControllerName { get; set; }

        [JsonProperty("createable")]
        public bool Createable { get; set; }

        [JsonProperty("custom")]
        public bool Custom { get; set; }

        [JsonProperty("defaultValue")]
        public object DefaultValue { get; set; }

        [JsonProperty("defaultValueFormula")]
        public object DefaultValueFormula { get; set; }

        [JsonProperty("defaultedOnCreate")]
        public bool DefaultedOnCreate { get; set; }

        [JsonProperty("dependentPicklist")]
        public bool DependentPicklist { get; set; }

        [JsonProperty("deprecatedAndHidden")]
        public bool DeprecatedAndHidden { get; set; }

        [JsonProperty("digits")]
        public long Digits { get; set; }

        [JsonProperty("displayLocationInDecimal")]
        public bool DisplayLocationInDecimal { get; set; }

        [JsonProperty("encrypted")]
        public bool Encrypted { get; set; }

        [JsonProperty("externalId")]
        public bool ExternalId { get; set; }

        [JsonProperty("extraTypeInfo")]
        public string ExtraTypeInfo { get; set; }

        [JsonProperty("filterable")]
        public bool Filterable { get; set; }

        [JsonProperty("filteredLookupInfo")]
        public object FilteredLookupInfo { get; set; }

        [JsonProperty("formulaTreatNullNumberAsZero")]
        public bool FormulaTreatNullNumberAsZero { get; set; }

        [JsonProperty("groupable")]
        public bool Groupable { get; set; }

        [JsonProperty("highScaleNumber")]
        public bool HighScaleNumber { get; set; }

        [JsonProperty("htmlFormatted")]
        public bool HtmlFormatted { get; set; }

        [JsonProperty("idLookup")]
        public bool IdLookup { get; set; }

        [JsonProperty("inlineHelpText")]
        public string InlineHelpText { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("length")]
        public long Length { get; set; }

        [JsonProperty("mask")]
        public object Mask { get; set; }

        [JsonProperty("maskType")]
        public object MaskType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameField")]
        public bool NameField { get; set; }

        [JsonProperty("namePointing")]
        public bool NamePointing { get; set; }

        [JsonProperty("nillable")]
        public bool Nillable { get; set; }

        [JsonProperty("permissionable")]
        public bool Permissionable { get; set; }

        [JsonProperty("picklistValues")]
        public List<object> PicklistValues { get; set; }

        [JsonProperty("polymorphicForeignKey")]
        public bool PolymorphicForeignKey { get; set; }

        [JsonProperty("precision")]
        public long Precision { get; set; }

        [JsonProperty("queryByDistance")]
        public bool QueryByDistance { get; set; }

        [JsonProperty("referenceTargetField")]
        public object ReferenceTargetField { get; set; }

        [JsonProperty("referenceTo")]
        public List<string> ReferenceTo { get; set; }

        [JsonProperty("relationshipName")]
        public string RelationshipName { get; set; }

        [JsonProperty("relationshipOrder")]
        public object RelationshipOrder { get; set; }

        [JsonProperty("restrictedDelete")]
        public bool RestrictedDelete { get; set; }

        [JsonProperty("restrictedPicklist")]
        public bool RestrictedPicklist { get; set; }

        [JsonProperty("scale")]
        public long Scale { get; set; }

        [JsonProperty("searchPrefilterable")]
        public bool SearchPrefilterable { get; set; }

        [JsonProperty("soapType")]
        public string SoapType { get; set; }

        [JsonProperty("sortable")]
        public bool Sortable { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("unique")]
        public bool Unique { get; set; }

        [JsonProperty("updateable")]
        public bool Updateable { get; set; }

        [JsonProperty("writeRequiresMasterRead")]
        public bool WriteRequiresMasterRead { get; set; }
    }
}