﻿Imports OpenTK

Public Class MouseRay

    Property CurrentRay As New Vector3

    Property ViewMatrix As Matrix4
    Property projectionMatrix As Matrix4

    Property Size As Size

    Sub New(ByRef View As Matrix4, ByRef Projection As Matrix4, TheSize As Size)
        projectionMatrix = Projection
        ViewMatrix = View
        Size = TheSize
    End Sub

    Public Sub Update(X As Integer, Y As Integer)
        CurrentRay = calculateMouseRay(X, Y)
    End Sub

    Private Function calculateMouseRay(X As Integer, Y As Integer) As Vector3
        Dim normalizedCoords As Vector2 = getNormalisedDeviceCoordinates(X, Y)
        Dim clipCoords As Vector4 = New Vector4(normalizedCoords.X, normalizedCoords.Y, -1.0F, 1.0F)
        Dim eyeCoords As Vector4 = toEyeCoords(clipCoords)
        Dim worldRay As Vector3 = toWorldCoords(eyeCoords)
        Return worldRay
    End Function

    Private Function toEyeCoords(clipCoords As Vector4) As Vector4
        Dim invertedProjection As Matrix4 = Matrix4.Invert(projectionMatrix)
        Dim eyeCoords As Vector4 = Vector4.Transform(clipCoords, invertedProjection)
        Return New Vector4(eyeCoords.x, eyeCoords.y, -1.0F, 0F)
    End Function

    Private Function toWorldCoords(eyeCoords As Vector4) As Vector3
        Dim invertedView As Matrix4 = Matrix4.Invert(ViewMatrix)
        Dim rayWorld As Vector4 = Vector4.Transform(eyeCoords, invertedView)
        Dim TheMouseRay As Vector3 = New Vector3(rayWorld.X, rayWorld.Y, rayWorld.Z)
        TheMouseRay.Normalize()
        Return TheMouseRay
    End Function

    Private Function getNormalisedDeviceCoordinates(x As Integer, y As Integer) As Vector2
        Dim x2 As Single = (2.0F * x) / Size.Width - 1.0F
        Dim y2 As Single = (2.0F * y) / Size.Height - 1.0F
        Return New Vector2(x2, y2)
    End Function
End Class