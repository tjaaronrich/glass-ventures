Imports System
Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports KendoCRUDService.Models

Namespace KendoCRUDService.Controllers
    Public Class FileBrowserController
        Inherits Controller

        Private Const contentFolderRoot As String = "~/Content/"
        Private Const prettyName As String = "Images/"
        Private Shared ReadOnly foldersToCopy As String() = {"~/Content/editor/"}
	Private Const DefaultFilter As String = "*.pdf,*.txt,*.doc,*.docx,*.xls,*.xlsx,*.ppt,*.pptx,*.zip,*.rar,*.jpg,*.jpeg,*.gif,*.png"
        Private ReadOnly directoryBrowser As DirectoryBrowser
        Private ReadOnly contentInitializer As ContentInitializer

        Public Sub New()
            directoryBrowser = New DirectoryBrowser()
            contentInitializer = New ContentInitializer(contentFolderRoot, foldersToCopy, prettyName)
        End Sub

        Public ReadOnly Property ContentPath As String
            Get
				Return contentInitializer.CreateUserFolder(Server, "DefaultUser")
            End Get
        End Property

        Private Function ToAbsolute(ByVal virtualPath As String) As String
            Return VirtualPathUtility.ToAbsolute(virtualPath)
        End Function

        Private Function CombinePaths(ByVal basePath As String, ByVal relativePath As String) As String
            Return VirtualPathUtility.Combine(VirtualPathUtility.AppendTrailingSlash(basePath), relativePath)
        End Function

        Public Overridable Function AuthorizeRead(ByVal path As String) As Boolean
            Return CanAccess(path)
        End Function

        Protected Overridable Function CanAccess(ByVal path As String) As Boolean
            Return path.StartsWith(ToAbsolute(ContentPath), StringComparison.OrdinalIgnoreCase)
        End Function

        Private Function NormalizePath(ByVal path As String) As String
            If String.IsNullOrEmpty(path) Then
                Return ToAbsolute(ContentPath)
            End If

            Return CombinePaths(ToAbsolute(ContentPath), path)
        End Function

        Public Overridable Function Read(ByVal path As String) As JsonResult
            path = NormalizePath(path)

            If AuthorizeRead(path) Then

                Try
                    directoryBrowser.Server = Server
                    Dim result = directoryBrowser.GetContent(path, DefaultFilter).[Select](Function(f) New With {Key _
							.name = f.Name, Key _
							.type = If(f.Type = EntryType.File, "f", "d"), Key _
                        .size = f.Size
                    })
                    Return Json(result, JsonRequestBehavior.AllowGet)
                Catch __unusedDirectoryNotFoundException1__ As DirectoryNotFoundException
                    Throw New HttpException(404, "File Not Found")
                End Try
            End If

            Throw New HttpException(403, "Forbidden")
        End Function

        <AcceptVerbs(HttpVerbs.Post)>
        Public Overridable Function Destroy(ByVal path As String, ByVal name As String, ByVal type As String) As ActionResult
            path = NormalizePath(path)

            If Not String.IsNullOrEmpty(name) AndAlso Not String.IsNullOrEmpty(type) Then
                path = CombinePaths(path, name)

                If type.ToLowerInvariant() = "f" Then
                    DeleteFile(path)
                Else
                    DeleteDirectory(path)
                End If

                Return Json(New Object(-1) {})
            End If

            Throw New HttpException(404, "File Not Found")
        End Function

        Public Overridable Function AuthorizeDeleteFile(ByVal path As String) As Boolean
            Return CanAccess(path)
        End Function

        Public Overridable Function AuthorizeDeleteDirectory(ByVal path As String) As Boolean
            Return CanAccess(path)
        End Function

        Protected Overridable Sub DeleteFile(ByVal path As String)
            If Not AuthorizeDeleteFile(path) Then
                Throw New HttpException(403, "Forbidden")
            End If

            Dim physicalPath = Server.MapPath(path)

            If System.IO.File.Exists(physicalPath) Then
                System.IO.File.Delete(physicalPath)
            End If
        End Sub

        Protected Overridable Sub DeleteDirectory(ByVal path As String)
            If Not AuthorizeDeleteDirectory(path) Then
                Throw New HttpException(403, "Forbidden")
            End If

            Dim physicalPath = Server.MapPath(path)

            If Directory.Exists(physicalPath) Then
                Directory.Delete(physicalPath, True)
            End If
        End Sub

        Public Overridable Function AuthorizeCreateDirectory(ByVal path As String, ByVal name As String) As Boolean
            Return CanAccess(path)
        End Function

        <AcceptVerbs(HttpVerbs.Post)>
        Public Overridable Function Create(ByVal path As String, ByVal entry As FileBrowserEntry) As ActionResult
            path = NormalizePath(path)
            Dim name = entry.Name

            If Not String.IsNullOrEmpty(name) AndAlso AuthorizeCreateDirectory(path, name) Then
					Dim physicalPath = System.IO.Path.Combine(Server.MapPath(path), name)

                If Not Directory.Exists(physicalPath) Then
                    Directory.CreateDirectory(physicalPath)
                End If

					Return Json(New With {Key _
					.name = entry.Name, Key _
					.type = "d", Key _
                    .size = entry.Size
                })
            End If

            Throw New HttpException(403, "Forbidden")
        End Function

        Public Overridable Function AuthorizeUpload(ByVal path As String, ByVal file As HttpPostedFileBase) As Boolean
            Return CanAccess(path) AndAlso IsValidFile(file.FileName)
        End Function

        Private Function IsValidFile(ByVal fileName As String) As Boolean
            Dim extension = Path.GetExtension(fileName)
            Dim allowedExtensions = DefaultFilter.Split(","c)
            Return allowedExtensions.Any(Function(e) e.EndsWith(extension, StringComparison.InvariantCultureIgnoreCase))
        End Function

        <AcceptVerbs(HttpVerbs.Post)>
        Public Overridable Function Upload(ByVal path As String, ByVal file As HttpPostedFileBase) As ActionResult
            path = NormalizePath(path)
					Dim fileName = System.IO.Path.GetFileName(file.FileName)

            If AuthorizeUpload(path, file) Then
                file.SaveAs(System.IO.Path.Combine(Server.MapPath(path), fileName))
				Return Json(New With {Key _
					.size = file.ContentLength, Key _
					.name = fileName, Key _
                    .type = "f"
                }, "text/plain")
			Else
					Return Json(New With {Key _
					.size = "", Key _
					.name = path & " " & fileName, Key _
                    .type = "f"
                }, "text/plain")	
						
            End If

            Throw New HttpException(403, "Forbidden")
        End Function

        <OutputCache(Duration:=360, VaryByParam:="path")>
		Public Function DFile(ByVal fileName As String) As ActionResult
            Dim path = NormalizePath(fileName)

            If AuthorizeFile(path) Then
                Dim physicalPath = Server.MapPath(path)

                If System.IO.File.Exists(physicalPath) Then
                    Const contentType As String = "application/octet-stream"
                    Return File(System.IO.File.OpenRead(physicalPath), contentType, fileName)
                End If
            End If

            Throw New HttpException(403, "Forbidden")
        End Function

        Public Overridable Function AuthorizeFile(ByVal path As String) As Boolean
					Return CanAccess(path) AndAlso IsValidFile(System.IO.Path.GetExtension(path))
        End Function
    End Class
End Namespace
