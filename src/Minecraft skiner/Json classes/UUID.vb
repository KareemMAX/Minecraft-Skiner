Imports Newtonsoft.Json

Public Class UUID
    <JsonProperty("uuid")> Public UUID As String
    <JsonProperty("uuid_formatted")> Public FormatedUUID As String
    <JsonProperty("name")> Public Name As String
End Class
