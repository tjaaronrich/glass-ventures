﻿eval((function(a){var c=[];for(var b=1;b<128;b++)c[b]=String.fromCharCode(b);var d=[11,12,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31];var e=[];for(var b=0;b<d.length;b++)e[d[b]]=b+1;var f=a.split('\x01');for(var g=f.length-1;g>=0;g--){var h=null;var i=f[g];var j=null;var k=0;var l=i.length;var m;for(var n=0;n<l;n++){var o=i.charCodeAt(n);if(o>31)continue;var p=e[o];if(p){p=p-1;h=p*113+i.charCodeAt(n+1)-14;m=n;n++;}else if(o==6){h=113*d.length+(i.charCodeAt(n+1)-14)*113+i.charCodeAt(n+2)-14;m=n;n+=2;}else{continue;}if(j==null)j=[];if(m>k)j.push(i.substring(k,m));j.push(f[h+1]);k=n+1;}if(j!=null){if(k<l)j.push(i.substring(k));f[g]=j.join('');}}a=f[0].split('\x08').join('\'').split('\x07').join('\\');var x='0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ';var y=[1,2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31];for(var b=0;b<y.length;b++)a=a.split('\x7F'+x.charAt(b)).join(c[y[b]]);return a.split('\x7F!').join('\x7F');})('var OxOc300=["Tool_{Picker_Opacity","OpacityN{Picker_VaoValue:7uP u7FromURL","From URL7File","Local FileTWWidthNHehHeight:7FillSFillt:7URL","UrlNs_Mode","ModFs_Pk","PkNSave_FileNamene namFSave_FileTypene typFSave_Overwrite","OverwritFCrop_rXR-XNCrop_rYR-YNDraw_ModeTDraw_Pq","Use PqNDraw_Composite","Composite OperationNRect_Radius","RoundedTFill_{Type"," Type:St:g Size:Diameter","DiameterFont","FontgSizeBold","BoldS{NewVAdd text on newmTl_Degree","DegreFZoom_ModeXModFPolygon_Sides","Sides:?r_Points","Points:?r_Ratio","Radius ratioNFrame_Head","FramesTFrame_Expand","Expand sizeTWater_Head","WatermarkTConstrained_gConstrained size?mp_Hardness","Hardness:?mp_Alpha?mp_Alignment","AlignmentEl_CW","CWEl_ACW","CCWE{_Transparent","TransparentE{_BackSBacktE{_ForeSForetEBool_True","Tru@Bool_False","Fals@[_Linear","LinearE[_Radial","RadialEMode_FillnlEMode_Stroktrok@Mode_FillStrokenl and strok@Erase_Rect","RectEErase_Arc","ArcImagcaleu","Extendv","vTL","Top-LefTC","Top-vTR","Top-RighML","Middle-LefMR","Middle-RighBL","Bottom-LefBC","Bottom-vBR","Bottom-RhStatus_gDocument Size :","Status_ZoomX:MLoadFile","Load filDNewVNew aMoveUp","Movem upMMerMerge visiblemJpVpiedFx","Layer stylDBackSBackw, line or fillForeSForew or strokeExchanExchangDLineWLine width settingMUsePq","Image editor will useied pq to drawIolorPickerVaoRgb, rgba and predefinedPreview","PreviewIlose","ClosDNewP a new document>size","s canvas orx size>size_Pk","Image pk in canvaJSavave filDSelectO a region , SHIFT for plus , ALT for excludDArrowO or move aCrop","CropIut","CutIopy","Copy ofPaste","PastD[","Linear, radial gradient>ctUrecGArcUarc or ellipsDPQDraw polygonMStarUstarMPenUlineJLineUa linDFillnlErase","ErasDTextUtexG{picker","{ pickerMl","RotatDl90Rhl 90 degree righGl90Left","l 90 degree lefGFlipH","Flip horizontalMFlipV","Flip verticalMZoom","ZoomMZoomInXinMZoomOutXouGUndo","Undo>do","RedoMy","yJLoaded","Loaded>deye","Remove red eyDStamp","Clone stampMPreStamp","Press ALT x26 mouse left click to get stamp, then click to painGPreText","Press and move mouse left button to draw textareaCAllVys allmsBgb","r/g/b/aCBlur","blurCCj","cjCHsl","hue/s/lCInvert","invertCFog","fogCNeon","neonBelief}liefCMosaic","mosaicCGrayscale","gray scaleCTwovaotwo valueCUnsharp","unsharp maskCPencil","pencilBadius","Radius<Hue","Hue<Saturation","S<Lightness","L<BrhBright<Cj2","Cj<Sunshine","sun shineBed","R<Green","G<BoB<Alpha","A:2Aqua","Aqua2Vivid","Vivid2ColdboCold blue2Fresh","Fresh2Concordezcorde2Elegant","Elegant2Indiglow","Indiglow2Old","Old2Singinge2Softfocus","Soft focusfOk","okfApply","ApplyfCancel","CancelfSavavefActualgActual sizefMoreFonts","more fontsLLayerList","Layer LisHHistoryList","History LisHNew","newBackw","backwL[","gradientAct}cHArc","arcLLine","linKVarnish","varnishLErase","erasKText","texHl","rotatKFlip","flipLMermergesImage}sizexAsizeu}size canvasLCrop","cropMove","moveCut","cuHCopy","copyLPaste","pasteAmove}moveRemoveArea}move areaLPQpolygonLStar","starLFrame","add borderLWater","watermarkLy","effectsAdeye}move red eyKFreeTransform","free transformLStamp","clone stamp6HeaderTitltyleShadow","ShadowOutGlow","Outer GlowInGlow","Inner Glow6Blur","Blur6S{6rXRX6rYRY6GlowWGlow Width=Unselect","Unselect=Invert","Invertiion=SelectLayerOm=SetSelection","Setiion=MoveUp=p","p=Copy","Copy=PastePWWidth value must be integer greater than 0PHehHeight value must be integer greater than 0","NeedFileName","Please input file name","NeedUrl","Please inputx URL","NumberValid","Not a number","NumberValidZero","Need a number greater than 0 or equal with 0neAPI","Your browser does not support file APIOArea","Pleasei an area firstzfirmCreate","Be sure to create a new document without save?zfirmMergeVBe sure to merge all visiblems?zfirmp","Be sure to delete thism?","InvalidSInvalid color"];varxeditor_lang={};imag00[04];imag00[1c00[8a00[9b00[5d~4e00[111c4a4b4d00[232e00[212c00[282a00[292b00[252d00[333e00[311d00[3\'^00[3&`00[3)]00[3a|+];imag00[414c00[4-a00[4/b00[454d00[535e00[515c00[585a00[595b00[555d00[636e00[616c00[686a00[696b00[656d00[737e00[717c00[787a00[797b00[784];imag00[79:_00[81:\\00[83:^00[85:`00[87:]00[89;_00[91;\\00[93;^00[95;`00[97;]00[90_~0\\~0^~#0`~!0]~1_00[111\\00[111^00[11#1`00[11!1]00[112_00[122\\00[122^00[12#2`00[12!2]00[123_00[133\\00[133^00[13#3`00[13!3]00[13Y4\\4^#Z!4]5_00[155\\00[155^00[15#5`00[15!5]00[156_6\\6^#6`!6]7_00[177\\00[177^00[17#7`00[17!7]00[178_8\\8^#8`!8]9_00[199\\00[199^00[19#9`00[19!9]00[19$0_00[200\\00[20"0^00[20 0`00[20%0]00[20$1_00[211\\00[21"1^00[21 1`00[21%1]00[21$2_00[222\\00[22"2^00[22 2`00[22%2]00[22$3_00[233\\00[23"3^00[23 3`00[23%3]00[23$Y4\\"4^ Z%4]$5_5\\"5^ 5`%5]$6_6\\"6^ 6`%6]$7_00[277\\00[27"7^00[27 7`00[27%7]00[27$8_8\\"8^ 8`%8]$9_9\\"9^ 9`%9](0_00[30*0\\00[30\'0^00[30&0`00[30)0]00[30(1_00[31*1\\00[31\'1^00[31&1`00[31)1]00[31(2_00[32*2\\00[32\'2^00[32&2`00[32)2]00[32(3_00[33*3\\00[33\'3^00[33&3`00[33)3]00[33(Y00[34*4\\00[34\'4^00[34&Z00[34)4]00[34(5_00[35*5\\00[35\'5^00[35&5`00[35)5]00[35(6_00[36*6\\00[36\'6^00[36&6`00[36)6]00[36(7_00[37*7\\00[37\'7^00[37&7`00[37)7]00[37(8_00[38Z00[3820c00[3840a00[3860b00[3880d00[390,e00[392,c00[394,a00[396,b00[398,d|340e|140c|-0a|/0b00[4084Y00[409+_00[411+\\00[418\\00[414+a00[416+b00[418+d00[420.e00[422.c00[424.a00[426.b00[428.d00[43343e00[43143c00[43-3a00[43/37];editor_lang[OxOc30ageeditor_lang[OxOitor_lang[OxOc300[eeditor_lang[OxOc3geeditor_lang[OxOctEResize_6Group layerL colorM layerMNText_TErase_ied area9434141]]=OxOc300[25]]=OxOc300[2743]]=OxOc300[2549]]=OxOc300[27]]=OxOc300[25]]=OxOc300[33]]=OxOc300[39]]=OxOc300[37]]=OxOc300[31]]=OxOc300[3]]=OxOc300[41]]=OxOc300[3984]]=OxOc300[4294]]=OxOc300[382]]=OxOc300[CS_0]]=OxOc300[]]=OxOc300[18]]=OxOc300[","Property_TNew_4]]=OxOc300[6]]=OxOc300[]]=OxOc300[8]]=OxOc300[9:Cztext_MReTStaeELReCR","y_eMO_eNtMtLMCsMeL","Layer_","Title_:T","Select","Createolygon","","r{","","Tool_","Draw Layer","Width","","Zoom 4_4`Gradient2];imag8];imag4];imag0];imag6];imag5];imag7];imag3];imag9];imag1];imag","Btn_Size","ight"," selectontrastositionRotate layer","Fillue","DeleteatternOffsetResize {CanvasCenterground imageEffect","ConColor00[40","re00[1000[1600[14Brushe","Sge","00[1800[2900[2800[2400[2600[25'
))