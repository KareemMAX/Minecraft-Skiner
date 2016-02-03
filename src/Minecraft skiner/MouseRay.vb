Imports OpenTK

Public Class MouseRay

    Property CurrentRay As New Vector3

    Property ViewMatrix As Matrix4
    Property projectionMatrix As Matrix4

    Property CamPos As Vector3

    Property Size As Size

    Property Pos As Point

    ReadOnly Property MouseHit As Vector3
        Get
            Update(Pos.X, Pos.Y)
            Dim HeadIndex(1) As Single
            Dim BodyIndex(1) As Single
            HeadIndex(0) = (4 - CamPos.Z) / CurrentRay.Z
            BodyIndex(0) = (2 - CamPos.Z) / CurrentRay.Z
            HeadIndex(1) = (-4 - CamPos.Z) / CurrentRay.Z
            BodyIndex(1) = (-2 - CamPos.Z) / CurrentRay.Z

            Dim HeadSmallest As Single
            Dim BodySmallest As Single
            If HeadIndex(0) > HeadIndex(1) Then
                HeadSmallest = HeadIndex(1)
            ElseIf HeadIndex(0) < HeadIndex(1) Then
                HeadSmallest = HeadIndex(0)
            End If
            If BodyIndex(0) > BodyIndex(1) Then
                BodySmallest = BodyIndex(1)
            ElseIf BodyIndex(0) < BodyIndex(1) Then
                BodySmallest = BodyIndex(0)
            End If

            Dim HeadXIndex(1) As Single
            Dim BodyXIndex(1) As Single
            Dim LegXIndex(1) As Single
            HeadXIndex(0) = (4 - CamPos.X) / CurrentRay.X
            BodyXIndex(0) = (8 - CamPos.X) / CurrentRay.X
            HeadXIndex(1) = (-4 - CamPos.X) / CurrentRay.X
            BodyXIndex(1) = (-8 - CamPos.X) / CurrentRay.X
            LegXIndex(0) = (4 - CamPos.X) / CurrentRay.X
            LegXIndex(1) = (-4 - CamPos.X) / CurrentRay.X

            Dim HeadXSmallest As Single
            Dim BodyXSmallest As Single
            Dim LegXSmallest As Single
            If HeadXIndex(0) > HeadXIndex(1) Then
                HeadXSmallest = HeadXIndex(1)
            ElseIf HeadXIndex(0) < HeadXIndex(1) Then
                HeadXSmallest = HeadXIndex(0)
            End If
            If BodyXIndex(0) > BodyXIndex(1) Then
                BodyXSmallest = BodyXIndex(1)
            ElseIf BodyXIndex(0) < BodyXIndex(1) Then
                BodyXSmallest = BodyXIndex(0)
            End If
            If LegXIndex(0) > LegXIndex(1) Then
                LegXSmallest = LegXIndex(1)
            ElseIf BodyXIndex(0) < LegXIndex(1) Then
                LegXSmallest = LegXIndex(0)
            End If

            Dim HeadYIndex(1) As Single
            Dim BodyYIndex(1) As Single
            Dim LegYIndex(1) As Single
            HeadYIndex(0) = (16 - CamPos.Y) / CurrentRay.Y
            BodyYIndex(0) = (8 - CamPos.Y) / CurrentRay.Y
            HeadYIndex(1) = (8 - CamPos.Y) / CurrentRay.Y
            BodyYIndex(1) = (-4 - CamPos.Y) / CurrentRay.Y
            LegYIndex(0) = (-4 - CamPos.Y) / CurrentRay.Y
            LegYIndex(1) = (-16 - CamPos.Y) / CurrentRay.Y

            Dim HeadYSmallest As Single
            Dim BodyYSmallest As Single
            Dim LegYSmallest As Single
            If HeadYIndex(0) > HeadYIndex(1) Then
                HeadYSmallest = HeadYIndex(1)
            ElseIf HeadYIndex(0) < HeadYIndex(1) Then
                HeadYSmallest = HeadYIndex(0)
            End If
            If BodyYIndex(0) > BodyYIndex(1) Then
                BodyYSmallest = BodyYIndex(1)
            ElseIf BodyYIndex(0) < BodyYIndex(1) Then
                BodyYSmallest = BodyYIndex(0)
            End If
            If LegYIndex(0) > LegYIndex(1) Then
                LegYSmallest = LegYIndex(1)
            ElseIf BodyYIndex(0) < LegYIndex(1) Then
                LegYSmallest = LegYIndex(0)
            End If

            Dim HeadPoint As Vector3 = getPointOnRay(CurrentRay, HeadSmallest)
            Dim BodyPoint As Vector3 = getPointOnRay(CurrentRay, BodySmallest)

            Dim HeadXPoint As Vector3 = getPointOnRay(CurrentRay, HeadXSmallest)
            Dim BodyXPoint As Vector3 = getPointOnRay(CurrentRay, BodyXSmallest)
            Dim LegXPoint As Vector3 = getPointOnRay(CurrentRay, LegXSmallest)

            Dim HeadYPoint As Vector3 = getPointOnRay(CurrentRay, HeadYSmallest)
            Dim BodyYPoint As Vector3 = getPointOnRay(CurrentRay, BodyYSmallest)
            Dim LegYPoint As Vector3 = getPointOnRay(CurrentRay, LegYSmallest)

            If HeadPoint.X < 4 AndAlso HeadPoint.X > -4 AndAlso HeadPoint.Y < 16 AndAlso HeadPoint.Y > 8 Then
                Return HeadPoint
            ElseIf (BodyPoint.X < 8 AndAlso BodyPoint.X > -8 AndAlso BodyPoint.Y < 8 AndAlso BodyPoint.Y > -4) OrElse
                (BodyPoint.X < 4 AndAlso BodyPoint.X > -4 AndAlso BodyPoint.Y < -4 AndAlso BodyPoint.Y > -16) Then
                Return BodyPoint
            ElseIf HeadXPoint.Z < 4 AndAlso HeadXPoint.Z > -4 AndAlso HeadXPoint.Y < 16 AndAlso HeadXPoint.Y > 8 Then
                Return HeadXPoint
            ElseIf BodyXPoint.Z < 2 AndAlso BodyXPoint.Z > -2 AndAlso BodyXPoint.Y < 8 AndAlso BodyXPoint.Y > -4 Then
                Return BodyXPoint
            ElseIf LegXPoint.Z < 2 AndAlso LegXPoint.Z > -2 AndAlso LegXPoint.Y < -4 AndAlso LegXPoint.Y > -16 Then
                Return LegXPoint
            ElseIf HeadYPoint.Z < 4 AndAlso HeadYPoint.Z > -4 AndAlso HeadYPoint.X < 4 AndAlso HeadYPoint.X > -4 Then
                Return HeadYPoint
            ElseIf BodyYPoint.Z < 2 AndAlso BodyYPoint.Z > -2 AndAlso BodyYPoint.X < 8 AndAlso BodyYPoint.X > -8 Then
                Return BodyYPoint
            ElseIf LegYPoint.Z < 2 AndAlso LegYPoint.Z > -2 AndAlso LegYPoint.X < 4 AndAlso LegYPoint.X > -4 Then
                Return LegYPoint
            End If
        End Get
    End Property

    Sub New(ByRef View As Matrix4, ByRef Projection As Matrix4, TheSize As Size, Camera As Vector3)
        projectionMatrix = Projection
        ViewMatrix = View
        Size = TheSize
        CamPos = Camera
    End Sub

    Private Sub Update(X As Integer, Y As Integer)
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
        Dim y2 As Single = -((2.0F * y) / Size.Height - 1.0F)
        Return New Vector2(x2, y2)
    End Function

    Private Function getPointOnRay(ray As Vector3, distance As Single) As Vector3
        Dim start As New Vector3(camPos.x, camPos.y, camPos.z)
        Dim scaledRay As New Vector3(ray.X * distance, ray.Y * distance, ray.Z * distance)
        Return start + scaledRay
    End Function
End Class