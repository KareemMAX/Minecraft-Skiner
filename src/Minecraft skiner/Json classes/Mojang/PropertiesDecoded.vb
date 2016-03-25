Imports Newtonsoft.Json

Public Class PropertiesDecoded
    <JsonProperty("timestamp")> Public TimeStamp As String
    <JsonProperty("profileId")> Public ProfileID As String
    <JsonProperty("profileName")> Public ProfileName As String
    <JsonProperty("textures")> Public Textures As Textures
End Class
