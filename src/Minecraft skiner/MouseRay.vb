Imports OpenTK

Public Class MouseRay

    Property CurrentRay As New Vector3

    Property ViewMatrix As Matrix4
    Property projectionMatrix As Matrix4

    Property CamPos As Vector3

    Property Size As Size

    Property Pos As Point

    Property Renderer As Renderer3D

    Structure ResultDistance
        Property Distance As Single

        Enum [Is]
            X
            Y
            Z
        End Enum

        Property IsWhat As [Is]

        Sub New(Distance As Single, IsWhat As [Is])
            Me.Distance = Distance
            Me.IsWhat = IsWhat
        End Sub
    End Structure

    ReadOnly Property MouseHit As Vector3
        Get
            On Error Resume Next
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
            If Renderer.Model = Renderer3D.Models.Steve Then
                BodyXIndex(0) = (8 - CamPos.X) / CurrentRay.X
                BodyXIndex(1) = (-8 - CamPos.X) / CurrentRay.X
            Else
                BodyXIndex(0) = (7 - CamPos.X) / CurrentRay.X
                BodyXIndex(1) = (-7 - CamPos.X) / CurrentRay.X
            End If
            HeadXIndex(1) = (-4 - CamPos.X) / CurrentRay.X
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

            Dim PointsDis As New List(Of ResultDistance)

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
                    PointsDis.Add(New ResultDistance(HeadIndex(I), ResultDistance.[Is].Z))
                End If
                If Renderer.ShowBody AndAlso BodyPoint.X < 4 AndAlso BodyPoint.X > -4 AndAlso BodyPoint.Y < 8 AndAlso BodyPoint.Y > -4 Then
                    PointsDis.Add(New ResultDistance(BodyIndex(I), ResultDistance.[Is].Z))
                End If
                If Renderer.ShowRightArm AndAlso BodyPoint.Y > -4 AndAlso BodyPoint.Y < 8 Then
                    If (Renderer.Model = Renderer3D.Models.Steve AndAlso BodyPoint.X > -8 AndAlso BodyPoint.X < -4) OrElse
                        (Renderer.Model = Renderer3D.Models.Alex AndAlso BodyPoint.X > -7 AndAlso BodyPoint.X < -4) Then
                        PointsDis.Add(New ResultDistance(BodyIndex(I), ResultDistance.[Is].Z))
                    End If
                End If
                If Renderer.ShowLeftArm AndAlso BodyPoint.Y < 8 AndAlso BodyPoint.Y > -4 Then
                    If (Renderer.Model = Renderer3D.Models.Steve AndAlso BodyPoint.X < 8 AndAlso BodyPoint.X > 4) OrElse
                        (Renderer.Model = Renderer3D.Models.Alex AndAlso BodyPoint.X < 7 AndAlso BodyPoint.X > 4) Then
                        PointsDis.Add(New ResultDistance(BodyIndex(I), ResultDistance.[Is].Z))
                    End If
                End If
                If Renderer.ShowRightLeg AndAlso BodyPoint.X < 0 AndAlso BodyPoint.X > -4 AndAlso BodyPoint.Y < -4 AndAlso BodyPoint.Y > -16 Then
                    PointsDis.Add(New ResultDistance(BodyIndex(I), ResultDistance.[Is].Z))
                End If
                If Renderer.ShowLeftLeg AndAlso BodyPoint.X < 4 AndAlso BodyPoint.X > 0 AndAlso BodyPoint.Y < -4 AndAlso BodyPoint.Y > -16 Then
                    PointsDis.Add(New ResultDistance(BodyIndex(I), ResultDistance.[Is].Z))
                End If
                If Renderer.ShowHead AndAlso HeadXPoint.Z < 4 AndAlso HeadXPoint.Z > -4 AndAlso HeadXPoint.Y < 16 AndAlso HeadXPoint.Y > 8 Then
                    PointsDis.Add(New ResultDistance(HeadXIndex(I), ResultDistance.[Is].X))
                End If
                If Renderer.ShowRightArm AndAlso (Convert.ToInt32(BodyXPoint.X) = -8 OrElse Convert.ToInt32(BodyXPoint.X) = -7) AndAlso BodyXPoint.Z < 2 AndAlso BodyXPoint.Z > -2 AndAlso BodyXPoint.Y < 8 AndAlso BodyXPoint.Y > -4 Then
                    PointsDis.Add(New ResultDistance(BodyXIndex(I), ResultDistance.[Is].X))
                End If
                If Renderer.ShowLeftArm AndAlso (Convert.ToInt32(BodyXPoint.X) = 8 OrElse Convert.ToInt32(BodyXPoint.X) = 7) AndAlso BodyXPoint.Z < 2 AndAlso BodyXPoint.Z > -2 AndAlso BodyXPoint.Y < 8 AndAlso BodyXPoint.Y > -4 Then
                    PointsDis.Add(New ResultDistance(BodyXIndex(I), ResultDistance.[Is].X))
                End If
                If (Renderer.ShowRightArm Xor Renderer.ShowBody) AndAlso Convert.ToInt32(BodyXPoint.X) = -4 AndAlso BodyXPoint.Z < 2 AndAlso BodyXPoint.Z > -2 AndAlso BodyXPoint.Y < 8 AndAlso BodyXPoint.Y > -4 Then
                    PointsDis.Add(New ResultDistance(BodyXIndex(I), ResultDistance.[Is].X))
                End If
                If (Renderer.ShowLeftArm Xor Renderer.ShowBody) AndAlso Convert.ToInt32(BodyXPoint.X) = 4 AndAlso BodyXPoint.Z < 2 AndAlso BodyXPoint.Z > -2 AndAlso BodyXPoint.Y < 8 AndAlso BodyXPoint.Y > -4 Then
                    PointsDis.Add(New ResultDistance(BodyXIndex(I), ResultDistance.[Is].X))
                End If
                If Renderer.ShowRightLeg AndAlso Convert.ToInt32(LegXPoint.X) = -4 AndAlso LegXPoint.Z < 2 AndAlso LegXPoint.Z > -2 AndAlso LegXPoint.Y < -4 AndAlso LegXPoint.Y > -16 Then
                    PointsDis.Add(New ResultDistance(LegXIndex(I), ResultDistance.[Is].X))
                End If
                If Renderer.ShowLeftLeg AndAlso Convert.ToInt32(LegXPoint.X) = 4 AndAlso LegXPoint.Z < 2 AndAlso LegXPoint.Z > -2 AndAlso LegXPoint.Y < -4 AndAlso LegXPoint.Y > -16 Then
                    PointsDis.Add(New ResultDistance(LegXIndex(I), ResultDistance.[Is].X))
                End If
                If (Renderer.ShowRightLeg Xor Renderer.ShowLeftLeg) AndAlso Convert.ToInt32(LegXPoint.X) = 0 AndAlso LegXPoint.Z < 2 AndAlso LegXPoint.Z > -2 AndAlso LegXPoint.Y < -4 AndAlso LegXPoint.Y > -16 Then
                    PointsDis.Add(New ResultDistance(LegXIndex(I), ResultDistance.[Is].X))
                End If
                If Renderer.ShowHead AndAlso HeadYPoint.Z < 4 AndAlso HeadYPoint.Z > -4 AndAlso HeadYPoint.X < 4 AndAlso HeadYPoint.X > -4 Then
                    PointsDis.Add(New ResultDistance(HeadYIndex(I), ResultDistance.[Is].Y))
                End If
                If Renderer.ShowBody AndAlso BodyYPoint.Z < 2 AndAlso BodyYPoint.Z > -2 AndAlso BodyYPoint.X < 4 AndAlso BodyYPoint.X > -4 Then
                    PointsDis.Add(New ResultDistance(BodyYIndex(I), ResultDistance.[Is].Y))
                End If
                If Renderer.ShowRightArm AndAlso BodyYPoint.Z < 2 AndAlso BodyYPoint.Z > -2 Then
                    If (Renderer.Model = Renderer3D.Models.Steve AndAlso BodyYPoint.X > -8 AndAlso BodyYPoint.X < -4) OrElse
                        (Renderer.Model = Renderer3D.Models.Alex AndAlso BodyYPoint.X > -7 AndAlso BodyYPoint.X < -4) Then
                        PointsDis.Add(New ResultDistance(BodyYIndex(I), ResultDistance.[Is].Y))
                    End If
                End If
                If Renderer.ShowLeftArm AndAlso BodyYPoint.Z < 2 AndAlso BodyYPoint.Z > -2 Then
                    If (Renderer.Model = Renderer3D.Models.Steve AndAlso BodyYPoint.X < 8 AndAlso BodyYPoint.X > 4) OrElse
                        (Renderer.Model = Renderer3D.Models.Alex AndAlso BodyYPoint.X < 7 AndAlso BodyYPoint.X > 4) Then
                        PointsDis.Add(New ResultDistance(BodyYIndex(I), ResultDistance.[Is].Y))
                    End If
                End If
                If Renderer.ShowRightLeg AndAlso LegYPoint.Z < 2 AndAlso LegYPoint.Z > -2 AndAlso LegYPoint.X < 0 AndAlso LegYPoint.X > -4 Then
                    PointsDis.Add(New ResultDistance(LegYIndex(I), ResultDistance.[Is].Y))
                End If
                If Renderer.ShowLeftLeg AndAlso LegYPoint.Z < 2 AndAlso LegYPoint.Z > -2 AndAlso LegYPoint.X < 4 AndAlso LegYPoint.X > 0 Then
                    PointsDis.Add(New ResultDistance(LegYIndex(I), ResultDistance.[Is].Y))
                End If

            Next

            If PointsDis.Count = 0 Then Return Nothing

            Dim Smallest As New ResultDistance(1000, ResultDistance.[Is].X)

            For Each value As ResultDistance In PointsDis
                If value.Distance < Smallest.Distance Then Smallest = value
            Next

            Dim Result As Vector3 = getPointOnRay(CurrentRay, Smallest.Distance)
            If Smallest.IsWhat = ResultDistance.Is.X Then
                Result.X = CInt(Result.X)
            ElseIf Smallest.IsWhat = ResultDistance.Is.Y Then
                Result.Y = CInt(Result.Y)
            ElseIf Smallest.IsWhat = ResultDistance.Is.Z Then
                Result.Z = CInt(Result.Z)
            End If

            Return Result
        End Get
    End Property

    ReadOnly Property Mouse2ndHit As Vector3
        Get
            Update(Pos.X, Pos.Y)
            Dim HeadIndex(1) As Single
            Dim BodyIndex(1) As Single
            HeadIndex(0) = (4.24 - CamPos.Z) / CurrentRay.Z
            BodyIndex(0) = (2.12 - CamPos.Z) / CurrentRay.Z
            HeadIndex(1) = (-4.24 - CamPos.Z) / CurrentRay.Z
            BodyIndex(1) = (-2.12 - CamPos.Z) / CurrentRay.Z

            Dim HeadXIndex(1) As Single
            Dim BodyXIndex(1) As Single
            Dim RArmXIndex(1) As Single
            Dim LArmXIndex(1) As Single
            Dim RLegXIndex(1) As Single
            Dim LLegXIndex(1) As Single
            HeadXIndex(0) = (4.24 - CamPos.X) / CurrentRay.X
            HeadXIndex(1) = (-4.24 - CamPos.X) / CurrentRay.X
            BodyXIndex(0) = (-4.24 - CamPos.X) / CurrentRay.X
            BodyXIndex(1) = (4.24 - CamPos.X) / CurrentRay.X
            If Renderer.Model = Renderer3D.Models.Steve Then
                RArmXIndex(0) = (-3.88 - CamPos.X) / CurrentRay.X
                RArmXIndex(1) = (-8.12 - CamPos.X) / CurrentRay.X
                LArmXIndex(0) = (3.88 - CamPos.X) / CurrentRay.X
                LArmXIndex(1) = (8.12 - CamPos.X) / CurrentRay.X
            Else
                RArmXIndex(0) = (-3.91 - CamPos.X) / CurrentRay.X
                RArmXIndex(1) = (-7.09 - CamPos.X) / CurrentRay.X
                LArmXIndex(0) = (3.91 - CamPos.X) / CurrentRay.X
                LArmXIndex(1) = (7.09 - CamPos.X) / CurrentRay.X
            End If
            LLegXIndex(0) = (4.24 - CamPos.X) / CurrentRay.X
            RLegXIndex(0) = (-4.24 - CamPos.X) / CurrentRay.X
            RLegXIndex(1) = (0.12 - CamPos.X) / CurrentRay.X
            LLegXIndex(1) = (-0.12 - CamPos.X) / CurrentRay.X

            Dim HeadYIndex(1) As Single
            Dim BodyYIndex(1) As Single
            Dim LegYIndex(1) As Single
            HeadYIndex(0) = (16.24 - CamPos.Y) / CurrentRay.Y
            BodyYIndex(0) = (8.36 - CamPos.Y) / CurrentRay.Y
            HeadYIndex(1) = (7.76 - CamPos.Y) / CurrentRay.Y
            BodyYIndex(1) = (-4.36 - CamPos.Y) / CurrentRay.Y
            LegYIndex(0) = (-3.64 - CamPos.Y) / CurrentRay.Y
            LegYIndex(1) = (-16.36 - CamPos.Y) / CurrentRay.Y

            Dim PointsDis As New List(Of ResultDistance)

            Dim HeadPoint, BodyPoint, HeadXPoint, BodyXPoint, LArmXPoint, RArmXPoint, LLegXPoint, RLegXPoint, HeadYPoint, BodyYPoint, LegYPoint As Vector3

            For I As Byte = 0 To 1

                HeadPoint = getPointOnRay(CurrentRay, HeadIndex(I))
                BodyPoint = getPointOnRay(CurrentRay, BodyIndex(I))

                HeadXPoint = getPointOnRay(CurrentRay, HeadXIndex(I))
                BodyXPoint = getPointOnRay(CurrentRay, BodyXIndex(I))
                RArmXPoint = getPointOnRay(CurrentRay, RArmXIndex(I))
                LArmXPoint = getPointOnRay(CurrentRay, LArmXIndex(I))
                RLegXPoint = getPointOnRay(CurrentRay, RLegXIndex(I))
                LLegXPoint = getPointOnRay(CurrentRay, LLegXIndex(I))

                HeadYPoint = getPointOnRay(CurrentRay, HeadYIndex(I))
                BodyYPoint = getPointOnRay(CurrentRay, BodyYIndex(I))
                LegYPoint = getPointOnRay(CurrentRay, LegYIndex(I))

                If Renderer.Show2ndHead AndAlso HeadPoint.X < 4.24 AndAlso HeadPoint.X > -4.24 AndAlso HeadPoint.Y < 16.24 AndAlso HeadPoint.Y > 7.76 Then
                    PointsDis.Add(New ResultDistance(HeadIndex(I), ResultDistance.Is.Z))
                End If
                If Renderer.Show2ndBody AndAlso BodyPoint.X < 4.24 AndAlso BodyPoint.X > -4.24 AndAlso BodyPoint.Y < 8.36 AndAlso BodyPoint.Y > -4.36 Then
                    PointsDis.Add(New ResultDistance(BodyIndex(I), ResultDistance.Is.Z))
                End If
                If Renderer.Show2ndRightArm AndAlso BodyPoint.Y < 8.36 AndAlso BodyPoint.Y > -4.36 Then
                    If (Renderer.Model = Renderer3D.Models.Steve AndAlso BodyPoint.X < -3.88 AndAlso BodyPoint.X > -8.12) OrElse
                            (Renderer.Model = Renderer3D.Models.Alex AndAlso BodyPoint.X < -3.91 AndAlso BodyPoint.X > -7.09) Then
                        PointsDis.Add(New ResultDistance(BodyIndex(I), ResultDistance.Is.Z))
                    End If
                End If
                If Renderer.Show2ndLeftArm AndAlso BodyPoint.Y < 8.36 AndAlso BodyPoint.Y > -4.36 Then
                    If (Renderer.Model = Renderer3D.Models.Steve AndAlso BodyPoint.X < 8.12 AndAlso BodyPoint.X > 3.88) OrElse
                            (Renderer.Model = Renderer3D.Models.Alex AndAlso BodyPoint.X < 7.09 AndAlso BodyPoint.X > 3.91) Then
                        PointsDis.Add(New ResultDistance(BodyIndex(I), ResultDistance.Is.Z))
                    End If
                End If
                If Renderer.Show2ndRightLeg AndAlso BodyPoint.X < 0.12 AndAlso BodyPoint.X > -4.12 AndAlso BodyPoint.Y < -3.64 AndAlso BodyPoint.Y > -16.36 Then
                    PointsDis.Add(New ResultDistance(BodyIndex(I), ResultDistance.Is.Z))
                End If
                If Renderer.Show2ndLeftLeg AndAlso BodyPoint.X < 4.12 AndAlso BodyPoint.X > -0.12 AndAlso BodyPoint.Y < -3.64 AndAlso BodyPoint.Y > -16.36 Then
                    PointsDis.Add(New ResultDistance(BodyIndex(I), ResultDistance.Is.Z))
                End If
                If Renderer.Show2ndHead AndAlso HeadXPoint.Z < 4.24 AndAlso HeadXPoint.Z > -4.24 AndAlso HeadXPoint.Y < 16.24 AndAlso HeadXPoint.Y > 7.76 Then
                    PointsDis.Add(New ResultDistance(HeadXIndex(I), ResultDistance.Is.X))
                End If
                If Renderer.Show2ndBody AndAlso BodyXPoint.Z < 4.24 AndAlso BodyXPoint.Z > -4.24 AndAlso BodyXPoint.Y < 8.36 AndAlso BodyXPoint.Y > -4.36 Then
                    PointsDis.Add(New ResultDistance(BodyXIndex(I), ResultDistance.Is.X))
                End If
                If Renderer.Show2ndRightArm AndAlso RArmXPoint.Z < 2.12 AndAlso RArmXPoint.Z > -2.12 AndAlso RArmXPoint.Y < 8.36 AndAlso RArmXPoint.Y > -4.36 Then
                    PointsDis.Add(New ResultDistance(RArmXIndex(I), ResultDistance.Is.X))
                End If
                If Renderer.Show2ndLeftArm AndAlso LArmXPoint.Z < 2.12 AndAlso LArmXPoint.Z > -2.12 AndAlso LArmXPoint.Y < 8.36 AndAlso LArmXPoint.Y > -4.36 Then
                    PointsDis.Add(New ResultDistance(LArmXIndex(I), ResultDistance.Is.X))
                End If
                If Renderer.Show2ndRightLeg AndAlso RLegXPoint.Z < 2.12 AndAlso RLegXPoint.Z > -2.12 AndAlso RLegXPoint.Y < -3.64 AndAlso RLegXPoint.Y > -16.36 Then
                    PointsDis.Add(New ResultDistance(RLegXIndex(I), ResultDistance.Is.X))
                End If
                If Renderer.Show2ndLeftLeg AndAlso LLegXPoint.Z < 2.12 AndAlso LLegXPoint.Z > -2.12 AndAlso LLegXPoint.Y < -3.64 AndAlso LLegXPoint.Y > -16.36 Then
                    PointsDis.Add(New ResultDistance(LLegXIndex(I), ResultDistance.Is.X))
                End If
                If Renderer.Show2ndHead AndAlso HeadYPoint.Z < 4.24 AndAlso HeadYPoint.Z > -4.24 AndAlso HeadYPoint.X < 4.24 AndAlso HeadYPoint.X > -4.24 Then
                    PointsDis.Add(New ResultDistance(HeadYIndex(I), ResultDistance.Is.Y))
                End If
                If Renderer.Show2ndBody AndAlso BodyYPoint.Z < 2.12 AndAlso BodyYPoint.Z > -2.12 AndAlso BodyYPoint.X < 4.24 AndAlso BodyYPoint.X > -4.24 Then
                    PointsDis.Add(New ResultDistance(BodyYIndex(I), ResultDistance.Is.Y))
                End If
                If Renderer.Show2ndRightArm AndAlso BodyYPoint.Z < 2.12 AndAlso BodyYPoint.Z > -2.12 Then
                    If (Renderer.Model = Renderer3D.Models.Steve AndAlso BodyYPoint.X < -3.88 AndAlso BodyYPoint.X > -8.12) OrElse
                        (Renderer.Model = Renderer3D.Models.Alex AndAlso BodyYPoint.X < -3.91 AndAlso BodyYPoint.X > -7.09) Then
                        PointsDis.Add(New ResultDistance(BodyYIndex(I), ResultDistance.Is.Y))
                    End If
                End If
                If Renderer.Show2ndLeftArm AndAlso BodyYPoint.Z < 2.12 AndAlso BodyYPoint.Z > -2.12 Then
                    If (Renderer.Model = Renderer3D.Models.Steve AndAlso BodyYPoint.X < 8.12 AndAlso BodyYPoint.X > 3.88) OrElse
                        (Renderer.Model = Renderer3D.Models.Alex AndAlso BodyYPoint.X < 7.09 AndAlso BodyYPoint.X > 3.91) Then
                        PointsDis.Add(New ResultDistance(BodyYIndex(I), ResultDistance.Is.Y))
                    End If
                End If
                If Renderer.Show2ndRightLeg AndAlso LegYPoint.Z < 2.12 AndAlso LegYPoint.Z > -2.12 AndAlso LegYPoint.X < 0.12 AndAlso LegYPoint.X > -4.12 Then
                    PointsDis.Add(New ResultDistance(LegYIndex(I), ResultDistance.Is.Y))
                End If
                If Renderer.Show2ndLeftLeg AndAlso LegYPoint.Z < 2.12 AndAlso LegYPoint.Z > -2.12 AndAlso LegYPoint.X < 4.12 AndAlso LegYPoint.X > -0.12 Then
                    PointsDis.Add(New ResultDistance(LegYIndex(I), ResultDistance.Is.Y))
                End If

            Next

            If PointsDis.Count = 0 Then Return New Vector3(100, 100, 100)

            Dim Smallest As New ResultDistance(1000, ResultDistance.Is.Z)

            For Each value As ResultDistance In PointsDis
                If value.Distance < Smallest.Distance Then Smallest = value
            Next

            Dim Result As Vector3 = getPointOnRay(CurrentRay, Smallest.Distance)

            Dim ZIndex As Single() = {4.24, 2.12, -4.24, -2.12}
            Dim XIndex As Single()
            If Renderer.Model = Renderer3D.Models.Steve Then
                XIndex = {4.24, 8.12, -4.24, -8.12, -3.88, 3.88, 0.12, -0.12}
            Else
                XIndex = {4.24, 7.09, -4.24, -7.09, -3.91, 3.91, 0.12, -0.12}
            End If
            Dim YIndex As Single() = {16.24, 8.36, 7.76, -4.36, -3.64, -16.36}

            Dim AResult As Single = 20

            If Smallest.IsWhat = ResultDistance.Is.X Then
                For Each value As Single In XIndex
                    If Math.Abs(value - Result.X) < Math.Abs(AResult - Result.X) Then
                        AResult = value
                    End If
                Next
                Result.X = AResult
            ElseIf Smallest.IsWhat = ResultDistance.Is.Y Then
                For Each value As Single In YIndex
                    If Math.Abs(value - Result.Y) < Math.Abs(AResult - Result.Y) Then
                        AResult = value
                    End If
                Next
                Result.Y = AResult
            ElseIf Smallest.IsWhat = ResultDistance.Is.Z Then
                For Each value As Single In ZIndex
                    If Math.Abs(value - Result.Z) < Math.Abs(AResult - Result.Z) Then
                        AResult = value
                    End If
                Next
                Result.Z = AResult
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