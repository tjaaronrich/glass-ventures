Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Optimization
Imports System.Web.UI
Imports BundleTransformer.Core
Imports BundleTransformer.Core.Builders
Imports BundleTransformer.Core.Bundles
Imports BundleTransformer.Core.Orderers
Imports BundleTransformer.Core.Resolvers
Imports BundleTransformer.Core.Transformers

Public Module BundleConfig
    ' For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
    Public Sub RegisterBundles(bundles As BundleCollection)
		
		
		Dim commonStylesBundle = New CustomStyleBundle("~/Bundles/CommonStyles")
		commonStylesBundle.Include("~/scss/theme/theme.scss")
		bundles.Add(commonStylesBundle)
		
		
		
		
		Dim materialStylesBundle = New CustomStyleBundle("~/Bundles/MaterialStyles")
		materialStylesBundle.Include("~/scss/materialize/materialize.scss")
        bundles.Add(materialStylesBundle)
		
		
		
		
		
		
        bundles.Add(New ScriptBundle("~/bundles/WebFormsJs").Include(
            "~/Scripts/WebForms/WebForms.js",
            "~/Scripts/WebForms/WebUIValidation.js",
            "~/Scripts/WebForms/MenuStandards.js",
            "~/Scripts/WebForms/Focus.js", "~/Scripts/WebForms/GridView.js", 
            "~/Scripts/WebForms/DetailsView.js",
            "~/Scripts/WebForms/TreeView.js",
            "~/Scripts/WebForms/WebParts.js"))

        ' Order is very important for these files to work, they have explicit dependencies
        bundles.Add(New ScriptBundle("~/bundles/MsAjaxJs").Include(
            "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
            "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
            "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
            "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"))

        ' Use the Development version of Modernizr to develop with and learn from. Then, when you’re
        ' ready for production, use the build tool at https://modernizr.com to pick only the tests you need
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
            "~/Scripts/modernizr-*"))

        ScriptManager.ScriptResourceMapping.AddDefinition("respond", New ScriptResourceDefinition() With {
            .Path = "~/Scripts/respond.min.js",
            .DebugPath = "~/Scripts/respond.js"})
		
		
		Dim commonScriptsBundle = New CustomScriptBundle("~/Bundles/CommonScripts")

        commonScriptsBundle.Include("~/Assets/Scripts/*.js", "~/Assets/Scripts/*.coffee", "~/Assets/Scripts/TestTypeScript.ts")

        'commonScriptsBundle.Orderer = NullOrderer

        bundles.Add(commonScriptsBundle)





    End Sub
End Module
