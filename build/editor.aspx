<%@ Page Language="VB" debug="true" AutoEventWireup="false" CodeFile="VB/editor.aspx.vb" Inherits="editorPage" validaterequest="false"  %>
   <html><head>
    <meta charset="utf-8">
    <title>Example</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">    
    <link href="/plugins/builder/assets/minimalist-basic/content.css" rel="stylesheet" type="text/css">
    <link href="/plugins/builder/contentbuilder/contentbuilder.css" rel="stylesheet" type="text/css">
    <link href="/framework/bootstrap/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    
    <style>
        .is-container {  margin: 90px auto; max-width: 1050px; width:100%; padding:0 35px; box-sizing:border-box; }
        @media all and (max-width: 1080px) {
            .is-container { margin:0; }
        }
    </style></head>
<body>

<div id="contentarea" class="is-container container connectSortable ui-sortable ui-droppable" style="zoom: 1; min-height: 50px;">

    <!-- This is just a sample existing content (content can be loaded from a database) 
    <div class="ui-draggable"><div class="row clearfix">
        <div class="column full" contenteditable="true">
            <div class="center">
			    <i class="icon ion-leaf size-48"></i>
			    <h1 style="font-size: 1.3em">BEAUTIFUL CONTENT</h1>
                <div class="display">
                    <h1>LOREM IPSUM IS SIMPLY DUMMY TEXT</h1>
                </div>
            </div>
        </div>
    </div><div class="row-tool" style="right: auto; left: -37px;"><div class="row-handle ui-sortable-handle"><i class="cb-icon-move"></i></div><div class="row-html"><i class="cb-icon-code"></i></div><div class="row-copy"><i class="cb-icon-plus"></i></div><div class="row-remove"><i class="cb-icon-cancel"></i></div></div></div>
    <div class="ui-draggable"><div class="row clearfix">
        <div class="column full" contenteditable="true">
            <hr>
        </div>
    </div><div class="row-tool" style="right: auto; left: -37px;"><div class="row-handle ui-sortable-handle"><i class="cb-icon-move"></i></div><div class="row-html"><i class="cb-icon-code"></i></div><div class="row-copy"><i class="cb-icon-plus"></i></div><div class="row-remove"><i class="cb-icon-cancel"></i></div></div></div>
    <div class="ui-draggable ui-dragbox-outlined"><div class="row clearfix">
        <div class="column half" contenteditable="true">
            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus leo ante, consectetur sit amet vulputate vel, dapibus sit amet lectus.</p>
       	</div>
        <div class="column half" contenteditable="true">
            <img src="http://innovastudio.com/builderdemo/assets/minimalist-basic/e09-1.jpg" alt="">
       	</div>
    </div><div class="row-tool" style="right: auto; left: -37px; display: block;"><div class="row-handle ui-sortable-handle"><i class="cb-icon-move"></i></div><div class="row-html"><i class="cb-icon-code"></i></div><div class="row-copy"><i class="cb-icon-plus"></i></div><div class="row-remove"><i class="cb-icon-cancel"></i></div></div></div>-->
<%= Content %>
</div>

<script src="http://innovastudio.com/builderdemo/contentbuilder/jquery.min.js" type="text/javascript"></script>
<script src="http://innovastudio.com/builderdemo/contentbuilder/jquery-ui.min.js" type="text/javascript"></script>
<script src="/plugins/builder/contentbuilder/contentbuilder.js" type="text/javascript"></script>
<script src="http://innovastudio.com/builderdemo/contentbuilder/load-image.all.min.js"></script>

<script type="text/javascript">
    jQuery(document).ready(function ($) {

        $("#contentarea").contentbuilder({
            snippetFile: '/plugins/builder/assets/minimalist-basic/snippets.html',
            snippetOpen: true,
            toolbar: 'left',
            iconselect: '/plugins/builder/assets/ionicons/selecticon.html'
        });

    });

    function view() {
        /* This is how to get the HTML (for saving into a database) */
        var sHTML = $('#contentarea').data('contentbuilder').viewHtml();
    }
</script>


	</body>
</html>

