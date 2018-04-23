Imports Microsoft.VisualBasic
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Utils

Namespace DXSample
	Public Class MyTextEdit
		Inherits TextEdit
		Shared Sub New()
			RepositoryItemMyTextEdit.RegisterMyTextEdit()
		End Sub

		Public Sub New()
			MyBase.New()
		End Sub

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemMyTextEdit.MyTextEditName
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemMyTextEdit
			Get
				Return CType(MyBase.Properties, RepositoryItemMyTextEdit)
			End Get
		End Property
	End Class

	<UserRepositoryItem("RegisterMyTextEdit")> _
	Public Class RepositoryItemMyTextEdit
		Inherits RepositoryItemTextEdit
		Shared Sub New()
			RegisterMyTextEdit()
		End Sub

		Public Sub New()
			MyBase.New()
		End Sub

		Friend Shared MyTextEditName As String = "MyTextEdit"

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return MyTextEditName
			End Get
		End Property

		Private incrementalBackColor_Renamed As Color
		Public Property IncrementalBackColor() As Color
			Get
				Return incrementalBackColor_Renamed
			End Get
			Set(ByVal value As Color)
				incrementalBackColor_Renamed = value
			End Set
		End Property

		Private incrementalForeColor_Renamed As Color
		Public Property IncrementalForeColor() As Color
			Get
				Return incrementalForeColor_Renamed
			End Get
			Set(ByVal value As Color)
				incrementalForeColor_Renamed = value
			End Set
		End Property

		Public Shared Sub RegisterMyTextEdit()
			EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(MyTextEditName, GetType(MyTextEdit), GetType(RepositoryItemMyTextEdit), GetType(MyTextEditViewInfo), New TextEditPainter(), True))
		End Sub

		Public Overrides Sub Assign(ByVal item As RepositoryItem)
			BeginUpdate()
			Try
				MyBase.Assign(item)
				Dim source As RepositoryItemMyTextEdit = TryCast(item, RepositoryItemMyTextEdit)
				If source Is Nothing Then
					Return
				End If
				IncrementalBackColor = source.IncrementalBackColor
				IncrementalForeColor = source.IncrementalForeColor
			Finally
				EndUpdate()
			End Try
		End Sub
	End Class

	Public Class MyTextEditViewInfo
		Inherits TextEditViewInfo
		Public Sub New(ByVal item As RepositoryItem)
			MyBase.New(item)
		End Sub

		Public Overrides Function GetSystemColor(ByVal color As Color) As Color
			If color = SystemColors.HighlightText Then
				Return (CType(Owner, RepositoryItemMyTextEdit)).IncrementalForeColor
			ElseIf color = SystemColors.Highlight Then
				Return (CType(Owner, RepositoryItemMyTextEdit)).IncrementalBackColor
			Else
				Return MyBase.GetSystemColor(color)
			End If
		End Function
	End Class
End Namespace