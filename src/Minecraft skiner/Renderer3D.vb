Imports TK = OpenTK
Imports GLGarphics = OpenTK.Graphics
Imports OpenTK.Graphics.OpenGL
Imports System.Drawing.Imaging

Public Class Renderer3D
    Private _Skin As Bitmap
    ''' <summary>
    ''' The visible skin on the renderer
    ''' </summary>
    ''' <returns>The visible skin</returns>
    Property Skin As Bitmap
        Set(value As Bitmap)
            If Not value.Height = 64 And value.Width = 64 Then 'Check the skin
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

    ''' <summary>
    ''' X rotation
    ''' </summary>
    ''' <returns>X rotattion</returns>
    Property RotationX As Integer

    ''' <summary>
    ''' Y rotation
    ''' </summary>
    ''' <returns>Y rotation</returns>
    Property RotationY As Integer = 90

    Dim _Zoom As Double = 1
    Property Zoom As Double
        Set(value As Double)
            If value < 1 Then
                value = 1
            ElseIf value > 10 Then
                value = 10
            End If

            _Zoom = value
        End Set
        Get
            Return _Zoom
        End Get
    End Property

    Dim _LookX As Double = 0
    Property LookX As Double
        Set(value As Double)
            If value < -8 Then
                value = -8
            ElseIf value > 8 Then
                value = 8
            End If

            _LookX = value
        End Set
        Get
            Return _LookX
        End Get
    End Property


    Dim _LookY As Double = 0
    Property LookY As Double
        Set(value As Double)
            If value < -16 Then
                value = -16
            ElseIf value > 16 Then
                value = 16
            End If

            _LookY = value
        End Set
        Get
            Return _LookY
        End Get
    End Property

    ''' <summary>
    ''' Stop the paint faction
    ''' </summary>
    ''' <returns>Is stopped or not</returns>
    Property InDesignMode As Boolean = True

    Private Sub GlControl_Paint(sender As Object, e As PaintEventArgs) Handles GlControl.Paint
        If InDesignMode Then Exit Sub
        GL.ClearColor(BackColor)
        'First Clear Buffers
        GL.Clear(ClearBufferMask.ColorBufferBit)
        GL.Clear(ClearBufferMask.DepthBufferBit)

        'Basic Setup for viewing
        Dim perspective As TK.Matrix4 = TK.Matrix4.CreatePerspectiveFieldOfView(Zoom ^ -1, Width / Height, 1, 100) 'Setup Perspective
        Dim lookat As TK.Matrix4 = TK.Matrix4.LookAt(36, LookY, LookX, 0, LookY, LookX, 1, 1, 0) 'Setup camera
        GL.MatrixMode(MatrixMode.Projection) 'Load Perspective
        GL.LoadIdentity()
        GL.LoadMatrix(perspective)
        GL.MatrixMode(MatrixMode.Modelview) 'Load Camera
        GL.LoadIdentity()
        GL.LoadMatrix(lookat)
        GL.Viewport(0, 0, GlControl.Width, GlControl.Height) 'Size of window
        GL.Enable(EnableCap.DepthTest) 'Enable correct Z Drawings
        GL.Enable(EnableCap.Texture2D) 'Enable textures
        GL.DepthFunc(DepthFunction.Less) 'Enable correct Z Drawings
        GL.Disable(EnableCap.Blend) 'Disable transparent

        'Load the textures
        Dim texID As Integer = GL.GenTexture()
        GL.BindTexture(TextureTarget.Texture2D, texID)
        Dim data As BitmapData = Skin.LockBits(New System.Drawing.Rectangle(0, 0, 64, 64),
   ImageLockMode.ReadOnly, Imaging.PixelFormat.Format32bppPArgb)
        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, 64, 64, 0,
    GLGarphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0)
        Skin.UnlockBits(data)
        GL.GenerateMipmap(GenerateMipmapTarget.Texture2D)
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureMinFilter.Nearest)
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureMagFilter.Nearest)

        Const TexVal As Double = 1 / 64

        'Rotating
        GL.Rotate(RotationX, 0, 0, 1)
        GL.Rotate(RotationY, 0, 1, 0)

        GL.BindTexture(TextureTarget.ProxyTexture2D, texID)
        'Vertex goes (X,Y,Z)
        GL.Begin(BeginMode.Quads)
        'Body
        If ShowBody Then
            'Face 1
            GL.TexCoord2(TexVal * 20, TexVal * 20)
            GL.Vertex3(-4, 8, 2)
            GL.TexCoord2(TexVal * 28, TexVal * 20)
            GL.Vertex3(4, 8, 2)
            GL.TexCoord2(TexVal * 28, TexVal * 32)
            GL.Vertex3(4, -4, 2)
            GL.TexCoord2(TexVal * 20, TexVal * 32)
            GL.Vertex3(-4, -4, 2)
            'Face 2
            GL.TexCoord2(TexVal * 40, TexVal * 20)
            GL.Vertex3(-4, 8, -2)
            GL.TexCoord2(TexVal * 32, TexVal * 20)
            GL.Vertex3(4, 8, -2)
            GL.TexCoord2(TexVal * 32, TexVal * 32)
            GL.Vertex3(4, -4, -2)
            GL.TexCoord2(TexVal * 40, TexVal * 32)
            GL.Vertex3(-4, -4, -2)
            'Face 3
            GL.TexCoord2(TexVal * 20, TexVal * 20)
            GL.Vertex3(-4, 8, 2)
            GL.TexCoord2(TexVal * 16, TexVal * 20)
            GL.Vertex3(-4, 8, -2)
            GL.TexCoord2(TexVal * 16, TexVal * 32)
            GL.Vertex3(-4, -4, -2)
            GL.TexCoord2(TexVal * 20, TexVal * 32)
            GL.Vertex3(-4, -4, 2)
            'Face 4
            GL.TexCoord2(TexVal * 28, TexVal * 20)
            GL.Vertex3(4, 8, 2)
            GL.TexCoord2(TexVal * 32, TexVal * 20)
            GL.Vertex3(4, 8, -2)
            GL.TexCoord2(TexVal * 32, TexVal * 32)
            GL.Vertex3(4, -4, -2)
            GL.TexCoord2(TexVal * 28, TexVal * 32)
            GL.Vertex3(4, -4, 2)
            'Face 5
            GL.TexCoord2(TexVal * 20, TexVal * 20)
            GL.Vertex3(-4, 8, 2)
            GL.TexCoord2(TexVal * 28, TexVal * 20)
            GL.Vertex3(4, 8, 2)
            GL.TexCoord2(TexVal * 28, TexVal * 16)
            GL.Vertex3(4, 8, -2)
            GL.TexCoord2(TexVal * 20, TexVal * 16)
            GL.Vertex3(-4, 8, -2)
            'Face 6
            GL.TexCoord2(TexVal * 28, TexVal * 16)
            GL.Vertex3(-4, -4, 2)
            GL.TexCoord2(TexVal * 36, TexVal * 16)
            GL.Vertex3(4, -4, 2)
            GL.TexCoord2(TexVal * 36, TexVal * 20)
            GL.Vertex3(4, -4, -2)
            GL.TexCoord2(TexVal * 28, TexVal * 20)
            GL.Vertex3(-4, -4, -2)
        End If

        If ShowHead Then
            'Head
            'Face 1
            GL.TexCoord2(TexVal * 8, TexVal * 8)
            GL.Vertex3(-4, 16, 4)
            GL.TexCoord2(TexVal * 16, TexVal * 8)
            GL.Vertex3(4, 16, 4)
            GL.TexCoord2(TexVal * 16, TexVal * 16)
            GL.Vertex3(4, 8, 4)
            GL.TexCoord2(TexVal * 8, TexVal * 16)
            GL.Vertex3(-4, 8, 4)
            'Face 2
            GL.TexCoord2(TexVal * 32, TexVal * 8)
            GL.Vertex3(-4, 16, -4)
            GL.TexCoord2(TexVal * 24, TexVal * 8)
            GL.Vertex3(4, 16, -4)
            GL.TexCoord2(TexVal * 24, TexVal * 16)
            GL.Vertex3(4, 8, -4)
            GL.TexCoord2(TexVal * 32, TexVal * 16)
            GL.Vertex3(-4, 8, -4)
            'Face 3
            GL.TexCoord2(TexVal * 8, TexVal * 8)
            GL.Vertex3(-4, 16, 4)
            GL.TexCoord2(TexVal * 0, TexVal * 8)
            GL.Vertex3(-4, 16, -4)
            GL.TexCoord2(TexVal * 0, TexVal * 16)
            GL.Vertex3(-4, 8, -4)
            GL.TexCoord2(TexVal * 8, TexVal * 16)
            GL.Vertex3(-4, 8, 4)
            'Face 4
            GL.TexCoord2(TexVal * 16, TexVal * 8)
            GL.Vertex3(4, 16, 4)
            GL.TexCoord2(TexVal * 24, TexVal * 8)
            GL.Vertex3(4, 16, -4)
            GL.TexCoord2(TexVal * 24, TexVal * 16)
            GL.Vertex3(4, 8, -4)
            GL.TexCoord2(TexVal * 16, TexVal * 16)
            GL.Vertex3(4, 8, 4)
            'Face 5
            GL.TexCoord2(TexVal * 8, TexVal * 8)
            GL.Vertex3(-4, 16, 4)
            GL.TexCoord2(TexVal * 16, TexVal * 8)
            GL.Vertex3(4, 16, 4)
            GL.TexCoord2(TexVal * 16, TexVal * 0)
            GL.Vertex3(4, 16, -4)
            GL.TexCoord2(TexVal * 8, TexVal * 0)
            GL.Vertex3(-4, 16, -4)
            'Face 6
            GL.TexCoord2(TexVal * 16, TexVal * 8)
            GL.Vertex3(-4, 8, 4)
            GL.TexCoord2(TexVal * 24, TexVal * 8)
            GL.Vertex3(4, 8, 4)
            GL.TexCoord2(TexVal * 24, TexVal * 0)
            GL.Vertex3(4, 8, -4)
            GL.TexCoord2(TexVal * 16, TexVal * 0)
            GL.Vertex3(-4, 8, -4)
        End If

        If Model = Models.Steve Then

            If ShowLeftArm Then
                'LefttArm
                'Face 1
                GL.TexCoord2(TexVal * 36, TexVal * 52)
                GL.Vertex3(4, 8, 2)
                GL.TexCoord2(TexVal * 40, TexVal * 52)
                GL.Vertex3(8, 8, 2)
                GL.TexCoord2(TexVal * 40, TexVal * 64)
                GL.Vertex3(8, -4, 2)
                GL.TexCoord2(TexVal * 36, TexVal * 64)
                GL.Vertex3(4, -4, 2)
                'Face 2
                GL.TexCoord2(TexVal * 44, TexVal * 52)
                GL.Vertex3(4, 8, -2)
                GL.TexCoord2(TexVal * 48, TexVal * 52)
                GL.Vertex3(8, 8, -2)
                GL.TexCoord2(TexVal * 48, TexVal * 64)
                GL.Vertex3(8, -4, -2)
                GL.TexCoord2(TexVal * 44, TexVal * 64)
                GL.Vertex3(4, -4, -2)
                'Face 3
                GL.TexCoord2(TexVal * 32, TexVal * 52)
                GL.Vertex3(4, 8, 2)
                GL.TexCoord2(TexVal * 36, TexVal * 52)
                GL.Vertex3(4, 8, -2)
                GL.TexCoord2(TexVal * 36, TexVal * 64)
                GL.Vertex3(4, -4, -2)
                GL.TexCoord2(TexVal * 32, TexVal * 64)
                GL.Vertex3(4, -4, 2)
                'Face 4
                GL.TexCoord2(TexVal * 44, TexVal * 52)
                GL.Vertex3(8, 8, 2)
                GL.TexCoord2(TexVal * 40, TexVal * 52)
                GL.Vertex3(8, 8, -2)
                GL.TexCoord2(TexVal * 40, TexVal * 64)
                GL.Vertex3(8, -4, -2)
                GL.TexCoord2(TexVal * 44, TexVal * 64)
                GL.Vertex3(8, -4, 2)
                'Face 5
                GL.TexCoord2(TexVal * 36, TexVal * 52)
                GL.Vertex3(4, 8, 2)
                GL.TexCoord2(TexVal * 40, TexVal * 52)
                GL.Vertex3(8, 8, 2)
                GL.TexCoord2(TexVal * 40, TexVal * 48)
                GL.Vertex3(8, 8, -2)
                GL.TexCoord2(TexVal * 36, TexVal * 48)
                GL.Vertex3(4, 8, -2)
                'Face 6
                GL.TexCoord2(TexVal * 40, TexVal * 52)
                GL.Vertex3(4, -4, 2)
                GL.TexCoord2(TexVal * 44, TexVal * 52)
                GL.Vertex3(8, -4, 2)
                GL.TexCoord2(TexVal * 44, TexVal * 48)
                GL.Vertex3(8, -4, -2)
                GL.TexCoord2(TexVal * 40, TexVal * 48)
                GL.Vertex3(4, -4, -2)
            End If

            If ShowRightArm Then
                'RightArm
                'Face 1
                GL.TexCoord2(TexVal * 44, TexVal * 20)
                GL.Vertex3(-8, 8, 2)
                GL.TexCoord2(TexVal * 48, TexVal * 20)
                GL.Vertex3(-4, 8, 2)
                GL.TexCoord2(TexVal * 48, TexVal * 32)
                GL.Vertex3(-4, -4, 2)
                GL.TexCoord2(TexVal * 44, TexVal * 32)
                GL.Vertex3(-8, -4, 2)
                'Face 2
                GL.TexCoord2(TexVal * 52, TexVal * 20)
                GL.Vertex3(-8, 8, -2)
                GL.TexCoord2(TexVal * 56, TexVal * 20)
                GL.Vertex3(-4, 8, -2)
                GL.TexCoord2(TexVal * 56, TexVal * 32)
                GL.Vertex3(-4, -4, -2)
                GL.TexCoord2(TexVal * 52, TexVal * 32)
                GL.Vertex3(-8, -4, -2)
                'Face 3
                GL.TexCoord2(TexVal * 40, TexVal * 20)
                GL.Vertex3(-8, 8, 2)
                GL.TexCoord2(TexVal * 44, TexVal * 20)
                GL.Vertex3(-8, 8, -2)
                GL.TexCoord2(TexVal * 44, TexVal * 32)
                GL.Vertex3(-8, -4, -2)
                GL.TexCoord2(TexVal * 40, TexVal * 32)
                GL.Vertex3(-8, -4, 2)
                'Face 4
                GL.TexCoord2(TexVal * 52, TexVal * 20)
                GL.Vertex3(-4, 8, 2)
                GL.TexCoord2(TexVal * 48, TexVal * 20)
                GL.Vertex3(-4, 8, -2)
                GL.TexCoord2(TexVal * 48, TexVal * 32)
                GL.Vertex3(-4, -4, -2)
                GL.TexCoord2(TexVal * 52, TexVal * 32)
                GL.Vertex3(-4, -4, 2)
                'Face 5
                GL.TexCoord2(TexVal * 44, TexVal * 20)
                GL.Vertex3(-8, 8, 2)
                GL.TexCoord2(TexVal * 48, TexVal * 20)
                GL.Vertex3(-4, 8, 2)
                GL.TexCoord2(TexVal * 48, TexVal * 16)
                GL.Vertex3(-4, 8, -2)
                GL.TexCoord2(TexVal * 44, TexVal * 16)
                GL.Vertex3(-8, 8, -2)
                'Face 6
                GL.TexCoord2(TexVal * 48, TexVal * 20)
                GL.Vertex3(-8, -4, 2)
                GL.TexCoord2(TexVal * 52, TexVal * 20)
                GL.Vertex3(-4, -4, 2)
                GL.TexCoord2(TexVal * 52, TexVal * 16)
                GL.Vertex3(-4, -4, -2)
                GL.TexCoord2(TexVal * 48, TexVal * 16)
                GL.Vertex3(-8, -4, -2)
            End If

        Else

            If ShowLeftArm Then
                'LefttArm
                'Face 1
                GL.TexCoord2(TexVal * 36, TexVal * 52)
                GL.Vertex3(4, 8, 2)
                GL.TexCoord2(TexVal * 39, TexVal * 52)
                GL.Vertex3(7, 8, 2)
                GL.TexCoord2(TexVal * 39, TexVal * 64)
                GL.Vertex3(7, -4, 2)
                GL.TexCoord2(TexVal * 36, TexVal * 64)
                GL.Vertex3(4, -4, 2)
                'Face 2
                GL.TexCoord2(TexVal * 46, TexVal * 52)
                GL.Vertex3(4, 8, -2)
                GL.TexCoord2(TexVal * 43, TexVal * 52)
                GL.Vertex3(7, 8, -2)
                GL.TexCoord2(TexVal * 43, TexVal * 64)
                GL.Vertex3(7, -4, -2)
                GL.TexCoord2(TexVal * 46, TexVal * 64)
                GL.Vertex3(4, -4, -2)
                'Face 3
                GL.TexCoord2(TexVal * 32, TexVal * 52)
                GL.Vertex3(4, 8, 2)
                GL.TexCoord2(TexVal * 36, TexVal * 52)
                GL.Vertex3(4, 8, -2)
                GL.TexCoord2(TexVal * 36, TexVal * 64)
                GL.Vertex3(4, -4, -2)
                GL.TexCoord2(TexVal * 32, TexVal * 64)
                GL.Vertex3(4, -4, 2)
                'Face 4
                GL.TexCoord2(TexVal * 43, TexVal * 52)
                GL.Vertex3(7, 8, 2)
                GL.TexCoord2(TexVal * 39, TexVal * 52)
                GL.Vertex3(7, 8, -2)
                GL.TexCoord2(TexVal * 39, TexVal * 64)
                GL.Vertex3(7, -4, -2)
                GL.TexCoord2(TexVal * 43, TexVal * 64)
                GL.Vertex3(7, -4, 2)
                'Face 5
                GL.TexCoord2(TexVal * 36, TexVal * 52)
                GL.Vertex3(4, 8, 2)
                GL.TexCoord2(TexVal * 39, TexVal * 52)
                GL.Vertex3(7, 8, 2)
                GL.TexCoord2(TexVal * 39, TexVal * 48)
                GL.Vertex3(7, 8, -2)
                GL.TexCoord2(TexVal * 36, TexVal * 48)
                GL.Vertex3(4, 8, -2)
                'Face 6
                GL.TexCoord2(TexVal * 39, TexVal * 52)
                GL.Vertex3(4, -4, 2)
                GL.TexCoord2(TexVal * 42, TexVal * 52)
                GL.Vertex3(7, -4, 2)
                GL.TexCoord2(TexVal * 42, TexVal * 48)
                GL.Vertex3(7, -4, -2)
                GL.TexCoord2(TexVal * 39, TexVal * 48)
                GL.Vertex3(4, -4, -2)
            End If

            If ShowRightArm Then
                'RightArm
                'Face 1
                GL.TexCoord2(TexVal * 44, TexVal * 20)
                GL.Vertex3(-7, 8, 2)
                GL.TexCoord2(TexVal * 47, TexVal * 20)
                GL.Vertex3(-4, 8, 2)
                GL.TexCoord2(TexVal * 47, TexVal * 32)
                GL.Vertex3(-4, -4, 2)
                GL.TexCoord2(TexVal * 44, TexVal * 32)
                GL.Vertex3(-7, -4, 2)
                'Face 2
                GL.TexCoord2(TexVal * 51, TexVal * 20)
                GL.Vertex3(-7, 8, -2)
                GL.TexCoord2(TexVal * 54, TexVal * 20)
                GL.Vertex3(-4, 8, -2)
                GL.TexCoord2(TexVal * 54, TexVal * 32)
                GL.Vertex3(-4, -4, -2)
                GL.TexCoord2(TexVal * 51, TexVal * 32)
                GL.Vertex3(-7, -4, -2)
                'Face 3
                GL.TexCoord2(TexVal * 44, TexVal * 20)
                GL.Vertex3(-7, 8, 2)
                GL.TexCoord2(TexVal * 40, TexVal * 20)
                GL.Vertex3(-7, 8, -2)
                GL.TexCoord2(TexVal * 40, TexVal * 32)
                GL.Vertex3(-7, -4, -2)
                GL.TexCoord2(TexVal * 44, TexVal * 32)
                GL.Vertex3(-7, -4, 2)
                'Face 4
                GL.TexCoord2(TexVal * 51, TexVal * 20)
                GL.Vertex3(-4, 8, 2)
                GL.TexCoord2(TexVal * 47, TexVal * 20)
                GL.Vertex3(-4, 8, -2)
                GL.TexCoord2(TexVal * 47, TexVal * 32)
                GL.Vertex3(-4, -4, -2)
                GL.TexCoord2(TexVal * 51, TexVal * 32)
                GL.Vertex3(-4, -4, 2)
                'Face 5
                GL.TexCoord2(TexVal * 44, TexVal * 20)
                GL.Vertex3(-7, 8, 2)
                GL.TexCoord2(TexVal * 47, TexVal * 20)
                GL.Vertex3(-4, 8, 2)
                GL.TexCoord2(TexVal * 47, TexVal * 16)
                GL.Vertex3(-4, 8, -2)
                GL.TexCoord2(TexVal * 44, TexVal * 16)
                GL.Vertex3(-7, 8, -2)
                'Face 6
                GL.TexCoord2(TexVal * 47, TexVal * 20)
                GL.Vertex3(-7, -4, 2)
                GL.TexCoord2(TexVal * 50, TexVal * 20)
                GL.Vertex3(-4, -4, 2)
                GL.TexCoord2(TexVal * 50, TexVal * 16)
                GL.Vertex3(-4, -4, -2)
                GL.TexCoord2(TexVal * 47, TexVal * 16)
                GL.Vertex3(-7, -4, -2)
            End If

        End If

        If ShowRightLeg Then
            'RightLeg
            'Face 1
            GL.TexCoord2(TexVal * 4, TexVal * 20)
            GL.Vertex3(-4, -4, 2)
            GL.TexCoord2(TexVal * 8, TexVal * 20)
            GL.Vertex3(0, -4, 2)
            GL.TexCoord2(TexVal * 8, TexVal * 32)
            GL.Vertex3(0, -16, 2)
            GL.TexCoord2(TexVal * 4, TexVal * 32)
            GL.Vertex3(-4, -16, 2)
            'Face 2
            GL.TexCoord2(TexVal * 16, TexVal * 20)
            GL.Vertex3(-4, -4, -2)
            GL.TexCoord2(TexVal * 12, TexVal * 20)
            GL.Vertex3(0, -4, -2)
            GL.TexCoord2(TexVal * 12, TexVal * 32)
            GL.Vertex3(0, -16, -2)
            GL.TexCoord2(TexVal * 16, TexVal * 32)
            GL.Vertex3(-4, -16, -2)
            'Face 3
            GL.TexCoord2(TexVal * 4, TexVal * 20)
            GL.Vertex3(-4, -4, 2)
            GL.TexCoord2(TexVal * 0, TexVal * 20)
            GL.Vertex3(-4, -4, -2)
            GL.TexCoord2(TexVal * 0, TexVal * 32)
            GL.Vertex3(-4, -16, -2)
            GL.TexCoord2(TexVal * 4, TexVal * 32)
            GL.Vertex3(-4, -16, 2)
            'Face 4
            GL.TexCoord2(TexVal * 8, TexVal * 20)
            GL.Vertex3(0, -4, 2)
            GL.TexCoord2(TexVal * 12, TexVal * 20)
            GL.Vertex3(0, -4, -2)
            GL.TexCoord2(TexVal * 12, TexVal * 32)
            GL.Vertex3(0, -16, -2)
            GL.TexCoord2(TexVal * 8, TexVal * 32)
            GL.Vertex3(0, -16, 2)
            'Face 5
            GL.TexCoord2(TexVal * 4, TexVal * 20)
            GL.Vertex3(-4, -4, 2)
            GL.TexCoord2(TexVal * 8, TexVal * 20)
            GL.Vertex3(0, -4, 2)
            GL.TexCoord2(TexVal * 8, TexVal * 16)
            GL.Vertex3(0, -4, -2)
            GL.TexCoord2(TexVal * 4, TexVal * 16)
            GL.Vertex3(-4, -4, -2)
            'Face 6
            GL.TexCoord2(TexVal * 8, TexVal * 20)
            GL.Vertex3(-4, -16, 2)
            GL.TexCoord2(TexVal * 12, TexVal * 20)
            GL.Vertex3(0, -16, 2)
            GL.TexCoord2(TexVal * 12, TexVal * 16)
            GL.Vertex3(0, -16, -2)
            GL.TexCoord2(TexVal * 8, TexVal * 16)
            GL.Vertex3(-4, -16, -2)
        End If

        If ShowLeftLeg Then
            'LeftLeg
            'Face 1
            GL.TexCoord2(TexVal * 20, TexVal * 52)
            GL.Vertex3(0, -4, 2)
            GL.TexCoord2(TexVal * 24, TexVal * 52)
            GL.Vertex3(4, -4, 2)
            GL.TexCoord2(TexVal * 24, TexVal * 64)
            GL.Vertex3(4, -16, 2)
            GL.TexCoord2(TexVal * 20, TexVal * 64)
            GL.Vertex3(0, -16, 2)
            'Face 2
            GL.TexCoord2(TexVal * 32, TexVal * 52)
            GL.Vertex3(0, -4, -2)
            GL.TexCoord2(TexVal * 28, TexVal * 52)
            GL.Vertex3(4, -4, -2)
            GL.TexCoord2(TexVal * 28, TexVal * 64)
            GL.Vertex3(4, -16, -2)
            GL.TexCoord2(TexVal * 32, TexVal * 64)
            GL.Vertex3(0, -16, -2)
            'Face 3
            GL.TexCoord2(TexVal * 20, TexVal * 52)
            GL.Vertex3(0, -4, 2)
            GL.TexCoord2(TexVal * 16, TexVal * 52)
            GL.Vertex3(0, -4, -2)
            GL.TexCoord2(TexVal * 16, TexVal * 64)
            GL.Vertex3(0, -16, -2)
            GL.TexCoord2(TexVal * 20, TexVal * 64)
            GL.Vertex3(0, -16, 2)
            'Face 4
            GL.TexCoord2(TexVal * 24, TexVal * 52)
            GL.Vertex3(4, -4, 2)
            GL.TexCoord2(TexVal * 28, TexVal * 52)
            GL.Vertex3(4, -4, -2)
            GL.TexCoord2(TexVal * 28, TexVal * 64)
            GL.Vertex3(4, -16, -2)
            GL.TexCoord2(TexVal * 24, TexVal * 64)
            GL.Vertex3(4, -16, 2)
            'Face 5
            GL.TexCoord2(TexVal * 20, TexVal * 52)
            GL.Vertex3(0, -4, 2)
            GL.TexCoord2(TexVal * 24, TexVal * 52)
            GL.Vertex3(4, -4, 2)
            GL.TexCoord2(TexVal * 24, TexVal * 48)
            GL.Vertex3(4, -4, -2)
            GL.TexCoord2(TexVal * 20, TexVal * 48)
            GL.Vertex3(0, -4, -2)
            'Face 6
            GL.TexCoord2(TexVal * 24, TexVal * 52)
            GL.Vertex3(0, -16, 2)
            GL.TexCoord2(TexVal * 28, TexVal * 52)
            GL.Vertex3(4, -16, 2)
            GL.TexCoord2(TexVal * 28, TexVal * 48)
            GL.Vertex3(4, -16, -2)
            GL.TexCoord2(TexVal * 24, TexVal * 48)
            GL.Vertex3(0, -16, -2)
        End If

        GL.End()

        GL.Enable(EnableCap.Blend) 'Enable transparent
        GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha)

        GL.Begin(BeginMode.Quads)

        If Show2ndBody Then
            'Face 1
            GL.TexCoord2(TexVal * 20, TexVal * 36)
            GL.Vertex3(-4.24, 8.36, 2.12)
            GL.TexCoord2(TexVal * 28, TexVal * 36)
            GL.Vertex3(4.24, 8.36, 2.12)
            GL.TexCoord2(TexVal * 28, TexVal * 48)
            GL.Vertex3(4.24, -4.36, 2.12)
            GL.TexCoord2(TexVal * 20, TexVal * 48)
            GL.Vertex3(-4.24, -4.36, 2.12)
            'Face 2
            GL.TexCoord2(TexVal * 40, TexVal * 36)
            GL.Vertex3(-4.24, 8.36, -2.12)
            GL.TexCoord2(TexVal * 32, TexVal * 36)
            GL.Vertex3(4.24, 8.36, -2.12)
            GL.TexCoord2(TexVal * 32, TexVal * 48)
            GL.Vertex3(4.24, -4.36, -2.12)
            GL.TexCoord2(TexVal * 40, TexVal * 48)
            GL.Vertex3(-4.24, -4.36, -2.12)
            'Face 3
            GL.TexCoord2(TexVal * 16, TexVal * 36)
            GL.Vertex3(-4.24, 8.36, 2.12)
            GL.TexCoord2(TexVal * 20, TexVal * 36)
            GL.Vertex3(-4.24, 8.36, -2.12)
            GL.TexCoord2(TexVal * 20, TexVal * 48)
            GL.Vertex3(-4.24, -4.36, -2.12)
            GL.TexCoord2(TexVal * 16, TexVal * 48)
            GL.Vertex3(-4.24, -4.36, 2.12)
            'Face 4
            GL.TexCoord2(TexVal * 32, TexVal * 36)
            GL.Vertex3(4.24, 8.36, 2.12)
            GL.TexCoord2(TexVal * 28, TexVal * 36)
            GL.Vertex3(4.24, 8.36, -2.12)
            GL.TexCoord2(TexVal * 28, TexVal * 48)
            GL.Vertex3(4.24, -4.36, -2.12)
            GL.TexCoord2(TexVal * 32, TexVal * 48)
            GL.Vertex3(4.24, -4.36, 2.12)
            'Face 5
            GL.TexCoord2(TexVal * 20, TexVal * 36)
            GL.Vertex3(-4.24, 8.36, 2.12)
            GL.TexCoord2(TexVal * 28, TexVal * 36)
            GL.Vertex3(4.24, 8.36, 2.12)
            GL.TexCoord2(TexVal * 28, TexVal * 32)
            GL.Vertex3(4.24, 8.36, -2.12)
            GL.TexCoord2(TexVal * 20, TexVal * 32)
            GL.Vertex3(-4.24, 8.36, -2.12)
            'Face 6
            GL.TexCoord2(TexVal * 28, TexVal * 36)
            GL.Vertex3(-4.24, -4.36, 2.12)
            GL.TexCoord2(TexVal * 36, TexVal * 36)
            GL.Vertex3(4.24, -4.36, 2.12)
            GL.TexCoord2(TexVal * 36, TexVal * 32)
            GL.Vertex3(4.24, -4.36, -2.12)
            GL.TexCoord2(TexVal * 28, TexVal * 32)
            GL.Vertex3(-4.24, -4.36, -2.12)
        End If

        If Show2ndHead Then
            'Head
            'Face 1
            GL.TexCoord2(TexVal * 40, TexVal * 8)
            GL.Vertex3(-4.24, 16.24, 4.24)
            GL.TexCoord2(TexVal * 48, TexVal * 8)
            GL.Vertex3(4.24, 16.24, 4.24)
            GL.TexCoord2(TexVal * 48, TexVal * 16)
            GL.Vertex3(4.24, 7.76, 4.24)
            GL.TexCoord2(TexVal * 40, TexVal * 16)
            GL.Vertex3(-4.24, 7.76, 4.24)
            'Face 2
            GL.TexCoord2(TexVal * 64, TexVal * 8)
            GL.Vertex3(-4.24, 16.24, -4.24)
            GL.TexCoord2(TexVal * 56, TexVal * 8)
            GL.Vertex3(4.24, 16.24, -4.24)
            GL.TexCoord2(TexVal * 56, TexVal * 16)
            GL.Vertex3(4.24, 7.76, -4.24)
            GL.TexCoord2(TexVal * 64, TexVal * 16)
            GL.Vertex3(-4.24, 7.76, -4.24)
            'Face 3
            GL.TexCoord2(TexVal * 40, TexVal * 8)
            GL.Vertex3(-4.24, 16.24, 4.24)
            GL.TexCoord2(TexVal * 32, TexVal * 8)
            GL.Vertex3(-4.24, 16.24, -4.24)
            GL.TexCoord2(TexVal * 32, TexVal * 16)
            GL.Vertex3(-4.24, 7.76, -4.24)
            GL.TexCoord2(TexVal * 40, TexVal * 16)
            GL.Vertex3(-4.24, 7.76, 4.24)
            'Face 4
            GL.TexCoord2(TexVal * 48, TexVal * 8)
            GL.Vertex3(4.24, 16.24, 4.24)
            GL.TexCoord2(TexVal * 56, TexVal * 8)
            GL.Vertex3(4.24, 16.24, -4.24)
            GL.TexCoord2(TexVal * 56, TexVal * 16)
            GL.Vertex3(4.24, 7.76, -4.24)
            GL.TexCoord2(TexVal * 48, TexVal * 16)
            GL.Vertex3(4.24, 7.76, 4.24)
            'Face 5
            GL.TexCoord2(TexVal * 40, TexVal * 8)
            GL.Vertex3(-4.24, 16.24, 4.24)
            GL.TexCoord2(TexVal * 48, TexVal * 8)
            GL.Vertex3(4.24, 16.24, 4.24)
            GL.TexCoord2(TexVal * 48, 0)
            GL.Vertex3(4.24, 16.24, -4.24)
            GL.TexCoord2(TexVal * 40, 0)
            GL.Vertex3(-4.24, 16.24, -4.24)
            'Face 6
            GL.TexCoord2(TexVal * 48, TexVal * 8)
            GL.Vertex3(-4.24, 7.76, 4.24)
            GL.TexCoord2(TexVal * 56, TexVal * 8)
            GL.Vertex3(4.24, 7.76, 4.24)
            GL.TexCoord2(TexVal * 56, 0)
            GL.Vertex3(4.24, 7.76, -4.24)
            GL.TexCoord2(TexVal * 48, 0)
            GL.Vertex3(-4.24, 7.76, -4.24)
        End If

        If Model = Models.Steve Then

            If Show2ndLeftArm Then
                'LeftArm
                'Face 1
                GL.TexCoord2(TexVal * 52, TexVal * 52)
                GL.Vertex3(3.88, 8.36, 2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 52)
                GL.Vertex3(8.12, 8.36, 2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 64)
                GL.Vertex3(8.12, -4.36, 2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 64)
                GL.Vertex3(3.88, -4.36, 2.12)
                'Face 2
                GL.TexCoord2(TexVal * 64, TexVal * 52)
                GL.Vertex3(3.88, 8.36, -2.12)
                GL.TexCoord2(TexVal * 60, TexVal * 52)
                GL.Vertex3(8.12, 8.36, -2.12)
                GL.TexCoord2(TexVal * 60, TexVal * 64)
                GL.Vertex3(8.12, -4.36, -2.12)
                GL.TexCoord2(TexVal * 64, TexVal * 64)
                GL.Vertex3(3.88, -4.36, -2.12)
                'Face 3
                GL.TexCoord2(TexVal * 48, TexVal * 52)
                GL.Vertex3(3.88, 8.36, 2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 52)
                GL.Vertex3(3.88, 8.36, -2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 64)
                GL.Vertex3(3.88, -4.36, -2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 64)
                GL.Vertex3(3.88, -4.36, 2.12)
                'Face 4
                GL.TexCoord2(TexVal * 60, TexVal * 52)
                GL.Vertex3(8.12, 8.36, 2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 52)
                GL.Vertex3(8.12, 8.36, -2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 64)
                GL.Vertex3(8.12, -4.36, -2.12)
                GL.TexCoord2(TexVal * 60, TexVal * 64)
                GL.Vertex3(8.12, -4.36, 2.12)
                'Face 5
                GL.TexCoord2(TexVal * 52, TexVal * 52)
                GL.Vertex3(3.88, 8.36, 2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 52)
                GL.Vertex3(8.12, 8.36, 2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 48)
                GL.Vertex3(8.12, 8.36, -2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 48)
                GL.Vertex3(3.88, 8.36, -2.12)
                'Face 6
                GL.TexCoord2(TexVal * 56, TexVal * 52)
                GL.Vertex3(3.88, -4.36, 2.12)
                GL.TexCoord2(TexVal * 60, TexVal * 52)
                GL.Vertex3(8.12, -4.36, 2.12)
                GL.TexCoord2(TexVal * 60, TexVal * 48)
                GL.Vertex3(8.12, -4.36, -2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 48)
                GL.Vertex3(3.88, -4.36, -2.12)
            End If

            If Show2ndRightArm Then
                'RightArm
                'Face 1
                GL.TexCoord2(TexVal * 44, TexVal * 36)
                GL.Vertex3(-8.12, 8.36, 2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 36)
                GL.Vertex3(-3.88, 8.36, 2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 48)
                GL.Vertex3(-3.88, -4.36, 2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 48)
                GL.Vertex3(-8.12, -4.36, 2.12)
                'Face 2
                GL.TexCoord2(TexVal * 56, TexVal * 36)
                GL.Vertex3(-8.12, 8.36, -2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 36)
                GL.Vertex3(-3.88, 8.36, -2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 48)
                GL.Vertex3(-3.88, -4.36, -2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 48)
                GL.Vertex3(-8.12, -4.36, -2.12)
                'Face 3
                GL.TexCoord2(TexVal * 40, TexVal * 36)
                GL.Vertex3(-8.12, 8.36, 2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 36)
                GL.Vertex3(-8.12, 8.36, -2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 48)
                GL.Vertex3(-8.12, -4.36, -2.12)
                GL.TexCoord2(TexVal * 40, TexVal * 48)
                GL.Vertex3(-8.12, -4.36, 2.12)
                'Face 4
                GL.TexCoord2(TexVal * 52, TexVal * 36)
                GL.Vertex3(-3.88, 8.36, 2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 36)
                GL.Vertex3(-3.88, 8.36, -2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 48)
                GL.Vertex3(-3.88, -4.36, -2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 48)
                GL.Vertex3(-3.88, -4.36, 2.12)
                'Face 5
                GL.TexCoord2(TexVal * 44, TexVal * 36)
                GL.Vertex3(-8.12, 8.36, 2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 36)
                GL.Vertex3(-3.88, 8.36, 2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 32)
                GL.Vertex3(-3.88, 8.36, -2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 32)
                GL.Vertex3(-8.12, 8.36, -2.12)
                'Face 6
                GL.TexCoord2(TexVal * 48, TexVal * 36)
                GL.Vertex3(-8.12, -4.36, 2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 36)
                GL.Vertex3(-3.88, -4.36, 2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 32)
                GL.Vertex3(-3.88, -4.36, -2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 32)
                GL.Vertex3(-8.12, -4.36, -2.12)
            End If

        Else

            If Show2ndLeftArm Then
                'LefttArm
                'Face 1
                GL.TexCoord2(TexVal * 52, TexVal * 52)
                GL.Vertex3(3.91, 8.36, 2.12)
                GL.TexCoord2(TexVal * 55, TexVal * 52)
                GL.Vertex3(7.09, 8.36, 2.12)
                GL.TexCoord2(TexVal * 55, TexVal * 64)
                GL.Vertex3(7.09, -4.36, 2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 64)
                GL.Vertex3(3.91, -4.36, 2.12)
                'Face 2
                GL.TexCoord2(TexVal * 62, TexVal * 52)
                GL.Vertex3(3.91, 8.36, -2.12)
                GL.TexCoord2(TexVal * 59, TexVal * 52)
                GL.Vertex3(7.09, 8.36, -2.12)
                GL.TexCoord2(TexVal * 59, TexVal * 64)
                GL.Vertex3(7.09, -4.36, -2.12)
                GL.TexCoord2(TexVal * 62, TexVal * 64)
                GL.Vertex3(3.91, -4.36, -2.12)
                'Face 3
                GL.TexCoord2(TexVal * 48, TexVal * 52)
                GL.Vertex3(3.91, 8.36, 2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 52)
                GL.Vertex3(3.91, 8.36, -2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 64)
                GL.Vertex3(3.91, -4.36, -2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 64)
                GL.Vertex3(3.91, -4.36, 2.12)
                'Face 4
                GL.TexCoord2(TexVal * 59, TexVal * 52)
                GL.Vertex3(7.09, 8.36, 2.12)
                GL.TexCoord2(TexVal * 55, TexVal * 52)
                GL.Vertex3(7.09, 8.36, -2.12)
                GL.TexCoord2(TexVal * 55, TexVal * 64)
                GL.Vertex3(7.09, -4.36, -2.12)
                GL.TexCoord2(TexVal * 59, TexVal * 64)
                GL.Vertex3(7.09, -4.36, 2.12)
                'Face 5
                GL.TexCoord2(TexVal * 52, TexVal * 52)
                GL.Vertex3(3.91, 8.36, 2.12)
                GL.TexCoord2(TexVal * 55, TexVal * 52)
                GL.Vertex3(7.09, 8.36, 2.12)
                GL.TexCoord2(TexVal * 55, TexVal * 48)
                GL.Vertex3(7.09, 8.36, -2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 48)
                GL.Vertex3(3.91, 8.36, -2.12)
                'Face 6
                GL.TexCoord2(TexVal * 55, TexVal * 52)
                GL.Vertex3(3.91, -4.36, 2.12)
                GL.TexCoord2(TexVal * 58, TexVal * 52)
                GL.Vertex3(7.09, -4.36, 2.12)
                GL.TexCoord2(TexVal * 58, TexVal * 48)
                GL.Vertex3(7.09, -4.36, -2.12)
                GL.TexCoord2(TexVal * 55, TexVal * 48)
                GL.Vertex3(3.91, -4.36, -2.12)
            End If

            If Show2ndRightArm Then
                'RightArm
                'Face 1
                GL.TexCoord2(TexVal * 44, TexVal * 36)
                GL.Vertex3(-7.09, 8.36, 2.12)
                GL.TexCoord2(TexVal * 47, TexVal * 36)
                GL.Vertex3(-3.91, 8.36, 2.12)
                GL.TexCoord2(TexVal * 47, TexVal * 48)
                GL.Vertex3(-3.91, -4.36, 2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 48)
                GL.Vertex3(-7.09, -4.36, 2.12)
                'Face 2
                GL.TexCoord2(TexVal * 54, TexVal * 36)
                GL.Vertex3(-7.09, 8.36, -2.12)
                GL.TexCoord2(TexVal * 51, TexVal * 36)
                GL.Vertex3(-3.91, 8.36, -2.12)
                GL.TexCoord2(TexVal * 51, TexVal * 48)
                GL.Vertex3(-3.91, -4.36, -2.12)
                GL.TexCoord2(TexVal * 54, TexVal * 48)
                GL.Vertex3(-7.09, -4.36, -2.12)
                'Face 3
                GL.TexCoord2(TexVal * 40, TexVal * 36)
                GL.Vertex3(-7.09, 8.36, 2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 36)
                GL.Vertex3(-7.09, 8.36, -2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 48)
                GL.Vertex3(-7.09, -4.36, -2.12)
                GL.TexCoord2(TexVal * 40, TexVal * 48)
                GL.Vertex3(-7.09, -4.36, 2.12)
                'Face 4
                GL.TexCoord2(TexVal * 51, TexVal * 36)
                GL.Vertex3(-3.91, 8.36, 2.12)
                GL.TexCoord2(TexVal * 47, TexVal * 36)
                GL.Vertex3(-3.91, 8.36, -2.12)
                GL.TexCoord2(TexVal * 47, TexVal * 48)
                GL.Vertex3(-3.91, -4.36, -2.12)
                GL.TexCoord2(TexVal * 51, TexVal * 48)
                GL.Vertex3(-3.91, -4.36, 2.12)
                'Face 5
                GL.TexCoord2(TexVal * 44, TexVal * 36)
                GL.Vertex3(-7.09, 8.36, 2.12)
                GL.TexCoord2(TexVal * 47, TexVal * 36)
                GL.Vertex3(-3.91, 8.36, 2.12)
                GL.TexCoord2(TexVal * 47, TexVal * 32)
                GL.Vertex3(-3.91, 8.36, -2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 32)
                GL.Vertex3(-7.09, 8.36, -2.12)
                'Face 6
                GL.TexCoord2(TexVal * 47, TexVal * 36)
                GL.Vertex3(-7.09, -4.36, 2.12)
                GL.TexCoord2(TexVal * 50, TexVal * 36)
                GL.Vertex3(-3.91, -4.36, 2.12)
                GL.TexCoord2(TexVal * 50, TexVal * 32)
                GL.Vertex3(-3.91, -4.36, -2.12)
                GL.TexCoord2(TexVal * 47, TexVal * 32)
                GL.Vertex3(-7.09, -4.36, -2.12)
            End If

        End If

        If Show2ndRightLeg Then
            'RightLeg
            'Face 1
            GL.TexCoord2(TexVal * 4, TexVal * 36)
            GL.Vertex3(-4.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 36)
            GL.Vertex3(0.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 48)
            GL.Vertex3(0.12, -16.36, 2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 48)
            GL.Vertex3(-4.12, -16.36, 2.12)
            'Face 2
            GL.TexCoord2(TexVal * 16, TexVal * 36)
            GL.Vertex3(-4.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 36)
            GL.Vertex3(0.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 48)
            GL.Vertex3(0.12, -16.36, -2.12)
            GL.TexCoord2(TexVal * 16, TexVal * 48)
            GL.Vertex3(-4.12, -16.36, -2.12)
            'Face 3
            GL.TexCoord2(TexVal * 0, TexVal * 36)
            GL.Vertex3(-4.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 36)
            GL.Vertex3(-4.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 48)
            GL.Vertex3(-4.12, -16.36, -2.12)
            GL.TexCoord2(TexVal * 0, TexVal * 48)
            GL.Vertex3(-4.12, -16.36, 2.12)
            'Face 4
            GL.TexCoord2(TexVal * 12, TexVal * 36)
            GL.Vertex3(0.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 36)
            GL.Vertex3(0.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 48)
            GL.Vertex3(0.12, -16.36, -2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 48)
            GL.Vertex3(0.12, -16.36, 2.12)
            'Face 5
            GL.TexCoord2(TexVal * 4, TexVal * 36)
            GL.Vertex3(-4.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 36)
            GL.Vertex3(0.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 32)
            GL.Vertex3(0.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 32)
            GL.Vertex3(-4.12, -3.64, -2.12)
            'Face 6
            GL.TexCoord2(TexVal * 8, TexVal * 36)
            GL.Vertex3(-4.12, -16.36, 2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 36)
            GL.Vertex3(0.12, -16.36, 2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 32)
            GL.Vertex3(0.12, -16.36, -2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 32)
            GL.Vertex3(-4.12, -16.36, -2.12)
        End If

        If Show2ndLeftLeg Then
            'LeftLeg
            'Face 1
            GL.TexCoord2(TexVal * 4, TexVal * 52)
            GL.Vertex3(-0.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 52)
            GL.Vertex3(4.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 64)
            GL.Vertex3(4.12, -16.36, 2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 64)
            GL.Vertex3(-0.12, -16.36, 2.12)
            'Face 2
            GL.TexCoord2(TexVal * 16, TexVal * 52)
            GL.Vertex3(-0.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 52)
            GL.Vertex3(4.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 64)
            GL.Vertex3(4.12, -16.36, -2.12)
            GL.TexCoord2(TexVal * 16, TexVal * 64)
            GL.Vertex3(-0.12, -16.36, -2.12)
            'Face 3
            GL.TexCoord2(TexVal * 0, TexVal * 52)
            GL.Vertex3(-0.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 52)
            GL.Vertex3(-0.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 64)
            GL.Vertex3(-0.12, -16.36, -2.12)
            GL.TexCoord2(TexVal * 0, TexVal * 64)
            GL.Vertex3(-0.12, -16.36, 2.12)
            'Face 4
            GL.TexCoord2(TexVal * 12, TexVal * 52)
            GL.Vertex3(4.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 52)
            GL.Vertex3(4.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 64)
            GL.Vertex3(4.12, -16.36, -2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 64)
            GL.Vertex3(4.12, -16.36, 2.12)
            'Face 5
            GL.TexCoord2(TexVal * 4, TexVal * 52)
            GL.Vertex3(-0.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 52)
            GL.Vertex3(4.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 48)
            GL.Vertex3(4.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 48)
            GL.Vertex3(-0.12, -3.64, -2.12)
            'Face 6
            GL.TexCoord2(TexVal * 8, TexVal * 52)
            GL.Vertex3(-0.12, -16.36, 2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 52)
            GL.Vertex3(4.12, -16.36, 2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 48)
            GL.Vertex3(4.12, -16.36, -2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 48)
            GL.Vertex3(-0.12, -16.36, -2.12)
        End If
        'Finish the begin mode with "end"
        GL.End()

        'Finally...
        GlControl.SwapBuffers() 'Takes from the 'GL' and puts into control
    End Sub

    Private IsMouseDown As Boolean
    Private IsRightMouseDown As Boolean
    Private IsMouseHidden As Boolean
    Private OldLoc As Point
    Private MouseLoc As Point

    Private Sub GlControl_MouseDown(sender As Object, e As MouseEventArgs) Handles GlControl.MouseDown
        If Not IsMouseDown AndAlso e.Button = MouseButtons.Left Then
            OldLoc = Cursor.Position
            If Not IsMouseHidden Then
                Cursor.Hide()
                IsMouseHidden = True
            End If
            MouseLoc = Cursor.Position
            IsMouseDown = True
        ElseIf Not IsRightMouseDown AndAlso e.Button = MouseButtons.Right Then
            OldLoc = Cursor.Position
            If Not IsMouseHidden Then
                Cursor.Hide()
                IsMouseHidden = True
            End If
            MouseLoc = Cursor.Position
            IsRightMouseDown = True
        End If
    End Sub

    Private Sub GlControl_MouseUp(sender As Object, e As MouseEventArgs) Handles GlControl.MouseUp
        If IsMouseHidden Then
            Cursor.Show()
            IsMouseHidden = False
            Cursor.Position = OldLoc
            IsMouseDown = False
            IsRightMouseDown = False
        End If
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        If IsMouseDown Then
            RotationY += (Cursor.Position.X - MouseLoc.X) * 0.5
            RotationX -= (Cursor.Position.Y - MouseLoc.Y) * 0.5
            Me.Refresh()
            Cursor.Position = New Point(My.Computer.Screen.Bounds.Width / 2, My.Computer.Screen.Bounds.Height / 2)
            MouseLoc = Cursor.Position
        ElseIf IsRightMouseDown Then
            LookX += (Cursor.Position.X - MouseLoc.X) * 0.5
            LookY += (Cursor.Position.Y - MouseLoc.Y) * 0.5
            Me.Refresh()
            Cursor.Position = New Point(My.Computer.Screen.Bounds.Width / 2, My.Computer.Screen.Bounds.Height / 2)
            MouseLoc = Cursor.Position
        End If
    End Sub

    Private Sub Renderer3D_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        Zoom += e.Delta * 0.005
        Refresh()
    End Sub
End Class
