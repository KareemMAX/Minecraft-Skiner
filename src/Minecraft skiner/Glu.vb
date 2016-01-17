Imports OpenTK
Imports OpenTK.Graphics.OpenGL

'Copied from http://www.opentk.com/files/Glu.cs
'And translated by http://www.carlosag.net/tools/codetranslator/
'So maybe it have some missing code

Namespace Imgui

    Public Class Glu

        Public Overloads Shared Function intersect_RayTriangle(ByVal RP0 As Vector3d, ByVal RP1 As Vector3d, ByVal TV0 As Vector3, ByVal TV1 As Vector3, ByVal TV2 As Vector3, ByRef I As Vector3) As Integer
            Dim _RP0 As Vector3 = New Vector3(CType(RP0.X, Single), CType(RP0.Y, Single), CType(RP0.Z, Single))
            Dim _RP1 As Vector3 = New Vector3(CType(RP1.X, Single), CType(RP1.Y, Single), CType(RP1.Z, Single))
            Return Glu.intersect_RayTriangle(_RP0, _RP1, TV0, TV1, TV2, I)
        End Function

        Private Shared SMALL_NUM As Double = 0.00000001

        ' intersect_RayTriangle(): intersect a ray with a 3D triangle
        '    Input:  a ray R, and a triangle T
        '    Output: *I = intersection point (when it exists)
        '    Return: -1 = triangle is degenerate (a segment or point)
        '             0 = disjoint (no intersect)
        '             1 = intersect in unique point I
        '               2 = intersect in unique point I, from back face of triangle
        '             3 = are in the same plane
        Public Overloads Shared Function intersect_RayTriangle(ByVal RP0 As Vector3, ByVal RP1 As Vector3, ByVal TV0 As Vector3, ByVal TV1 As Vector3, ByVal TV2 As Vector3, ByRef I As Vector3) As Integer
            Dim n As Vector3
            Dim u As Vector3
            Dim v As Vector3
            ' triangle vectors
            Dim w As Vector3
            Dim dir As Vector3
            Dim w0 As Vector3
            ' ray vectors
            Dim b As Single
            Dim r As Single
            Dim a As Single
            ' params to calc ray-plane intersect
            ' get triangle edge vectors and plane normal
            u = (TV1 - TV0)
            v = (TV2 - TV0)
            n = Vector3.Cross(u, v)
            ' cross product
            If (n = New Vector3(0, 0, 0)) Then
                Return -1
            End If

            ' do not deal with this case
            dir = (RP1 - RP0)
            ' ray direction vector
            w0 = (RP0 - TV0)
            a = (Vector3.Dot(n, w0) * -1)
            b = Vector3.Dot(n, dir)
            If (Math.Abs(b) < SMALL_NUM) Then
                ' ray is parallel to triangle plane
                If (a = 0) Then
                    Return 3
                Else
                    Return 0
                End If

                ' ray disjoint from plane
            End If

            ' get intersect point of ray with triangle plane
            r = (a / b)
            If (r < 0!) Then
                Return 0
            End If

            ' => no intersect
            ' for a segment, also test if (r > 1.0) => no intersect
            I = (RP0 _
                        + (r * dir))
            ' intersect point of ray and plane        
            ' is I inside T?
            Dim D As Single
            Dim uu As Single
            Dim uv As Single
            Dim vv As Single
            Dim wu As Single
            Dim wv As Single
            uu = Vector3.Dot(u, u)
            uv = Vector3.Dot(u, v)
            vv = Vector3.Dot(v, v)
            w = (I - TV0)
            wu = Vector3.Dot(w, u)
            wv = Vector3.Dot(w, v)
            D = ((uv * uv) _
                        - (uu * vv))
            ' get and test parametric coords
            Dim t As Single
            Dim s As Single
            s = (((uv * wv) _
                        - (vv * wu)) _
                        / D)
            If ((s < 0!) _
                        OrElse (s > 1.0!)) Then
                Return 0
            End If

            t = (((uv * wu) _
                        - (uu * wv)) _
                        / D)
            If ((t < 0!) _
                        OrElse ((s + t) _
                        > 1.0!)) Then
                Return 0
            End If

            If (b < 0) Then
                Return 2
            End If

            ' I is in T, intersecting from back face
            Return 1
            ' I is in T
        End Function

        Private __glPi As Double = 3.1415926535897931

        Private Sub gluPerspective(ByVal fovy As Double, ByVal aspect As Double, ByVal zNear As Double, ByVal zFar As Double)
            Dim m As Matrix4d = Matrix4d.Identity
            Dim deltaZ As Double
            Dim sine As Double
            Dim cotangent As Double
            Dim radians As Double = (fovy / (2 _
                        * (Me.__glPi / 180)))
            deltaZ = (zFar - zNear)
            sine = Math.Sin(radians)
            If ((deltaZ = 0) _
                        OrElse ((sine = 0) _
                        OrElse (aspect = 0))) Then
                Return
            End If

            'TODO: check why this cos was written COS?
            cotangent = (Math.Cos(radians) / sine)
            m.M11 = (cotangent / aspect)
            m.M22 = cotangent
            m.M33 = (((zFar + zNear) _
                        / deltaZ) _
                        * -1)
            m.M34 = -1
            m.M43 = ((2 _
                        * (zNear _
                        * (zFar / deltaZ))) _
                        * -1)
            m.M44 = 0
            GL.MultMatrix(m)
        End Sub

        Public Sub LookAt(ByVal eye As Vector3, ByVal center As Vector3, ByVal up As Vector3)
            Me.gluLookAt(eye.X, eye.Y, eye.Z, center.X, center.Y, center.Z, up.X, up.Y, up.Z)
        End Sub

        Private Sub gluLookAt(ByVal eyex As Double, ByVal eyey As Double, ByVal eyez As Double, ByVal centerx As Double, ByVal centery As Double, ByVal centerz As Double, ByVal upx As Double, ByVal upy As Double, ByVal upz As Double)
            Dim up As Vector3
            Dim forward As Vector3
            Dim side As Vector3
            Dim m As Matrix4
            forward.X = CType((centerx - eyex), Single)
            forward.Y = CType((centery - eyey), Single)
            forward.Z = CType((centerz - eyez), Single)
            up.X = CType(upx, Single)
            up.Y = CType(upy, Single)
            up.Z = CType(upz, Single)
            forward.Normalize()
            side = Vector3.Cross(forward, up)
            side.Normalize()
            up = Vector3.Cross(side, forward)
            m = Matrix4.Identity
            m.M11 = side.X
            m.M21 = side.Y
            m.M31 = side.Z
            m.M12 = up.X
            m.M22 = up.Y
            m.M32 = up.Z
            m.M13 = (forward.X * -1)
            m.M23 = (forward.Y * -1)
            m.M33 = (forward.Z * -1)
            GL.MultMatrix(m)
            GL.Translate((eyex * -1), (eyey * -1), (eyez * -1))
        End Sub

        Public Overloads Function Project(ByVal obj As Vector3d, ByRef win As Vector3d) As Integer
            Dim modelMatrix As Matrix4d
            GL.GetDouble(GetPName.ModelviewMatrix, modelMatrix)
            Dim projMatrix As Matrix4d
            GL.GetDouble(GetPName.ProjectionMatrix, projMatrix)
            Dim viewport() As Integer = New Integer((4) - 1) {}
            GL.GetInteger(GetPName.Viewport, viewport)
            Return Me.Project(obj, modelMatrix, projMatrix, viewport, win)
        End Function

        Public Overloads Function Project(ByVal obj As Vector3d, ByVal modelMatrix As Matrix4d, ByVal projMatrix As Matrix4d, ByVal viewport() As Integer, ByRef win As Vector3d) As Integer
            Return Me.gluProject(obj.X, obj.Y, obj.Z, modelMatrix, projMatrix, viewport, win.X, win.Y, win.Z)
        End Function

        Private Function gluProject(ByVal objx As Double, ByVal objy As Double, ByVal objz As Double, ByVal modelMatrix As Matrix4d, ByVal projMatrix As Matrix4d, ByVal viewport() As Integer, ByRef winx As Double, ByRef winy As Double, ByRef winz As Double) As Integer
            Dim _in As Vector4d
            Dim _out As Vector4d
            _in.X = objx
            _in.Y = objy
            _in.Z = objz
            _in.W = 1
            '__gluMultMatrixVecd(modelMatrix, in, out);
            '__gluMultMatrixVecd(projMatrix, out, in);
            'TODO: check if multiplication is in right order
            _out = Vector4d.Transform(_in, modelMatrix)
            _in = Vector4d.Transform(_out, projMatrix)
            If (_in.W = 0) Then
                Return 0
            End If

            _in.X /= _in.W
            _in.Y /= _in.W
            _in.Z /= _in.W
            _in.X = ((_in.X * 0.5) _
                        + 0.5)
            _in.Y = ((_in.Y * 0.5) _
                        + 0.5)
            _in.Z = ((_in.Z * 0.5) _
                        + 0.5)
            _in.X = ((_in.X * viewport(2)) _
                        + viewport(0))
            _in.Y = ((_in.Y * viewport(3)) _
                        + viewport(1))
            winx = _in.X
            winy = _in.Y
            winz = _in.Z
            Return 1
        End Function

        Public Overloads Shared Function UnProject(ByVal win As Vector3d, ByRef obj As Vector3d) As Integer
            Dim modelMatrix As Matrix4d
            GL.GetDouble(GetPName.ModelviewMatrix, modelMatrix)
            Dim projMatrix As Matrix4d
            GL.GetDouble(GetPName.ProjectionMatrix, projMatrix)
            Dim viewport() As Integer = New Integer((4) - 1) {}
            GL.GetInteger(GetPName.Viewport, viewport)
            Return Glu.UnProject(win, modelMatrix, projMatrix, viewport, obj)
        End Function

        Public Overloads Shared Function UnProject(ByVal win As Vector3d, ByVal modelMatrix As Matrix4d, ByVal projMatrix As Matrix4d, ByVal viewport() As Integer, ByRef obj As Vector3d) As Integer
            Return Glu.gluUnProject(win.X, win.Y, win.Z, modelMatrix, projMatrix, viewport, obj.X, obj.Y, obj.Z)
        End Function

        Private Shared Function gluUnProject(ByVal winx As Double, ByVal winy As Double, ByVal winz As Double, ByVal modelMatrix As Matrix4d, ByVal projMatrix As Matrix4d, ByVal viewport() As Integer, ByRef objx As Double, ByRef objy As Double, ByRef objz As Double) As Integer
            Dim finalMatrix As Matrix4d
            Dim _in As Vector4d
            Dim _out As Vector4d
            finalMatrix = Matrix4d.Mult(modelMatrix, projMatrix)
            'if (!__gluInvertMatrixd(finalMatrix, finalMatrix)) return(GL_FALSE);
            finalMatrix.Invert()
            _in.X = winx
            _in.Y = winy
            _in.Z = winz
            _in.W = 1
            _in.X = ((_in.X - viewport(0)) _
                        / viewport(2))
            _in.Y = ((_in.Y - viewport(1)) _
                        / viewport(3))
            _in.X = ((_in.X * 2) _
                        - 1)
            _in.Y = ((_in.Y * 2) _
                        - 1)
            _in.Z = ((_in.Z * 2) _
                        - 1)
            '__gluMultMatrixVecd(finalMatrix, _in, _out);
            ' check if this works:
            _out = Vector4d.Transform(_in, finalMatrix)
            If (_out.W = 0) Then
                Return 0
            End If

            _out.X /= _out.W
            _out.Y /= _out.W
            _out.Z /= _out.W
            objx = _out.X
            objy = _out.Y
            objz = _out.Z
            Return 1
        End Function

        Private Function gluUnProject4(ByVal winx As Double, ByVal winy As Double, ByVal winz As Double, ByVal clipw As Double, ByVal modelMatrix As Matrix4d, ByVal projMatrix As Matrix4d, ByVal viewport() As Integer, ByVal near As Double, ByVal far As Double, ByRef objx As Double, ByRef objy As Double, ByRef objz As Double, ByRef objw As Double) As Integer
            Dim finalMatrix As Matrix4d
            Dim _in As Vector4d
            Dim _out As Vector4d
            finalMatrix = Matrix4d.Mult(modelMatrix, projMatrix)
            'if (!__gluInvertMatrixd(finalMatrix, finalMatrix)) return(GL_FALSE);
            finalMatrix.Invert()
            _in.X = winx
            _in.Y = winy
            _in.Z = winz
            _in.W = clipw
            _in.X = ((_in.X - viewport(0)) _
                        / viewport(2))
            _in.Y = ((_in.Y - viewport(1)) _
                        / viewport(3))
            _in.Z = ((_in.Z - near) _
                        / (far - near))
            _in.X = ((_in.X * 2) _
                        - 1)
            _in.Y = ((_in.Y * 2) _
                        - 1)
            _in.Z = ((_in.Z * 2) _
                        - 1)
            ' TODO: check again (same order issue as prev. todos)
            _out = Vector4d.Transform(_in, finalMatrix)
            If (_out.W = 0) Then
                Return 0
            End If

            objx = _out.X
            objy = _out.Y
            objz = _out.Z
            objw = _out.W
            Return 1
        End Function

        Private Sub gluPickMatrix(ByVal x As Double, ByVal y As Double, ByVal deltax As Double, ByVal deltay As Double, ByVal viewport() As Integer)
            If ((deltax <= 0) _
                        OrElse (deltay <= 0)) Then
                Return
            End If

            GL.Translate(((viewport(2) - (2 _
                            * (x - viewport(0)))) _
                            / deltax), ((viewport(3) - (2 _
                            * (y - viewport(1)))) _
                            / deltay), 0)
            'glScalef(viewport[2] / deltax, viewport[3] / deltay, 1.0);
            GL.Scale((viewport(2) / deltax), (viewport(3) / deltay), 1)
        End Sub
    End Class
End Namespace