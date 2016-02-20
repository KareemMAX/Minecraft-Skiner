Imports OpenTK

Public Class MouseRay

    Property CurrentRay As New Vector3

    Property ViewMatrix As Matrix4
    Property projectionMatrix As Matrix4

    Property CamPos As Vector3

    Property Size As Size

    Property Pos As Point

    Property Renderer As Renderer3D

    ReadOnly Property MouseHit As Vector3
        Get
            Update(Pos.X, Pos.Y)
            Dim HeadIndex(1) As Single
            Dim BodyIndex(1) As Single
            HeadIndex(0) = (4 - CamPos.Z) / CurrentRay.Z
            BodyIndex(0) = (2 - CamPos.Z) / CurrentRay.Z
            HeadIndex(1) = (-4 - CamPos.Z) / CurrentRay.Z
            BodyIndex(1) = (-2 - CamPos.Z) / CurrentRay.Z

            Dim HeadXIndex(1) As Single
            Dim BodyXIndex(3) As Single
            Dim LegXIndex(2) As Single
            HeadXIndex(0) = (4 - CamPos.X) / CurrentRay.X
            BodyXIndex(0) = (8 - CamPos.X) / CurrentRay.X
            HeadXIndex(1) = (-4 - CamPos.X) / CurrentRay.X
            BodyXIndex(1) = (-8 - CamPos.X) / CurrentRay.X
            BodyXIndex(2) = (-4 - CamPos.X) / CurrentRay.X
            BodyXIndex(3) = (4 - CamPos.X) / CurrentRay.X
            LegXIndex(0) = (4 - CamPos.X) / CurrentRay.X
            LegXIndex(1) = (-4 - CamPos.X) / CurrentRay.X
            LegXIndex(2) = -CamPos.X / CurrentRay.X

            Dim HeadYIndex(1) As Single
            Dim BodyYIndex(1) As Single
            Dim LegYIndex(1) As Single
            HeadYIndex(0) = (16 - CamPos.Y) / CurrentRay.Y
            BodyYIndex(0) = (8 - CamPos.Y) / CurrentRay.Y
            HeadYIndex(1) = (8 - CamPos.Y) / CurrentRay.Y
            BodyYIndex(1) = (-4 - CamPos.Y) / CurrentRay.Y
            LegYIndex(0) = (-4 - CamPos.Y) / CurrentRay.Y
            LegYIndex(1) = (-16 - CamPos.Y) / CurrentRay.Y

            Dim IsZ, IsX, IsY As Boolean

            Dim PointsDis As New List(Of Single)

            Dim HeadPoint, BodyPoint, HeadXPoint, BodyXPoint, LegXPoint, HeadYPoint, BodyYPoint, LegYPoint As Vector3

            For I As Byte = 0 To 3

                If Not I > 1 Then : HeadPoint = getPointOnRay(CurrentRay, HeadIndex(I)) : Else : HeadPoint = New Vector3(20, 20, 20) : End If
                If Not I > 1 Then : BodyPoint = getPointOnRay(CurrentRay, BodyIndex(I)) : Else : BodyPoint = New Vector3(20, 20, 20) : End If

                If Not I > 1 Then : HeadXPoint = getPointOnRay(CurrentRay, HeadXIndex(I)) : Else : HeadXPoint = New Vector3(20, 20, 20) : End If
                BodyXPoint = getPointOnRay(CurrentRay, BodyXIndex(I))
                If Not I > 2 Then : LegXPoint = getPointOnRay(CurrentRay, LegXIndex(I)) : Else : LegXPoint = New Vector3(20, 20, 20) : End If

                If Not I > 1 Then : HeadYPoint = getPointOnRay(CurrentRay, HeadYIndex(I)) : Else : HeadYPoint = New Vector3(20, 20, 20) : End If
                If Not I > 1 Then : BodyYPoint = getPointOnRay(CurrentRay, BodyYIndex(I)) : Else : BodyYPoint = New Vector3(20, 20, 20) : End If
                If Not I > 1 Then : LegYPoint = getPointOnRay(CurrentRay, LegYIndex(I)) : Else : LegYPoint = New Vector3(20, 20, 20) : End If

                If Renderer.ShowHead AndAlso HeadPoint.X < 4 AndAlso HeadPoint.X > -4 AndAlso HeadPoint.Y < 16 AndAlso HeadPoint.Y > 8 Then
                    PointsDis.Add(HeadIndex(I))
                    IsZ = True
                End If
                If Renderer.ShowBody AndAlso BodyPoint.X < 4 AndAlso BodyPoint.X > -4 AndAlso BodyPoint.Y < 8 AndAlso BodyPoint.Y > -4 Then
                    PointsDis.Add(BodyIndex(I))
                    IsZ = True
                End If
                If Renderer.ShowRightArm AndAlso BodyPoint.X < -4 AndAlso BodyPoint.X > -8 AndAlso BodyPoint.Y < 8 AndAlso BodyPoint.Y > -4 Then
                    PointsDis.Add(BodyIndex(I))
                    IsZ = True
                End If
                If Renderer.ShowLeftArm AndAlso BodyPoint.X < 8 AndAlso BodyPoint.X > 4 AndAlso BodyPoint.Y < 8 AndAlso BodyPoint.Y > -4 Then
                    PointsDis.Add(BodyIndex(I))
                    IsZ = True
                End If
                If Renderer.ShowRightLeg AndAlso BodyPoint.X < 0 AndAlso BodyPoint.X > -4 AndAlso BodyPoint.Y < -4 AndAlso BodyPoint.Y > -16 Then
                    PointsDis.Add(BodyIndex(I))
                    IsZ = True
                End If
                If Renderer.ShowLeftLeg AndAlso BodyPoint.X < 4 AndAlso BodyPoint.X > 0 AndAlso BodyPoint.Y < -4 AndAlso BodyPoint.Y > -16 Then
                    PointsDis.Add(BodyIndex(I))
                    IsZ = True
                End If
                If Renderer.ShowHead AndAlso HeadXPoint.Z < 4 AndAlso HeadXPoint.Z > -4 AndAlso HeadXPoint.Y < 16 AndAlso HeadXPoint.Y > 8 Then
                    PointsDis.Add(HeadXIndex(I))
                    IsX = True
                End If
                If Renderer.ShowRightArm AndAlso Convert.ToInt32(BodyXPoint.X) = -8 AndAlso BodyXPoint.Z < 2 AndAlso BodyXPoint.Z > -2 AndAlso BodyXPoint.Y < 8 AndAlso BodyXPoint.Y > -4 Then
                    PointsDis.Add(BodyXIndex(I))
                    IsX = True
                End If
                If Renderer.ShowLeftArm AndAlso Convert.ToInt32(BodyXPoint.X) = 8 AndAlso BodyXPoint.Z < 2 AndAlso BodyXPoint.Z > -2 AndAlso BodyXPoint.Y < 8 AndAlso BodyXPoint.Y > -4 Then
                    PointsDis.Add(BodyXIndex(I))
                    IsX = True
                End If
                If (Renderer.ShowRightArm Xor Renderer.ShowBody) AndAlso Convert.ToInt32(BodyXPoint.X) = -4 AndAlso BodyXPoint.Z < 2 AndAlso BodyXPoint.Z > -2 AndAlso BodyXPoint.Y < 8 AndAlso BodyXPoint.Y > -4 Then
                    PointsDis.Add(BodyXIndex(I))
                    IsX = True
                End If
                If (Renderer.ShowLeftArm Xor Renderer.ShowBody) AndAlso Convert.ToInt32(BodyXPoint.X) = 4 AndAlso BodyXPoint.Z < 2 AndAlso BodyXPoint.Z > -2 AndAlso BodyXPoint.Y < 8 AndAlso BodyXPoint.Y > -4 Then
                    PointsDis.Add(BodyXIndex(I))
                    IsX = True
                End If
                If Renderer.ShowRightLeg AndAlso Convert.ToInt32(LegXPoint.X) = -4 AndAlso LegXPoint.Z < 2 AndAlso LegXPoint.Z > -2 AndAlso LegXPoint.Y < -4 AndAlso LegXPoint.Y > -16 Then
                    PointsDis.Add(LegXIndex(I))
                    IsX = True
                End If
                If Renderer.ShowLeftLeg AndAlso Convert.ToInt32(LegXPoint.X) = 4 AndAlso LegXPoint.Z < 2 AndAlso LegXPoint.Z > -2 AndAlso LegXPoint.Y < -4 AndAlso LegXPoint.Y > -16 Then
                    PointsDis.Add(LegXIndex(I))
                    IsX = True
                End If
                If (Renderer.ShowRightLeg Xor Renderer.ShowLeftLeg) AndAlso Convert.ToInt32(LegXPoint.X) = 0 AndAlso LegXPoint.Z < 2 AndAlso LegXPoint.Z > -2 AndAlso LegXPoint.Y < -4 AndAlso LegXPoint.Y > -16 Then
                    PointsDis.Add(LegXIndex(I))
                    IsX = True
                End If
                If Renderer.ShowHead AndAlso HeadYPoint.Z < 4 AndAlso HeadYPoint.Z > -4 AndAlso HeadYPoint.X < 4 AndAlso HeadYPoint.X > -4 Then
                    PointsDis.Add(HeadYIndex(I))
                    IsY = True
                End If
                If Renderer.ShowBody AndAlso BodyYPoint.Z < 2 AndAlso BodyYPoint.Z > -2 AndAlso BodyYPoint.X < 4 AndAlso BodyYPoint.X > -4 Then
                    PointsDis.Add(BodyYIndex(I))
                    IsY = True
                End If
                If Renderer.ShowRightArm AndAlso BodyYPoint.Z < 2 AndAlso BodyYPoint.Z > -2 AndAlso BodyYPoint.X < -4 AndAlso BodyYPoint.X > -8 Then
                    PointsDis.Add(BodyYIndex(I))
                    IsY = True
                End If
                If Renderer.ShowLeftArm AndAlso BodyYPoint.Z < 2 AndAlso BodyYPoint.Z > -2 AndAlso BodyYPoint.X < 8 AndAlso BodyYPoint.X > 4 Then
                    PointsDis.Add(BodyYIndex(I))
                    IsY = True
                End If
                If Renderer.ShowRightLeg AndAlso LegYPoint.Z < 2 AndAlso LegYPoint.Z > -2 AndAlso LegYPoint.X < 0 AndAlso LegYPoint.X > -4 Then
                    PointsDis.Add(LegYIndex(I))
                    IsY = True
                End If
                If Renderer.ShowLeftLeg AndAlso LegYPoint.Z < 2 AndAlso LegYPoint.Z > -2 AndAlso LegYPoint.X < 4 AndAlso LegYPoint.X > 0 Then
                    PointsDis.Add(LegYIndex(I))
                    IsY = True
                End If

            Next

            If PointsDis.Count = 0 Then Return Nothing

            Dim Smallest As Single = 1000

            For Each value As Single In PointsDis
                If value < Smallest Then Smallest = value
            Next

            Dim Result As Vector3 = getPointOnRay(CurrentRay, Smallest)
            If IsX Then
                Result.X = CInt(Result.X)
            ElseIf IsY Then
                Result.Y = CInt(Result.Y)
            ElseIf IsZ Then
                Result.Z = CInt(Result.Z)
            End If

            Return Result
        End Get
    End Property

    Sub New(ByRef View As Matrix4, ByRef Projection As Matrix4, TheSize As Size, Camera As Vector3, TheRenderer As Renderer3D)
        projectionMatrix = Projection
        ViewMatrix = View
        Size = TheSize
        CamPos = Camera
        Renderer = TheRenderer
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