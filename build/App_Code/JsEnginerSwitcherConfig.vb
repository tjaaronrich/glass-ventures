
Imports JavaScriptEngineSwitcher.Core
Imports JavaScriptEngineSwitcher.Msie



Public Class JsEngineSwitcherConfig

    Public Shared Sub Configure(ByVal engineSwitcher As JsEngineSwitcher)

        engineSwitcher.EngineFactories.AddMsie(New MsieSettings With {
                .UseEcmaScript5Polyfill = True,
                .UseJson2Library = True
            })

        engineSwitcher.DefaultEngineName = MsieJsEngine.EngineName

    End Sub
End Class
