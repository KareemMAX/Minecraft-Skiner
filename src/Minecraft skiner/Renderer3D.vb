Imports TK = OpenTK
Imports GLGarphics = OpenTK.Graphics
Imports OpenTK.Graphics.OpenGL
Public Class Renderer3D
    Private _Skin As Bitmap
    ''' <summary>
    ''' The visible skin on the renderer
    ''' </summary>
    ''' <returns>The visible skin</returns>
    Property Skin As Bitmap
        Set(value As Bitmap)
            If Not (value.Height = 64 Or value.Height = 32) And value.Width = 64 Then 'Check the skin
                Throw New ExSkinRes
            End If
            _Skin = value
        End Set
        Get
            Return _Skin
        End Get
    End Property

    Dim _showhead As Boolean = True
    ''' <summary>
    ''' Show the head or not
    ''' </summary>
    ''' <returns>Show the head or not</returns>
    Property ShowHead As Boolean
        Set(value As Boolean)
            Refresh()
            _showhead = value
        End Set
        Get
            Return _showhead
        End Get
    End Property
    Dim _show2ndhead As Boolean = True
    ''' <summary>
    ''' Show the second head layer or not
    ''' </summary>
    ''' <returns>Show the second head layer or not</returns>
    Property Show2ndHead As Boolean
        Set(value As Boolean)
            Refresh()
            _show2ndhead = value
        End Set
        Get
            Return _show2ndhead
        End Get
    End Property
    Dim _showbody As Boolean = True
    ''' <summary>
    ''' Show the body or not
    ''' </summary>
    ''' <returns>Show the body or not</returns>
    Property ShowBody As Boolean
        Set(value As Boolean)
            Refresh()
            _showbody = value
        End Set
        Get
            Return _showbody
        End Get
    End Property
    Dim _show2ndbody As Boolean = True
    ''' <summary>
    ''' Show the second body layer or not
    ''' </summary>
    ''' <returns>Show the second body layer or not</returns>
    Property Show2ndBody As Boolean
        Set(value As Boolean)
            Refresh()
            _show2ndbody = value
        End Set
        Get
            Return _show2ndbody
        End Get
    End Property
    Dim _showra As Boolean = True
    ''' <summary>
    ''' Show the right arm or not
    ''' </summary>
    ''' <returns>Show the right arm or not</returns>
    Property ShowRightArm As Boolean
        Set(value As Boolean)
            Refresh()
            _showra = value
        End Set
        Get
            Return _showra
        End Get
    End Property
    Dim _show2ndra As Boolean = True
    ''' <summary>
    ''' Show the second right arm layer or not
    ''' </summary>
    ''' <returns>Show the second right arm layer or not</returns>
    Property Show2ndRightArm As Boolean
        Set(value As Boolean)
            Refresh()
            _show2ndra = value
        End Set
        Get
            Return _show2ndra
        End Get
    End Property
    Dim _showla As Boolean = True
    ''' <summary>
    ''' Show the left arm or not
    ''' </summary>
    ''' <returns>Show the leftht arm or not</returns>
    Property ShowLeftArm As Boolean
        Set(value As Boolean)
            Refresh()
            _showla = value
        End Set
        Get
            Return _showla
        End Get
    End Property
    Dim _show2ndla As Boolean = True
    ''' <summary>
    ''' Show the second left arm layer or not
    ''' </summary>
    ''' <returns>Show the second left arm layer or not</returns>
    Property Show2ndLeftArm As Boolean
        Set(value As Boolean)
            Refresh()
            _show2ndla = value
        End Set
        Get
            Return _show2ndla
        End Get
    End Property
    Dim _showrl As Boolean = True
    ''' <summary>
    ''' Show the right leg or not
    ''' </summary>
    ''' <returns>Show the right leg or not</returns>
    Property ShowRightLeg As Boolean
        Set(value As Boolean)
            Refresh()
            _showrl = value
        End Set
        Get
            Return _showrl
        End Get
    End Property
    Dim _show2ndrl As Boolean = True
    ''' <summary>
    ''' Show the second right leg layer or not
    ''' </summary>
    ''' <returns>Show the second right leg layer or not</returns>
    Property Show2ndRightLeg As Boolean
        Set(value As Boolean)
            Refresh()
            _show2ndrl = value
        End Set
        Get
            Return _show2ndrl
        End Get
    End Property
    Dim _showll As Boolean = True
    ''' <summary>
    ''' Show the left leg or not
    ''' </summary>
    ''' <returns>Show the leftht leg or not</returns>
    Property ShowLeftLeg As Boolean
        Set(value As Boolean)
            Refresh()
            _showll = value
        End Set
        Get
            Return _showll
        End Get
    End Property
    Dim _show2ndll As Boolean = True
    ''' <summary>
    ''' Show the second left leg layer or not
    ''' </summary>
    ''' <returns>Show the second left leg layer or not</returns>
    Property Show2ndLeftLeg As Boolean
        Set(value As Boolean)
            Refresh()
            _show2ndll = value
        End Set
        Get
            Return _show2ndll
        End Get
    End Property


    Enum Models
        Steve
        Alex
    End Enum
    ''' <summary>
    ''' The rendered model
    ''' </summary>
    ''' <returns>The rendered model</returns>
    Property Model As Models

    Private Sub GlControl_Paint(sender As Object, e As PaintEventArgs) Handles GlControl.Paint
        'First Clear Buffers
        GL.Clear(ClearBufferMask.ColorBufferBit)
        GL.Clear(ClearBufferMask.DepthBufferBit)

        'Basic Setup for viewing
        Dim perspective As TK.Matrix4 = TK.Matrix4.CreatePerspectiveFieldOfView(1.04, 4 / 3, 1, 10000) 'Setup Perspective
        Dim lookat As TK.Matrix4 = TK.Matrix4.LookAt(35, 0, 0, 0, 0, 0, 0, 1, 0) 'Setup camera
        GL.MatrixMode(MatrixMode.Projection) 'Load Perspective
        GL.LoadIdentity()
        GL.LoadMatrix(perspective)
        GL.MatrixMode(MatrixMode.Modelview) 'Load Camera
        GL.LoadIdentity()
        GL.LoadMatrix(lookat)
        GL.Viewport(0, 0, GlControl.Width, GlControl.Height) 'Size of window
        GL.Enable(EnableCap.DepthTest) 'Enable correct Z Drawings
        GL.DepthFunc(DepthFunction.Less) 'Enable correct Z Drawings

        'Rotating
        GL.Rotate(90, 0, 1, 0)

        'Vertex goes (X,Y,Z)
        GL.Begin(BeginMode.Quads)
        'Body
        If ShowBody Then
            'Face 1
            GL.Color3(Color.Red)
            GL.Vertex3(-4, 8, 2)
            GL.Color3(Color.White)
            GL.Vertex3(4, 8, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(4, -4, 2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-4, -4, 2)
            'Face 2
            GL.Color3(Color.Red)
            GL.Vertex3(-4, 8, -2)
            GL.Color3(Color.White)
            GL.Vertex3(4, 8, -2)
            GL.Color3(Color.Blue)
            GL.Vertex3(4, -4, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-4, -4, -2)
            'Face 3
            GL.Color3(Color.Red)
            GL.Vertex3(-4, 8, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(-4, 8, -2)
            GL.Color3(Color.White)
            GL.Vertex3(-4, -4, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-4, -4, 2)
            'Face 4
            GL.Color3(Color.Red)
            GL.Vertex3(4, 8, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(4, 8, -2)
            GL.Color3(Color.White)
            GL.Vertex3(4, -4, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(4, -4, 2)
            'Face 5
            GL.Color3(Color.Red)
            GL.Vertex3(-4, 8, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(4, 8, 2)
            GL.Color3(Color.White)
            GL.Vertex3(4, 8, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-4, 8, -2)
            'Face 6
            GL.Color3(Color.Red)
            GL.Vertex3(-4, -4, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(4, -4, 2)
            GL.Color3(Color.White)
            GL.Vertex3(4, -4, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-4, -4, -2)
        End If

        If ShowHead Then
            'Head
            'Face 1
            GL.Color3(Color.Red)
            GL.Vertex3(-4, 16, 4)
            GL.Color3(Color.White)
            GL.Vertex3(4, 16, 4)
            GL.Color3(Color.Blue)
            GL.Vertex3(4, 8, 4)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-4, 8, 4)
            'Face 2
            GL.Color3(Color.Red)
            GL.Vertex3(-4, 16, -4)
            GL.Color3(Color.White)
            GL.Vertex3(4, 16, -4)
            GL.Color3(Color.Blue)
            GL.Vertex3(4, 8, -4)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-4, 8, -4)
            'Face 3
            GL.Color3(Color.Red)
            GL.Vertex3(-4, 16, 4)
            GL.Color3(Color.Blue)
            GL.Vertex3(-4, 16, -4)
            GL.Color3(Color.White)
            GL.Vertex3(-4, 8, -4)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-4, 8, 4)
            'Face 4
            GL.Color3(Color.Red)
            GL.Vertex3(4, 16, 4)
            GL.Color3(Color.Blue)
            GL.Vertex3(4, 16, -4)
            GL.Color3(Color.White)
            GL.Vertex3(4, 8, -4)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(4, 8, 4)
            'Face 5
            GL.Color3(Color.Red)
            GL.Vertex3(-4, 16, 4)
            GL.Color3(Color.Blue)
            GL.Vertex3(4, 16, 4)
            GL.Color3(Color.White)
            GL.Vertex3(4, 16, -4)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-4, 16, -4)
            'Face 6
            GL.Color3(Color.Red)
            GL.Vertex3(-4, 8, 4)
            GL.Color3(Color.Blue)
            GL.Vertex3(4, 8, 4)
            GL.Color3(Color.White)
            GL.Vertex3(4, 8, -4)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-4, 8, -4)
        End If

        If ShowLeftArm Then
            'LefttArm
            'Face 1
            GL.Color3(Color.Red)
            GL.Vertex3(4, 8, 2)
            GL.Color3(Color.White)
            GL.Vertex3(8, 8, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(8, -4, 2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(4, -4, 2)
            'Face 2
            GL.Color3(Color.Red)
            GL.Vertex3(4, 8, -2)
            GL.Color3(Color.White)
            GL.Vertex3(8, 8, -2)
            GL.Color3(Color.Blue)
            GL.Vertex3(8, -4, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(4, -4, -2)
            'Face 3
            GL.Color3(Color.Red)
            GL.Vertex3(4, 8, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(4, 8, -2)
            GL.Color3(Color.White)
            GL.Vertex3(4, -4, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(4, -4, 2)
            'Face 4
            GL.Color3(Color.Red)
            GL.Vertex3(8, 8, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(8, 8, -2)
            GL.Color3(Color.White)
            GL.Vertex3(8, -4, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(8, -4, 2)
            'Face 5
            GL.Color3(Color.Red)
            GL.Vertex3(4, 8, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(8, 8, 2)
            GL.Color3(Color.White)
            GL.Vertex3(8, 8, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(4, 8, -2)
            'Face 6
            GL.Color3(Color.Red)
            GL.Vertex3(4, -4, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(8, -4, 2)
            GL.Color3(Color.White)
            GL.Vertex3(8, -4, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(4, -4, -2)
        End If

        If ShowRightArm Then
            'RightArm
            'Face 1
            GL.Color3(Color.Red)
            GL.Vertex3(-8, 8, 2)
            GL.Color3(Color.White)
            GL.Vertex3(-4, 8, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(-4, -4, 2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-8, -4, 2)
            'Face 2
            GL.Color3(Color.Red)
            GL.Vertex3(-8, 8, -2)
            GL.Color3(Color.White)
            GL.Vertex3(-4, 8, -2)
            GL.Color3(Color.Blue)
            GL.Vertex3(-4, -4, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-8, -4, -2)
            'Face 3
            GL.Color3(Color.Red)
            GL.Vertex3(-8, 8, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(-8, 8, -2)
            GL.Color3(Color.White)
            GL.Vertex3(-8, -4, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-8, -4, 2)
            'Face 4
            GL.Color3(Color.Red)
            GL.Vertex3(-4, 8, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(-4, 8, -2)
            GL.Color3(Color.White)
            GL.Vertex3(-4, -4, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-4, -4, 2)
            'Face 5
            GL.Color3(Color.Red)
            GL.Vertex3(-8, 8, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(-4, 8, 2)
            GL.Color3(Color.White)
            GL.Vertex3(-4, 8, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-8, 8, -2)
            'Face 6
            GL.Color3(Color.Red)
            GL.Vertex3(-8, -4, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(-4, -4, 2)
            GL.Color3(Color.White)
            GL.Vertex3(-4, -4, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-8, -4, -2)
        End If

        If ShowRightLeg Then
            'RightLeg
            'Face 1
            GL.Color3(Color.Red)
            GL.Vertex3(-4, -4, 2)
            GL.Color3(Color.White)
            GL.Vertex3(0, -4, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(0, -16, 2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-4, -16, 2)
            'Face 2
            GL.Color3(Color.Red)
            GL.Vertex3(-4, -4, -2)
            GL.Color3(Color.White)
            GL.Vertex3(0, -4, -2)
            GL.Color3(Color.Blue)
            GL.Vertex3(0, -16, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-4, -16, -2)
            'Face 3
            GL.Color3(Color.Red)
            GL.Vertex3(-4, -4, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(-4, -4, -2)
            GL.Color3(Color.White)
            GL.Vertex3(-4, -16, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-4, -16, 2)
            'Face 4
            GL.Color3(Color.Red)
            GL.Vertex3(0, -4, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(0, -4, -2)
            GL.Color3(Color.White)
            GL.Vertex3(0, -16, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(0, -16, 2)
            'Face 5
            GL.Color3(Color.Red)
            GL.Vertex3(-4, -4, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(0, -4, 2)
            GL.Color3(Color.White)
            GL.Vertex3(0, -4, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-4, -4, -2)
            'Face 6
            GL.Color3(Color.Red)
            GL.Vertex3(-4, -16, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(0, -16, 2)
            GL.Color3(Color.White)
            GL.Vertex3(0, -16, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(-4, -16, -2)
        End If

        If ShowLeftLeg Then
            'LeftLeg
            'Face 1
            GL.Color3(Color.Red)
            GL.Vertex3(0, -4, 2)
            GL.Color3(Color.White)
            GL.Vertex3(4, -4, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(4, -16, 2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(0, -16, 2)
            'Face 2
            GL.Color3(Color.Red)
            GL.Vertex3(0, -4, -2)
            GL.Color3(Color.White)
            GL.Vertex3(4, -4, -2)
            GL.Color3(Color.Blue)
            GL.Vertex3(4, -16, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(0, -16, -2)
            'Face 3
            GL.Color3(Color.Red)
            GL.Vertex3(0, -4, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(0, -4, -2)
            GL.Color3(Color.White)
            GL.Vertex3(0, -16, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(0, -16, 2)
            'Face 4
            GL.Color3(Color.Red)
            GL.Vertex3(4, -4, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(4, -4, -2)
            GL.Color3(Color.White)
            GL.Vertex3(4, -16, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(4, -16, 2)
            'Face 5
            GL.Color3(Color.Red)
            GL.Vertex3(0, -4, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(4, -4, 2)
            GL.Color3(Color.White)
            GL.Vertex3(4, -4, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(0, -4, -2)
            'Face 6
            GL.Color3(Color.Red)
            GL.Vertex3(0, -16, 2)
            GL.Color3(Color.Blue)
            GL.Vertex3(4, -16, 2)
            GL.Color3(Color.White)
            GL.Vertex3(4, -16, -2)
            GL.Color3(Color.BurlyWood)
            GL.Vertex3(0, -16, -2)
        End If

        'Finish the begin mode with "end"
        GL.End()

        'Finally...
        GlControl.SwapBuffers() 'Takes from the 'GL' and puts into control
    End Sub

    Private Sub Renderer3D_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        GlControl.Refresh()
    End Sub
End Class
