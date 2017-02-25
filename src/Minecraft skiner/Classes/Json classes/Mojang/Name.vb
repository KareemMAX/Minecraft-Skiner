Imports Newtonsoft.Json

Public Class Name
    <JsonProperty("uuid")> Public UUID As String
    <JsonProperty("uuid_formatted")> Public FormatedUUID As String
    <JsonProperty("name")> Public Name As String
    <JsonProperty("properties")> Public Properties As IList(Of properties)
    <JsonProperty("properties_decoded")> Public PropertiesDecoded As IList(Of PropertiesDecoded)
End Class
